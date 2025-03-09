namespace PowerSql.Forms
{
    partial class ArchiveForm
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
            panel1 = new Panel();
            connectionsTextBox = new TextBox();
            activateButton = new Button();
            queryTextBox = new TextBox();
            queriesListBox = new ListBox();
            splitter1 = new Splitter();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(connectionsTextBox);
            panel1.Controls.Add(activateButton);
            panel1.Controls.Add(queryTextBox);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(325, 0);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(788, 817);
            panel1.TabIndex = 0;
            // 
            // connectionsTextBox
            // 
            connectionsTextBox.Location = new Point(9, 13);
            connectionsTextBox.Name = "connectionsTextBox";
            connectionsTextBox.ReadOnly = true;
            connectionsTextBox.Size = new Size(625, 31);
            connectionsTextBox.TabIndex = 4;
            // 
            // activateButton
            // 
            activateButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            activateButton.Location = new Point(9, 780);
            activateButton.Name = "activateButton";
            activateButton.Size = new Size(129, 33);
            activateButton.TabIndex = 3;
            activateButton.Text = "&Activate";
            activateButton.UseVisualStyleBackColor = true;
            activateButton.Click += ActivateButton_Click;
            // 
            // queryTextBox
            // 
            queryTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            queryTextBox.Location = new Point(9, 52);
            queryTextBox.Margin = new Padding(4, 5, 4, 5);
            queryTextBox.Multiline = true;
            queryTextBox.Name = "queryTextBox";
            queryTextBox.ReadOnly = true;
            queryTextBox.Size = new Size(768, 720);
            queryTextBox.TabIndex = 1;
            // 
            // queriesListBox
            // 
            queriesListBox.Dock = DockStyle.Left;
            queriesListBox.FormattingEnabled = true;
            queriesListBox.Location = new Point(0, 0);
            queriesListBox.Name = "queriesListBox";
            queriesListBox.Size = new Size(315, 817);
            queriesListBox.TabIndex = 1;
            queriesListBox.SelectedIndexChanged += QueriesListBox_SelectedIndexChanged;
            // 
            // splitter1
            // 
            splitter1.Location = new Point(315, 0);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(10, 817);
            splitter1.TabIndex = 2;
            splitter1.TabStop = false;
            // 
            // ArchiveForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(splitter1);
            Controls.Add(queriesListBox);
            Margin = new Padding(4, 5, 4, 5);
            Name = "ArchiveForm";
            Size = new Size(1113, 817);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private ListBox queriesListBox;
        private Splitter splitter1;
        private TextBox queryTextBox;
        private Button activateButton;
        private TextBox connectionsTextBox;
    }
}
