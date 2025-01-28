using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFINAL
{
    // Represents a library member who borrows and returns books.
    internal class Member : PersonBase
    {
        public string MembershipType { get; set; }
        public Dictionary<string, int> BooksBorrowed { get; set; } = new Dictionary<string, int>();
        public double Balance { get; set; }

        // Displays member-specific details including borrowed books.
        public override void DisplayInfo()
        {
            Console.WriteLine($"Member ID: {PersonID}, Name: {Name}, Phone: {PhoneNumber}, Address: {Address}, Membership Type: {MembershipType}, Balance: ${Balance}");
           Console.WriteLine("Borrowed Books:");
            if (BooksBorrowed.Count == 0)
            {
                Console.WriteLine("  No books borrowed.");
            }
            else
            {
                foreach (var book in BooksBorrowed)
                {
                    Console.WriteLine($"  - ISBN: {book.Key}, Count: {book.Value}");
                }
            }

            Console.WriteLine("-----------------------------------");
        }

        // Allows a member to borrow a book from the library.
        public void BorrowBook(string isbn, Library library)
        {
            // Check if the book exists in the library.
            if (!library.Books.ContainsKey(isbn))
            {
                Console.WriteLine("Book not found in the library.");
                return;
            }
            var book = library.Books[isbn];

            // Check if the book is available.
            if (book.AvailableCopies <= 0)
            {
                Console.WriteLine("Book is not available for borrowing.");
                return;
            }

            // Prevent borrowing the same book multiple times.
            if (BooksBorrowed.ContainsKey(isbn) && BooksBorrowed[isbn] > 0)
            {
                Console.WriteLine("You have already borrowed this book. Returning is required before borrowing again.");
                return;
            }

            // Borrow the book.
            BooksBorrowed[isbn] = 1;
            book.AvailableCopies--;

            Console.WriteLine($"Book '{book.Title}' with ISBN {isbn} borrowed successfully.");
        }

        // Allows a member to return a borrowed book to the library.
        public void ReturnBook(string isbn, Library library)
        {
            // Check if the book was borrowed by the member.
            if (!BooksBorrowed.ContainsKey(isbn) || BooksBorrowed[isbn] <= 0)
            {
                Console.WriteLine("Error: This book has already been returned or was never borrowed.");
                return;
            }

            var book = library.Books[isbn];

            // Return the book and calculate fees.
            BooksBorrowed[isbn]--; 

            if (BooksBorrowed[isbn] == 0)
            {
                BooksBorrowed[isbn] = 0; // If the book is fully returned, set to zero but deleted
            }

            double fee = book.GetCost(); // Calculate the fee based on book type.
            Balance += fee;
            book.AvailableCopies++;

            Console.WriteLine($"Book '{book.Title}' with ISBN {isbn} returned successfully. Fee: ${fee}");
        }

    }
}
