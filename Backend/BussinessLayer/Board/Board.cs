using IntroSE.Kanban.Backend.BusinessLayer.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntroSE.Kanban.Backend.DataAccessLayer.DAL;
using IntroSE.Kanban.Backend.DataAccessLayer.DTO;

namespace IntroSE.Kanban.Backend.BussinessLayer.Board
{
    public class Board
    {
        private string User_Email;
        private string Board_name;
        private int Board_id;
        // add list of users 
        public List<Column> columns_list;
        private int taskcount;
        private List<user> members_list;
        public string owner;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly DALcolumncontroller DAL_column = new DALcolumncontroller();
        private readonly DALtaskcontroller DAL_task = new DALtaskcontroller();

        public Board(string email, string boardn, int id, string owner)
        {
            this.Board_id = id;
            this.Board_name = boardn;
            this.User_Email = email;
            this.taskcount = 0;
            this.columns_list = new List<Column>();
            this.members_list = new List<user>();
            Column cul = new Column(0, boardn);
            cul.set_board_id(this.Board_id);
            this.columns_list.Add(cul);
            this.DAL_column.Insert(cul.todal());
            Column cul1 = new Column(1, boardn);
            cul1.set_board_id(this.Board_id);

            this.columns_list.Add(cul1);
            this.DAL_column.Insert(cul1.todal());
            Column cul2 = new Column(2, boardn);
            cul2.set_board_id(this.Board_id);

            this.columns_list.Add(cul2);
            this.DAL_column.Insert(cul2.todal());
            this.owner = owner;
        }

        public void Prepare()
        {
            foreach (Column col in this.columns_list)
            {
                col.Prepare();
            }
        }
        public Board(BoardDTO boarddal)
        {
            this.User_Email = boarddal.BOARDEMAIL;
            this.Board_id = boarddal.BOARDID;
            this.Board_name = boarddal.BOARDNAME;
            this.taskcount = boarddal.TASKCOUNTER;
            this.columns_list = new List<Column>();
            Column cul = new Column(0, this.Board_name);
            cul.set_board_id(this.Board_id);

            this.columns_list.Add(cul);
            cul = new Column(1, this.Board_name);
            cul.set_board_id(this.Board_id);

            this.columns_list.Add(cul);
            cul = new Column(2, this.Board_name);
            cul.set_board_id(this.Board_id);

            this.columns_list.Add(cul);
        }
        /// <summary>
        /// this function get the column from board 
        /// <summary>
        /// <baram name = "ord" > the column ordinary we want to retarn 0 1 2 </param>
        /// <returns> a the column in board </return > 

        public Column getCol(int Ordinal)
        {
            if (Ordinal == 0) return columns_list[0];
            if (Ordinal == 1) return columns_list[1];
            else return columns_list[2];
        }

        /// <summary>
        /// this function get the column name from board 
        /// <summary>
        /// <baram name = "ord" > the column name  we want to retarn 0 1 2 </param>
        /// <returns> a the column name  in board </return >

        /// <summary>
        /// this function return the user email that created the board
        /// </summary>
        /// <returns>the email of the user who created the board</returns>
        public string getemail()
        {
            return this.User_Email;
        }

        /// <summary>
        /// this function return the user board name  that created the board
        /// </summary>
        /// <returns>the board name of the user who created the board</returns>
        public string getboardname()
        {
            return this.Board_name;
        }
        public int getboardid()
        { return this.Board_id; }

        public string GetColumnName(int Ordinal)
        {
            return columns_list[Ordinal].GetColumnName();
        }

        /// <summary>
        /// this function return the user email that created the board
        /// </summary>

        /// <param name = "status " > the column name  we want to retarn the limit of </param>
        /// <returns>the email of the user who created the board</returns>
        public int getlimit(int Ordinal)

        {
            if (Ordinal == 0) return columns_list[0].getlim();
            if (Ordinal == 1) return columns_list[1].getlim();
            else return columns_list[2].getlim();
        }

        public void SetEmail(string email)
        {
            User_Email = email;
        }
        

        /// <summary>
        /// this function updait the limit of a status column
        /// /// </summary>

        /// <param name = "status " > the column name  we want to update  the limit of  "lim" the new limit </param>

        public void setlimit(int ordinal, int lim)
        {
            if (ordinal == 0)
            {
                Column c = columns_list[0];
                c.setlim(lim);
            }
            if (ordinal == 1)
            {
                Column c = columns_list[1];
                c.setlim(lim);
            }
            if (ordinal == 2)
            {
                Column c = columns_list[2];
                c.setlim(lim);
            }

        }
        /// <summary>
        /// this function update the limit of a all column
        /// /// </summary>
        /// <baram name =  "lim" the new limit </param>
        public void limit_all(int lim)
        {
            this.columns_list[0].setlim(lim);
            this.columns_list[1].setlim(lim);
            this.columns_list[2].setlim(lim);

        }
        /// <summary>
        /// return a task list of the in progress tasks 
        /// </summary>
        /// <returns>the list of tasks </returns>
        public List<Task> In_progressTasks()
        {
            return this.columns_list[1].List_Of_Tasks();
        }

        public BoardDTO ToDal()
        {
            return new BoardDTO(this.Board_id, this.taskcount, this.Board_name, this.User_Email);
        }

        public void deleteAllTasks(string email)
        {
            foreach (Column column in columns_list)
            {
                List<Task> allTasks = column.List_Of_Tasks();
                foreach (Task task in allTasks)
                {
                    if (task.GetAssignee().Equals(email)) 
                    {
                        task.SetAssignee("unassigned"); 
                        task.ToDal().Assignee = "unassigned"; 
                    }
                }
            }
        }
        public void addUserToBoard(user user)
        {
            if(!members_list.Contains(user))
                members_list.Add(user);
        }

        public void removeUserFromBoard(user user)
        {
            if (members_list.Contains(user))
                members_list.Remove(user);
        }

        //public Board getboard(int id)
        //{
        //    Board my = new Board(this.User_Email, this.Board_name, this.Board_id);
        //    my.members_list = this.members_list;
        //    my.columns_list = this.columns_list;
        //    my.taskcount = this.taskcount;
        //    //my.DAL_column = this.DAL_column;
        //    //return Board(this.User_Email, this.Board_name, this.Board_id);
        //    return my;
        //}
    }
}
