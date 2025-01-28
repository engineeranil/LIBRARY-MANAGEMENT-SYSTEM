using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFINAL
{
    // Represents a book in the library.
    internal class Book
    {
        public string Title { get; set; }  // Title of the book.
        public string Author { get; set; } // Author of the book.
        public string ISBN { get; set; }     // ISBN of the book.
        public int AvailableCopies { get; set; } // Number of available copies.
        public string Type { get; set; }  // Type/genre of the book.
        public Librarian AssignedLibrarian { get; set; }  // Librarian assigned to manage the book.

        // Calculates the cost of borrowing based on book type.
        public double GetCost()
        {
            if (Type == "Fiction")
                return 2;
            else if (Type == "Science")
                return 3;
            else if (Type == "History")
                return 2;
            else if (Type == "Technology")
                return 4;
            else
                return 0;
        }

        // Displays book details.
        public void DisplayBookInfo()
        {
            Console.WriteLine($"Title: {Title}, Author: {Author}, ISBN: {ISBN}, Copies: {AvailableCopies}, Type: {Type}");
        }
    }
}
