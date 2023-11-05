using System;
using System.Data.SQLite;
using System.IO;
using System.Collections.Generic;
using IntroSE.Kanban.Backend.DataAccessLayer.DTO;
using System.Linq;



namespace IntroSE.Kanban.Backend.DataAccessLayer.DAL
{
    public class DALcolumncontroller : DALcontroller
    {
        private const string ColumnTable = "Columns";
        public DALcolumncontroller() : base(ColumnTable) { }

        protected override DTOs ConvertReaderToObject(SQLiteDataReader reader)
        {
            int id;
            if (reader.IsDBNull(0))
            {
                id = 0;
            }
            else
            {
                id = reader.GetInt32(0);
            }

            int intValue;
            if (reader.IsDBNull(1))
            {
                intValue = 0;
            }
            else
            {
                intValue = reader.GetInt32(1);
            }

            string stringValue = reader.GetString(2);

            int anotherIntValue;
            if (reader.IsDBNull(3))
            {
                anotherIntValue = 0;
            }
            else
            {
                anotherIntValue = reader.GetInt32(3);
            }

            ColumnDTO result = new ColumnDTO(id, intValue, stringValue, anotherIntValue);
            return result;
        }

        public List<ColumnDTO> allcolumns()
        {
            return Select().Cast<ColumnDTO>().ToList();
        }



        //code from practice 6 
        public int GetTaskLimit(int boardID, int ColumnOrdinal)
        {
            int limit = 0;
            using (var connections = new SQLiteConnection(connection))
            {
                SQLiteCommand command = new SQLiteCommand(null, connections);
                command.CommandText = $"select * from {ColumnTable} WHERE BOARDID = @brdid and COLUMNORDINAL = @ord;";
                SQLiteDataReader dataReader = null;
                try
                {
                    connections.Open();
                    SQLiteParameter Pram1 = new SQLiteParameter(@"brdid", boardID);
                    SQLiteParameter Pram2 = new SQLiteParameter(@"ord", ColumnOrdinal);
                    command.Parameters.Add(Pram1);
                    command.Parameters.Add(Pram2);
                    command.Prepare();


                    dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        try
                        {
                            limit = int.Parse(dataReader.GetValue(3).ToString()); 
                        }
                        catch (Exception e)
                        {
                            limit = -1;
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
            return limit;
        }



        /// <summary>
        /// an a sql query to add a row to columns table
        /// </summary>
        /// <param name="column"> column dto to add its fields to the table</param>
        /// <returns></returns>
        public bool Insert(ColumnDTO column)
        {
            using (var connections = new SQLiteConnection(connection))
            {
                SQLiteCommand command = new SQLiteCommand(null, connections);
                int res = -1;
                try
                {
                    connections.Open();
                    command.CommandText = $"INSERT INTO {ColumnTable}({ColumnDTO.Column_BoardId},{ColumnDTO.Column_Ordinal},{ColumnDTO.Column_Name},{ColumnDTO.Column_TaskLimit})"
                        + $"VALUES(@id,@Ordinal,@Colname,@limit)";

                    SQLiteParameter Pram1 = new SQLiteParameter(@"id", column.BOARDID);
                    SQLiteParameter Pram2 = new SQLiteParameter(@"Ordinal", column.COLUMNORDINAL);
                    SQLiteParameter Pram3 = new SQLiteParameter(@"Colname", column.COLUMNNAME);
                    SQLiteParameter Pram4 = new SQLiteParameter(@"limit", column.COLUMNTASKLIMIT);
                    command.Parameters.Add(Pram1);
                    command.Parameters.Add(Pram2);
                    command.Parameters.Add(Pram3);
                    command.Parameters.Add(Pram4);
                    command.Prepare();
                    res = command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    log.Error("Error inserting to dataBase");
                    log.Debug(e.Message);
                }
                finally
                {
                    command.Dispose();
                    connections.Close();
                }
                if( res > -1) return true; else return false;
            }


        }

        public bool delete (int boardid)
        {
            using (var connections = new SQLiteConnection(connection))
            {
                SQLiteCommand command = new SQLiteCommand(null, connections);
                int res = -1;
                try
                {
                    connections.Open();
                    command.CommandText = $"DELETE FROM {ColumnTable} WHERE BoardID = @id";

                    SQLiteParameter Pram1 = new SQLiteParameter(@"id",boardid);
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
                if (res > -1) return true; else return false;
            }

        }

        public bool DeleteAll()
        {
            using (var connections = new SQLiteConnection(connection))
            {
                SQLiteCommand command = new SQLiteCommand(null, connections);
                int res = -1;
                try
                {
                    connections.Open();
                    command.CommandText = $"DELETE FROM {ColumnTable}";

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
                else return false;
            }
        }

        public bool update (int id, int boardID, string attributeName, string attributeValue)
        {
            using (var connections = new SQLiteConnection(connection))
            {
                SQLiteCommand command = new SQLiteCommand(null, connections);
                int res = -1;
                try
                {
                    connections.Open();
                    command.CommandText = $"UPDATE {ColumnTable} SET [{attributeName}] = @attributevalue WHERE TaskID = @id AND BoardID = @boardID";
                    SQLiteParameter attrib = new SQLiteParameter(@"attributevalue", attributeValue);
                    SQLiteParameter idPar = new SQLiteParameter(@"ID", id);
                    SQLiteParameter brdPar = new SQLiteParameter(@"boardID", boardID);
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
                if (res > -1) return true; else return false;
            }
        }

     

    }


   

}
