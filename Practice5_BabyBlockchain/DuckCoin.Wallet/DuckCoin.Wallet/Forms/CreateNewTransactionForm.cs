namespace DuckCoin.Wallet.Forms
{
    public partial class CreateNewTransactionForm : Form
    {
        private byte _operationCount;

        public CreateNewTransactionForm()
        {
            _operationCount = 0;
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
    }
}
