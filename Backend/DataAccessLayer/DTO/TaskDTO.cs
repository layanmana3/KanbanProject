using IntroSE.Kanban.Backend.BussinessLayer.Board;
using IntroSE.Kanban.Backend.DataAccessLayer.DAL;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.DataAccessLayer.DTO
{
    public  class TaskDTO :DTOs
    {
        public const string Task_BoardId = "BoardID";
        public const string Task_BoardOrdinal = "Ordinal";
        public const string Task_ID = "TaskID";
        public const string Task_Email = "Email";
        public const string Task_ColumnTitle = "Title";
        public const string Task_ColumnDescreption = "Descreption";
        public const string Task_ColumnDueDate = "DueDate";
        public const string Tasks_ColumnCreationTime = "CreationTime";


        private int BoardId;
        private int TaskId;
        private int Ordinal;
        private string Email;
        private string title;
        private string description;
        private DateTime CreateTime;
        private DateTime DueDate;
        private string assignee;

        /// <summary>
        /// getters & setters
        /// </summary>
        /// 
        public string Assignee {
            get { return assignee; } 
            set { assignee = value; }
        }
        public string desciptions {
            get { return description; }
            set { description = value; }
        }
        public int taskID {
            get { return TaskId; }
            set { TaskId = value; }
        }
        public int BoardID {
            get { return BoardId; } 
            set { BoardId = value; }
        }
        public int ORDINAL { 
            get { return Ordinal; } 
            set { Ordinal = value; } 
        }
        public string EMAIL { 
            get { return Email; } 
            set { Email = value;  } 
        }
        public string TITLE {
            get { return title; }
            set { title = value; }
        }
        public DateTime CreationTime {
            get { return CreateTime; } 
            set { CreateTime = value; }
        }
        public DateTime DUEDATE { 
            get { return DueDate; } 
            set { DueDate = value; } 
        }


        public TaskDTO(int taskID, DateTime CreateTime, DateTime DueDate, string title, string description, string Email, int BoardId, int Ordinal):base(new DALtaskcontroller())
        {
            this.TaskId = taskID;
            this.BoardId = BoardId;
            this.Ordinal = Ordinal;
            this.Email = Email;
            this.title = title;
            this.description = description;
            this.CreateTime = CreateTime;
            this.DueDate = DueDate;


        }
        public void Save()
        {
            taskID = taskID;
            BoardID = BoardId;
            Assignee = assignee;
            TITLE = title;
            desciptions = description;
            CreationTime = CreateTime;
            DUEDATE = DueDate;
            ORDINAL = Ordinal;
        }
    }

}
