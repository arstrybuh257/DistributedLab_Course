using DuckCoin.Wallet.Services;

namespace DuckCoin.Wallet
{
    public partial class MainForm : Form
    {
        IAccountManager _accountManager;
        IAccountService _accountservice;

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

            ProceedToAnAccountForm();
        }

        private async void button_login_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_login_address.Text)
                || string.IsNullOrEmpty(textBox_login_password.Text))
            {
                MessageBox.Show("Please, fulfil all the fields!");
                return;
            }

            var validationResult = await _accountservice.ValidatePasswordAsync(textBox_login_address.Text, textBox_login_password.Text);

            if(validationResult == false)
            {
                MessageBox.Show("Credentials are wrong!");
                return;
            }

            ProceedToAnAccountForm();
        }

        private void ProceedToAnAccountForm()
        {
            AccountForm accountForm = new AccountForm();
            accountForm.Show();
            Hide();
        }
    }
}