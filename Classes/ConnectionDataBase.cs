using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationOfStudents
{
    public class ConnectionDataBase
    {
        public EntityConnection conn { get; set; }         
        public ConnectionDataBase(string connectionString)
        {
            conn = new EntityConnection(connectionString);
        }

        public bool CheckConnection()
        {
            bool isConnection;
            using (var context = new RegistrationContainer1())
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();
                isConnection = true;
            }
            return isConnection;
        }
    }
}
