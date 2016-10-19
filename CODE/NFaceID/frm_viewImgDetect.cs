using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NFaceID
{
    public partial class frm_ViewImgDetect : Form
    {
        string img_detect;
        string img_tem;
        string ngay;
        string gio;
        public frm_ViewImgDetect()
        {
            InitializeComponent();
        }
        public frm_ViewImgDetect(string img_detect, string img_tem, string ngay, string gio)
        {
            InitializeComponent();
            this.img_detect = img_detect;
            this.img_tem = img_tem;
            this.ngay = ngay;
            this.gio = gio;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void frm_ViewImgDetect_Load(object sender, EventArgs e)
        {
            try
            {
                ptb_Img.Image = new Bitmap(img_detect);
                
            }catch (Exception ex)
            {
                ptb_Img.Image = new Bitmap(Application.StartupPath+@"\File\noimagefound.Jpg");
                
            }
            ptb_Img.SizeMode = PictureBoxSizeMode.StretchImage;
            try{
                ptb_ImgMau.Image = new Bitmap(img_tem);

            }
            catch
            {
                ptb_ImgMau.Image = new Bitmap(Application.StartupPath + @"\File\noimagefound.Jpg");

            }
            ptb_ImgMau.SizeMode = PictureBoxSizeMode.StretchImage;
            lbl_time.Text = ngay + " " + gio;
            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
