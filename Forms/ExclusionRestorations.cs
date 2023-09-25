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
    public partial class ExclusionRestorations : Form
    {
        public ExclusionRestorations()
        {
            InitializeComponent();
        }
        public int id { get; set; }

        #region AddExclusionRestoration
        private void BtnAddExcRestoration_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32((Application.OpenForms["BasicForm"] as BasicForm).txtSurname.Tag);

            using (var context = new RegistrationContainer1())
            {
                Students student = (from s in context.Students
                                    select s).First(f => f.ID.Equals(id));

                context.ExclusionRestoration.Add(new ExclusionRestoration
                {
                    XaricetmeBerpaetme = (ChBExclusion.Checked) ? "X" : (ChBRestoration.Checked) ? "B" : " ",
                    Sebeb = (rtbExcResReason.Text == "Səbəb" && rtbExcResReason.ForeColor == Color.Silver) ? " " : (rtbExcResReason.Text != "Səbəb"
                            && rtbExcResReason.ForeColor == Color.Black) ? rtbExcResReason.Text : "Xaricedilmə və Bərpaedilməsi yoxdur",
                    Tarix = dtpExcResDate.Value,
                    Emr = (rtbExcResOrder.Text == "Əmr №" && rtbExcResOrder.ForeColor == Color.Silver) ? " " : (rtbExcResOrder.Text != "Əmr №"
                            && rtbExcResOrder.ForeColor == Color.Black) ? rtbExcResOrder.Text : "Xaricedilmə və Bərpaedilmə Əmri yoxdur",
                    Student = student
                });
                context.SaveChanges();
            }
            MessageBox.Show("Uğurla daxil edildi...", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            (Application.OpenForms["BasicForm"] as BasicForm).ShowExclusionRestoration();
            ClearExcRestorations();
        }
        #endregion

        #region UpdateExclusionRestoration
        private void BtnUpdateExcRestoration_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(rtbExcResReason.Tag);

            using (var context = new RegistrationContainer1())
            {
                var myExcRestoration = (from ex in context.ExclusionRestoration
                                        select ex).First(f => f.XaricBerpaID.Equals(id));

                if (myExcRestoration != null)
                {
                    myExcRestoration.XaricetmeBerpaetme = (ChBExclusion.Checked) ? "X" : (ChBRestoration.Checked) ? "B" : " ";
                    myExcRestoration.Sebeb = (rtbExcResReason.Text == "Səbəb" && rtbExcResReason.ForeColor == Color.Silver) ? " " : (rtbExcResReason.Text != "Səbəb"
                            && rtbExcResReason.ForeColor == Color.Black) ? rtbExcResReason.Text : "Xaricedilmə və Bərpaedilməsi yoxdur";
                    myExcRestoration.Tarix = dtpExcResDate.Value;
                    myExcRestoration.Emr = (rtbExcResOrder.Text == "Əmr №" && rtbExcResOrder.ForeColor == Color.Silver) ? " " : (rtbExcResOrder.Text != "Əmr №"
                            && rtbExcResOrder.ForeColor == Color.Black) ? rtbExcResOrder.Text : "Xaricedilmə və Bərpaedilmə Əmri yoxdur";
                }
                context.SaveChanges();
            }
            MessageBox.Show("Uğurla Yeniləndi...", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            (Application.OpenForms["BasicForm"] as BasicForm).ShowExclusionRestoration();
            ClearExcRestorations();
        }
        #endregion

        #region ClearMethod
        public void ClearExcRestorations()
        {
            rtbExcResReason.Text = "Səbəb";
            rtbExcResOrder.Text = "Əmr №";
            dtpExcResDate.Value = DateTime.Now;

            if (ChBExclusion.Checked)
                ChBExclusion.Checked = false;
            else if (ChBRestoration.Checked)
                ChBRestoration.Checked = false;

            rtbExcResReason.ForeColor = Color.Silver;
            rtbExcResOrder.ForeColor = Color.Silver;
        }
        #endregion

        #region PlaceHolder
        private void rtbExcResOrder_Enter(object sender, EventArgs e)
        {
            if (rtbExcResOrder.Text == "Əmr №")
            {
                rtbExcResOrder.Text = "";
                rtbExcResOrder.ForeColor = Color.Black;
            }
        }

        private void rtbExcResOrder_Leave(object sender, EventArgs e)
        {
            if (rtbExcResOrder.Text == "")
            {
                rtbExcResOrder.Text = "Əmr №";
                rtbExcResOrder.ForeColor = Color.Silver;
            }
        }

        private void ChBExclusion_CheckedChanged(object sender, EventArgs e)
        {
            if (ChBExclusion.Checked == true)
            {
                ChBRestoration.Checked = false;
            }
        }

        private void ChBRestoration_CheckedChanged(object sender, EventArgs e)
        {
            if (ChBRestoration.Checked == true)
            {
                ChBExclusion.Checked = false;
            }
        }

        private void rtbExcResReason_Enter(object sender, EventArgs e)
        {
            if (rtbExcResReason.Text == "Səbəb")
            {
                rtbExcResReason.Text = "";
                rtbExcResReason.ForeColor = Color.Black;
            }
        }

        private void rtbExcResReason_Leave(object sender, EventArgs e)
        {
            if (rtbExcResReason.Text == "")
            {
                rtbExcResReason.Text = "Səbəb";
                rtbExcResReason.ForeColor = Color.Silver;
            }
        }
        #endregion
    }
}
