using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
    class Library
    {
        private List<Book> books;

        public Library()
        {
            books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public void RemoveBook(string isbn)
        {
            Book bookToRemove = books.Find(b => b.ISBN == isbn);
            if (bookToRemove != null)
            {
                books.Remove(bookToRemove);
            }
        }

        public void LendBook(string isbn, Reader reader)
        {
            Book bookToLend = books.Find(b => b.ISBN == isbn);
            if (bookToLend != null && bookToLend.IsAvailable)
            {
                bookToLend.IsAvailable = false;
                reader.BorrowedBooks.Add(bookToLend);
                Console.WriteLine($"{reader.Name} has borrowed '{bookToLend.Title}'.");
            }
            else
            {
                Console.WriteLine("Book not available for lending.");
            }
        }

        public void ReturnBook(string isbn, Reader reader)
        {
            Book bookToReturn = reader.BorrowedBooks.Find(b => b.ISBN == isbn);
            if (bookToReturn != null)
            {
                bookToReturn.IsAvailable = true;
                reader.BorrowedBooks.Remove(bookToReturn);
                Console.WriteLine($"{reader.Name} has returned '{bookToReturn.Title}'.");
            }
            else
            {
                Console.WriteLine("Book not found in reader's borrowed books.");
            }
        }

        public void DisplayBooks()
        {
            Console.WriteLine("Library Books:");
            foreach (var book in books)
            {
                string availability = book.IsAvailable ? "Available" : "Not Available";
                Console.WriteLine($"{book.Title} by {book.Author} (ISBN: {book.ISBN}) - {availability}");
            }
        }
    }
}
