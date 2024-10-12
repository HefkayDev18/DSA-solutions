using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class Book(string title) : LibraryItem(title, 14) { }

    public class Magazine(string title) : LibraryItem(title, 7) { }

    public class DVD(string title) : LibraryItem(title, 3){ }

}
