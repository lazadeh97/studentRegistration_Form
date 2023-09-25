using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistrationOfStudents
{
    public partial class Helper : Form
    {
        public Helper()
        {
            InitializeComponent();
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbHelperForm dbHelper = new DbHelperForm();
            dbHelper.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EntranceHelper entranceHelper = new EntranceHelper();
            entranceHelper.ShowDialog();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistrationHelper registrationHelper = new RegistrationHelper();
            registrationHelper.ShowDialog();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SearchFormHelper searchFormHelper = new SearchFormHelper();
            searchFormHelper.ShowDialog();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PunishPresentsAndExcRestorationHelper excRestorationHelper = new PunishPresentsAndExcRestorationHelper();
            excRestorationHelper.ShowDialog();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ExportToWordFile wordFile = new ExportToWordFile();
            wordFile.ShowDialog();
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TranskriptHelper transkriptHelper = new TranskriptHelper();
            transkriptHelper.ShowDialog();
        }
    }
}
