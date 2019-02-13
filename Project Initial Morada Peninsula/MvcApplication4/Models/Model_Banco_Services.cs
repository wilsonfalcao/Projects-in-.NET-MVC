using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections.ObjectModel;
using MvcApplication4.Controllers;

namespace MvcApplication4.Models
{
    public class Model_Banco_Services
    {
        //Instanciamento EnityFrameWork Banco de Dados
        Models.db_moradaEntities Service_Cloud = new db_moradaEntities();
        //Validando E-mail Existente
        public bool Consulta_Email(string email)
        {
            return Service_Cloud.cadastro_usuario.Any(user => user.email == email);
        }

        //Consultas
        public IEnumerable<cadastro_categoria> Consulta_Categorias()
        {
            using (var context = new Models.db_moradaEntities())
            {
                var Dado_Retorno = context.cadastro_categoria.Where(x1 => x1.id_categoria > 0).ToArray();
                return Dado_Retorno;
            }
        }
        public string Consulta_Categoria(Int64 Id)
        {
            using (var context = new Models.db_moradaEntities())
            {
                string Dado_Retorno = context.cadastro_categoria.Where(x1 => x1.id_categoria == Id).Select(c => c.categoria).FirstOrDefault();
                return Dado_Retorno;
            }
        }
        public string Consulta_Pessoa(int Id)
        {
            using (var context = new Models.db_moradaEntities())
            {
                string Dado_Retorno = context.cadastro_usuario.Where(x1 => x1.id_user == Id).Select(c1 => c1.nome).FirstOrDefault();
                return Dado_Retorno;
            }
        }
        public IEnumerable<Model_Body_> Listar_Bordo(string protocolo)
        {
            if (protocolo != "")
            {
                using (var context = new Models.db_moradaEntities())
                {
                    Int64 Protocolo_ = Convert.ToInt64(protocolo);
                    var Dado_Retorno_D_bordo_S1 = (from x in context.d_bordo_s1
                                                   join x1 in context.cadastro_usuario on x.id_user equals x1.id_user
                                                   join x2 in context.cadastro_categoria on x.id_lugar equals x2.id_categoria
                                                   join x3 in context.cadastro_usuario on x.user_at equals x3.id_user
                                                   where x.protocolo == Protocolo_
                                                   select new Model_Body_
                                                   {
                                                       d_bordo_s1_protocolo = x.protocolo,
                                                       cadastro_usuario_nome = x1.nome,
                                                       cadastro_usuario_nome2 = x3.nome,
                                                       d_bordo_s1_id_user = x.id_user,
                                                       d_bordo_s1_t_problema = x.t_problema,
                                                       d_bordo_s1_problema = x.problema,
                                                       d_bordo_s1_id_categoria = x.id_lugar,
                                                       cadastro_categoria = x2.categoria,
                                                       d_bordo_s1_user_at = x.user_at,
                                                       d_bordo_s1_dt_at = x.dt_at,
                                                       d_bordo_s1_data = x.data
                                                   }).ToList();
                    return Dado_Retorno_D_bordo_S1;
                }
            }
            else
            {
                using (var context = new Models.db_moradaEntities())
                {
                    var Dado_Retorno_D_bordo_S1 = (from x in context.d_bordo_s1
                                                   join x1 in context.cadastro_usuario on x.id_user equals x1.id_user
                                                   join x2 in context.cadastro_categoria on x.id_lugar equals x2.id_categoria
                                                   join x3 in context.cadastro_usuario on x.user_at equals x3.id_user
                                                   select new Model_Body_
                                                   {
                                                       d_bordo_s1_protocolo = x.protocolo,
                                                       cadastro_usuario_nome = x1.nome,
                                                       cadastro_usuario_nome2= x3.nome,
                                                       d_bordo_s1_t_problema = x.t_problema,
                                                       cadastro_categoria = x2.categoria,
                                                       d_bordo_s1_user_at = x.user_at,
                                                       d_bordo_s1_dt_at = x.dt_at,
                                                       d_bordo_s1_data = x.data
                                                   }).ToList();
                    return Dado_Retorno_D_bordo_S1;
                }
            }
        }
        public IEnumerable<cadastro_usuario> Consulta_User()
        {
            using (var context = new Models.db_moradaEntities())
            {
                var Dado_Retorno = context.cadastro_usuario.Where(x1 => x1.id_user > 0).ToArray();
                return Dado_Retorno;
            }
        }
        public List<string> Consultar_Email()
        {
            using (var context = new Models.db_moradaEntities())
            {
                List<string> Dado_Retorno =new List<string>(context.email.Where(c2 => c2.id > 0).Select(c1 => c1.email1).ToList());
                return Dado_Retorno;
            }
        }
        public List<string> Consultar_UserON()
        {
            using (var context = new Models.db_moradaEntities())
            {
                List<string> Dado_Retorno = new List<string>(context.cadastro_usuario.Where(c2 => c2.online ==1).Select(c1 => c1.nome).ToList());
                return Dado_Retorno;
            }
        }


        //Inserções
        public bool Insert_Cadastro_User(Body_ Data_Cadastro_User)
        {
            bool valid = true;
            var Insert = new cadastro_usuario
            {
                nome = Data_Cadastro_User.Nome_User,
                tp_user = Data_Cadastro_User.Nivel,
                id_setor = Convert.ToInt32(Data_Cadastro_User.Setor),
                email = Data_Cadastro_User.Email,
                telefone = Data_Cadastro_User.Ramal,
                senha = Data_Cadastro_User.Senha,
                data = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))
            };
            try
            {
                Service_Cloud.cadastro_usuario.Add(Insert);
                Service_Cloud.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                valid = false;
            }
            return valid;
        }
        public bool Insert_Cadastro_Categoria(Body_ Data_Cadastro_Lugar)
        {
            bool valid = true;
            var Insert = new cadastro_categoria
            {
                categoria = Data_Cadastro_Lugar.Categoria
            };
            try
            {
                Service_Cloud.cadastro_categoria.Add(Insert);
                Service_Cloud.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                valid = false;
            }
            return valid;
        }
        public bool Insert_Diario_Bordo(Body_ Data_Diario, Int64 Protocolo_Controller)
        {
            bool valid = true;
            var Insert = new d_bordo_s1
            {
                protocolo = Protocolo_Controller,
                id_lugar = Data_Diario.id_lugar,
                id_user = Body_.User_Autenticado.id_user,
                t_problema = Data_Diario.t_problema,
                problema = Data_Diario.problema,
                user_at = 7,
                data = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))
            };
            try
            {
                Service_Cloud.d_bordo_s1.Add(Insert);
                Service_Cloud.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                valid = false;
            }
            return valid;
        }
        public bool Insert_Cadastro_Email(Body_ Data_email)
        {
            bool valid = true;
            var Insert = new email
            {
                nome = Data_email.Nome_User,
                email1 = Data_email.Email_Setor,
                setor = Data_email.Setor
            };
            try
            {
                Service_Cloud.email.Add(Insert);
                Service_Cloud.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                valid = false;
            }
            return valid;
        }

        //Atualizações
        public bool Apagar_Diario_Bordo(Int64 protocolo)
        {
            using (var contex = new Models.db_moradaEntities())
            {
                bool valid = true;
                var Data = contex.d_bordo_s1.Where(x1 => x1.protocolo == protocolo).FirstOrDefault();
                try
                {
                    contex.d_bordo_s1.Remove(Data);
                    contex.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {
                    valid = false;
                }
                return valid;
            }
        }
        public bool Apagar_Cadastro_User(Int64 id_user)
        {
            using (var contex = new Models.db_moradaEntities())
            {
                bool valid = true;
                var Data = contex.cadastro_usuario.Where(x1 => x1.id_user == id_user).FirstOrDefault();
                try
                {
                    contex.cadastro_usuario.Remove(Data);
                    contex.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {
                    valid = false;
                }
                return valid;
            }
        }
        public bool Atualizar_Diario_Bordo(Body_ Data_At,string protocolo)
        {
            using (var contex = new Models.db_moradaEntities())
            {
                Int64 _Protocolo =Convert.ToInt64(protocolo);
                bool valid = true;
                var Data = contex.d_bordo_s1.Where(x1 => x1.protocolo == _Protocolo ).FirstOrDefault();
                try
                {
                    //Passando Valores
                    Data.problema = Data_At.problema;
                    Data.t_problema = Data_At.t_problema;
                    Data.id_lugar = Data_At.id_lugar;
                    Data.user_at = Body_.User_Autenticado.id_user;
                    Data.dt_at = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                    //Fim
                    contex.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {
                    valid = false;
                }
                return valid;
            }
        }
        public bool Atualizar_Cadastro_User(Settings Data_At_Settings, string ID_User)
        {
            using (var contex = new Models.db_moradaEntities())
            {
                Int64 _ID_User = Convert.ToInt64(ID_User);
                bool valid = true;
                var Data = contex.cadastro_usuario.Where(x1 => x1.id_user == _ID_User).FirstOrDefault();
                try
                {
                    //Passando Valores
                    Data.senha = Data_At_Settings.Senha;
                    //Fim
                    contex.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {
                    valid = false;
                }
                return valid;
            }
        }
    }
}