using Autofac;
using DuckCoin.Wallet.DomainModels;
using DuckCoin.Wallet.Forms;
using DuckCoin.Wallet.Services;

namespace DuckCoin.Wallet
{
    public partial class AccountForm : Form
    {
        private readonly IAccountService _accountService;
        private Account _account;

        public AccountForm(Account account)
        {
            _account = account;
            _accountService = Program.Container.Resolve<IAccountService>(); 
            InitializeComponent();
            textBox_accountAddress.Text = _account.AccountAddress;
            label_balance.Text = _account.Balance.ToString();
        }

        private void ProceedToTheMainForm()
        {
            var mainForm = Program.Container.Resolve<MainForm>();
            mainForm.Show();
            Close();
        }

        private void button_logout_Click(object sender, EventArgs e)
        {
            ProceedToTheMainForm();
        }

        private async void button_createTransaction_Click(object sender, EventArgs e)
        {
            await ProceedToTheCreateNewTrasactionForm();
        }

        private async Task ProceedToTheCreateNewTrasactionForm()
        {
            var form = new CreateNewTransactionForm(_account);
            form.ShowDialog();
            await ReloadAccountData();
        }

        private async Task ReloadAccountData()
        {
            _account = await _accountService.GetAccountAsync(_account.AccountAddress);
            label_balance.Text = _account.Balance.ToString();
        }
    }
}