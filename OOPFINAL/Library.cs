using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFINAL
{

    // Represents the library, managing books, members, and librarians.
    internal class Library
    {
        // Private dictionary to store books. 
        // Key: ISBN (unique identifier for books), Value: Book object.
        private Dictionary<string, Book> books = new Dictionary<string, Book>(); // Collection of books.

        // Private dictionary to store members. 
        // Key: PersonID (unique identifier for members), Value: Member object.
        private Dictionary<int, Member> members = new Dictionary<int, Member>(); 

        // Private dictionary to store librarians. 
        // Key: PersonID (unique identifier for librarians), Value: Librarian object.
        private Dictionary<int, Librarian> librarians = new Dictionary<int, Librarian>(); 

        public IReadOnlyDictionary<string, Book> Books => books; // Read-only property to allow external access to books without modification.
        public IReadOnlyDictionary<int, Member> Members => members; // Read-only property to allow external access to members without modification.
        public IReadOnlyDictionary<int, Librarian> Librarians => librarians; // Read-only property to allow external access to librarians without modification.

        // Adds a book to the library and assigns a librarian if available.
        public void AddBook(Book book)
        {
            // Check if the book with the same ISBN already exists
            if (books.ContainsKey(book.ISBN))
            {
                Console.WriteLine("Book with the same ISBN already exists.");
                return;
            }
            // Add the book to the library's collection
            books[book.ISBN] = book;
            // Find a librarian whose specialty matches the book type
            Librarian matchedLibrarian = null;
            foreach (var librarian in librarians.Values)
            {
                if (librarian.Specialty == book.Type)
                {
                    matchedLibrarian = librarian;
                    break; // Stop searching when a match is found
                }
            }
            // If a suitable librarian is found, assign the book to them
            if (matchedLibrarian != null)
            {

               
                book.AssignedLibrarian = matchedLibrarian;
                Console.WriteLine($"Book titled '{book.Title}' added and assigned to librarian '{matchedLibrarian.Name}'.");
            }
            else
            {
                // If no librarian has the required specialty, book is added without an assigned librarian
                Console.WriteLine($"No librarian available with specialty '{book.Type}'. Book not added.");
            }
        }

        // Add Member
        public void RegisterMember(Member member)
        {
            // Check if the provided ID is valid(greater than 0)
            if (member.PersonID <= 0)
            {
                Console.WriteLine("Invalid ID. ID must be a positive number.");
                return;
            }
            // Check if the person is already a librarian
            if (librarians.ContainsKey(member.PersonID))
            {
                Console.WriteLine("This person is already a librarian and cannot be a member.");
                return;
            }
            // Check if the member ID is already registered
            if (members.ContainsKey(member.PersonID))
            {
                Console.WriteLine("Member with the same ID already exists.");
            }
            else
            {
                // Register the new member
                members[member.PersonID] = member;
                Console.WriteLine($"Member '{member.Name}' registered.");
            }
        }

        // Add Librarian 
        public void RegisterLibrarian(Librarian librarian)
        {
            // Check if the provided ID is valid (greater than 0)
            if (librarian.PersonID <= 0)
            {
                Console.WriteLine("Invalid ID. ID must be a positive number.");
                return;
            }
            // Ensure salary is not negative
            if (librarian.Salary < 0)
            {
                Console.WriteLine("Salary cannot be negative.");
                return;
            }
            // Check if a librarian with the same ID already exists
            if (librarians.ContainsKey(librarian.PersonID))
            {
                Console.WriteLine("Librarian with the same ID already exists.");
            }
            else
            {
                // Register the new librarian
                librarians[librarian.PersonID] = librarian;
                Console.WriteLine($"Librarian '{librarian.Name}' registered.");
            }
        }

        // Show all books information
        public void DisplayAllBooks()
        {
            Console.WriteLine("Books in Library:");
            foreach (var book in books.Values)
            {
                book.DisplayBookInfo(); // Calls the method inside the Book class to print details
            }
        }

        // Show all members information 
        public void DisplayAllMembers()
        {
            Console.WriteLine("Library Members:");
            foreach (var member in members.Values)
            {
                member.DisplayInfo(); // Calls the method inside the Member class to print details
            }
        }
        public void AssignLibrarianToBook(string isbn)
        {
            // Check if the book exists in the library
            if (!books.ContainsKey(isbn))
            {
                Console.WriteLine("Book not found.");
                return;
            }

            var book = books[isbn];

            Librarian assignedLibrarian = null;

            // Find a librarian whose specialty matches the book type
            foreach (var librarian in librarians.Values)
            {
                if (librarian.Specialty == book.Type)  // Does the Librarian's area of ​​expertise match the book genre?
                {
                    assignedLibrarian = librarian;
                    break;  // Stop searching when a match is found
                }
            }
            // If a matching librarian is found, assign them to the book
            if (assignedLibrarian != null)
            {
                book.AssignedLibrarian = assignedLibrarian;
                Console.WriteLine($"Librarian '{assignedLibrarian.Name}' assigned to book '{book.Title}' of type '{book.Type}'.");
            }
            else
            {
                // No librarian found for this book type
                Console.WriteLine($"No librarian found for book type '{book.Type}'. Book not assigned.");
            }
        }

    }
}
