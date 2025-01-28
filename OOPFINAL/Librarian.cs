using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFINAL
{
    // Represents a librarian who manages the library books.
    internal class Librarian : PersonBase 
    {
        public double Salary { get; set; }  // Librarian's salary.
        public string Specialty { get; set; }  // Librarian's area of expertise.

        // Overrides the DisplayInfo method to show librarian-specific details.
        public override void DisplayInfo()
        {
            Console.WriteLine($"Librarian ID: {PersonID}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Phone: {PhoneNumber}");
            Console.WriteLine($"Address: {Address}");
            Console.WriteLine($"Salary: ${Salary}");
            Console.WriteLine($"Specialty: {Specialty}");
        }

    }
}
