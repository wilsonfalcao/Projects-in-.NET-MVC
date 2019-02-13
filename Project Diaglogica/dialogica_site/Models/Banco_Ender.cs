using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dialogica_site.Models
{
    public class Banco_Ender
    {
        public Banco_Ender()
        {
            string formatar = "DRIVER={MySQL ODBC 3.51 Driver};Server=mysql.psidialogica.com.br;" + "Database=psidialogica_com_br;" + "UID=psidialogica;" + "PASSWORD=Gpoz33@@;";
            myconection = formatar;
        }
        public Banco_Ender(string ip, string data, string username, string pwd)
        {
            string formatar = "DRIVER={MySQL ODBC 3.51 Driver};" +
            "SERVER=" + ip + ";" +
            "DATABASE=" + data + ";" +
            "UID=" + username + ";" +
            "PASSWORD=" + pwd + ";" +
            "OPTION=3;";
            myconection = formatar;

        }
        private string myconection;
        public string Myconection
        {
            get { return myconection; }
        }
    }
}