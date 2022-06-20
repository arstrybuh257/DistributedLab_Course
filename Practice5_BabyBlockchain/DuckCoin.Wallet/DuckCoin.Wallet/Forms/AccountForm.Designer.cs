namespace DuckCoin.Wallet
{
    partial class AccountForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label_accountId_title = new System.Windows.Forms.Label();
            this.label_accountId = new System.Windows.Forms.Label();
            this.button_logout = new System.Windows.Forms.Button();
            this.label_balance_title = new System.Windows.Forms.Label();
            this.label_balance = new System.Windows.Forms.Label();
            this.button_createTransaction = new System.Windows.Forms.Button();
            this.button_syncronizeBalance = new System.Windows.Forms.Button();
            this.button_getTestTokens = new System.Windows.Forms.Button();
            this.label_logo = new System.Windows.Forms.Label();
            this.label_transactionHistory = new System.Windows.Forms.Label();
            this.richTextBox_transactionsHistory = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label_accountId_title
            // 
            this.label_accountId_title.AutoSize = true;
            this.label_accountId_title.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_accountId_title.Location = new System.Drawing.Point(23, 113);
            this.label_accountId_title.Name = "label_accountId_title";
            this.label_accountId_title.Size = new System.Drawing.Size(130, 37);
            this.label_accountId_title.TabIndex = 0;
            this.label_accountId_title.Text = "AcountId:";
            // 
            // label_accountId
            // 
            this.label_accountId.AutoSize = true;
            this.label_accountId.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_accountId.Location = new System.Drawing.Point(159, 113);
            this.label_accountId.Name = "label_accountId";
            this.label_accountId.Size = new System.Drawing.Size(90, 37);
            this.label_accountId.TabIndex = 1;
            this.label_accountId.Text = "label1";
            // 
            // button_logout
            // 
            this.button_logout.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_logout.Location = new System.Drawing.Point(862, 117);
            this.button_logout.Name = "button_logout";
            this.button_logout.Size = new System.Drawing.Size(100, 37);
            this.button_logout.TabIndex = 2;
            this.button_logout.Text = "Logout";
            this.button_logout.UseVisualStyleBackColor = true;
            this.button_logout.Click += new System.EventHandler(this.button_logout_Click);
            // 
            // label_balance_title
            // 
            this.label_balance_title.AutoSize = true;
            this.label_balance_title.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_balance_title.Location = new System.Drawing.Point(23, 180);
            this.label_balance_title.Name = "label_balance_title";
            this.label_balance_title.Size = new System.Drawing.Size(202, 37);
            this.label_balance_title.TabIndex = 3;
            this.label_balance_title.Text = "Balance in DCC:";
            // 
            // label_balance
            // 
            this.label_balance.AutoSize = true;
            this.label_balance.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_balance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label_balance.Location = new System.Drawing.Point(240, 172);
            this.label_balance.Name = "label_balance";
            this.label_balance.Size = new System.Drawing.Size(146, 47);
            this.label_balance.TabIndex = 4;
            this.label_balance.Text = "Balance:";
            // 
            // button_createTransaction
            // 
            this.button_createTransaction.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_createTransaction.Location = new System.Drawing.Point(23, 254);
            this.button_createTransaction.Name = "button_createTransaction";
            this.button_createTransaction.Size = new System.Drawing.Size(254, 67);
            this.button_createTransaction.TabIndex = 5;
            this.button_createTransaction.Text = "Create new transaction";
            this.button_createTransaction.UseVisualStyleBackColor = true;
            this.button_createTransaction.Click += new System.EventHandler(this.button_createTransaction_Click);
            // 
            // button_syncronizeBalance
            // 
            this.button_syncronizeBalance.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_syncronizeBalance.Location = new System.Drawing.Point(23, 348);
            this.button_syncronizeBalance.Name = "button_syncronizeBalance";
            this.button_syncronizeBalance.Size = new System.Drawing.Size(254, 67);
            this.button_syncronizeBalance.TabIndex = 6;
            this.button_syncronizeBalance.Text = "Syncronize balance";
            this.button_syncronizeBalance.UseVisualStyleBackColor = true;
            // 
            // button_getTestTokens
            // 
            this.button_getTestTokens.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_getTestTokens.Location = new System.Drawing.Point(23, 446);
            this.button_getTestTokens.Name = "button_getTestTokens";
            this.button_getTestTokens.Size = new System.Drawing.Size(254, 67);
            this.button_getTestTokens.TabIndex = 7;
            this.button_getTestTokens.Text = "Get test tokens";
            this.button_getTestTokens.UseVisualStyleBackColor = true;
            // 
            // label_logo
            // 
            this.label_logo.AutoSize = true;
            this.label_logo.Font = new System.Drawing.Font("Tempus Sans ITC", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_logo.Location = new System.Drawing.Point(311, 25);
            this.label_logo.Name = "label_logo";
            this.label_logo.Size = new System.Drawing.Size(371, 62);
            this.label_logo.TabIndex = 9;
            this.label_logo.Text = "DuckCoin Wallet";
            // 
            // label_transactionHistory
            // 
            this.label_transactionHistory.AutoSize = true;
            this.label_transactionHistory.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_transactionHistory.Location = new System.Drawing.Point(522, 229);
            this.label_transactionHistory.Name = "label_transactionHistory";
            this.label_transactionHistory.Size = new System.Drawing.Size(226, 32);
            this.label_transactionHistory.TabIndex = 10;
            this.label_transactionHistory.Text = "Transactions History";
            // 
            // richTextBox_transactionsHistory
            // 
            this.richTextBox_transactionsHistory.Location = new System.Drawing.Point(356, 280);
            this.richTextBox_transactionsHistory.Name = "richTextBox_transactionsHistory";
            this.richTextBox_transactionsHistory.Size = new System.Drawing.Size(580, 233);
            this.richTextBox_transactionsHistory.TabIndex = 11;
            this.richTextBox_transactionsHistory.Text = "";
            // 
            // AccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.richTextBox_transactionsHistory);
            this.Controls.Add(this.label_transactionHistory);
            this.Controls.Add(this.label_logo);
            this.Controls.Add(this.button_getTestTokens);
            this.Controls.Add(this.button_syncronizeBalance);
            this.Controls.Add(this.button_createTransaction);
            this.Controls.Add(this.label_balance);
            this.Controls.Add(this.label_balance_title);
            this.Controls.Add(this.button_logout);
            this.Controls.Add(this.label_accountId);
            this.Controls.Add(this.label_accountId_title);
            this.Name = "AccountForm";
            this.Text = "AccountForm";
            this.Load += new System.EventHandler(this.account_form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label_accountId_title;
        private Label label_accountId;
        private Button button_logout;
        private Label label_balance_title;
        private Label label_balance;
        private Button button_createTransaction;
        private Button button_syncronizeBalance;
        private Button button_getTestTokens;
        private Label label_logo;
        private Label label_transactionHistory;
        private RichTextBox richTextBox_transactionsHistory;
    }
}