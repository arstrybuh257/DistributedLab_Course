using Autofac;
using DuckCoin.Cryptography.Encryption;
using DuckCoin.Wallet.Forms;
using DuckCoin.Wallet.Services;

namespace DuckCoin.Wallet
{
    public partial class AccountForm : Form
    {
        private readonly IAccountManager _accountManager;
        private readonly IAccountService _accountservice;
        private readonly string _accountId;
        private KeyPair _keyPair;

        public AccountForm(string accountId)
        {
            _accountManager = Program.Container.Resolve<IAccountManager>();
            _accountservice = Program.Container.Resolve<IAccountService>();
            _accountId = accountId;
            InitializeComponent();
        }


        private async void account_form_Load(object sender, EventArgs e)
        {
            var account = await _accountservice.GetAccountAsync(_accountId);

            if (account == null)
            {
                ProceedToTheMainForm();
                return;
            }

            textBox_accountAddress.Text = account.PublicKeyHash;
            label_balance.Text = account.Balance.ToString();
            _keyPair = new KeyPair(account.PublicKey, account.PrivateKey);
        }

        private void ProceedToTheMainForm()
        {
            Close();
        }

        private void button_logout_Click(object sender, EventArgs e)
        {
            ProceedToTheMainForm();
        }

        private void button_createTransaction_Click(object sender, EventArgs e)
        {
            ProceedToTheCreateNewTrasactionForm();
        }

        private void ProceedToTheCreateNewTrasactionForm()
        {
            var form = new CreateNewTransactionForm(_keyPair);
            form.ShowDialog();
        }
    }
}