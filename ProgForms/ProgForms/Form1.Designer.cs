namespace ProgForms
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
            GBOpcoes = new GroupBox();
            filesListBox = new ListBox();
            LogPanel = new Panel();
            fileTextBox = new TextBox();
            Exit = new Button();
            label1 = new Label();
            saveFileButtton = new Button();
            newFileButton = new Button();
            GBOpcoes.SuspendLayout();
            LogPanel.SuspendLayout();
            SuspendLayout();
            // 
            // GBOpcoes
            // 
            GBOpcoes.Controls.Add(filesListBox);
            GBOpcoes.FlatStyle = FlatStyle.Popup;
            GBOpcoes.Location = new Point(452, 63);
            GBOpcoes.Name = "GBOpcoes";
            GBOpcoes.Size = new Size(336, 304);
            GBOpcoes.TabIndex = 0;
            GBOpcoes.TabStop = false;
            GBOpcoes.Text = "Files List";
            // 
            // filesListBox
            // 
            filesListBox.FormattingEnabled = true;
            filesListBox.ItemHeight = 15;
            filesListBox.Location = new Point(6, 22);
            filesListBox.Name = "filesListBox";
            filesListBox.Size = new Size(324, 259);
            filesListBox.TabIndex = 1;
            filesListBox.SelectedValueChanged += PrintFile_filesListBox_SelectedValueChanged;
            // 
            // LogPanel
            // 
            LogPanel.BorderStyle = BorderStyle.FixedSingle;
            LogPanel.Controls.Add(fileTextBox);
            LogPanel.Location = new Point(12, 63);
            LogPanel.Name = "LogPanel";
            LogPanel.Size = new Size(434, 375);
            LogPanel.TabIndex = 1;
            // 
            // fileTextBox
            // 
            fileTextBox.BorderStyle = BorderStyle.FixedSingle;
            fileTextBox.Location = new Point(3, 3);
            fileTextBox.Multiline = true;
            fileTextBox.Name = "fileTextBox";
            fileTextBox.ScrollBars = ScrollBars.Vertical;
            fileTextBox.Size = new Size(426, 367);
            fileTextBox.TabIndex = 3;
            // 
            // Exit
            // 
            Exit.FlatStyle = FlatStyle.Popup;
            Exit.Location = new Point(685, 397);
            Exit.Name = "Exit";
            Exit.Size = new Size(103, 41);
            Exit.TabIndex = 2;
            Exit.Text = "Exit";
            Exit.UseVisualStyleBackColor = true;
            Exit.Click += Exit_Click;
            // 
            // label1
            // 
            label1.Location = new Point(16, 38);
            label1.Name = "label1";
            label1.Size = new Size(430, 24);
            label1.TabIndex = 3;
            label1.Text = "Log";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // saveFileButtton
            // 
            saveFileButtton.FlatStyle = FlatStyle.Popup;
            saveFileButtton.Location = new Point(458, 387);
            saveFileButtton.Name = "saveFileButtton";
            saveFileButtton.Size = new Size(78, 37);
            saveFileButtton.TabIndex = 5;
            saveFileButtton.Text = "Save";
            saveFileButtton.UseVisualStyleBackColor = true;
            saveFileButtton.Click += saveFileButtton_Click;
            // 
            // newFileButton
            // 
            newFileButton.FlatStyle = FlatStyle.Popup;
            newFileButton.Location = new Point(566, 387);
            newFileButton.Name = "newFileButton";
            newFileButton.Size = new Size(78, 37);
            newFileButton.TabIndex = 6;
            newFileButton.Text = "New File";
            newFileButton.UseVisualStyleBackColor = true;
            newFileButton.Click += newFileButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(newFileButton);
            Controls.Add(saveFileButtton);
            Controls.Add(label1);
            Controls.Add(Exit);
            Controls.Add(LogPanel);
            Controls.Add(GBOpcoes);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            ImeMode = ImeMode.Off;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Programa de teste";
            GBOpcoes.ResumeLayout(false);
            LogPanel.ResumeLayout(false);
            LogPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox GBOpcoes;
        private Panel LogPanel;
        private Button Exit;
        private Label label1;
        private ListBox filesListBox;
        private Button saveFileButtton;
        private Button newFileButton;
        private TextBox fileTextBox;
    }
}
