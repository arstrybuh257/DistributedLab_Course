namespace DuckCoin.Wallet
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_newAdress = new System.Windows.Forms.Button();
            this.tabControl_login = new System.Windows.Forms.TabControl();
            this.tabPage_login = new System.Windows.Forms.TabPage();
            this.button_login = new System.Windows.Forms.Button();
            this.textBox_login_password = new System.Windows.Forms.TextBox();
            this.textBox_login_address = new System.Windows.Forms.TextBox();
            this.label_provide_password = new System.Windows.Forms.Label();
            this.label_enter_address = new System.Windows.Forms.Label();
            this.tabPage_registration = new System.Windows.Forms.TabPage();
            this.label_create_password = new System.Windows.Forms.Label();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.label_logo = new System.Windows.Forms.Label();
            this.tabControl_login.SuspendLayout();
            this.tabPage_login.SuspendLayout();
            this.tabPage_registration.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_newAdress
            // 
            this.button_newAdress.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_newAdress.Location = new System.Drawing.Point(351, 223);
            this.button_newAdress.Name = "button_newAdress";
            this.button_newAdress.Size = new System.Drawing.Size(212, 54);
            this.button_newAdress.TabIndex = 0;
            this.button_newAdress.Text = "Create new address";
            this.button_newAdress.UseVisualStyleBackColor = true;
            this.button_newAdress.Click += new System.EventHandler(this.button_newAdress_Click);
            // 
            // tabControl_login
            // 
            this.tabControl_login.Controls.Add(this.tabPage_login);
            this.tabControl_login.Controls.Add(this.tabPage_registration);
            this.tabControl_login.Location = new System.Drawing.Point(12, 74);
            this.tabControl_login.Name = "tabControl_login";
            this.tabControl_login.SelectedIndex = 0;
            this.tabControl_login.Size = new System.Drawing.Size(960, 466);
            this.tabControl_login.TabIndex = 1;
            // 
            // tabPage_login
            // 
            this.tabPage_login.AllowDrop = true;
            this.tabPage_login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabPage_login.Controls.Add(this.button_login);
            this.tabPage_login.Controls.Add(this.textBox_login_password);
            this.tabPage_login.Controls.Add(this.textBox_login_address);
            this.tabPage_login.Controls.Add(this.label_provide_password);
            this.tabPage_login.Controls.Add(this.label_enter_address);
            this.tabPage_login.Location = new System.Drawing.Point(4, 24);
            this.tabPage_login.Name = "tabPage_login";
            this.tabPage_login.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_login.Size = new System.Drawing.Size(952, 438);
            this.tabPage_login.TabIndex = 0;
            this.tabPage_login.Text = "Sign in";
            this.tabPage_login.UseVisualStyleBackColor = true;
            // 
            // button_login
            // 
            this.button_login.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_login.Location = new System.Drawing.Point(394, 269);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(149, 59);
            this.button_login.TabIndex = 4;
            this.button_login.Text = "Login";
            this.button_login.UseVisualStyleBackColor = true;
            // 
            // textBox_login_password
            // 
            this.textBox_login_password.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_login_password.Location = new System.Drawing.Point(354, 188);
            this.textBox_login_password.Name = "textBox_login_password";
            this.textBox_login_password.Size = new System.Drawing.Size(226, 33);
            this.textBox_login_password.TabIndex = 3;
            // 
            // textBox_login_address
            // 
            this.textBox_login_address.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_login_address.Location = new System.Drawing.Point(54, 91);
            this.textBox_login_address.Name = "textBox_login_address";
            this.textBox_login_address.Size = new System.Drawing.Size(876, 33);
            this.textBox_login_address.TabIndex = 2;
            // 
            // label_provide_password
            // 
            this.label_provide_password.AutoSize = true;
            this.label_provide_password.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_provide_password.Location = new System.Drawing.Point(374, 151);
            this.label_provide_password.Name = "label_provide_password";
            this.label_provide_password.Size = new System.Drawing.Size(184, 25);
            this.label_provide_password.TabIndex = 1;
            this.label_provide_password.Text = "Enter your password";
            // 
            // label_enter_address
            // 
            this.label_enter_address.AutoSize = true;
            this.label_enter_address.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_enter_address.Location = new System.Drawing.Point(354, 51);
            this.label_enter_address.Name = "label_enter_address";
            this.label_enter_address.Size = new System.Drawing.Size(255, 25);
            this.label_enter_address.TabIndex = 0;
            this.label_enter_address.Text = "Enter your DuckCoin address";
            // 
            // tabPage_registration
            // 
            this.tabPage_registration.Controls.Add(this.label_create_password);
            this.tabPage_registration.Controls.Add(this.textBox_password);
            this.tabPage_registration.Controls.Add(this.button_newAdress);
            this.tabPage_registration.Location = new System.Drawing.Point(4, 24);
            this.tabPage_registration.Name = "tabPage_registration";
            this.tabPage_registration.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_registration.Size = new System.Drawing.Size(952, 438);
            this.tabPage_registration.TabIndex = 1;
            this.tabPage_registration.Text = "Create new address";
            this.tabPage_registration.UseVisualStyleBackColor = true;
            // 
            // label_create_password
            // 
            this.label_create_password.AutoSize = true;
            this.label_create_password.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_create_password.Location = new System.Drawing.Point(365, 122);
            this.label_create_password.Name = "label_create_password";
            this.label_create_password.Size = new System.Drawing.Size(181, 25);
            this.label_create_password.TabIndex = 2;
            this.label_create_password.Text = "Enter new password";
            // 
            // textBox_password
            // 
            this.textBox_password.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_password.Location = new System.Drawing.Point(351, 160);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.PasswordChar = '*';
            this.textBox_password.Size = new System.Drawing.Size(212, 33);
            this.textBox_password.TabIndex = 1;
            // 
            // label_logo
            // 
            this.label_logo.AutoSize = true;
            this.label_logo.Font = new System.Drawing.Font("Tempus Sans ITC", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_logo.Location = new System.Drawing.Point(302, 9);
            this.label_logo.Name = "label_logo";
            this.label_logo.Size = new System.Drawing.Size(371, 62);
            this.label_logo.TabIndex = 2;
            this.label_logo.Text = "DuckCoin Wallet";
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.label_logo);
            this.Controls.Add(this.tabControl_login);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.tabControl_login.ResumeLayout(false);
            this.tabPage_login.ResumeLayout(false);
            this.tabPage_login.PerformLayout();
            this.tabPage_registration.ResumeLayout(false);
            this.tabPage_registration.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button_newAdress;
        private TabControl tabControl_login;
        private TabPage tabPage_login;
        private TabPage tabPage_registration;
        private Label label_logo;
        private Button button_login;
        private TextBox textBox_login_password;
        private TextBox textBox_login_address;
        private Label label_provide_password;
        private Label label_enter_address;
        private Label label_create_password;
        private TextBox textBox_password;
    }
}