using System;
using System.Collections.Generic;
using Task1;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the LibraryService class
            LibraryService libraryService = new LibraryService();

            // Add a book and a user to the library
            libraryService.AddBook("The Great Gatsby");
            libraryService.AddUser("West","Alice", 123, "AWest@test.pl");

            // Check out a book
            libraryService.CheckoutBook("Alice", "The Great Gatsby");

            // Get a list of rentals
            List<Rental> rentals = libraryService.GetRentals();

            // Print the list of rentals
            foreach (Rental rental in rentals)
            {
                Console.WriteLine($"User: {rental.User.GetName()}, Book: {rental.Book.Name}");
            }

            // Return the book
            libraryService.ReturnBook("Alice", "The Great Gatsby");
        }
    }
}