using BookStoreApp.Models;

var books = new List<Book>();

while (true)
{
    Console.WriteLine("Please enter command: 'Add', 'List', 'Delete {title}', Exit: ");
    var command = Console.ReadLine();

    if (command.ToLower() == "exit")
    {
        return;
    }
    else if (command.ToLower() == "add")
    {
        Console.WriteLine("Please enter the Title");
        var title = Console.ReadLine();

        Console.WriteLine("Please enter the Description");
        var description = Console.ReadLine();

        Console.WriteLine("Please enter the Amount");
        var amount = 0;
        try
        {
            amount = Convert.ToInt32(Console.ReadLine());
        }
        catch (Exception ex)
        {
            Console.WriteLine("Wrong amount");
        }

        var Book = new Book(title, description, amount);

        if (books.Count > 0)
        {
            foreach (var book in books)
            {
                if (book.Title == title)
                {
                    Console.WriteLine("Duplicate entry, try again.");
                    continue;
                }
            }
        }
        books.Add(Book);
    }
    else if (command.ToLower() == "list")
    {
        foreach (var book in books)
        {
            book.PrintBook();
        }
    }
    else if (command.ToLower().Contains("delete"))
    {
        var titleToDelete = command.Substring(command.IndexOf(' ') + 1);
        for (int i = 0; i < books.Count; i++)
        {
            if (books[i].Title == titleToDelete)
            {
                books.RemoveAt(i);
                continue;
            }
        }
    }
}