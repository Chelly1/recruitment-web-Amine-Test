using com.proxym.libraryapp.book;
using com.proxym.libraryapp.Exceptions;

using LibraryApp.Entities;
using LibraryApp.Exception;
using LibraryApp.IRepositories;
using LibraryApp.Repositories;
using LibraryApp.service;

using Moq;

using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

using Xunit;

namespace TestProjectBook
  {
  public class UnitTestLibraryApp
	{
	public ILibrary library;
	private readonly BookRepository bookRepository;
	public static List<Book> books = new();
	public UnitTestLibraryApp()
	  {
	  bookRepository = new BookRepository();
	  //books = GetBooks(); 
	  }


	// bon
	[Fact]
	public void member_can_borrow_a_book_if_book_is_available()
	  {

	  BookRepository bookRepository = new BookRepository();

	  var bookRepositoryMock = new Mock<IbookRepository>();
	  Book book = new Book();
	  book.Isbn = new Isbn(12L);
	  book.BorrowedAt = new DateOnly(2000, 1, 1);

	  var bk = new List<Book>();
	  bk.Add(book);



	  bookRepository.saveAll(bk);
	  long num = 12345;
	  var libraryService = new LibraryService(bookRepository);


	  //Given
	  bookRepositoryMock.Setup(x => x.findBook(12l)).Returns(book);
	  Student student = new Student(700);
	  student.NumberDaysKeeping = 20;

	  student.BorrowBook = book;
	  //WHEN
	  Book bookResult = libraryService.borrowBook(12L, student);
	  //THEN
	  Assert.NotNull(bookResult);

	  }

	//bon
	[Fact]
	public void member_can_not_borrow_a_book_if_book_is_not_available()
	  {

	  BookRepository bookRepository = new BookRepository();
	  var bookRepositoryMock = new Mock<IbookRepository>();
	  Book book = new Book();
	  book.Isbn = new Isbn(13L);
	  book.BorrowedAt = new DateOnly(2000, 1, 1);

	  var bk = new List<Book>();
	  bk.Add(book);
	  // bookRepository.saveAll(bk);
	  long num = 12345;
	  var libraryService = new LibraryService(bookRepository);

	  //Given
	  bookRepositoryMock.Setup(x => x.findBook(num)).Returns(book);
	  Student student = new Student(700);
	  student.NumberDaysKeeping = 20;

	  student.BorrowBook = book;
	  //WHEN

	  //  //WHEN // THEN 
	  Assert.Throws<BookNotFoundException>(() =>
	  libraryService.borrowBook(46578964513L, student));
	  }




	[Fact]
	public void borrowed_book_is_no_longer_available()
	  {
	  Book book = new Book();

	  book.Isbn = new Isbn(46578964513L);
	  var bk = new List<Book>();
	  bk.Add(book);

	  // GIVEN
	  BookRepository bookRepository = new BookRepository();
	  var bookRepositoryMock = new Mock<IbookRepository>();
	  bookRepository.saveAll(bk);

	  Member student = new Student(700);
	  student.BorrowBook = book;
	  student.NumberDaysKeeping = 30;
	  var libraryService = new LibraryService(bookRepository);
	  bookRepositoryMock.Setup(x => x.findBook(46578964513L)).Returns(book);
	  DateOnly BorrowedAt = DateOnly.FromDateTime(DateTime.Now).AddDays(-30);
	  // WHEN
	  Book bookResult = libraryService.borrowBook(46578964513L, student);

	  // THEN
	  Assert.NotNull(bookResult);

	  }


	[Fact]
	public void students_pay_10_cents_the_first_30days()
	  {
	  int numberDaysKeeping = 30;
	  Double pris = 0;
	  var bookpositoryMock = new Mock<IbookRepository>();

	  //          firtYear,wallet,numberDaysKeeping)
	  Student student = new Student(true, 400, 20);
	  var studentMock = new Mock<Student>();

	  studentMock.Setup(x => x.CostBorrowBook(30)).Returns(pris);


	  
	 }

	//[Fact]
	//public void students_in_1st_year_are_not_taxed_for_the_first_15days()
	//  {
	//  Assert.True(false, "Implement me.");
	//  }
	//[Fact]
	//public void residents_pay_20cents_for_each_day_they_keep_a_book_after_the_initial_60days()
	//  {
	//  Assert.True(false, "Implement me.");
	//  }

	[Fact]
	public void members_cannot_borrow_book_if_they_have_late_books()
	  {
	  //Given
	  Student student = new Student(false, 10, 30);
	  Book book = new Book();
	  book.BorrowedAt = DateOnly.FromDateTime(DateTime.Now).AddDays(30);
	  var bookRepositoryMock = new Mock<IbookRepository>();

	  bookRepositoryMock.Setup(x => x.findBook(46578964513L)).Returns(book);
	  var libraryService = new LibraryService(bookRepository);

	  //WHEN // THEN 
	  Assert.Throws<HasLateBooksException>(() =>
	   libraryService.borrowBook(46578964513L, student)
	  );
	  }


	}

  }

//public List<Book> GetBooks() => new List<Book>
//    {
//       new Book("Harry Potter","J.K. Rowling",  new Isbn(46578964513)),
//        new Book("Around the world in 80 days", "Jules Verne", new Isbn(3326456467846)),
//    new Book("Catch 22", "Joseph Heller", new Isbn(968787565445)),
//        new Book("La peau de chagrin", "Balzac", new Isbn(465789453149))
//    };

