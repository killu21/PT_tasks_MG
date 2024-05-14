// using Library.Data;
//
// namespace LibraryTests.DataTests;
//
// [TestFixture]
// public class CatalogTests
// {
//     private Catalog _catalog;
//     private Book _book1;
//     private Book _book2;
//     private const bool Available = true;
//     // private const bool NotAvailable = false;
//
//     [SetUp]
//     public void SetUp()
//     {
//         Book.SetNextBookId(1);
//         _book1 = new Book("Title1", "Author1", Available);
//         _book2 = new Book("Title2", "Author2", Available);
//         var initialBooks = new Dictionary<int, IDataInterfaces.IBook>
//         {
//             { _book1.GetId(), _book1 },
//             { _book2.GetId(), _book2 }
//         };
//         _catalog = new Catalog(initialBooks);
//     }
//
//     [Test]
//     public void AddBook_WithValidBook_ShouldAddBookToCatalogProperly()
//     {
//         // Arrange
//         var book3 = new Book("Title3", "Author3", Available);
//         const int expectedIdCount = 3;
//
//         // Act
//         _catalog.AddBook(book3);
//         Assert.Multiple(() =>
//         {
//             // Assert
//             Assert.That(book3.GetId(), Is.EqualTo(expectedIdCount));
//             Assert.That(_catalog.GetBooks(), Does.Contain(book3));
//         });
//     }
//
//     [Test]
//     public void RemoveBook_WithValidBook_ShouldRemoveBookFromCatalog()
//     {
//         // Act
//         _catalog.RemoveBook(_book1);
//
//         // Assert
//         Assert.That(_catalog.GetBooks(), Does.Not.Contain(_book1));
//     }
//
//     [Test]
//     public void GetBooks_ShouldReturnAllBooksInCatalog()
//     {
//         // Act
//         var books = _catalog.GetBooks();
//
//         // Assert
//         Assert.That(books, Does.Contain(_book1));
//         Assert.That(books, Does.Contain(_book2));
//     }
// }