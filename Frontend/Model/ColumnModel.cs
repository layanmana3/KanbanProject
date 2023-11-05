using IntroSE.Kanban.Backend.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Model
{
    public class ColumnModel : NotifiableModelObject
    {


        private readonly UserModel user_m;

        public ObservableCollection<TaskModel> backlog { get; set; }
        public ObservableCollection<TaskModel> inprogress { get; set; }
        public ObservableCollection<TaskModel> done { get; set; }


        public ColumnModel(BackendController controller, UserModel user, int brdId) : base(controller)
        {
            this.user_m = user;
            backlog = new ObservableCollection<TaskModel>();
            inprogress = new ObservableCollection<TaskModel>();
            done = new ObservableCollection<TaskModel>();
            for (int i = 0; i < 3; i++)
            {
                TaskToSend[] array = controller.GetColumn(user.Email, brdId, i);
                for (int j = 0; j < array.Length; j++)
                {
                    TaskToSend currtask = array[j];
                    if (i == 0)
                    {
                        TaskModel tasktoadd = new TaskModel(user.Controller, currtask.Id, currtask.Title, currtask.Description, currtask.assignee, currtask.CreationTime, currtask.DueDate);
                        backlog.Add(tasktoadd);
                    }
                    else if (i == 1)
                    {
                        TaskModel tasktoadd = new TaskModel(user.Controller, currtask.Id, currtask.Title, currtask.Description, currtask.assignee, currtask.CreationTime, currtask.DueDate);
                        inprogress.Add(tasktoadd);
                    }
                    else
                    {
                        TaskModel tasktoadd = new TaskModel(user.Controller, currtask.Id, currtask.Title, currtask.Description, currtask.assignee, currtask.CreationTime, currtask.DueDate);
                        done.Add(tasktoadd);
                    }
                }
            }
        }
    }
}
