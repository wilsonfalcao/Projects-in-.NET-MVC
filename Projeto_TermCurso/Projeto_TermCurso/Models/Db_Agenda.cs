using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_TermCurso.Models
{
    public class Db_Agenda
    {
        public Db_Agenda()
        {
            Field_DB();
        }

        //Adicionando Dados ao Banco
        public void Field_DB()
        {
            var Values_Data = new List<DB_Body>()
            {
                new DB_Body() { Nome = "Wilson", Telefone = Telefone_Randon()},
                new DB_Body() { Nome = "Maria", Telefone = Telefone_Randon()},
                new DB_Body() { Nome = "Jose", Telefone = Telefone_Randon()},
                new DB_Body() { Nome = "Roberto", Telefone = Telefone_Randon()},
                new DB_Body() { Nome = "Felipe", Telefone = Telefone_Randon()},
                new DB_Body() { Nome = "Carlos", Telefone = Telefone_Randon()},
                new DB_Body() { Nome = "Iran", Telefone = Telefone_Randon() },
                new DB_Body() { Nome = "Gabriel", Telefone = Telefone_Randon()},
                new DB_Body() { Nome = "Raphael", Telefone = Telefone_Randon() },
                new DB_Body() { Nome = "Eduarda", Telefone = Telefone_Randon()},
                new DB_Body() { Nome = "Poliana", Telefone = Telefone_Randon()},
                new DB_Body() { Nome = "Ana", Telefone = Telefone_Randon() },
                new DB_Body() { Nome = "Aline", Telefone = Telefone_Randon() }
            }.ToArray();

            Tables = Values_Data;
        }

        public string Telefone_Randon()
        {
            Random Tel = new Random();
            return Tel.Next(900000000, 999999999).ToString();
        }
        public IEnumerable<DB_Body> Tables;
    }
    public class DB_Body
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
    }
}