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
            FillComboBox(cbbCoverMaterialCode, "Cover Material", "Cover material name");



            //cbbPartName.Items.Clear();
            //cbbCoverMaterialCode.Items.Clear();
            //cbbReOven.Items.Clear();
            //cbbShift.Items.Clear();
            //cbbFIPGMatCode.Items.Clear();
            //cbbProductRevision.Items.AddRange(Enumerable.Range('A', 26)
            //    .Select(i => ((char)i).ToString())
            //    .ToArray());
            //cbbTool.Items.AddRange(Enumerable.Range(1, 9).Select(n => n.ToString()).ToArray());

            //void FillComboBox<T>(ComboBox cb, string tableName, string columnName)
            //{
            //    var dt = SqlSelect.GetDataTable(tableName);
            //    var list = SqlSelect.GetList(tableName, columnName);
            //    foreach (var item in list)
            //        cb.Items.Add(item);
            //}

            //// ใช้
            //FillComboBox(cbbReOven, "Re-Oven Baking", "Code");
            //FillComboBox(cbbShift, "Shift", "Code");
            //FillComboBox(cbbFIPGMatCode, "FIPG Material", "Code");

            //// สำหรับ Part name
            //FillComboBox(cbbPartName, "Part name", "Part name");
            //DataTable dt = SqlSelect.GetDataTable("Re-Oven Baking");
            //List<string> reoven = SqlSelect.GetList("Re-Oven Baking", "Code");
            //foreach (string code in reoven)
            //{
            //    cbbReOven.Items.Add(code);
            //}

            //DataTable dt2 = SqlSelect.GetDataTable("Shift");
            //List<string> shift = SqlSelect.GetList("Shift", "Code");
            //foreach (string code in shift)
            //{
            //    cbbShift.Items.Add(code);
            //}

            //DataTable dt3 = SqlSelect.GetDataTable("FIPG Material");
            //List<string> fipg = SqlSelect.GetList("FIPG Material", "Code");
            //foreach (string code in fipg)
            //{
            //    cbbFIPGMatCode.Items.Add(code);
            //}

            //DataTable dt4 = SqlSelect.GetDataTable("Part name");
            //List<string> pn = SqlSelect.GetList("Part name", "Part name");
            //foreach (string code in pn)
            //{
            //    cbbPartName.Items.Add(code);
            //}
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

        private void btn39ChkBar_Click_1(object sender, EventArgs e)
        {

        }

        private void btn39Save_Click(object sender, EventArgs e)
        {

        }




        private void dtStamping_ValueChanged(object sender, EventArgs e)
        {
            DateTime dt = dtStamping.Value;
            string result = DateCode.GetDateCode(dt);
            txtStamping.Text = result;
        }

        private void dtPassivation_ValueChanged(object sender, EventArgs e)
        {
            DateTime dt = dtPassivation.Value;
            string result = DateCode.GetDateCode(dt);
            txtPassivation.Text = result;
        }

        private void dtPlotting_ValueChanged(object sender, EventArgs e)
        {
            DateTime dt = dtPlotting.Value;
            string result = DateCode.GetDateCode(dt);
            txtPlotting.Text = result;
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
            txtCoverMaterialName.Text = SqlSelect.GetValue("Cover material", "Cover material name", cbbCoverMaterialCode.Text, "Code")?.FirstOrDefault();
        }
        private void cbbFIPGMatCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFIPGMatName.Text = SqlSelect.GetValue("FIPG Material", "Code", cbbFIPGMatCode.Text, "FIPG Material name")?.FirstOrDefault();
        }
    }
}
