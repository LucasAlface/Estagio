using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeituraFicheiro
{

    public class Simulator
    {
        public string? _id { get; set; }
        public string? game { get; set; }
        public string? partner { get; set; }
        public string? object_name { get; set; }
        public Boolean community { get; set; }
        public List<RNS>? rns { get; set; }
        public List<CoreDataRefs>? core_datarefs { get; set; }

        public Simulator()
        {

        }

        public Simulator(string Id, string Game, string Partner, string ObjectName,
                         Boolean Community, List<RNS> Rns, List<CoreDataRefs> CoreDatarefs)
        {
            _id = Id;
            game = Game;
            partner = Partner;
            object_name = ObjectName;
            community = Community;
            rns = Rns;
            core_datarefs = CoreDatarefs;

        }

        public void WriteFile(string fileName, string fileText)
        {
            /// <summary>
            /// Writes text on a file
            /// "fileName" - Location of the file to put text on
            /// "fileText" - Text to put on the file
            /// </summary>
            File.WriteAllText(fileName, fileText);
        }

        public void ReadFile(string fileName)
        {
            /// <summary>
            /// Reads a given file and writes it on the console
            /// "fileName" - Location of the file to be read
            /// </summary>
            string read = File.ReadAllText(fileName);
            Console.WriteLine(read);
        }


    }

    public class RNS
    {
        public string? ID { get; set; }
        public string? NAME { get; set; }

        public RNS()
        {

        }

        public RNS(string? id, string? name)
        {
            ID = id;
            NAME = name;
        }
    }

    public class CoreDataRefs
    {
        public string? ID { get; set; }
        public string? NAME { get; set; }

        public CoreDataRefs()
        {

        }

        public CoreDataRefs(string? id, string? name)
        {
            ID = id;
            NAME = name;
        }
    }

}
