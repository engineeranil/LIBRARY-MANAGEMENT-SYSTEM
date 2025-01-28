using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFINAL
{
    // Interface defining basic properties for any person-related class.
    internal interface IPerson
    {
        int PersonID { get; set; } // Unique ID for the person.
        string Name { get; set; } // Name of the person.
    }
}
