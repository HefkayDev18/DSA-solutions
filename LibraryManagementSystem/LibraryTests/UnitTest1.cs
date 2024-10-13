//namespace LibraryTests;
using LibraryManagementSystem;
using NUnit.Framework;
using System;

namespace LibraryTests
{
    [TestFixture]
    public class LibrarySlnTests
    {
        private Library library;

        [SetUp]
        public void Setup()
        {
            library = new Library();

            library.AddBook("The Gang of 4");
            library.AddBook("Creational design patterns");
            library.AddBook("Structural design patterns");
            library.AddBook("Behavioral design patterns");
            library.AddMagazine("Forbes under 30");
            library.AddMagazine("Architectural patterns - UnitOfWork & repository");
            library.AddDVD("Data structures in C#, Python and Java");
        }

        [Test]
        public void Test_BorrowBook_Successful()
        {
            library.BorrowItem("The Gang of 4", "Farouk");
            Assert.IsTrue(library.FindItem("The Gang of 4").IsBorrowed, "The book should be marked as borrowed.");
        }

        [Test]
        public void Test_BorrowNonExistentItem_Fails()
        {
            var ex = Assert.Throws<NullReferenceException>(() => library.BorrowItem("Non-Existent Book", "Jane Doe"));
            Assert.That(ex.Message, Is.EqualTo("Object reference not set to an instance of an object."));
        }

        [Test]
        public void Test_ReturnBookOnTime_NoLateFee()
        {
            library.BorrowItem("The Gang of 4", "John Doe");
            library.ReturnItem("The Gang of 4");

            var item = library.FindItem("The Gang of 4");
            Assert.IsFalse(item.IsOverdue(), "The book should not be overdue.");
            Assert.AreEqual(0, item.CalculatePenalty(), "There should be no late fee.");
        }

        [Test]
        public void Test_ReturnBookLate_CalculatesLateFee()
        {
            //Arrange
            library.BorrowItem("Creational design patterns", "Jane Doe");

            var item = library.FindItem("Creational design patterns");
            //Simulating an overdue return
            //var BorrowedDate = DateTime.Now.AddDays(-16);
            //item.SetBorrowedDate(BorrowedDate);

            //DateTime TodayDate = new DateTime(2024, 10, 12);

            item.SetBorrowedDate(DateTime.Now.AddDays(-16));

            Console.WriteLine($"Borrowed Date: {item.BorrowedDate}");
            Console.WriteLine($"BorrowingLimitDays: {item.BorrowingLimitDays}");
            Console.WriteLine($"Expected Due Date: {item.GetDueDate()?.ToShortDateString()}");
            //Act
            library.ReturnItem("Creational design patterns");

            Console.WriteLine($"IsOverdue: {item.IsOverdue()}");
            Console.WriteLine($"Late Fee: {item.CalculatePenalty()}");

            //Assert
            Assert.IsTrue(item.IsOverdue(), "The book should be overdue.");
            Assert.AreEqual(1.00, item.CalculatePenalty(), "The late fee should be $1.00 (2 days at $0.50/day).");
        }

        [Test]
        public void Test_ReservationSystem_NotifiesNextPatron()
        {
            library.BorrowItem("Data structures in C#, Python and Java", "Patron 1");
            library.BorrowItem("Data structures in C#, Python and Java", "Patron 2");

            library.ReturnItem("Data structures in C#, Python and Java");

            var item = library.FindItem("Data structures in C#, Python and Java");
            Assert.IsFalse(item.IsBorrowed, "The DVD should be returned.");
            Assert.That(item.ReservationQueue.Count, Is.EqualTo(0), "The reservation queue should be empty after the item is returned.");
        }

        [Test]
        public void Test_AvailabilityCheck()
        {
            library.BorrowItem("The Gang of 4", "Farouk");
            library.BorrowItem("Creational design patterns", "Alice");

            library.CheckAvailability();

            //Assert.AreEqual(97, library.GetAvailableBooks(), "There should be 97 books available.");
            //Assert.AreEqual(50, library.GetAvailableMagazines(), "There should be 50 magazines available.");
            //Assert.AreEqual(30, library.GetAvailableDVDs(), "There should be 30 DVDs available.");
        }

        private LibraryItem FindItemByTitle(string title)
        {
            return library.FindItem(title);
        }
    }
}


