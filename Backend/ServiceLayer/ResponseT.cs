using IntroSE.Forum.Backend.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.ServiceLayer
{
    public class Response<T> : Response
    {
        public readonly T Value;
        public Response(T value) : base()
        {
            this.Value = value;
        }
        public Response() { }
        public Response(string msg) : base(msg) { }
      
        public Response(T value, string msg) : base(msg)
        {
            this.Value = value;
        }
        //public Response(int[] inte)
        //{
        //    this.Value = inte;
        //}
    }
}
