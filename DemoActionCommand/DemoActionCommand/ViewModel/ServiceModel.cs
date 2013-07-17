using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoActionCommand.ViewModel
{
    public class ServiceModel
    {
        public ObservableCollection<User> GetUsers()
        {
            ObservableCollection<User> userList = new ObservableCollection<User>();
            userList.Add(new User { FirstName = "Guillermo", LastName = "Teijeiro" });
            userList.Add(new User { FirstName = "Juan", LastName = "Lopez" });
            userList.Add(new User { FirstName = "Lorena", LastName = "Ramirez" });
            userList.Add(new User { FirstName = "Luciana", LastName = "Lopez" });
            return userList;
        }

    }
}
