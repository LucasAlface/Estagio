﻿namespace ProgForms
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
            communityBox = new CheckBox();
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
            Exit = new Button();
            label1 = new Label();
            editFileButtton = new Button();
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
            filesListBox.SelectedIndexChanged += filesListBox_SelectedIndexChanged;
            // 
            // LogPanel
            // 
            LogPanel.BorderStyle = BorderStyle.FixedSingle;
            LogPanel.Controls.Add(communityBox);
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
            LogPanel.Location = new Point(12, 63);
            LogPanel.Name = "LogPanel";
            LogPanel.Size = new Size(434, 375);
            LogPanel.TabIndex = 1;
            // 
            // communityBox
            // 
            communityBox.AutoSize = true;
            communityBox.Enabled = false;
            communityBox.Location = new Point(87, 154);
            communityBox.Name = "communityBox";
            communityBox.Size = new Size(15, 14);
            communityBox.TabIndex = 15;
            communityBox.UseVisualStyleBackColor = true;
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
            coreDataTextBox.ReadOnly = true;
            coreDataTextBox.ScrollBars = ScrollBars.Vertical;
            coreDataTextBox.Size = new Size(185, 69);
            coreDataTextBox.TabIndex = 11;
            // 
            // rnsTextBox
            // 
            rnsTextBox.Location = new Point(87, 179);
            rnsTextBox.Multiline = true;
            rnsTextBox.Name = "rnsTextBox";
            rnsTextBox.ReadOnly = true;
            rnsTextBox.ScrollBars = ScrollBars.Vertical;
            rnsTextBox.Size = new Size(185, 69);
            rnsTextBox.TabIndex = 10;
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
            objectTextBox.ReadOnly = true;
            objectTextBox.Size = new Size(185, 23);
            objectTextBox.TabIndex = 7;
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
            idTextBox.ReadOnly = true;
            idTextBox.Size = new Size(185, 23);
            idTextBox.TabIndex = 5;
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
            partnerTextBox.ReadOnly = true;
            partnerTextBox.Size = new Size(185, 23);
            partnerTextBox.TabIndex = 3;
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
            gameTextBox.ReadOnly = true;
            gameTextBox.Size = new Size(185, 23);
            gameTextBox.TabIndex = 1;
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
            // editFileButtton
            // 
            editFileButtton.FlatStyle = FlatStyle.Popup;
            editFileButtton.Location = new Point(458, 387);
            editFileButtton.Name = "editFileButtton";
            editFileButtton.Size = new Size(78, 37);
            editFileButtton.TabIndex = 5;
            editFileButtton.Text = "Edit";
            editFileButtton.UseVisualStyleBackColor = true;
            editFileButtton.Click += editFileButtton_Click;
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
            Controls.Add(editFileButtton);
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
        private Button editFileButtton;
        private Button newFileButton;
        private TextBox gameTextBox;
        private Label label2;
        private Label label6;
        private TextBox objectTextBox;
        private Label label5;
        private TextBox idTextBox;
        private Label label4;
        private TextBox partnerTextBox;
        private Label label3;
        private TextBox rnsTextBox;
        private TextBox coreDataTextBox;
        private Label label8;
        private Label label7;
        private CheckBox communityBox;
    }
}
