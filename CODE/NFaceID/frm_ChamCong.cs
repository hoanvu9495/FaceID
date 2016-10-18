using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NFaceID.BLL;
using Microsoft.Office.Interop.Excel;
using app = Microsoft.Office.Interop.Excel.Application;
using System.IO;
using OfficeOpenXml;
using System.Threading;
using OfficeOpenXml.Style;

namespace NFaceID
{
    public partial class frm_ChamCong : Form
    {
        bool IsDefault = true;
        public frm_ChamCong()
        {
            InitializeComponent();
        }
        private void loadDGV()
        {
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            cbx_Month.Text = month.ToString();
            dgv_CC.DataSource = BLL_ATTENDANCE.getByMonth(month, year);
            dgv_CC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }
        private void frm_ChamCong_Load(object sender, EventArgs e)
        {
            loadDGV();
        }
        private bool excelExTemplate(DataGridView dt, string path, string FileName)
        {
            using (var templateXls = new ExcelPackage(new FileInfo(path+@"BCCC.xlsx")))
            {
                try
                {
                    var sheet = templateXls.Workbook.Worksheets[1];
                    string month = "";
                    cbx_Month.Invoke(new System.Action(() =>
                    {
                        month = cbx_Month.Text;
                    }));
                    sheet.Cells["A5"].Value = "Tháng " + month + "Năm " + txt_year.Text;
                    DateTime dtCur = DateTime.Now;
                    sheet.Cells["W28"].Value = "Ngày " + dtCur.Day + " tháng " + dtCur.Month + " năm" + dtCur.Year;
                    for (int i = 2; i < dt.Columns.Count; i++)
                    {

                        sheet.Cells[9, i].Value = dt.Columns[i].HeaderText.ToString();
                    }
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        for (int j = 1; j < dt.Columns.Count; j++)
                        {
                            sheet.Cells[10 + i, j].Value = dt.Rows[i].Cells[j].Value.ToString();
                            sheet.Cells[10 + i, j].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        }
                    }
                    templateXls.SaveAs(new FileInfo(path + FileName + ".xlsx"));
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }



            }
        }
        private void excelEx(DataGridView dt, string path, string FileName)
        {

            app obj = new app();
            obj.Application.Workbooks.Add(Type.Missing);
            obj.Cells[2, 3] = "Báo cáo chấm công tháng 10";

            for (int i = 1; i < dt.Columns.Count + 1; i++)
            {
                obj.Cells[5, i] = dt.Columns[i - 1].HeaderText;


            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    obj.Cells[i + 6, j + 1] = dt.Rows[i].Cells[j].Value.ToString();

                }
            }
            obj.ActiveWorkbook.SaveCopyAs(path + FileName + ".xlsx");
            obj.ActiveWorkbook.Saved = true;
        }
        Thread exExcel;
        frm_Wait frmWait;
        string fileName;
        private void export()
        {

            excelExTemplate(dgv_CC, pathTem, fileName);
            frmWait.CloseFRM();
        }
        string pathTem = System.Windows.Forms.Application.StartupPath + @"\File\ExportEx\";
        private void btn_Excel_Click(object sender, EventArgs e)
        {
            string month = "";
            month = cbx_Month.Text;
            fileName = "Cham Cong Thang " + month;
            frmWait = new frm_Wait("Đang xuất file excel " + pathTem + fileName + ".xlsx");
            
            exExcel = new Thread(export);
            exExcel.Start();
            frmWait.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (BLL_Validate.NumValidate(txt_year.Text))
            {
                var rs = BLL_ATTENDANCE.getByMonth(int.Parse(cbx_Month.Text), int.Parse(txt_year.Text));
                if (rs.Rows.Count > 0)
                {
                    dgv_CC.DataSource = null;
                    dgv_CC.DataSource = rs;
                    dgv_CC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    dgv_CC.Show();
                }
                else
                {
                    dgv_CC.DataSource = null;
                    dgv_CC.Show();
                    MessageBox.Show("Không có dữ liệu", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Năm chỉ được nhập số");
            }
           
        }

        private void dgv_CC_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgv_Detail.DataSource = BLL_ATTENDANCE.getHisMonth(int.Parse(dgv_CC.Rows[e.RowIndex].Cells["ID"].Value.ToString()), int.Parse(cbx_Month.Text), int.Parse(txt_year.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
