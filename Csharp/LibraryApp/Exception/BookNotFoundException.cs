using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Exception
  {
	 [Serializable]
	 public class BookNotFoundException : IOException
	 {

		private long _isbn =0;
		private long Isbn
		{
		  get => _isbn;
		  set => Isbn = value;
	  }
		public BookNotFoundException(string mssg , long isbn) : base(String.Format("book not found", isbn)) { }

	}
	}
	
