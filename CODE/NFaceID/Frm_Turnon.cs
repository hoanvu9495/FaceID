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
    public partial class Frm_Turnon : Form
    {
        public double m_threshold = 0.0;

        public Frm_Turnon()
        {
            InitializeComponent();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            m_threshold = Convert.ToDouble(textBox_threshold.Text);
        }

        private void Frm_Turnon_Load_1(object sender, EventArgs e)
        {
            textBox_threshold.Text = m_threshold.ToString();
            textBox2.Text = "8";
            textBox3.Text = "17";
        }
    }
}
