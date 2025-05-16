using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Test_winform.Caynhiphantimkiem;
namespace Test_winform
{
    public partial class Formdangki : Form
    {
        private Caynhiphantimkiem.CayNhiPhan cay;
        public Formdangki(Caynhiphantimkiem.CayNhiPhan cay)
        {
            InitializeComponent();
            this.cay = cay;
            btxacnhan.Click -= btnDangKy_Click;
            btxacnhan.Click += btnDangKy_Click;
        }
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            int id;
            if (!int.TryParse(txtID.Text.Trim(), out id))
            {
                MessageBox.Show("ID phải là số nguyên.");
                return;
            }

            string ten = txtTen.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();
            string gioiTinh = cbGioiTinh.SelectedItem?.ToString() ?? "Không rõ";
            string diaChi = txtDiaChi.Text.Trim();
            string queQuan = txtQueQuan.Text.Trim();
            string quocTich = txtQuocTich.Text.Trim();
            DateTime ngaySinh = dtNgaySinh.Value;
            byte[] anh = null;

            if (pictureBox1.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                    anh = ms.ToArray();
                }
            }

            // Gọi cây nhị phân đã khai báo sẵn
            cay.ChenThongTin(id, ten, matKhau, gioiTinh, diaChi, queQuan, quocTich, ngaySinh, anh);

            MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Ảnh (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(dlg.FileName);
            }
        }

    }
}
