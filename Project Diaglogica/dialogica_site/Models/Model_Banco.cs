using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Odbc;
using System.Collections.ObjectModel;
using dialogica_site.Controllers;

namespace dialogica_site.Models
{
    public class Model_Banco
    {
        public IEnumerable<Profissional> Profissionais;
        public IEnumerable<Profissional> Associados;
        public List<Grafico_Valores> Quantidade_Mes;

        //Construtor
        public Model_Banco()
        {
            tdd();
            Associados_tdd();
        }

        //Métodos
        public void tdd()
        {
         Banco_Ender Ender = new Banco_Ender();
         string Query ="SELECT * FROM profissionais where tp_profissional=1;";
         OdbcConnection Conexao = new OdbcConnection(Ender.Myconection);
         OdbcCommand Comando = new OdbcCommand(Query, Conexao);
         var retorno = new Collection<Profissional>();
         try
         {
             Conexao.Open();
             OdbcDataReader Reader = Comando.ExecuteReader();
             while (Reader.Read())
             {
                 /*Profissional pf = new Profissional();
                 pf.Nome = Reader["nome"].ToString();
                 pf.Ender_img = Reader["img_src"].ToString();
                 pf.Facebook = Reader["facebook"].ToString();
                 pf.Linkedin = Reader["linkedin"].ToString();
                 pf.Frase = Reader["frase"].ToString();
                 pf.Funcao = Reader["funcao"].ToString();
                 pf.ht = Reader["turno"].ToString();
                 pf.crp = Reader["crp"].ToString();
                 pf.tel = Reader["tel"].ToString();
                 pf.id = Reader["id"].ToString();
                 retorno.Add(pf);*/
             }
         }
         catch (OdbcException ex)
         {
             this.Erro_Exception(ex.Message);
         }
         finally
         {
             Profissionais = retorno;
             Conexao.Close();
         }
        }
        public void Associados_tdd()
        {
         Banco_Ender Ender = new Banco_Ender();
         string Query ="SELECT * FROM profissionais where tp_profissional=0;";
         OdbcConnection Conexao = new OdbcConnection(Ender.Myconection);
         OdbcCommand Comando = new OdbcCommand(Query, Conexao);
         var retorno = new Collection<Profissional>();
         try
         {
             Conexao.Open();
             OdbcDataReader Reader = Comando.ExecuteReader();
             while (Reader.Read())
             {
                 /*Profissional pf = new Profissional();
                 pf.Nome = Reader["nome"].ToString();
                 pf.Ender_img = Reader["img_src"].ToString();
                 pf.Facebook = Reader["facebook"].ToString();
                 pf.Linkedin = Reader["linkedin"].ToString();
                 pf.Frase = Reader["frase"].ToString();
                 pf.Funcao = Reader["funcao"].ToString();
                 pf.ht = Reader["turno"].ToString();
                 pf.crp = Reader["crp"].ToString();
                 pf.tel = Reader["tel"].ToString();
                 pf.id = Reader["id"].ToString();
                 retorno.Add(pf);*/
             }
         }
         catch (OdbcException ex)
         {
             this.Erro_Exception(ex.Message);
         }
         finally
         {
             Associados = retorno;
             Conexao.Close();
         }
        }
        public bool Consult_Agedamento(string dt)
        {
            Banco_Ender Ender = new Banco_Ender();
            Int64 Retorno_Scalar= 0 ;
            bool Retorno_Valid = false;
            OdbcConnection Conexao = new OdbcConnection(Ender.Myconection);
            OdbcCommand Command = new OdbcCommand("SELECT count(*) FROM ordens where dt_ag=?", Conexao);
            try
            {
                Conexao.Open();
                Command.Parameters.AddWithValue("@dt_ag", dt);
                Command.ExecuteNonQuery();
                Retorno_Scalar = Convert.ToInt64(Command.ExecuteScalar());
            }
            catch(OdbcException ex)
            {
                Erro_Exception(ex.Message);
            }
            finally
            {
                if (Retorno_Scalar < 24)
                {
                    Retorno_Valid = true;
                }
                else if (Retorno_Scalar >= 24)
                {
                    Retorno_Valid = false;
                }
            }
            return Retorno_Valid;

        }
        public bool Consult_Agendamento_Hora(string hora, string dt)
        {
            Banco_Ender Ender = new Banco_Ender();
            Int64 Retorno_Scalar = 0;
            bool Retorno_Valid = false;
            OdbcConnection Conexao = new OdbcConnection(Ender.Myconection);
            OdbcCommand Command = new OdbcCommand("SELECT count(*) FROM ordens where dt_ag=? and ho_con=?", Conexao);
            try
            {
                Conexao.Open();
                Command.Parameters.AddWithValue("@dt_ag", dt);
                Command.Parameters.AddWithValue("@ho_con", hora);
                Command.ExecuteNonQuery();
                Retorno_Scalar = Convert.ToInt64(Command.ExecuteScalar());
            }
            catch (OdbcException ex)
            {
                Erro_Exception(ex.Message);
            }
            finally
            {
                if (Retorno_Scalar < 2)
                {
                    Retorno_Valid = true;
                }
                else if (Retorno_Scalar >= 2)
                {
                    Retorno_Valid = false;
                }
            }
            return Retorno_Valid;

        }
        public Usuario Consult_Login_User(string password, string email)
        {
            Banco_Ender Ender = new Banco_Ender();
            string Query = "SELECT  cadastro_user.nome,cadastro_user.email,cadastro_user.id FROM autenticacao " +
                                          "INNER JOIN cadastro_user ON cadastro_user.id=autenticacao.id "+
                                          "where autenticacao.password = ? and cadastro_user.email=? and "+
                                          "autenticacao.tp_autentic = 3;";
            OdbcConnection Conexao = new OdbcConnection(Ender.Myconection);
            OdbcCommand Comando = new OdbcCommand(Query, Conexao);
            Usuario user = new Usuario();
            try
            {
                Conexao.Open();
                string senha = password;
                Comando.Parameters.AddWithValue("@autenticacao.password", password);
                Comando.Parameters.AddWithValue("@cadastro_user.email", email);
                Comando.ExecuteNonQuery();
                OdbcDataReader Reader = Comando.ExecuteReader();
                while (Reader.Read())
                {
                    user.nome = Reader["nome"].ToString();
                    user.email = Reader["email"].ToString();
                    user.id = Reader["id"].ToString();
                }
            }
            catch (OdbcException ex)
            {
                Erro_Exception(ex.Message);
            }
            finally
            {
            }
               return user;
        }
        public bool Agendando_Consulta(Agendamento Data,Usuario User, string ordem)
        {
            Banco_Ender Ender = new Banco_Ender();
            bool valid = true;
             string Query = "INSERT INTO ordens(ordem,id_user,dt_ag,ho_con,id_pf,obs_con,data) VALUES"+
                 "(?,?,?,?,?,?,curdate());";
            OdbcConnection Conexao = new OdbcConnection(Ender.Myconection);
            OdbcCommand Comando = new OdbcCommand(Query, Conexao);
            Usuario user = new Usuario();
            DateTime Data_Convert = Convert.ToDateTime(Data.dt_ag);
            try
            {
                Conexao.Open();
                Comando.Parameters.AddWithValue("@ordem", Convert.ToInt64(ordem));
                Comando.Parameters.AddWithValue("@id_user", User.id);
                Comando.Parameters.AddWithValue("@dt_ag", Data_Convert.ToString("yyyy-MM-dd"));
                Comando.Parameters.AddWithValue("@ho_con", Data.hora_con);
                Comando.Parameters.AddWithValue("@id_pf", Data.if_pf_esc);
                Comando.Parameters.AddWithValue("@obs", Data.observe);
                Comando.ExecuteNonQuery();
            }
            catch (OdbcException ex)
            {
                Erro_Exception(ex.Message);
                valid = false;
            }
            finally
            {
                if (valid)
                {
                    Email_Marketing Consult_Marketing = new Email_Marketing();
                    Consult_Marketing.Noti_Consulta(ordem,Data, User);
                }
            }
            return valid;
        }
        public Usuario Consult_Login(string id)
        {
            Banco_Ender Ender = new Banco_Ender();
            string Query = "select nome,email,id from cadastro_user where id=? and tp_autentic = 3;";
            OdbcConnection Conexao = new OdbcConnection(Ender.Myconection);
            OdbcCommand Comando = new OdbcCommand(Query, Conexao);
            Usuario user = new Usuario();
            try
            {
                Conexao.Open();
                Comando.Parameters.AddWithValue("@id", id);
                Comando.ExecuteNonQuery();
                OdbcDataReader Reader = Comando.ExecuteReader();
                while (Reader.Read())
                {
                    user.nome = Reader["nome"].ToString();
                    user.email = Reader["email"].ToString();
                    user.id = Reader["id"].ToString();
                }
            }
            catch (OdbcException ex)
            {
                Erro_Exception(ex.Message);
            }
            finally
            {
            }
            return user;
        }
        public string Consult_Profissional(string id)
        {
            Banco_Ender Ender = new Banco_Ender();
            string Query = "select nome from profissionais where id=?";
            OdbcConnection Conexao = new OdbcConnection(Ender.Myconection);
            OdbcCommand Comando = new OdbcCommand(Query, Conexao);
            string Nome_Profissional = null;
            try
            {
                Conexao.Open();
                Comando.Parameters.AddWithValue("@id", id);
                Comando.ExecuteNonQuery();
                OdbcDataReader Reader = Comando.ExecuteReader();
                while (Reader.Read())
                {
                    Nome_Profissional = Reader["nome"].ToString();
                }
            }
            catch (OdbcException ex)
            {
                Erro_Exception(ex.Message);
            }
            finally
            {
            }
            return Nome_Profissional;
        }
        public bool Cadastrando_Usuario(Cadastro_Usuario Usuario_Cadastro)
        {
            Banco_Ender Ender = new Banco_Ender();
            bool valid = true;
            string Query = "INSERT INTO cadastro_user(id,nome,sexo,cpf,dnt,tel,email,tp_end,end,bairro,cidade,estado,nm,data) VALUES "+
                           "(?,?,?,?,?,?,?,?,?,?,?,?,?,curdate());";
            OdbcConnection Conexao = new OdbcConnection(Ender.Myconection);
            OdbcCommand Comando = new OdbcCommand(Query, Conexao);
            Usuario user = new Usuario();
            DateTime Data_Convert = Convert.ToDateTime(Usuario_Cadastro.data_nascimento);
            string Id_User = Usuario_Cadastro.id;
            try
            {
                Conexao.Open();
                Comando.Parameters.AddWithValue("@id", Id_User);
                Comando.Parameters.AddWithValue("@nome", Usuario_Cadastro.nome);
                Comando.Parameters.AddWithValue("@sexo", Usuario_Cadastro.Sexo);
                Comando.Parameters.AddWithValue("@cpf", Usuario_Cadastro.CPF);
                Comando.Parameters.AddWithValue("@dnt", Data_Convert.ToString("yyyy-MM-dd"));
                Comando.Parameters.AddWithValue("@tel", Usuario_Cadastro.tel);
                Comando.Parameters.AddWithValue("@email", Usuario_Cadastro.email);
                Comando.Parameters.AddWithValue("@tp_end", Usuario_Cadastro.tp_end);
                Comando.Parameters.AddWithValue("@end", Usuario_Cadastro.end);
                Comando.Parameters.AddWithValue("@bairro", Usuario_Cadastro.bairro);
                Comando.Parameters.AddWithValue("@cidade", Usuario_Cadastro.cidade);
                Comando.Parameters.AddWithValue("@estado", Usuario_Cadastro.estado);
                Comando.Parameters.AddWithValue("@nm", Usuario_Cadastro.nm);
                Comando.ExecuteNonQuery();
            }
            catch (OdbcException ex)
            {
                Erro_Exception(ex.Message);
                valid = false;
            }
            finally
            {
                
                    if (valid)
                    {
                        if (Cadastro_Senha(Id_User, Usuario_Cadastro.senha))
                        {
                            Email_Marketing Consult_Marketing = new Email_Marketing();
                            Consult_Marketing.Noti_Cadastro(Usuario_Cadastro.email, Usuario_Cadastro.nome, Usuario_Cadastro.senha);
                        }
                        else
                        {
                            valid = false;
                        }
                }
                
            }
            return valid;
        }
        public bool Consult_Email(string email)
        {
            Banco_Ender Ender = new Banco_Ender();
            Int64 Retorno_Scalar = 0;
            bool Retorno_Valid = false;
            OdbcConnection Conexao = new OdbcConnection(Ender.Myconection);
            OdbcCommand Command = new OdbcCommand("SELECT count(*) FROM cadastro_user where email=?", Conexao);
            try
            {
                Conexao.Open();
                Command.Parameters.AddWithValue("@email", email);
                Command.ExecuteNonQuery();
                Retorno_Scalar = Convert.ToInt64(Command.ExecuteScalar());
            }
            catch (OdbcException ex)
            {
                Erro_Exception(ex.Message);
            }
            finally
            {
                if (Retorno_Scalar < 1)
                {
                    Retorno_Valid = true;
                }
                else if (Retorno_Scalar == 1)
                {
                    Retorno_Valid = false;
                }
            }
            return Retorno_Valid;
        }
        private bool Cadastro_Senha(string id,string senha)
        {
            Banco_Ender Ender = new Banco_Ender();
            bool valid = true;
            string Query = "INSERT INTO autenticacao(id,password,tp_autentic,data) VALUES (?,?,3,curdate())";
            OdbcConnection Conexao = new OdbcConnection(Ender.Myconection);
            OdbcCommand Comando = new OdbcCommand(Query, Conexao);
            try
            {
                Conexao.Open();
                Comando.Parameters.AddWithValue("@id", id);
                Comando.Parameters.AddWithValue("@senha", senha);
                Comando.ExecuteNonQuery();
            }
            catch (OdbcException ex)
            {
                Erro_Exception(ex.Message);
                valid = false;
            }
            finally
            {

            }
            return valid;
        }
        public bool Quantidade_Ordens_Mes_P(string dataMin, string dataMax)
        {
            Banco_Ender Ender = new Banco_Ender();
            bool valid = true;
            string Query =  "select profissionais.nome,count(ordens.ordem) as quantidade from ordens"+
                            "INNER JOIN profissionais ON profissionais.id=ordens.id_pf where ordens.status = 1"+
                            "and ordens.data between "+dataMin+" and "+dataMax +" "+
                            "group by profissionais.nome;";
            OdbcConnection Conexao = new OdbcConnection(Ender.Myconection);
            OdbcCommand Comando = new OdbcCommand(Query, Conexao);
            try
            {
                Conexao.Open();
                Comando.ExecuteNonQuery();
                OdbcDataReader Reader = Comando.ExecuteReader();
                while (Reader.Read())
                {
                    Grafico_Valores GV = new Grafico_Valores();
                    GV.nome = Reader["nome"].ToString();
                    GV.quantidade = Convert.ToInt64(Reader["quantidade"].ToString());
                    Quantidade_Mes.Add(GV);
                }
            }
            catch (OdbcException ex)
            {
                this.Erro_Exception(ex.Message);
                valid = false;
            }
            finally
            {
                Conexao.Close();
            }
            return valid;
        }

        public string Erro_Exception(string erro)
        {
            return erro;
        }
    }
    }