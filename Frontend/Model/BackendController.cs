using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Windows;
using System.Xml.Linq;
//using Backend.Service;
//using Backend.Service.Objects;
using IntroSE.Forum.Backend.ServiceLayer;
using IntroSE.Kanban.Backend.BusinessLayer.User;
using IntroSE.Kanban.Backend.BussinessLayer.Board;
using IntroSE.Kanban.Backend.ServiceLayer;

namespace Frontend.Model
{
    public class BackendController
    {
        private FactoryService Service { get; set; }
        public BackendController(FactoryService service)
        {
            this.Service = service;
            service.LoadData();
        }

        public BackendController()
        {
            this.Service = new FactoryService();
            Service.LoadData();
        }

        public UserModel Login(string username, string password)
        {
            string json = Service.Login(username, password);
            Response Login = JsonSerializer.Deserialize<Response>(json);
            if (Login.ErrorOccured)
            {
                throw new Exception(Login.ErrorMessage);
            }
            return new UserModel(this, username);
           
        }
        public UserModel Register(string username, string password)
        {
            string json = Service.Register(username, password);
            Response reg = JsonSerializer.Deserialize<Response>(json);
            if (reg.ErrorOccured)
            {
                throw new Exception(reg.ErrorMessage);
            }
            return new UserModel(this, username);
        }
        public List<int> GetBoardsids(string email)
        {
            IReadOnlyCollection<int> boardsids;

            //string json = Service.GetUserBoards(email);
            //Response<int[]> boards = JsonSerializer.Deserialize <Response<int[]>>(json);
            boardsids = Service.GetUserBoardsForLoading(email);

            List<int> result = new List<int>();
            if (boardsids != null)
            {
                foreach (int boardid in boardsids)
                { result.Add(boardid); }
            }
            return result;
        }

        public void Logout(string email)
        {
            string json = Service.Logout(email);
            Response name = JsonSerializer.Deserialize<Response>(json);
            if (name.ErrorOccured)
            {
                throw new Exception(name.ErrorMessage);
            }

        } 

        public string GetBoardname(string email,int id) 
        {
            
            string json = Service.GetBoardName(id);
            Response boardname = JsonSerializer.Deserialize<Response>(json);
            if (boardname.ErrorOccured)
            {
                throw new Exception(boardname.ErrorMessage);
            }
            return json;
        }

        public TaskToSend[] GetColumn(string email,int boardid,int ordinal)
        {
            string boardname = Service.GetBoardName(boardid);
            string json = Service.GetColumn(email, boardname, ordinal);
            Response<TaskToSend[]> column= JsonSerializer.Deserialize<Response<TaskToSend[]>>(json);
            if (column.ErrorOccured)
            {
                throw new Exception(column.ErrorMessage);
            }
            return column.Value;
        }
        internal (string Id, string Title) GetBoard(string email, int boardid)
        {

            string json = Service.GetBoardName(boardid);
            Response<string> name = JsonSerializer.Deserialize<Response<string>>(json);
            return (boardid.ToString(), name.Value);
        }



    }
}
