using Microsoft.CSharp.RuntimeBinder;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace LibraryApp.Exception
  {
  public class CostBorrowException : RuntimeBinderException
	{

	public CostBorrowException(string message) : base(message) { }

	}
  }
