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
using NFaceID.BLL;
using NFaceID.DAL;
using System.Drawing.Imaging;
using System.IO;

namespace NFaceID
{
    public partial class Form_AddFace : Form
    {
        public FD_Face m_FD_Face = null;
        public FR_Face m_face_recog = null;
        public Bitmap m_bitmap = null;
        public Bitmap m_bitmap_Face = null;
        public bool m_isBitmap = false;
        public VideoCapture m_video = null;
        public bool m_isVideo = true;
        private volatile bool updatedUI = true;
        public Thread m_thread = null;
        public String m_name = "";
        public bool m_isSnapshot = false;
        public Bitmap m_bitmap_snapshot = null;
        private bool is_file = false;
        PERSONAL per = new PERSONAL();
        EMPLOYEE emp = new EMPLOYEE();
        public int m_width = 1080;
        public int m_height = 1920;
        public Form_AddFace()
        {
            InitializeComponent();
            string pathDefault = Application.StartupPath + @"\File\noimagefound.Jpg";
            pictureBox1.Image = new Bitmap(pathDefault);
            panel1.BackgroundImage = new Bitmap(Application.StartupPath + @"\File\NoVideo.Png");
            panel1.BackgroundImageLayout = ImageLayout.Center;

        }
        private void ChonTuFile(Bitmap m_bitmap1, bool isFile)
        {
            m_bitmap = m_bitmap1;
            is_file = isFile;
            btn_FaceDetect.Text = "Chụp";
            m_isVideo = !isFile;
            if (m_bitmap != null)
            {
                panel1.Refresh();
                m_isVideo = false;
                if (m_thread != null)
                {
                    if (m_thread.IsAlive)
                        m_thread.Abort();
                }
                if (m_video != null)
                    m_video.Dispose();
                m_isBitmap = true;
                double ratiox = (double)m_bitmap.Width / (1.0 * panel1.Width);
                double ratioy = (double)m_bitmap.Height / (1.0 * panel1.Height);
                if (ratiox > ratioy)
                {
                    int kc = panel1.Height - (int)((double)m_bitmap.Height / ratiox);
                    Graphics c = Graphics.FromHwnd(panel1.Handle);
                    c.DrawImage(m_bitmap, 4, kc / 2, panel1.Width - 8, panel1.Height - kc);
                    c.Dispose();

                }
                else
                {
                    int kc = panel1.Width - (int)((double)m_bitmap.Width / ratioy);
                    Graphics c = Graphics.FromHwnd(panel1.Handle);
                    c.DrawImage(m_bitmap, kc / 2, 4, panel1.Width - kc, panel1.Height - 8);
                    c.Dispose();
                }
            }
        }
        private void button1_OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                m_bitmap = new Bitmap(openFileDialog1.FileName);
                is_file = true;
                if (m_bitmap != null)
                {
                    panel1.Refresh();
                    m_isVideo = false;
                    if (m_thread != null)
                    {
                        if (m_thread.IsAlive)
                            m_thread.Abort();
                    }
                    if (m_video != null)
                        m_video.Dispose();
                    m_isBitmap = true;
                    double ratiox = (double)m_bitmap.Width / (1.0 * panel1.Width);
                    double ratioy = (double)m_bitmap.Height / (1.0 * panel1.Height);
                    if (ratiox > ratioy)
                    {
                        int kc = panel1.Height - (int)((double)m_bitmap.Height / ratiox);
                        Graphics c = Graphics.FromHwnd(panel1.Handle);
                        c.DrawImage(m_bitmap, 4, kc / 2, panel1.Width - 8, panel1.Height - kc);
                        c.Dispose();

                    }
                    else
                    {
                        int kc = panel1.Width - (int)((double)m_bitmap.Width / ratioy);
                        Graphics c = Graphics.FromHwnd(panel1.Handle);
                        c.DrawImage(m_bitmap, kc / 2, 4, panel1.Width - kc, panel1.Height - 8);
                        c.Dispose();
                    }
                }
            }
        }

        private void Form_AddFace_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_isVideo = false;
            if (m_thread != null)
            {
                if (m_thread.IsAlive)
                    m_thread.Abort();
            }
            if (m_bitmap != null)
                m_bitmap.Dispose();
            if (m_bitmap_Face != null)
                m_bitmap_Face.Dispose();
            if (m_bitmap_snapshot != null)
                m_bitmap_snapshot.Dispose();
            if (m_video != null)
                m_video.Dispose();

        }

        private void click_FaceDetect(object sender, EventArgs e)
        {

            if (btn_FaceDetect.Text=="Chụp")
            {
                if (m_isVideo)
                {
                    if (m_bitmap_snapshot != null)
                        m_bitmap_snapshot.Dispose();
                    m_isSnapshot = true;
                    btn_FaceDetect.Text = "Chọn";
                }
            }
            else
            {
                try
                {

                    if (m_isBitmap)
                    {
                        if (m_FD_Face == null)
                        {
                            MessageBox.Show("Chưa tải bộ tìm kiếm khuôn mặt");
                            return;
                        }
                        m_bitmap_Face = m_FD_Face.DetectFaceImage(m_bitmap);
                        if (m_bitmap_Face != null)
                        {
                            pictureBox1.Image = m_bitmap_Face;
                        }
                        else
                        {
                            pictureBox1.Refresh();
                        }
                    }
                    else if (m_isVideo)
                    {
                        if (m_FD_Face == null || m_bitmap_snapshot == null)
                        {
                            MessageBox.Show("Chưa tải bộ tìm kiếm khuôn mặt");
                            return;
                        }
                        else if (m_bitmap_snapshot == null)
                        {
                            MessageBox.Show("Chưa chụp ảnh");
                            return;
                        }
                        Bitmap temp = new Bitmap(m_bitmap_snapshot);
                        m_bitmap_Face = m_FD_Face.DetectFaceImage(temp);
                        if (m_bitmap_Face != null)
                        {
                            pictureBox1.Image = m_bitmap_Face;
                        }
                        else
                        {
                            pictureBox1.Refresh();
                        }
                        temp.Dispose();
                    }

                }
                catch (Exception ex)
                {
                    pictureBox1.Refresh();
                }
            }
            

        }


        public void bw_DoWork()
        {
            while (m_isVideo)
            {
                try
                {
                    if (m_isSnapshot)
                    {
                        IntPtr _Temp;
                        if (m_bitmap != null)
                        {
                            m_bitmap_snapshot = new Bitmap(m_bitmap);
                            m_isSnapshot = false;
                            label_progressing.Invoke(new Action(() => {
                                label_progressing.Text = "Đã Chụp ảnh";
                            }));
                            //panel2.Invoke(new Action(() =>
                            //{
                            //    double ratiox = (double)m_bitmap_snapshot.Width / (1.0 * panel2.Width);
                            //    double ratioy = (double)m_bitmap_snapshot.Height / (1.0 * panel2.Height);
                            //    if (ratiox > ratioy)
                            //    {
                            //        int kc = panel2.Height - (int)((double)m_bitmap_snapshot.Height / ratiox);
                            //        Graphics c = Graphics.FromHwnd(panel2.Handle);
                            //        c.DrawImage(m_bitmap_snapshot, 4, kc / 2, panel2.Width - 8, panel2.Height - kc);
                            //        c.Dispose();

                            //    }
                            //    else
                            //    {
                            //        int kc = panel2.Width - (int)((double)m_bitmap.Width / ratioy);
                            //        Graphics c = Graphics.FromHwnd(panel2.Handle);
                            //        c.DrawImage(m_bitmap_snapshot, kc / 2, 4, panel2.Width - kc, panel2.Height - 8);
                            //        c.Dispose();
                            //    }

                            //}));
                        }

                    }
                    if (m_bitmap != null)
                        m_bitmap.Dispose();
                    bool res = m_video.queryFrame(ref m_bitmap);
                    if (res)
                    {
                        panel1.Invoke(new Action(() =>
                        {
                            double ratiox = (double)m_bitmap.Width / (1.0 * panel1.Width);
                            double ratioy = (double)m_bitmap.Height / (1.0 * panel1.Height);
                            if (ratiox > ratioy)
                            {
                                int kc = panel1.Height - (int)((double)m_bitmap.Height / ratiox);
                                Graphics c = Graphics.FromHwnd(panel1.Handle);
                                c.DrawImage(m_bitmap, 4, kc / 2, panel1.Width - 8, panel1.Height - kc);
                                c.Dispose();

                            }
                            else
                            {
                                int kc = panel1.Width - (int)((double)m_bitmap.Width / ratioy);
                                Graphics c = Graphics.FromHwnd(panel1.Handle);
                                c.DrawImage(m_bitmap, kc / 2, 4, panel1.Width - kc, panel1.Height - 8);
                                c.Dispose();
                            }

                        }));
                    }

                }
                catch (Exception e)
                {
                    m_isVideo = false;
                    continue;
                }
            }
        }
        private void SetVideo(bool isVideo)
        {
            m_isVideo = isVideo;
            if (m_isVideo)
            {
                btn_FaceDetect.Text = "Chụp";
            }
        }
        private void button_OpenCameraStream(object sender, EventArgs e)
        {
            CameraForm form = new CameraForm(true);
            form.Img += ChonTuFile;
            form.vid += SetVideo;
            //form.Location = m_list_pannel[m_index_pannel].Location;
            form.StartPosition = FormStartPosition.CenterScreen;
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.index == -1)
                    return;
                panel1.Refresh();
                m_isBitmap = false;
                if (m_video != null)
                    m_video.Dispose();
                //mo webcam
                if (form.index == 0)
                {
                    m_video = new VideoCapture();
                    m_isVideo = m_video.Open(0);
                    if (m_isVideo)
                    {
                        m_thread = new Thread(bw_DoWork);
                        //m_thread.IsBackground = true;
                        m_thread.Start();
                    }
                }
                else
                {
                    m_video = new VideoCapture();
                    //mo video
                    if (form.index == 1)
                        m_isVideo = m_video.OpenVideo(form.m_url);
                    //link stream
                    else if (form.index == 2)
                        m_isVideo = m_video.Open(form.m_url, m_width, m_height);
                    if (m_isVideo)
                    {
                        m_thread = new Thread(bw_DoWork);
                        //m_thread.IsBackground = true;
                        m_thread.Start();
                    }
                }

            }

        }

        private void getPer()
        {
            per.ID = DAL_PERSON.getIDNew();
            per.IMG_FACE = BLL_PARA.PathFace + txt_HoTen.Text + ".Jpg";
            this.emp.IMG_FACE = per.IMG_FACE;
            this.emp.ID_PS = per.ID;
            per.IMG = per.IMG_FACE;
            per.TIME_UPDATE = DateTime.Now;
            per.TYPE_PS = 1;
        }
        private void button_Click_Enroll(object sender, EventArgs e)
        {
            if (m_bitmap_Face != null)
            {
                if (saveImg(m_bitmap_Face))
                {
                    getPer();                   
                    string rs = createEmp();
                    
                    if (rs == "Lưu thành công")
                    {
                        m_name = emp.ID.ToString();
                        Thread t = new Thread(HuanluyenThem);
                        t.Start();
                        txt_HoTen.ResetText();
                        txt_DiaChi.ResetText();
                        chk_profile.Checked = false;
                        btn_createProfile.Visible = false;
                        pictureBox1.ResetText();
                    }
                }
                
            }
            else
            {
                MessageBox.Show("Chưa có ảnh mặt");
            }

        }

        private void Form_AddFace_Load(object sender, EventArgs e)
        {
            label_progressing.Hide();
            if (m_bitmap_Face != null)
            {
                pictureBox1.Image = m_bitmap_Face;
            }
        }
        public void HuanluyenThem()
        {
            label_progressing.Invoke(new Action(() =>
                        {
                            label_progressing.Text = "Đang thêm dữ liệu mới";
                            label_progressing.Show();
                        }));

            m_face_recog.enroll_one_image(m_bitmap_Face, m_name);
            label_progressing.Invoke(new Action(() =>
            {
                label_progressing.Text = "Thành công";
                
            }));
            MessageBox.Show("Thành công", "Thông báo");
        }

        private void button_snapshot_Click(object sender, EventArgs e)
        {
            if (m_isVideo)
            {
                if (m_bitmap_snapshot != null)
                    m_bitmap_snapshot.Dispose();
                m_isSnapshot = true;
                /*
                m_isVideo = false;
                Thread.Sleep(10);
                Mutex t = new Mutex();
                t.WaitOne();
                Bitmap temp = new Bitmap(m_bitmap);
                if (temp != null)
                {
                    
                    temp.Dispose();
                }
                t.ReleaseMutex();
                t.Dispose();
                m_isVideo = true;
                * */
            }

        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool saveImg(Bitmap bmp)
        {
            try
            {

                // Save Image
                string filename = BLL_PARA.PathFace + Ultis.RemoveUnicode(txt_HoTen.Text) + ".Jpg";
                FileStream fstream = new FileStream(filename, FileMode.Create);
                bmp.Save(fstream, System.Drawing.Imaging.ImageFormat.Jpeg);
                fstream.Close();
                return true;


            }
            catch (Exception)
            {

                return false;
            }

        }
        private string createEmp()
        {
            try
            {

                using (var context = new DBEntities())
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            context.PERSONALs.Add(per);
                            
                                context.EMPLOYEEs.Add(emp);                                
                            
                            context.SaveChanges();
                            dbContextTransaction.Commit();
                            return "Lưu thành công";
                        }
                        catch (Exception)
                        {
                            dbContextTransaction.Rollback();
                            return "Không lưu được";

                        }
                    }
                }
            }
            catch (Exception)
            {

                return "Không lưu được";
            }
        }
        private void GetEmp(EMPLOYEE emp)
        {
            
                this.emp.ID = DAL_EMPLOYEE.getIDNew();
                this.emp.ID_PS = per.ID;
                this.emp.IMG_FACE = per.IMG_FACE;
                this.emp.BIRTHDAY = emp.BIRTHDAY;
                this.emp.CMT = emp.CMT;
                this.emp.EMAIL = emp.EMAIL;
                this.emp.GENDER = emp.GENDER;
                this.emp.ISDELETE = emp.ISDELETE;
                this.emp.NAME = emp.NAME;
                this.emp.PHONE = emp.PHONE;
                this.emp.ISDELETE = false;
                this.emp.ADDRESS_EMP = emp.ADDRESS_EMP;
                chk_profile.Checked = true;
            


        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (m_bitmap_Face!=null)
            {
                frm_ProfileEmp frm = new frm_ProfileEmp(m_bitmap_Face, txt_HoTen.Text, txt_DiaChi.Text);
                frm.SetProfile += GetEmp;
                frm.ShowDialog();
            }
            
        }

        private void comboBox_attribute_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        
    }
}
