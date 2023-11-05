using IntroSE.Kanban.Backend.DataAccessLayer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.DataAccessLayer.DTO
{
    public  class UserDTO:DTOs
    {

        public const string UserEmail = "Email";
        public const string UsersPassword = "Password";

        private string email;
        private string password;
        private bool status;

        /// <summary>
        /// get & set 
        /// </summary>
        public string Email {
            get { return email; } 
            set { email = value; }
        }
        public string Password {
            get { return password; } 
            set { password = value; }
        }
        public bool Status { 
            get { return status;}
            set { status = value;}
        }
        //constructor
        public UserDTO(string email, string password):base (new DALusercontroller() )
        {
           this.email = email;
            this.password = password;
        }

        private static int boolToInt(bool a)
        {
            if (a) return 1;
            return 0;
        }

        public void Save()
        {
            Email = email;
            Password = password;
        }
    }
}
