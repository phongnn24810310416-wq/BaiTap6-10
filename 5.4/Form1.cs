using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace bai5._4
{
    public partial class Form1 : Form
    {
        Dictionary<string, List<string[]>> ds = new Dictionary<string, List<string[]>>();

        public Form1()
        {
            InitializeComponent();

            ImageList img = new ImageList();
            img.Images.Add("folder", SystemIcons.WinLogo);
            img.Images.Add("employee", SystemIcons.Application);
            tvDepartments.ImageList = img;
            lsvEmployees.SmallImageList = img;
            lsvEmployees.LargeImageList = img;

            TaoDuLieu();
            TaoCay();

            cboView.Items.Add("Details");
            cboView.Items.Add("SmallIcon");
            cboView.Items.Add("LargeIcon");
            cboView.Items.Add("Tile");
            cboView.SelectedIndex = 0;
        }

        private void TaoDuLieu()
        {
            ds.Add("Kế toán", new List<string[]>
            {
                new string[] { "NV001", "Nguyễn Văn An", "Kế toán trưởng", "01/03/2022" },
                new string[] { "NV002", "Trần Thị Hoa", "Kế toán viên", "15/06/2023" }
            });

            ds.Add("Nhân sự", new List<string[]>
            {
                new string[] { "NV003", "Lê Văn Bình", "Trưởng phòng", "10/02/2021" },
                new string[] { "NV004", "Phạm Thị Lan", "Nhân viên", "20/08/2023" }
            });

            ds.Add("Lập trình", new List<string[]>
            {
                new string[] { "NV005", "Nguyễn Minh Tuấn", "Trưởng nhóm", "05/01/2022" },
                new string[] { "NV006", "Đỗ Văn Nam", "Lập trình viên", "12/09/2024" }
            });

            ds.Add("Kiểm thử", new List<string[]>
            {
                new string[] { "NV007", "Hoàng Văn Long", "Trưởng nhóm", "10/04/2022" },
                new string[] { "NV008", "Vũ Thị Mai", "Tester", "18/07/2024" }
            });

            ds.Add("Kinh doanh", new List<string[]>
            {
                new string[] { "NV009", "Trần Văn Hùng", "Trưởng nhóm", "02/05/2021" },
                new string[] { "NV010", "Nguyễn Thị Hà", "Nhân viên", "22/10/2023" }
            });
        }

        private void TaoCay()
        {
            TreeNode congTy = new TreeNode("Công ty");
            congTy.ImageKey = "folder";

            TreeNode keToan = new TreeNode("Phòng Kế toán");
            TreeNode nhanSu = new TreeNode("Phòng Nhân sự");

            TreeNode cntt = new TreeNode("Phòng Công nghệ thông tin");
            TreeNode kinhDoanh = new TreeNode("Phòng Kinh doanh");

            keToan.ImageKey = "folder";
            nhanSu.ImageKey = "folder";
            cntt.ImageKey = "folder";
            kinhDoanh.ImageKey = "folder";

            TreeNode nhomLapTrinh = new TreeNode("Nhóm Lập trình");
            TreeNode nhomKiemThu = new TreeNode("Nhóm Kiểm thử");

            nhomLapTrinh.ImageKey = "folder";
            nhomKiemThu.ImageKey = "folder";

            keToan.Tag = "Kế toán";
            nhanSu.Tag = "Nhân sự";
            nhomLapTrinh.Tag = "Lập trình";
            nhomKiemThu.Tag = "Kiểm thử";
            kinhDoanh.Tag = "Kinh doanh";

            congTy.Nodes.Add(keToan);
            congTy.Nodes.Add(nhanSu);

            cntt.Nodes.Add(nhomLapTrinh);
            cntt.Nodes.Add(nhomKiemThu);

            congTy.Nodes.Add(cntt);
            congTy.Nodes.Add(kinhDoanh);

            tvDepartments.Nodes.Add(congTy);
            congTy.Expand();
            cntt.Expand();
        }

        private void tvDepartments_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lsvEmployees.Items.Clear();

            if (e.Node.Tag == null)
                return;

            string phong = e.Node.Tag.ToString();

            if (!ds.ContainsKey(phong))
                return;

            foreach (string[] nv in ds[phong])
            {
                ListViewItem item = new ListViewItem(nv[0]);
                item.SubItems.Add(nv[1]);
                item.SubItems.Add(nv[2]);
                item.SubItems.Add(nv[3]);
                item.ImageKey = "employee";

                lsvEmployees.Items.Add(item);
            }
        }

        private void cboView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboView.Text == "Details")
                lsvEmployees.View = View.Details;
            else if (cboView.Text == "SmallIcon")
                lsvEmployees.View = View.SmallIcon;
            else if (cboView.Text == "LargeIcon")
                lsvEmployees.View = View.LargeIcon;
            else
                lsvEmployees.View = View.Tile;
        }
    }
}
