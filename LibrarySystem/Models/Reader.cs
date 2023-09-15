using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
    class Reader
    {
        public string Name { get; private set; }
        public List<Book> BorrowedBooks { get; private set; }

        public Reader(string name)
        {
            Name = name;
            BorrowedBooks = new List<Book>();
        }
    }
}
