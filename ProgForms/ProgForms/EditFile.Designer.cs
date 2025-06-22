namespace ProgForms
{
    partial class EditFile
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
            filesListBox = new ListBox();
            Exit = new Button();
            saveButton = new Button();
            LogPanel = new Panel();
            communityCheckBox = new CheckBox();
            label8 = new Label();
            label7 = new Label();
            coreDataTextBox = new TextBox();
            rnsTextBox = new TextBox();
            label6 = new Label();
            objectTextBox = new TextBox();
            label5 = new Label();
            idTextBox = new TextBox();
            label4 = new Label();
            partnerTextBox = new TextBox();
            label3 = new Label();
            gameTextBox = new TextBox();
            label2 = new Label();
            LogPanel.SuspendLayout();
            SuspendLayout();
            // 
            // filesListBox
            // 
            filesListBox.FormattingEnabled = true;
            filesListBox.ItemHeight = 15;
            filesListBox.Location = new Point(453, 47);
            filesListBox.Name = "filesListBox";
            filesListBox.Size = new Size(324, 334);
            filesListBox.TabIndex = 2;
            filesListBox.SelectedValueChanged += filesListBox_SelectedValueChanged;
            // 
            // Exit
            // 
            Exit.FlatStyle = FlatStyle.Popup;
            Exit.Location = new Point(685, 397);
            Exit.Name = "Exit";
            Exit.Size = new Size(103, 41);
            Exit.TabIndex = 4;
            Exit.Text = "Exit";
            Exit.UseVisualStyleBackColor = true;
            Exit.Click += Exit_Click;
            // 
            // saveButton
            // 
            saveButton.FlatStyle = FlatStyle.Popup;
            saveButton.Location = new Point(534, 397);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(103, 41);
            saveButton.TabIndex = 5;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // LogPanel
            // 
            LogPanel.BorderStyle = BorderStyle.FixedSingle;
            LogPanel.Controls.Add(communityCheckBox);
            LogPanel.Controls.Add(label8);
            LogPanel.Controls.Add(label7);
            LogPanel.Controls.Add(coreDataTextBox);
            LogPanel.Controls.Add(rnsTextBox);
            LogPanel.Controls.Add(label6);
            LogPanel.Controls.Add(objectTextBox);
            LogPanel.Controls.Add(label5);
            LogPanel.Controls.Add(idTextBox);
            LogPanel.Controls.Add(label4);
            LogPanel.Controls.Add(partnerTextBox);
            LogPanel.Controls.Add(label3);
            LogPanel.Controls.Add(gameTextBox);
            LogPanel.Controls.Add(label2);
            LogPanel.Location = new Point(12, 42);
            LogPanel.Name = "LogPanel";
            LogPanel.Size = new Size(434, 338);
            LogPanel.TabIndex = 6;
            // 
            // communityCheckBox
            // 
            communityCheckBox.AutoSize = true;
            communityCheckBox.Location = new Point(87, 154);
            communityCheckBox.Name = "communityCheckBox";
            communityCheckBox.Size = new Size(15, 14);
            communityCheckBox.TabIndex = 15;
            communityCheckBox.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(3, 277);
            label8.Name = "label8";
            label8.Size = new Size(84, 15);
            label8.TabIndex = 13;
            label8.Text = "Core Data Refs";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(3, 203);
            label7.Name = "label7";
            label7.Size = new Size(29, 15);
            label7.TabIndex = 12;
            label7.Text = "RNS";
            // 
            // coreDataTextBox
            // 
            coreDataTextBox.Location = new Point(87, 254);
            coreDataTextBox.Multiline = true;
            coreDataTextBox.Name = "coreDataTextBox";
            coreDataTextBox.ScrollBars = ScrollBars.Vertical;
            coreDataTextBox.Size = new Size(185, 69);
            coreDataTextBox.TabIndex = 11;
            coreDataTextBox.TextChanged += Changed;
            // 
            // rnsTextBox
            // 
            rnsTextBox.Location = new Point(87, 179);
            rnsTextBox.Multiline = true;
            rnsTextBox.Name = "rnsTextBox";
            rnsTextBox.ScrollBars = ScrollBars.Vertical;
            rnsTextBox.Size = new Size(185, 69);
            rnsTextBox.TabIndex = 10;
            rnsTextBox.TextChanged += Changed;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(3, 153);
            label6.Name = "label6";
            label6.Size = new Size(71, 15);
            label6.TabIndex = 8;
            label6.Text = "Community";
            // 
            // objectTextBox
            // 
            objectTextBox.Location = new Point(87, 121);
            objectTextBox.Name = "objectTextBox";
            objectTextBox.Size = new Size(185, 23);
            objectTextBox.TabIndex = 7;
            objectTextBox.TextChanged += Changed;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 124);
            label5.Name = "label5";
            label5.Size = new Size(77, 15);
            label5.TabIndex = 6;
            label5.Text = "Object Name";
            // 
            // idTextBox
            // 
            idTextBox.Location = new Point(87, 33);
            idTextBox.Name = "idTextBox";
            idTextBox.Size = new Size(185, 23);
            idTextBox.TabIndex = 5;
            idTextBox.TextChanged += Changed;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 37);
            label4.Name = "label4";
            label4.Size = new Size(17, 15);
            label4.TabIndex = 4;
            label4.Text = "Id";
            // 
            // partnerTextBox
            // 
            partnerTextBox.Location = new Point(87, 92);
            partnerTextBox.Name = "partnerTextBox";
            partnerTextBox.Size = new Size(185, 23);
            partnerTextBox.TabIndex = 3;
            partnerTextBox.TextChanged += Changed;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 95);
            label3.Name = "label3";
            label3.Size = new Size(45, 15);
            label3.TabIndex = 2;
            label3.Text = "Partner";
            // 
            // gameTextBox
            // 
            gameTextBox.Location = new Point(87, 63);
            gameTextBox.Name = "gameTextBox";
            gameTextBox.Size = new Size(185, 23);
            gameTextBox.TabIndex = 1;
            gameTextBox.TextChanged += Changed;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 66);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 0;
            label2.Text = "Game";
            // 
            // EditFile
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            ClientSize = new Size(800, 450);
            Controls.Add(LogPanel);
            Controls.Add(saveButton);
            Controls.Add(Exit);
            Controls.Add(filesListBox);
            Name = "EditFile";
            Text = "EditFile";
            LogPanel.ResumeLayout(false);
            LogPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ListBox filesListBox;
        private Button Exit;
        private Button saveButton;
        private Panel LogPanel;
        private CheckBox communityCheckBox;
        private Label label8;
        private Label label7;
        private TextBox coreDataTextBox;
        private TextBox rnsTextBox;
        private Label label6;
        private TextBox objectTextBox;
        private Label label5;
        private TextBox idTextBox;
        private Label label4;
        private TextBox partnerTextBox;
        private Label label3;
        private TextBox gameTextBox;
        private Label label2;
    }
}