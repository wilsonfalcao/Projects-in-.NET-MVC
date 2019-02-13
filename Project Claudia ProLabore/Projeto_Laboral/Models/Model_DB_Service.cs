using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projeto_Laboral.Body;

namespace Projeto_Laboral.Models
{
    public class Model_DB_Service
    {
        public Body_Site_Template Carregamento_Home()
        {
           Body_Site_Template V_Return_C_I1 = new Body_Site_Template();
            using (var Context = new Models.db_prolaboreEntities ())
            {
                var V_Return_C_I2 = Context.exibition_home.OrderBy(x => x.data).FirstOrDefault();
                V_Return_C_I1.S1_Home = V_Return_C_I2;
            }
            return V_Return_C_I1;
        }
        public Body_Site_Template Carregamento_Servicos()
        {
            Body_Site_Template V_Return_C_I1 = new Body_Site_Template();
            using (var Context = new Models.db_prolaboreEntities())
            {
                var V_Return_C_I2 = Context.exibition_atv.Where(x => x.id > 0).ToArray();
                V_Return_C_I1.S3_Servicos = V_Return_C_I2;
            }
            return V_Return_C_I1;
        }

        public Body_Site_Template Carregamento_Profissional()
        {
            Body_Site_Template V_Return_C_I1 = new Body_Site_Template();
            using (var Contex = new Models.db_prolaboreEntities())
            {
                var V_Return_C_I2 = Contex.exibition_prf.Where(x => x.exb == 1).ToArray();
                V_Return_C_I1.S4_PRF = V_Return_C_I2;
            }
            return V_Return_C_I1;
        }
        public Body_Site_Template Carregamento_Gallery()
        {
            Body_Site_Template V_Return_C_I1 = new Body_Site_Template();
            using (var Context = new Models.db_prolaboreEntities())
            {
                var V_Return_C_I2 = Context.exib_gallery.OrderBy(x => x.data).Take(6).ToArray();
                V_Return_C_I1.S5_Galeria = V_Return_C_I2;
            }
            return V_Return_C_I1;
        }
        public Body_Site_Template Carregamento_Cliente()
        {
            Body_Site_Template V_Return_C_I1 = new Body_Site_Template();
            using (var Context = new Models.db_prolaboreEntities())
            {
                var V_Return_C_I2 = Context.exib_client.Where(x => x.id > 0).ToArray();
                V_Return_C_I1.S6_Cliente = V_Return_C_I2;
            }
            return V_Return_C_I1;
        }
  
    }
}