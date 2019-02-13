using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication4.Models;
using MvcApplication4.Controllers;

namespace MvcApplication4.Controllers
{
    public class ServicosController : Controller
    {
        //
        // GET: /Servicos/
        Model_Banco_Services Banco = new Model_Banco_Services();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Corpo_Site"></param>
        /// <returns></returns>
        [Authorize(Roles ="Adm")]
        public ActionResult Cadastro_Usuario(Body_ Corpo_Site)
        {
            ViewBag.Nome_User = Body_.User_Autenticado.nome.ToString();
            ViewBag.Cadastro_State = "";
            if (Session["Cadastro_State"] != null)
            {
                ViewBag.Cadastro_State = Session["Cadastro_State"].ToString();
                ViewBag.Tabela = Session["Tabela"].ToString();
                Session["Cadastro_State"] = null;
            }
            ViewBag.Nivel = Corpo_Site.nivel;
            return View(Corpo_Site);
        }
        [Authorize(Roles = "Adm")]
        [HttpPost]
        public ActionResult Cadastro_Usuario1(Body_ Data_User)
        {

            if (Banco.Insert_Cadastro_User(Data_User))
            {
                Session["Cadastro_State"] = "Sucesso";
                Session["Tabela"] = "Cadastro_Usuario";
            }
            else
            {
                Session["Cadastro_State"] = "Erro";
            }
            return RedirectToAction("Cadastro_Usuario", "Servicos");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Corpo_Site"></param>
        /// <returns></returns>
        [Authorize(Roles = "Adm")]
        public ActionResult Cadastro_Categoria(Body_ Corpo_Site)
        {
            ViewBag.Nome_User = Body_.User_Autenticado.nome.ToString();
            ViewBag.Cadastro_State = "";
            if (Session["Cadastro_State"] != null)
            {
                ViewBag.Cadastro_State = Session["Cadastro_State"].ToString();
                ViewBag.Tabela = Session["Tabela"].ToString();
                Session["Cadastro_State"] = null;
            }
            ViewBag.Nivel = Corpo_Site.nivel;
            return View(Corpo_Site);
        }
        [Authorize(Roles = "Adm")]
        [HttpPost]
        public ActionResult Cadastro_Categoria1(Body_ Data_Lugar)
        {
            if (Banco.Insert_Cadastro_Categoria(Data_Lugar))
            {
                Session["Cadastro_State"] = "Sucesso";
                Session["Tabela"] = "Cadastro_Categoria";
            }
            else
            {
                Session["Cadastro_State"] = "Erro";
            }
            return RedirectToAction("Cadastro_Categoria", "Servicos");
        }

        /*[Authorize(Roles = "Adm")]
        public ActionResult Cadastro_Setor(Body_ Corpo_Site)
        {
            ViewBag.Cadastro_State = "";
            if (Session["Cadastro_State"] != null)
            {
                ViewBag.Cadastro_State = Session["Cadastro_State"].ToString();
                ViewBag.Tabela = Session["Tabela"].ToString();
                Session["Cadastro_State"] = null;
            }
            return View(Corpo_Site);
        }
        [Authorize(Roles = "Adm")]
        [HttpPost]
        public ActionResult Cadastro_Setor1(Body_ Data_Setor)
        {
            if (Banco.Insert_Cadastro_Setor(Data_Setor))
            {
                Session["Cadastro_State"] = "Sucesso";
                Session["Tabela"] = "Setores";
            }
            else
            {
                Session["Cadastro_State"] = "Erro";
            }
            return RedirectToAction("Cadastro_Setor", "Servicos");
        }*/

        [Authorize(Roles = "Adm")]
        public ActionResult Cadastro_Email(Body_ Corpo_Site)
        {
            ViewBag.Nome_User = Body_.User_Autenticado.nome.ToString();
            ViewBag.Cadastro_State = "";
            if (Session["Cadastro_State"] != null)
            {
                ViewBag.Cadastro_State = Session["Cadastro_State"].ToString();
                ViewBag.Tabela = Session["Tabela"].ToString();
                Session["Cadastro_State"] = null;
            }
            return View(Corpo_Site);
        }
        [Authorize(Roles = "Adm")]
        [HttpPost]
        public ActionResult Cadastro_Email1(Body_ Data_Lugar)
        {
            if (Banco.Insert_Cadastro_Email(Data_Lugar))
            {
                Session["Cadastro_State"] = "Sucesso";
                Session["Tabela"] = "email";
            }
            else
            {
                Session["Cadastro_State"] = "Erro";
            }
            return RedirectToAction("Cadastro_Email", "Servicos");
        }

        [Authorize(Roles = "Adm")]
        public ActionResult Consultar_User()
        {
            ViewBag.Nome_User = Body_.User_Autenticado.nome.ToString();
            Body_ Corpo_Site = new Body_();
            Corpo_Site.User_Select = Banco.Consulta_User();
            return View(Corpo_Site);
        }
        [Authorize(Roles = "Adm")]
        public ActionResult Consultar_User_Apagar(Int64 id)
        {
            if (Banco.Apagar_Cadastro_User(id))
            {
                Session["Cadastro_State"] = "Sucesso";
                Session["Tabela"] = "cadastro_user";
            }
            else
            {
                Session["Cadastro_State"] = "Infelizmente não foi possível realizar a ação!";
            }
            return RedirectToAction("Consultar_User", "Servicos");
        }
        //Consulta e validações Remotas
        [Authorize(Roles = "Adm")]
        public JsonResult Consulta_Email(string Email)
        {
            if(Banco.Consulta_Email(Email))
            {
                return Json("E-mail Existente", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            
        }

    }
}
