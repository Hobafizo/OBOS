using OBOS.Commands;
using OBOS.Models.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OBOS.ViewModels
{
    public class BookViewModel : ViewModelBase
    {
        private Book _book;
        public Book Book
        {
            get { return _book; }
            set
            {
                _book = value;
                OnPropertyChanged(nameof(Book));
            }
        }

        public BookViewModel(Book book)
        {
            Book = book;
            AddToCart = new AddToCart(this);
        }

        private bool _Special = false;
        public bool Special
        {
            get { return _Special; }
            set { _Special = value; OnPropertyChanged(nameof(Special)); }
        }

        private bool _Bookmark = false;
        public bool Bookmark
        {
            get { return _Bookmark; }
            set { _Bookmark = value; OnPropertyChanged(nameof(Bookmark)); }
        }

        private bool _gift = false;
        public bool Gift
        {
            get { return _gift; }
            set { _gift = value; OnPropertyChanged(nameof(Gift)); }
        }

        public int Count { get; set; }

        public ICommand AddToCart { get; }
    }
}
