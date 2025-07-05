namespace _05_ftp_forms
{
    partial class Form1
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
            textBoxHost = new TextBox();
            labelHost = new Label();
            labelUser = new Label();
            textBoxUser = new TextBox();
            labelPassword = new Label();
            textBoxPassword = new TextBox();
            btnConnect = new Button();
            listBoxItems = new ListBox();
            btnCreateDir = new Button();
            textBoxDirName = new TextBox();
            SuspendLayout();
            // 
            // textBoxHost
            // 
            textBoxHost.Location = new Point(68, 2);
            textBoxHost.Name = "textBoxHost";
            textBoxHost.Size = new Size(230, 27);
            textBoxHost.TabIndex = 0;
            // 
            // labelHost
            // 
            labelHost.AutoSize = true;
            labelHost.Location = new Point(12, 9);
            labelHost.Name = "labelHost";
            labelHost.Size = new Size(40, 20);
            labelHost.TabIndex = 1;
            labelHost.Text = "Host";
            // 
            // labelUser
            // 
            labelUser.AutoSize = true;
            labelUser.Location = new Point(302, 9);
            labelUser.Name = "labelUser";
            labelUser.Size = new Size(38, 20);
            labelUser.TabIndex = 3;
            labelUser.Text = "User";
            // 
            // textBoxUser
            // 
            textBoxUser.Location = new Point(346, 2);
            textBoxUser.Name = "textBoxUser";
            textBoxUser.Size = new Size(110, 27);
            textBoxUser.TabIndex = 2;
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Location = new Point(462, 9);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(70, 20);
            labelPassword.TabIndex = 5;
            labelPassword.Text = "Password";
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(538, 2);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(110, 27);
            textBoxPassword.TabIndex = 4;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(654, 0);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(94, 29);
            btnConnect.TabIndex = 6;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // listBoxItems
            // 
            listBoxItems.FormattingEnabled = true;
            listBoxItems.Location = new Point(12, 67);
            listBoxItems.Name = "listBoxItems";
            listBoxItems.Size = new Size(444, 404);
            listBoxItems.TabIndex = 7;
            listBoxItems.MouseDoubleClick += listBoxItems_MouseDoubleClick;
            // 
            // btnCreateDir
            // 
            btnCreateDir.Location = new Point(462, 100);
            btnCreateDir.Name = "btnCreateDir";
            btnCreateDir.Size = new Size(163, 29);
            btnCreateDir.TabIndex = 8;
            btnCreateDir.Text = "Create directory";
            btnCreateDir.UseVisualStyleBackColor = true;
            btnCreateDir.Click += btnCreateDir_Click;
            // 
            // textBoxDirName
            // 
            textBoxDirName.Location = new Point(462, 67);
            textBoxDirName.Name = "textBoxDirName";
            textBoxDirName.Size = new Size(163, 27);
            textBoxDirName.TabIndex = 9;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(878, 492);
            Controls.Add(textBoxDirName);
            Controls.Add(btnCreateDir);
            Controls.Add(listBoxItems);
            Controls.Add(btnConnect);
            Controls.Add(labelPassword);
            Controls.Add(textBoxPassword);
            Controls.Add(labelUser);
            Controls.Add(textBoxUser);
            Controls.Add(labelHost);
            Controls.Add(textBoxHost);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxHost;
        private Label labelHost;
        private Label labelUser;
        private TextBox textBoxUser;
        private Label labelPassword;
        private TextBox textBoxPassword;
        private Button btnConnect;
        private ListBox listBoxItems;
        private Button btnCreateDir;
        private TextBox textBoxDirName;
    }
}
