using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using MvcApplication4.Models;

namespace MvcApplication4.Controllers
{
    public class Body_
    {
        //
        ///Corpo do Serviço Administrativo
        //
        [Required(ErrorMessage="Campo Nome em Branco")]
        [StringLength(40, MinimumLength = 10, ErrorMessage = "Nome Curto")]
        public string Nome_User { get; set; }
        [Required(ErrorMessage = "Campo E-mail em Branco")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        [Remote("Consulta_Email", "Servicos")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Campo Ramal em Branco")]
        [StringLength(11, MinimumLength = 10, ErrorMessage = "Ramal Invalido")]
        public string Ramal { get; set; }
        [Required(ErrorMessage = "Campo Nivel em Branco")]
        public string Nivel { get; set; }
        public string[] nivel = new string[] { "","Adm", "Usuario", "Cadastrador" };
        [Required(ErrorMessage = "Campo Setor em Branco")]
        public string Setor { get; set; }
        [Required(ErrorMessage = "Campo Senha em Branco")]
        [StringLength(16, MinimumLength = 6, ErrorMessage = "Senha Curta")]
        public string Senha { get; set; }
        [System.Web.Mvc.Compare("Senha", ErrorMessage = "Senhas não Conferem")]
        [StringLength(16, MinimumLength = 6, ErrorMessage = "Senha Curta")]
        public string Conf_Senha { get; set; }
        //
        ///Corpo do Cadastro de Setor
        //
        [Required(ErrorMessage = "Campo Trabalhadores em Branco")]
        public string Qtd_Pessoas { get; set; }
        [Required(ErrorMessage = "Campo E-mail em Branco")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        public string Email_Setor { get; set; }
        //
        ///Corpo do Cadastro de Lugar
        //
        [Required(ErrorMessage = "Campo Lugar em Branco")]
        [StringLength(25, MinimumLength = 1, ErrorMessage = "Lugar Curto")]
        public string Categoria { get; set; }
        //
        ///Corpor do Diário de Bordo
        //
        public string Protocolo()
        {
            string Format = DateTime.Now.ToString("yyMMddHHss");
            return Format;
        }
        public IEnumerable<cadastro_categoria> Categorias_Select;
        public IEnumerable<cadastro_usuario> User_Select;
        public Int32 id_lugar { get; set; }
        public string t_problema { get; set; }
        public string problema { get; set; }
        public IEnumerable<Model_Body_> Listar_Bordo;
        public static cadastro_usuario User_Autenticado;
        public List<string> List_User_ON { get; set; }
    }
    public class Model_Body_
    {
        public Int64 d_bordo_s1_protocolo{get;set;}
        public Int64 d_bordo_s1_id_user { get; set; }
        public string d_bordo_s1_t_problema { get; set; }
        public string d_bordo_s1_problema { get; set; }
        public Int64 d_bordo_s1_id_categoria { get; set; }
        public string cadastro_categoria { get; set; }
        public Int64 d_bordo_s1_user_at=7;
        public DateTime d_bordo_s1_dt_at;
        public DateTime d_bordo_s1_data { get; set; }
        public string cadastro_usuario_nome { get; set; }
        public string cadastro_usuario_nome2 { get; set; }
    }
    public class Settings
    {
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        [Remote("Consulta_Email", "Servicos")]
        public string Email_Settings { get; set; }
        public string Nome_User { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        [StringLength(16, MinimumLength = 6, ErrorMessage = "Senha Curta")]
        [Required]
        public string Senha { get; set; }
        [Required(ErrorMessage="Campo Repetir Senha Obrigatória")]
        [System.Web.Mvc.Compare("Senha", ErrorMessage = "Senhas não Conferem")]
        [StringLength(16, MinimumLength = 6, ErrorMessage = "Senha Curta")]
        public string Conf_Senha { get; set; }
    }

}