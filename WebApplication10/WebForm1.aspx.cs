using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication10
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void LoadTB()
        {
            Table1.Rows.Clear();

            TableHeaderRow header = new TableHeaderRow();
            header.Cells.Add(new TableHeaderCell { Text = "STT" });
            header.Cells.Add(new TableHeaderCell { Text = "Họ tên" });
            header.Cells.Add(new TableHeaderCell { Text = "Email" });
            header.Cells.Add(new TableHeaderCell { Text = "SĐT" });
            header.Cells.Add(new TableHeaderCell { Text = "Ngày sinh" });
            header.Cells.Add(new TableHeaderCell { Text = "Giới tính" });
            header.Cells.Add(new TableHeaderCell { Text = "Khóa học" });
            header.Cells.Add(new TableHeaderCell { Text = "Tác vụ" });
            Table1.Rows.Add(header);

            if (ViewState["Data"] != null)
            {
                List<SinhVien> ListSV = (List<SinhVien>)ViewState["Data"];
                int count = 1;
                foreach (var sv in ListSV)
                {
                    TableRow row = new TableRow();
                    row.Cells.Add(new TableCell { Text = count.ToString() });
                    row.Cells.Add(new TableCell { Text = sv.HoTen });
                    row.Cells.Add(new TableCell { Text = sv.Email });
                    row.Cells.Add(new TableCell { Text = sv.SDT });
                    row.Cells.Add(new TableCell { Text = sv.NgaySinh.ToShortDateString() });
                    row.Cells.Add(new TableCell { Text = sv.GioiTinh });
                    row.Cells.Add(new TableCell { Text = sv.KhoaHoc });
                    Table1.Rows.Add(row);
                    count++;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtBoxHoTen.Attributes["placeholder"] = "Enter full name";
                txtBoxEmail.Attributes["placeholder"] = "Enter email";
                txtBoxSDT.Attributes["placeholder"] = "Enter numberphone";
            }
            LoadTB();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            bool check = true;
            string hoten = txtBoxHoTen.Text.Trim();
            string email = txtBoxEmail.Text.Trim();
            string sdt = txtBoxSDT.Text.Trim();
            DateTime ngaysinh;
            string gioitinh = RadioButton1.Checked ? "Nam" : (RadioButton2.Checked ? "Nữ" : "");

            lblErrHoTen.Visible = lblErrEmail.Visible = lblErrSDT.Visible =
                lblErrNgaySinh.Visible = lblErrGT.Visible = lblErrOption.Visible = false;

            List<SinhVien> data;

            if (ViewState["Data"] == null)
            {
                data = new List<SinhVien>();
            }
            else data = (List<SinhVien>)ViewState["Data"];

            if (string.IsNullOrEmpty(hoten))
            {
                lblErrHoTen.Text = "Họ tên không được để trống";
                lblErrHoTen.Visible = true;
                check = false;
            }

            if (string.IsNullOrEmpty(email) || !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                lblErrEmail.Text = "Email không hợp lệ (ví dụ: ex@ex.com)";
                lblErrEmail.Visible = true;
                check = false;
            }
            if (string.IsNullOrEmpty(sdt) || !Regex.IsMatch(sdt, @"^0\d{8,10}$"))
            {
                lblErrSDT.Text = "SĐT phải bắt đầu bằng 0 và có 9-11 số";
                lblErrSDT.Visible = true;
                check = false;
            }
            if (!DateTime.TryParse(txtBoxNgaySinh.Text, out ngaysinh))
            {
                lblErrNgaySinh.Text = "Ngày sinh không hợp lệ";
                lblErrNgaySinh.Visible = true;
                check = false;
            }
            if (string.IsNullOrEmpty(gioitinh))
            {
                lblErrGT.Text = "Vui lòng chọn giới tính";
                lblErrGT.Visible = true;
                check = false;
            }
            string khoa = ddlKhoa.SelectedValue;
            if (string.IsNullOrEmpty(khoa))
            {
                lblErrOption.Text = "Vui lòng chọn khóa học";
                lblErrOption.Visible = true;
                check = false;
            }
            else if (data.Any(s => s.HoTen == hoten && s.KhoaHoc == khoa))
            {
                lblErrOption.Text = "Khóa học đã tồn tại";
                lblErrOption.Visible = true;
                check = false;
            }

            if (check)
            {
                data.Add(new SinhVien
                {
                    HoTen = hoten,
                    Email = email,
                    GioiTinh = gioitinh,
                    KhoaHoc = khoa,
                    NgaySinh = ngaysinh,
                    SDT = sdt,
                });
                ViewState["Data"] = data;

                LoadTB(); 
            }
        }

       
    }
}
