using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using T.EX.T;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Microsoft.IdentityModel.Protocols;
using System.Security.Cryptography;
using Newtonsoft.Json;
using System.Web;
namespace TEXT
{
    public class g_
    {      // Equipment and user global variable

        public static string EquipType { get; set; }
        public static string EquipNo { get; set; }
        public static string Reader { get; set; }
        public static int UserIndex { get; set; }
        public static int TeamIndex { get; set; }
        public static string EN { get; set; }
        public static string Team { get; set; }

        public static string DataPath = ConfigurationManager.AppSettings["DataPath"];
        public static string Server = ConfigurationManager.AppSettings["Server"];
        public readonly static string AppsDB = ConfigurationManager.AppSettings["AppsDB"];
        public readonly static string MainDB = ConfigurationManager.AppSettings["MainDB"];

        public readonly static string ConServer = $"Server={Server};User Id=trc;Password=trc123*;";
        public readonly static string ConLocal = "Server=localhost;Database=MMI;Integrated Security=True;";
        //public readonly static string ConLocal = "Server=NOTE-DELL4743\\SQLEXPRESS;Database=MMI;Integrated Security=True;";
        public static string ConStr = ConLocal;    // default connection
    }
    internal static class TEXT
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmLogIn());
        }
    }
    public static class Session
    {
        public static string Username { get; set; }
    }
    //public class DataItem
    //{
    //    public string TableName { get; set; }
    //    public string ColName { get; set; } = string.Empty;
    //    public string Value { get; set; } = string.Empty;
    //    public int? rowid { get; set; }
    //}
    public class DataItem
    {
        public string TableName { get; set; }
        public string ColName { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public int? rowid { get; set; }
    }
    public static class ControlExtensions
    {
        public static void MakeButtonRounded(this Button btn, int radius)
        {
            var path = new GraphicsPath();
            int w = btn.Width;
            int h = btn.Height;
            int r = Math.Min(radius, Math.Min(w, h) / 2);

            path.AddArc(0, 0, r * 2, r * 2, 180, 90);
            path.AddArc(w - r * 2, 0, r * 2, r * 2, 270, 90);
            path.AddArc(w - r * 2, h - r * 2, r * 2, r * 2, 0, 90);
            path.AddArc(0, h - r * 2, r * 2, r * 2, 90, 90);
            path.CloseFigure();

            btn.Region = new Region(path);
        }
       
        public static void MakeTxtRounded(this TextBox tb, int radius)
        {
            var path = new GraphicsPath();
            int w = tb.Width;
            int h = tb.Height;
            int r = Math.Min(radius, Math.Min(w, h) / 2);

            path.AddArc(0, 0, r * 2, r * 2, 180, 90);
            path.AddArc(w - r * 2, 0, r * 2, r * 2, 270, 90);
            path.AddArc(w - r * 2, h - r * 2, r * 2, r * 2, 0, 90);
            path.AddArc(0, h - r * 2, r * 2, r * 2, 90, 90);
            path.CloseFigure();

            tb.Region = new Region(path);
        }

        public static void MakePictureRounded(this PictureBox pb, int radius)
        {
            int w = pb.Width;
            int h = pb.Height;
            int r = Math.Min(radius, Math.Min(w, h) / 2);

            var path = new GraphicsPath();
            path.AddArc(0, 0, r * 2, r * 2, 180, 90);
            path.AddArc(w - r * 2, 0, r * 2, r * 2, 270, 90);
            path.AddArc(w - r * 2, h - r * 2, r * 2, r * 2, 0, 90);
            path.AddArc(0, h - r * 2, r * 2, r * 2, 90, 90);
            path.CloseFigure();

            pb.Region = new Region(path);
        }

        public static void MakePanelRounded(this Panel pnl, int radius)
        {
            var path = new GraphicsPath();
            int w = pnl.Width;
            int h = pnl.Height;
            int r = Math.Min(radius, Math.Min(w, h) / 2);

            path.AddArc(0, 0, r * 2, r * 2, 180, 90);
            path.AddArc(w - r * 2, 0, r * 2, r * 2, 270, 90);
            path.AddArc(w - r * 2, h - r * 2, r * 2, r * 2, 0, 90);
            path.AddArc(0, h - r * 2, r * 2, r * 2, 90, 90);
            path.CloseFigure();

            pnl.Region = new Region(path);
        }

    
    }

    public static class DateCode
    {
        public static string GetDateCode(DateTime dt)
        {
            var date = dt.Day;
            var year = dt.Year;
            var month = dt.Month;
            string dateStr = $"{year:D4}-{month:D2}-{date:D2}";

            using (var cn = new SqlConnection(g_.ConStr))
            {
                cn.Open();
                string sql = "select dbo.DATECODE(@Date)";
                using (var cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@Date", dateStr);
                    using (var rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            return rd.GetString(0);
                        }
                    }
                }
            }
            return string.Empty;
        }
    }

    public static class Base34
    {
        private const string Base34Symbols = "0123456789ABCDEFGHJKLMNPQRSTUVWXYZ";
        private const int Base = 34;
        private const int NumDigits = 4;

        public static string DecimalToBase34(long decimalValue)
        {
            if (decimalValue < 0 || decimalValue > 1336335)
            {
                throw new ArgumentOutOfRangeException(nameof(decimalValue), "ค่าต้องอยู่ระหว่าง 0 ถึง 1,336,335");
            }

            if (decimalValue == 0)
            {
                return "0000";
            }

            string base34Value = "";
            long tempValue = decimalValue;

            while (tempValue > 0)
            {
                int remainder = (int)(tempValue % Base);
                base34Value = Base34Symbols[remainder] + base34Value;
                tempValue /= Base;
            }

            return base34Value.PadLeft(NumDigits, '0');
        }
    }


    public static class SqlSelect
    {

        public static List<string> GetTableArray()
        {
            var arrTable = new List<string>();
            string sql = @"EXEC dbo.sp_Master @Action = 'SELECT'";
            using (var cn = new SqlConnection(g_.ConStr))
            {
                cn.Open();
                using (var cmd = new SqlCommand(sql, cn))
                {
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            string value = rd.IsDBNull(1) ? null : rd.GetString(1);
                            if (value != null)
                                arrTable.Add(value);
                        }
                    }
                }
            }

            return arrTable;
        }

    
        public static DataTable GetDataTable(string curTable)
        {
            DataTable dt = new DataTable();
            string sql = $@"EXEC dbo.sp_Master @Action = 'SELECT', @TableName = '{curTable}'";

            using (var cn = new SqlConnection(g_.ConStr))
            using (var cmd = new SqlCommand(sql, cn))
            {
                cn.Open();
                using (var da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }


        public static List<string> GetValue(string curTable, string curCol, string targetName, string colName)
        {
            DataTable dt = GetDataTable(curTable);
            var results = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                string colValue = row[curCol]?.ToString();


                if (string.Equals(colValue, targetName, StringComparison.OrdinalIgnoreCase))
                {
                    string partNumber = row[colName]?.ToString();
                    results.Add(partNumber);
                }
            }

            return results;
        }
        public static List<string> GetList(string curTable, string ColName)
        {
            DataTable dt = GetDataTable(curTable);
            var results = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                string value = row[ColName].ToString();

                results.Add(value);
            }

            return results;
        }


        public static string[][] GetColArray(int curTable)
        {
            string sql = @"SELECT [table_name] FROM [MMI].[dbo].[tb_master_table] where id = @id";
            string sql2 = @"SELECT column_name, cell_value, row_id
                   FROM [MMI].[dbo].[tb_master_data] 
                   WHERE master_id = @id";

            var tempList = new List<string[]>();
            string TableName = null;
            string columnName = null;
            string cellValue = null; 
            int? rowid = null;
            using (var cn = new SqlConnection(g_.ConStr))
            {
                cn.Open();
                using (var cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", curTable);
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            TableName = rd.IsDBNull(0) ? null : rd.GetString(0);

                        }
                    }
                }

                using (var cmd2 = new SqlCommand(sql2, cn))
                {
                    cmd2.Parameters.AddWithValue("@id", curTable);
                    using (var rd2 = cmd2.ExecuteReader())
                    {
                        while (rd2.Read())
                        {

                            columnName = rd2.IsDBNull(0) ? null : rd2.GetString(0);
                            cellValue = rd2.IsDBNull(1) ? null : rd2.GetString(1);
                            rowid = rd2.IsDBNull(2) ? (int?)null : rd2.GetInt32(2);
                            string row_id = rowid.ToString();
                            tempList.Add(new string[] { TableName, columnName, cellValue, row_id });
                        }
                    }
                }
            }

            return tempList.ToArray();
        }

        public static int? GetRowId(string partName, SqlConnection cn)
        {
            int? rowId = null;
            string sql = @"SELECT row_id FROM [MMI].[dbo].[tb_master_data] WHERE column_name = 'Part name' AND cell_value = @CellValue";

            using (var cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@CellValue", partName);

                using (var rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        rowId = rd.IsDBNull(0) ? (int?)null : rd.GetInt32(0);
                    }
                }
            }
            return rowId;
        }

        public static string GetSqlInfo(int? rowId, SqlConnection cn, string TableName, string ColName)
        {

            string result = null;
            string sqlinfo = @"EXEC dbo.sp_Master @Action = 'SELECT', @TableName = @Table , @RowId =@row, @ColName = @Col";
            
            using (var cmdinfo = new SqlCommand(sqlinfo, cn))
            {
                cmdinfo.Parameters.AddWithValue("@Table", TableName);
                cmdinfo.Parameters.AddWithValue("@row", rowId);
                cmdinfo.Parameters.AddWithValue("@Col", ColName);
                using (var rdinfo = cmdinfo.ExecuteReader())
                {
                    if (rdinfo.Read())
                    {
                       result = rdinfo.IsDBNull(0) ? null : rdinfo.GetString(0);
                    }
                }
            }
            return result;
        }

    }


}
