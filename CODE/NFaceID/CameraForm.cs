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
    public partial class CameraForm : Form
    {
        public delegate void ChooseIMG(Bitmap m_bitmap, bool isFile);
        public delegate void ChooseVideo(bool isVideo);
        public ChooseVideo vid = null;
        public ChooseIMG Img = null;
        public int index = -1;
        public String m_url = "";
        bool m_isRegis = false;
        public CameraForm()
        {
            InitializeComponent();

        }
        public CameraForm(bool isRegis)
        {
            InitializeComponent();
            m_isRegis = isRegis;

        }

        private void CameraForm_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox3.Checked = false;
            checkBox2.Checked = false;
            textBox2.Enabled = false;
            textBox1.Enabled = false;
            btn_ChonAnh.Enabled = false;
            button1.Enabled = false;
        }
        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox3.Checked = false;
                checkBox2.Checked = false;
                textBox2.Enabled = false;
                textBox1.Enabled = false;
                button1.Enabled = false;
                index = 0;//webcam
            }
        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
                checkBox3.Checked = false;
                textBox2.Enabled = false;
                textBox1.Enabled = true;
                button1.Enabled = true;
                index = 1;//video
            }
        }


        private void checkBox3_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox4.Checked = false;
                textBox2.Enabled = true;
                textBox1.Enabled = false;
                button1.Enabled = false;
                index = 2;//camera stream
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                m_url = openFileDialog1.FileName;
                textBox1.Text = m_url;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (m_isRegis)
            {
                if (checkBox4.Checked)
                {
                    vid(false);
                }
                else
                {
                    vid(true);
                }
            }

            if (index == 1)
            {
                m_url = textBox1.Text;
            }
            else if (index == 2)
            {
                m_url = textBox2.Text;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Bitmap m_bitmap = new Bitmap(openFileDialog1.FileName);
                bool is_file = true;
                txt_ChonAnh.Text = openFileDialog1.FileName;
                Img(m_bitmap, is_file);
            }
        }

        private void checkBox4_Click(object sender, EventArgs e)
        {
            btn_ChonAnh.Enabled = true;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked==true)
            {
                btn_ChonAnh.Enabled = false;
                checkBox1.Checked = false;
                checkBox3.Checked = false;
                checkBox2.Checked = false;
                textBox2.Enabled = false;
                textBox1.Enabled = false;
                btn_ChonAnh.Enabled = false;
                button1.Enabled = false;
            }
            else
            {
                btn_ChonAnh.Enabled = false;
            }
        }
    }
}
