namespace ProgForms
{
    partial class NewFile
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
            Label label7;
            Label label14;
            Label label3;
            Label label15;
            label1 = new Label();
            fileNameTextBox = new TextBox();
            saveFileButtton = new Button();
            label2 = new Label();
            Exit = new Button();
            LogPanel = new Panel();
            rnsAddButton = new Button();
            coreDataAddButton = new Button();
            coreDataIdTextBox = new TextBox();
            label8 = new Label();
            coreDataNameTextBox = new TextBox();
            label13 = new Label();
            rnsIdTextBox = new TextBox();
            label11 = new Label();
            rnsNameTextBox = new TextBox();
            label12 = new Label();
            communityCheckBox = new CheckBox();
            label6 = new Label();
            objectTextBox = new TextBox();
            label5 = new Label();
            idTextBox = new TextBox();
            label4 = new Label();
            partnerTextBox = new TextBox();
            label9 = new Label();
            gameTextBox = new TextBox();
            label10 = new Label();
            rnsListTextBox = new TextBox();
            coreDataListTextBox = new TextBox();
            label7 = new Label();
            label14 = new Label();
            label3 = new Label();
            label15 = new Label();
            LogPanel.SuspendLayout();
            SuspendLayout();
            // 
            // label7
            // 
            label7.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ImageAlign = ContentAlignment.MiddleLeft;
            label7.Location = new Point(84, 173);
            label7.Name = "label7";
            label7.Size = new Size(185, 20);
            label7.TabIndex = 12;
            label7.Text = "RNS List";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            label14.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.ImageAlign = ContentAlignment.MiddleLeft;
            label14.Location = new Point(84, 252);
            label14.Name = "label14";
            label14.Size = new Size(185, 20);
            label14.TabIndex = 20;
            label14.Text = "Core Data Refs List";
            label14.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ImageAlign = ContentAlignment.MiddleLeft;
            label3.Location = new Point(454, 88);
            label3.Name = "label3";
            label3.Size = new Size(185, 20);
            label3.TabIndex = 25;
            label3.Text = "RNS List";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            label15.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label15.ImageAlign = ContentAlignment.MiddleLeft;
            label15.Location = new Point(454, 253);
            label15.Name = "label15";
            label15.Size = new Size(185, 20);
            label15.TabIndex = 25;
            label15.Text = "Core Data Refs List";
            label15.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(320, 9);
            label1.Name = "label1";
            label1.Size = new Size(153, 89);
            label1.TabIndex = 0;
            label1.Text = "Create New File";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fileNameTextBox
            // 
            fileNameTextBox.Location = new Point(12, 52);
            fileNameTextBox.Name = "fileNameTextBox";
            fileNameTextBox.Size = new Size(153, 23);
            fileNameTextBox.TabIndex = 1;
            fileNameTextBox.TextChanged += Changed;
            // 
            // saveFileButtton
            // 
            saveFileButtton.FlatStyle = FlatStyle.Popup;
            saveFileButtton.Location = new Point(528, 397);
            saveFileButtton.Name = "saveFileButtton";
            saveFileButtton.Size = new Size(103, 41);
            saveFileButtton.TabIndex = 6;
            saveFileButtton.Text = "Save File";
            saveFileButtton.UseVisualStyleBackColor = true;
            saveFileButtton.Click += saveFileButtton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 31);
            label2.Name = "label2";
            label2.Size = new Size(80, 18);
            label2.TabIndex = 7;
            label2.Text = "File Name";
            // 
            // Exit
            // 
            Exit.FlatStyle = FlatStyle.Popup;
            Exit.Location = new Point(685, 397);
            Exit.Name = "Exit";
            Exit.Size = new Size(103, 41);
            Exit.TabIndex = 9;
            Exit.Text = "Exit";
            Exit.UseVisualStyleBackColor = true;
            Exit.Click += Exit_Click;
            // 
            // LogPanel
            // 
            LogPanel.BorderStyle = BorderStyle.FixedSingle;
            LogPanel.Controls.Add(rnsAddButton);
            LogPanel.Controls.Add(coreDataAddButton);
            LogPanel.Controls.Add(coreDataIdTextBox);
            LogPanel.Controls.Add(label8);
            LogPanel.Controls.Add(coreDataNameTextBox);
            LogPanel.Controls.Add(label13);
            LogPanel.Controls.Add(label14);
            LogPanel.Controls.Add(rnsIdTextBox);
            LogPanel.Controls.Add(label11);
            LogPanel.Controls.Add(rnsNameTextBox);
            LogPanel.Controls.Add(label12);
            LogPanel.Controls.Add(communityCheckBox);
            LogPanel.Controls.Add(label7);
            LogPanel.Controls.Add(label6);
            LogPanel.Controls.Add(objectTextBox);
            LogPanel.Controls.Add(label5);
            LogPanel.Controls.Add(idTextBox);
            LogPanel.Controls.Add(label4);
            LogPanel.Controls.Add(partnerTextBox);
            LogPanel.Controls.Add(label9);
            LogPanel.Controls.Add(gameTextBox);
            LogPanel.Controls.Add(label10);
            LogPanel.Location = new Point(12, 81);
            LogPanel.Name = "LogPanel";
            LogPanel.Size = new Size(434, 366);
            LogPanel.TabIndex = 10;
            // 
            // rnsAddButton
            // 
            rnsAddButton.FlatStyle = FlatStyle.Popup;
            rnsAddButton.Location = new Point(285, 200);
            rnsAddButton.Name = "rnsAddButton";
            rnsAddButton.Size = new Size(103, 41);
            rnsAddButton.TabIndex = 12;
            rnsAddButton.Text = "Add";
            rnsAddButton.UseVisualStyleBackColor = true;
            rnsAddButton.Click += rnsAddButton_Click;
            // 
            // coreDataAddButton
            // 
            coreDataAddButton.FlatStyle = FlatStyle.Popup;
            coreDataAddButton.Location = new Point(285, 282);
            coreDataAddButton.Name = "coreDataAddButton";
            coreDataAddButton.Size = new Size(103, 41);
            coreDataAddButton.TabIndex = 13;
            coreDataAddButton.Text = "Add";
            coreDataAddButton.UseVisualStyleBackColor = true;
            coreDataAddButton.Click += coreDataAddButton_Click;
            // 
            // coreDataIdTextBox
            // 
            coreDataIdTextBox.Location = new Point(84, 275);
            coreDataIdTextBox.Name = "coreDataIdTextBox";
            coreDataIdTextBox.Size = new Size(185, 23);
            coreDataIdTextBox.TabIndex = 24;
            coreDataIdTextBox.TextChanged += Changed;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(0, 279);
            label8.Name = "label8";
            label8.Size = new Size(17, 15);
            label8.TabIndex = 23;
            label8.Text = "Id";
            // 
            // coreDataNameTextBox
            // 
            coreDataNameTextBox.Location = new Point(84, 305);
            coreDataNameTextBox.Name = "coreDataNameTextBox";
            coreDataNameTextBox.Size = new Size(185, 23);
            coreDataNameTextBox.TabIndex = 22;
            coreDataNameTextBox.TextChanged += Changed;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(0, 308);
            label13.Name = "label13";
            label13.Size = new Size(39, 15);
            label13.TabIndex = 21;
            label13.Text = "Name";
            // 
            // rnsIdTextBox
            // 
            rnsIdTextBox.Location = new Point(84, 196);
            rnsIdTextBox.Name = "rnsIdTextBox";
            rnsIdTextBox.Size = new Size(185, 23);
            rnsIdTextBox.TabIndex = 19;
            rnsIdTextBox.TextChanged += Changed;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(0, 200);
            label11.Name = "label11";
            label11.Size = new Size(17, 15);
            label11.TabIndex = 18;
            label11.Text = "Id";
            // 
            // rnsNameTextBox
            // 
            rnsNameTextBox.Location = new Point(84, 226);
            rnsNameTextBox.Name = "rnsNameTextBox";
            rnsNameTextBox.Size = new Size(185, 23);
            rnsNameTextBox.TabIndex = 17;
            rnsNameTextBox.TextChanged += Changed;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(0, 229);
            label12.Name = "label12";
            label12.Size = new Size(39, 15);
            label12.TabIndex = 16;
            label12.Text = "Name";
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
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(3, 95);
            label9.Name = "label9";
            label9.Size = new Size(45, 15);
            label9.TabIndex = 2;
            label9.Text = "Partner";
            // 
            // gameTextBox
            // 
            gameTextBox.Location = new Point(87, 63);
            gameTextBox.Name = "gameTextBox";
            gameTextBox.Size = new Size(185, 23);
            gameTextBox.TabIndex = 1;
            gameTextBox.TextChanged += Changed;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(3, 66);
            label10.Name = "label10";
            label10.Size = new Size(38, 15);
            label10.TabIndex = 0;
            label10.Text = "Game";
            // 
            // rnsListTextBox
            // 
            rnsListTextBox.Location = new Point(454, 111);
            rnsListTextBox.Multiline = true;
            rnsListTextBox.Name = "rnsListTextBox";
            rnsListTextBox.ScrollBars = ScrollBars.Vertical;
            rnsListTextBox.Size = new Size(185, 115);
            rnsListTextBox.TabIndex = 11;
            rnsListTextBox.TextChanged += Changed;
            // 
            // coreDataListTextBox
            // 
            coreDataListTextBox.Location = new Point(454, 276);
            coreDataListTextBox.Multiline = true;
            coreDataListTextBox.Name = "coreDataListTextBox";
            coreDataListTextBox.ScrollBars = ScrollBars.Vertical;
            coreDataListTextBox.Size = new Size(185, 115);
            coreDataListTextBox.TabIndex = 12;
            coreDataListTextBox.TextChanged += Changed;
            // 
            // NewFile
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            ClientSize = new Size(800, 450);
            Controls.Add(label15);
            Controls.Add(label3);
            Controls.Add(coreDataListTextBox);
            Controls.Add(rnsListTextBox);
            Controls.Add(LogPanel);
            Controls.Add(Exit);
            Controls.Add(label2);
            Controls.Add(saveFileButtton);
            Controls.Add(fileNameTextBox);
            Controls.Add(label1);
            Name = "NewFile";
            Text = "NewFile";
            LogPanel.ResumeLayout(false);
            LogPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox fileNameTextBox;
        private Button saveFileButtton;
        private Label label2;
        private Button Exit;
        private Panel LogPanel;
        private CheckBox communityCheckBox;
        private Label label7;
        private Label label6;
        private TextBox objectTextBox;
        private Label label5;
        private TextBox idTextBox;
        private Label label4;
        private TextBox partnerTextBox;
        private Label label9;
        private TextBox gameTextBox;
        private Label label10;
        private TextBox rnsIdTextBox;
        private Label label11;
        private TextBox rnsNameTextBox;
        private Label label12;
        private TextBox coreDataIdTextBox;
        private Label label8;
        private TextBox coreDataNameTextBox;
        private Label label13;
        private Button rnsAddButton;
        private Button coreDataAddButton;
        private TextBox rnsListTextBox;
        private TextBox coreDataListTextBox;
    }
}