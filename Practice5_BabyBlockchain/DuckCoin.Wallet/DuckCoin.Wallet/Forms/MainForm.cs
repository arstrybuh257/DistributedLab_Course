using DuckCoin.Wallet.Services;

namespace DuckCoin.Wallet
{
    public partial class MainForm : Form
    {
        private readonly IAccountManager _accountManager;
        private readonly IAccountService _accountservice;

        public MainForm(IAccountManager accountManager, IAccountService accountservice)
        {
            _accountManager = accountManager;
            _accountservice = accountservice;
            InitializeComponent();
        }

        private async void button_newAdress_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_password.Text))
            {
                MessageBox.Show("Please, fulfil all the fields!");
                return;
            }

            var account = _accountManager.CreateAccount(textBox_password.Text);
            await _accountservice.AddAccountAsync(account);
            MessageBox.Show($"This is your address hash. Use it for signing in the wallet.\n {account.PublicKeyHash}");

            ProceedToAnAccountForm(account.PublicKeyHash);
        }

        private async void button_login_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_login_address.Text)
                || string.IsNullOrEmpty(textBox_login_password.Text))
            {
                MessageBox.Show("Please, fulfil all the fields!");
                return;
            }

            var accountId = textBox_login_address.Text;
            var password = textBox_login_password.Text;

            var validationResult = await _accountservice.ValidatePasswordAsync(accountId, password);

            if(validationResult == false)
            {
                MessageBox.Show("Credentials are wrong!");
                return;
            }

            ProceedToAnAccountForm(accountId);
        }

        private void ProceedToAnAccountForm(string accountId)
        {
            AccountForm accountForm = new AccountForm(_accountManager, _accountservice, accountId);
            accountForm.Show();
        }
    }
}