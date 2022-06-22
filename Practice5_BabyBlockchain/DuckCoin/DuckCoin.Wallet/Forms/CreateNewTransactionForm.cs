using Autofac;
using DuckCoin.Cryptography.Encryption;
using DuckCoin.Wallet.Core;
using DuckCoin.Wallet.DomainModels;

namespace DuckCoin.Wallet.Forms
{
    public partial class CreateNewTransactionForm : Form
    {
        private readonly ITransactionManager _transactionManager;
        private byte _operationCount;
        private readonly KeyPair _keyPair;

        public CreateNewTransactionForm(KeyPair keyPair)
        {
            _keyPair = keyPair;
            _transactionManager = Program.Container.Resolve<ITransactionManager>();
            _operationCount = 1;
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
        private void button_confirmTransaction_Click(object sender, EventArgs e)
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

            var transaction = _transactionManager.CreateTransaction(operations, _keyPair.PrivateKey);
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

            return new Operation(_keyPair.PublicKey, receiverAddress, amount);
        }
    }
}
