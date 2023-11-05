using IntroSE.Kanban.Backend.DataAccessLayer.DTO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.DataAccessLayer.DAL
{
    public class DALusercontroller : DALcontroller
    {
        private const string UserTable = "Users";
        public DALusercontroller() : base(UserTable) { }

        protected override DTOs ConvertReaderToObject(SQLiteDataReader reader)
        {
            string username = reader.GetString(0);
            string password = reader.GetString(1);
            bool isAdmin = false;

            UserDTO result = new UserDTO(username, password);
            return result;
        }




        public List<UserDTO> allusers()
        {
           return Select().Cast<UserDTO>().ToList();
        }

        public bool intTobool(int status)
        {
            if (status != 1) return false;
            return true;
        }

        /// <summary>
		/// an a sql query to add a user to the users table
		/// </summary>
		/// <param name="user"> user dto to add its fields to the users table</param>
		/// <returns></returns>
		public bool Insert(UserDTO user)
        {
            using (var connections = new SQLiteConnection(connection))
            {
                SQLiteCommand command = new SQLiteCommand(null, connections);
                int res = -1;
                try
                {
                    connections.Open();
                    command.CommandText = $"INSERT INTO {UserTable}({UserDTO.UserEmail},{UserDTO.UsersPassword})"
                        + $"VALUES(@email,@password)";

                    SQLiteParameter Pram1 = new SQLiteParameter(@"email", user.Email);
                    SQLiteParameter Pram2 = new SQLiteParameter(@"password", user.Password);
                    command.Parameters.Add(Pram1);
                    command.Parameters.Add(Pram2);

                    command.Prepare();
                    res = command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    log.Error("Error inserting to dataBase");
                    log.Debug(e.Message);
                }
                finally
                {
                    command.Dispose();
                    connections.Close();
                }
                if (res > -1) return true;
                return false;
            }
        }

        /// <summary>
		/// an a sql query to delete all data from the users table
		/// </summary>
		/// <returns></returns>
		public bool Delete()
        {
            using (var connections = new SQLiteConnection(connection))
            {
                SQLiteCommand command = new SQLiteCommand(null, connections);
                int res = -1;
                try
                {
                    connections.Open();
                    command.CommandText = $"DELETE FROM {UserTable}";

                    command.Prepare();
                    res = command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    log.Error("Error deleting from dataBase");
                    log.Debug(e.Message);
                }
                finally
                {
                    command.Dispose();
                    connections.Close();
                }
                if (res > -1) return true;
                return false;
            }

        }


    }



}
