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
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
        }

        private void Loading_Load(object sender, EventArgs e)
        {
            psb_load.Value = 5;
            lbl_Content.Text = "Đang Khởi động môi trường..";
        }
        public void loadParaSys()
        {
            lbl_Content.Invoke(new Action(() =>
            {
                lbl_Content.Text = "Đang Khởi động môi trường";
                lbl_Content.Show();
            }));
            psb_load.Invoke(new Action(() =>
            {
                psb_load.Value = 30;

            }));
        }
        public void loadData()
        {
            lbl_Content.Invoke(new Action(() =>
            {
                lbl_Content.Text = "Kết nối với cơ sở dữ liệu...";
                lbl_Content.Show();
            }));

            psb_load.Invoke(new Action(() =>
            {
                psb_load.Value = 60;

            }));
        }
        public void Completepros()
        {
            lbl_Content.Invoke(new Action(() =>
            {
                lbl_Content.Text = "Hoàn thành";
                lbl_Content.Show();
            }));
            psb_load.Invoke(new Action(() =>
            {
                psb_load.Value = 100;

            }));
            this.Invoke(new Action(() =>
            {
                this.Close();
            }));
           
        }


    }
}
