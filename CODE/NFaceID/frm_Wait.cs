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
    public partial class frm_Wait : Form
    {
        public frm_Wait()
        {
            InitializeComponent();
        }

        
        public frm_Wait(string s)
        {
            InitializeComponent();
            lbl_Content.Text = s;
        }
        public void CloseFRM()
        {
            this.Invoke(new Action(() =>
            {
                this.Close();
            }));
        }
        private void frm_Wait_Load(object sender, EventArgs e)
        {
            
        }
    }
}
