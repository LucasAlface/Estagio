using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections;
using LeituraFicheiro;


public class Program
{
    // Definitions
    public static List<Simulator> listSimulator = new List<Simulator>();
    public static List<RNS> listRns = new List<RNS>();
    public static List<CoreDataRefs> listCoreDataRefs = new List<CoreDataRefs>();
    public static string file = @"C:\Users\Utilizador\Desktop\ficheiro6.json";

    public static void Main()
    {
        /// <summary>
        /// Writes on a file and reads it
        /// </summary>
        WriteFile();
        ReadFile();
    }


    public static void WriteFile()
    {
        /// <summary>
        /// Calls the "Serialize()" and calls the "WriteFile()" of the Simulator class
        /// </summary>
        Simulator sim = new Simulator();
        string json = Serialize();

        sim.WriteFile(file, json);
    }

    public static void ReadFile()
    {
        /// <summary>
        /// Calls the "ReadFile" from the Simulator class
        /// </summary>
        Simulator sim = new Simulator();

        sim.ReadFile(file);
    }

    public static string Serialize()
    {
        /// <summary>
        /// Calls the "PopulateLists()" and serializes the created list
        /// </summary>
        PopulateLists();
        return JsonConvert.SerializeObject(listSimulator, Formatting.Indented);
    }

    public static void PopulateLists()
    {
        /// <summary>
        /// Populates the RNS, CoreDataRefs and Simulator's lists by calling their respective adding object method
        /// </summary>
        AddRNS("adf", "XPLANE DATAREF");
        AddRNS("xpdr", "XPLANE DATAREF");
        AddRNS("com1_active", "XPLANE DATAREF");
        AddRNS("com1_stdby", "XPLANE DATAREF");
        AddRNS("nav1_active", "XPLANE DATAREF");
        AddRNS("nav1_stdby", "XPLANE DATAREF");

        AddCoreDataRefs("b742/lights/beacon/batatas", "Beacon Light");
        AddCoreDataRefs("b742/lights/nav/batatas", "Nav Light");

        AddSimulator("66ccc36b08515dfee1b48849", "xplane-12", "felix", "Boeing 742", false, listRns, listCoreDataRefs);
    }

    public static void AddRNS(string id, string name)
    {
        /// <summary>
        /// Adds an RNS to the list with the given parameters
        /// "id" - id of the RNS
        /// "name" - name of the RNS
        /// </summary>
        RNS r = new  RNS(id, name);
        listRns.Add(r);
    }

    public static void AddCoreDataRefs(string id, string name)
    {
        /// <summary>
        /// Adds a CoreDataRefs to the list with the given parameters
        /// "id" - id of the CoreDataRefs
        /// "name" - name of the CoreDataRefs
        /// </summary>
        CoreDataRefs c = new  CoreDataRefs(id, name);
        listCoreDataRefs.Add(c);
    }

    public static void AddSimulator(string id, string game, string partner, string objectName,
          Boolean community, List<RNS> rns, List<CoreDataRefs> coreDatarefs)
    {
        /// <summary>
        /// Adds a Simulator to the list with the given parameters
        /// "id" - id of the Simulator
        /// "game" - game of the Simulator
        /// "partner" - partner of the Simulator
        /// "objectName" - Nome of the object of the Simulator
        /// "community" - Has a community or not
        /// "rns" - List of the RNS's of the Simulator
        /// "coreDatarefs" - List of the Core Data Refs of the Simulator
        /// </summary>
        Simulator s = new Simulator(id, game, partner, objectName, community, rns, coreDatarefs);
        listSimulator.Add(s);
    }

}


