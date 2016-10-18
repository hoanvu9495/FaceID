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
    public partial class InputLicense : Form
    {
        public String m_code = "";
        public Active m_active = null;
        public bool m_isActvived = false;
        public InputLicense()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m_code = textBox1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            m_code = textBox1.Text;
            m_isActvived = m_active.Register(m_code);
            textBox1.Text = "";
            if (m_isActvived)
            {
                textBox1.Text = "";
                MessageBox.Show("Bạn đã đăng ký thành công\n Cảm ơn bạn!");
            }
            else
            {
                textBox1.Text = "";
                MessageBox.Show("Mã kích hoạt không đúng\n Cảm ơn bạn!");
            }
        }
    }
}
