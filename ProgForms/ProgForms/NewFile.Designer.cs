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
            label1 = new Label();
            fileNameTextBox = new TextBox();
            fileTextTextBox = new TextBox();
            saveFileButtton = new Button();
            label2 = new Label();
            label3 = new Label();
            Exit = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(320, 23);
            label1.Name = "label1";
            label1.Size = new Size(153, 89);
            label1.TabIndex = 0;
            label1.Text = "Create New File";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fileNameTextBox
            // 
            fileNameTextBox.Location = new Point(12, 125);
            fileNameTextBox.Name = "fileNameTextBox";
            fileNameTextBox.Size = new Size(153, 23);
            fileNameTextBox.TabIndex = 1;
            // 
            // fileTextTextBox
            // 
            fileTextTextBox.BorderStyle = BorderStyle.FixedSingle;
            fileTextTextBox.Location = new Point(12, 195);
            fileTextTextBox.Multiline = true;
            fileTextTextBox.Name = "fileTextTextBox";
            fileTextTextBox.ScrollBars = ScrollBars.Vertical;
            fileTextTextBox.Size = new Size(445, 243);
            fileTextTextBox.TabIndex = 4;
            // 
            // saveFileButtton
            // 
            saveFileButtton.FlatStyle = FlatStyle.Popup;
            saveFileButtton.Location = new Point(463, 195);
            saveFileButtton.Name = "saveFileButtton";
            saveFileButtton.Size = new Size(103, 41);
            saveFileButtton.TabIndex = 6;
            saveFileButtton.Text = "Save";
            saveFileButtton.UseVisualStyleBackColor = true;
            saveFileButtton.Click += saveFileButtton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 104);
            label2.Name = "label2";
            label2.Size = new Size(80, 18);
            label2.TabIndex = 7;
            label2.Text = "File Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 174);
            label3.Name = "label3";
            label3.Size = new Size(65, 18);
            label3.TabIndex = 8;
            label3.Text = "File Text";
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
            // NewFile
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            ClientSize = new Size(800, 450);
            Controls.Add(Exit);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(saveFileButtton);
            Controls.Add(fileTextTextBox);
            Controls.Add(fileNameTextBox);
            Controls.Add(label1);
            Name = "NewFile";
            Text = "NewFile";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox fileNameTextBox;
        private TextBox fileTextTextBox;
        private Button saveFileButtton;
        private Label label2;
        private Label label3;
        private Button Exit;
    }
}