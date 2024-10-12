namespace LibraryManagementSystem
{
    public class Solution
    {
        public static void Main(string[] args)
        {
            ArgumentNullException.ThrowIfNull(args);

            Library hefkayLibrary = new();

            hefkayLibrary.AddBook("The Gang of 4");
            hefkayLibrary.AddBook("Creational design patterns");
            hefkayLibrary.AddBook("Structural design patterns");
            hefkayLibrary.AddBook("Behavioral design patterns");
            hefkayLibrary.AddMagazine("Forbes under 30");
            hefkayLibrary.AddMagazine("Architectural patterns - UnitOfWork & repository");
            hefkayLibrary.AddDVD("Data structures in c#, python and java");

            hefkayLibrary.BorrowItem("The Gang of 4");
            hefkayLibrary.BorrowItem("Data structures in c#, python and java");

            hefkayLibrary.ListBorrowedItem();

            hefkayLibrary.ReturnItem("The Gang of 4");

            hefkayLibrary.CheckAvailability();

            Console.WriteLine($"Is the library full? {hefkayLibrary.IsLibraryFull()}");
            Console.WriteLine($"Is the library empty? {hefkayLibrary.IsLibraryEmpty()}");


        }
    }
}