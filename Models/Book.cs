using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Models
{
    public class Book
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }

        public Book(string title, string description, int amount)
        {
            this.Title = title;
            this.Description = description;
            this.Amount = amount;
        }

        public void PrintBook()
        {
            Console.WriteLine($"title: {this.Title}, description: {this.Description}, amount: {this.Amount}");
        }
    }
}
