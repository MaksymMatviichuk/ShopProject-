using LibrarySystem.Models;

class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();

        Book book1 = new Book("Book 1", "Author 1", "12345");
        Book book2 = new Book("Book 2", "Author 2", "67890");
        Book book3 = new Book("Book 3", "Author 3", "54321");

        library.AddBook(book1);
        library.AddBook(book2);
        library.AddBook(book3);

        Reader reader1 = new Reader("Reader 1");
        Reader reader2 = new Reader("Reader 2");

        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("\nLibrary Menu:");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Remove Book");
            Console.WriteLine("3. Lend Book");
            Console.WriteLine("4. Return Book");
            Console.WriteLine("5. Display Books");
            Console.WriteLine("6. Exit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter book title: ");
                    string title = Console.ReadLine();
                    Console.Write("Enter author: ");
                    string author = Console.ReadLine();
                    Console.Write("Enter ISBN: ");
                    string isbn = Console.ReadLine();
                    Book newBook = new Book(title, author, isbn);
                    library.AddBook(newBook);
                    Console.WriteLine($"{newBook.Title} has been added to the library.");
                    break;

                case "2":
                    Console.Write("Enter ISBN of the book to remove: ");
                    string isbnToRemove = Console.ReadLine();
                    library.RemoveBook(isbnToRemove);
                    Console.WriteLine($"Book with ISBN {isbnToRemove} has been removed from the library.");
                    break;

                case "3":
                    Console.Write("Enter ISBN of the book to lend: ");
                    string isbnToLend = Console.ReadLine();
                    Console.Write("Enter reader's name: ");
                    string readerName = Console.ReadLine();
                    Reader lendingReader = new Reader(readerName);
                    library.LendBook(isbnToLend, lendingReader);
                    break;

                case "4":
                    Console.Write("Enter ISBN of the book to return: ");
                    string isbnToReturn = Console.ReadLine();
                    Console.Write("Enter reader's name: ");
                    string returningReaderName = Console.ReadLine();
                    Reader returningReader = new Reader(returningReaderName);
                    library.ReturnBook(isbnToReturn, returningReader);
                    break;

                case "5":
                    library.DisplayBooks();
                    break;

                case "6":
                    isRunning = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
        }
    }
}