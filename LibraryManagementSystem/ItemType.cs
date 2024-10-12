using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class Book(string title) : LibraryItem(title, 14, 0.50) { }

    public class Magazine(string title) : LibraryItem(title, 7, 0.25) { }

    public class DVD(string title) : LibraryItem(title, 3, 1.00){ }

}
