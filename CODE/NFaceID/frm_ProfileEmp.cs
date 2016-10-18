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
using NFaceID.BLL;

namespace NFaceID
{
    public partial class frm_ProfileEmp : Form
    {
        public delegate void Profile(EMPLOYEE obj);
        public Profile SetProfile = null;
        EMPLOYEE emp = null;
        Bitmap _Img ;
        private string message;
        public frm_ProfileEmp(Bitmap img, string Name, string Address)
        {
            InitializeComponent();
            _Img = img;
            txt_HoTen.Text = Name;
            txt_DiaChi.Text = Address;
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (checkEmpty())
            {
                if (MessageBox.Show("Thông tin chưa đầy đủ, bạn có muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    this.Close();

                }

            }
            else
            {
                if (!checkEmpty())
                {
                    if (checkValidate())
                    {
                        emp = new EMPLOYEE();
                        emp.NAME = txt_HoTen.Text;
                        emp.CMT = txt_Cmt.Text;
                        emp.EMAIL = txt_Email.Text;
                        if (rbn_Nam.Checked)
                        {
                            emp.GENDER = "Nam";

                        }
                        else
                        {
                            emp.GENDER = "Nữ";

                        }
                        emp.ADDRESS_EMP = txt_DiaChi.Text;
                        emp.BIRTHDAY = dtp_Bỉthday.Value.Date;
                        emp.PHONE = txt_SDT.Text;
                        emp.ISDELETE = false;
                        SetProfile(emp);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(message, "Thông báo");
                    }
                }
            }
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
            if (message.Any())
            {
                return true;
            }
            return false;
        }

        private bool checkValidate()
        {
            message = string.Empty;
            if (!BLL_Validate.CMTValidate(txt_Cmt.Text))
            {
                message = "+ Vui lòng nhập đúng định dạng số cmt\n";
            }
            if (!BLL_Validate.EmailValidate(txt_Email.Text))
            {
                message = "+ Vui lòng nhập đúng định dạng email\n";

            }
            if (!BLL_Validate.PhoneValidate(txt_SDT.Text))
            {
                message = "+ Số điện thoại gồm các chữ số\n";

            }
            if (message.Any())
            {
                return false;
            }
            return true;
        }
        private void frm_ProfileEmp_Load(object sender, EventArgs e)
        {
            ptb_Face.Image = _Img;
        }
    }
}
