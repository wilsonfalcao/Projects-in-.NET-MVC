using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projeto_Laboral.Models;

namespace Projeto_Laboral.Body
{
    public class Body_Site_Template : Projeto_Laboral.Models.db_prolaboreEntities
    {
        //Carregamento da Sessão Exibição
        public exibition_home S1_Home {get; set;}

        //Carregamento da Sessão Sobre 
        public string S_Texto_Sobre { get; set; }

        //Carregamento da Sessão Serviços
        public IEnumerable<exibition_atv> S3_Servicos { get; set; }

        //Carregamento da Sessão Time
        public IEnumerable<exibition_prf> S4_PRF { get; set; }

        //Carregamento da Sessão Galeria
        public IEnumerable<exib_gallery> S5_Galeria { get; set; }

        //Carregamenta da Sessão Clientes
        public IEnumerable<exib_client> S6_Cliente { get; set; }
    }
}