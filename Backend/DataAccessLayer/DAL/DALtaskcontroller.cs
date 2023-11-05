using IntroSE.Kanban.Backend.DataAccessLayer.DTO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.DataAccessLayer.DAL
{
    public  class DALtaskcontroller : DALcontroller 
    {
        private const string TaskTable = "Tasks";
        public DALtaskcontroller() : 
            base(TaskTable) { }


        protected override DTOs ConvertReaderToObject(SQLiteDataReader reader)
        {
            int taskID;
            if (reader.IsDBNull(2))
            {
                taskID = 0;
            }
            else
            {
                taskID = int.Parse(reader.GetValue(2).ToString()); //.GetInt32(0);
            }

            DateTime createTime;
            if (reader.IsDBNull(7))
            {
                createTime = DateTime.MinValue;
            }
            else
            {
                createTime = DateTime.Parse(reader.GetString(7));
            }

            DateTime dueDate;
            if (reader.IsDBNull(6))
            {
                dueDate = DateTime.MinValue;
            }
            else
            {
                dueDate = DateTime.Parse(reader.GetValue(6).ToString());
            }

            string title;
            if (reader.IsDBNull(4))
            {
                title = string.Empty;
            }
            else
            {
                title = reader.GetValue(4).ToString();
            }

            string description;
            if (reader.IsDBNull(5))
            {
                description = string.Empty;
            }
            else
            {
                description = reader.GetValue(5).ToString();
            }

            string email;
            if (reader.IsDBNull(3))
            {
                email = string.Empty;
            }
            else
            {
                email = reader.GetValue(3).ToString();
            }

            int boardId;
            if (reader.IsDBNull(0))
            {
                boardId = 0;
            }
            else
            {
                boardId = int.Parse(reader.GetValue(0).ToString());
            }

            int ordinal;
            if (reader.IsDBNull(1))
            {
                ordinal = 0;
            }
            else
            {
                ordinal = int.Parse(reader.GetValue(1).ToString());
            }

            TaskDTO result = new TaskDTO(taskID, createTime, dueDate, title, description, email, boardId, ordinal);
            return result;
        }



        /// <summary>
		/// an a sql query to delete board's tasks from tasks table
		/// </summary>
		/// <param name="boardID"> boardId to specify the row</param>
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
                    command.CommandText = $"DELETE FROM {TaskTable} WHERE BoardID = @id";

                    SQLiteParameter Pram1 = new SQLiteParameter(@"id", boardID);
                    command.Parameters.Add(Pram1);

                    command.Prepare();
                    res = command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    log.Error("Error deleting to dataBase");
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
            /// an a sql query to delete all tasks table data
            /// </summary>
            /// <returns></returns>
            public bool DeleteAll()
            {
                using (var connections = new SQLiteConnection(connection))
                {
                    SQLiteCommand command = new SQLiteCommand(null, connections);
                    int res = -1;
                    try
                    {
                        connections.Open();
                        command.CommandText = $"DELETE FROM {TaskTable}";

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
		/// an a sql query to add a task in the tasks table
		/// </summary>
		/// <param name="tsk"> task dto to add its feilds to the tasks table</param>
		/// <returns></returns>
		public bool Insert(TaskDTO task)
        {
            using (var connections = new SQLiteConnection(connection))
            {
                SQLiteCommand command = new SQLiteCommand(null, connections);
                int res = -1;
                try
                {
                    connections.Open();
                    command.CommandText = $"INSERT INTO {TaskTable}({TaskDTO.Task_BoardId}, {TaskDTO.Task_BoardOrdinal} ,{TaskDTO.Task_ID}, {TaskDTO.Task_Email}, {TaskDTO.Task_ColumnTitle},{TaskDTO.Task_ColumnDescreption},{TaskDTO.Task_ColumnDueDate},{TaskDTO.Tasks_ColumnCreationTime})"
                        + $"VALUES(@brdid ,@Ordinal, @tskid, @email , @title, @descreption , @duedate, @creationtime)";
                    SQLiteParameter Param1 = new SQLiteParameter(@"brdid", task.BoardID);
                    SQLiteParameter Param2 = new SQLiteParameter(@"Ordinal", task.ORDINAL);
                    SQLiteParameter Param3 = new SQLiteParameter(@"tskid", task.taskID);
                    SQLiteParameter Param4 = new SQLiteParameter(@"email", task.Assignee);
                    SQLiteParameter Param5 = new SQLiteParameter(@"title",task.TITLE);
                    SQLiteParameter Param6 = new SQLiteParameter(@"descreption", task.desciptions);
                    SQLiteParameter Param7 = new SQLiteParameter(@"duedate", task.DUEDATE);
                    SQLiteParameter Param8 = new SQLiteParameter(@"creationtime", task.CreationTime);
                    command.Parameters.Add(Param1);
                    command.Parameters.Add(Param2);
                    command.Parameters.Add(Param3);
                    command.Parameters.Add(Param4);
                    command.Parameters.Add(Param5);
                    command.Parameters.Add(Param6);
                    command.Parameters.Add(Param7);
                    command.Parameters.Add(Param8);
                    command.Prepare();
                    res = command.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    log.Error("error occured while updating the database");
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
        public List<TaskDTO> GetAlltasks()
        {
            return Select().Cast<TaskDTO>().ToList();
        }
        /// <summary>
        /// an a sql query to get all column's tasks to load the data
        /// </summary>
        /// <param name="brdid"> task's boardid</param>
        /// <param name="ord"> column ordinal</param>
        /// <returns></returns>
        public List<TaskDTO> SelectcolsTasks(int boardid, int ordinal)
        {
            List<DTOs> results = new List<DTOs>();
            using (var connections = new SQLiteConnection(connection))
            {
                SQLiteCommand command = new SQLiteCommand(null, connections);
                command.CommandText = $"select * from {TaskTable} WHERE BoardID = @boardid and Ordinal = @ordinal;";
                SQLiteDataReader dataReader = null;
                try
                {
                    connections.Open();
                    SQLiteParameter Pram1 = new SQLiteParameter(@"boardid", boardid);
                    SQLiteParameter Pram2 = new SQLiteParameter(@"ordinal", ordinal);
                    command.Parameters.Add(Pram1);
                    command.Parameters.Add(Pram2);
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
            List<TaskDTO> res2 = results.Cast<TaskDTO>().ToList();
            return res2;
        }


        public bool Update(int id, int brdid, string attributeName, string attributeValue)
        {

            using (var connections = new SQLiteConnection(connection))
            {
                SQLiteCommand command = new SQLiteCommand(null, connections);
                int res = -1;
                try
                {
                    connections.Open();
                    command.CommandText = $"UPDATE {TaskTable} SET [{attributeName}] = @attributevalue WHERE TaskID = @ID AND BoardID = @brdId";
                    SQLiteParameter attrib = new SQLiteParameter(@"attributevalue", attributeValue);
                    SQLiteParameter idPar = new SQLiteParameter(@"ID", id);
                    SQLiteParameter brdPar = new SQLiteParameter(@"brdId", brdid);
                    command.Parameters.Add(idPar);
                    command.Parameters.Add(brdPar);
                    command.Parameters.Add(attrib);
                    command.Prepare();
                    res = command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
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



















    }
}
