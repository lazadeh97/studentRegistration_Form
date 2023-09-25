using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Core.Metadata;

namespace RegistrationOfStudents
{
    public partial class ConnectDBChangedAppConfig : Form
    {
        public ConnectDBChangedAppConfig()
        {
            InitializeComponent();
        }
        public SaveAppConfig change { get; set; }
        public ObjectContext objectContext { get; set; }
        public ConnectionDataBase connect { get; set; }
        public string connectionString { get; set; }
        public BasicForm basicForm { get; set; }
        public StringBuilder msg { get; set; }
        public string  message { get; set; }

        private void ConnectDBChangedAppConfig_Load(object sender, EventArgs e)
        {
            CBDataSource.SelectedIndex = 0;
            CbAuthenticaton.SelectedIndex = 1;
        }

        #region MenuStripToolForAppConfigAndDatabase
        private void appConfigScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult question = MessageBox.Show("App Config faylını dəyişmək istəyirsinizmi?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (question == DialogResult.Yes)
            {
                BtnExecuteScript.Visible = true;
            }
            else
            {
                appConfigScriptToolStripMenuItem.Enabled = false;
                BtnExecuteScript.Enabled = false;
                BtnChanged.Visible = true;
            }
        }
        #endregion

        #region MenuStripToolForConnectDataBase
        private void connectDbToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BtnChanged.Visible = true;
        }
        #endregion

        #region ChangeAppConfigForOwnComputer
        private void BtnChanged_Click(object sender, EventArgs e)
        {     
            try
            {
                EntityConnectionStringBuilder entityConnBuilder = new EntityConnectionStringBuilder(ConfigurationManager.ConnectionStrings["RegistrationContainer1"].ConnectionString);
                SqlConnectionStringBuilder sqlConnBuilder = new SqlConnectionStringBuilder(entityConnBuilder.ProviderConnectionString);
                sqlConnBuilder.DataSource = CBDataSource.Text;
                sqlConnBuilder.InitialCatalog = TxtInitialCatalog.Text;
                entityConnBuilder.ProviderConnectionString = sqlConnBuilder.ConnectionString;
                string cn = entityConnBuilder.ConnectionString;

                message = CheckValidation();

                if (CbAuthenticaton.SelectedItem.ToString() == "Windows Authentication"&& TxtInitialCatalog.Text=="")
                {
                    //toolTipMessage.SetToolTip(TxtInitialCatalog, "DataBase adı daxil edilmədi!");
                    MessageBox.Show("DataBase adı daxil edilmədi!","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                else if (CbAuthenticaton.SelectedItem.ToString() == "Sql Server Authentication"&& message != "")
                {
                    MessageBox.Show(message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    ConnectDatabase(cn);
                }                         
            }
            catch (Exception)
            {
                MessageBox.Show("DataBase ilə əlaqə qurulmadı!", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    
        #endregion

        #region ExecuteEDMXFileScriptForOwnDataBase
        private void BtnExecuteScript_Click(object sender, EventArgs e)
        {
            try
            {
                basicForm = new BasicForm();
                string userID;
                string passWord;

                //ObjectContext objectContext = ((IObjectContextAdapter)context).ObjectContext;
                if (CbAuthenticaton.SelectedItem.ToString() == "Windows Authentication")
                {
                    connectionString = ConnectionString.ChangeConnString(CBDataSource.Text, TxtInitialCatalog.Text);
                    GenerateDatabase(connectionString);

                    Close();
                }
                else if (CbAuthenticaton.SelectedItem.ToString() == "Sql Server Authentication")
                {
                    userID = basicForm.EncryptUsername(TxtUserID.Text);
                    passWord = basicForm.EncryptPassword(TxtPassword.Text);

                    connectionString = ConnectionString.ChangeConnString(CBDataSource.Text, TxtInitialCatalog.Text, userID, passWord);
                    GenerateDatabase(connectionString);

                    Close();
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.InnerException.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NotSupportedException ex)
            {
                MessageBox.Show(ex.InnerException.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }
        #endregion
      
        #region CheckAuthentication
        private void CbAuthenticaton_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbAuthenticaton.SelectedItem.ToString() == "Sql Server Authentication")
            {
                TxtUserID.Enabled = true;
                TxtPassword.Enabled = true;
            }
            else
            {
                TxtUserID.Enabled = false;
                TxtPassword.Enabled = false;
            }
        }
        #endregion

        #region ExitFormApplicatinWhenFormClosed
        private void ConnectDBChangedAppConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            GC.Collect();
            //Application.Exit();
        }
        #endregion

        #region GenerateScriptAndChangeAppConfigMethod
        public void GenerateDatabase(string connectionString)
        {
            change = new SaveAppConfig();
            objectContext = new ObjectContext(connectionString);
            if (!objectContext.DatabaseExists())
            {
                objectContext.CreateDatabase();
                string schema = objectContext.CreateDatabaseScript();
                objectContext.SaveChanges();

                change.ChangeConnectionString("RegistrationContainer1", connectionString);
                MessageBox.Show("DataBase Yaradıldı... Proqramı yenidən başladın..!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                change.ChangeConnectionString("RegistrationContainer1", connectionString);
                MessageBox.Show("Proqramı yenidən başladın..!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region CheckValidationMethod
        private string CheckValidation()
        {
            msg = new StringBuilder();
            if (TxtInitialCatalog.Text == "")
                msg.AppendLine("DataBase adı daxil edilmədi!");
            if (TxtUserID.Text == "")
                msg.AppendLine("İstifadəçi adı daxil edilmədi!");
            if (TxtPassword.Text == "")
                msg.AppendLine("Şifrə daxil edilmədi!");
            return msg.ToString();
        }
        #endregion

        #region ConnectionDataBaseMethod
        private void ConnectDatabase(string connectionString)
        {
            connect = new ConnectionDataBase(connectionString);
            if (connect.CheckConnection())
            {
                MessageBox.Show("DataBase ilə əlaqə yaradıldı...","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                Close();
            }
        }
        #endregion
    }
}
