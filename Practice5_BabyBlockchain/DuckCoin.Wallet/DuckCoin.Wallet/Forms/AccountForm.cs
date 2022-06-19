using DuckCoin.Wallet.Forms;
using DuckCoin.Wallet.Services;

namespace DuckCoin.Wallet
{
    public partial class AccountForm : Form
    {
        private readonly IAccountManager _accountManager;
        private readonly IAccountService _accountservice;
        private readonly string _accountId;

        public AccountForm(IAccountManager accountManager, IAccountService accountservice, string accountId)
        {
            _accountManager = accountManager;
            _accountservice = accountservice;
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

            label_accountId.Text = account.PublicKeyHash;
            label_balance.Text = account.Balance.ToString();

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
            var form = new CreateNewTransactionForm();
            form.ShowDialog();
        }
    }
}