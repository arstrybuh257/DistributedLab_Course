using DuckCoin.Cryptography;

namespace DuckCoin.Wallet
{
    public partial class MainForm : Form
    {
        IEncryptor _encryptor;

        public MainForm(IEncryptor encryptor)
        {
            _encryptor = encryptor;
            InitializeComponent();
        }

        private void button_newAdress_Click(object sender, EventArgs e)
        {
            var keyPair = _encryptor.GenerateKeys();

            //richTextBox1.Text = $"Public key: {keyPair.PublicKey}\nPrivate key: {keyPair.PrivateKey}";
        }
    }
}