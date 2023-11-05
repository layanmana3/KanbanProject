
using log4net;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text.RegularExpressions;
using IntroSE.Kanban.Backend.BussinessLayer.Board;
using IntroSE.Kanban.Backend.DataAccessLayer.DTO;
using IntroSE.Kanban.Backend.DataAccessLayer.DAL;

namespace IntroSE.Kanban.Backend.BusinessLayer.User

{
    /// <summary>
    /// UserController class - manage all the users of the kanban board
    /// </summary>
    public class UserController
    {
        
        public Dictionary<string, user> users;
        private int counter;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly DALusercontroller daluser;
        public BoardController boardController;
        public UserController()
        {
            users = new Dictionary<string, user>();
            boardController = new BoardController();
            counter = 0;
            daluser = new DALusercontroller();
            //LoadData();
        }
        
        internal void Register(string email, string password)
        {
            //List<user> list = new List<user>();
            //foreach (UserDTO user in daluser.allusers())
            //{
            //    user userrr = new user(user.Email, user.Password, counter);
            //    if (!users.ContainsKey(user.Email)),,
            //    {
            //        users.Add(user.Email, userrr);
            //        counter++;
            //    }
            //}
            //LoadData();
            if (email is null)
            {
                log.Warn("User with null email attempted register");
                throw new Exception("Email is null");
            }
            if (users.ContainsKey(email))
            {
                log.Warn("attemp to register with exsisting email");
                throw new Exception($"Email {email} already exists");
            }
            if (!checkThePassword(password))
            {
                log.Warn("attemp to register with exsisting email");
                throw new Exception($"password {password} isn't ");
            }
            user newUser = new user(email, password, counter);
            users.Add(email, newUser);
            //Console.WriteLine("users size in use controller");
            //Console.WriteLine(users.Count);
            users[email].login(password);
            //Console.WriteLine("users size in use controller");
            //Console.WriteLine(users.Count);
            boardController.User_Board.Add(email, new List<Board>());
            

            counter = counter + 1;
            daluser.Insert(newUser.UserToDal());
            log.Info("new user is registered");
        }

        public bool isLoggedin_user(string email) {
            return users[email].IsLoggedIn();
        }

        public bool IsRegestered(string email)
        {

            return users.ContainsKey(email);
        }


        internal string Login(string email, string password)
        {
            //List<user> list = new List<user>();
            //foreach (UserDTO user in daluser.allusers())
            //{
            //    user userrr = new user(user.Email, user.Password, counter);
            //    if (!users.ContainsKey(user.Email))
            //    {
            //        users.Add(user.Email, userrr);
            //        counter++;
            //    }
            //}
            //LoadData();
            if (email is null || password is null)
            {
                log.Warn("Attempted to login with a null email address");
                throw new Exception("Email cannot be null");
            }
            //if (!ValidateEmail(email))
            //{
            //    log.Warn("Invalid email");
            //    throw new InvalidOperationException("user email is Invalid");
            //}
            // Check if the user is registered.
            if (!IsRegestered(email))
            {
                log.Warn("Attempted to login with an unregistered email address");
                throw new Exception("This email is not registered");
            }
            if (users[email].IsLoggedIn())
            {
                log.Warn($"Login attempt for user '{email}' who is already logged in.");
                throw new InvalidOperationException($"User '{email}' is already logged in.");
            }
            if (!checkThePassword(password))
            {
                log.Warn("invalid password");
                throw new InvalidOperationException("user password is invalid");
            }
            users[email].login(password);
            boardController.User_status[email] = true;
            
            //foreach(BoardDTO board in daluser.getboardcontroller().GetAllBoards())
            //{
            //    boardController.User_Board[email].Add(new Board(board.BOARDEMAIL, board.BOARDNAME, board.BOARDID, board.BOARDEMAIL));
            //}
            //List<Board> boards = boardController.User_Board[email];
            //Dictionary<string, bool> usersStatus = boardController.getUserStatus();
            //usersStatus[email] = true;
            log.Info($"User '{email}' logged in successfully");
            return email;
        }
        internal void Logout(string email)
        {
            //LoadData();
            if (email is null)
            {
                throw new Exception("Email is null");
            }
            if (!users.ContainsKey(email))
            {
                Console.WriteLine("no user");
                log.Warn("Attempted to logout a non existing user.");
                throw new ArgumentException("User doesn't exist");
            }
            if (!users[email].IsLoggedIn())
            {
                log.Warn("Attempted to logout a user that is already logged out.");
                throw new InvalidOperationException("User is already logged out.");
            }
            users[email].logout();
            boardController.User_status[email] = true;
            //users.Remove(email);
            //Dictionary<string, bool> usersStatus = boardController.getUserStatus();
            //usersStatus[email] = false;
            log.Info("User logged out successfully");
        }
        private bool checkThePassword(string password)
        {

            bool HasUpperCase = false;
            bool HasLowerCase = false;
            bool HasNumber = false;
            if (password.Length < 6 || password.Length > 20)
            {
                log.Warn("Attempted to register using a password of invalid length");
                throw new Exception("Passwords must be between 6 and 20 characters");
            }
            foreach (char c in password)
            {
                if (char.IsDigit(c) && !HasNumber)
                {
                    HasNumber = true;
                }
                else if (char.IsUpper(c) && !HasUpperCase)
                {
                    HasUpperCase = true;
                }
                else if (char.IsLower(c) && !HasLowerCase)
                {
                    HasLowerCase = true;
                }
            }
            if (!HasNumber)
            {
                log.Warn("attempt to register using password that doesn't contain a number");
                throw new Exception("password must contain a number!");
            }
            if (!HasUpperCase)
            {
                log.Warn("Attempted to register using a password that doesn't contain an uppercase letter");
                throw new Exception("Password must contain at least one uppercase letter");
            }
            if (!HasLowerCase)
            {
                log.Warn("Attempted to register using a password that doesn't contain a lowercase letter");
                throw new Exception("Password must contain at least one lowercase letter");
            }
            return true;
        }
        /// <summary>
        /// This function loads the data needed for the User Service.
        /// <param> It has no Parametrs</param>
        /// </summary>
        /// <returns></returns>
        public void LoadData()
        {
            List<UserDTO> GETALLUSERS = daluser.allusers();
            foreach (UserDTO userdto in GETALLUSERS)
            {
                if(!users.ContainsKey(userdto.Email))
                users.Add(userdto.Email, new user(userdto));
            }
        }

        /// <summary>
        /// This function delete all the data.
        /// <param> It has no Parametrs</param>
        /// </summary>
        /// <returns></returns>
        public void DeleteData()
        {
            daluser.DeleteData();
        }

        /*public void add_board(string email,string name )
        {
            if (isLoggedin_user())
            {
                this.users.Add()
            }
            log.Warn("the user have to be logged in ");
            throw new Exception("the user have to be logged in ");
        }*/

    }
}
