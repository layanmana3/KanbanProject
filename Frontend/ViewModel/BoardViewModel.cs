using Frontend.Model;
using System;
using System.Data.Entity.Migrations.Model;
using System.Windows;
using System.Windows.Media;
using Frontend.Model;
using Frontend.View;
using Frontend.ViewModel;
using System.Collections.Generic;
using IntroSE.Kanban.Backend.BussinessLayer.Board;
using ColumnModel = Frontend.Model.ColumnModel;

namespace Frontend.ViewModel

{
    internal class BoardViewModel : NotifiableObject
    {
        private Model.BackendController controller;
        private UserModel userModel;
        private string title;
        private ColumnModel taskslist;
        public BoardViewModel(UserModel user, String boardName, int Id)
        {
            this.controller = user.Controller;
            this.userModel = user;
            this.title = boardName;
            this.taskslist = user.GetColumn(Id);
        }
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                RaisePropertyChanged("Title");
            }
        }
        
      

       


    }
}