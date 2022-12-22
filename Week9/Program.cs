// Creating and reading a list from file.


// List path.
string FolderPath = "C:\\Users\\(string UserName)\\source\\data\\";
string FileName = "ShoppingList.txt";
string FilePath = Path.Combine(FolderPath, FileName);

List<string> ShoppingList = new List<string>();


// Checking if the file exists or not.
if (File.Exists(FilePath))
{
    ShoppingList = UserItemsChoice();
    //ShowListItems(ShoppingList);
    File.WriteAllLines(FilePath, ShoppingList);
}
else
{
    File.Create(FilePath).Close();
    Console.WriteLine($"File {FileName} has been created.");
    ShoppingList = UserItemsChoice();
    //ShowListItems(ShoppingList);
    File.WriteAllLines(FilePath, ShoppingList);
}


// Function to add items to the list and exit.
static List<string> UserItemsChoice()
{
    List<string> UserList = new List<string>();

    while (true)
    {
        Console.WriteLine("Add an item or exit (Write Add/Exit):");
        string UserChoice = Console.ReadLine().ToLower();

        if (UserChoice == "add")
        {
            Console.WriteLine("Enter an item:");
            string UserItem = Console.ReadLine();
            UserList.Add(UserItem);
            Console.WriteLine($"{UserItem} added.");
        }
        else if (UserChoice == "exit")
        {
            Console.WriteLine("Bye!");
            break;
        }
        else
        {
            Console.WriteLine("What?");
            break;
        }
        
    }
    return UserList;
}

// Function to see what the list currently contains.
static void ShowListItems(List<string> AnyList)
{
    Console.Clear();
    int ListLength = AnyList.Count;
    Console.WriteLine($"Your shopping list has {ListLength} item(s):");

    int i = 1;
    foreach (string UserItem in AnyList)
    {
        Console.WriteLine($"{i}. {UserItem}");
        i++;
    }
}