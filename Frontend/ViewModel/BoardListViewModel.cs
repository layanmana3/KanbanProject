using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frontend.Model;

namespace Frontend.ViewModel
{
    public class BoardListViewModel : NotifiableObject
    {
        private Model.BackendController controller;
        private UserModel userModel;
        private bool enableForward = false;
        private BoardModel selectedBoard;
        public BoardListModel userBoards { get; private set; }

        public BoardModel board { get; private set; }
        public BoardListViewModel(UserModel user)
        {
            this.controller = user.Controller;
            this.userModel = user;
            this.Title = "Boards of: " + user.Email;
            this.userBoards = user.GetBoards();

        }

        public string Title { get; private set; }
        public BoardModel SelectedBoard
        {
            get
            {
                return selectedBoard;
            }
            set
            {
                selectedBoard = value;
                EnableForward = value != null;
                RaisePropertyChanged("SelectedBoard");
            }
        }
        public bool EnableForward
        {
            get => enableForward;
            private set
            {
                enableForward = value;
                RaisePropertyChanged("EnableForward");
            }
        }
        public void Logout()
        {
            try
            {
                controller.Logout(userModel.Email);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }



        public string get_id()
        {
            return SelectedBoard.Id;
        }

        public string get_title()
        {
            return SelectedBoard.Title; 
        }

    }
}