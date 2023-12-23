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
    public class NewBookViewModel : ViewModelBase
    {
        public ICommand ToMainAdmin { get; }

        private string _bookname, _authorname, _simplestringproperty;
        private float _price;
        private int _stock;

        public string BookName
        {
            get => _bookname;
            set
            {
                _bookname = value;
                OnPropertyChanged(nameof(BookName));
            }
        }

        public string AuthorName
        {
            get => _authorname;
            set
            {
                _authorname = value;
                OnPropertyChanged(nameof(AuthorName));
            }
        }

        public float Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        public int Stock
        {
            get => _stock;
            set
            {
                _stock = value;
                OnPropertyChanged(nameof(Stock));
            }
        }

        public List<Category> Categories { get; }
        public List<string> CategoryNames
        {
            get
            {
                return Categories.Select(x => x.Name).ToList();
            }
        }

        public string SimpleStringProperty
        {
            get => _simplestringproperty;
            set
            {
                _simplestringproperty = value;
                OnPropertyChanged(nameof(SimpleStringProperty));
            }
        }

        public NewBookViewModel(NavigationStore navigationStore)
        {
            ToMainAdmin = new ToMainAdmin(navigationStore);

            Categories = Shop.GetInstance().Categories;
        }

        public void AddBook(string cat)
        {
            if (!string.IsNullOrEmpty(cat))
            {
                Book book = new SimpleBook
                {
                    Name = _bookname,
                    Author = _authorname,
                    Price = _price,
                    Stock = _stock,
                    CategoryNames = new List<string>() { cat }
                };

                ((Admin)Shop.GetInstance().CurrentUser).AddBook(book);
            }
        }
    }
}
