using System;

namespace Library
{
    public class Book
    {
        private readonly int bookId;
        private readonly string title;
        private readonly string author;
        private int term;

        public Book(int bookId, string title, string author, int term)
        {
            this.bookId = bookId;
            this.title = title;
            this.author = author;
            this.term = term;
        }

        public int GetId()
        {
            return bookId;
        }

        public string GetTitle()
        {
            return title;
        }

        public string GetAuthor()
        {
            return author;
        }

        public int GetTerm()
        {
            return term;
        }

        public void SetTerm(int newTerm)
        {
            if (newTerm <= 0)
            {
                throw new ArgumentException("Term cannot be zero or negative.");
            }
            term = newTerm;
        }
    }
}