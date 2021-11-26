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
		var amount = Convert.ToInt32(Console.ReadLine());

		var Book = new Book(title, description, amount);
		books.Add(Book);
	}
	else if (command.ToLower() == "list")
	{
		foreach (var book in books)
		{
			book.PrintBook();
		}
	}

	
}