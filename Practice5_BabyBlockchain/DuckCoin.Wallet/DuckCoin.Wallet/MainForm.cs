using DuckCoin.Wallet.DataAccess;

namespace DuckCoin.Wallet
{
    public partial class MainForm : Form
    {
        IAccountManager _accountManager;
        IAccountRepository _accountRepository;

        public MainForm(IAccountManager accountManager, IAccountRepository accountRepository)
        {
            _accountManager = accountManager;
            _accountRepository = accountRepository;
            InitializeComponent();
        }

        private void button_newAdress_Click(object sender, EventArgs e)
        {
            var account = _accountManager.CreateAccount(textBox_password.Text);
            _accountRepository.AddAccount(account);
        }
    }
}