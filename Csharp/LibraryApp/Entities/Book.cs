namespace LibraryApp.Entities
{
    /// <summary>
    /// A simple representation of a book
    /// </summary>
    public class Book
	{
	#region Attribute

	public Guid Id
	  {
	  get;
	  }

	public string Title
	  {
	  get;
	  set;
	  }

	public Isbn Isbn
	  {
	  get;
	  set;
	  }
	public DateOnly BorrowedAt
	  {
	  get;
	  set;
	  }

	#endregion

	#region constructor

	public Book(Isbn _isbn)
	  {
	  this.Isbn = _isbn;
	  }

	public Book() { }

	public Book(long _isbncode, DateOnly borrowedAt)
	  {

	  Isbn _isbn = new Isbn(_isbncode);
	  this.BorrowedAt = borrowedAt;
	  }

	public Book(string title)
	  { this.Title = title; }
	#endregion
	}

  }
