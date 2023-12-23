using OBOS.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBOS.ViewModels
{
    public class NotificationViewModel : ViewModelBase
    {
        public Notification notification;


        public NotificationViewModel(Notification notification)
        {
            this.notification = notification;
        }

    }
}
