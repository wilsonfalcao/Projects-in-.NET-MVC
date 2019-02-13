using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcApplication4.Controllers;
using MvcApplication4.Models;

namespace MvcApplication4.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        Model_Banco_Services Banco = new Model_Banco_Services();

        public ActionResult Index()
        {
            if (TempData["Status_Autenticacao"] != null)
            {
                ModelState.AddModelError(string.Empty, TempData["Status_Autenticacao"].ToString());
            }
            return View();
        }

        [HttpPost]
        public ActionResult L_Auten(FormCollection String_Autenticacao,string returnUrl)
        {
            // Lets first check if the Model is valid or not
            if (ModelState.IsValid)
            {
                using (Models.db_moradaEntities entities = new Models.db_moradaEntities())
                {
                    string login = String_Autenticacao["usuario"];
                    string senha = String_Autenticacao["senha"];
                    entities.Database.Connection.Open();
                    // Now if our password was enctypted or hashed we would have done the
                    // same operation on the user entered password here, But for now
                    // since the password is in plain text lets just authenticate directly
                    bool userValid = entities.cadastro_usuario.Any(user => user.email == login && user.senha == senha);
                    // User found in the database
                    if (userValid)
                    {
                        Models.cadastro_usuario User = entities.cadastro_usuario.SingleOrDefault(u => u.email == login);
                        FormsAuthentication.SetAuthCookie(User.email, true);
                        FormsAuthenticationTicket Passe = new FormsAuthenticationTicket(User.email, true, 10);
                        string encryptTicket = FormsAuthentication.Encrypt(Passe);
                        HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptTicket);
                        Response.Cookies.Add(authCookie);
                        if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                            && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Tela_RP", "Login");
                        }
                    }
                    else
                    {
                        TempData["Status_Autenticacao"] = "Usuário ou Senha Invalidos!";
                        return RedirectToAction("Index", "Login");
                    }
                    entities.Database.Connection.Close();
                }
            }
            return View();
        }
        
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Login");
        }

        public ActionResult Settings()
        {
            Settings Corpo_Settings = new Settings();
            ViewBag.Cadastro_State = "";
            if (Session["Cadastro_State"] != null)
            {
                ViewBag.Cadastro_State = Session["Cadastro_State"].ToString();
                ViewBag.Tabela = Session["Tabela"].ToString();
                Session["Cadastro_State"] = null;
            }
            return View(Corpo_Settings);
        }

        [HttpPost]
        public ActionResult Settings(FormCollection Data_Settings)
        {
            Settings Corpo_Settings = new Settings();
            Corpo_Settings.Senha = Data_Settings["Senha"].ToString();
            if(Banco.Atualizar_Cadastro_User(Corpo_Settings,Body_.User_Autenticado.id_user.ToString()))
            {
                Session["Cadastro_State"] = "Sucesso";
                Session["Tabela"] = "cadastro_user";
            }
            else
            {
                Session["Cadastro_State"] = "Erro";
            }
            return RedirectToAction("Settings", "Login");
        }

        [Authorize]
        public ActionResult Tela_RP()
        {
            ViewBag.Nome_User = Body_.User_Autenticado.nome.ToString();
            return View();
        }
    }
}
