using System;
using System.Windows.Forms;

namespace bai5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            epCheck.Clear();
            bool hopLe = true;

            if (txtTenDangNhap.Text.Trim() == "")
            {
                epCheck.SetError(txtTenDangNhap, "Tên đăng nhập không được để trống");
                hopLe = false;
            }

            if (txtMatKhau.Text == "")
            {
                epCheck.SetError(txtMatKhau, "Mật khẩu không được để trống");
                hopLe = false;
            }

            if (txtXacNhan.Text != txtMatKhau.Text)
            {
                epCheck.SetError(txtXacNhan, "Mật khẩu nhập lại không khớp");
                hopLe = false;
            }

            int tuoi = DateTime.Now.Year - dtpNgaySinh.Value.Year;

            if (dtpNgaySinh.Value.Date > DateTime.Now.AddYears(-tuoi).Date)
                tuoi--;

            if (tuoi < 18)
            {
                epCheck.SetError(dtpNgaySinh, "Bạn phải đủ 18 tuổi");
                hopLe = false;
            }

            if (!chkDieuKhoan.Checked)
            {
                epCheck.SetError(chkDieuKhoan, "Bạn phải đồng ý điều khoản");
                hopLe = false;
            }

            if (hopLe)
            {
                MessageBox.Show("Đăng ký thành công");
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            txtXacNhan.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            rdoNam.Checked = false;
            rdoNu.Checked = false;
            chkDieuKhoan.Checked = false;
            epCheck.Clear();
        }
    }
}
