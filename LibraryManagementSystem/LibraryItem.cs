using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class LibraryItem(string title, int borrowingLimitDays)
    {
        public string Title { get; private set; } = title;
        //Might have used a key or ID instead, maybe string(first 2 letters of item type + random number or guid)
        public int BorrowingLimitDays { get; private set; } = borrowingLimitDays;
        public bool IsBorrowed { get; private set; } = false;
        public DateTime? BorrowedDate { get; private set; }


        public DateTime? GetDueDate()
        {
            return BorrowedDate?.AddDays(BorrowingLimitDays);
        }

        public bool IsOverdue()
        {
            if (BorrowedDate == null) return false;
            return DateTime.Now > GetDueDate();
        }

        public void BorrowItem()
        {
            if (!IsBorrowed) BorrowedDate = DateTime.Now;
            else Console.WriteLine($"{Title} has been borrowed");
        }

        public void ReturnItem()
        {
            BorrowedDate = null;
        }
    }
}
