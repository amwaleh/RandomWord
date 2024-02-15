// See https://aka.ms/new-console-template for more information

using System.Reflection;
using Game;
using RandomWords;



List<string> menuItems = new List<string>();

Console.WriteLine("Welcome to the Random Word Game!");
Console.WriteLine("Please select a category:");
var collections = new Collections();

// using reflection to get the value of the field

FieldInfo[] fields = collections.GetType().GetFields();

foreach (var v in fields.Select((field, index) => new { field, index }))
{
    Console.WriteLine($"{item.index} : {item.field.Name} ");
    menuItems.Add(item.field.Name);
}

int selection = Convert.ToInt32(Console.ReadLine());
Console.WriteLine($"--------------Your Lucky {menuItems[selection]} selection is ---------------------------");

FieldInfo? field = collections.GetType().GetField(menuItems[selection]);
List<string>? fieldValues = (List<string>?) field?.GetValue(collections) ?? new List<string>();
RandomWordGame game = new(fieldValues);
Console.WriteLine(game.GetWord());


