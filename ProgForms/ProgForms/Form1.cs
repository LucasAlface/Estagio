using System.DirectoryServices;
using static System.Net.Mime.MediaTypeNames;
using System.Web;
using System.Text.Json;
using System.Xml;
using Newtonsoft.Json;
using System.Net;
using System.Text.RegularExpressions;
using LeituraFicheiro;
using System.Diagnostics;

namespace ProgForms
{
    public partial class Form1 : Form
    {



        public Form newFile = new NewFile();
        public Form1()
        {
            InitializeComponent();

            //GetFiles();

            fileTextBox.Text = GetWebpageContent();

        }

        public static string GetWebpageContent()
        {
            //// Create a request to the provided URL
            //string loc = "https://github.com/norairlabs/test-toga/blob/main/xplane12/felix/742.json";


            using WebClient client = new WebClient();

            string info = "";

            //// Add a user agent header in case the
            //// requested URI contains a query.

            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

            using Stream data = client.OpenRead("https://raw.githubusercontent.com/norairlabs/test-toga/main/xplane12/felix/742.json");
            using StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();
            List<Simulator> g = JsonConvert.DeserializeObject<List<Simulator>>(s);
            foreach (Simulator ss in g)
            {
                info += ss._id + "\n";
                info += ss.game + "\n";
                info += ss.partner + "\n";
                info += ss.object_name + "\n";
                info += ss.community + "\n";
                info += ss.rns + "\n";
                info += ss.core_datarefs + "\n";
            }
            //File.WriteAllText(file, text);
            //string e = File.ReadAllText(file);

            return info;



            ////Creates an IpEndPoint.
            //IPAddress ipAddress = Dns.Resolve("github.com").AddressList[0];
            //IPEndPoint ipLocalEndPoint = new IPEndPoint(ipAddress, 11000);

            ////Serializes the IPEndPoint.
            //SocketAddress socketAddress = ipLocalEndPoint.Serialize();

            ////Verifies that ipLocalEndPoint is now serialized by printing its contents.
            //Console.WriteLine("Contents of the socketAddress are: " + socketAddress.ToString());
            ////Checks the Family property.
            //Console.WriteLine("The address family of the socketAddress is: " + socketAddress.Family.ToString());
            ////Checks the underlying buffer size.
            //Console.WriteLine("The size of the underlying buffer is: " + socketAddress.Size.ToString());

            //return socketAddress.ToString();
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public string[] GetFiles()
        {

            string[] test = Directory.GetFiles(@"C:\Users\Utilizador\Desktop\json", "*.json");
            foreach (string file in test)
            {
                filesListBox.Items.Add(file);
            }
            return test;


        }

        private void PrintFile_filesListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            var item = filesListBox.SelectedItem;
            string file = item.ToString();
            string fileText = File.ReadAllText(file);
            fileTextBox.Text = fileText;
        }

        private void saveFileButtton_Click(object sender, EventArgs e)
        {
            var item = filesListBox.SelectedItem;
            string file = item.ToString();
            File.WriteAllText(file, fileTextBox.Text);
        }

        private void newFileButton_Click(object sender, EventArgs e)
        {
            newFile.Show();
        }
    }
}
