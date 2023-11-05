
using IntroSE.Kanban.Backend.BusinessLayer.User;

using IntroSE.Kanban.Backend.DataAccessLayer.DTO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.DataAccessLayer.DAL
{
    public abstract class DALcontroller
    {
        protected readonly string connection;
        private readonly string table;
        protected static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public DALcontroller (string table)
        {
            //string path = "C:\\Users\\ASUS\\OneDrive\\שולחן העבודה\\kanban1\\2022-2023-2023-2024-30\\Backend\\kanban3.db";
            string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "kanban.db"));
            this.connection = $"Data Source={path}; Version=3";
            this.table = table;
        }

        public DALboardcontroller getboardcontroller()
        {
            return new DALboardcontroller();
        }
        public DALusercontroller getusercontroller()
        {
            return new DALusercontroller();
        }
        public DALcolumncontroller getcolumncontroller()
        {
            return new DALcolumncontroller();
        }
        public DALtaskcontroller gettaskcontroller()
        {
            return new DALtaskcontroller() ;
        }

        /// <summary>
		/// converts SQLiteReader to the corresponding DTO object so we can handle it and deal with it!
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		protected abstract DTOs ConvertReaderToObject(SQLiteDataReader reader);


        /// <summary>
		/// Reads data from a wanted table
		/// </summary>
		/// <returns></returns>
		protected List<DTOs> Select()
        {
            List<DTOs> results = new List<DTOs>();
            using (var connections = new SQLiteConnection(connection))
            {
                SQLiteCommand command = new SQLiteCommand(null, connections);
                command.CommandText = $"select * from {table};";
                SQLiteDataReader dataReader = null;
                try
                {
                    connections.Open();
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
            return results;
        }
        /// <summary>
		/// deletes all data in a wanted table
		/// </summary>
		/// <returns></returns>
		public bool DeleteData()
        {
            using (var connections = new SQLiteConnection(connection))
            {
                SQLiteCommand command = new SQLiteCommand(null, connections);
                int res = -1;
                try
                {
                    command.CommandText = $"DELETE  FROM {table}";
                    command.Prepare();
                    connections.Open();
                    res = command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    log.Error("error connecting to the dataBase");
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
