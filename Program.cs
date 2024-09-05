using BinariTreeTest;
using BinariTreeTest.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

class Program // Binary search tree program
{

    static void Main(string[] args)
    {
        // Defining an instance of the protection class
        DefenceStrategiesBST defenceStrategiesBST = new DefenceStrategiesBST();

        // Reading all data from a JSON file
        string jsonContentDefence = File.ReadAllText("C:\\Users\\Admin\\source\\repos\\BinariTreeTest\\JsonFiles\\defenceStrategiesBalanced.json");

        // Inserting values ​​from the file into an array
        List<ModelNode> values = JsonConvert.DeserializeObject<List<ModelNode>>(jsonContentDefence);

        // A loop that goes through the entire array and you send them to a function that will insert the values ​​into the tree
        foreach (var item in values)
        {
            defenceStrategiesBST.Insert(item);
        }

        // A call to a function that will print the entire defense tree
        defenceStrategiesBST.preorderTraversal();

        //***************************************************************************

        // Reading all data from a JSON file
        string jsonContentThrets = File.ReadAllText("C:\\Users\\Admin\\source\\repos\\BinariTreeTest\\JsonFiles\\threats.json");


        // Inserting values ​​from the file into an array
        List<ModelThreat> threats = JsonConvert.DeserializeObject<List<ModelThreat>>(jsonContentThrets);

        
        StartAttack(threats,defenceStrategiesBST);


    }

    // This function starts an attack
    public static void StartAttack(List<ModelThreat> threats, DefenceStrategiesBST defenceStrategiesBST)
    {
        // This loop runs through all the threats and sends them to the function that creates an attack
        foreach (var item in threats)
        {
            CreteAttack(item, defenceStrategiesBST);
        }
    }

    // This function creates an attack
    public static void CreteAttack(ModelThreat modelThreat, DefenceStrategiesBST defenceStrategiesBST)
    {
        int severity = CalculateSeverity(modelThreat.Volume, modelThreat.Sophistication, modelThreat.Target);
        int value = defenceStrategiesBST.FindValueInTree(severity);

        // Checking if the severity is lower than the minimum
        if (severity < defenceStrategiesBST.GetMin().Value.MinSeverity)
        {
            Console.WriteLine("Attack severity is below the threshold. Attack is ignored");
        }

        // Checking if the severity is not in the tree
        if (value == -1)
        {
            Console.WriteLine("Not suitable defence was found!. Brace for impact");
        }

        else
        {
            Console.WriteLine($"Attack ThreatType is: {modelThreat.ThreatType}, Volume is: {modelThreat.Volume}, Sophistication is: {modelThreat.Sophistication}, Target is: {modelThreat.Target}");

            Console.WriteLine($"defence is: {value}");
        }

    }


    public static int CalculateSeverity(int volume, int sophistication, string targetValue)
    {
        return (volume * sophistication) + ConvertTargetValue(targetValue);
    }


    public static int ConvertTargetValue(string targetValue)
    {
        switch (targetValue)
        {
            case ("Web Server"):
                return 10;
            case ("Database"):
                return 15;
            case ("User Credentials"):
                return 20;
            default:
                return 5;

        }
    }
}





