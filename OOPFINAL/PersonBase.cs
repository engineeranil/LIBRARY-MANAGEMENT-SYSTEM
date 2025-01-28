using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFINAL
{
    // Abstract base class implementing IPerson and adding common properties.
    internal abstract class PersonBase : IPerson
    {
        public int PersonID { get; set; }  // Unique ID for the person.
        public string Name { get; set; } // Name of the person.
        public string PhoneNumber { get; set; }  // Phone number of the person.
        public string Address { get; set; } // Address of the person.

        // Abstract method that must be implemented by derived classes.
        public abstract void DisplayInfo();
    }
}
