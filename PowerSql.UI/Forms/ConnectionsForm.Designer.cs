namespace PowerSql.Forms
{
    partial class ConnectionsForm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            connectionsListBox = new ListBox();
            splitter1 = new Splitter();
            panel1 = new Panel();
            saveConnectionButton = new Button();
            integratedSecurityCheckBox = new CheckBox();
            passwordTextBox = new TextBox();
            label4 = new Label();
            usernameTextBox = new TextBox();
            label3 = new Label();
            databaseTextBox = new TextBox();
            label2 = new Label();
            serverTextBox = new TextBox();
            label1 = new Label();
            newConnectionButton = new Button();
            deleteButton = new Button();
            label5 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // connectionsListBox
            // 
            connectionsListBox.Dock = DockStyle.Left;
            connectionsListBox.FormattingEnabled = true;
            connectionsListBox.IntegralHeight = false;
            connectionsListBox.Location = new Point(0, 0);
            connectionsListBox.Name = "connectionsListBox";
            connectionsListBox.Size = new Size(547, 1064);
            connectionsListBox.TabIndex = 0;
            connectionsListBox.SelectedIndexChanged += ConnectionsListBox_SelectedIndexChanged;
            // 
            // splitter1
            // 
            splitter1.Location = new Point(547, 0);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(4, 1064);
            splitter1.TabIndex = 1;
            splitter1.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(label5);
            panel1.Controls.Add(saveConnectionButton);
            panel1.Controls.Add(integratedSecurityCheckBox);
            panel1.Controls.Add(passwordTextBox);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(usernameTextBox);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(databaseTextBox);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(serverTextBox);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(551, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(872, 1064);
            panel1.TabIndex = 2;
            // 
            // saveConnectionButton
            // 
            saveConnectionButton.Location = new Point(6, 374);
            saveConnectionButton.Name = "saveConnectionButton";
            saveConnectionButton.Size = new Size(112, 34);
            saveConnectionButton.TabIndex = 4;
            saveConnectionButton.Text = "Save";
            saveConnectionButton.UseVisualStyleBackColor = true;
            saveConnectionButton.Click += SaveConnectionButton_Click;
            // 
            // integratedSecurityCheckBox
            // 
            integratedSecurityCheckBox.AutoSize = true;
            integratedSecurityCheckBox.Location = new Point(6, 317);
            integratedSecurityCheckBox.Name = "integratedSecurityCheckBox";
            integratedSecurityCheckBox.Size = new Size(187, 29);
            integratedSecurityCheckBox.TabIndex = 9;
            integratedSecurityCheckBox.Text = "Integrated Security";
            integratedSecurityCheckBox.UseVisualStyleBackColor = true;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(6, 243);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(371, 31);
            passwordTextBox.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 215);
            label4.Name = "label4";
            label4.Size = new Size(87, 25);
            label4.TabIndex = 6;
            label4.Text = "Password";
            // 
            // usernameTextBox
            // 
            usernameTextBox.Location = new Point(6, 181);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(371, 31);
            usernameTextBox.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 153);
            label3.Name = "label3";
            label3.Size = new Size(91, 25);
            label3.TabIndex = 4;
            label3.Text = "Username";
            // 
            // databaseTextBox
            // 
            databaseTextBox.Location = new Point(6, 119);
            databaseTextBox.Name = "databaseTextBox";
            databaseTextBox.Size = new Size(371, 31);
            databaseTextBox.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 91);
            label2.Name = "label2";
            label2.Size = new Size(86, 25);
            label2.TabIndex = 2;
            label2.Text = "Database";
            // 
            // serverTextBox
            // 
            serverTextBox.Location = new Point(6, 57);
            serverTextBox.Name = "serverTextBox";
            serverTextBox.Size = new Size(371, 31);
            serverTextBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 29);
            label1.Name = "label1";
            label1.Size = new Size(61, 25);
            label1.TabIndex = 0;
            label1.Text = "Server";
            // 
            // newConnectionButton
            // 
            newConnectionButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            newConnectionButton.Location = new Point(13, 1018);
            newConnectionButton.Name = "newConnectionButton";
            newConnectionButton.Size = new Size(184, 34);
            newConnectionButton.TabIndex = 3;
            newConnectionButton.Text = "New Connection";
            newConnectionButton.UseVisualStyleBackColor = true;
            newConnectionButton.Click += NewConnectionButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            deleteButton.Location = new Point(203, 1018);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(111, 34);
            deleteButton.TabIndex = 4;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += DeleteButton_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 277);
            label5.Name = "label5";
            label5.Size = new Size(394, 25);
            label5.TabIndex = 10;
            label5.Text = "* Do not use production or sensitive passwords.";
            // 
            // ConnectionsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(deleteButton);
            Controls.Add(newConnectionButton);
            Controls.Add(panel1);
            Controls.Add(splitter1);
            Controls.Add(connectionsListBox);
            Name = "ConnectionsForm";
            Size = new Size(1423, 1064);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ListBox connectionsListBox;
        private Splitter splitter1;
        private Panel panel1;
        private TextBox passwordTextBox;
        private Label label4;
        private TextBox usernameTextBox;
        private Label label3;
        private TextBox databaseTextBox;
        private Label label2;
        private TextBox serverTextBox;
        private Label label1;
        private CheckBox integratedSecurityCheckBox;
        private Button newConnectionButton;
        private Button saveConnectionButton;
        private Button deleteButton;
        private Label label5;
    }
}
