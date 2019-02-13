using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Projeto_TermCurso.Models;

namespace Projeto_TermCurso.Controllers
{
    public class AgendaTelController : ApiController
    {
        [AcceptVerbs("GET")]
        public IEnumerable<DB_Body> GetAgenda()
        {
            Db_Agenda agenda = new Db_Agenda();
            return agenda.Tables;
        }
    }
}
