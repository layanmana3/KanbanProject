using Frontend.Model;
using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace Frontend.ViewModel
{
    class MainViewModel : NotifiableObject
    {
        public BackendController Controller { get; private set; }
        private string username;
        private string password;
        private string message;

        public MainViewModel()
        {
            this.Controller = new BackendController();
            this.username = "";
            this.password = "";
            this.message = "";
          
        }
        public string Username
        {
            get => username;
            set
            {
                this.username = value;
                RaisePropertyChanged("Username");
            }
        }
        public string Password
        {
            get => password;
            set
            {
                this.password = value;
                RaisePropertyChanged("Password");
            }
        }
       
        public string Message
        {
            get => message;
            set
            {
                this.message = value;
                RaisePropertyChanged("Message");
            }
        }
        public UserModel Login()
        {
            Message = "";
            try
            {
                return Controller.Login(Username, Password);
            }
            catch (Exception e)
            {
                Message = e.Message;
                return null;
            }
        }
        public UserModel Register()
        {
            Message = "";
            try
            {
               return Controller.Register(Username, Password);
                
            }
            catch (Exception e)
            {
                Message = e.Message;
                return null;
            }
        }

       
    }
}
