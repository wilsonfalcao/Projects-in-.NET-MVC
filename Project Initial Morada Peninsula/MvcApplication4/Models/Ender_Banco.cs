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
            string formatar = "DRIVER={MySQL ODBC 3.51 Driver};Server=br-cdbr-azure-south-b.cloudapp.net;" + "Database=cond_peninsula;" + "UID=b726ee5dd48654;" + "PASSWORD=2cfcb1ab;";
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