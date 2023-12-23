using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using OBOS.Stores;
using OBOS.Commands;
using OBOS.Models.Users;
using OBOS.Models.Store;

namespace OBOS.ViewModels
{
    public class MainAdminViewModel : ViewModelBase
    {
        private const int CategoryMaxChars = 32;

        private string _newcategory;

        public string NewCategory
        {
            get { return _newcategory; }
            set
            {
                _newcategory = value;
                OnPropertyChanged(nameof(NewCategory));
            }
        }

        private int _categoryindex, _bookindex;
        private string _categoryname, _bookname;

        public List<Category> Categories { get; }
        public List<Book> Books { get; }

        public string CategoryName
        {
            get
            {
                return _categoryname;
            }
            set
            {
                _categoryname = value;
                OnPropertyChanged(nameof(CategoryName));
            }
        }

        public string BookName
        {
            get
            {
                return _bookname;
            }
            set
            {
                _bookname = value;
                OnPropertyChanged(nameof(BookName));
            }
        }

        private bool _bookinstock, _bookoutofstock;

        public BookStatus BookStatus { get; set; }

        public bool BookInStock
        {
            get
            {
                return _bookinstock;
            }
            set
            {
                _bookinstock = value;
                if (value)
                    BookStatus = BookStatus.Available;
                OnPropertyChanged(nameof(BookInStock));
            }
        }

        public bool BookOutOfStock
        {
            get
            {
                return _bookoutofstock;
            }
            set
            {
                _bookoutofstock = value;
                if (value)
                    BookStatus = BookStatus.OutOfStock;
                OnPropertyChanged(nameof(BookOutOfStock));
            }
        }

        public ICommand ToNewBook { get; }

        public MainAdminViewModel(NavigationStore navigationStore)
        {
            ToNewBook = new ToNewBook(navigationStore);

            Categories = Shop.GetInstance().Categories;
            Books = Shop.GetInstance().Books;

            _categoryindex = 0;
            _bookindex = 0;
            _categoryname = Categories.Count > 0 ? Categories[0].Name : "<null>";
            _bookname = Books.Count > 0 ? Books[0].Name : "<null>";

            BookStatus = Books.Count > 0 ? Books[0].Status : BookStatus.OutOfStock;
            BookInStock = BookStatus == BookStatus.Available;
            BookOutOfStock = BookStatus == BookStatus.OutOfStock;
        }

        public void IncreaseCategoryIndex(int idx)
        {
            int newidx = _categoryindex + idx;

            if (newidx < 0)
                newidx = 0;
            else if (newidx >= Categories.Count)
                newidx = Categories.Count - 1;

            _categoryindex = newidx;
            CategoryName = Categories.Count != 0 ? Categories[_categoryindex].Name : "<null>";
        }

        public void IncreaseBookIndex(int idx)
        {
            int newidx = _bookindex + idx;

            if (newidx < 0)
                newidx = 0;
            else if (newidx >= Books.Count)
                newidx = Books.Count - 1;

            _bookindex = newidx;

            if (Books.Count != 0)
            {
                BookName = Books[_bookindex].Name;
                BookStatus = Books[_bookindex].Status;
            }
            else
            {
                BookName = "<null>";
                BookStatus = BookStatus.OutOfStock;
            }

            BookInStock = BookStatus == BookStatus.Available;
            BookOutOfStock = BookStatus == BookStatus.OutOfStock;
        }

        public void AddCategory()
        {
            if (!string.IsNullOrEmpty(NewCategory))
                ((Admin)Shop.GetInstance().CurrentUser).AddCategory(NewCategory.Length <= CategoryMaxChars ? NewCategory : NewCategory.Substring(0, CategoryMaxChars));
        }

        public void DeleteCategory()
        {
            if (((Admin)Shop.GetInstance().CurrentUser).DeleteCategory(CategoryName))
                IncreaseCategoryIndex(-1);
        }

        public void UpdateBookStatus()
        {
            ((Admin)Shop.GetInstance().CurrentUser).UpdateBookStatus(BookName, BookStatus);
        }
    }
}
