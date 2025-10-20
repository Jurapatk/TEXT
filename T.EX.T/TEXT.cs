using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using T.EX.T;

namespace TEXT
{
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
            Application.Run(new FrmOpn());
            Application.Run(new FrmSetting());
        }
    }
    public static class Session
    {
        public static string Username { get; set; }
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

}
