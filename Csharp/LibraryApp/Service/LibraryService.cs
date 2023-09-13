using com.proxym.libraryapp.book;
using com.proxym.libraryapp.Exceptions;

using LibraryApp.Entities;
using LibraryApp.Exception;
using LibraryApp.IRepositories;
using LibraryApp.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace LibraryApp.service
  {
  public class LibraryService : ILibrary
	{
	  BookRepository bookRepository;

	public LibraryService(BookRepository _bookRepository)
	  {
	  this.bookRepository = _bookRepository;
	  }


	public Book borrowBook(long isbnCode, Member member)
	{
		Book book = new Book();
		if (member != null && member.BorrowBook != null)
		  {
		  book = bookRepository.findBook(isbnCode);
		  if (book == null)
			{
			throw new BookNotFoundException("isbn not found", isbnCode);
			}
		  //exceed  borrowed date 
		  if (Math.Abs(DateTime.Now.Day - book.BorrowedAt.Day) >= member.NumberDaysKeeping)
			{
			throw new HasLateBooksException("BOOK IS LATE RETURNED", DateTime.Now);
			}
		  member.BorrowBook = book;
		  bookRepository.save(book);

		  }
		return book;
		}


	  public void returnBook(Book book, Member member)
	  {
	  if (book != null)
		{
		DateOnly borrowedBookDate = bookRepository.findBorrowedBookDate(book);
		if (borrowedBookDate.ToString() != null)
		  {
		  int keepingDays = (int)(DateOnly.FromDateTime(DateTime.Now).DayNumber - (book.BorrowedAt.DayNumber));
		  member.payBook(keepingDays);

		  }
		}
	  }


	
	}
  }
