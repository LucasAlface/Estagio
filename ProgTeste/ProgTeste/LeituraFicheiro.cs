using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeituraFicheiro
{

    public class Simulator
    {
        public string? ID { get; set; }
        public string? GAME { get; set; }
        public string? PARTNER { get; set; }
        public string? OBJECTNAME { get; set; }
        public Boolean COMMUNITY { get; set; }
        public List<RNS> RNSLIST { get; set; }
        public List<CoreDataRefs> COREDATAREFSLIST { get; set; }

        public Simulator()
        {

        }

        public Simulator(string id, string game, string partner, string object_name,
                         Boolean community, List<RNS> rns, List<CoreDataRefs> coreDatarefs)
        {
            ID = id;
            GAME = game;
            PARTNER = partner;
            OBJECTNAME = object_name;
            COMMUNITY = community;
            RNSLIST = rns;
            COREDATAREFSLIST = coreDatarefs;

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
