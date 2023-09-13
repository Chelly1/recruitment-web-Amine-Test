using LibraryApp.Entities;

using System.Xml.Linq;
using System.Xml.Schema;

namespace LibraryApp.Entities
  {

  /// <summary>
  /// A member is a person who can borrow and return books to a <seealso cref="Library"/>
  /// A member can be either a student or a resident
  /// </summary>
  public abstract class Member
	{

	/// <summary>
	/// Attribute region
	/// define attribute 
	/// </summary>
	#region attribute 

	public Guid Id { get; }

	// the last book borrow

	public Book BorrowBook
	  {
	  get;
	  set;
	  }
	public int NumberOfDays
	  {
	  get;
	  set;
	  }
	public int NumberDaysKeeping
	  {
	  get;
	  set;
	  }
	public double Wallet
	  {
	  get;
	  set;
	  }

	#endregion


	// Constructor
	/// <summary>
	/// define Constructeur region
	/// 
	/// </summary>
	#region constructor

	public Member() { }


	public Member(double _wallet, int _numberOfDays, Book _borrowBook, int _numberDaysKeeping)
	 {
	   this.Wallet = _wallet;
	   this.NumberOfDays = _numberOfDays;
	   this.BorrowBook = _borrowBook;
	   this.NumberDaysKeeping = _numberDaysKeeping;
	  }

	public Member(double _wallet, int _numberDaysKeeping)
	  {
	  this.Wallet = _wallet;
	  this.NumberDaysKeeping = _numberDaysKeeping;
	  }

	public Member(double _wallet)
	  {
	  this.Wallet = _wallet;
	  }


	#endregion

	/// <summary>
	/// Function region
	/// Define function
	/// </summary>
	#region function

	/// <summary>
	/// The member should pay their books when they are returned to the library
	/// </summary>
	/// <param name="numberOfDays"> the number of days they kept the book </param>
	public abstract void payBook(int numberOfDays);

	/// <summary>
	/// cost of borrowing book
	/// </summary>
	/// <param name="numberOfDays"></param>
	/// <returns></returns>
	public abstract Double CostBorrowBook(int numberOfDays);

	#endregion

	}
  }

