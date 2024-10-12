using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class Library
    {
        private readonly List<Book> books;
        private readonly List<Magazine> magazines;
        private readonly List<DVD> dVDs;

        public Library()
        {
            books = []; /*new List<Book>();*/
            magazines = [];
            dVDs = [];
         
        }
        private readonly int BookLimit = 100;
        private readonly int MagazineLimit = 50;
        private readonly int DVDLimit = 30;

        public void AddBook(string title)
        {
            if(books.Count <  BookLimit)
            {
                books.Add(new Book(title));
                Console.WriteLine($"{title} has been added to library");
            }
            else
            {
                Console.WriteLine("Book can not be added. Its library section is already full");
            }
        }

        public void AddMagazine(string title)
        {
            if (magazines.Count < MagazineLimit)
            {
                magazines.Add(new Magazine(title));
                Console.WriteLine($"{title} has been added to library");
            }
            else
            {
                Console.WriteLine("Magazine can not be added. its Library section is already full");
            }    
        }

        public void AddDVD(string title)
        {
            if (dVDs.Count < DVDLimit)
            {
                dVDs.Add(new DVD(title));
                Console.WriteLine($"{title} has been added to library");
            }
            else
            {
                Console.WriteLine("DVD can not be added. its Library section is already full");
            }
        }

        //Helper method to find an item 
        private LibraryItem FindItem(string title)
        {
            LibraryItem item = books.Find(c => c.Title == title) as LibraryItem ??
                               magazines.Find(k => k.Title == title) as LibraryItem ??
                               dVDs.Find(m => m.Title == title) as LibraryItem;

            return item;
        }

        public void BorrowItem(string title)
        {
            LibraryItem item = FindItem(title);

            if(item != null && !item.IsBorrowed)
            {
                item.BorrowItem();
                Console.WriteLine($"You have borrowed: {title}, Due for return on {item.GetDueDate().Value.ToShortDateString()}");
            }
            else
            {
                Console.WriteLine($"'{title}' is either not available or is already borrowed.");
            }
        }

        public void ReturnItem(string title)
        {
            LibraryItem item = FindItem(title);

            if (item!= null && item.IsBorrowed)
            {
                item.ReturnItem();
                Console.WriteLine($"'{title}' has been returned.");
            }
            else
            {
                Console.WriteLine($"'{title}' is not currently borrowed.");
            }
        }
        
        public void ListBorrowedItem()
        {
            Console.WriteLine("Borrowed Items:");

            foreach(LibraryItem item in books)
            {
                if (item.IsBorrowed)
                    Console.WriteLine($"Book: {item.Title}, Borrowed Date: {item.BorrowedDate}," +
                        $"Due Date: {item.GetDueDate().Value.ToShortDateString()}, Overdue: {item.IsOverdue} ");
            }

            foreach (LibraryItem item in magazines)
            {
                if (item.IsBorrowed)
                    Console.WriteLine($"Magazine: {item.Title}, Borrowed Date: {item.BorrowedDate}," +
                        $"Due Date: {item.GetDueDate().Value.ToShortDateString()}, Overdue: {item.IsOverdue} ");
            }

            foreach (LibraryItem item in dVDs)
            {
                if (item.IsBorrowed)
                    Console.WriteLine($"DVD: {item.Title}, Borrowed Date: {item.BorrowedDate}," +
                        $"Due Date: {item.GetDueDate().Value.ToShortDateString()}, Overdue: {item.IsOverdue} ");
            }

        }

        public void CheckAvailability()
        {
            Console.WriteLine($"Book slots Available: {BookLimit - books.Count}");
            Console.WriteLine($"Magazine slots Available: {MagazineLimit - magazines.Count}");
            Console.WriteLine($"DVD slots Available: {DVDLimit - dVDs.Count}");
        }

        public bool IsLibraryFull()
        {
            return books.Count == BookLimit && magazines.Count == MagazineLimit && dVDs.Count == DVDLimit;
        }

        public bool IsLibraryEmpty()
        {
            return books.Count == 0 && magazines.Count == 0 && dVDs.Count == 0;
        }
    }
}
