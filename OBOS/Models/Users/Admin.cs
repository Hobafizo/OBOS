using OBOS.Models.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBOS.Models.Users
{
	public class Admin : User
	{
		// <<<< Attributes here >>>>

		public bool AddCategory(string name)
		{
			return false;
		}

		public bool DeleteCategory(string name)
		{
			return false;
		}

		public void AddBook(Book book)
		{

		}

		public void UpdateBookStatus(Book book, BookStatus status)
		{

		}
	}
}
