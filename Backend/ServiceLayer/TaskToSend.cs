using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntroSE.Kanban.Backend.BussinessLayer;

namespace IntroSE.Kanban.Backend.ServiceLayer
{
    public class TaskToSend
    {
        public int Id { get; set; }
        public DateTime CreationTime { get; set; }
        public string Title { get; set; }

        public string Description {get; set;}
        public DateTime DueDate { get; set; }
        public string assignee { get; set; }

        public TaskToSend() { }

        public TaskToSend(BussinessLayer.Board.Task task)
        {
            this.Id = task.getid();
            this.CreationTime = task.getcreationTime();
            this.Title = task.gettitle();
            this.Description = task.getdescription();
            this.DueDate = task.getdueDate();
            this.assignee = task.GetAssignee();
        }
    }
}
