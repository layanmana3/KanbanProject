

namespace Frontend.Model
{
    public class UserModel : NotifiableModelObject
    {
        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                RaisePropertyChanged("Email");
            }
        }

        public BoardListModel GetBoards()
        {
            return new BoardListModel(Controller, this);
        }
        public ColumnModel GetColumn(int brdId)
        {
            return new ColumnModel(Controller, this, brdId);
        }

        public UserModel(BackendController controller, string email) : base(controller)
        {
            _email = email;
        }
    }
}
