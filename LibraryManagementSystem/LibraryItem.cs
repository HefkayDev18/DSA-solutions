using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class LibraryItem(string title, int borrowingLimitDays, double penaltyFeePerDay)
    {
        public string Title { get; private set; } = title;
        //Might have used a key or ID instead, maybe string(first 2 letters of item type + random number or guid)
        public int BorrowingLimitDays { get; private set; } = borrowingLimitDays;

        //public bool IsBorrowed { get; private set; } = false;
        public bool IsBorrowed => BorrowedDate != null;
        public DateTime? BorrowedDate { get; private set; }

        //FOR TESTS
        public void SetBorrowedDate(DateTime date)
        {
            BorrowedDate = date;
        }
        public double PenaltyFeePerDay { get; private set; } = penaltyFeePerDay;
        public Queue<string> ReservationQueue { get; private set; } = new();

        public DateTime? GetDueDate()
        {
            return BorrowedDate?.AddDays(BorrowingLimitDays);
        }

        public double CalculatePenalty()
        {
            if (!IsOverdue()) return 0;

            int OverdueDays = (DateTime.Now - GetDueDate().Value).Days;
            return OverdueDays * PenaltyFeePerDay;
        }

        public bool IsOverdue()
        {
            //if (BorrowedDate == null) return false;
            if (BorrowedDate == null)
            {
                Console.WriteLine("BorrowedDate is null.");
                return false;
            }

            DateTime dueDate = BorrowedDate.Value.AddDays(BorrowingLimitDays);
            //DateTime TodayDate = new DateTime(2024, 10, 12);

            Console.WriteLine($"BorrowedDate: {BorrowedDate.Value.ToShortDateString()}");
            Console.WriteLine($"DueDate: {dueDate.ToShortDateString()}");
            Console.WriteLine($"TodayDate: {DateTime.Now.ToShortDateString()}");

            return DateTime.Now > dueDate;
        }

        public void BorrowItem(string patronName)
        {
            if (!IsBorrowed)
            {
                BorrowedDate = DateTime.Now;
                Console.WriteLine($"{patronName} borrowed '{Title}'. Due for return on {GetDueDate().Value.ToShortDateString()}.");
            }
            else
            {
                Console.WriteLine($"'{Title}' is already borrowed. Adding {patronName} to the reservation queue.");
                ReservationQueue.Enqueue(patronName);
            }
        }

        public void ReturnItem()
        {
            //BorrowedDate = null;

            if (IsOverdue())
            {
                double fee = CalculatePenalty();
                Console.WriteLine($"'{Title}' returned. Late return attracts penalty fee: ${fee:F2}");
            }
            else
            {
                Console.WriteLine($"'{Title}' returned on time.");
            }

            BorrowedDate = null;

            if (ReservationQueue.Count > 0)
            {
                string nextPatron = ReservationQueue.Dequeue();
                Console.WriteLine($"{nextPatron} is next to borrow '{Title}'");
            }
        }
    }
}
