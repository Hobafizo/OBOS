using OBOS.Models.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBOS.ViewModels
{
    public class CartItemViewModel : ViewModelBase
    {
        readonly CartItem cartItem;

        public CartItemViewModel(CartItem cartItem)
        {
            this.cartItem = cartItem;

            Name = cartItem.Book.Name;
            Quantity = cartItem.Quantity;
            Total = cartItem.Total();
        }

        private string _name;
        public string Name
        {
            get => _name;

            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private int _quantity;
        public int Quantity
        {
            get => _quantity;

            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }

        private float _total;
        public float Total
        {
            get => _total;

            set
            {
                _total = value;
                OnPropertyChanged(nameof(Total));
            }
        }

    }
}
