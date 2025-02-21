using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgForms
{
    public partial class NewFile : Form
    {
        public NewFile()
        {
            InitializeComponent();
        }

        private void saveFileButtton_Click(object sender, EventArgs e)
        {
            string fileName = "";
            fileName += "C:\\Users\\Utilizador\\Desktop\\";
            fileName += fileNameTextBox.Text;
            fileName += ".json";
            string fileText = fileTextTextBox.Text;
            label1.Text = fileName + fileText;
            File.WriteAllText(fileName, fileText);
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
    }
}
