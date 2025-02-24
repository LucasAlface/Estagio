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
        public NewFile()
        {
            InitializeComponent();
            listRns = new List<RNS>(); // Initialize the list for RNS objects
            listCoreData = new List<CoreDataRefs>(); // Initialize the list for CoreDataRefs objects
        }

        private void saveFileButtton_Click(object sender, EventArgs e)
        {
            string fileName = "C:\\Users\\Alfac\\Desktop\\" + fileNameTextBox.Text + ".json";
            Simulator s = new Simulator();
            s._id = idTextBox.Text;
            s.game = gameTextBox.Text;
            s.partner = partnerTextBox.Text;
            s.object_name = objectTextBox.Text;
            s.community = communityCheckBox.Checked;
            s.rns = listRns;
            s.core_datarefs = listCoreData;

            string text = JsonConvert.SerializeObject(s, Formatting.Indented);

            File.WriteAllText(fileName, text);
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void rnsAddButton_Click(object sender, EventArgs e)
        {
            RNS r = new RNS();
            r.ID = rnsIdTextBox.Text;
            r.NAME = rnsNameTextBox.Text;
            listRns.Add(r);

        }

        private void coreDataAddButton_Click(object sender, EventArgs e)
        {
            CoreDataRefs c = new CoreDataRefs();
            c.ID = coreDataIdTextBox.Text;
            c.NAME = coreDataNameTextBox.Text;
            listCoreData.Add(c);
        }
    }
}
