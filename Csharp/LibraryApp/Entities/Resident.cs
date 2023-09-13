

using LibraryApp.Exception;
using LibraryApp.library;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LibraryApp.Entities
  {
  public class Resident : Member
	{

	public Resident(double wallet) : base(wallet)
	  { }

	public override double CostBorrowBook(int numberOfDays)
	  {
	  double costOfBorrow;
	  if (numberOfDays < LibraryCost.getDaysBeforeLateResident())
		{
		costOfBorrow = numberOfDays * LibraryCost.getDaysBeforeLateStudent();
		}
	  else
		{
		costOfBorrow = numberOfDays * LibraryCost.getResidentPriceAfterLate()
									+ LibraryCost.getMembrePriceBeforeLate()
									* (numberOfDays - LibraryCost.getDaysBeforeLateResident());

		}
	  return costOfBorrow;

	  }


	public override void payBook(int numberOfDays)
	  {
	  double cost = 0;
	  cost = CostBorrowBook(numberOfDays);
	  if (cost < 0)
		{
		throw new CostBorrowException("negative" + cost);
		}
	  if (cost > this.Wallet)
		{
		throw new WalletNotEnoughException("wallet enough" + cost);
		}
	  this.Wallet = (float)-cost;

	  }


	}
  }
