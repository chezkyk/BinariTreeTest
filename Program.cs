using BinariTreeTest;
using BinariTreeTest.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;

class Program // Binary search tree program
{

    static async Task Main(string[] args)
    {
        // Defining an instance of the protection class
        DefenceStrategiesBST defenceStrategiesBST = new DefenceStrategiesBST();

        // Reading all data from a JSON file
        string jsonContentDefence = GetjsonDefence();

        // Inserting values ​​from the file into an array
        List<ModelNode> values = JsonConvert.DeserializeObject<List<ModelNode>>(jsonContentDefence);

        InsertsValuesLoopIntoTheTree(values, defenceStrategiesBST);

        await Task.Delay(4000);

        // A call to a function that will print the entire defense tree
        defenceStrategiesBST.preorderTraversal();

        // A call to a function that will print visual the entire defense tree
        defenceStrategiesBST.PrintTree(defenceStrategiesBST.root);

        await Task.Delay(4000);
        //***************************************************************************

        // Reading all data from a JSON file
        string jsonContentThrets = GetjsonThreatse();


        // Inserting values ​​from the file into an array
        List<ModelThreat> threats = JsonConvert.DeserializeObject<List<ModelThreat>>(jsonContentThrets);

        await Task.Delay(4000);

        await StartAttack(threats,defenceStrategiesBST);


    }

    public static void InsertsValuesLoopIntoTheTree(List<ModelNode> values, DefenceStrategiesBST defenceStrategiesBST)
    {
        // O(n)
        for (int i = 0; i < values.Count(); i++)
        {
            defenceStrategiesBST.Insert(values[i]);
        }
    }

    public static string  GetjsonDefence()
    {
        return File.ReadAllText("C:\\Users\\Admin\\source\\repos\\BinariTreeTest\\JsonFiles\\defenceStrategiesBalanced.json");
    }

    public static string GetjsonThreatse()
    {
        return File.ReadAllText("C:\\Users\\Admin\\source\\repos\\BinariTreeTest\\JsonFiles\\threats.json");
    }

    // This function starts an attack
    public static async Task StartAttack(List<ModelThreat> threats, DefenceStrategiesBST defenceStrategiesBST)
    {
        // This loop runs through all the threats and sends them to the function that creates an attack

        // O(n)
        for (int i = 0; i < threats.Count(); i++)
        {
            await CreteAttack(threats[i], defenceStrategiesBST);
        }
    }

    // This function creates an attack
    public static async Task CreteAttack(ModelThreat modelThreat, DefenceStrategiesBST defenceStrategiesBST)
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

            await Task.Delay(2000);
            
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





