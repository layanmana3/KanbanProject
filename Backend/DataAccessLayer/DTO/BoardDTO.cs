using IntroSE.Kanban.Backend.BussinessLayer.Board;
using IntroSE.Kanban.Backend.DataAccessLayer.DAL;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.DataAccessLayer.DTO
{
    public class BoardDTO : DTOs
    {
        public const string BoardsID = "BoardID";
        public const string BoardsEmail = "Email";
        public const string BoardsName = "BoardName";
        public const string BoardTaskCounter = "Taskcounter";

        private int boardid;
        private string boardemail;
        private string boardname;
        private int taskcounter;

        public BoardDTO(int id, int count, string name, string email) : base(new DALboardcontroller())
        {
            this.boardid = id;
            this.boardemail = email;
            this.boardname = name;
            this.taskcounter = count;

        }
        public int BOARDID
        {
            get { return this.boardid; }
            set { this.boardid = value; }
        }

        public string BOARDEMAIL
        {
            get { return this.boardemail; }
            set { this.boardemail = value; }
        }
        public string BOARDNAME
        {
            get { return this.boardname; }
            set { this.boardname = value; }
        }
        public int TASKCOUNTER
        {
            get { return this.taskcounter; }
            set { this.taskcounter = value; }
        }

        public void Save()
        {
            BOARDID = boardid;
            BOARDEMAIL = boardemail;
            BOARDNAME = boardname;
            TASKCOUNTER = taskcounter;
        }
    }
}
