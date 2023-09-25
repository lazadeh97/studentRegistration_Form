using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

using Microsoft.Office.Interop.Word;
using Microsoft.Office.Core;
using System.Reflection;
using Word = Microsoft.Office.Interop.Word;
using System.Diagnostics;
using System.Drawing.Drawing2D;


namespace RegistrationOfStudents
{
    public partial class BasicForm : Form
    {
        public BasicForm()
        {
            InitializeComponent();
        }
        System.Drawing.Point lastPoint;
        LoginForm login;
        TranskriptForm transkriptForm;
        PunishmentPresents punishmentPresents;
        ExclusionRestorations exclusionRestorations;
        SupplementalEduInfor infor;

        private string ImageLocation = "";

        byte[] image = null;

        private string pattern;
        public int id { get; set; }
        public string bookNo { get; set; }
        public int bookNoİD { get; set; }
        public string gender { get; set; }
        public string education { get; set; }
        public int num { get; set; }

        private void BasicForm_Load(object sender, EventArgs e)
        {
            toolTipMessage.SetToolTip(txtBookNo, "Məlumatları daxil etmək və ya əldə etmək üçün Şəxsi iş və Qiymət kitabçasının nömrəsini daxil edin..!");
        }

        #region ExitForm and MinimizedForm
        private void button1_Click(object sender, EventArgs e)
        {
            if (BtnList.Text == "Şəxsi məlumatları əldə et")
            {
                Close();
                login = new LoginForm();
                login.Show();
            }
            else if (BtnList.Text == "Ümumi Siyahı")
            {
                Close();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        #region MovementFormApp
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new System.Drawing.Point(e.X, e.Y);
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        #endregion

        #region TextBoxPlaceHolder
        private void txtSurname_Enter(object sender, EventArgs e)
        {
            if (txtSurname.Text == "Soyad")
            {
                txtSurname.Text = "";
                txtSurname.ForeColor = Color.Black;
            }
        }

        private void txtSurname_Leave(object sender, EventArgs e)
        {
            if (txtSurname.Text == "")
            {
                txtSurname.Text = "Soyad";
                txtSurname.ForeColor = Color.Silver;
            }
        }

        private void txtName_Enter(object sender, EventArgs e)
        {
            if (txtName.Text == "Ad")
            {
                txtName.Text = "";
                txtName.ForeColor = Color.Black;
            }
        }
        private void txtName_Leave(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                txtName.Text = "Ad";
                txtName.ForeColor = Color.Silver;
            }
        }
        private void txtFatherName_Enter(object sender, EventArgs e)
        {
            if (txtFatherName.Text == "Ata Adı")
            {
                txtFatherName.Text = "";
                txtFatherName.ForeColor = Color.Black;
            }
        }

        private void txtFatherName_Leave(object sender, EventArgs e)
        {
            if (txtFatherName.Text == "")
            {
                txtFatherName.Text = "Ata Adı";
                txtFatherName.ForeColor = Color.Silver;
            }
        }
        private void txtAddress_Enter(object sender, EventArgs e)
        {
            if (txtAddress.Text == "Yaşayış Yeri")
            {
                txtAddress.Text = "";
                txtAddress.ForeColor = Color.Black;
            }
        }

        private void txtAddress_Leave(object sender, EventArgs e)
        {
            if (txtAddress.Text == "")
            {
                txtAddress.Text = "Yaşayış Yeri";
                txtAddress.ForeColor = Color.Silver;
            }
        }
        private void txtNationality_Enter(object sender, EventArgs e)
        {
            if (txtNationality.Text == "Milliyəti")
            {
                txtNationality.Text = "";
                txtNationality.ForeColor = Color.Black;
            }
        }

        private void txtNationality_Leave(object sender, EventArgs e)
        {
            if (txtNationality.Text == "")
            {
                txtNationality.Text = "Milliyəti";
                txtNationality.ForeColor = Color.Silver;
            }
        }

        private void txtPhoneNumber_Enter(object sender, EventArgs e)
        {
            if (txtPhoneNumber.Text == "Əlaqə Telefonları")
            {
                txtPhoneNumber.Text = "";
                txtPhoneNumber.ForeColor = Color.Black;
            }
        }

        private void txtPhoneNumber_Leave(object sender, EventArgs e)
        {
            if (txtPhoneNumber.Text == "")
            {
                txtPhoneNumber.Text = "Əlaqə Telefonları";
                txtPhoneNumber.ForeColor = Color.Silver;
            }
        }
        private void txtScore_Enter(object sender, EventArgs e)
        {

            if (txtScore.Text == "Müsabiqə üzrə Qəbul Balı")
            {
                txtScore.Text = "";
                txtScore.ForeColor = Color.Black;
            }
        }

        private void txtScore_Leave(object sender, EventArgs e)
        {
            if (txtScore.Text == "")
            {
                txtScore.Text = "Müsabiqə üzrə Qəbul Balı";
                txtScore.ForeColor = Color.Silver;
            }
        }
        private void txtGroupNo_Enter(object sender, EventArgs e)
        {
            if (txtGroupNo.Text == "Qrup Nömrəsi")
            {
                txtGroupNo.Text = "";
                txtGroupNo.ForeColor = Color.Black;
            }
        }

        private void txtGroupNo_Leave(object sender, EventArgs e)
        {
            if (txtGroupNo.Text == "")
            {
                txtGroupNo.Text = "Qrup Nömrəsi";
                txtGroupNo.ForeColor = Color.Silver;
            }
        }

        private void txtJobs_Enter(object sender, EventArgs e)
        {
            if (txtJobs.Text == "İşi")
            {
                txtJobs.Text = "";
                txtJobs.ForeColor = Color.Black;
            }
        }

        private void txtJobs_Leave(object sender, EventArgs e)
        {
            if (txtJobs.Text == "")
            {
                txtJobs.Text = "İşi";
                txtJobs.ForeColor = Color.Silver;
            }
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Email")
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = Color.Black;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                txtEmail.Text = "Email";
                txtEmail.ForeColor = Color.Silver;
            }
            //Validation correct EmailAddress
            pattern = @"^([0-9a-zA-Z]" + @"([\+\-_\.][0-9a-zA-Z]+)*" + @")+" + @"@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,17})$";

            if (Regex.IsMatch(txtEmail.Text, pattern))
            {
                ErrorProviderEmailAddress.Clear();
            }
            else
            {
                ErrorProviderEmailAddress.SetError(txtEmail, "Emailinizi düzgün formada daxil edin!");
                return;
            }
        }

        private void txtParents_Enter(object sender, EventArgs e)
        {
            if (txtParents.Text == "Valideynlər")
            {
                txtParents.Text = "";
                txtParents.ForeColor = Color.Black;
            }
        }

        private void txtParents_Leave(object sender, EventArgs e)
        {
            if (txtParents.Text == "")
            {
                txtParents.Text = "Valideynlər";
                txtParents.ForeColor = Color.Silver;
            }
        }

        private void txtEntranceOrder_Enter(object sender, EventArgs e)
        {
            if (txtEntranceOrder.Text == "Qəbul Əmri")
            {
                txtEntranceOrder.Text = "";
                txtEntranceOrder.ForeColor = Color.Black;
            }
        }
        private void txtEntranceOrder_Leave(object sender, EventArgs e)
        {
            if (txtEntranceOrder.Text == "")
            {
                txtEntranceOrder.Text = "Qəbul Əmri";
                txtEntranceOrder.ForeColor = Color.Silver;
            }
        }

        private void rtbAcademicOrder_Enter(object sender, EventArgs e)
        {
            if (rtbAcademicOrder.Text == "Əmr №")
            {
                rtbAcademicOrder.Text = "";
                rtbAcademicOrder.ForeColor = Color.Black;
            }
        }

        private void rtbAcademicOrder_Leave(object sender, EventArgs e)
        {
            if (rtbAcademicOrder.Text == "")
            {
                rtbAcademicOrder.Text = "Əmr №";
                rtbAcademicOrder.ForeColor = Color.Silver;
            }
        }

        private void txtBookNo_Enter(object sender, EventArgs e)
        {
            //if (txtBookNo.Text == "İş Nömrəsi")
            //{
            //    txtBookNo.Text = "";
            //    txtBookNo.ForeColor = Color.Black;
            //}
        }

        private void txtBookNo_Leave(object sender, EventArgs e)
        {
            //if (txtBookNo.Text == "")
            //{
            //    txtBookNo.Text = "İş Nömrəsi";
            //    txtBookNo.ForeColor = Color.Silver;
            //}
        }
        #endregion

        #region CheckedCheckBox
        private void cbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMale.Checked == true)
            {
                cbFemale.Checked = false;
            }
        }

        private void cbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFemale.Checked == true)
            {
                cbMale.Checked = false;
            }
        }      
        #endregion

        #region InsertDataToSql
        private void button7_Click(object sender, EventArgs e)
        {
            using (var context = new RegistrationContainer1())
            {
                Students student = new Students();

                gender = "N/A";
                if (cbMale.Checked) gender = "K";
                else if (cbFemale.Checked) gender = "Q";

                education = "N/A";
                if (RbBachelor.Checked) education = "B";
                else if (RbMaster.Checked) education = "M";

                try
                {
                    string resultMethod = Validation();

                    if (resultMethod == "")
                    {
                        ImageReader();

                        student.Soyad = txtSurname.Text;
                        student.Ad = txtName.Text;
                        context.Students.Add(student);

                        context.PrivateOfStudent.Add(new PrivateOfStudent
                        {
                            AtaAdi = txtFatherName.Text,
                            //Cinsi=(cbMale.Checked)?"K":(cbFemale.Checked)?"Q":"N/A",
                            Cinsi = gender,
                            DogumTarixi = dtpBirthDate.Value,
                            Milliyeti = txtNationality.Text,
                            Valideynler = txtParents.Text,
                            IsYeri = txtJobs.Text,
                            ElaqeTelefonu = txtPhoneNumber.Text,
                            Email = txtEmail.Text,
                            YasayisYeri = txtAddress.Text,
                            Student = student
                        });

                        context.Education.Add(new Education
                        {
                            Tehsili = CBSchool.SelectedItem.ToString(),
                            Fakulte = CBFaculty.SelectedItem.ToString(),
                            Ixtisas = CBSpeciality.SelectedItem.ToString(),
                            QebulEmri = txtEntranceOrder.Text,
                            QebulTarixi = dtpEnterDate.Value,
                            Bal = txtScore.Text,
                            QrupNo = txtGroupNo.Text,
                            BitirmeTarixi = dtpEndDate.Value,
                            ArayisEmri = rtbAcademicOrder.Text,
                            TehsilPillesi = education,
                            Student = student
                        });

                        context.BookNo.Add(new BookNo
                        {
                            IsNomresi = txtBookNo.Text,
                            Student = student
                        });

                        ImageReader();
                        context.Pictures.Add(new Pictures
                        {
                            Sekil = image,
                            Student = student
                        });

                        context.SaveChanges();
                        if (BtnList.Text == "Ümumi Siyahı")
                        {
                            (System.Windows.Forms.Application.OpenForms["MainForm"] as MainForm).ListData();
                        }

                        DialogResult dialog = MessageBox.Show("Uğurla daxil edildi...", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show(resultMethod, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Məlumatlar Bazaya Yazılmadı! Serverle əlaqənin düzgünlüyünü yoxlayın. " +
                        "Əgər serverlə əlaqə yaradılmayıbsa və ya DataBase yaradılmayıbsa DataBase-i qurmağa yenidən cəhd edin.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region GoToListOfStudent
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (BtnList.Text == "Şəxsi məlumatları əldə et")
                {
                    GetDataForStudents getData = new GetDataForStudents();

                    bookNo = txtBookNo.Text;

                    using (var context = new RegistrationContainer1())
                    {
                        bookNoİD = (from x in context.BookNo
                                    where x.IsNomresi == bookNo
                                    select x.ID).SingleOrDefault();
                        var myStudent = (from s in context.BookNo
                                         select s).First(f => f.ID.Equals(bookNoİD));

                        if (myStudent != null)
                        {
                            var resultForStudents = (from s in context.Students
                                                     join p in context.PrivateOfStudent
                                                     on s equals p.Student
                                                     join ex in context.Education
                                                     on s equals ex.Student
                                                     join pic in context.Pictures
                                                     on s equals pic.Student
                                                     join bN in context.BookNo
                                                     on s equals bN.Student
                                                     where (bN.IsNomresi == bookNo)
                                                     select new
                                                     {
                                                         s.ID,
                                                         s.Soyad,
                                                         s.Ad,
                                                         p.AtaAdi,
                                                         p.DogumTarixi,
                                                         p.YasayisYeri,
                                                         p.ElaqeTelefonu,
                                                         p.Email,
                                                         p.Cinsi,
                                                         p.IsYeri,
                                                         p.Milliyeti,
                                                         p.Valideynler,
                                                         ex.Tehsili,
                                                         ex.Fakulte,
                                                         ex.Ixtisas,
                                                         ex.QebulTarixi,
                                                         ex.Bal,
                                                         ex.QrupNo,
                                                         ex.QebulEmri,
                                                         ex.BitirmeTarixi,
                                                         ex.ArayisEmri,
                                                         ex.TehsilPillesi,
                                                         pic.Sekil,
                                                     }).ToList();

                            getData.DgvGetPersonalData.DataSource = resultForStudents;
                            getData.DgvGetPersonalData.Columns[0].Visible = false;
                            ((DataGridViewImageColumn)getData.DgvGetPersonalData.Columns[22]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                        }
                        getData.ShowDialog();
                    }
                }
                else if (BtnList.Text == "Ümumi Siyahı")
                {
                    MessageBox.Show("Ümumi Siyahı açıqdır.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bu istifadəçi adı və ya şifrəyə uyğun tələbə mövcud deyil.", "Bildiriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region UpdateData
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(txtSurname.Tag);
            try
            {
                using (var content = new RegistrationContainer1())
                {
                    gender = "N/A";
                    if (cbMale.Checked) gender = "K";
                    else if (cbFemale.Checked) gender = "Q";

                    education = "N/A";
                    if (RbBachelor.Checked) education = "B";
                    else if (RbMaster.Checked) education = "M";


                    string resultMethod = Validation();
                    if (resultMethod == "")
                    {
                        var MyStudent = (from s in content.Students
                                         select s).First(f => f.ID.Equals(id));
                        if (MyStudent != null)
                        {
                            MyStudent.Soyad = txtSurname.Text;
                            MyStudent.Ad = txtName.Text;
                        }

                        var MyInformation = (from info in content.PrivateOfStudent
                                             select info).First(f => f.Student.ID == id);
                        if (MyInformation != null)
                        {
                            MyInformation.AtaAdi = txtFatherName.Text;
                            MyInformation.DogumTarixi = dtpBirthDate.Value;
                            MyInformation.YasayisYeri = txtAddress.Text;
                            MyInformation.ElaqeTelefonu = txtPhoneNumber.Text;
                            MyInformation.Email = txtEmail.Text;
                            MyInformation.Cinsi = gender;
                            MyInformation.IsYeri = txtJobs.Text;
                            MyInformation.Valideynler = txtParents.Text;
                        }

                        var MyEducation = (from edu in content.Education
                                           select edu).First(f => f.Student.ID == id);
                        if (MyEducation != null)
                        {
                            MyEducation.Tehsili = CBSchool.Text;
                            MyEducation.Fakulte = CBFaculty.Text;
                            MyEducation.Ixtisas = CBSpeciality.Text;
                            MyEducation.QebulTarixi = dtpEnterDate.Value;
                            MyEducation.BitirmeTarixi = dtpEndDate.Value;
                            MyEducation.Bal = txtScore.Text;
                            MyEducation.QrupNo = txtGroupNo.Text;
                            MyEducation.ArayisEmri = rtbAcademicOrder.Text;
                            MyEducation.QebulEmri = txtEntranceOrder.Text;
                            MyEducation.TehsilPillesi = education;
                        }
                        var MyPicture = (from pic in content.Pictures
                                         select pic).First(p => p.Student.ID == id);

                        ImageReader();
                        if (MyPicture != null)
                        {
                            MyPicture.Sekil = image;
                        }

                        var MyBookNo = (from book in content.BookNo
                                        select book).First(f => f.Student.ID == id);

                        if (MyBookNo != null)
                        {
                            MyBookNo.IsNomresi = txtBookNo.Text;
                        }

                        content.SaveChanges();

                        MessageBox.Show("Uğurla yeniləndi...", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (BtnList.Text == "Ümumi Siyahı")
                        {
                            (System.Windows.Forms.Application.OpenForms["MainForm"] as MainForm).ListData();
                        }
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show(resultMethod, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region DeleteStudent
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(txtSurname.Tag);
            DataGridViewRow row = DgvPunPresent.CurrentRow;
            DataGridViewRow rowExclusion = DgvExcRestoration.CurrentRow;

            try
            {
                using (var context = new RegistrationContainer1())
                {
                    DialogResult dialog = MessageBox.Show("Bu tələbəni silmək istədiyinizdən əminsinizmi? ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                        var MyStudent = (from s in context.Students
                                         select s).First(f => f.ID.Equals(id));
                        if (MyStudent != null)
                            context.Students.Remove(MyStudent);

                        var MyInformation = (from info in context.PrivateOfStudent
                                             select info).First(f => f.Student.ID == id);
                        if (MyInformation != null)
                            context.PrivateOfStudent.Remove(MyInformation);

                        var MyEducation = (from edu in context.Education
                                           select edu).First(f => f.Student.ID == id);
                        if (MyEducation != null)
                            context.Education.Remove(MyEducation);

                        var MyBookNo = (from bookno in context.BookNo
                                        select bookno).First(f => f.Student.ID == id);
                        if (MyBookNo != null)
                            context.BookNo.Remove(MyBookNo);

                        if (context.PunismentPresents.Count() != 0)
                        {
                            if (row != null)
                            {                               
                                var MyPunishPresent = (from pp in context.PunismentPresents
                                                       select pp).First(f => f.Student.ID == id);
                                if (MyPunishPresent != null)
                                    context.PunismentPresents.Remove(MyPunishPresent);
                            }                          
                        }

                        if (context.ExclusionRestoration.Count() != 0)
                        {
                            if (rowExclusion != null)
                            {
                                var MyExcRestoration = (from er in context.ExclusionRestoration
                                                        select er).First(f => f.Student.ID == id);
                                if (MyExcRestoration != null)
                                    context.ExclusionRestoration.Remove(MyExcRestoration);
                            }                           
                        }
                      
                        if (context.Transkript.Count() != 0)
                        {
                            var TranskriptID = (from tId in context.Transkript select tId).FirstOrDefault(i => i.Student.ID == id);

                            if (TranskriptID != null)
                            {
                                var MyTranscript = (from t in context.Transkript
                                                    select t).First(f => f.Student.ID == id);
                                if (MyTranscript != null)
                                    context.Transkript.Remove(MyTranscript);
                            }                            
                        }

                        var MyPicture = (from pic in context.Pictures
                                         select pic).First(p => p.Student.ID == id);

                        ImageReader();
                        if (MyPicture != null)
                            context.Pictures.Remove(MyPicture);

                        context.SaveChanges();
                        if (BtnList.Text == "Ümumi Siyahı")
                        {
                            (System.Windows.Forms.Application.OpenForms["MainForm"] as MainForm).ListData();
                        }
                        Clear();
                        //EnabledFalse();
                        //txtBookNo.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region GoToBaseForm
        private void BtnBasicForm_Click(object sender, EventArgs e)
        {
            login = new LoginForm();
            login.Show();
            (System.Windows.Forms.Application.OpenForms["Entrance"] as Entrance).Hide();
            Hide();
            Dispose();
        }
        #endregion

        #region AddSupplementalData
        private void BtnAddSchool_Click(object sender, EventArgs e)
        {
            infor = new SupplementalEduInfor();
            infor.BtnUniver.Enabled = true;
            infor.TxtUniver.Enabled = true;
            infor.ShowDialog();
        }

        private void BtnAddFaculty_Click(object sender, EventArgs e)
        {
            infor = new SupplementalEduInfor();
            infor.BtnFaculity.Enabled = true;
            infor.TxtFaculity.Enabled = true;
            infor.ShowDialog();           
        }

        private void BtnAddSpeciality_Click(object sender, EventArgs e)
        {
            infor = new SupplementalEduInfor();
            infor.BtnSpecial.Enabled = true;
            infor.TxtSpecial.Enabled = true;
            infor.ShowDialog();
        }
        #endregion

        #region ClearMethod
        public void Clear()
        {
            txtBookNo.Text = "";
            txtSurname.Text = "Soyad";
            txtName.Text = "Ad";
            txtFatherName.Text = "Ata Adı";
            dtpBirthDate.Value = DateTime.Now;
            txtNationality.Text = "Milliyəti";
            txtAddress.Text = "Yaşayış Yeri";
            txtParents.Text = "Valideynlər";
            txtJobs.Text = "İşi";
            txtEmail.Text = "Email";
            txtPhoneNumber.Text = "(   )   -   -  -";

            if (cbMale.Checked)
            {
                cbMale.Checked = false;
            }
            else if (cbFemale.Checked)
            {
                cbFemale.Checked = false;
            }
            CBSchool.Text = null;
            CBFaculty.Text = "";
            CBSpeciality.Text = "";
            dtpEnterDate.Value = DateTime.Now;
            txtEntranceOrder.Text = "Qəbul Əmri";
            txtScore.Text = "Müsabiqə üzrə Qəbul Balı";
            txtGroupNo.Text = "Qrup Nömrəsi";

            if (RbBachelor.Checked)
            {
                RbBachelor.Checked = false;
            }
            else if (RbMaster.Checked)
            {
                RbMaster.Checked = false;
            }

            txtBookNo.ForeColor = Color.Black;
            txtSurname.ForeColor = Color.Silver;
            txtName.ForeColor = Color.Silver;
            txtFatherName.ForeColor = Color.Silver;
            txtNationality.ForeColor = Color.Silver;
            txtParents.ForeColor = Color.Silver;
            txtJobs.ForeColor = Color.Silver;
            txtAddress.ForeColor = Color.Silver;
            txtEmail.ForeColor = Color.Silver;
            txtPhoneNumber.ForeColor = Color.Black;
            txtEntranceOrder.ForeColor = Color.Silver;
            CBSchool.ForeColor = Color.Gray;
            CBFaculty.ForeColor = Color.Gray;
            CBSpeciality.ForeColor = Color.Gray;
            txtScore.ForeColor = Color.Silver;
            txtGroupNo.ForeColor = Color.Silver;
            PBStudentsPictures.Image = null;
            if (BtnList.Text == "Şəxsi məlumatları əldə et")
            {
                BtnList.Enabled = false;
            }
            rtbAcademicOrder.ForeColor = Color.Silver;
            DgvPunPresent.DataSource = null;
            DgvExcRestoration.DataSource = null;
        }
        #endregion

        #region ValidationMethod
        private string Validation()
        {
            StringBuilder sb = new StringBuilder();
            pattern = @"^([0-9a-zA-Z]" + @"([\+\-_\.][0-9a-zA-Z]+)*" + @")+" + @"@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,17})$";

            if (txtSurname.Text == "Soyad" && txtSurname.ForeColor == Color.Silver)
                sb.AppendLine("Soyad daxil edilmədi.");

            if (txtName.Text == "Ad" && txtName.ForeColor == Color.Silver)
                sb.AppendLine("Ad daxil edilmədi.");

            if (txtFatherName.Text == "Ata Adı" && txtFatherName.ForeColor == Color.Silver)
                sb.AppendLine("Ata Adı daxil edilmədi.");

            if (dtpBirthDate.Value.Date == DateTime.Today.Date)
                sb.AppendLine("Doğum Tarixi daxil edilmədi.");

            if (txtNationality.Text == "Milliyəti" && txtNationality.ForeColor == Color.Silver)
                sb.AppendLine("Milliyəti daxil edilmədi.");

            if (txtParents.Text == "Valideynlər" && txtParents.ForeColor == Color.Silver)
                sb.AppendLine("Valideynlər haqqında məlumatlar daxil edilmədi.");

            if (txtJobs.Text == "İşi" && txtJobs.ForeColor == Color.Silver)
                sb.AppendLine("İşi daxil edilmədi.");

            if (txtEntranceOrder.Text == "Qəbul Əmri" && txtEntranceOrder.ForeColor == Color.Silver)
                sb.AppendLine("Qəbul Əmri daxil edilmədi.");

            if (dtpEndDate.Value.Date == DateTime.Today.Date)
                sb.AppendLine("Milli Aviasiya Akademiyasını bitirdiyi və ya bitirəcəyi tarix daxil edilmədi.");

            if (txtJobs.Text == "Əmr №" && txtJobs.ForeColor == Color.Silver)
                sb.AppendLine("Milli Aviasiya Akademiyasını bitirdiyi və ya bitirəcəyi haqqında Əmr №-si daxil edilmədi.");

            if (txtBookNo.Text == "İş Nömrəsi" && txtBookNo.ForeColor == Color.Silver)
                sb.AppendLine("İş Nömrəsi daxil edilmədi.");

            if (txtAddress.Text == "Yaşayış Yeri" && txtAddress.ForeColor == Color.Silver)
                sb.AppendLine("Yaşayış Yeri daxil edilmədi.");

            if (!Regex.IsMatch(txtEmail.Text, pattern))
                sb.AppendLine("Email daxil edilmədi və ya düzgün deyil.");

            if (!txtPhoneNumber.MaskFull)
                sb.AppendLine("Telefon nömrəsi daxil edilmədi və ya düzgün deyil..!");

            if (cbMale.Checked == false && cbFemale.Checked == false)
                sb.AppendLine("Cinsiniz daxil edilmədi.");

            if (RbBachelor.Checked == false && RbMaster.Checked == false)
                sb.AppendLine("Təhsil Pilləsi daxil edilmədi.");

            if (CBSchool.SelectedIndex < 0)
                sb.AppendLine("Təhsili daxil edilmədi.");

            if (CBFaculty.SelectedIndex < 0)
                sb.AppendLine("Fakültə daxil edilmədi.");

            if (CBSpeciality.SelectedIndex < 0)
                sb.AppendLine("Ixtisas daxil edilmədi.");

            if (dtpEnterDate.Value.Date == DateTime.Now.Date)
                sb.AppendLine("Qəbul Tarixi daxil edilmədi.");

            if (txtScore.Text == "Müsabiqə üzrə Qəbul Balı" && txtScore.ForeColor == Color.Silver)
                sb.AppendLine("Qəbul Balı daxil edilmədi.");

            if (txtGroupNo.Text == "Qrup Nömrəsi" && txtGroupNo.ForeColor == Color.Silver)
                sb.AppendLine("Qrup Nömrəsi daxil edilmədi.");

            if (/*PBStudentsPictures.ImageLocation == null ||*/ PBStudentsPictures.Image == null)
                sb.AppendLine("Şəkil daxil edilmədi.");

            return sb.ToString();
        }
        #endregion

        #region SelectPictures
        private void btnAddPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                ImageLocation = openFile.FileName.ToString();
                PBStudentsPictures.ImageLocation = ImageLocation;
                PBStudentsPictures.BackgroundImageLayout = ImageLayout.Stretch;
                PBStudentsPictures.BackgroundImage = null;
            }
        }
        #endregion

        #region ImageReaderMethod
        private void ImageReader()
        {
            if (PBStudentsPictures.ImageLocation != null)
            {
                FileStream file = new FileStream(ImageLocation, FileMode.Open, FileAccess.Read);
                BinaryReader reader = new BinaryReader(file);
                image = reader.ReadBytes((int)file.Length);
            }
            else if (PBStudentsPictures.Image != null)
            {
                Image images = PBStudentsPictures.Image;
                ImageConverter converter = new ImageConverter();
                image = (byte[])converter.ConvertTo(images, typeof(byte[]));
            }
        }
        #endregion

        #region EncryptMethodForPasswordAndUserName
        public string EncryptPassword(string password)
        {
            MD5CryptoServiceProvider mD5 = new MD5CryptoServiceProvider();
            mD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));
            byte[] result = mD5.Hash;
            StringBuilder str = new StringBuilder();

            for (int i = 1; i < result.Length; i++)
            {
                str.Append(result[i].ToString("x2"));
            }
            return str.ToString();
        }

        public string EncryptUsername(string username)
        {
            MD5CryptoServiceProvider mD5 = new MD5CryptoServiceProvider();
            mD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(username));
            byte[] result = mD5.Hash;
            StringBuilder str = new StringBuilder();

            for (int i = 1; i < result.Length; i++)
            {
                str.Append(result[i].ToString("x2"));
            }
            return str.ToString();
        }
        #endregion

        #region MethodForDoEnabledTrue
        public void EnabledTrue()
        {
            txtSurname.Enabled = true;
            txtName.Enabled = true;
            txtFatherName.Enabled = true;
            txtAddress.Enabled = true;
            txtNationality.Enabled = true;
            txtParents.Enabled = true;
            txtJobs.Enabled = true;
            txtEmail.Enabled = true;
            txtGroupNo.Enabled = true;
            txtScore.Enabled = true;
            txtPhoneNumber.Enabled = true;
            txtEntranceOrder.Enabled = true;
            dtpBirthDate.Enabled = true;
            dtpEnterDate.Enabled = true;
            dtpEndDate.Enabled = true;
            cbMale.Enabled = true;
            cbFemale.Enabled = true;
            RbBachelor.Enabled = true;
            RbMaster.Enabled = true;
            CBSchool.Enabled = true;
            CBSchool.Enabled = true;
            CBFaculty.Enabled = true;
            CBSpeciality.Enabled = true;
            PBStudentsPictures.Enabled = true;
            BtnAddSchool.Enabled = true;
            BtnAddFaculty.Enabled = true;
            BtnAddSpeciality.Enabled = true;
            rtbAcademicOrder.Enabled = true;
            btnAddPicture.Enabled = true;
            //BtnPrint.Enabled = true;
            //BtnInsert.Enabled = true;
        }
        #endregion

        #region EnabledPunishPresentAndExcRestoration
        public void EnabledPunishPresentAndExcRestoration()
        {
            //ChBPunish.Enabled = true;
            //ChBPresent.Enabled = true;
            //ChBExclusion.Enabled = true;
            //ChBRestoration.Enabled = true;
            //rtbPunPresReason.Enabled = true;
            //rtbExcResOrder.Enabled = true;
            //rtbExcResReason.Enabled = true;
            //BtnShowPunPres.Enabled = true;
            //BtnExcRestoration.Enabled = true;
            //dtpExcResDate.Enabled = true;
            //dtbPunPresDate.Enabled = true;
            //AddPunishPresents.Enabled = true;
            //AddPunishPresents.Enabled = true;
            //BtnUpdatePunishPresents.Enabled = true;
            //BtnAddExcRestoration.Enabled = true;
            //BtnUpdateExcRestoration.Enabled = true;
        }
        #endregion

        #region EnableFalseMethod
        public void EnabledFalse()
        {
            txtSurname.Enabled = false;
            txtName.Enabled = false;
            txtFatherName.Enabled = false;
            txtAddress.Enabled = false;
            txtNationality.Enabled = false;
            txtParents.Enabled = false;
            txtJobs.Enabled = false;
            txtEmail.Enabled = false;
            txtPhoneNumber.Enabled = false;
            txtEntranceOrder.Enabled = false;
            cbFemale.Enabled = false;
            cbMale.Enabled = false;
            RbBachelor.Enabled = false;
            RbMaster.Enabled = false;
            CBFaculty.Enabled = false;
            CBSchool.Enabled = false;
            CBSpeciality.Enabled = false;
            //ChBPresent.Enabled = false;
            //ChBPunish.Enabled = false;
            //ChBExclusion.Enabled = false;
            //ChBRestoration.Enabled = false;
            txtScore.Enabled = false;
            txtGroupNo.Enabled = false;
            dtpBirthDate.Enabled = false;
            dtpEnterDate.Enabled = false;
            dtpEndDate.Enabled = false;
            //dtbPunPresDate.Enabled = false;
            //dtpExcResDate.Enabled = false;
            //BtnShowPunPres.Enabled = false;
            BtnAddFaculty.Enabled = false;
            BtnAddSchool.Enabled = false;
            BtnAddSpeciality.Enabled = false;
            PBStudentsPictures.Enabled = false;
            BtnInsert.Enabled = false;
            BtnTranscription.Enabled = false;
            rtbAcademicOrder.Enabled = false;
            //rtbPunPresReason.Enabled = false;
            //rtbExcResReason.Enabled = false;
            //rtbExcResOrder.Enabled = false;
            btnAddPicture.Enabled = false;
            //BtnExcRestoration.Enabled = false;
            //AddPunishPresents.Enabled = false;
            //BtnUpdatePunishPresents.Enabled = false;
            //BtnAddExcRestoration.Enabled = false;
            //BtnUpdateExcRestoration.Enabled = false;
            BtnUpdate.Enabled = false;
            BtnDelete.Enabled = false;
            BtnPrint.Enabled = false;
            btnAddPicture.Enabled = false;
        }
        #endregion

        #region ShowPunismentsPresentsAndExclusionsRestorations
        private void BtnExcRestoration_Click(object sender, EventArgs e)
        {
            exclusionRestorations = new ExclusionRestorations();
            try
            {
                bookNo = txtBookNo.Text;
                using (var context = new RegistrationContainer1())
                {
                    bookNoİD = (from x in context.BookNo
                                where x.IsNomresi == bookNo
                                select x.ID).First();

                    var myStudent = (from s in context.Students
                                     select s).First(f => f.ID.Equals(bookNoİD));

                    if (myStudent != null)
                    {
                        var showExcRstoration = (from s in context.Students
                                                 join er in context.ExclusionRestoration
                                                 on s equals er.Student
                                                 join bN in context.BookNo
                                                 on s equals bN.Student
                                                 where (bN.IsNomresi == bookNo)
                                                 select new
                                                 {
                                                     er.XaricBerpaID,
                                                     er.XaricetmeBerpaetme,
                                                     er.Sebeb,
                                                     er.Tarix,
                                                     er.Emr,
                                                 }).ToList();

                        DgvExcRestoration.DataSource = showExcRstoration;
                        DgvExcRestoration.Columns[0].Visible = false;
                    }
                    exclusionRestorations.ShowDialog();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region TranscriptForm
        private void BtnTranscription_Click(object sender, EventArgs e)
        {
            transkriptForm = new TranskriptForm();
            try
            {
                string bookNo = txtBookNo.Text;

                using (var context = new RegistrationContainer1())
                {
                    int bookNoİD = (from x in context.BookNo
                                    where x.IsNomresi == bookNo
                                    select x.ID).FirstOrDefault();
                    var myStudent = (from s in context.BookNo
                                     select s).First(f => f.ID.Equals(bookNoİD));

                    if (myStudent != null)
                    {
                        var transcriptDatas = (from s in context.Students
                                               join bN in context.BookNo
                                               on s equals bN.Student
                                               join t in context.Transkript
                                               on s equals t.Student
                                               where (bN.IsNomresi == bookNo)
                                               select new
                                               {
                                                   t.TranskriptID,
                                                   t.Fenn,
                                                   t.Semestr,
                                                   t.Qiymet,
                                                   t.Kredit,
                                                   t.Bal,
                                               }).ToList();

                        transkriptForm.DgvTranskript.DataSource = transcriptDatas;
                        transkriptForm.DgvTranskript.Columns[0].Visible = false;


                        transkriptForm.LblNameSurname.Text = txtName.Text + " " + txtSurname.Text;
                        transkriptForm.LblBirthDate.Text = dtpBirthDate.Value.ToShortDateString();
                        transkriptForm.LblAddress.Text = txtAddress.Text;
                        transkriptForm.LblFaculty.Text = CBFaculty.Text;
                        transkriptForm.LblSpeciality.Text = CBSpeciality.Text;
                        transkriptForm.LblGroupNo.Text = txtGroupNo.Text;
                        if (RbBachelor.Checked)
                        {
                            transkriptForm.LblEducation.Text = "Bakalavr";
                        }
                        else if (RbMaster.Checked)
                        {
                            transkriptForm.LblEducation.Text = "Magistr";
                        }
                    }
                }
                transkriptForm.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("Bu Şəxsi iş Nömrəsinə uyğun Tələbə yoxdur..!", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region AddNewPunismentsPresentsAndExclusionsRestorations
        private void BtnAddExcRestoration_Click(object sender, EventArgs e)
        {
           
        }
        #endregion

        #region UpdatePunismentsPresentsAndExclusionsRestorations
        private void BtnUpdateExcRestoration_Click(object sender, EventArgs e)
        {
            
        }
        #endregion

        #region TextboxTextChanged
        private void txtSurname_TextChanged(object sender, EventArgs e)
        {
            BtnInsert.Enabled = true;
        }
        private void txtBookNo_TextChanged(object sender, EventArgs e)
        {
            if (txtBookNo.Text == "")
            {
                EnabledFalse();
            }
            else
            {
                BtnList.Enabled = true;
                EnabledTrue();
            }
        }
        #endregion
     
        #region DgvPunishPresentsClik
        private void DgvPunPresent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            punishmentPresents = new PunishmentPresents();
            punishmentPresents.BtnUpdatePunishPresents.Enabled = true;
            punishmentPresents.AddPunishPresents.Enabled = false;

            DataGridViewRow row = DgvPunPresent.CurrentRow;

            punishmentPresents.rtbPunPresReason.Text = row.Cells["Sebebi"].Value.ToString();
            punishmentPresents.rtbPunPresReason.Tag = row.Cells["MukafatCezaID"].Value.ToString();
            punishmentPresents.dtbPunPresDate.Text = row.Cells["Tarixi"].Value.ToString();
            if (row.Cells["MukafatCeza"].Value.ToString() == "M")
            {
                punishmentPresents.ChBPresent.Checked = true;
            }
            else if (row.Cells["MukafatCeza"].Value.ToString() == "C")
            {
                punishmentPresents.ChBPunish.Checked = true;
            }
            else
            {
                punishmentPresents.ChBPresent.Checked = false;
                punishmentPresents.ChBPunish.Checked = false;
            }

            punishmentPresents.rtbPunPresReason.ForeColor = Color.Black;
            punishmentPresents.ShowDialog();
        }
        #endregion

        #region ShowPunismentsPresentsAndExclusionsRestorations
        public void ShowPunishPresent()
        {
            try
            {
                bookNo = txtBookNo.Text;
                using (var context = new RegistrationContainer1())
                {
                    bookNoİD = (from x in context.BookNo
                                where x.IsNomresi == bookNo
                                select x.ID).First();
                    var myStudent = (from s in context.BookNo
                                     select s).First(f => f.ID.Equals(bookNoİD));

                    if (myStudent != null)
                    {
                        var showPresentPunisment = (from s in context.Students
                                                    join pp in context.PunismentPresents
                                                    on s equals pp.Student
                                                    join bN in context.BookNo
                                                    on s equals bN.Student
                                                    where (bN.IsNomresi == bookNo)
                                                    select new
                                                    {
                                                        pp.MukafatCezaID,
                                                        pp.MukafatCeza,
                                                        pp.Sebebi,
                                                        pp.Tarixi,
                                                    }).ToList();

                        DgvPunPresent.DataSource = showPresentPunisment;
                        DgvPunPresent.Columns[0].Visible = false;
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region ShowExclusionRestoration
        public void ShowExclusionRestoration()
        {
            try
            {
                bookNo = txtBookNo.Text;
                using (var context = new RegistrationContainer1())
                {
                    bookNoİD = (from x in context.BookNo
                                where x.IsNomresi == bookNo
                                select x.ID).First();
                    var myStudent = (from s in context.BookNo
                                     select s).First(f => f.ID.Equals(bookNoİD));

                    if (myStudent != null)
                    {
                        var showExcRestoration = (from s in context.Students
                                                    join ex in context.ExclusionRestoration
                                                    on s equals ex.Student
                                                    join bN in context.BookNo
                                                    on s equals bN.Student
                                                    where (bN.IsNomresi == bookNo)
                                                    select new
                                                    {
                                                        ex.XaricBerpaID,
                                                        ex.XaricetmeBerpaetme,
                                                        ex.Sebeb,
                                                        ex.Emr,
                                                        ex.Tarix
                                                    }).ToList();

                        DgvExcRestoration.DataSource = showExcRestoration;
                        DgvExcRestoration.Columns[0].Visible = false;
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region AddNewPunishPresents
        private void BtnShowPunPres_Click_1(object sender, EventArgs e)
        {
            punishmentPresents = new PunishmentPresents();
            punishmentPresents.ShowDialog();
        }
        #endregion

        #region FindAndReplaceMethod
        private void FindAndReplace(Microsoft.Office.Interop.Word.Application wordApp, object findText, object replaceWithText)
        {
            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundLike = false;
            object matchAllForms = false;
            object forward = true;
            object format = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;

            wordApp.Selection.Find.Execute(ref findText, ref matchCase,
                ref matchWholeWord, ref matchWildCards,
                ref matchSoundLike, ref matchAllForms,
                ref forward, ref wrap, ref format,
                ref replaceWithText, ref replace,
                ref matchControl);
        }
        #endregion

        #region CreateWordDocument
        private void CreateWordDocument(object fileName, object saveAs)
        {

            string type = FillPunishPresentType();
            string reason = FillPunishPresentReason();
            string date = FillPunishPresentDate();
            string typeExcRes = FillExcRestorationType();
            string excResReason = FillExcRestorationReason();
            string excResDate = FillExcRestorationDate();
            string excResOrder = FillExcRestorationOrder();


            object missing = Missing.Value;

            Word.Application wordApp = new Word.Application();

            Word.Document aDoc = null;
            try
            {
                if (File.Exists((string)fileName))
                {
                    object readOnly = false;
                    object isVisible = false;

                    wordApp.Visible = false;

                    aDoc = wordApp.Documents.Open(ref fileName, ref missing, ref readOnly,
                            ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref isVisible,
                            ref missing, ref missing, ref missing, ref missing);

                    aDoc.Activate();

                    this.FindAndReplace(wordApp, "< Soyad >", txtSurname.Text.Trim());
                    this.FindAndReplace(wordApp, "< Ad >", txtName.Text.Trim());
                    this.FindAndReplace(wordApp, "< Ata Adı >", txtFatherName.Text.Trim());
                    this.FindAndReplace(wordApp, "< Doğum Tarixi >", dtpBirthDate.Value.ToShortDateString());
                    this.FindAndReplace(wordApp, "< Milliyəti >", txtNationality.Text.Trim());
                    this.FindAndReplace(wordApp, "< Valideynlər >", txtParents.Text.Trim());
                    this.FindAndReplace(wordApp, "< Ünvan >", txtAddress.Text.Trim());
                    this.FindAndReplace(wordApp, "< İş Yeri >", txtJobs.Text.Trim());
                    this.FindAndReplace(wordApp, "< Email >", txtEmail.Text.Trim());
                    this.FindAndReplace(wordApp, "< Telefon >", txtPhoneNumber.Text.Trim());

                    if (cbMale.Checked)
                    {
                        this.FindAndReplace(wordApp, "< Cinsi >", "Kişi");
                    }
                    else if (cbFemale.Checked)
                    {
                        this.FindAndReplace(wordApp, "< Cinsi >", "Qadın");
                    }

                    this.FindAndReplace(wordApp, "< Təhsil >", CBSchool.Text.Trim());

                    if (RbBachelor.Checked)
                    {
                        this.FindAndReplace(wordApp, "< Təhsil Pilləsi >", "Bakalavr");
                    }
                    else if (RbMaster.Checked)
                    {
                        this.FindAndReplace(wordApp, "< Təhsil Pilləsi >", "Magistr");
                    }


                    this.FindAndReplace(wordApp, "< Fakültə >", CBFaculty.Text.Trim());
                    this.FindAndReplace(wordApp, "< İxtisas >", CBSpeciality.Text.Trim());
                    this.FindAndReplace(wordApp, "< Qəbul Tarixi >", dtpEnterDate.Value.ToShortDateString());
                    this.FindAndReplace(wordApp, "< Qəbul Əmri >", txtEntranceOrder.Text.Trim());
                    this.FindAndReplace(wordApp, "< Qrup >", txtGroupNo.Text.Trim());
                    this.FindAndReplace(wordApp, "< Kitabça >", txtBookNo.Text.Trim());
                    this.FindAndReplace(wordApp, "< Qəbul Balı >", txtScore.Text.Trim());
                    this.FindAndReplace(wordApp, "< Bitirmə Tarixi >", dtpEndDate.Value.ToShortDateString());
                    this.FindAndReplace(wordApp, "< Arayış əmri >", rtbAcademicOrder.Text.Trim());

                    this.FindAndReplace(wordApp, "< MükafatCəzaTipi >", type);
                    this.FindAndReplace(wordApp, "< MükafatCəza Səbəbi >", reason);
                    this.FindAndReplace(wordApp, "< MükafatCəzaTarixi >", date);

                    //PopulateFileWithExcRestoration(wordApp, "< XaricBərpaTipi >", sb);
                    this.FindAndReplace(wordApp, "< XaricBərpaTipi >", typeExcRes);
                    this.FindAndReplace(wordApp, "< XaricBərpa Səbəbi >", excResReason);
                    this.FindAndReplace(wordApp, "< XaricBərpa Tarixi >", excResDate);
                    this.FindAndReplace(wordApp, "< XaricBərpaƏmri>", excResOrder);

                }
                else
                {
                    MessageBox.Show("Fayl mövcud deyil!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                aDoc.SaveAs2(ref saveAs, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing);

                MessageBox.Show("Fayl yaradıldı...", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                aDoc.Close(ref missing, ref missing, ref missing);
            }
        }
        #endregion

        #region ExportDataToWordFile
        private void BtnPrint_Click(object sender, EventArgs e)
        {
            string fileName = null;

            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                fileName = OpenFile.FileName;
            }

            if (SaveFile.ShowDialog() == DialogResult.OK)
            {
                CreateWordDocument(fileName, SaveFile.FileName);
            }
        }
        #endregion

        #region ExportPunismentsPresentsToWordDoc

        //Punishment-Presents Type
        private string FillPunishPresentType()
        {
            StringBuilder sb = new StringBuilder();
            num = 0;
            foreach (DataGridViewRow rows in DgvPunPresent.Rows)
            {
                if (rows.Cells[1].Value.ToString() == "M")
                {
                    education = "Mükafat";
                }
                else if (rows.Cells[1].Value.ToString() == "C")
                {
                    education = "Cəza";
                }
                num++;
                sb.Append(num + "." + education);
                sb.Append("\n\n\n");
            }
            return sb.ToString();
        }

        //Punishment-Presents Reason
        private string FillPunishPresentReason()
        {
            StringBuilder sb = new StringBuilder();
            num = 0;
            foreach (DataGridViewRow rows in DgvPunPresent.Rows)
            {
                string punishPresentReason = rows.Cells[2].Value.ToString();
                num++;
                sb.Append(num + "." + punishPresentReason);
                sb.Append("\n\n\n");
            }
            return sb.ToString();
        }

        //Punishment-Presents DateTime
        private string FillPunishPresentDate()
        {
            StringBuilder sb = new StringBuilder();
            num = 0;

            foreach (DataGridViewRow rows in DgvPunPresent.Rows)
            {
                string punishPresentDate = Convert.ToDateTime(rows.Cells[3].Value).ToShortDateString();
                num++;
                sb.Append(num + "." + punishPresentDate);
                sb.Append("\n\n\n");
            }
            return sb.ToString();
        }
        #endregion

        #region ExportExclusionRestorationToWordDoc
        //Exclusion-Restoration Type
        private string FillExcRestorationType()
        {
            StringBuilder sb = new StringBuilder();
            num = 0;
            foreach (DataGridViewRow rows in DgvExcRestoration.Rows)
            {
                if (rows.Cells[1].Value.ToString() == "X")
                {
                    education = "Xaricetmə";
                }
                else if (rows.Cells[1].Value.ToString() == "B")
                {
                    education = "Bərpaetmə";
                }
                num++;
                sb.Append(num + "." + education);
                sb.Append("\n\n\n");
            }
            return sb.ToString();
        }

        //Exclusion-Restoration Reason
        private string FillExcRestorationReason()
        {
            StringBuilder sb = new StringBuilder();
            num = 0;
            foreach (DataGridViewRow rows in DgvExcRestoration.Rows)
            {
                string excRestorationReason = rows.Cells[2].Value.ToString();
                num++;
                sb.Append(num + "." + excRestorationReason);
                sb.Append("\n\n\n");
            }
            return sb.ToString();
        }
        //Exclusion-Restoration Order
        private string FillExcRestorationOrder()
        {
            StringBuilder sb = new StringBuilder();
            num = 0;
            foreach (DataGridViewRow rows in DgvExcRestoration.Rows)
            {
                string excRestorationOrder = rows.Cells[3].Value.ToString();
                num++;
                sb.Append(num + "." + excRestorationOrder);
                sb.Append("\n\n\n");
            }
            return sb.ToString();
        }

        //Exclusion-Restoration DateTime
        private string FillExcRestorationDate()
        {
            StringBuilder sb = new StringBuilder();
            num = 0;

            foreach (DataGridViewRow rows in DgvExcRestoration.Rows)
            {
                string excRestorationDate = Convert.ToDateTime(rows.Cells[4].Value).ToShortDateString();
                num++;
                sb.Append(num + "." + excRestorationDate);
                sb.Append("\n\n\n");
            }
            return sb.ToString();
        }

        #endregion

        #region DgvExclusionRestorationClik
        private void DgvExcRestoration_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            exclusionRestorations = new ExclusionRestorations();
            exclusionRestorations.BtnUpdateExcRestoration.Enabled = true;
            exclusionRestorations.BtnAddExcRestoration.Enabled = false;

            DataGridViewRow row = DgvExcRestoration.CurrentRow;

            exclusionRestorations.rtbExcResReason.Text = row.Cells["Sebeb"].Value.ToString();
            exclusionRestorations.rtbExcResReason.Tag = row.Cells["XaricBerpaID"].Value.ToString();
            exclusionRestorations.rtbExcResOrder.Text = row.Cells["Emr"].Value.ToString();
            exclusionRestorations.dtpExcResDate.Text = row.Cells["Tarix"].Value.ToString();

            if (row.Cells["XaricetmeBerpaetme"].Value.ToString() == "X")
            {
                exclusionRestorations.ChBExclusion.Checked = true;
            }
            else if (row.Cells["XaricetmeBerpaetme"].Value.ToString() == "B")
            {
                exclusionRestorations.ChBRestoration.Checked = true;
            }
            else
            {
                exclusionRestorations.ChBExclusion.Checked = false;
                exclusionRestorations.ChBRestoration.Checked = false;
            }

            exclusionRestorations.rtbExcResReason.ForeColor = Color.Black;
            exclusionRestorations.rtbExcResOrder.ForeColor = Color.Black;
            exclusionRestorations.ShowDialog();
        }
        #endregion

        #region AddNewExclusionRestoration
        private void BtnShowExclusionRestoration_Click(object sender, EventArgs e)
        {
            exclusionRestorations = new ExclusionRestorations();
            exclusionRestorations.ShowDialog();
        }
        #endregion
    }
}