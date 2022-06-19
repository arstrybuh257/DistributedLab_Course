using DuckCoin.Cryptography;

namespace DuckCoin.Wallet
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button_newAdress_Click(object sender, EventArgs e)
        {
            var encryptor = new RSAEncryptor();
            var keyPair = encryptor.GenerateKeys();
            //richTextBox1.Text = $"Public key: {keyPair.PublicKey}\nPrivate key: {keyPair.PrivateKey}";
        }
    }
}