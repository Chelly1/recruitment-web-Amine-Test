using LibraryApp.Entities;
using LibraryApp.Exception;
using LibraryApp.IRepositories;

namespace com.proxym.libraryapp.book
{

    /// <summary>
    /// The book repository emulates a database via 2 HashMaps
    /// </summary>
    public class BookRepository : IbookRepository
	{

	private Dictionary<Isbn, Book> availableBooks = new Dictionary<Isbn, Book>();
	private Dictionary<Book, DateOnly> borrowedBooks = new Dictionary<Book, DateOnly>();

	public virtual void saveAll(IList<Book> books)
	  {
		 if (books != null)
		 {
		  foreach (Book book in books)
		  {
		  availableBooks.Add(book.Isbn, book);
		  }
		}
	  }


	public Book findBook(long isbnCode)
	  {
	  foreach (var b in availableBooks)
		{
		if (b.Value != null && b.Value.Isbn.IsbnCode == isbnCode)
		  {
		  return b.Value;
		  }
		}
	  throw new BookNotFoundException("Book non trouvé", isbnCode);
	  }


	public void save(Book book)
	  {
	  if (book != null)
		{
		borrowedBooks.Add(book, DateOnly.FromDateTime(DateTime.Now));
		availableBooks.Remove(book.Isbn);


		}

	  }


	public DateOnly findBorrowedBookDate(Book book)
	  {

	  foreach (var b in borrowedBooks)
		{
		if (b.Value.Equals(book))
		  {
		  return b.Value;
		  }
		}
	  return DateOnly.MinValue;
	  }

	}
  }
