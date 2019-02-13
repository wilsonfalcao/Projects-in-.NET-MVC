using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace dialogica_site.Models
{
    public class Email_Marketing
    {
        public bool Noti_Consulta(string ordem, Agendamento Data, Usuario User )
        {
            bool valid = false;
            string Montando_Copor_HTML = null;
            string[] destinatario = new string[2];
            destinatario[0]=User.email;
            destinatario[1] = "wilson.falcao1@hotmail.com";
            Model_Banco Banco = new Model_Banco();
            string Profissional = Banco.Consult_Profissional(Data.if_pf_esc);
            Montando_Copor_HTML = "<!DOCTYPE html PUBLIC '-//W3C//DTD HTML 4.01//EN' 'http://www.w3.org/TR/html4/strict.dtd'>"+
                                   "<html xmlns='http://www.w3.org/1999/xhtml' xml:lang='en'><head><meta content='text/html; charset=utf-8' http-equiv='Content-Type' />"+	
		                            "<title>Newsletter template - Gretta&#146;s Garden Goods<</title><!--general stylesheet--><style type='text/css'>p { padding: 0; margin: 0; }"+
			                        "h1, h2, h3, p, li { font-family: Helvetica, Arial, sans-serif; }td { vertical-align:top;}ul, ol { margin: 0; padding: 0;}</style>"+
	                                "</head><body marginheight='0' topmargin='0' marginwidth='0' leftmargin='0' style='margin: 0px; background-color: #edf5e4;' bgcolor='#edf5e4'>"+
		                            "<table cellspacing='0' border='0' cellpadding='0' width='100%' bgcolor='#edf5e4'><tbody><tr valign='top'><td valign='top'><!--container-->"+
						            "<table cellspacing='0' cellpadding='0' border='0' align='center' width='655' height='1000'><tbody><tr><!--content--><td valign='top'>"+
									"<table cellspacing='0' cellpadding='0' border='0' align='center' width='600' height='83' style=''><tbody><tr><td valign='top' height='20'>&nbsp;"+
									"</td></tr><tr><td valign='top' style='text-align:center;'><p style='margin:0; padding-bottom: 3px; padding-top: 3px; color:#b7c0ab; font-size: 12px;"+
                                    "text-align:center; font-family: Arial, Helvetica;'> Você esta recebendo uma notificação de agendamento</p>"+
									"</td></tr><tr><td valign='top' style='text-align:center;'><p style='margin:0; padding-bottom: 3px; padding-top: 3px; color:#b7c0ab; font-size: 12px;"+
                                    "text-align: center; font-family: Arial, Helvetica;'>Caso não queira a mensagem por favor igonorar este E-mail<webversion  style='color:#959d8c; font-size:12px; font-weight:bold;"+
                                    "font-style: normal; text-decoration:none;'></webversion>.</p></td></tr><tr><td valign='top' height='20'>&nbsp;</td></tr></tbody>"+
								    "</table><table cellspacing='0' cellpadding='0' border='0' align='center' width='600' bgcolor='#ffffff'><tbody>"+
								    "<tr><td colspan='2' valign='top' height='84'><img width='30' height='84' src='http://scrips.xpg.uol.com.br/ana2s/tl-corner.jpg' alt='' style='display: block;' />"+
								    "</td><td valign='top' height='84' style='vertical-align:top'><table cellspacing='0' cellpadding='0' border='0' align='center' height='78'>"+
									"<tbody><tr><td valign='top' height='15'><img width='540' height='15' src='http://scrips.xpg.uol.com.br/ana2s/top-bar.jpg' alt='' style='display: block;'  />"+
								    "</td></tr><tr><td valign='top'><table cellspacing='0' cellpadding='0' border='0' align='center' width='540'><tbody><tr><td valign='middle' style='vertical-align:middle;'>"+
                                    "<h1 style='margin:0; padding:0; font-size:34px; font-style: italic; font-weight: normal; font-family: Monotype Corsiva; color:#7cc39e;'>" +
                                    "Espaço Dialógica<h1>" +
									"</td><td valign='middle' width='157' style='vertical-align:middle;'><table cellspacing='0' cellpadding='0' border='0' width='157' align='center'>"+
									"<tbody><tr><td valign='top' height='19' width='157' bgcolor='#e9e6c8' background='http://scrips.xpg.uol.com.br/ana2s/date-bg.jpg' style='background-image: url('images/date-bg.jpg'); background-position: center center; background-repeat: no-repeat;'>"+
									"<h2 class='date' style='margin:0; padding:0; width:157px; height:19px; font-size:9px; font-style: normal; font-family: Georgia; text-transform:uppercase; letter-spacing:2px; text-align:center; vertical-align:middle; color:#959d8c; '>"+
                                    "<span style='display:block; width:157px; padding-top:5px;'>" + DateTime.Now.ToShortDateString().ToString() + "</span></h2></td></tr></tbody></table></td>" +
									"</tr></tbody></table></td></tr><tr><td valign='top' height='20'><img width='540' height='10' src='http://scrips.xpg.uol.com.br/ana2s/divider-1.jpg' alt='' style='display: block; padding-top: 10px;'  />"+
									"</td></tr></tbody></table></td><td colspan='2' valign='top' height='84'><img width='30' height='84' src='http://scrips.xpg.uol.com.br/ana2s/tr-corner.jpg' alt='' style='display: block;' />"+
									"</td></tr><tr><td width='8' valign='top' bgcolor='#bec5b6;' style='background-color:#bec5b6;'>&nbsp;"+
									"</td><td width='22' valign='top'>&nbsp;</td><td valign='top' width='540'>"+
									"<table cellspacing='0' cellpadding='0' border='0' align='center'><tr><td valign='top' style='padding-top:14px;'><h2 style='margin:0; padding:0; color:#7cc39e; font-size:22px; font-weight:bold; font-family: Helvetica;'>Informações Sobre a Empresa</h2>"+
									"<img width='540' height='6' src='http://scrips.xpg.uol.com.br/ana2s/divider-2.jpg' alt='' style='display: block; padding-top: 10px;' /> </td></tr><tr><td valign='top' height='12px;' style='height:12px;'>&nbsp;</td></tr>"+
                                    "<tr><td valign='top'> <p style='margin:0; font-size:14px; line-height:22px; color:#959d8c; font-weight:normal;text-align:justify; font-family: Georgia;'>" +
								    "Neste espaço você desfrutará de um ambiente confortável, com instalações de qualidade, em meio a muita tranquilidade onde a prática da psicologia é exercida com excelência."+
                                    "Localizada no centro do Recife, possui fácil acesso através de diferentes meios de transporte. É um espaço que oferece atendimento clínico através da escuta psicoterapêutica a crianças, adolescentes, adultos,  idosos."+
                                    "O Espaço Psicoterapêutico Dialógica se destaca pelos profissionais qualificados, em constante atualização em áreas afins da psicologia, proporcionando qualidade e segurança nos atendimentos aos seus clientes."+
                                    "O nosso objetivo é contribuir para o bem estar psicológico das pessoas, fazendo com que os nossos clientes se sintam acolhidos, oferecendo um serviço de atendimento diferenciado.</br></br>"+
                                    "CONSULTÓRIO PSICOLÓGICO FERNANDES, CHAGAS E RESENDE LTDA.</br>"+
                                    "CNPJ.: 22.043.388/0001-40   Sociedade Simples"+
								    "</p></td></tr><tr><td valign='top' height='35px;' style='height:35px;'>&nbsp;</td></tr><tr><td valign='top'>"+
									"<h2 style='margin:0; padding:0; color:#7cc39e; font-size:22px; font-weight:bold; font-family: Helvetica;'>Como Chegar ao Local?</h2>"+
                                    "<img width='540' height='6'src='http://scrips.xpg.uol.com.br/ana2s/divider-2.jpg' alt='' style='display: block; padding-top: 10px;' />"+
									"</td></tr><tr><td valign='top' height='12px;' style='height:12px;'>&nbsp;</td>"+
									"</tr><td valign='top'><div style='text-align:left; float: left; padding-bottom: 10px; padding-right: 10px;'>"+
									"</div><p style='margin:0; font-size:14px; line-height:22px; color:#959d8c; font-weight:normal; font-family: Georgia;'>"+
                                    "<img width='100%' height='350'src='http://scrips.xpg.uol.com.br/ana2s/mapa.png' alt='' style='display: block; padding-top: 10px;' />"+
                                    "End.: Rua Gervásio Pires, 234 – Soledade – Recife/PE CEP.: 50.060-90<br>"+
                                    "Edifício Comercial Brasil Norte – Sala – 1003</p></td></tr><tr><td valign='top' height='35px;' style='height:35px;'>&nbsp;</td></tr>"+
                                    "<tr><td valign='top'><h2 style='margin:0; padding:0; color:#7cc39e; font-size:22px; font-weight:bold; font-family: Helvetica;'>Informações do Cliente</h2>"+
                                    "<img width='540' height='6'src='http://scrips.xpg.uol.com.br/ana2s/divider-2.jpg' alt='' style='display: block; padding-top: 10px;' />"+
									"</td></tr><tr><td valign='top' height='12px;' style='height:12px;'>&nbsp;</td>"+
									"</tr><td valign='top'><div style='text-align:left; float: left; padding-bottom: 10px; padding-right: 10px;'>"+
									"</div><p style='margin:0; font-size:14px; line-height:22px; color:#959d8c; font-weight:normal; font-family: Georgia;'>"+
                                    "<strong style='color:#d8d498; font-family:Arial;'>Ordem Número:</strong>&nbsp&nbsp" + ordem + "</br><strong style='color:#d8d498; font-family:Arial;'>Nome do Cliente:</strong>&nbsp&nbsp" + User.nome + "</br>" +
                                    "<strong style='color:#d8d498; font-family:Arial;'>Data de Consulta:</strong>&nbsp&nbsp" + Data.dt_ag + "</br><strong style='color:#d8d498; font-family:Arial;'>Horário de Consulta:</strong>&nbsp&nbsp" + Data.hora_con + "<br>" +
                                    "<strong style='color:#d8d498; font-family:Arial;'>Psicóloga(o):</strong>&nbsp&nbsp"+Profissional+"<br><strong style='color:#d8d498; font-family:Arial;'>Observações do Cliente:</strong>&nbsp&nbsp" + Data.observe + "<br></p></td>" +
                                    "</tr></table></td><td width='22' valign='top'>&nbsp;</td><td width='8' valign='top' bgcolor='#bec5b6;' style='background-color:#bec5b6;'>&nbsp;"+
								    "</td></tr><tr><td valign='top' colspan='5'><img width='600' height='188' src='http://scrips.xpg.uol.com.br/ana2s/bottom.jpg' alt='' style='display: block;' />"+
								    "</td></tr></tbody></table></td><!--/content--></tr></tbody></table><!--/container--></td></tr></tbody></table></body></html>';";
            valid = Enviar_Action(Montando_Copor_HTML, destinatario, "Notificação de Agendamento de Consulta ORDEM: " + ordem);
            return valid;
        }
        public bool Span_Dialogica()
        {
            return true;
        }
        public bool Mensagem_Site(string email, string assunto, string mensagem,string nome )
        {
            bool valid = false;
            string Montando_Copor_HTML = null;
            string[] destinatario = new string[2];
            destinatario[0]= email;
            destinatario[1] = "sac@psidialogica.com.br";
            Montando_Copor_HTML = "<html><body>Sistema de Mensagem Dialógica 2015.2S</br></br>" +
                                  "Enviado por:&nbsp&nbsp"+nome+"</br></br>"+
                                  "Mensagem:<br>" + mensagem + "</br></br>" + "E-mail para contato:&nbsp&nbsp"+email +"<br><br></body></html>" + DateTime.Now.ToShortDateString().ToString();
            valid = Enviar_Action(Montando_Copor_HTML, destinatario, "Sistema de Mensagem::. " + assunto+" "+DateTime.Now.ToShortDateString());
            return valid;
        }
        public bool Noti_Cadastro(string email, string nome, string senha)
        {
            bool valid = false;
            string Montando_Copor_HTML = null;
            string[] destinatario = new string[2];
            destinatario[0] = email;
            destinatario[1] = "sac@psidialogica.com.br";
            Montando_Copor_HTML = "<!DOCTYPE html PUBLIC '-//W3C//DTD HTML 4.01//EN' 'http://www.w3.org/TR/html4/strict.dtd'>" +
                                   "<html xmlns='http://www.w3.org/1999/xhtml' xml:lang='en'><head><meta content='text/html; charset=utf-8' http-equiv='Content-Type' />" +
                                    "<title>Newsletter template - Gretta&#146;s Garden Goods<</title><!--general stylesheet--><style type='text/css'>p { padding: 0; margin: 0; }" +
                                    "h1, h2, h3, p, li { font-family: Helvetica, Arial, sans-serif; }td { vertical-align:top;}ul, ol { margin: 0; padding: 0;}</style>" +
                                    "</head><body marginheight='0' topmargin='0' marginwidth='0' leftmargin='0' style='margin: 0px; background-color: #edf5e4;' bgcolor='#edf5e4'>" +
                                    "<table cellspacing='0' border='0' cellpadding='0' width='100%' bgcolor='#edf5e4'><tbody><tr valign='top'><td valign='top'><!--container-->" +
                                    "<table cellspacing='0' cellpadding='0' border='0' align='center' width='655' height='1000'><tbody><tr><!--content--><td valign='top'>" +
                                    "<table cellspacing='0' cellpadding='0' border='0' align='center' width='600' height='83' style=''><tbody><tr><td valign='top' height='20'>&nbsp;" +
                                    "</td></tr><tr><td valign='top' style='text-align:center;'><p style='margin:0; padding-bottom: 3px; padding-top: 3px; color:#b7c0ab; font-size: 12px;" +
                                    "text-align:center; font-family: Arial, Helvetica;'> Você esta recebendo uma notificação de Cadastro</p>" +
                                    "</td></tr><tr><td valign='top' style='text-align:center;'><p style='margin:0; padding-bottom: 3px; padding-top: 3px; color:#b7c0ab; font-size: 12px;" +
                                    "text-align: center; font-family: Arial, Helvetica;'>Por favor igonorar este E-mail<webversion  style='color:#959d8c; font-size:12px; font-weight:bold;" +
                                    "font-style: normal; text-decoration:none;'></webversion>.</p></td></tr><tr><td valign='top' height='20'>&nbsp;</td></tr></tbody>" +
                                    "</table><table cellspacing='0' cellpadding='0' border='0' align='center' width='600' bgcolor='#ffffff'><tbody>" +
                                    "<tr><td colspan='2' valign='top' height='84'><img width='30' height='84' src='http://scrips.xpg.uol.com.br/ana2s/tl-corner.jpg' alt='' style='display: block;' />" +
                                    "</td><td valign='top' height='84' style='vertical-align:top'><table cellspacing='0' cellpadding='0' border='0' align='center' height='78'>" +
                                    "<tbody><tr><td valign='top' height='15'><img width='540' height='15' src='http://scrips.xpg.uol.com.br/ana2s/top-bar.jpg' alt='' style='display: block;'  />" +
                                    "</td></tr><tr><td valign='top'><table cellspacing='0' cellpadding='0' border='0' align='center' width='540'><tbody><tr><td valign='middle' style='vertical-align:middle;'>" +
                                    "<h1 style='margin:0; padding:0; font-size:34px; font-style: italic; font-weight: normal; font-family: Monotype Corsiva; color:#7cc39e;'>" +
                                    "Espaço Psicoterapêutico Dialógica<h1>" +
                                    "</td><td valign='middle' width='157' style='vertical-align:middle;'><table cellspacing='0' cellpadding='0' border='0' width='157' align='center'>" +
                                    "<tbody><tr><td valign='top' height='19' width='157' bgcolor='#e9e6c8' background='http://scrips.xpg.uol.com.br/ana2s/date-bg.jpg' style='background-image: url('images/date-bg.jpg'); background-position: center center; background-repeat: no-repeat;'>" +
                                    "<h2 class='date' style='margin:0; padding:0; width:157px; height:19px; font-size:9px; font-style: normal; font-family: Georgia; text-transform:uppercase; letter-spacing:2px; text-align:center; vertical-align:middle; color:#959d8c; '>" +
                                    "<span style='display:block; width:157px; padding-top:5px;'>" + DateTime.Now.ToShortDateString().ToString() + "</span></h2></td></tr></tbody></table></td>" +
                                    "</tr></tbody></table></td></tr><tr><td valign='top' height='20'><img width='540' height='10' src='http://scrips.xpg.uol.com.br/ana2s/divider-1.jpg' alt='' style='display: block; padding-top: 10px;'  />" +
                                    "</td></tr></tbody></table></td><td colspan='2' valign='top' height='84'><img width='30' height='84' src='http://scrips.xpg.uol.com.br/ana2s/tr-corner.jpg' alt='' style='display: block;' />" +
                                    "</td></tr><tr><td width='8' valign='top' bgcolor='#bec5b6;' style='background-color:#bec5b6;'>&nbsp;" +
                                    "</td><td width='22' valign='top'>&nbsp;</td><td valign='top' width='540'>" +
                                    "<table cellspacing='0' cellpadding='0' border='0' align='center'><tr><td valign='top' style='padding-top:14px;'><h2 style='margin:0; padding:0; color:#7cc39e; font-size:22px; font-weight:bold; font-family: Helvetica;'>Informações Sobre a Empresa</h2>" +
                                    "<img width='540' height='6' src='http://scrips.xpg.uol.com.br/ana2s/divider-2.jpg' alt='' style='display: block; padding-top: 10px;' /> </td></tr><tr><td valign='top' height='12px;' style='height:12px;'>&nbsp;</td></tr>" +
                                    "<tr><td valign='top'> <p style='margin:0; font-size:14px; line-height:22px; color:#959d8c; font-weight:normal;text-align:justify; font-family: Georgia;'>" +
                                    "Neste espaço você desfrutará de um ambiente confortável, com instalações de qualidade, em meio a muita tranquilidade onde a prática da psicologia é exercida com excelência." +
                                    "Localizada no centro do Recife, possui fácil acesso através de diferentes meios de transporte. É um espaço que oferece atendimento clínico através da escuta psicoterapêutica a crianças, adolescentes, adultos,  idosos." +
                                    "O Espaço Psicoterapêutico Dialógica se destaca pelos profissionais qualificados, em constante atualização em áreas afins da psicologia, proporcionando qualidade e segurança nos atendimentos aos seus clientes." +
                                    "O nosso objetivo é contribuir para o bem estar psicológico das pessoas, fazendo com que os nossos clientes se sintam acolhidos, oferecendo um serviço de atendimento diferenciado.</br></br>" +
                                    "CONSULTÓRIO PSICOLÓGICO FERNANDES, CHAGAS E RESENDE LTDA.</br>" +
                                    "CNPJ.: 22.043.388/0001-40   Sociedade Simples" +
                                    "</p></td></tr><tr><td valign='top' height='35px;' style='height:35px;'>&nbsp;</td></tr><tr><td valign='top'>" +
                                    "<h2 style='margin:0; padding:0; color:#7cc39e; font-size:22px; font-weight:bold; font-family: Helvetica;'>Informações de Cadastramento</h2>" +
                                    "<img width='540' height='6'src='http://scrips.xpg.uol.com.br/ana2s/divider-2.jpg' alt='' style='display: block; padding-top: 10px;' />" +
                                    "</td></tr><td valign='top'><div style='text-align:left; float: left; padding-bottom: 10px; padding-right: 10px;'>" +
                                    "</div><p style='margin:0; font-size:14px; line-height:22px; color:#959d8c; font-weight:normal; font-family: Georgia;'>" +
                                    "<strong style='color:#d8d498; font-family:Arial;'>Nome:</strong>&nbsp&nbsp" + nome + "</br><strong style='color:#d8d498; font-family:Arial;'>E-mail:</strong>&nbsp&nbsp" + email + "</br>" +
                                    "<strong style='color:#d8d498; font-family:Arial;'>Senha:</strong>&nbsp&nbsp" + senha + "</p></td>" +
                                    "</tr></table></td><td width='22' valign='top'>&nbsp;</td><td width='8' valign='top' bgcolor='#bec5b6;' style='background-color:#bec5b6;'>&nbsp;" +
                                    "</td></tr><tr><td valign='top' colspan='5'><img width='600' height='188' src='http://scrips.xpg.uol.com.br/ana2s/bottom.jpg' alt='' style='display: block;' />";
            valid = Enviar_Action(Montando_Copor_HTML, destinatario,"Notificação de Cadastro:. ESPAÇO PSICOTERAPÊUTICO DIALÓGICA");
            return valid;
        }


        //Modelo de Negócio
        private bool Enviar_Action(string corpo, string[] destinatario,string Assunto)
        {
            string Email = null;
            bool Valid = true, valid_caracter = false;
            string Email_Convert = null;
            for (int cont = 0; cont < Convert.ToInt16(destinatario.Length); cont++)
            {
                if (destinatario.Length > 1)
                {
                    Email += destinatario[cont] + ",";
                    valid_caracter = true;
                }
                else
                {
                    Email_Convert += destinatario[cont];
                }
            }
            if (valid_caracter == true) { int cont_string = Email.Length; Email_Convert = Email.Substring(0, cont_string - 1); }
            // Instanciando a Classe Mail
            MailMessage Email_Process = new MailMessage();
            /* Atribuição de valores que será correspondente aos campos
             * de referencia da menssagem*/
            //E-mail receptivo
            Email_Process.From = new MailAddress("sac@psidialogica.com.br");//caso queira outro so basta colocar entre as aspas
            //Campo referente de destinatário
            Email_Process.CC.Add(Email_Convert);//Email que é um paramentro do metodo Resposta retorna o valor do Campo_Email
            //Assunto
            Email_Process.Subject = Assunto;//Assunto retorna o valor do Campo só de leitura assunto, DateTime é so para constar a data
            //Ativando o tipo menssagem com HTML
            Email_Process.IsBodyHtml = true;
            //Template Html
            //Passando valor a instancia
            Email_Process.Body = corpo;
            // Estancia a Classe de Envio
            SmtpClient Email_Sending = new SmtpClient("mail.psidialogica.com.br");
            Email_Sending.Port = 587;
            //Email_Sending.EnableSsl = true;
            // Credencial para envio por SMTP Seguro (Quando o servidor exige autenticação)
            Email_Sending.Credentials = new System.Net.NetworkCredential("webmaster@psidialogica.com.br", "W945766@@");
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