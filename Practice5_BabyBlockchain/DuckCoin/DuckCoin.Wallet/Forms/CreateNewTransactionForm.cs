using Autofac;
using DuckCoin.Dto;
using DuckCoin.Wallet.Core.Abstractions;
using DuckCoin.Wallet.DomainModels;
using DuckCoin.Wallet.Helpers;
using DuckCoin.Wallet.HttpClients;
using DuckCoin.Wallet.Services;

namespace DuckCoin.Wallet.Forms
{
    public partial class CreateNewTransactionForm : Form
    {
        private readonly ITransactionManager _transactionManager;
        private readonly IAccountService _accountServcie;
        private readonly ITransactionService _transactionService;
        private readonly IFullNodeHttpClient _httpClient;
        private byte _operationCount;
        private readonly Account _account;

        public CreateNewTransactionForm(Account account)
        {
            _transactionManager = Program.Container.Resolve<ITransactionManager>();
            _transactionService = Program.Container.Resolve<ITransactionService>();
            _accountServcie = Program.Container.Resolve<IAccountService>();
            _operationCount = 1;
            _account = account;
            _httpClient = Program.Container.Resolve<IFullNodeHttpClient>();
            InitializeComponent();           
        }

        private void button_add2Operation_Click(object sender, EventArgs e)
        {
            label_amount2Title.Visible = true;
            label_operation2Title.Visible = true;
            label_reciver2Title.Visible = true;
            textBox_amount2.Visible = true;
            textBox_receiverAdress2.Visible = true;
            button_add3Operation.Visible = true;
            button_remove2Operation.Visible = true;
            button_add2Operation.Visible = false;
            _operationCount++;
        }

        private void button_remove2Operation_Click(object sender, EventArgs e)
        {
            label_amount2Title.Visible = false;
            label_operation2Title.Visible = false;
            label_reciver2Title.Visible = false;
            textBox_amount2.Visible = false;
            textBox_receiverAdress2.Visible = false;
            button_add3Operation.Visible = false;
            button_remove2Operation.Visible = false;
            button_add2Operation.Visible = true;
            _operationCount--;
        }

        private void button_add3Operation_Click(object sender, EventArgs e)
        {
            label_amount3Title.Visible = true;
            label_operation3Title.Visible = true;
            label_reciver3Title.Visible = true;
            textBox_amount3.Visible = true;
            textBox_receiverAdress3.Visible = true;
            button_remove3Operation.Visible = true;
            button_add3Operation.Visible = false;
            button_remove2Operation.Visible = false;
            _operationCount++;
        }

        private void button_remove3Operation_Click(object sender, EventArgs e)
        {
            label_amount3Title.Visible = false;
            label_operation3Title.Visible = false;
            label_reciver3Title.Visible = false;
            textBox_amount3.Visible = false;
            textBox_receiverAdress3.Visible = false;
            button_remove3Operation.Visible = false;
            button_add3Operation.Visible = true;
            button_remove2Operation.Visible = true;
            _operationCount--;
        }

        //TODO Reformat this method to read operations in more elegant way
        private async void button_confirmTransaction_Click(object sender, EventArgs e)
        {
            List<Operation> operations = new List<Operation>();

            var operation1 = ReadOperation(textBox_receiverAdress1, textBox_amount1);

            if (operation1 == null)
            {
                return;
            }

            operations.Add(operation1);

            if (_operationCount > 1)
            {
                var operation2 = ReadOperation(textBox_receiverAdress2, textBox_amount2);

                if (operation2 == null)
                {
                    return;
                }

                operations.Add(operation2);
            }

            if (_operationCount > 2)
            {
                var operation3 = ReadOperation(textBox_receiverAdress3, textBox_amount3);

                if (operation3 == null)
                {
                    return;
                }

                operations.Add(operation3);
            }

            var transaction = _transactionManager.CreateTransaction(operations, _account.PrivateKey);
            var validationResult = _transactionManager.ValidateTransaction(transaction, _account.Balance);
            
            if (!validationResult.IsValid)
            {
                MessageBox.Show(validationResult.Error);
                return;
            }

            await _transactionService.AddTransactionAsync(transaction);
            
            _account.Balance -= transaction.GetTotalAmount();
            await _accountServcie.UpdateAccountAsync(_account);

            var transactionDto = MappingHelper.MapTransactionToDto(transaction);
            await _httpClient.PostTransactionAsync(transactionDto);

            MessageBox.Show("Transaction was successfully sent to the blockchain.");
            Close();
        }

        private Operation? ReadOperation(TextBox receiverTb, TextBox amountTb)
        {
            if (string.IsNullOrEmpty(receiverTb.Text))
            {
                MessageBox.Show("Provide a Receiver Address for the operation");
                return null;
            }

            if (string.IsNullOrEmpty(amountTb.Text))
            {
                MessageBox.Show("Provide an amount for the operation");
                return null;
            }

            var receiverAddress = receiverTb.Text;
            var amount = Convert.ToDouble(amountTb.Text);

            if (amount < 0)
            {
                MessageBox.Show("Amount must be a positive number.");
                return null;
            }

            return new Operation(_account.AccountAddress, receiverAddress, amount, _account.PublicKey);
        }
    }
}
