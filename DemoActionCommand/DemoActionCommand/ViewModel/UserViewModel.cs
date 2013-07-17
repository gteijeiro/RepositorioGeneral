using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DemoActionCommand.ViewModel
{
    public class UserViewModel :  NotificationEnabledObject
    {
        ObservableCollection<User> userList;
        User user;

        public User GetUser
        {
            get
            {
                if (user == null)
                {
                    user = new User();
                }
                if (DesignerProperties.IsInDesignTool)
                {
                    user = new User { FirstName = "Guillermo", LastName = "Teijeiro" };
                }
                return user;
            }
            set
            {
                user = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<User> UserList
        {
            get
            {
                if (userList == null)
                {
                    userList = new ObservableCollection<User>();
                }

                if (DesignerProperties.IsInDesignTool)
                {
                    userList.Add(new User { FirstName = "Guillermo", LastName = "Teijeiro" });
                    userList.Add(new User { FirstName = "Juan", LastName = "Lopez" });
                    userList.Add(new User { FirstName = "Lorena", LastName = "Ramirez"});
                    userList.Add(new User { FirstName = "Luciana", LastName = "Lopez" });
                }
                return userList;
            }
            set
            {
                userList = value;
                OnPropertyChanged();
            }
        }

        private ActionCommand getUserList { get; set; }
        private ActionCommand<User> addUserToList { get; set; }
        ServiceModel serviceModel = new ServiceModel();
        public UserViewModel()
        {
            UserList = serviceModel.GetUsers();
        }

        public ActionCommand GetUserList
        {
            get
            {
                if (getUserList == null)
                {
                    getUserList = new ActionCommand(() =>
                    {
                        serviceModel.GetUsers();
                    });
                }
                return getUserList;
            }
        }

        public ActionCommand<User> AddUserToList
        {
            get
            {
                if (addUserToList == null)
                {
                    addUserToList = new ActionCommand<User>(AddUser);
                }
                return addUserToList;
            }
        }

        public void AddUser(User pUser)
        {
            userList.Add(pUser);
        }
    }
}
