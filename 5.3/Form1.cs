using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace bai5._3
{
    public class Product
    {
        public string ProductId { get; set; } = "";
        public string ProductName { get; set; } = "";
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; } = "";
    }

    public partial class Form1 : Form
    {
        List<Product> ds = new List<Product>();
        BindingSource bs = new BindingSource();

        public Form1()
        {
            InitializeComponent();

            cboCategory.Items.Add("Điện thoại");
            cboCategory.Items.Add("Laptop");
            cboCategory.Items.Add("Phụ kiện");

            bs.DataSource = ds;
            dgvProducts.DataSource = bs;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Product p = new Product();

            p.ProductId = txtProductId.Text;
            p.ProductName = txtProductName.Text;
            p.UnitPrice = double.Parse(txtUnitPrice.Text);
            p.Quantity = int.Parse(txtQuantity.Text);
            p.Category = cboCategory.Text;

            ds.Add(p);
            bs.ResetBindings(false);
            XoaTrang();
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Product p = (Product)dgvProducts.Rows[e.RowIndex].DataBoundItem;

                txtProductId.Text = p.ProductId;
                txtProductName.Text = p.ProductName;
                txtUnitPrice.Text = p.UnitPrice.ToString();
                txtQuantity.Text = p.Quantity.ToString();
                cboCategory.Text = p.Category;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow != null)
            {
                Product p = (Product)dgvProducts.CurrentRow.DataBoundItem;

                p.ProductId = txtProductId.Text;
                p.ProductName = txtProductName.Text;
                p.UnitPrice = double.Parse(txtUnitPrice.Text);
                p.Quantity = int.Parse(txtQuantity.Text);
                p.Category = cboCategory.Text;

                bs.ResetBindings(false);
                XoaTrang();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow != null)
            {
                DialogResult kq = MessageBox.Show(
                    "Bạn có muốn xóa sản phẩm này không?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo);

                if (kq == DialogResult.Yes)
                {
                    Product p = (Product)dgvProducts.CurrentRow.DataBoundItem;
                    ds.Remove(p);

                    bs.DataSource = ds;
                    bs.ResetBindings(false);
                    XoaTrang();
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string ten = txtProductName.Text.ToLower();

            List<Product> ketQua = ds.FindAll(
                p => p.ProductName.ToLower().Contains(ten));

            bs.DataSource = ketQua;
            dgvProducts.DataSource = bs;
        }

        private void XoaTrang()
        {
            txtProductId.Clear();
            txtProductName.Clear();
            txtUnitPrice.Clear();
            txtQuantity.Clear();
            cboCategory.SelectedIndex = -1;
        }
    }
}   