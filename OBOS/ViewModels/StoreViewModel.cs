using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBOS.ViewModels
{
    public class StoreViewModel : ViewModelBase
    {
        private string _search;

        public string Search 
        { 
            get 
            { 
                return _search;
            } 
            set
            {
                _search = value;
                OnPropertyChanged(nameof(Search));
            } 
        }
    }
}
