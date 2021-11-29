using BookStoreApp.Models;

var books = new List<Book>();

books.Add(new Book("Nr 1 book", "Some desc 1", 1111));
books.Add(new Book("Nr 2 book", "Some desc 2", 2222));
books.Add(new Book("Nr 3 book", "Some desc 3", 3333));
books.Add(new Book("Nr 4 book", "Some desc 4", 4444));
books.Add(new Book("Nr 5 book", "Some desc 5", 5555));

while (true)
{
    Console.WriteLine("Please enter command: 'Add', 'List', 'Delete {title}', Update {title}, Exit: ");
    var command = Console.ReadLine();

    if (command.ToLower() == "exit")
    {
        return;
    }
    if (command.ToLower() == "add")
    {
        try
        {
            AddBook();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    if (command.ToLower() == "list")
    {
        ListBooks();
    }
    if (command.ToLower().IndexOf("delete") == 0)
    {
        DeleteBook(command);
    }
    if (command.ToLower().IndexOf("update") == 0)
    {
        try
        {
            UpdateBook(command);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
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

void AddBook()
{
    Book newBook = GetNewBook();

    if (books.Count > 0)
    {
        foreach (var book in books)
        {
            if (book.Title == newBook.Title)
            {
                throw new Exception("Duplicate entry, try again.");
            }
        }
    }
    books.Add(newBook);
}

Book GetNewBook()
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
        throw new Exception("Wrong amount.");
    }

    return new Book(title, description, amount);
}

void DeleteBook(string command)
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

void UpdateBook(string command)
{
    var titleToUpdate = command.ToLower().Substring(command.IndexOf(' ') + 1);

    for (int i = 0; i < books.Count; i++)
    {
        if (books[i].Title.ToLower() == titleToUpdate)
        {
            Console.WriteLine("Enter new title or leave empty for original title:");
            var newTitle = Console.ReadLine();
            if (newTitle != "")
            {
                books[i].Title = newTitle;
            }
            Console.WriteLine("Enter new description or leave empty for original description:");
            var newDescription = Console.ReadLine();
            if (newDescription != "")
            {
                books[i].Description = newDescription;
            }
            Console.WriteLine("Enter new amount or leave empty for original amount:");
            var newAmount = 0;
            try
            {
                newAmount = Convert.ToInt32(Console.ReadLine());
                books[i].Amount = newAmount;
            }
            catch (Exception ex)
            {
                throw new Exception("Wrong new amount");
            }
            continue;
        }
    }
}