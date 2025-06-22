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
using Newtonsoft.Json;
using ProgForms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProgForms
{
    public partial class EditFile : Form
    {
        // Tracks if there is unsaved changes
        bool change = false;

        string nl = Environment.NewLine;

        string selectedFile = "";

        public List<RNS> listRns;
        public List<CoreDataRefs> listCoreData;
        public EditFile()
        {
            InitializeComponent();

            listRns = new List<RNS>(); // Initialize the list for RNS objects
            listCoreData = new List<CoreDataRefs>(); // Initialize the list for CoreDataRefs objects

            GetFiles();
        }


        public string[] GetFiles()
        {
            // .json files from the directory
            string[] files = Directory.GetFiles(@"C:\Users\Utilizador\Desktop\json", "*.json");
            // Put the files in the text box
            foreach (string file in files)
            {
                filesListBox.Items.Add(file);
            }
            return files;
        }

        public void SetInfo(List<Simulator> list)
        {

            idTextBox.Clear();
            gameTextBox.Clear();
            partnerTextBox.Clear();
            objectTextBox.Clear();
            rnsTextBox.Clear();
            coreDataTextBox.Clear();

            foreach (Simulator s in list)
            {
                idTextBox.Text += s._id;
                gameTextBox.Text += s.game;
                partnerTextBox.Text += s.partner;
                objectTextBox.Text += s.object_name;
                if (s.community == false)
                {
                    communityCheckBox.Checked = false;
                }
                if (s.community == true)
                {
                    communityCheckBox.Checked = true;
                }
                // Every RNS in the Simulator "rns" list 
                foreach (RNS r in s.rns)
                {
                    rnsTextBox.Text += r.ID + nl;
                    rnsTextBox.Text += r.NAME + nl;
                }
                // Every CoreDataRefs in the Simulator "core_datarefs" list 
                foreach (CoreDataRefs c in s.core_datarefs)
                {
                    coreDataTextBox.Text += c.ID + nl;
                    coreDataTextBox.Text += c.NAME + nl;
                }

            }
        }

        // Prints the raw text of the selected file in the list box
        private void filesListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            var item = filesListBox.SelectedItem;
            selectedFile = item.ToString();

            // Getting the file text into a string
            string text = File.ReadAllText(selectedFile);
            try
            {
                // Deserializes the string and turns it to a Simualtor list
                List<Simulator> list = JsonConvert.DeserializeObject<List<Simulator>>(text);
                // Puts the deserialized list information on the text boxes
                SetInfo(list);
            }
            // Cacthes an error if the file is not deserializeble
            catch (JsonReaderException)
            {
                MessageBox.Show("File not in the right format", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (JsonSerializationException)
            {
                MessageBox.Show("File not in the right format", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Exits after verifying the unsaved changes
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
                    saveButton_Click(sender, e);
                    this.Close();
                }
            // Exits without saving
            if (result == DialogResult.No)
                {
                    this.Close();
                }
            }
            
        }

        // Writes the changed file
        private void saveButton_Click(object sender, EventArgs e)
        {
            // Get the selected file
            string fileName = selectedFile;

            Simulator s = new Simulator();
            // Checks the information on the text box, creates the CoreDataRefs and adds them to the list 
            for (int i = 0; i * 2 + 1 < coreDataTextBox.Lines.Length; i++)
            {
                CoreDataRefs c = new CoreDataRefs();
                c.ID = coreDataTextBox.Lines[i * 2];
                c.NAME = coreDataTextBox.Lines[i * 2 + 1];
                listCoreData.Add(c);
            }
            // Checks the information on the text box, creates the RNS's and adds them to the list
            for (int i = 0; i * 2 + 1 < rnsTextBox.Lines.Length; i++)
            {
                RNS r = new RNS();
                r.ID = rnsTextBox.Lines[i * 2];
                r.NAME = rnsTextBox.Lines[i * 2 + 1];
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
            File.WriteAllText(fileName, "["+text+"]"); // Needs the [] to read the file

            change = false; // No unsaved changes now

            MessageBox.Show("File saved", "Sucess",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Checks if there were changes
        private void Changed(object sender, EventArgs e)
        {
            change = true;
        }
    }
}
