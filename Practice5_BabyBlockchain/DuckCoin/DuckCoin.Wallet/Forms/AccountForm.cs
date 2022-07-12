using Autofac;
using DuckCoin.Wallet.DomainModels;
using DuckCoin.Wallet.HttpClients;
using DuckCoin.Wallet.Services;

namespace DuckCoin.Wallet.Forms
{
    public partial class AccountForm : Form
    {
        private readonly IAccountService _accountService;
        private readonly IFullNodeHttpClient _fullNodeHttpClient;
        private Account _account;

        public AccountForm(Account account)
        {
            _account = account;
            _accountService = Program.Container.Resolve<IAccountService>();
            InitializeComponent();
            textBox_accountAddress.Text = _account.AccountAddress;
            label_balance.Text = _account.Balance.ToString();
            _fullNodeHttpClient = Program.Container.Resolve<IFullNodeHttpClient>();
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
            await ProceedToTheCreateNewTransactionForm();
        }

        private async Task ProceedToTheCreateNewTransactionForm()
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

        private async void button_syncronizeBalance_Click(object sender, EventArgs e)
        {
            var operations = await _fullNodeHttpClient.GetAllAccountOperationsAsync(_account.AccountAddress);
        }
    }
}