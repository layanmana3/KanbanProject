using IntroSE.Kanban.Backend.BussinessLayer.Board;
using IntroSE.Kanban.Backend.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Model
{
    public class BoardListModel : NotifiableModelObject
    {
        //HandleChange

        private readonly UserModel userModel;
        public ObservableCollection<BoardModel> boardslist { get; set; }

        //private BoardListModel(BackendController controller, ObservableCollection<BoardModel> Boardslist):base(controller)
        //{
        //    this.boardslist = Boardslist;
        //    boardslist.CollectionChanged += HandleChange;
        //}

        public BoardListModel(BackendController controller, UserModel user) : base(controller)
        {
            this.boardslist = new ObservableCollection<BoardModel>();
            this.userModel = user;
           // boardslist = new ObservableCollection<BoardModel>();
            List<int> curr = controller.GetBoardsids(user.Email);
    
            foreach (int id in curr)
            {
                boardslist.Add(new BoardModel(controller, id.ToString() , controller.GetBoardname(user.Email,id), user.Email));
            }
            ObservableCollection<BoardModel> boards =boardslist;

         }





    }
}
