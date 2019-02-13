using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto_Laboral.Body;
using Projeto_Laboral.Models;

namespace Projeto_Laboral.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        Body_Site_Template Body = new Body_Site_Template();
        public ActionResult Index()
        {
            Model_DB_Service Service = new Model_DB_Service();
            Body.S1_Home = Service.Carregamento_Home().S1_Home;
            Body.S3_Servicos = Service.Carregamento_Servicos().S3_Servicos;
            Body.S4_PRF = Service.Carregamento_Profissional().S4_PRF;
            Body.S5_Galeria = Service.Carregamento_Gallery().S5_Galeria;
            return View(Body);
        }

    }
}
