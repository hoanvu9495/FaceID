using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Net;
using System.Windows;
using System.Threading;
using System.IO;
using System.Drawing.Imaging;


namespace NFaceID
{
    public partial class Polygon : Form
    {
        public Bitmap m_bitmap = null;
        public Bitmap m_bitmap_origin = null;
        public bool m_down_mouse = false;
        public bool m_down_polygon = false;
        public Point start, end;
        public Point mPreviousPoint = Point.Empty;
        public Rectangle m_rectangle_region = new Rectangle();

        public Polygon()
        {
            InitializeComponent();
        }

        private void Polygon_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (m_bitmap != null)
                m_bitmap.Dispose();
            if (m_bitmap_origin != null)
                m_bitmap_origin.Dispose();
        }
        private void p_Paint(object sender, PaintEventArgs e)
        {
            Panel p = ((Panel)sender);
            Graphics g = Graphics.FromHwnd(p.Handle);
            //Graphics g = Graphics.FromHwnd(panel_content.Handle);
            g.DrawImage(m_bitmap, 4, 4, panel_content.Width - 8, panel_content.Height - 8);
            g.Dispose();
        }

        private void Polygon_Load(object sender, EventArgs e)
        {
            if (m_bitmap != null)
            {
                m_bitmap_origin = new Bitmap(m_bitmap);
                panel_content.Paint += p_Paint;

            }
        }

        private void panel_content_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point p = new Point(e.X, e.Y);
                m_down_mouse = true;
                start = p;

            }
        }

        private void panel_content_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_down_mouse)
            {
                if (m_bitmap != null)
                {

                    Cursor.Current = Cursors.Cross;
                    Point p = new Point(e.X, e.Y);
                    //panel_image.Refresh();
                    Graphics g = Graphics.FromHwnd(panel_content.Handle);
                    m_bitmap.Dispose();
                    m_bitmap = m_bitmap_origin.Clone(new Rectangle(0, 0, m_bitmap_origin.Width, m_bitmap_origin.Height), PixelFormat.Format24bppRgb);
                    g.DrawImage(m_bitmap, 0, 0, panel_content.Width, panel_content.Height);
                    using (Pen pen = new Pen(Color.Green, 2))
                    {
                        //Draw the rectangle on our form with the pen

                        g.DrawRectangle(pen, new Rectangle(start.X, start.Y, Math.Abs(p.X - start.X), Math.Abs(p.Y - start.Y)));
                        //g.Graphics.DrawRectangle(pen, _rect);
                    }
                    g.Dispose();
                }
            }
            else
            {
                Cursor.Current = Cursors.Arrow;
            }
        }

        private void panel_content_MouseUp(object sender, MouseEventArgs e)
        {
            if (m_down_mouse && m_bitmap != null)
            {
                end = new Point(e.X, e.Y);
                Point p = new Point(e.X, e.Y);
                //panel_image.Refresh();
                Graphics g = Graphics.FromHwnd(panel_content.Handle);
                m_bitmap.Dispose();
                m_bitmap = m_bitmap_origin.Clone(new Rectangle(0, 0, m_bitmap_origin.Width, m_bitmap_origin.Height), PixelFormat.Format24bppRgb);
                g.DrawImage(m_bitmap, 0, 0, panel_content.Width, panel_content.Height);
                Pen pen = new Pen(Color.Green, 2);
                g.DrawRectangle(pen, new Rectangle(start.X, start.Y, Math.Abs(p.X - start.X), Math.Abs(p.Y - start.Y)));
                g.Dispose();
                m_down_mouse = false;
                m_rectangle_region = new Rectangle(start, new Size(Math.Abs(p.X - start.X), Math.Abs(p.Y - start.Y)));
                Cursor.Current = Cursors.Arrow;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //anh xa lai tap diem

            double ratiox = m_bitmap.Width / ((double)panel_content.Width);
            double ratioy = m_bitmap.Height / ((double)panel_content.Height);
            int x = (int)((double)m_rectangle_region.X * ratiox);
            int y = (int)((double)m_rectangle_region.Y * ratioy);
            int w = (int)((double)m_rectangle_region.Width * ratiox);
            int h = (int)((double)m_rectangle_region.Height * ratioy);
            m_rectangle_region = new Rectangle(x, y, w, h);
        }

    }
}
