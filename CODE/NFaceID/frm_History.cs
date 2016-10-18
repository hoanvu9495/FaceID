using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NFaceID.Entities;
using NFaceID.DAL;
using NFaceID.BLL;

namespace NFaceID
{
    public partial class frm_History : Form
    {
        DateTime s;
        DateTime end;
        private int PageCur;
        private int PageCount;
        public frm_History()
        {
            InitializeComponent();
        }
        private void loadDGV()
        {
            DateTime now = DateTime.Today;
             s = new DateTime(now.Year,now.Month,now.Day,0,0,0);
             end = new DateTime(now.Year, now.Month, now.Day, 23, 59, 0);
            PageCount = DAL_HISTORY.PageCount(s, end);
            button3.Enabled = false;
            if (PageCount > 1)
            {
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }
            dgv_History.DataSource = BLL_HISTORY.filterPage(s, end, 1);
            if (dgv_History.Rows.Count > 0)
            {
                DataGridViewImageColumn img = (DataGridViewImageColumn)dgv_History.Columns["AnhNV"];
                img.ImageLayout = DataGridViewImageCellLayout.Stretch;
                PageCur = 1;
                for (int i = 0; i < dgv_History.Rows.Count; i++)
                {
                    Bitmap imgv = new Bitmap(dgv_History.Rows[i].Cells["IMG_FACE"].Value.ToString());
                    img.Image = imgv;
                    dgv_History.Rows[i].MinimumHeight = 80;


                }
            }
        }
        private void frm_History_Load(object sender, EventArgs e)
        {
            loadDGV();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             s = (DateTime)dateTimePicker1.Value;
             end = (DateTime)dateTimePicker2.Value;
            if (s > end)
            {
                MessageBox.Show("Vui lòng điều chỉnh lại thời gian bắt đầu và kết thúc", "Thông báo");
            }
            else
            {
                PageCount = DAL_HISTORY.PageCount(s, end);
                button3.Enabled = false;
                if (PageCount>1)
                {
                    button2.Enabled = true;
                }
                else
                {
                    button2.Enabled = false;
                }
                dgv_History.DataSource = BLL_HISTORY.filterPage(s, end,1);
                if (dgv_History.Rows.Count > 0)
                {
                    DataGridViewImageColumn img = (DataGridViewImageColumn)dgv_History.Columns["AnhNV"];
                    img.ImageLayout = DataGridViewImageCellLayout.Stretch;
                    PageCur = 1;
                    for (int i = 0; i < dgv_History.Rows.Count; i++)
                    {
                        Bitmap imgv = new Bitmap(dgv_History.Rows[i].Cells["IMG_FACE"].Value.ToString());
                        img.Image = imgv; 
                        dgv_History.Rows[i].MinimumHeight = 80;
                        

                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            button3.Enabled = true;
            if (s > end)
            {
                MessageBox.Show("Vui lòng điều chỉnh lại thời gian bắt đầu và kết thúc", "Thông báo");
            }
            else
            {

                dgv_History.DataSource = BLL_HISTORY.filterPage(s, end, PageCur + 1);
                if (dgv_History.Rows.Count > 0)
                {
                    DataGridViewImageColumn img = (DataGridViewImageColumn)dgv_History.Columns["AnhNV"];
                    img.ImageLayout = DataGridViewImageCellLayout.Stretch;
                    PageCur += 1;
                    for (int i = 0; i < dgv_History.Rows.Count; i++)
                    {
                        Bitmap imgv = new Bitmap(dgv_History.Rows[i].Cells["IMG_FACE"].Value.ToString());
                        img.Image = imgv;
                        dgv_History.Rows[i].MinimumHeight = 80;


                    }
                }
            }
            if (PageCur == PageCount)
            {
                button2.Enabled = false;
                button3.Enabled = true;
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            
            if (s > end)
            {
                MessageBox.Show("Vui lòng điều chỉnh lại thời gian bắt đầu và kết thúc", "Thông báo");
            }
            else
            {

                dgv_History.DataSource = BLL_HISTORY.filterPage(s, end, PageCur - 1);
                if (dgv_History.Rows.Count > 0)
                {
                    DataGridViewImageColumn img = (DataGridViewImageColumn)dgv_History.Columns["AnhNV"];
                    img.ImageLayout = DataGridViewImageCellLayout.Stretch;
                    PageCur -= 1;
                    for (int i = 0; i < dgv_History.Rows.Count; i++)
                    {
                        Bitmap imgv = new Bitmap(dgv_History.Rows[i].Cells["IMG_FACE"].Value.ToString());
                        img.Image = imgv;
                        dgv_History.Rows[i].MinimumHeight = 80;


                    }
                }
            }
            if (PageCur == 1)
            {
                button3.Enabled = false;
                button2.Enabled = true;
            }
           
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
