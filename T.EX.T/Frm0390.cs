using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using T.EX.T;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;



namespace TEXT
{
    public partial class Frm0390 : Form
    {
        public Frm0390()
        {
            InitializeComponent();

        }


        private void Frm0390_Load(object sender, EventArgs e)
        {
            string user = Session.Username;
            lblUsername.Text = user;

            FillComboBox(cbbReOven, "Re-Oven Baking", "Code");
            FillComboBox(cbbShift, "Shift", "Code");
            FillComboBox(cbbFIPGMatCode, "FIPG Material", "Code");
            FillComboBox(cbbPartName, "Part name", "Part name");
            FillComboBox(cbbProductRevision, "Product Revision", "Code");
            FillComboBox(cbbTool, "Fixture", "Code");
            FillComboBox(cbbCoverMaterialCode, "Cover Material", "Code");

        }
        private void FillComboBox(ComboBox cb, string tableName, string columnName)
        {
            cb.Items.Clear(); // ล้างก่อนเติม
            var list = SqlSelect.GetList(tableName, columnName);
            foreach (var item in list)
            {
                cb.Items.Add(item);
            }
        }
        private void Frm0390_Shown(object sender, EventArgs e)
        {
            pnl0390.Focus();
            cbbPartName.Focus();
        }
        private void Frm0390_Resize(object sender, EventArgs e)
        {
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;


            pnlHeader.Width = formWidth;
            pnl0390.Width = formWidth - 160;
            pnl0390.Height = formHeight - pnlHeader.Height - 20;
            pnl0390.Location = new Point((formWidth - pnl0390.Width) / 2, (formHeight - pnl0390.Height + pnlHeader.Height) / 2);

            pnl0390.MakePanelRounded(20);
            btn39Reset.MakeButtonRounded(6);
            btn39ChkBar.MakeButtonRounded(6);
            btn39Save.MakeButtonRounded(6);
            btn39Next.MakeButtonRounded(6);
        }

        private void lblText_Click(object sender, EventArgs e)
        {

        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn39ChkBar_Click(object sender, EventArgs e)
        {
            bool result = true;
            string Noti = "";

            if (txtPlotting.Text == "")
            {
                MessageBox.Show("Please fill Plotting Date", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txtStartSN.Text == "")
            {
                MessageBox.Show("Please fill Start Serial no.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txtEndSN.Text == "")
            {
                MessageBox.Show("Please fill End Serial no.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ///Start 2D

            if (txt2DStart.Text.Substring(13,2) != txtPlotting.Text.Substring(1,2)) //ChkPosition1 Plotting Day
            {
                Noti = "Start_Edit WW " + txt2DStart.Text.Substring(13, 2) + "==>" + txtPlotting.Text.Substring(1, 2);
                result = false;

            }
            
            if (txt2DStart.Text.Substring(15, 1) != txtPlotting.Text.Substring(3, 1)) //ChkPosition2 Plotting Day
            {
                Noti += Environment.NewLine + "Start_Edit Day " + txt2DStart.Text.Substring(15, 1)  + "==>" + txtPlotting.Text.Substring(3, 1);
                result = false;

            }

            if (txt2DStart.Text.Substring(23, 4) != txtStartSN.Text) //ChkPosition3 Start SN
            {
                Noti += Environment.NewLine + "Start_Edit Start SN " + txt2DStart.Text.Substring(23, 4) + "==>" + txtStartSN.Text;
                result = false;

            }
           

            if (result == false)
            {
                MessageBox.Show(Noti, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt2DResult.Text = "NG";

                txt2DResult.BackColor = Color.FromArgb(255, 192, 192);
            }
            else
            {
                txt2DResult.BackColor = Color.FromArgb(192, 255, 192);
                txt2DResult.Text = "Pass";
 
            }

            ///End 2D
             if (txt2DEnd.Text.Substring(13,2) != txtPlotting.Text.Substring(1,2)) //ChkPosition1 Plotting Day
            {
                Noti = "End_Edit WW " + txt2DEnd.Text.Substring(13, 2) + "==>" + txtPlotting.Text.Substring(1, 2);
                result = false;

            }

            if (txt2DEnd.Text.Substring(15, 1) != txtPlotting.Text.Substring(3, 1)) //ChkPosition2 Plotting Day
            {
                Noti += Environment.NewLine + "End_Edit Day " + txt2DEnd.Text.Substring(15, 1) + "==>" + txtPlotting.Text.Substring(3, 1);
                result = false;

            }

            if (txt2DEnd.Text.Substring(23, 4) != txtEndSN.Text) //ChkPosition3 End SN
            {
                Noti += Environment.NewLine + "End_Edit End SN " + txt2DEnd.Text.Substring(23, 4) + "==>" + txtEndSN.Text;
                result = false;

            }


            if (result == false)
            {
                MessageBox.Show(Noti, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt2DResult.Text = "NG";

                txt2DResult.BackColor = Color.FromArgb(255, 192, 192);
            }
            else
            {
                txt2DResult.BackColor = Color.FromArgb(192, 255, 192);
                txt2DResult.Text = "Pass";

            }
        }

        private void icoSetting_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmSetting FrmSetting = new FrmSetting();
            FrmSetting.FormClosed += (s, args) => Application.Exit();
            FrmSetting.Show();
        }

        private void icoLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLogIn loginForm = new FrmLogIn();
            loginForm.FormClosed += (s, args) => Application.Exit();
            loginForm.Show();
        }

        private void icoBack2Opn_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmOpn OpnForm = new FrmOpn();
            OpnForm.FormClosed += (s, args) => Application.Exit();
            OpnForm.Show();
        }

        private void btn39Next_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm03902 Frm03902 = new Frm03902();
            Frm03902.FormClosed += (s, args) => Application.Exit();
            Frm03902.Show();
        }


        private void btn39Save_Click(object sender, EventArgs e)
        {

        }




        private void dtStamping_ValueChanged(object sender, EventArgs e)
        {
            if (dtStamping?.Value == null)
                return;

            DateTime dt = dtStamping.Value;

            if (dt == DateTime.MinValue)
            {
                txtStamping.Text = string.Empty;
                return;
            }

            try
            {
                string result = DateCode.GetDateCode(dt);
                txtStamping.Text = result;
            }
            catch (Exception ex)
            {
                txtStamping.Text = "Invalid date";
            }
        }

        private void dtPassivation_ValueChanged(object sender, EventArgs e)
        {

            if (dtPassivation?.Value == null)
                return;

            DateTime dt = dtPassivation.Value;

            if (dt == DateTime.MinValue)
            {
                txtPassivation.Text = string.Empty;
                return;
            }

            try
            {
                string result = DateCode.GetDateCode(dt);
                txtPassivation.Text = result;
            }
            catch (Exception ex)
            {
                txtPassivation.Text = "Invalid date";
            }

         
        }

        private void dtPlotting_ValueChanged(object sender, EventArgs e)
        {
            if (dtPlotting?.Value == null)
                return;

            DateTime dt = dtPlotting.Value;

            if (dt == DateTime.MinValue)
            {
                txtPlotting.Text = string.Empty;
                return;
            }

            try
            {
                string result = DateCode.GetDateCode(dt);
                txtPlotting.Text = result;
            }
            catch (Exception ex)
            {
                txtPlotting.Text = "Invalid date";
            }
            
        }

        private void txtPlottingNo_TextChanged(object sender, EventArgs e)
        {
            txtPlottingCode.Text = SqlSelect.GetValue("Plotting Machine", "Plotting M/C no.", txtPlottingNo.Text, "Code")?.FirstOrDefault();
        }

        private void cbbPartName_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPartNumber.Text = SqlSelect.GetValue("Part name", "Part name", cbbPartName.Text, "Part number")?.FirstOrDefault();
            txtFactoryCode.Text = SqlSelect.GetValue("Part name", "Part name", cbbPartName.Text, "Factory Code")?.FirstOrDefault();

        }
        private void cbbCoverMaterialCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCoverMaterialName.Text = SqlSelect.GetValue("Cover material", "Code", cbbCoverMaterialCode.Text, "Cover material name")?.FirstOrDefault();
        }
        private void cbbFIPGMatCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFIPGMatName.Text = SqlSelect.GetValue("FIPG Material", "Code", cbbFIPGMatCode.Text, "FIPG Material name")?.FirstOrDefault();
        }

        private void txtEndSN_click(object sender, EventArgs e)
        {

        }

        private void txt2DQty_TextChanged(object sender, EventArgs e)
        {
            int startSN;
            int qty2D;
            string End;

            if (int.TryParse(txtStartSN.Text, out startSN) && int.TryParse(txt2DQty.Text, out qty2D))
            {
                int endSN = startSN + qty2D - 1;
                End = endSN.ToString("D4");
                txtEndSN.Text = Base34.DecimalToBase34(long.Parse(End));
            }

        }

        private void txtStartSN_TextChanged(object sender, EventArgs e)
        {
            int startSN;
            int qty2D;
            string End;

            if (int.TryParse(txtStartSN.Text, out startSN) && int.TryParse(txt2DQty.Text, out qty2D))
            {
                int endSN = startSN + qty2D - 1;
                End = endSN.ToString("D4");
                txtEndSN.Text = Base34.DecimalToBase34(long.Parse(End));
            }
        }


    }
}
