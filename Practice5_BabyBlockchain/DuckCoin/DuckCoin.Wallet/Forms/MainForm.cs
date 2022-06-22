using Autofac;
using DuckCoin.Wallet.Services;

namespace DuckCoin.Wallet
{
    public partial class MainForm : Form
    {
        private readonly IAccountManager _accountManager;
        private readonly IAccountService _accountservice;

        public MainForm()
        {
            _accountManager = Program.Container.Resolve<IAccountManager>();
            _accountservice = Program.Container.Resolve<IAccountService>();
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

            await ProceedToAnAccountFormAsync(account.PublicKeyHash);
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

            await ProceedToAnAccountFormAsync(accountId);
        }

        private async Task ProceedToAnAccountFormAsync(string accountId)
        {
            var account = await _accountservice.GetAccountAsync(accountId);

            if (account == null)
            {
                MessageBox.Show("This account was not found.");
                return;
            }

            AccountForm accountForm = new AccountForm(account);
            accountForm.Show();
            Hide();
        }
    }
}