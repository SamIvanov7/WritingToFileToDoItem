using System;
using System.Collections.Generic;
using System.IO;

[Serializable]
public class ToDoItem
{
    public string Title { get; set; }
    public bool IsCompleted { get; set; }
}

class Program
{
    static void Main()
    {
        List<ToDoItem> toDoItems = new List<ToDoItem>
        {
            new ToDoItem { Title = "Item 1", IsCompleted = false },
            new ToDoItem { Title = "Item 2", IsCompleted = true }
        };

        
        using (BinaryWriter writer = new BinaryWriter(File.Open("toDoItems.dat", FileMode.Create)))
        {
            foreach (ToDoItem item in toDoItems)
            {
                writer.Write(item.Title);
                writer.Write(item.IsCompleted);
            }
        }
        Console.WriteLine("File has been written");

        
        List<ToDoItem> toDoItemsFromFile = new List<ToDoItem>();
        using (BinaryReader reader = new BinaryReader(File.Open("toDoItems.dat", FileMode.Open)))
        {
            while (reader.BaseStream.Position != reader.BaseStream.Length)
            {
                string title = reader.ReadString();
                bool isCompleted = reader.ReadBoolean();
                toDoItemsFromFile.Add(new ToDoItem { Title = title, IsCompleted = isCompleted });
            }
        }

       
        foreach (ToDoItem item in toDoItemsFromFile)
        {
            Console.WriteLine($"Title: {item.Title}, Completed: {item.IsCompleted}");
        }

        
        string text = "qwer asdf, qwer";
        var result = text.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var item in result)
        {
            Console.WriteLine(item);
        }
    }
}
