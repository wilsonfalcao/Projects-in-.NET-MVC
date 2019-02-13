using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication4.Controllers;
using MvcApplication4.Models;

namespace MvcApplication4.Controllers
{
    public class DiarioController : Controller
    {

        //PAGINA DE REGISTRO
        Model_Banco_Services Banco = new Model_Banco_Services();
        [Authorize(Roles = "Adm, Usuario")]
        public ActionResult Diario_Bordo()
        {
            ViewBag.Nome_User = Body_.User_Autenticado.nome.ToString();
            Body_ Sistema = new Body_();
            Session["protocolo"] = Sistema.Protocolo().ToString();
            Sistema.Categorias_Select = Banco.Consulta_Categorias();
            ViewBag.Protocolo = Session["protocolo"].ToString();
            ViewBag.Data = DateTime.Now.ToString("yyyy-MM-dd");
            ViewBag.Cadastro_State = "";
            if (Session["Cadastro_State"] != null)
            {
                ViewBag.Cadastro_State = Session["Cadastro_State"].ToString();
                ViewBag.Tabela = Session["Tabela"].ToString();
                Session["Cadastro_State"] = null;
            }
            return View(Sistema);
        }
        
        [Authorize(Roles = "Adm, Usuario")]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Diario_Bordo(FormCollection Data_Bordo)
        {
            Body_ Set_Bordo = new Body_();
            Set_Bordo.id_lugar = Convert.ToInt32(Data_Bordo["selectlugar"].ToString());
            Set_Bordo.t_problema = Data_Bordo["tproblema"].ToString();
            Set_Bordo.problema = Data_Bordo["texto"].ToString();
            string emailtxt = null;
            if (Data_Bordo["emailtxt"] == "")
            {
                emailtxt = Data_Bordo["emailtxt"].ToString();
            }
            if (Banco.Insert_Diario_Bordo(Set_Bordo,Convert.ToInt64(Session["protocolo"].ToString())))
            {
                Session["Cadastro_State"] = "Sucesso";
                Session["Tabela"] = "d_bordo_s1";
                Email_Marketing Marketing = new Email_Marketing();
                Marketing.Noti_Insert(Set_Bordo, Session["protocolo"].ToString(),emailtxt);
            }
            else
            {
                Session["Cadastro_State"] = "Erro";
            }
            return RedirectToAction("Diario_Bordo", "Diario");
        }
        

        //PAGINAS DE CONSULTA
        [Authorize(Roles = "Adm, Usuario")]
        public ActionResult Diario_Bordo_C()
        {
            ViewBag.Nome_User = Body_.User_Autenticado.nome.ToString();
            ViewBag.Status_Acao = "";
            if (Session["Cadastro_State"] != null)
            {
                ViewBag.Status_Acao = Session["Cadastro_State"].ToString();
            }
            Body_ Sistema = new Body_();
            Sistema.Listar_Bordo = Banco.Listar_Bordo("");
            return View(Sistema);
        }
        [Authorize(Roles = "Adm, Usuario")]
        public ActionResult Diario_Bordo_Leituras(Int64 id)
        {
            ViewBag.Nome_User = Body_.User_Autenticado.nome.ToString();
            Body_ Sistema = new Body_();
            Sistema.Listar_Bordo = Banco.Listar_Bordo(Convert.ToString(id));
            return View(Sistema);
        }
        


        //PAGINA DE AÇÕES
        [Authorize(Roles = "Adm, Usuario")]
        public ActionResult Diario_Bordo_Atualizar(Int64 id)
        {
            ViewBag.Nome_User = Body_.User_Autenticado.nome.ToString();
            Body_ Sistema = new Body_();
            Sistema.Categorias_Select = Banco.Consulta_Categorias();
            Session["protocolo"] = id;
            Sistema.Listar_Bordo = Banco.Listar_Bordo(Convert.ToString(id));
            return View(Sistema);
        }
        [Authorize(Roles = "Adm, Usuario")]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Diario_Bordo_Atualizar(FormCollection Data_Atualizar)
        {
            Body_ Set_Bordo_At = new Body_();
            Set_Bordo_At.id_lugar = Convert.ToInt32(Data_Atualizar["selectlugar"].ToString());
            Set_Bordo_At.t_problema = Data_Atualizar["tproblema"].ToString();
            Set_Bordo_At.problema = Data_Atualizar["texto"].ToString();
            if (Banco.Atualizar_Diario_Bordo(Set_Bordo_At,Session["protocolo"].ToString()))
            {
                Session["Cadastro_State"] = "Atualizado com Sucesso";
                Session["Tabela"] = "d_bordo_s1";
            }
            else
            {
                Session["Cadastro_State"] = "Erro";
            }
            return RedirectToAction("Diario_Bordo", "Diario");
        }


        [Authorize(Roles = "Adm, Usuario")]
        public ActionResult Diario_Bordo_Apagar(Int64 id)
        {
            if (Banco.Apagar_Diario_Bordo(id))
            {
                Session["Cadastro_State"] = "Sucesso";
                Session["Tabela"] = "d_bordo_s1";
                Email_Marketing Marketing = new Email_Marketing();
                Marketing.Noti_Delete(Convert.ToString(id));
            }
            else
            {
                Session["Cadastro_State"] = "Infelizmente não foi possível realizar a ação!";
            }
            return RedirectToAction("Diario_Bordo_C", "Diario");
        }
    }
}
