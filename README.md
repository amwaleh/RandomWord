

# Random Word Game

This code is a console application that allows the user to select a category and get a random word from that category.

## Code Explanation

### Namespace Imports

The code imports three namespaces: `System.Reflection`, `Game`, and `RandomWords`.

### Creating the Menu

The code creates a menu by using reflection to get all the fields in the `Collections` class. Each field is displayed as an option in the menu, and the user can select an option by entering the corresponding number.

### Getting the User's Selection

The code uses the user's selection to dynamically load the selected category's list of words using reflection. It then creates a new instance of the `RandomWordGame` class with the selected category's list of words.

### Displaying a Random Word

The code uses the `GetWord()` method of the `RandomWordGame` class to get a random word from the selected category's list of words. It then displays the word to the user.




### Using Reflection C#

Reflection is the ability to see the type of a class or assembly metadata, such as fields, properties, methods, and so on. 
Reflection enables us to dynamically access this metadata during runtime.

We use reflection to get all the fields within the `Collections` instance object:

```C#
using System.Reflection;

// ...

FieldInfo[] fields = collections.GetType().GetFields();
```

### Dynamically Create the Option Menu

Through reflection, we can get access to all the fields in the class. This enables us to expand the fields without tightly coupling to dependent 
functionality like printing the categories menu. Through reflection, the menu will automatically be updated when we add more field categories:

```C#
FieldInfo[] fields = collections.GetType().GetFields();

foreach (var item in fields.Select((field, index) => new { field, index }))
{
    Console.WriteLine($"{item.index} : {item.field.Name} ");
    menuItems.Add(item.field.Name);
}
```

### Execute User Option Dynamically

Using reflection, we dynamically load the user selection, enabling the user to choose available options without having to hardcode these categories in an enum or list:

```C#
int selection = Convert.ToInt32(Console.ReadLine());
Console.WriteLine($"--------------Your Lucky {menuItems[selection]} selection is ---------------------------");

FieldInfo? field = collections.GetType().GetField(menuItems[selection]);
List<string>? fieldValues = (List<string>?) field?.GetValue(collections) ?? new List<string>();
RandomWordGame game = new(fieldValues);
Console.WriteLine(game.GetWord());
```

### Enumerating Foreach Loop

To add an index to your `foreach` loop, you can do it using a variable:

```C#
FieldInfo[] fields = collections.GetType().GetFields();
int count = 0; 
foreach(var item in fields ){
    Console.WriteLine($"{count} : {item.Name} ");
    menuItems.Add(item.Name);
    count++;
}
```

Or use LINQ:

```C#
foreach (var v in fields.Select((field, index) => new { field, index }))
{
    Console.WriteLine($"{item.index} : {item.field.Name} ");
    menuItems.Add(item.field.Name);
}
```

[watch tutorial on reflection](https://www.youtube.com/watch?v=MqJ_JjCV-9M)