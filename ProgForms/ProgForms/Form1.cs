using System.DirectoryServices;
using static System.Net.Mime.MediaTypeNames;
using System.Web;
using System.Text.Json;
using Newtonsoft.Json;
using System.Net;
using System.Text.RegularExpressions;
using LeituraFicheiro;
using System.Diagnostics;

namespace ProgForms
{
    public partial class Form1 : Form
    {
        // String with the web file
        string webFile = "https://raw.githubusercontent.com/norairlabs/test-toga/main/xplane12/felix/742.json";
 
        string nl = Environment.NewLine;

        // Forms
        public Form newFile = new NewFile();
        public Form editFile = new EditFile();
        public Form1()
        {
            InitializeComponent();

            GetFiles();

        }

        // Puts the information in the respective objects
        public void SetInfo(List<Simulator> list)
        {
            // Clear all the information
            idTextBox.Clear();
            gameTextBox.Clear();
            partnerTextBox.Clear();
            objectTextBox.Clear();
            rnsTextBox.Clear();
            coreDataTextBox.Clear();

            foreach (Simulator s in list)
            {
                // Putting the information in the objects
                idTextBox.Text += s._id;
                gameTextBox.Text += s.game;
                partnerTextBox.Text += s.partner;
                objectTextBox.Text += s.object_name;
                communityBox.Checked = s.community;
                // Every RNS in the Simulator "rns" list 
                foreach (RNS r in s.rns)
                {
                    rnsTextBox.Text += nl;
                    rnsTextBox.Text += "Id: " + r.ID + nl;
                    rnsTextBox.Text += "Name: " + r.NAME + nl;
                }
                // Every CoreDataRefs in the Simulator "core_datarefs" list 
                foreach (CoreDataRefs c in s.core_datarefs)
                {
                    coreDataTextBox.Text += nl;
                    coreDataTextBox.Text += "Id: " + c.ID + nl;
                    coreDataTextBox.Text += "Name: " + c.NAME + nl;
                }

            }
        }



        // Reads the raw web page file and returns a Simulator list based on that file
        public void GetWebpageContent()
        {
            using WebClient client = new WebClient();
            // Add a user agent header in case the
            // requested URI contains a query.
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

            // Reads the web file
            using Stream data = client.OpenRead(webFile);
            using StreamReader reader = new StreamReader(data);
            // Turns the read file into a string
            string s = reader.ReadToEnd();
            
            try
            {
                // Deserializes the string and turns it to a Simualtor list
                List<Simulator> list = JsonConvert.DeserializeObject<List<Simulator>>(s);
                // Puts the deserialized list information on the text boxes
                SetInfo(list);
            }
            // Cacthes an error if the file is not deserializeble
            catch (JsonReaderException)
            {
                MessageBox.Show("File not in the right format", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // Gets the json files of a directory and puts them on a list box
        public string[] GetFiles()
        {
            filesListBox.Items.Add(webFile);
            // .json files from the directory
            string[] files = Directory.GetFiles(@"C:\Users\Utilizador\Desktop\json", "*.json");
            // Put the files in the text box
            foreach (string file in files)
            {
                filesListBox.Items.Add(file);
            }
            return files;
        }

        // Uses the SetInfo() for the selected file
        private void filesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = filesListBox.SelectedItem;
            string file = item.ToString();
            if (file == webFile)
            {
                GetWebpageContent(); // This method aleready has SetInfo() and the try&catch
            }
            else
            {
                // Getting the file text into a string
                string text = File.ReadAllText(file);
                try
                {
                    // Deserializes the string and turns it to a Simualtor list
                    List<Simulator> list = JsonConvert.DeserializeObject<List<Simulator>>(text);
                    // Puts the deserialized list information on the text boxes
                    SetInfo(list);
                }
                // Cacthes an error if the file is not deserializeble
                catch (JsonReaderException  )
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
        }

        private void editFileButtton_Click(object sender, EventArgs e)
        {
            editFile.Show();
        }

        private void newFileButton_Click(object sender, EventArgs e)
        {
            newFile.Show();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
