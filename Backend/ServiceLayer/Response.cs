using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Forum.Backend.ServiceLayer
{
    public class Response
    {


        public string ErrorMessage { get; set; }
        public object ReturnValue { get; set; }
        public bool ErrorOccured { get => ErrorMessage != null; }
        public Response() { }
        public Response(string msg)
        {
            ErrorMessage = msg;
            ReturnValue = null;
        }
        public Response(string msg, object returnValue)
        {
            ErrorMessage = msg;
            ReturnValue = returnValue;
        }

        public Response(int[] array)
        {
            ReturnValue = array;
        }
  
        public Response(string msg,object msg1,object msg2)
        {
           
            ReturnValue = msg;
        }

        //public Response(Kanban.Backend.BussinessLayer.Board.Task[] tasksArray)
        //{
        //    ReturnValue = tasksArray;
        //}

        public bool CheckforError()
        {
            if (ErrorMessage == null)
            {
                return false;
            }
            return true;
        }
    }
}