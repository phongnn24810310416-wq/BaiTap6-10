using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace bai5._2
{
    public partial class Form1 : Form
    {
        Dictionary<string, List<string>> ds = new Dictionary<string, List<string>>();

        public Form1()
        {
            InitializeComponent();

            ds.Add("Khám bệnh", new List<string>
            {
                "Khám tổng quát - 200000",
                "Khám chuyên khoa - 300000"
            });

            ds.Add("Xét nghiệm", new List<string>
            {
                "Xét nghiệm máu - 150000",
                "Xét nghiệm nước tiểu - 100000"
            });

            ds.Add("Chụp X-Quang", new List<string>
            {
                "Chụp X-Quang phổi - 250000",
                "Chụp X-Quang xương - 300000"
            });

            ds.Add("Vắc-xin", new List<string>
            {
                "Vắc-xin cúm - 200000",
                "Vắc-xin viêm gan - 350000"
            });

            cboCategory.Items.Add("Khám bệnh");
            cboCategory.Items.Add("Xét nghiệm");
            cboCategory.Items.Add("Chụp X-Quang");
            cboCategory.Items.Add("Vắc-xin");

            txtTongTien.ReadOnly = true;
            txtThanhTien.ReadOnly = true;
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstAvailableServices.Items.Clear();

            foreach (string x in ds[cboCategory.Text])
                lstAvailableServices.Items.Add(x);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (lstAvailableServices.SelectedItem != null)
            {
                lstSelectedServices.Items.Add(lstAvailableServices.SelectedItem);
                lstAvailableServices.Items.Remove(lstAvailableServices.SelectedItem);
                TinhTien();
            }
        }

        private void lstAvailableServices_DoubleClick(object sender, EventArgs e)
        {
            btnSelect_Click(sender, e);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstSelectedServices.SelectedItem != null)
            {
                lstAvailableServices.Items.Add(lstSelectedServices.SelectedItem);
                lstSelectedServices.Items.Remove(lstSelectedServices.SelectedItem);
                TinhTien();
            }
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            while (lstSelectedServices.Items.Count > 0)
            {
                lstAvailableServices.Items.Add(lstSelectedServices.Items[0]);
                lstSelectedServices.Items.RemoveAt(0);
            }

            TinhTien();
        }

        private void txtChietKhau_TextChanged(object sender, EventArgs e)
        {
            TinhTien();
        }

        private void TinhTien()
        {
            double tong = 0;

            foreach (string x in lstSelectedServices.Items)
            {
                string[] a = x.Split('-');
                tong += double.Parse(a[a.Length - 1].Trim());
            }

            double chietKhau = 0;
            double.TryParse(txtChietKhau.Text, out chietKhau);

            double thanhTien = tong - tong * chietKhau / 100;

            txtTongTien.Text = tong.ToString("N0");
            txtThanhTien.Text = thanhTien.ToString("N0");
        }
    }
}