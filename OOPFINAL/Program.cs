using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFINAL
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the Library class to manage books, members, and librarians.
            Library library = new Library();
            // Control variable for the while loop to keep the menu running.
            bool exit = true;

            // The main menu will keep showing as long as exit is true.
            while (exit)
            {
                // The main menu options are displayed to the user.
                Console.WriteLine("\nLibrary Management System Menu:");
                Console.WriteLine("1. Add Librarian");
                Console.WriteLine("2. Add Member");
                Console.WriteLine("3. Add Book");
                Console.WriteLine("4. Borrow Book");
                Console.WriteLine("5. Return Book");
                Console.WriteLine("6. View All Books");
                Console.WriteLine("7. View All Members");
                Console.WriteLine("8. Exit");
                Console.Write("Select an option (1-8): ");

                // The user input is captured for the choice.
                int choice;

                // This checks if the input is a valid number and if it's within the range of 1-8.
                // If the input is invalid, it will prompt the user to try again.
                if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 8)
                {
                    Console.WriteLine("Invalid option. Please try again."); // Go back to the menu if input is invalid.
                    continue; // If the input is invalid, the loop starts again.
                }
                // The switch case handles the selected option and executes the appropriate action.
                switch (choice)
                {
                    case 1:
                        // Registers a new librarian by asking for necessary information from the user.
                        Console.Write("Enter Librarian ID: ");
                        int librarianId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Librarian Name: ");
                        string librarianName = Console.ReadLine();
                        Console.Write("Enter Librarian Phone Number without 0 : ");
                        string phone = Console.ReadLine();
                        Console.Write("Enter Librarian Email Adress : ");
                        string emailAdress = Console.ReadLine(); 
                        Console.Write("Enter Salary: ");
                        double salary = double.Parse(Console.ReadLine());
                        Console.Write("Enter Specialty (Fiction, Science, History, Technology): ");
                        string specialty = Console.ReadLine();
                        // Register the new librarian in the system by calling the RegisterLibrarian method.
                        library.RegisterLibrarian(new Librarian { PersonID = librarianId, Name = librarianName,PhoneNumber = phone,Address = emailAdress ,Salary = salary, Specialty = specialty });
                        break;

                    case 2:
                        // Registers a new member by asking for necessary information from the user.
                        Console.Write("Enter Member ID: ");
                        int memberId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Member Name: ");
                        string memberName = Console.ReadLine();
                        Console.Write("Enter Phone Number without 0 : ");
                        string phoneNumber = Console.ReadLine();
                        Console.Write("Enter Address: ");
                        string adress = Console.ReadLine();
                        Console.Write("Enter Membership Type (Basic, Premium): ");
                        string membershipType = Console.ReadLine();
                        // Register the new member in the system by calling the RegisterMember method.
                        library.RegisterMember(new Member { PersonID = memberId,Name = memberName,PhoneNumber = phoneNumber,Address = adress,MembershipType = membershipType });
                        break;

                    case 3:
                        // Adds a new book by asking for necessary information from the user.
                        Console.Write("Enter Book Title: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter Author: ");
                        string author = Console.ReadLine();
                        Console.Write("Enter ISBN: ");
                        string isbn = Console.ReadLine();
                        Console.Write("Enter Type (Fiction, Science, History, Technology): ");
                        string type = Console.ReadLine();
                        Console.Write("Enter Available Copies: ");
                        int copies = int.Parse(Console.ReadLine());
                        // Add the book to the system by calling the AddBook method.
                        library.AddBook(new Book { Title = title, Author = author, ISBN = isbn, Type = type, AvailableCopies = copies });
                        break;
                    case 4:
                        // Allows a member to borrow a book.
                        Console.Write("Enter Member ID: ");
                        int borrowerId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Book ISBN: ");
                        string borrowIsbn = Console.ReadLine();
                        // Check if the member exists in the system.
                        if (library.Members.ContainsKey(borrowerId))
                        {
                            // Call the BorrowBook method of the member to borrow the book.
                            library.Members[borrowerId].BorrowBook(borrowIsbn, library);
                        }
                        else
                        {
                            Console.WriteLine("Member not found."); // Error message if the member is not found.
                        }
                        break;

                    case 5:
                        // Allows a member to return a borrowed book.
                        Console.Write("Enter Member ID: "); // Member's ID
                        int returnerId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Book ISBN: ");
                        string returnIsbn = Console.ReadLine(); // ISBN of the book to return
                        // Check if the member exists in the system.
                        if (library.Members.ContainsKey(returnerId))
                        {
                            // Call the ReturnBook method of the member to return the book.
                            library.Members[returnerId].ReturnBook(returnIsbn, library);
                        }
                        else
                        {
                            Console.WriteLine("Member not found."); // Error message if the member is not found.
                        }
                        break;

                    case 6:
                        // Displays all the books in the library.
                        library.DisplayAllBooks();
                        break;

                    case 7:
                        // Displays all the members of the library.
                        library.DisplayAllMembers();
                        break;

                    case 8:
                        // Exits the program and sets exit to false, ending the loop.
                        Console.WriteLine("Exiting the system. Goodbye!");
                        exit = false;
                        break;
                    default:
                        // If the user enters an invalid choice, display an error message.
                        Console.WriteLine("Invalid choice,please try again.");
                        break;
                }
                // If the user hasn't selected "Exit", the program asks for a key press to continue.
                if (exit)
                {
                    Console.WriteLine("Please,enter any key to continue...");
                    Console.ReadLine(); // Wait for the user to press a key before showing the menu again.
                }
            }
        }
    }
}
