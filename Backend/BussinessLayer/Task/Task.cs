using IntroSE.Kanban.Backend.DataAccessLayer.DTO;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.BussinessLayer.Board

{
    public class Task
    {
        private int id ;
        private string assignee;
        private  readonly DateTime creationTime;
        private  DateTime dueDate;
        private string title;
        private string description;
        private int ColumnOrdinal;
        private string Email;
        private string myboard;
        private int board_id;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        /// <summary>
        /// constructor for the task class
        /// </summary>

        /// <param> name="id">the id and its unique</param>
        /// <param> name="creationTime"> the creationtime of the task</param>
        /// <param> name="dueDate">the task dueDate</param>
        /// <param> name="title">the task title</param>
        /// <param> name="Description">the task decsription</param>
        /// <param> name="board_Status">the task status or the column name of the task </param>
        /// <param> name="Email">the user email who created the task</param>
        public Task(int id, DateTime dueDate, string title, string description, string Email , string myboard, int board_id)
        {
            this.id = id;
            this.creationTime = DateTime.Now;
            this.dueDate = dueDate;
            this.title = title;
            this.description = description;
            this.ColumnOrdinal = 0;
            this.Email = Email;
            this.myboard = myboard;
            this.assignee = "unassigned";
            this.board_id = board_id;
            

        }

        public Task(TaskDTO dtotask)
        {
            this.cdescription( dtotask.desciptions);
            this.creationTime = dtotask.CreationTime;
            this.id = dtotask.taskID;
            this.dueDate = dtotask.DUEDATE;
            this.ctitle (dtotask.TITLE);
            this.ColumnOrdinal = dtotask.ORDINAL;
            this.Email = dtotask.EMAIL;
            this.board_id = dtotask.BoardID;
            this.assignee = dtotask.Assignee;
        }

        public TaskDTO ToDal()
        {
            return new TaskDTO(id, creationTime, dueDate, title, description, Email, board_id, ColumnOrdinal);
        }

        public string GetAssignee()
        {
            return this.assignee;
        }

        public void SetAssignee(string ass)
        {
            this.assignee = ass; 
        }

        /// <summary>
        /// this is a getter for the task id
        /// </summary>
        /// <returns>the task id</returns>
        public int getid()
        {
            return id;
        }
        /// <summary>
        /// this is a getter for the creationtime
        /// </summary>
        /// <returns>the task creationtime</returns>
        public DateTime getcreationTime()
        {
            return creationTime;
        }
        /// <summary>
        /// this is a getter for the task dueDate
        /// </summary>
        /// <returns>the task dueDate</returns>
        public DateTime getdueDate()
        {
            return dueDate;
        }
        /// <summary>
        /// this is a getter for the task title
        /// </summary>
        /// <returns>the task title</returns>
        public string gettitle()
        {
            return title;
        }
        /// <summary>
        /// this is a getter for the task description
        /// </summary>
        /// <returns>the task description</returns>
        public string getdescription()
        {
            return description;
        }
        /// <summary>
        /// this is a getter for the task status
        /// </summary>
        /// <returns>the task status</returns>
        public int getColumnOrdinal()
        {
            return ColumnOrdinal;
        }
        /// <summary>
        /// this is a getter for the task email
        /// </summary>
        /// <returns>the task email</returns>
        public string getEmail()
        {
            return Email;
        }
        public string getmyboard()
        {
            return myboard;
        }
        public int getboardid()
        {
            return this.board_id;
        }

        /// <summary>
        /// this is a setter for the task duedate
        /// </summary>
        /// <param name="title">the new duedate we want to set to the task</param>
        /// <return>the function does not return anything</return>
        public void setDuedate(DateTime newdueDate)
        {
            this.dueDate = newdueDate;
        }

        /// <summary>
        /// this is a setter for the task title
        /// </summary>
        /// <param name="title">the new title we want to set to the task</param>
        /// <return>the function does not return anything</return>
        public void setTitle(string newTitle)
        {
            if (ctitle(newTitle))
                this.title = newTitle;
            
        }


        /// <summary>
        /// this is a setter for the task description
        /// </summary>
        /// <param name="title">the new description we want to set to the task</param>
        /// <return>the function does not return anything</return>
        public void setdescription(string newdescription)
        {
            if (cdescription(newdescription))
                 this.description = newdescription;
        }

        /// <summary>
        /// this is a setter for the task status
        /// </summary>
        /// <param name="title">the new status we want to set to the task</param>
        /// <return>the function does not return anything</return>

        public void setColumnOrdinal(int newOrdinal)
        {
            this.ColumnOrdinal = newOrdinal;
        }

        /// <summary>
        /// this is a setter for the task Email
        /// </summary>
        /// <param name="title">the new Email we want to set to the task</param>
        /// <return>the function does not return anything</return>
        public void setEmail(string newEmail)
        {
            this.Email = newEmail;
        }
        

        public bool ctitle (string title )
        {
            if (title is null)
            {
                log.Warn("title cant be null ");
                throw new Exception("title cant be null ");
            }
            if (title.Length == 0)
            {
                log.Warn("title cant be empty ");
                throw new Exception("title cant be empty");
            }
            if (title.Length > 50)
            {
                log.Warn("the length of the title cant be more than 50 ");
                throw new Exception("the length of the title cant be more than 50 ");
            }
            return true;
        }

        public bool cdescription (string description )
        {
            if (description == null)
            {
                log.Warn("decsription cant be null ");
                throw new Exception("decsription cant be  null");
            }
            if (description.Length > 300)
            {
                log.Warn("the length of the description cant be more than 300");
                throw new Exception("the length of the description cant be more than 300");
            }
            return true;
        }
    


    }
}
