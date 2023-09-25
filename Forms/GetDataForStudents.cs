using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistrationOfStudents
{
    public partial class GetDataForStudents : Form
    {
        public GetDataForStudents()
        {
            InitializeComponent();
        }
        BasicForm basicForm;

        private void DgvGetPersonalData_CellClick(object sender, DataGridViewCellEventArgs e)
        {            
            basicForm = new BasicForm();

            DataGridViewRow row = DgvGetPersonalData.CurrentRow;
            (Application.OpenForms["BasicForm"] as BasicForm).txtSurname.Text= row.Cells["Soyad"].Value.ToString();
            (Application.OpenForms["BasicForm"] as BasicForm).txtSurname.Tag = row.Cells["ID"].Value.ToString();

            (Application.OpenForms["BasicForm"] as BasicForm).txtName.Text = row.Cells["Ad"].Value.ToString();
            (Application.OpenForms["BasicForm"] as BasicForm).txtFatherName.Text = row.Cells["AtaAdi"].Value.ToString();
            (Application.OpenForms["BasicForm"] as BasicForm).dtpBirthDate.Text = row.Cells["DogumTarixi"].Value.ToString();
            (Application.OpenForms["BasicForm"] as BasicForm).txtAddress.Text = row.Cells["YasayisYeri"].Value.ToString();
            (Application.OpenForms["BasicForm"] as BasicForm).txtPhoneNumber.Text = row.Cells["ElaqeTelefonu"].Value.ToString();
            (Application.OpenForms["BasicForm"] as BasicForm).txtEmail.Text = row.Cells["Email"].Value.ToString();
            if (row.Cells["Cinsi"].Value.ToString() == "K")
            {
                (Application.OpenForms["BasicForm"] as BasicForm).cbMale.Checked = true;
            }
            else if (row.Cells["Cinsi"].Value.ToString() == "Q")
            {
                (Application.OpenForms["BasicForm"] as BasicForm).cbFemale.Checked = true;
            }
            else
            {
                (Application.OpenForms["BasicForm"] as BasicForm).cbMale.Checked = false;
                (Application.OpenForms["BasicForm"] as BasicForm).cbFemale.Checked = false;
            }
            (Application.OpenForms["BasicForm"] as BasicForm).CBSchool.Items.Add(row.Cells["Tehsili"].Value.ToString());
            (Application.OpenForms["BasicForm"] as BasicForm).CBSchool.SelectedItem = row.Cells["Tehsili"].Value.ToString();
            (Application.OpenForms["BasicForm"] as BasicForm).CBFaculty.Items.Add(row.Cells["Fakulte"].Value.ToString());
            (Application.OpenForms["BasicForm"] as BasicForm).CBFaculty.SelectedItem = row.Cells["Fakulte"].Value.ToString();
            (Application.OpenForms["BasicForm"] as BasicForm).CBSpeciality.Items.Add(row.Cells["Ixtisas"].Value.ToString());
            (Application.OpenForms["BasicForm"] as BasicForm).CBSpeciality.SelectedItem = row.Cells["Ixtisas"].Value.ToString();
            (Application.OpenForms["BasicForm"] as BasicForm).dtpEnterDate.Text = row.Cells["QebulTarixi"].Value.ToString();
            (Application.OpenForms["BasicForm"] as BasicForm).dtpEndDate.Text = row.Cells["BitirmeTarixi"].Value.ToString();
            (Application.OpenForms["BasicForm"] as BasicForm).txtScore.Text = row.Cells["Bal"].Value.ToString();
            (Application.OpenForms["BasicForm"] as BasicForm).txtGroupNo.Text = row.Cells["QrupNo"].Value.ToString();

            if (row.Cells["TehsilPillesi"].Value.ToString() == "B")
            {
                (Application.OpenForms["BasicForm"] as BasicForm).RbBachelor.Checked = true;
            }
            else if (row.Cells["TehsilPillesi"].Value.ToString() == "M")
            {
                (Application.OpenForms["BasicForm"] as BasicForm).RbMaster.Checked = true;
            }
            else
            {
                (Application.OpenForms["BasicForm"] as BasicForm).RbBachelor.Checked = false;
                (Application.OpenForms["BasicForm"] as BasicForm).RbMaster.Checked = false;
            }

            (Application.OpenForms["BasicForm"] as BasicForm).txtNationality.Text = row.Cells["Milliyeti"].Value.ToString();
            (Application.OpenForms["BasicForm"] as BasicForm).txtParents.Text = row.Cells["Valideynler"].Value.ToString();
            (Application.OpenForms["BasicForm"] as BasicForm).txtJobs.Text = row.Cells["IsYeri"].Value.ToString();
            (Application.OpenForms["BasicForm"] as BasicForm).txtEntranceOrder.Text = row.Cells["QebulEmri"].Value.ToString();
            (Application.OpenForms["BasicForm"] as BasicForm).rtbAcademicOrder.Text = row.Cells["ArayisEmri"].Value.ToString();

            if (row.Cells["Sekil"].Value != System.DBNull.Value)
            {
                byte[] bytes = (byte[])(row.Cells["Sekil"].Value);
                MemoryStream ms = new MemoryStream(bytes);
                (Application.OpenForms["BasicForm"] as BasicForm).PBStudentsPictures.Image = Image.FromStream(ms);
            }
            FontColor();
            Activation();
            (Application.OpenForms["BasicForm"] as BasicForm).PBStudentsPictures.BackgroundImage = null;
            (Application.OpenForms["BasicForm"] as BasicForm).EnabledFalse();

            Close();
        }      

        public void FontColor()
        {
            (Application.OpenForms["BasicForm"] as BasicForm).txtSurname.ForeColor = Color.Black;
            (Application.OpenForms["BasicForm"] as BasicForm).txtName.ForeColor = Color.Black;
            (Application.OpenForms["BasicForm"] as BasicForm).txtFatherName.ForeColor = Color.Black;
            (Application.OpenForms["BasicForm"] as BasicForm).txtAddress.ForeColor = Color.Black;
            (Application.OpenForms["BasicForm"] as BasicForm).txtEmail.ForeColor = Color.Black;
            (Application.OpenForms["BasicForm"] as BasicForm).CBSchool.ForeColor = Color.Black;
            (Application.OpenForms["BasicForm"] as BasicForm).CBFaculty.ForeColor = Color.Black;
            (Application.OpenForms["BasicForm"] as BasicForm).CBSpeciality.ForeColor = Color.Black;
            (Application.OpenForms["BasicForm"] as BasicForm).txtScore.ForeColor = Color.Black;
            (Application.OpenForms["BasicForm"] as BasicForm).txtGroupNo.ForeColor = Color.Black;
            (Application.OpenForms["BasicForm"] as BasicForm).txtNationality.ForeColor = Color.Black;
            (Application.OpenForms["BasicForm"] as BasicForm).txtParents.ForeColor = Color.Black;
            (Application.OpenForms["BasicForm"] as BasicForm).txtJobs.ForeColor = Color.Black;
            (Application.OpenForms["BasicForm"] as BasicForm).txtEntranceOrder.ForeColor = Color.Black;
            (Application.OpenForms["BasicForm"] as BasicForm).rtbAcademicOrder.ForeColor = Color.Black;
        }

        private void Activation()
        {
            (Application.OpenForms["BasicForm"] as BasicForm).BtnInsert.Enabled = false;
            (Application.OpenForms["BasicForm"] as BasicForm).BtnPrint.Enabled = false;
            (Application.OpenForms["BasicForm"] as BasicForm).BtnUpdate.Enabled = false;
            (Application.OpenForms["BasicForm"] as BasicForm).BtnDelete.Enabled = false;
            (Application.OpenForms["BasicForm"] as BasicForm).txtBookNo.Enabled = false;
        }
    }
}
