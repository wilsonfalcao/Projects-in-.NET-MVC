using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dialogica_site.Models;

namespace dialogica_site.Controllers
{
    public class HomeController : Controller
    {
        Usuario Data_User = new Usuario();
        Model_Agendamento M_Agen = new Model_Agendamento();
        

        public HomeController()
        {
            
        }


        public ActionResult Index()
        {
            Model_Agendamento M_Agen = new Model_Agendamento();
            Model_Banco Banco = new Model_Banco();
            M_Agen.Profissional = Banco.Profissionais;
            M_Agen.Associados = Banco.Associados;
            Session["Valid"] = "0";
            if (Session["Status_Agendando"] != null)
            {
                ViewBag.mensagem = Session["Status_Agendando"].ToString();
                ViewBag.nome = Session["Nome_User"].ToString();
                ViewBag.dt_ag = Session["dt_ag"].ToString();
                ViewBag.hora_con = Session["hora_con"].ToString();
                ViewBag.if_pf_esc=Session["if_pf_esc"].ToString();
                ViewBag.ordem=Session["ordem"].ToString();
            }
            return View(M_Agen);
        }

        public ActionResult Agendamento()
        {
            Model_Agendamento M_Agen = new Model_Agendamento();
            Model_Banco Banco = new Model_Banco();
            M_Agen.Profissional = Banco.Profissionais;
            M_Agen.Associados = Banco.Associados;
            Agendamento Ag_site = new Agendamento();
            ViewBag.horas = Ag_site.Drop_hora;
            return View(M_Agen);
        }
        
        [HttpPost]
        public ActionResult Agendamento(Model_Agendamento f)
        {
            Model_Banco Banco = new Model_Banco();
            Session["Valid"] = "1";
            if (Session["Valid_Login"] != null)
            {
                Data_User = Banco.Consult_Login(Session["Valid_Login"].ToString());
                Banco.Agendando_Consulta(f.Agendamento,Data_User,f.Agendamento.ordem);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                Session["dt_ag"] = f.Agendamento.dt_ag;
                Session["hora_con"] = f.Agendamento.hora_con;
                Session["if_pf_esc"] = f.Agendamento.if_pf_esc;
                Session["ordem"] = f.Agendamento.ordem;
                return RedirectToAction("Autenti_user", "Home");
            }
            return View();
        }

        public ActionResult Autenti_user()
        {
            if (Session["Status_Agendando"] != null)
            {
                ViewBag.Status_Agendando = Session["Status_Agendando"].ToString();
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login_Auten(FormCollection String_Login)
        {
            Model_Banco Banco = new Model_Banco();
            switch (Session["Valid"].ToString())
            {
                case ("0"): 
                    Data_User = Banco.Consult_Login_User(String_Login["password"], String_Login["email"]);
                    if (Data_User.nome != null)
                    {
                        Session["Valid_Login"] = Data_User.id;
                        Session["Nome_User"] = Data_User.nome;
                        Session["Status_Agendando"] = "Ok";
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                            Session["Status_Agendando"] = "Usuário ou senha invalidos...";
                            return RedirectToAction("Autenti_user", "Home");
                    }break;
                    case ("1"): Agendamento Login = new Agendamento();
                    Usuario Login1 = new Usuario();
                    Data_User = Banco.Consult_Login_User(String_Login["password"], String_Login["email"]);
                    if (Data_User.nome != null)
                    {
                        Session["Valid_Login"] = Data_User.id;
                        Session["Nome_User"] = Data_User.nome;
                        Login.dt_ag = Session["dt_ag"].ToString(); Login.hora_con = Session["hora_con"].ToString();
                        Login.if_pf_esc = Session["if_pf_esc"].ToString(); Login1.id = Data_User.id;
                        Login1.nome = Data_User.nome; Login1.email = Data_User.email;
                        if (Banco.Agendando_Consulta(Login, Login1, Session["ordem"].ToString()))
                        {
                            Session["Status_Agendando"] = "Agendado com Sucesso";
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            Session["Status_Agendando"] = "Infelizmente não conseguimos agendar. Por favor tente mais tarde...";
                        }
                    }
                    else
                    {
                        Session["Status_Agendando"] = "Usuário ou senha invalidos...";
                        return RedirectToAction("Autenti_user", "Home");
                    } 
                    break;
            
            }
            
            return View();
        }
       
        public ActionResult Cadastro_Usuario()
        {
            Model_Agendamento M_Agen = new Model_Agendamento();
            Model_Banco Banco = new Model_Banco();
            M_Agen.Profissional = Banco.Profissionais;
            M_Agen.Associados = Banco.Associados;
            Cadastro_Usuario User_Site = new Models.Cadastro_Usuario();
            ViewBag.Sexos = User_Site.sex;
            ViewBag.Tipo_End = User_Site.TP_Ende;
            ViewBag.Estado = User_Site.Estado;
            return View(M_Agen);
        }
        [HttpPost]
        public ActionResult Cadastro_Usuario(Model_Agendamento f)
        {
            Model_Banco Banco = new Model_Banco();
            if (Banco.Cadastrando_Usuario(f.Cadastro))
            {
                return RedirectToAction("Autenti_user", "Home");
            }
            else
            {
                ViewBag.Status = "Cadastro não Realizado! Por favor tente novamente ou mais tarde.";
            }
            return View();
        }

        

        [HttpPost]
        public ActionResult Enviar_Mensagem(FormCollection Valores_Form)
        {
            Email_Marketing Enviando_Mensagem = new Email_Marketing();
            Enviando_Mensagem.Mensagem_Site(Valores_Form["Email"], Valores_Form["Assunto"], Valores_Form["Menssagem"], Valores_Form["Nome"]);
            return RedirectToAction("Index", "Home");
        }


        //Validações Remotas
        public JsonResult Consultar_Email(Model_Agendamento user)
        {
            Model_Banco Banco = new Model_Banco();
            bool Resultado = false;
            Resultado = Banco.Consult_Email(user.Cadastro.email);
            if (Resultado)
            {
                return Json(Resultado, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("E-mail já cadastrado", JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult Consultar_Data(Model_Agendamento data)
        {
            Model_Banco Banco = new Model_Banco();
            bool Resultado = false;
            Resultado = Banco.Consult_Agedamento(data.Agendamento.dt_ag.ToString());
            if (Resultado)
            {
                return Json(Resultado, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Não Podemos Agendar para esta Data.", JsonRequestBehavior.AllowGet);
            }
            
        }
        public JsonResult Consultar_Hora(Model_Agendamento hora, Model_Agendamento data)
        {
            Model_Banco Banco = new Model_Banco();
            bool Resultado = false;
            Resultado = Banco.Consult_Agendamento_Hora(hora.Agendamento.hora_con.ToString(),data.Agendamento.dt_ag.ToString());
            if (Resultado)
            {
                return Json(Resultado, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Não Podemos Agendar para esta Horário.", JsonRequestBehavior.AllowGet);
            }

        }
}
}