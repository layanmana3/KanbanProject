using IntroSE.Kanban.Backend.BussinessLayer.Board;
using IntroSE.Kanban.Backend.DataAccessLayer.DAL;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IntroSE.Kanban.Backend.DataAccessLayer.DTO
{
    public class ColumnDTO : DTOs
    {
        public const string Column_BoardId = "BOARDID";
        public const string Column_Ordinal = "COLUMNORDINAL";
        public const string Column_Name = "COLUMNNAME";
        public const string Column_TaskLimit = "COLUMNTASKLIMIT";
        private int boardid;
        private int columnordinal;
        private string columnname;
        private int columnTasklimit;

        public ColumnDTO(int id, int ordinal, string name, int limit) : base(new DALcolumncontroller())
        {
            this.boardid = id;
            this.columnordinal = ordinal;
            this.columnname = name;
            this.columnTasklimit = limit;

        }
        public int BOARDID
        {
            get { return this.boardid; }
            set { this.boardid = value; }
        }

        public int COLUMNORDINAL
        {
            get { return this.columnordinal; }
            set { this.columnordinal = value; }
        }

        public int COLUMNTASKLIMIT
        {
            get { return this.columnTasklimit; }
            set { this.columnTasklimit = value; }
        }

        public string COLUMNNAME
        {
            get { return this.columnname; }
            set { this.columnname = value; }
        }

        public void save()
        {
            COLUMNORDINAL = columnordinal;
            COLUMNTASKLIMIT = columnTasklimit;
            COLUMNNAME = columnname;
            BOARDID = boardid;
        }
    }
}
