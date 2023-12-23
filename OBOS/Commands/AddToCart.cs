using OBOS.Models.Store;
using OBOS.Models.Users;
using OBOS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBOS.Commands
{
    public class AddToCart : CommandBase
    {
        private readonly BookViewModel viewModel;

        Shop shop;
        
        public AddToCart(BookViewModel viewModel)
        {
            this.viewModel = viewModel;
            shop = Shop.GetInstance();
        }

        public override void Execute(object parameter)
        {

            if (viewModel.Bookmark)
            {
                viewModel.Book = new BookMark(viewModel.Book);
            } 
            if (viewModel.Gift)
            {
                viewModel.Book = new BookWrap(viewModel.Book);
            }
            if (viewModel.Special)
            {
                viewModel.Book = new SpecialBook(viewModel.Book);
            }
             
            ((Customer)shop.CurrentUser).Cart.Add(new CartItem(viewModel.Book,viewModel.Count));
        }


    }
}
