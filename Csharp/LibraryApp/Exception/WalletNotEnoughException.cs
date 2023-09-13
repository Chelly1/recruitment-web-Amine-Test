using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Exception
  {
  internal class WalletNotEnoughException : IOException
	{


	public WalletNotEnoughException(string message): base(message)
	  {  }

	}
  }
