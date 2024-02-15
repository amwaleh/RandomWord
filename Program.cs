// See https://aka.ms/new-console-template for more information

using System.Reflection;
using Game;
using RandomWords;



List<string> menuItems = [];
var collections = new Collections();

// Using reflection to get the value of the field
FieldInfo[] fields = collections.GetType().GetFields();
Console.WriteLine("Welcome to the Random Word Game!");
Console.WriteLine("Please select a category:");
foreach (var item in fields.Select((field, index) => new { field, index }))
{
    Console.WriteLine($"{item.index} : {item.field.Name} ");
    menuItems.Add(item.field.Name);
}
// User selection
int selection = Convert.ToInt32(Console.ReadLine());

if (selection < 0 || selection >= menuItems.Count)
{
    Console.WriteLine("Invalid selection");
    return;
}


FieldInfo? field = collections.GetType().GetField(menuItems[selection]);
List<string>? fieldValues = (List<string>?) field?.GetValue(collections) ?? new List<string>();
RandomWordGame game = new(fieldValues);
string luckyWord = game.GetWord();

Console.WriteLine($"--------------Your Lucky {menuItems[selection]} selection is ---------------------------");
Console.WriteLine(luckyWord);


