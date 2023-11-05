using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using IntroSE.Kanban.Backend.BussinessLayer.Board;
using IntroSE.Kanban.Backend.DataAccessLayer.DAL;
using IntroSE.Kanban.Backend.DataAccessLayer.DTO;
using Microsoft.VisualBasic;
//using IntroSE.Kanban.Backend.BussinessLayer.task;

namespace IntroSE.Kanban.Backend.BussinessLayer.Board
{
    public class Column
    {
        private int limit_of_tasks;
        private int col_Ordinal;
        private List<Task> List_of_tasks;
        private string ColumnName;
        private string board_name;
        private int boardid;

        private readonly DALtaskcontroller DAL_task = new DALtaskcontroller();
        private readonly DALcolumncontroller DAL_column = new DALcolumncontroller();
        /// <summary>
        /// constructor for the column class
        /// </summary>
        /// <param name="status_of_column ">the  column status </param>
        public Column(int Ordinal, string board)
        {
            this.col_Ordinal = Ordinal;
            this.List_of_tasks = new List<Task>();
            this.limit_of_tasks = -1;
            if (Ordinal == 0) ColumnName = "backlog";
            if (Ordinal == 1) ColumnName = "in progress";
            else ColumnName = "done";
            this.board_name = board;

        }
        
        /// <summary>
        /// this function return anew column dto  
        /// </summary>
        /// <return> return the columndto </return>

        public ColumnDTO todal()
        {
            return new ColumnDTO(this.boardid, this.col_Ordinal,this.ColumnName, this.limit_of_tasks);
        }
        /// <summary>
        /// this function return the limit of the task in the column 
        /// </summary>
        /// <return> return the limit </return>
        public int getlim()
        {
            return this.limit_of_tasks;
        }
        public void set_board_id(int id )
        {
            this.boardid = id;
        }
        /// <summary>
        /// this function change the limit of the tasks in the column 
        /// </summary>
        /// <param> name="lim ">the new limit </param>
        /// <return>the function does not return anything</return>
        public void setlim(int lim)
        {
            if (lim == -1 || lim >= num_of_tasks())
            {
                this.limit_of_tasks = lim;
                this.todal().save();
            }
            else { throw new Exception("Column contains tasks more than the limit!"); }

        }
        /// <summary>
        /// the function return the number of tasks in the column 
        /// </summary>
        /// <return>the function return the number of tasks </return>
        public int num_of_tasks()
        {
            return this.List_of_tasks.Count;
        }
        /// <summary>
        /// this function return a list of tasks in the column 
        /// </summary>
        /// <return>the function return a list of tasks </return>
        public List<Task> List_Of_Tasks()
        {
            return this.List_of_tasks;
        }
        /// <summary>
        /// this function add new task to the column task list 
        /// </summary>
        /// <return> null  </return>
        public void AddTask(string email, string title, string description, DateTime dueDate, int taskId)
        {
            if (!(List_of_tasks.Count == limit_of_tasks))
            {
                Task addtask = new Task(taskId, dueDate, title, description, email, board_name, boardid);
                addtask.SetAssignee(email);
                List_of_tasks.Add(addtask);
                this.DAL_task.Insert(addtask.ToDal());
                
            }
            else throw new Exception("no more tasks can be added");
        }

        public void AddTask(Task task)
        {
            if (!(List_of_tasks.Count == limit_of_tasks))
            {
                //Task addtask = new Task(taskId, dueDate, title, description, email, board_name, boardid);
                //task.SetAssignee(task.getEmail());
                List_of_tasks.Add(task);
                this.DAL_task.Insert(task.ToDal());

            }
        }

        public string GetColumnName()
        {
            return this.ColumnName;
        }

        public void Remove(Task task)
        {
            if (List_of_tasks.Count > 0)
                List_of_tasks.Remove(task);
        }
        public int getboardid()
        {
            return this.boardid;
        }
        public void Prepare()
        {
            this.limit_of_tasks = this.DAL_column.GetTaskLimit(this.boardid, this.col_Ordinal);
            List<TaskDTO> tasks = this.DAL_task.SelectcolsTasks(this.boardid, this.col_Ordinal);
            foreach (TaskDTO tsk in tasks)
            {
                this.List_of_tasks.Add(new Task(tsk));
            }

        }

       
    }
}
