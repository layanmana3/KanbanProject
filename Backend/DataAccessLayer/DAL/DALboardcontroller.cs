using System;
using System.Data.SQLite;
using System.IO;
using System.Collections.Generic;
using IntroSE.Kanban.Backend.DataAccessLayer.DTO;
using System.Linq;



namespace IntroSE.Kanban.Backend.DataAccessLayer.DAL
{
    public class DALboardcontroller : DALcontroller
    {
        private const string BoardTable = "Boards";
        private const string join = "join";
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public DALboardcontroller() : base(BoardTable) { }

        protected override DTOs ConvertReaderToObject(SQLiteDataReader reader)
        {
            int id;
            if (reader.IsDBNull(0))
            {
                id = 0;
            }
            else
            {
                id = int.Parse(reader.GetValue(0).ToString());
            }

            int intValue;
            if (reader.IsDBNull(1))
            {
                intValue = 0;
            }
            else
            {
                intValue = int.Parse(reader.GetValue(3).ToString());
            }

            string stringValue1;
            if (reader.IsDBNull(1))
            {
                stringValue1 = string.Empty;
            }
            else
            {
                stringValue1 = (string)reader.GetValue(1);
            }

            string stringValue2;
            if (reader.IsDBNull(2))
            {
                stringValue2 = string.Empty;
            }
            else
            {
                stringValue2 = (string)reader.GetValue(2);
            }

            BoardDTO result = new BoardDTO(id, intValue, stringValue2,stringValue1);
            return result;
        }

        public List<BoardDTO> GetAllBoards()
        {
            return Select().Cast<BoardDTO>().ToList();
        }
        /// <summary>
        /// an a sql query to insert a new row to the joinees table
        /// </summary>
        /// <param name="email"> the user email</param>
        /// <param name="boardID"> the joined board id</param>>
        /// <returns></returns>
        public bool Insert(string email, int boardID)
        {
            using (var connections = new SQLiteConnection(connection))
            {
                SQLiteCommand command = new SQLiteCommand(null, connections);
                int res = -1;
                try
                {
                    connections.Open();
                    command.CommandText = $"INSERT INTO {join}(Email,BoardID)"
                        + $"VALUES(@email,@boardID)";

                    SQLiteParameter Pram1 = new SQLiteParameter(@"email", email);
                    SQLiteParameter Pram2 = new SQLiteParameter(@"boardID", boardID);
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
                return res > -1;
            }

        }

        /// <summary>
        /// an a sql query to insert a board to boards table
        /// </summary>
        /// <param name="board"> dto object to add its fields to the boards table</param>
        /// <returns></returns>
        public bool Insert(BoardDTO board)
        {
            using (var connections = new SQLiteConnection(connection))
            {
                SQLiteCommand command = new SQLiteCommand(null, connections);
                int res = -1;
                try
                {
                    connections.Open();
                    command.CommandText = $"INSERT INTO {BoardTable}({BoardDTO.BoardsID},{BoardDTO.BoardsEmail},{BoardDTO.BoardsName},{BoardDTO.BoardTaskCounter})"
                        + $"VALUES(@id,@email,@boardname,@taskidCounter)";

                    SQLiteParameter Pram1 = new SQLiteParameter(@"id", board.BOARDID);
                    SQLiteParameter Pram2 = new SQLiteParameter(@"email", board.BOARDEMAIL);
                    SQLiteParameter Pram3 = new SQLiteParameter(@"boardname", board.BOARDNAME);
                    SQLiteParameter Pram4 = new SQLiteParameter(@"taskidCounter", board.TASKCOUNTER);
                    command.Parameters.Add(Pram1);
                    command.Parameters.Add(Pram2);
                    command.Parameters.Add(Pram3);
                    command.Parameters.Add(Pram4);

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
                return res > -1;
            }


        }
        /// <summary>
		/// an a sql query to update in the board table
		/// </summary>
		/// <param name="brdId"> boardId to specify the row</param>
		/// <param name="attributeName"> column name in the table</param>
		/// <param name="brdId"> the new value to set</param>
		/// <returns></returns>
		public bool Update(int brdId, string attributeName, string attributeValue)
        {
            using (var connections = new SQLiteConnection(connection))
            {
                SQLiteCommand command = new SQLiteCommand(null, connections);
                int res = -1;
                try
                {
                    connections.Open();
                    command.CommandText = $"UPDATE {BoardTable} SET [{attributeName}]=@attributevalue WHERE BoardID=@brdId";
                    SQLiteParameter attribpram = new SQLiteParameter(@"attributevalue", attributeValue);
                    SQLiteParameter Pram1 = new SQLiteParameter(@"brdId", brdId);
                    command.Parameters.Add(attribpram);
                    command.Parameters.Add(Pram1);
                    command.Prepare();
                    res = command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    log.Error("Error in updating dataBase");
                    log.Debug(e.Message);
                }
                finally
                {
                    command.Dispose();
                    connections.Close();
                }
                return res > -1;
            }

        }



        /// <summary>
		/// an a sql query to delete the board where the boardid = @boardID
		/// </summary>
		/// <param name="boardID"> the board id wanted to be deleted</param>
		/// <returns></returns>
		public bool Delete(int boardID)
        {
            using (var connections = new SQLiteConnection(connection))
            {
                SQLiteCommand command = new SQLiteCommand(null, connections);
                int res = -1;
                try
                {
                    connections.Open();
                    command.CommandText = $"DELETE FROM {BoardTable} WHERE BoardID = @boardID";

                    SQLiteParameter Pram1 = new SQLiteParameter(@"boardID", boardID);
                    command.Parameters.Add(Pram1);

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
                return res > -1;
            }


        }
        /// <summary>
		/// an a sql query to delete boards table
		/// </summary>
		/// <returns></returns>
		public bool DeleteAllboards()
        {
            using (var connections = new SQLiteConnection(connection))
            {
                SQLiteCommand command = new SQLiteCommand(null, connections);
                int res = -1;
                try
                {
                    connections.Open();
                    command.CommandText = $"DELETE FROM {BoardTable}";

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
                return res > -1;
            }

        }

        /// <summary>
        /// an a sql query to delete the joinees table
        /// </summary>
        /// <returns></returns>
        public bool DeleteAlljoinees()
        {
            using (var connections = new SQLiteConnection(connection))
            {
                SQLiteCommand command = new SQLiteCommand(null, connections);
                int res = -1;
                try
                {
                    connections.Open();
                    command.CommandText = $"DELETE FROM {join}";

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
                return res > -1;
            }

        }

        public bool DeleteAll()
        {
            return DeleteAllboards() & DeleteAlljoinees();
        }
        /// <summary>
		/// an a sql query to remove joinee from the join table
		/// </summary>
		/// <param name="email"> the users email</param>
		/// <param name="boardID"> the boardID to delete its joinee</param>
		/// <returns></returns>
		public bool DeleteJoin(string email, int boardID)
        {
            using (var connections = new SQLiteConnection(connection))
            {
                SQLiteCommand command = new SQLiteCommand(null, connections);
                int res = -1;
                try
                {
                    connections.Open();
                    command.CommandText = $"DELETE FROM {join} WHERE BoardID = @id AND Email = @email";

                    SQLiteParameter Pram1 = new SQLiteParameter(@"id", boardID);
                    SQLiteParameter Pram2 = new SQLiteParameter(@"email", email);
                    command.Parameters.Add(Pram1);
                    command.Parameters.Add(Pram2);

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
                return res > -1;
            }
        }

        /// <summary>
		/// an a sql query to get User's boards.
		/// </summary>
		/// <param name="email"> the user email</param>
		/// <returns></returns>
		public List<BoardDTO> GetUsersBoardList(string email)
        {
            List<DTOs> results = new List<DTOs>();
            using (var connections = new SQLiteConnection(connection))
            {
                SQLiteCommand command = new SQLiteCommand(null, connections);
                command.CommandText = $"SELECT Boards.BoardID,Boards.Email,BoardName,TaskIDcounter from {BoardTable} join {join} on join.BoardID = Boards.BoardID and join.Email = @email";
                SQLiteDataReader dataReader = null;
                try
                {
                    connections.Open();
                    SQLiteParameter Param1 = new SQLiteParameter(@"email", email);
                    command.Parameters.Add(Param1);
                    command.Prepare();
                    dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        results.Add(ConvertReaderToObject(dataReader));
                    }
                }
                finally
                {
                    if (dataReader != null)
                    {
                        dataReader.Close();
                    }

                    command.Dispose();
                    connections.Close();
                }

            }
            return results.Cast<BoardDTO>().ToList();

        }
        /// <summary>
		/// an a sql query to get the BoardId Counter for the boardcontroller
		/// </summary>
		/// <returns></returns>
		public int GetBoardCounter()
        {
            int idcounter = 0;
            using (var connections = new SQLiteConnection(connection))
            {
                SQLiteCommand command = new SQLiteCommand(null, connections);
                command.CommandText = $"SELECT max(BoardID) FROM Boards";
                SQLiteDataReader dataReader = null;
                try
                {
                    connections.Open();

                    dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        try
                        {
                            idcounter = int.Parse(dataReader.GetValue(0).ToString()) + 1;
                        }
                        catch (Exception e)
                        {
                            idcounter = 0;
                        }

                    }
                }
                catch (Exception e)
                {
                    log.Debug(e.Message);
                    Console.WriteLine(e.Message);

                }

                finally
                {
                    if (dataReader != null)
                    {
                        dataReader.Close();
                    }

                    command.Dispose();
                    connections.Close();
                }

            }
            return idcounter;
        }
    }

}
