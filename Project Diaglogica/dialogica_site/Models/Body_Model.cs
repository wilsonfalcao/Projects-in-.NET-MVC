using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
namespace dialogica_site.Models
{

    public class Profissional
    {
        public string id;
        public string Ender_img;
        public string Facebook;
        public string Linkedin;
        public string Nome;
        public string Frase;
        public string Funcao;
        public string crp;
        public string ht;
        public string tel;
    }

    public class Agendamento
    {
        public string[] Drop_hora = new string[] { "","00:00", "01:00", "02:00", "03:00", "04:00", "05:00", "06:00", "07:00", "08:00", "09:00",
                                                   "10:00","11:00","12:00","13:00","14:00","15:00","16:00","17:00","18:00","19:00","20:00"};
        public string ordem { get { return ordem_now(); } set { ordem = value; } } 

        [Required(ErrorMessage = "Campo data Hora em Branco")]
        [Remote("Consultar_Data","Home")]
        public string dt_ag{get;set;}

        [Required(ErrorMessage = "Campo data Hora em Branco")]
        [Remote("Consultar_Hora","Home",AdditionalFields="dt_ag")]
        public string hora_con { get; set; }

        [Required(ErrorMessage = "Escolha o Profissional Disponível")]
        public string if_pf_esc { get; set; }

        public string observe { get; set; }

        //Método

        private string ordem_now()
        {
            DateTime hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
            string retorno = hora.ToString("yyMMddHmmss");
            return retorno;
        }

    }

    public class Model_Agendamento
    {
        public IEnumerable<Profissional> Profissional { get; set; }
        public Agendamento Agendamento { get; set; }
        public Usuario Usuario { get; set; }
        public IEnumerable<Profissional> Associados { get; set; }
        public Cadastro_Usuario Cadastro { get; set; }
        public List<Grafico_Valores> Grafico_Valores { get; set; }
    }

    public class Usuario
    {
        public string nome;
        public string id;
        public string email;
        public string password;
    }

    public class Cadastro_Usuario
    {
        public string id { get { return id_now(); } set { id = value; } } 

        [StringLength(30, MinimumLength = 10,ErrorMessage="Nome Curto")]
        [Required(ErrorMessage = "Campo em branco")]
        public string nome{get;set;}
        public string[] sex = new string[] { "M", "H", "L", "T", "G" };
        [Required(ErrorMessage = "Campo em branco..")]
        public char Sexo{get;set;}
        [StringLength(11, MinimumLength = 11,ErrorMessage="CPF Inválido")]
        [Required(ErrorMessage = "Campo em branco")]
        public string CPF{get;set;}
        [StringLength(10, MinimumLength = 10,ErrorMessage="Não Confere")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public string data_nascimento{get;set;}
        [StringLength(11, MinimumLength = 11)]
        [Required(ErrorMessage = "Campo em branco")]
        public string tel { get; set; }
        //consultar ele em banco
        [Required(ErrorMessage = "Campo em branco")]
        [StringLength(30, MinimumLength = 11)]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        [Remote("Consultar_Email", "Home")]
        public string email { get; set; }

        [Required(ErrorMessage = "Campo em branco")]
        [StringLength(8, MinimumLength = 8,ErrorMessage="Inválido")]
        public string cep { get; set; }
        [Required(ErrorMessage = "Campo em branco")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Endereço Curto")]
        public string end { get; set; }
        public string[] TP_Ende = new string[] { "Apartamento", "Casa", "Flat" };
        public string tp_end { get; set; }
        [Required(ErrorMessage = "Campo em branco..")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Bairro Curto")]
        public string bairro { get; set; }
        [Required(ErrorMessage = "Campo em branco..")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Cidade Curta")]
        public string cidade { get; set; }
        public string[] Estado = new string[] { "PE", "BH", "BA", "PB", "CE", "SE", "TO", "MA", "RN" };
        public string estado { get; set; }
        [Required(ErrorMessage = "Campo em branco..")]
        public string nm { get; set; }
        [Required(ErrorMessage = "Campo em branco..")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Senha Fraca")]
        public string senha { get; set; }
        [Required(ErrorMessage = "Campo em branco..")]
        [System.Web.Mvc.Compare("senha",ErrorMessage="senha não confere")]
        public string verifica_senha { get; set; }

        private string id_now()
        {
            DateTime hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
            string retorno = hora.ToString("ssmmHddMM");
            return retorno;
        }
    }

    public class Grafico_Valores
    {
        public string nome;
        public Int64 quantidade;
        public DateTime data;
        public decimal faturamento;
        public bool validacao;
        public Int64 validacao_tp2;
        public string mensagem;
        public string src;
    }
}