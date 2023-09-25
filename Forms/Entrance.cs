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
    public partial class Entrance : Form
    {
        public Entrance()
        {
            InitializeComponent();
        }      

        public BasicForm basic { get; set; }
        public LoginForm login { get; set; }

        #region MoveForm
        Point lastPoint = new Point();
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
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

        #region CloseForm
        private void BtnExit_Click(object sender, EventArgs e)
        {
            login = new LoginForm();
            login.Show();
            GC.Collect();
            Close();
        }
        #endregion

        #region GoToRegistration
        private void BtnRegister_Click(object sender, EventArgs e)
        {
            basic = new BasicForm();

            Hide();

            basic.Show();
            basic.BtnBasicForm.Enabled = true;
            //basic.BtnInsert.Enabled = false;
        }
        #endregion

        #region GoToListOfStudent
        private void BtnList_Click(object sender, EventArgs e)
        {
            MainForm main = new MainForm();
            main.Show();
            main.ListData();
            Hide();
        }
        #endregion
    }
}
