using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationOfStudents
{
    public class SaveAppConfig
    {
        Configuration config;
        public string connectionString { get; set; }
        public SaveAppConfig()
        {
            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }

        public string GetConnectionString(string key)
        {
            return config.ConnectionStrings.ConnectionStrings[key].ConnectionString;
        }
        public void ChangeConnectionString(string key, string value)
        {
            config.ConnectionStrings.ConnectionStrings[key].ConnectionString=value;
            config.ConnectionStrings.ConnectionStrings[key].ProviderName = "System.Data.EntityClient";
            config.Save(ConfigurationSaveMode.Modified,true);
            ConfigurationManager.RefreshSection(key);

            connectionString = ConfigurationManager.ConnectionStrings[key].ConnectionString;
            //Properties.Settings.Default.Reload();
            //config.Save();
        }    
    }   
}
