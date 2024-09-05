using BinariTreeTest;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

class Program // Binary search tree program
{

    static void Main(string[] args)
    {
        // Defining an instance of the protection class
        DefenceStrategiesBST defenceStrategiesBST = new DefenceStrategiesBST();

        // Reading all data from a JSON file
        string jsonContent = File.ReadAllText("C:\\Users\\Admin\\source\\repos\\BinariTreeTest\\defenceStrategiesBalanced.json");

        // Inserting values ​​from the file into an array
        List<ModelNode> values = JsonConvert.DeserializeObject<List<ModelNode>>(jsonContent);

        // A loop that goes through the entire array and you send them to a function that will insert the values ​​into the tree
        foreach (var item in values)
        {
            defenceStrategiesBST.Insert(item);
        }

        // A call to a function that will print the entire defense tree
        defenceStrategiesBST.preorderTraversal();



    }
}
