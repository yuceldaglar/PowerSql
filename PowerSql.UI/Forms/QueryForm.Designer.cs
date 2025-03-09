namespace PowerSql.Forms
{
    partial class QueryForm
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
            queryDataGridView = new DataGridView();
            splitContainer = new SplitContainer();
            queryTextBox = new TextBox();
            panel1 = new Panel();
            nameTextBox = new TextBox();
            runButton = new Button();
            connectionsCombo = new ComboBox();
            tabControl1 = new TabControl();
            resultTabPage = new TabPage();
            resultPanel = new Panel();
            tablesComboBox = new ComboBox();
            messagesTabPage = new TabPage();
            messagesTextBox = new TextBox();
            panel2 = new Panel();
            ((System.ComponentModel.ISupportInitialize)queryDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            panel1.SuspendLayout();
            tabControl1.SuspendLayout();
            resultTabPage.SuspendLayout();
            resultPanel.SuspendLayout();
            messagesTabPage.SuspendLayout();
            SuspendLayout();
            // 
            // queryDataGridView
            // 
            queryDataGridView.AllowUserToAddRows = false;
            queryDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            queryDataGridView.Dock = DockStyle.Fill;
            queryDataGridView.Location = new Point(3, 53);
            queryDataGridView.Margin = new Padding(4, 5, 4, 5);
            queryDataGridView.Name = "queryDataGridView";
            queryDataGridView.ReadOnly = true;
            queryDataGridView.RowHeadersWidth = 62;
            queryDataGridView.Size = new Size(1075, 455);
            queryDataGridView.TabIndex = 0;
            // 
            // splitContainer
            // 
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Location = new Point(0, 0);
            splitContainer.Margin = new Padding(4, 5, 4, 5);
            splitContainer.Name = "splitContainer";
            splitContainer.Orientation = Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(queryTextBox);
            splitContainer.Panel1.Controls.Add(panel1);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(tabControl1);
            splitContainer.Size = new Size(1089, 832);
            splitContainer.SplitterDistance = 276;
            splitContainer.SplitterWidth = 7;
            splitContainer.TabIndex = 1;
            // 
            // queryTextBox
            // 
            queryTextBox.Dock = DockStyle.Fill;
            queryTextBox.Location = new Point(0, 87);
            queryTextBox.Margin = new Padding(4, 5, 4, 5);
            queryTextBox.Multiline = true;
            queryTextBox.Name = "queryTextBox";
            queryTextBox.Size = new Size(1089, 189);
            queryTextBox.TabIndex = 0;
            queryTextBox.TextChanged += QueryTextBox_TextChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(nameTextBox);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(runButton);
            panel1.Controls.Add(connectionsCombo);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1089, 87);
            panel1.TabIndex = 1;
            // 
            // nameTextBox
            // 
            nameTextBox.BackColor = SystemColors.Control;
            nameTextBox.BorderStyle = BorderStyle.None;
            nameTextBox.Location = new Point(13, 12);
            nameTextBox.Margin = new Padding(4, 5, 4, 5);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(624, 24);
            nameTextBox.TabIndex = 2;
            // 
            // runButton
            // 
            runButton.Location = new Point(414, 44);
            runButton.Name = "runButton";
            runButton.Size = new Size(86, 33);
            runButton.TabIndex = 1;
            runButton.Text = "&Run";
            runButton.UseVisualStyleBackColor = true;
            runButton.Click += RunButton_Click;
            // 
            // connectionsCombo
            // 
            connectionsCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            connectionsCombo.FormattingEnabled = true;
            connectionsCombo.Location = new Point(13, 44);
            connectionsCombo.Name = "connectionsCombo";
            connectionsCombo.Size = new Size(395, 33);
            connectionsCombo.TabIndex = 0;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(resultTabPage);
            tabControl1.Controls.Add(messagesTabPage);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1089, 549);
            tabControl1.TabIndex = 1;
            // 
            // resultTabPage
            // 
            resultTabPage.Controls.Add(queryDataGridView);
            resultTabPage.Controls.Add(resultPanel);
            resultTabPage.Location = new Point(4, 34);
            resultTabPage.Name = "resultTabPage";
            resultTabPage.Padding = new Padding(3);
            resultTabPage.Size = new Size(1081, 511);
            resultTabPage.TabIndex = 0;
            resultTabPage.Text = "Result";
            resultTabPage.UseVisualStyleBackColor = true;
            // 
            // resultPanel
            // 
            resultPanel.Controls.Add(tablesComboBox);
            resultPanel.Dock = DockStyle.Top;
            resultPanel.Location = new Point(3, 3);
            resultPanel.Name = "resultPanel";
            resultPanel.Size = new Size(1075, 50);
            resultPanel.TabIndex = 1;
            resultPanel.Visible = false;
            // 
            // tablesComboBox
            // 
            tablesComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            tablesComboBox.FormattingEnabled = true;
            tablesComboBox.Location = new Point(6, 7);
            tablesComboBox.Name = "tablesComboBox";
            tablesComboBox.Size = new Size(273, 33);
            tablesComboBox.TabIndex = 0;
            // 
            // messagesTabPage
            // 
            messagesTabPage.Controls.Add(messagesTextBox);
            messagesTabPage.Location = new Point(4, 34);
            messagesTabPage.Name = "messagesTabPage";
            messagesTabPage.Padding = new Padding(3);
            messagesTabPage.Size = new Size(1081, 511);
            messagesTabPage.TabIndex = 1;
            messagesTabPage.Text = "Messages";
            messagesTabPage.UseVisualStyleBackColor = true;
            // 
            // messagesTextBox
            // 
            messagesTextBox.Dock = DockStyle.Fill;
            messagesTextBox.Location = new Point(3, 3);
            messagesTextBox.Margin = new Padding(4, 5, 4, 5);
            messagesTextBox.Multiline = true;
            messagesTextBox.Name = "messagesTextBox";
            messagesTextBox.Size = new Size(1075, 505);
            messagesTextBox.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlDark;
            panel2.Location = new Point(13, 28);
            panel2.Name = "panel2";
            panel2.Size = new Size(624, 10);
            panel2.TabIndex = 3;
            // 
            // QueryForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer);
            Name = "QueryForm";
            Size = new Size(1089, 832);
            ((System.ComponentModel.ISupportInitialize)queryDataGridView).EndInit();
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel1.PerformLayout();
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabControl1.ResumeLayout(false);
            resultTabPage.ResumeLayout(false);
            resultPanel.ResumeLayout(false);
            messagesTabPage.ResumeLayout(false);
            messagesTabPage.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView queryDataGridView;
        private SplitContainer splitContainer;
        private TextBox queryTextBox;
        private Panel panel1;
        private ComboBox connectionsCombo;
        private Button runButton;
        private TextBox nameTextBox;
        private TabControl tabControl1;
        private TabPage resultTabPage;
        private TabPage messagesTabPage;
        private TextBox messagesTextBox;
        private Panel resultPanel;
        private ComboBox tablesComboBox;
        private Panel panel2;
    }
}
