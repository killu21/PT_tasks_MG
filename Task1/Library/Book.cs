using System;

namespace Library
{
    public class Book
    {
        private readonly int _bookId;
        private readonly string _title;
        private readonly string _author;
        private int _term;

        public Book(int bookId, string title, string author, int term)
        {
            this._bookId = bookId;
            this._title = title;
            this._author = author;
            this._term = term;
        }

        public int GetId()
        {
            return _bookId;
        }

        public string GetTitle()
        {
            return _title;
        }

        public string GetAuthor()
        {
            return _author;
        }

        public int GetTerm()
        {
            return _term;
        }

        public void SetTerm(int newTerm)
        {
            if (newTerm <= 0)
            {
                throw new ArgumentException("Term cannot be zero or negative.");
            }
            _term = newTerm;
        }
    }
}