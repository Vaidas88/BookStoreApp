using BookStoreApp.Models;

var books = new List<Book>();

while (true)
{
    Console.WriteLine("Please enter command: 'Add', 'List', 'Delete {title}', Update, Exit: ");
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
        ListBooks();
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
    else if (command.ToLower().Contains("update"))
    {
        ListBooks();
        Console.WriteLine("Enter book number to edit:");
        var bookNumber = 0;
        try
        {
            bookNumber = Convert.ToInt32(Console.ReadLine()) - 1;
        }
        catch
        {
            Console.WriteLine("Wrong book number");
            continue;
        }
        Console.WriteLine("Enter new title or leave empty for original title:");
        var newTitle = Console.ReadLine();
        if (newTitle != "")
        {
            books[bookNumber].Title = newTitle;
        }
        Console.WriteLine("Enter new description or leave empty for original description:");
        var newDescription = Console.ReadLine();
        if (newDescription != "")
        {
            books[bookNumber].Description = newDescription;
        }
        Console.WriteLine("Enter new amount or leave empty for original amount:");
        var newAmount = 0;
        try
        {
            newAmount = Convert.ToInt32(Console.ReadLine());
            books[bookNumber].Amount = newAmount;
        }
        catch (Exception ex)
        {

        }
    }
}

void ListBooks()
{
    for (int i = 0; i < books.Count; i++)
    {
        Console.Write($"{i + 1}. ");
        books[i].PrintBook();
    }
}