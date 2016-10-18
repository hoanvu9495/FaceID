using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Windows;
using System.Threading;
using System.IO;

//using lib;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Collections;
using NFaceID.Entities;
using NFaceID.DAL;
using NFaceID.BLL;

namespace NFaceID
{
    public class Service
    {
        private static volatile Service instance;
        private static object syncRoot = new Object();
        public Queue<ListViewItem> ViewRs = new Queue<ListViewItem>();
        public Thread m_thread = null;
        public Thread m_thread_recog = null;
        public Thread m_thread_display = null;
        public int m_index = -1;
        public string m_url = "";
        public VideoCapture m_cameraCapture = new VideoCapture();
        public bool m_isReadCamera = false;
        public Bitmap m_bitmap = null;
        public List<Bitmap> m_bitmap_list = new List<Bitmap>();
        public List<DateTime> m_time_list = new List<DateTime>();
        public Bitmap m_bitmap_face = null;
        public Rectangle m_rectangle_roi = new Rectangle();

        public Bitmap m_bitmap_to_show = null;
        public Bitmap m_bitmap_to_tracking = null;
        public List<Bitmap> m_container = new List<Bitmap>();
        public FaceTracking m_faceTracking = null;
        public FR_Face m_face_recog = null;
        public bool m_isFaceTrack = false;
        public bool m_isFaceRecog = false;
        public List<Bitmap> m_listFace = new List<Bitmap>();//co dinh danh sach lon nhat de hien thi
        public String m_folder_know_Image = "history/known";
        public String m_folder_blacklist_Image = "history/blacklist";
        public String m_folder_unknow_Image = "history/unknown";
        public bool m_isChamcong = false;
        public double m_nguongphanloai = 0.90;
        //tuong tac voi giac dien
        public Panel m_panel = null;
        public Panel m_panel_result = null;
        public Panel panel_db_img = null;
        public Label m_text_name = null;
        public Label m_text_time = null;
        public Label m_text_confident = null;
        public ListView m_listView_Thumb = null;
        private List<Image> Images = new List<Image>();
        private ImageList imageList = new ImageList();
        public ListView listView_report = null;

        private static Mutex mut = new Mutex();
        private static bool haschanged_update = false;
        private volatile bool updatedUI = true;
        private volatile bool updatedTracking = true;
        Font drawFont1 = new Font(new FontFamily("Arial"), 12, FontStyle.Regular, GraphicsUnit.World);
        SolidBrush drawBrush = new SolidBrush(Color.White);

        public int m_width = 1080;
        public int m_height = 1920;


        public static Service Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new Service();
                    }
                }

                return instance;
            }
        }

        public Service()
        {
        }
        ~Service()
        {

        }
        public void Dispose()
        {

        }

        public void bw_DoWork()
        {
            while (m_isReadCamera)
            {
                try
                {
                    if (m_bitmap != null)
                        m_bitmap.Dispose();
                    bool res = m_cameraCapture.queryFrame(ref m_bitmap);
                    if (res)
                    {
                        if (m_panel != null)
                        {
                            if (m_bitmap != null)
                            {
                                if (updatedUI)
                                {
                                    if (m_bitmap_to_show != null)
                                        m_bitmap_to_show.Dispose();
                                    m_bitmap_to_show = new Bitmap(m_bitmap);

                                    if (m_thread_display == null)
                                    {
                                        m_thread_display = new Thread(UIShowvideo);
                                        m_thread_display.Start();
                                        m_thread_display.Join();
                                    }
                                    else if (m_thread_display.ThreadState == ThreadState.Stopped)
                                    {
                                        m_thread_display = new Thread(UIShowvideo);
                                        m_thread_display.Start();
                                        m_thread_display.Join();
                                    }

                                }
                                if (m_isChamcong)
                                {
                                    if (updatedTracking)
                                    {
                                        if (m_bitmap_to_tracking != null)
                                            m_bitmap_to_tracking.Dispose();
                                        m_bitmap_to_tracking = new Bitmap(m_bitmap);
                                        //System.Threading.ThreadPool.QueueUserWorkItem()
                                        //System.Threading.ThreadPool.QueueUserWorkItem(Recognize, m_bitmap_to_tracking);   

                                        if (m_thread_recog == null)
                                        {
                                            m_thread_recog = new Thread(Recognize);
                                            m_thread_recog.Start();
                                            m_thread_recog.Join();
                                        }
                                        else if (m_thread_recog.ThreadState == ThreadState.Stopped)
                                        {
                                            m_thread_recog = new Thread(Recognize);
                                            m_thread_recog.Start();
                                            m_thread_recog.Join();
                                        }

                                    }
                                }


                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    m_isReadCamera = false;
                    if (m_thread_display != null)
                        m_thread_display.Abort();
                }

            }
        }

        public void start()
        {
            imageList.ImageSize = new Size(90, 90);
            imageList.ColorDepth = ColorDepth.Depth32Bit;

            m_listView_Thumb.View = View.LargeIcon;
            m_listView_Thumb.LargeImageList = imageList;

            m_panel.Invoke(new Action(() =>
            {
                //draw here
                Graphics g = Graphics.FromHwnd(m_panel.Handle);
                FontFamily fam = new FontFamily("Arial Black");
                SolidBrush sbr = new SolidBrush(Color.White);
                String measureString = "Đang tải dữ liệu...";
                // Set maximum width of string.
                int stringWidth = 200;
                Font font = new System.Drawing.Font(fam, 8, FontStyle.Bold);
                // Measure string.
                SizeF stringSize = new SizeF();
                stringSize = g.MeasureString(measureString, font, stringWidth);
                g.Clear(Color.Black);
                g.DrawString(measureString, font, Brushes.White, new PointF(m_panel.Width / 2 - stringSize.Width / 2, m_panel.Height / 2 - stringSize.Height / 2));
                int thickness = 1;//it's up to you
                int halfThickness = thickness / 2;
                using (Pen pen = new Pen(Color.White, thickness))
                {
                    g.DrawRectangle(pen, new Rectangle(halfThickness,
                                                              halfThickness,
                                                              m_panel.ClientSize.Width - thickness,
                                                              m_panel.ClientSize.Height - thickness));
                }
                g.Dispose();
            }));
            //m_isFaceTrack = m_faceTracking.loadConfig("config.txt");
            //m_isFaceRecog = m_face_recog.loadConfig("config.txt");
            Thread thread_ = new Thread(LoadCamera);
            thread_.Start();


        }
        public void LoadCamera()
        {

            if (m_index == 0)
                m_isReadCamera = m_cameraCapture.Open(0);
            else if (m_index == 1)
                m_isReadCamera = m_cameraCapture.OpenVideo(m_url);
            //streaming
            else if (m_index == 2)
                m_isReadCamera = m_cameraCapture.Open(m_url, m_width, m_height);
            if (!m_isReadCamera)
            {
                m_panel.Invoke(new Action(() =>
                {
                    m_panel.Refresh();
                }));
                return;
            }

            m_thread = new Thread(bw_DoWork);
            m_thread.IsBackground = true;
            m_thread.Start();
            //m_thread_recog = new Thread(Recognize);
            //m_thread_recog.Start();
        }
        public void stop()
        {
            m_listView_Thumb.Items.Clear();
            imageList.Images.Clear();
            m_isReadCamera = false;
            if (m_thread_display != null)
            {
                if (m_thread_display.IsAlive)
                    m_thread_display.Abort();
            }
            if (m_thread != null)
            {
                if (m_thread.IsAlive)
                    m_thread.Abort();
            }
            if (m_thread_recog != null)
            {
                if (m_thread_recog.IsAlive)
                    m_thread_recog.Abort();
            }
            if (m_faceTracking != null)
                m_faceTracking.Dispose();
            if (m_face_recog != null)
                m_face_recog.Dispose();
            m_cameraCapture.Dispose();
            if (m_container.Count > 0)
            {
                for (int i = 0; i < m_container.Count; i++)
                    if (m_container[i] != null)
                        m_container[i].Dispose();
                m_container.Clear();
            }
            if (m_bitmap_to_tracking != null)
                m_bitmap_to_tracking.Dispose();
            if (m_bitmap_to_show != null)
                m_bitmap_to_show.Dispose();
            for (int i = 0; i < m_bitmap_list.Count; i++)
                m_bitmap_list[i].Dispose();
        }
        #region -------------------SQL and camera processing -----------------------
        public String FromDateTime(DateTime date_)
        {
            String a = date_.Year.ToString() + date_.Month.ToString("00") + date_.Day.ToString("00") + date_.Hour.ToString("00") + date_.Minute.ToString("00") + date_.Millisecond.ToString("0000");
            return a;
        }


        public String DateTimeToOracle(DateTime time_)
        {
            String time_str = time_.ToString("yyyy/MM/dd HH:mm:ss");
            String grammar = "TO_DATE('" + time_str + "','YYYY/MM/DD HH24:MI:SS')";
            return grammar;
        }
        #endregion-------------------------------------------------------------------
        #region------UI interaction-----
        void UIShowvideo()
        {
            try
            {
                if (m_bitmap_to_show != null)
                {
                    if (updatedUI)
                    {
                        updatedUI = false;
                        m_panel.Invoke(new Action(() =>
                        {
                            /*
                            double ratiox = (double)m_bitmap.Width / (1.0 * m_panel.Width);
                            double ratioy = (double)m_bitmap.Height / (1.0 * m_panel.Height);
                            if (ratiox > ratioy)
                            {
                                int kc = m_panel.Height - (int)((double)m_bitmap.Height / ratiox);
                                Graphics c = Graphics.FromHwnd(m_panel.Handle);
                                c.DrawImage(m_bitmap, 4, kc / 2, m_panel.Width - 8, m_panel.Height - kc);
                                c.Dispose();

                            }
                            else
                            {
                                int kc = m_panel.Width - (int)((double)m_bitmap.Width / ratioy);
                                Graphics c = Graphics.FromHwnd(m_panel.Handle);
                                c.DrawImage(m_bitmap, kc / 2, 4, m_panel.Width - kc, m_panel.Height - 8);
                                c.Dispose();
                            }
                             * */
                            Graphics c = Graphics.FromHwnd(m_panel.Handle);

                            c.DrawImage(m_bitmap, 4, 4, m_panel.Width - 8, m_panel.Height - 8);
                            if (m_rectangle_roi.Width != 0 && m_rectangle_roi.Height != 0)
                            {
                                //anh xa lai tap diem

                                double ratiox = m_panel.Width / ((double)m_bitmap.Width);
                                double ratioy = m_panel.Height / ((double)m_bitmap.Height);

                                int x = (int)((double)m_rectangle_roi.X * ratiox);
                                int y = (int)((double)m_rectangle_roi.Y * ratioy);
                                int w = (int)((double)m_rectangle_roi.Width * ratiox);
                                int h = (int)((double)m_rectangle_roi.Height * ratioy);
                                Rectangle r = new Rectangle(x, y, w, h);
                                c.DrawRectangle(new Pen(Color.Red, 2), r);
                            }
                            c.Dispose();
                        }));
                        m_bitmap_to_show.Dispose();
                        updatedUI = true;
                    }
                }

            }
            catch (Exception ex)
            {
                updatedUI = true;
            }
            

        }
        #endregion ----UI interaction-----
        private string saveImg(/*Bitmap bmp,*/string name)
        {
            try
            {
                // Save Image
                string filename = BLL_PARA.PathHistory + Ultis.RemoveUnicode(DAL_EMPLOYEE.GetFullName(int.Parse(name))) + CODE.timeString(DateTime.Now) + ".Jpg";
                //FileStream fstream = new FileStream(filename, FileMode.Create);
                //bmp.Save(fstream, System.Drawing.Imaging.ImageFormat.Jpeg);
                //fstream.Close();
                return filename;


            }
            catch (Exception)
            {

                return "";
            }

        }
        public void Recognize(/* Bitmap src*/)
        {
            //while (m_isReadCamera)
            //  {
            try
            {
                updatedTracking = false;
                if (m_isFaceTrack && m_bitmap_to_tracking != null)
                {
                    m_faceTracking.update(m_bitmap_to_tracking);
                    //nhan dang tai day
                    if (m_faceTracking.getSize() > 0)
                    {
                        for (int i = 0; i < m_faceTracking.getSize(); i++)
                        {
                            if (!m_faceTracking.getRecognize_status(i))
                            {
                                Bitmap bmp = null;
                                if (m_faceTracking.getFaceImage(i, ref bmp))
                                {
                                    m_faceTracking.setRecognize_status(i, true);
                                    m_time_list.Add(m_faceTracking.getStartTime(i));
                                    m_bitmap_list.Add(bmp);
                                    int n = 0;
                                }
                            }
                        }
                    }
                }
                if (m_bitmap_list.Count > 0)
                {
                    if (m_bitmap_face != null)
                        m_bitmap_face.Dispose();
                    m_bitmap_face = (Bitmap)m_bitmap_list[0].Clone();

                    double confident = 0;
                    String name = "";
                    int id = -1;
                    m_face_recog.recognizeFromImage(m_bitmap_face, out confident, out id, out name);
                    m_panel_result.Invoke(new Action(() =>
                    {
                        Graphics g = Graphics.FromHwnd(m_panel_result.Handle);
                        g.DrawImage(m_bitmap_face, 4, 4, m_panel_result.Width - 8, m_panel_result.Height - 8);
                        g.Dispose();
                    }));
                    m_text_confident.Invoke(new Action(() =>
                    {
                        m_text_confident.Text = Math.Floor(confident * 100).ToString();
                    }));
                    m_text_name.Invoke(new Action(() =>
                    {
                        m_text_name.Text = name;
                    }));
                    m_text_time.Invoke(new Action(() =>
                    {
                        m_text_time.Text = m_time_list[0].ToString();
                    }));
                    if (confident < m_nguongphanloai)
                        name = "Unknown";
                    //luu tru tai day
                    if (name != "Unknown")
                    {
                        string fullname = DAL_EMPLOYEE.GetFullName(int.Parse(name));
                        m_text_name.Invoke(new Action(() =>
                        {
                            m_text_name.Text = fullname;
                        }));
                        DateTime time = m_time_list[0];
                        String s = m_folder_know_Image + "/" + time.Year.ToString();
                        if (!Directory.Exists(s))
                            Directory.CreateDirectory(s);
                        s += "/" + time.Month.ToString();
                        if (!Directory.Exists(s))
                            Directory.CreateDirectory(s);
                        s += "/" + time.Day.ToString();
                        if (!Directory.Exists(s))
                            Directory.CreateDirectory(s);
                        s += "/" + name + "_" + time.Hour.ToString("00") + time.Minute.ToString("00") + time.Second.ToString("00") + ".jpg";
                        //string imgSave = saveImg(/* Bitmap(s), */name);
                        m_bitmap_list[0].Save(s);

                        HISTORY his = new HISTORY();
                        his.ID = DAL_HISTORY.getIDNew();
                        his.ID_PER = int.Parse(name);
                        his.IMG_FACE = s;
                        his.IMG = s;
                        his.IN_OUT = false;
                        his.TIME_UPDATE = DateTime.Now;
                        DAL_HISTORY.INSERT(his);
                        if (DAL_ATTENDANCE.Check(int.Parse(name), his.TIME_UPDATE))
                        {
                            ATTENDANCE att = new ATTENDANCE();
                            att.ID = DAL_ATTENDANCE.getIDNew();
                            att.ID_EMP = int.Parse(name);
                            att.DATE_ATT = DateTime.Now.Date;
                            att.TIME_IN = DateTime.Now.TimeOfDay;
                            att.IMG_IN = s;
                            DAL_ATTENDANCE.INSERT(att);
                        }
                        else
                        {
                            DAL_ATTENDANCE.updateTimeOut(int.Parse(name), s);
                        }
                        //m_bitmap_list[0].Save(s);
                        m_listView_Thumb.Invoke(new Action(() =>
                        {
                            Image img = Image.FromFile(s);
                            String s_ = "0";
                            imageList.Images.Add(s_, img);
                            ListViewItem lvitem = new ListViewItem();
                            lvitem.ImageIndex = imageList.Images.Count - 1;
                            //lvitem.Text = name + ":" + confident.ToString();
                            lvitem.Text = fullname;
                            ViewRs.Enqueue(lvitem);


                            m_listView_Thumb.Items.Insert(0, lvitem);

                            //m_listView_Thumb.Items.Add(lvitem);
                            //m_listView_Thumb.Show();

                            //m_listView_Thumb.Items.Add(lvitem);
                        }));

                        //add thong tin vao report
                        string[] arr = new string[6];
                        arr[0] = name;
                        arr[1] = fullname;
                        arr[2] = DateTime.Now.ToString("dd-MMM-yy");
                        arr[3] = DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00");
                        arr[4] = "";
                        arr[5] = "1";
                        ListViewItem itm = new ListViewItem(arr);
                        //kiem tra ra

                        listView_report.Invoke(new Action(() =>
                        {
                            int index = -1;
                            for (int i = 0; i < listView_report.Items.Count; i++)
                            {
                                if (listView_report.Items[i].SubItems[0].Text == name)
                                {
                                    index = i;
                                    break;
                                }
                            }
                            if (index == -1)
                                listView_report.Items.Add(itm);
                            else
                            {
                                listView_report.Items[index].SubItems[4].Text = DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00");
                            }
                        }));

                    }
                    else
                    {
                        DateTime time = m_time_list[0];
                        String s = m_folder_unknow_Image + "/" + time.Year.ToString();
                        if (!Directory.Exists(s))
                            Directory.CreateDirectory(s);
                        s += "/" + time.Month.ToString();
                        if (!Directory.Exists(s))
                            Directory.CreateDirectory(s);
                        s += "/" + time.Day.ToString();
                        if (!Directory.Exists(s))
                            Directory.CreateDirectory(s);
                        s += "/" + name + "_" + time.Hour.ToString("00") + time.Minute.ToString("00") + time.Second.ToString("00") + ".jpg";
                        m_bitmap_list[0].Save(s);
                        m_listView_Thumb.Invoke(new Action(() =>
                        {
                            Image img = Image.FromFile(s);
                            String s_ = "0";
                            imageList.Images.Add(s_, img);
                            //imageList.Images.Add()

                            ListViewItem lvitem = new ListViewItem();
                            lvitem.ImageIndex = imageList.Images.Count - 1;
                            //lvitem.Text = name + ":" + confident.ToString();
                            lvitem.Text = name;
                            lvitem.Name = s;
                            ViewRs.Enqueue(lvitem);
                            m_listView_Thumb.Items.Insert(0, lvitem);

                        }));

                    }
                    m_time_list.RemoveAt(0);
                    m_bitmap_list.RemoveAt(0);
                }
            }
            catch (Exception ex)
            {
                updatedTracking = true;
            }
            updatedTracking = true;
            //}
            //bmp.Save("face.png");
            //bmp.Dispose();
        }

    }
}
