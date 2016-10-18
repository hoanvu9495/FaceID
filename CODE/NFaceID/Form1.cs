using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using NFaceID.Entities;
using System.Data.SqlClient;
using System.Configuration;

namespace NFaceID
{
    public partial class Form1 : Form
    {
        public FaceTracking m_faceTracking = null;
        public FR_Face m_face_recog = null;
        public Active m_active = null;
        public FD_Face m_FD_Face = null;
        public bool m_isFaceTrack = false;
        public bool m_isFaceRecog = false;
        public bool m_isOpen = false;
        public bool m_isFaceDetect = false;
        public Service m_service = null;
        public int m_index = -1;
        public Loading m_loadForm = new Loading();
        public String m_store_unknow;
        public String m_store_know;
        public String m_server_ip = "localhost";
        public int m_server_port = 8888;
        public String m_server_name = "";
        public Form1()
        {
            InitializeComponent();

            ReadFolder();
            ReadServer();
            
            panel_video.BackgroundImage=new Bitmap(Application.StartupPath + @"\File\NoVideo.Png");
            panel_video.BackgroundImageLayout = ImageLayout.Center;

            panel_img.BackgroundImage = new Bitmap(Application.StartupPath + @"\File\NoProfile.Gif");
            panel_img.BackgroundImageLayout = ImageLayout.Stretch;
            panel_db_img.BackgroundImage = new Bitmap(Application.StartupPath + @"\File\NoProfile.Gif");
            panel_db_img.BackgroundImageLayout = ImageLayout.Stretch;
           
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_service != null)
            {
                m_service.stop();
                m_service.Dispose();
                m_service = null;
            }
            else 
            {
                if (m_faceTracking != null)
                    m_faceTracking.Dispose();
                if (m_face_recog != null)
                    m_face_recog.Dispose();

                if (m_FD_Face != null)
                    m_FD_Face.Dispose();
            }
            Close();
        }

        private void càiĐặtCameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CameraForm form = new CameraForm();
            //form.Location = m_list_pannel[m_index_pannel].Location;
            form.StartPosition = FormStartPosition.CenterScreen;
            
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.index == -1)
                    return;
                //MessageBox.Show(form.index.ToString() + ":" + form.m_url);
                if (m_service != null)
                {
                    m_service.stop();
                    m_service.Dispose();
                    
                }
                m_service = new Service();
                m_service.m_panel = panel_video;
                m_service.m_text_name = lbl_HoTen;
                m_service.m_text_confident = lbl_TrongSo;
                m_service.m_panel_result = panel_img;
                m_service.m_face_recog = m_face_recog;
                m_service.m_faceTracking = m_faceTracking;
                m_service.m_isFaceRecog = m_isFaceRecog;
                m_service.m_isFaceTrack = m_isFaceTrack;
                m_service.m_text_time = lbl_Time;
                m_service.m_listView_Thumb = listView_thumbnail;
                m_service.m_folder_unknow_Image = m_store_unknow;
                m_service.m_folder_know_Image = m_store_know;
                m_service.listView_report = listView_report;
                m_service.panel_db_img = panel_db_img;

                if (form.index == 0)
                {
                    m_service.m_index = form.index;
                    m_service.start();
                }
                else
                {
                    m_service.m_index = form.index;
                    m_service.m_url = form.m_url;
                    m_service.start();
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_loadForm.Close();
            if (m_faceTracking != null)
                m_faceTracking.Dispose();
            if (m_face_recog != null)
                m_face_recog.Dispose();
            if (m_service != null)
            {
                m_service.stop();
                m_service.Dispose();
                m_service = null;
            }
        }
        Loading frmLoad;
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Configuration _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                string conStr = _config.ConnectionStrings.ConnectionStrings["DBEntities"].ConnectionString;
                var con = new SqlConnectionStringBuilder(conStr);
            }
            catch (Exception)
            {
                if (m_server_name.Length > 3)
                {
                    Configuration _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    string server = m_server_name;
                    string constr = "data source=" + server + ";initial catalog=NFACE;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
                    _config.ConnectionStrings.ConnectionStrings["DBEntities"].ConnectionString = constr;
                    _config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection(_config.ConnectionStrings.SectionInformation.Name);
                    Properties.Settings.Default.Reload();
                }
            }
           
            try
            {
                m_active = new Active();
                int val = m_active.checkRegister();
                if (val != 1)
                {
                    // bool racises = m_active.Register("07a1b9725be6594abd7a49452ddb99ba");
                    Register frm = new Register();
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    if (frm.ShowDialog() == DialogResult.OK)
                    {

                        String seria = m_active.getseriacode();
                        //MessageBox.Show(seria);
                        List<String> m_list = new List<String>();
                        m_list.Add(frm.m_name);
                        m_list.Add(frm.m_phone);
                        m_list.Add(seria);
                        bool res = m_active.SendOrderLicense(m_server_ip, m_server_port, m_list);
                        if (res)
                        {
                            InputLicense frm_l = new InputLicense();
                            frm_l.m_active = m_active;
                            frm_l.StartPosition = FormStartPosition.CenterScreen;

                            if (frm_l.ShowDialog() == DialogResult.OK)
                            {
                                if (frm_l.m_isActvived)
                                {
                                    //true
                                    label_progressing.Hide();
                                    frmLoad = new Loading();
                                    Thread t = new Thread(loadConfig);
                                    t.Start();

                                    frmLoad.ShowDialog();
                                }
                                else
                                {
                                    this.Close();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không thể kết nối với server!", "Lỗi");
                            this.Close();
                        }
                    }
                    else
                    {
                        this.Close();
                    }

                }
                else
                {
                    label_progressing.Hide();
                    frmLoad = new Loading();
                    Thread t = new Thread(loadConfig);
                    t.Start();

                    frmLoad.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            //load config
           // m_loadForm.StartPosition = FormStartPosition.CenterScreen;
            //m_loadForm.Show();
           
            
        }
       
        public void loadConfig()
        {

            frmLoad.loadParaSys();
            //label_progressing.Invoke(new Action(() =>
            //{
            //    label_progressing.Text = "Đang Khởi động môi trường";
            //    label_progressing.Show();
            //}));
            m_faceTracking = new FaceTracking();
            m_face_recog = new FR_Face();
            m_FD_Face = new FD_Face();
            
            //label_progressing.Invoke(new Action(() =>
            //{
            //    label_progressing.Text = "Đang tải dữ liệu từ hệ thống";
            //}));
            
            m_isFaceTrack = m_faceTracking.loadConfig("config.txt");
            m_isFaceRecog = m_face_recog.loadConfig("config.txt");
            m_isFaceDetect = m_FD_Face.LoadConfig("config.txt");
            frmLoad.loadData();
            try
            {
                var db = new DBEntities();
                db.HISTORies.Take(1);
            }
            catch (Exception)
            {
                MessageBox.Show("Khong ket noi duoc csdl");

            }
            //label_progressing.Invoke(new Action(() =>
            //{
            //    label_progressing.Hide();
            //}));
            frmLoad.Completepros();
            
        }

        private void đăngKýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_AddFace form = new Form_AddFace();
            form.StartPosition = FormStartPosition.CenterScreen;
            if (m_isFaceDetect)
                form.m_FD_Face = m_FD_Face;
            if (m_isFaceRecog)
                form.m_face_recog = m_face_recog;
            if (form.ShowDialog() == DialogResult.OK)
            {
            }
        }

        private void càiĐặtHệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemSetting form = new SystemSetting();
            form.StartPosition = FormStartPosition.CenterScreen;
            if (form.ShowDialog() == DialogResult.OK)
            {
            }
        }

        private void lịchSửNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frm_ManageEmployee();
            frm.ShowDialog();
        }

        private void lịchSửToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frm_History();
            frm.ShowDialog();
        }

        private void thốngKêDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_ChamCong frm = new frm_ChamCong();
            frm.ShowDialog();
        }

        private void càiĐặtChứcNăngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_service == null)
            {
                MessageBox.Show("Xin vui lòng bật dịch vụ lên");
                return;
            }
            if (m_service.m_bitmap == null)
            {
                MessageBox.Show("Xin vui lòng mở camera trước");
                return;
            }

            Polygon frm = new Polygon();
            frm.m_bitmap = new Bitmap(m_service.m_bitmap);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                m_service.m_rectangle_roi = frm.m_rectangle_region;
            }
        }

        private void bậtChấmCôngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_service == null)
            {
                MessageBox.Show("Xin vui lòng bật dịch vụ lên");
                return;
            }
            Frm_Turnon frm = new Frm_Turnon();
            frm.m_threshold = m_service.m_nguongphanloai;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                m_service.m_faceTracking.setRectangle(m_service.m_rectangle_roi);
                m_service.m_nguongphanloai = frm.m_threshold;
                m_service.m_isChamcong = true;
                m_service.m_faceTracking.setSave(true);
            }
        }
        public void ReadFolder()
        {
            string[] lines = System.IO.File.ReadAllLines(@"folder.txt");
            m_store_unknow = lines[0];
            m_store_know = lines[1];
        }
        public void ReadServer()
        {
            string[] lines = System.IO.File.ReadAllLines(@"server.ini");
            m_server_ip = lines[0];
            m_server_port = Convert.ToInt32(lines[1]);
            if (lines.Length == 3)
            {
                m_server_name = lines[2];
            }
        }

        private void listView_thumbnail_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem lvItem = listView_thumbnail.SelectedItems[0];
            if (lvItem.Text == "Unknown")
            {
                Form_AddFace form = new Form_AddFace();
                form.StartPosition = FormStartPosition.CenterScreen;
                if (m_isFaceDetect)
                    form.m_FD_Face = m_FD_Face;
                if (m_isFaceRecog)
                    form.m_face_recog = m_face_recog;
                form.m_bitmap_Face = new Bitmap(lvItem.Name);
                if (form.ShowDialog() == DialogResult.OK)
                {
                }

            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About frm = new About();
            frm.ShowDialog();
        }
    }
}
