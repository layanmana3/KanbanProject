using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Model
{
    public class TaskModel : NotifiableModelObject
    {
        private int _id;
        private DateTime _creationtime;
        private string _title;
        private string _description;
        private string _assignee;
        private DateTime _duedate;

        public TaskModel(BackendController controller, int id, string title, string desc, string assigne, DateTime crtime, DateTime duodate) : base(controller)
        {
            ID = id;
            Title = title;
            Description = desc;
            Assignee = assigne;
            CreationTime = crtime;
            DueDate = duodate;
        }
        public int ID
        {
            get { return _id; }
            set
            {
                _id = value;
                RaisePropertyChanged("ID");
            }
        }
        public DateTime CreationTime
        {
            get { return _creationtime; }
            set
            {
                _creationtime = value;
                RaisePropertyChanged("CreationTime");
            }
        }
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                RaisePropertyChanged("Title");
            }
        }

        
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                RaisePropertyChanged("Description");
            }
        }
        public string Assignee
        {
            get { return _assignee; }
            set
            {
                _assignee = value;
                RaisePropertyChanged("Assignee");
            }
        }
        public DateTime DueDate
        {
            get { return _duedate; }
            set
            {
                _duedate = value;
                RaisePropertyChanged("DueDate");
            }
        }
    }
}