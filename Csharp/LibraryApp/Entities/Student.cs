
using LibraryApp.Exception;
using LibraryApp.library;


using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Entities
  {
  public class Student : Member
	{
	
	public Boolean FirstYear
	 {
	  get;
	  set;
	 }
	
	public Student(Boolean firtYear, float _wallet, int numberDaysKeeping) : base(_wallet)
	 {
	  this.FirstYear = firtYear;
	  this.NumberDaysKeeping = LibraryCost.getDaysBeforeLateStudent();
	 }

	public Student(double _wallet) : base(_wallet) { }

	public Student( ):base(){ }
	  

	public override double CostBorrowBook(int numberOfDays)
	 {
	   double costOfBorrowBook;
	  if (numberOfDays <= LibraryCost.getDaysBeforeLateStudent())
		{
		costOfBorrowBook = numberOfDays * LibraryCost.getStudentPriceAfterLate();
		}
	  else
		{
		costOfBorrowBook = LibraryCost.getDaysBeforeLateStudent()
		  + LibraryCost.getMembrePriceBeforeLate()
		  * (numberOfDays - LibraryCost.getStudentPriceAfterLate());
		}
	  return costOfBorrowBook;
	  
	  }

	public override void payBook(int numberOfDays)
	{
	  double cost = 0;
	  if (this.FirstYear)
	  numberOfDays = LibraryCost.getFirstYearFree();
	  cost = CostBorrowBook(numberOfDays);
	  if (cost < 0)
		{ 
		throw new CostBorrowException("cost negative" + cost);
		}
	  if (cost > this.Wallet)
		{
		throw new WalletNotEnoughException("Insufficient wallet balance: " + this.Wallet + ", cost: " + cost);
		}

	  this.Wallet= -  (float) - cost;

	  }
	}
  }
