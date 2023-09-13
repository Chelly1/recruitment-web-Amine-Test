using LibraryApp.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.IRepositories
  {
  public interface IbookRepository
	{

	void saveAll(IList<Book> books);

	Book findBook(long isbnCode);

	void save(Book book);

	}

  }



