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
	public class AdminViewModel : ViewModelBase
	{
		private readonly NavigationStore _adminNavigationStore;
		public ViewModelBase CurrentViewModel => _adminNavigationStore.CurrentViewModel;

        private string _username;

        public string UserName
		{
			get { return _username; }
			set
			{
				_username = value;
				OnPropertyChanged(nameof(UserName));
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

        public ICommand ToLogin { get; }
		public ICommand ToHistory { get; }
		public ICommand ToCart { get; }
		public ICommand ToHome { get; }
		public ICommand SearchCommand { get; }

		public AdminViewModel(NavigationStore navigationStore, string username)
		{
			_adminNavigationStore = new NavigationStore();
			_adminNavigationStore.CurrentViewModel = new HomeViewModel(_adminNavigationStore);
			_adminNavigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

            Categories = Shop.GetInstance().Categories;
            Books = Shop.GetInstance().Books;

            _categoryindex = 0;
            _bookindex = 0;

            _categoryname = Categories.Count > 0 ? Categories[0].Name : "<null>";
            _bookname = Books.Count > 0 ? Books[0].Name : "<null>";

            ToLogin = new ToLogin(navigationStore);
			ToHistory = new ToHistory(_adminNavigationStore);
			ToCart = new ToCart(_adminNavigationStore);
			SearchCommand = new SearchCommand(_adminNavigationStore);
			ToHome = new ToHome(_adminNavigationStore);

			UserName = username;
		}

		private void OnCurrentViewModelChanged()
		{
			OnPropertyChanged(nameof(CurrentViewModel));
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
            BookName = Books.Count != 0 ? Books[_bookindex].Name : "<null>";
        }

        public void AddCategory(string name)
        {
            if (((Admin)Shop.GetInstance().CurrentUser).AddCategory(CategoryName))
            {

            }
        }

        public void DeleteCategory()
        {
            if (((Admin)Shop.GetInstance().CurrentUser).DeleteCategory(CategoryName))
                IncreaseCategoryIndex(-1);
        }
    }
}
