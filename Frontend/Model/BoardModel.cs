using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Model
{
    public class BoardModel : NotifiableModelObject
    {
        private string useremail;
        private string _title;
        private string _id;

        public BoardModel(BackendController controller, string id, string title, string userEmail) : base(controller)
        {
            _id = id;
            _title = title;
            Id = id;
            //Title = title;
            useremail = userEmail;
        }
        public string Id
        {
            get { return _id; }
            set
            {
                _id = "Boards ID: " + value;
                RaisePropertyChanged("Id");
            }
        }
        public string Title
        {
            get { return _title; }

            set
            {
                _title = "Boards name: " + value;
                RaisePropertyChanged("Title");
            }
        }

        public BoardModel(BackendController controller, (string Id, string Title) board, UserModel user) : this(controller, board.Id, board.Title, user.Email) { }
    }
}