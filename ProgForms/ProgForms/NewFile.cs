
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LeituraFicheiro;
using Newtonsoft;
using Newtonsoft.Json;

namespace ProgForms
{
    public partial class NewFile : Form
    {
        public List<RNS> listRns;
        public List<CoreDataRefs> listCoreData;

        string nl = Environment.NewLine;

        bool change = false;
        public NewFile()
        {
            InitializeComponent(); 
            listRns = new List<RNS>(); // Initialize the list for RNS objects
            listCoreData = new List<CoreDataRefs>(); // Initialize the list for CoreDataRefs objects
        }

        // Saves the new file with the information given
        private void saveFileButtton_Click(object sender, EventArgs e)
        {
            // Creating the new file with the given name
            string fileName = "C:\\Users\\Utilizador\\Desktop\\json\\" + fileNameTextBox.Text + ".json";

            Simulator s = new Simulator();

            // Checks the information on the text box, creates the CoreDataRefs and adds them to the list 
            for (int i = 0; i*2+1 < coreDataListTextBox.Lines.Length; i++)
            {
                CoreDataRefs c = new CoreDataRefs();
                c.ID = coreDataListTextBox.Lines[i * 2];
                c.NAME = coreDataListTextBox.Lines[i * 2 + 1];
                listCoreData.Add(c);
            }
            // Checks the information on the text box, creates the RNS's and adds them to the list 
            for (int i = 0; i*2+1 < rnsListTextBox.Lines.Length; i++)
            {
                RNS r = new RNS();
                r.ID = rnsListTextBox.Lines[i * 2];
                r.NAME = rnsListTextBox.Lines[i * 2 + 1];
                listRns.Add(r);
            }

            // Creating the simulator with the information given
            s._id = idTextBox.Text;
            s.game = gameTextBox.Text;
            s.partner = partnerTextBox.Text;
            s.object_name = objectTextBox.Text;
            s.community = communityCheckBox.Checked;
            s.rns = listRns;
            s.core_datarefs = listCoreData;
            // Serializing the Simulator
            string text = JsonConvert.SerializeObject(s, Formatting.Indented);
            // Writing in the created file
            File.WriteAllText(fileName, "[" + text + "]"); // Needs the [] to read the file

            MessageBox.Show("File saved", "Sucess",
            MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Clear ALL information
            fileNameTextBox.Clear();
            idTextBox.Clear();
            gameTextBox.Clear();
            partnerTextBox.Clear();
            objectTextBox.Clear();
            communityCheckBox.Checked = false;
            rnsListTextBox.Clear();
            coreDataListTextBox.Clear();
            listRns.Clear();
            listCoreData.Clear();

            change = false; // No unsaved changes now

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            // No unsaved changes
            if (change == false)
            {
                this.Close();
            }
            // Unsaved Changes
            if (change == true)
            {
                var result = MessageBox.Show("Want to save the changes?", "Unsaved changes",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error);
                // Saves the changes and exits
                if (result == DialogResult.Yes)
                {
                    saveFileButtton_Click(sender, e);
                    this.Close();
                }
                // Exits without saving
                if (result == DialogResult.No)
                {
                    this.Close();
                }
            }

        }

        private void rnsAddButton_Click(object sender, EventArgs e)
        {
            // Insert new RNS into the list
            rnsListTextBox.Text += rnsIdTextBox.Text + nl;
            rnsListTextBox.Text += rnsNameTextBox.Text + nl;
            //Clear after use
            rnsIdTextBox.Clear();
            rnsNameTextBox.Clear();

        }

        private void coreDataAddButton_Click(object sender, EventArgs e)
        {
            // Insert new CoreDataRefs into the list
            coreDataListTextBox.Text += coreDataIdTextBox.Text + nl;
            coreDataListTextBox.Text += coreDataNameTextBox.Text + nl;
            //Clear after use
            coreDataIdTextBox.Clear();
            coreDataNameTextBox.Clear();
        }

        private void Changed(object sender, EventArgs e)
        {
            change = true;
        }
    }
}
