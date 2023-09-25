using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationOfStudents
{
    public static class ConnectionString
    {
        public static StringBuilder GetString { get; set; }

        public static string ChangeConnString(string dataSource, string initialCatalog)
        {
            GetString = new StringBuilder("metadata=");
            GetString.Append("res://*/;");
            GetString.Append("provider=System.Data.SqlClient;");
            GetString.Append("provider connection string=' ");
            GetString.Append("data source=");
            GetString.Append(dataSource);
            GetString.Append(";initial Catalog=");
            GetString.Append(initialCatalog);
            GetString.Append(";integrated Security=True");
            GetString.Append(";App=EntityFramework';");

            string strCon = GetString.ToString();
            return strCon;
        }

        public static string ChangeConnString(string dataSource, string initialCatalog, string userID, string password)
        {
            GetString = new StringBuilder("metadata=");
            GetString.Append("res://*/Model.csdl|res://*/Model.ssdl|res://*/Model.msl;");
            GetString.Append("provider=System.Data.SqlClient;");
            GetString.Append("provider connection string='");
            GetString.Append(";data source=");
            GetString.Append(dataSource);
            GetString.Append(";initial Catalog=");
            GetString.Append(initialCatalog);
            GetString.Append(";integrated Security=True");
            GetString.Append(";persist security info = True;");
            GetString.Append("user id= ");
            GetString.Append(userID);
            GetString.Append(";password =");
            GetString.Append(password);
            GetString.Append(";App=EntityFramework';");

            string strCon = GetString.ToString();
            return strCon;
        }
    }
}
