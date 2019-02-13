using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dialogica_site.Models;

namespace dialogica_site.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        Model_Banco Banco = new Model_Banco();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Painel_Log()
        {
            return View();
        }


        //Poste de Valores

        public ActionResult BarChart_Aten_Mes()
        {
            string dataMin = DateTime.Now.ToString("yyyy-MM-dd");
            string dataMax = DateTime.Today.AddMonths(-1).ToString("yyyy-MM-dd");
            if (Banco.Quantidade_Ordens_Mes_P(dataMin, dataMax))
            {
                var Dados = Banco.Quantidade_Mes;
                return Json(Dados, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Erro", JsonRequestBehavior.AllowGet);
            }
        }

    }
}
