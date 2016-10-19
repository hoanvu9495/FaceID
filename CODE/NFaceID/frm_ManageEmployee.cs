using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NFaceID.DAL;
using NFaceID.BLL;
using NFaceID.Entities;
using OfficeOpenXml;
using System.IO;
using System.Threading;
using OfficeOpenXml.Style;

namespace NFaceID
{
    public partial class frm_ManageEmployee : Form
    {
        private string message;
        private string url_Face_Cur;
        string dayStart;
        string dayEnd;
        public frm_ManageEmployee()
        {
            InitializeComponent();
            offGBX();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void loadDGV()
        {
            dgv_AllEmp.DataSource = BLL_EMPLOYEE.getAll();
            DataGridViewImageColumn imgclm = (DataGridViewImageColumn)dgv_AllEmp.Columns["IMG"];
            imgclm.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dgv_AllEmp.Columns["IMG_FACE"].Visible = false;
            for (int i = 0; i < dgv_AllEmp.Rows.Count; i++)
            {
                try
                {
                    Bitmap img = new Bitmap(dgv_AllEmp.Rows[i].Cells["IMG_FACE"].Value.ToString());
                    dgv_AllEmp.Rows[i].Cells["IMG"].Value = img;

                }
                catch (Exception)
                {
                    Bitmap img = new Bitmap(Application.StartupPath + @"\File\noimagefound.Jpg");
                    dgv_AllEmp.Rows[i].Cells["IMG"].Value = img;

                }
                dgv_AllEmp.Rows[i].MinimumHeight = 80;
            }
        }
        private void offGBX()
        {
            rbn_Nam.Enabled = false;
            rbn_Nu.Enabled = false;
            chk_NghiViec.Enabled = false;
            dgv_AllEmp.Enabled = true;
            txt_Cmt.Enabled = false;
            txt_DiaChi.Enabled = false;
            txt_Email.Enabled = false;
            txt_GhiChu.Enabled = false;
            txt_HoTen.Enabled = false;
            txt_SDT.Enabled = false;
            btn_Create.Enabled = true;
            btn_Create.Text = "Thêm";
            btn_edit.Enabled = false;
            btn_edit.Text = "Sửa";
            btn_delete.Enabled = false;
            btn_exit.Enabled = false;
            btn_reset.Enabled = false;
        }
        private void onGBX()
        {
            rbn_Nu.Enabled = true;
            rbn_Nam.Enabled = true;
            chk_NghiViec.Enabled = true;
            dgv_AllEmp.Enabled = true;
            txt_Cmt.Enabled = false;
            txt_DiaChi.Enabled = false;
            txt_Email.Enabled = false;
            txt_GhiChu.Enabled = false;
            txt_HoTen.Enabled = false;
            txt_SDT.Enabled = false;
            btn_Create.Enabled = true;
            btn_Create.Text = "Thêm";
            btn_edit.Enabled = false;
            btn_edit.Text = "Sửa";
            btn_delete.Enabled = false;
            btn_exit.Enabled = false;
            btn_reset.Enabled = false;
        }

        private void resetForm()
        {
            txt_Cmt.ResetText();
            txt_DiaChi.ResetText();
            txt_Email.ResetText();
            txt_GhiChu.ResetText();
            txt_HoTen.ResetText();
            txt_SDT.ResetText();
            rbn_Nam.Checked = true;
            rbn_Nu.Checked = false;
            chk_NghiViec.Checked = false;
        }
        private void btn_reset_Click(object sender, EventArgs e)
        {
            resetForm();
        }

        private bool checkEmpty()
        {
            message = string.Empty;
            if (!txt_HoTen.Text.Any())
            {
                message = "+ Vui lòng nhập tên\n";
            }
            if (!txt_Cmt.Text.Any())
            {
                message += "Vui lòng nhập số CMT/CCCD\n";
            }
            if (!txt_SDT.Text.Any())
            {
                message += "Vui lòng nhập số điện thoại liên hệ\n";
            }
            if (!txt_Email.Text.Any())
            {
                message += "Vui lòng nhập email\n";
            }
            if (!txt_DiaChi.Text.Any())
            {
                message += "Vui lòng nhập địa chỉ";
            }
            return true;

        }
        private void btn_Create_Click(object sender, EventArgs e)
        {
            if (btn_Create.Text == "Thêm")
            {
                btn_Create.Text = "Lưu";
                btn_edit.Enabled = false;
                btn_delete.Enabled = false;
                btn_exit.Enabled = true;
                btn_reset.Enabled = true;
                resetForm();
            }
        }

        private void frm_ManageEmployee_Load(object sender, EventArgs e)
        {
            loadDGV();
        }
        int idps;
        private void dgv_AllEmp_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            txt_HoTen.Text = dgv_AllEmp.Rows[e.RowIndex].Cells["NAME"].Value.ToString();
            url_Face_Cur = dgv_AllEmp.Rows[e.RowIndex].Cells["IMG_FACE"].Value.ToString();
            try
            {
                Bitmap img = new Bitmap(url_Face_Cur);
                ptb_ImageCustomer.Image = img;
            }
            catch (Exception)
            {
                ptb_ImageCustomer.Image = new Bitmap(Application.StartupPath + @"\File\noimagefound.Jpg");
            }
           
            ptb_ImageCustomer.SizeMode = PictureBoxSizeMode.StretchImage;
            txt_Cmt.Text = dgv_AllEmp.Rows[e.RowIndex].Cells["CMT"].Value.ToString();
            txt_Email.Text = dgv_AllEmp.Rows[e.RowIndex].Cells["EMAIL"].Value.ToString();
            txt_GhiChu.Text = dgv_AllEmp.Rows[e.RowIndex].Cells["GHICHU"].Value.ToString();
            txt_SDT.Text = dgv_AllEmp.Rows[e.RowIndex].Cells["PHONE"].Value.ToString();
            if (dgv_AllEmp.Rows[e.RowIndex].Cells["GT"].Value.ToString() == "Nam")
            {
                rbn_Nam.Checked = true;
            }
            else
            {
                rbn_Nu.Checked = true;
            }
            dtp_birthday.Text = dgv_AllEmp.Rows[e.RowIndex].Cells["BIRTHDAY"].Value.ToString();
            txt_DiaChi.Text = dgv_AllEmp.Rows[e.RowIndex].Cells["ADDRESS"].Value.ToString();
            idps = int.Parse(dgv_AllEmp.Rows[e.RowIndex].Cells["ID_PS"].Value.ToString());
            dgv_history.DataSource = BLL_HISTORY.getByEmp(idps);
            if (dgv_history.Rows.Count > 0)
            {
                dayEnd = dgv_history.Rows[0].Cells["NGAY"].Value.ToString();
                dayStart = dgv_history.Rows[dgv_history.Rows.Count - 1].Cells["NGAY"].Value.ToString();
            }
            emp = DAL_EMPLOYEE.getEmpByIDPER(idps);
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            DataTable dt = BLL_EMPLOYEE.SearchEmp(txt_keyWork.Text);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy!", "Tìm kiếm");
            }
            else
            {

                dgv_AllEmp.DataSource = dt;
                DataGridViewImageColumn imgclm = (DataGridViewImageColumn)dgv_AllEmp.Columns["IMG"];
                imgclm.ImageLayout = DataGridViewImageCellLayout.Stretch;
                dgv_AllEmp.Columns["IMG_FACE"].Visible = false;
                for (int i = 0; i < dgv_AllEmp.Rows.Count; i++)
                {
                    try
                    {
                        Bitmap img = new Bitmap(dgv_AllEmp.Rows[i].Cells["IMG_FACE"].Value.ToString());
                        dgv_AllEmp.Rows[i].Cells["IMG"].Value = img;                    

                    }
                    catch (Exception)
                    {
                        Bitmap img = new Bitmap(Application.StartupPath + @"\File\noimagefound.Jpg");
                        dgv_AllEmp.Rows[i].Cells["IMG"].Value = img;                    
                        
                    }
                    dgv_AllEmp.Rows[i].MinimumHeight = 80;
                }
            }
        }
        DateTime s;
        DateTime end;
        private void button5_Click(object sender, EventArgs e)
        {
            s = (DateTime)dtp_Start.Value;
            end = (DateTime)dtp_End.Value;
            if (s > end)
            {
                MessageBox.Show("Vui lòng chọn lại thời gian bắt đầu và kết thúc", "Lỗi lọc");
            }
            else
            {
                dgv_history.DataSource = BLL_HISTORY.filterByPer(s, end, idps);
                if (dgv_history.Rows.Count > 0)
                {
                    dayEnd = dgv_history.Rows[0].Cells["NGAY"].Value.ToString();
                    dayStart = dgv_history.Rows[dgv_history.Rows.Count - 1].Cells["NGAY"].Value.ToString();
                }

            }
        }

        private void dgv_history_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            Form frm = new frm_ViewImgDetect(dgv_history.CurrentRow.Cells["IMG_FACE"].Value.ToString(), url_Face_Cur, dgv_history.CurrentRow.Cells["NGAY"].Value.ToString(), dgv_history.CurrentRow.Cells["TIME"].Value.ToString());
            frm.ShowDialog();
        }
        EMPLOYEE emp;
        private bool excelExTemplate(DataGridView dt, string path, string FileName)
        {
            try
            {
                string pathTem = Application.StartupPath + @"\File\ExportEx\";
                using (var templateXls = new ExcelPackage(new FileInfo(pathTem + @"EmployTem.xlsx")))
                {
                    try
                    {
                        var sheet = templateXls.Workbook.Worksheets[1];
                        dtp_Start.Invoke(new Action(() =>
                        {
                            sheet.Cells["B4"].Value = dtp_Start.Text;
                        }));
                        dtp_End.Invoke(new Action(() =>
                        {
                            sheet.Cells["E4"].Value = dtp_End.Text;
                        }));


                        sheet.Cells["B5"].Value = emp.NAME;
                        sheet.Cells["B6"].Value = emp.BIRTHDAY;
                        sheet.Cells["B7"].Value = emp.GENDER;
                        sheet.Cells["B8"].Value = emp.NAME;
                        sheet.Cells["B9"].Value = emp.CMT;

                        DateTime dtCur = DateTime.Now;
                        sheet.Cells["B3"].Value = "Ngày " + dtCur.Day + " tháng " + dtCur.Month + " năm" + dtCur.Year;

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            sheet.Cells[12 + i, 1].Value = dt.Rows[i].Cells["STTHis"].Value.ToString();
                            sheet.Cells[12 + i, 1].Style.Border.BorderAround(ExcelBorderStyle.Hair, Color.Black);
                            sheet.Cells[12 + i, 2].Value = dt.Rows[i].Cells["NGAY"].Value.ToString();
                            sheet.Cells[12 + i, 2].Style.Border.BorderAround(ExcelBorderStyle.Hair, Color.Black);
                            sheet.Cells[12 + i, 3].Value = dt.Rows[i].Cells["TIME"].Value.ToString();
                            sheet.Cells[12 + i, 3].Style.Border.BorderAround(ExcelBorderStyle.Hair, Color.Black);
                            sheet.Cells[12 + i, 4].Value = dt.Rows[i].Cells["GHICHUHis"].Value.ToString();
                            sheet.Cells[12 + i, 4].Style.Border.BorderAround(ExcelBorderStyle.Hair, Color.Black);
                        }
                        templateXls.SaveAs(new FileInfo(pathTem + FileName + ".xlsx"));
                        return true;
                    }
                    catch (Exception)
                    {

                        return false;
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Vui lòng đóng file mẫu", "Thông báo");
                return false;
            }





        }
        Thread exExcel;
        frm_Wait frmWait;
        string fileName;
        private void export()
        {

            excelExTemplate(dgv_history, BLL_PARA.PathExcel, fileName);
            Thread.Sleep(200);
            frmWait.CloseFRM();

        }
        private void button6_Click(object sender, EventArgs e)
        {


            fileName = Ultis.RemoveUnicode(emp.NAME) + "_" + CODE.TextDateString(dayStart) + "_" + CODE.TextDateString(dayEnd);
            frmWait = new frm_Wait("Đang xuất file excel " + BLL_PARA.PathExcel + fileName + ".xlsx");
            exExcel = new Thread(export);
            exExcel.Start();
            frmWait.ShowDialog();
        }
    }
}
