using IntroSE.Kanban.Backend.DataAccessLayer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.DataAccessLayer.DTO
{
    public abstract class DTOs
    {
        protected DALcontroller control;
        protected DTOs(DALcontroller control)
        { this.control = control; }

    }
}

