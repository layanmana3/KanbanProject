using IntroSE.Kanban.Backend.BussinessLayer.Board;
using IntroSE.Kanban.Backend.DataAccessLayer.DTO;
using log4net;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace IntroSE.Kanban.Backend.BusinessLayer.User
{
    /// <summary>
    /// User class - make new users to use Kanban board
    /// </summary>
    public class user
    {
        private string email;
        private string password;
        private int Id;
        private bool LoggedIn;
        private Dictionary<string, int> board_and_id; 
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public user(string email, string password, int id)
        {
            this.email = email;
            this.password = password;
            Id = id;
            LoggedIn = true;
        }
        public user(UserDTO user)
        {

            email = user.Email;
            password = user.Password;
        }
        
        public UserDTO UserToDal()
        {
            return new UserDTO(email, password);
        }

        public string GetEmail() { return email; }
        public string GetPassword() { return password; }
        public int GetId() { return Id; }
        public bool IsLoggedIn() { return LoggedIn; }
        public void login(string password)
        {
            if (password.Equals(this.password))
            {
                LoggedIn = true;
            }
            else
            {
            log.Warn("Attempted to login with an incorrect password.");
            throw new ArgumentException("Incorrect password.");
            }

        }
        public void logout()
        {
            this.LoggedIn = false;
        }

        public Dictionary<string,int> getboardlist()
        {
            return this.board_and_id;
        }

        public void add_board(string boardname,int id )
        {
            this.board_and_id.Add(boardname,id);
        }
    }
}
