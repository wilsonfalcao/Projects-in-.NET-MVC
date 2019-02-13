using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using MvcApplication4.Models;

namespace MvcApplication4.Controllers
{
    public class Email_Marketing
    {
        public bool Noti_Insert(Body_ Corpo, string protocolo,string EmailOpcional)
        {
            Model_Banco_Services Banco = new Model_Banco_Services();
            //Consultando Mais Informações
            string Categoria = Banco.Consulta_Categoria(Corpo.id_lugar).ToString();
            string Nome = Banco.Consulta_Pessoa(Convert.ToInt16(Body_.User_Autenticado.id_user)).ToString();
            List<string> Destinatario_ = new List<string>(Banco.Consultar_Email());
            if (EmailOpcional != null)
            {
                Destinatario_.Add(EmailOpcional);
            }
            bool valid = false;
            string Montando_Copor_HTML = null;
            Montando_Copor_HTML = "<html><body><h1><b>Novo Diario de Bordo Criado</b></h1>"+
                                  "<p><b>Por:&nbsp;</b>" + Body_.User_Autenticado.nome + "</p><p><b>Data:&nbsp;</b>" + DateTime.Now.ToString("dd/MM/yyyy") +
                                  "</p><div class='panel panel-primary'><div class='panel-heading'><b>Assunto:&nbsp;</b>" + Corpo.t_problema + "<b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Protocolo:&nbsp;</b>" +
                                  protocolo + @"</div> <div style='blockquote{display:block;background: #fff;padding: 15px 20px 15px 45px;margin: 0 0 20px;position:"+
                                  "relative;font-family: Georgia, serif;font-size: 16px;line-height: 1.2;color: #666;text-align: justify;/*Borders - (Optional)*/border-left:"+ 
                                  "15px solid #c76c0c;border-right: 2px solid #c76c0c;/*Box Shadow - (Optional)*/-moz-box-shadow: 2px 2px 15px #ccc;-webkit-box-shadow: 2px 2px"+
                                  @"15px #ccc;box-shadow: 2px 2px 15px #ccc;}blockquote::before{content: '\201C'; /*Unicode for Left Double Quote*//*Font*/font-family: Georgia,"+
                                  " serif;font-size: 60px;font-weight: bold;color: #999;/*Positioning*/position: absolute;left: 10px;top:5px;}blockquote::after{/*Reset to make sure*/content:"+
                                  "'';}blockquote a{text-decoration: none;background: #eee;cursor: pointer;padding: 0 3px;color: #c76c0c;}blockquote a:hover{color: #666;}blockquote em{font-style: italic;}>" + 
                                  "<blockquote>"+
                                  Corpo.problema+
                                  "</blockquote></div>"+
                                  "</div><p><b>Categoria:&nbsp;</b>" + Categoria + "</p>" +
                                  "<p><a class='btn btn-primary btn-lg' href='http://google.com.br' role='button'>Ir para o Sistema</a></p></div></body></html>";
            valid = Enviar_Action(Montando_Copor_HTML, Destinatario_, "Diário de Bordo Cadastrado com Sucesso [" + protocolo.ToString() + "]");
            return valid;
        }
        public bool Noti_Delete(string protocolo)
        {
            Model_Banco_Services Banco = new Model_Banco_Services();
            bool valid = false;
            string Montando_Copor_HTML = null;
            List<string> Destinatario_ = new List<string>(Banco.Consultar_Email());
            valid = Enviar_Action(Montando_Copor_HTML, Destinatario_, "Diário de Bordo Apagado com Sucesso [" + protocolo.ToString() + "]");
            return valid;
        }


        //Modelo de Negócio
        private bool Enviar_Action(string corpo, List<string> destinatario, string Assunto)
        {
            bool Valid = true;
            // Instanciando a Classe Mail
            MailMessage Email_Process = new MailMessage();
            /* Atribuição de valores que será correspondente aos campos
             * de referencia da menssagem*/
            //E-mail receptivo
            Email_Process.From = new MailAddress(Body_.User_Autenticado.email.ToString());//caso queira outro so basta colocar entre as aspas
            //Campo referente de destinatário
            for (int cont = 0; cont < destinatario.Count(); cont++)
            {
                Email_Process.CC.Add(destinatario[cont]);//Email que é um paramentro do metodo Resposta retorna o valor do Campo_Email
                //Assunto
            }
            Email_Process.Subject = Assunto;//Assunto retorna o valor do Campo só de leitura assunto, DateTime é so para constar a data
            //Ativando o tipo menssagem com HTML
            Email_Process.IsBodyHtml = true;
            //Template Html
            //Passando valor a instancia
            Email_Process.Body = corpo;
            // Estancia a Classe de Envio
            SmtpClient Email_Sending = new SmtpClient("smtp.live.com");
            Email_Sending.Port = 25;
            Email_Sending.EnableSsl = true;
            //Email_Sending.EnableSsl = true;
            // Credencial para envio por SMTP Seguro (Quando o servidor exige autenticação)
            Email_Sending.Credentials = new System.Net.NetworkCredential("wilson.falcao1@hotmail.com", "WilsoneAna30");
            //Email_Sending.EnableSsl = true;
            // Envia a mensagem e retorna valor a label Status
            try
            {
                Email_Sending.Send(Email_Process);
            }
            catch (Exception Erro)
            {
                string txt = Erro.Message;
                Valid = false;
            }
            return Valid;
        }
    }
}