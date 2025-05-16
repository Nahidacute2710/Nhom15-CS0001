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
using Test_winform;
using static Test_winform.Caynhiphantimkiem;
using MyTreeNode = Test_winform.Caynhiphantimkiem.TreeNode;


namespace Test_winform
{
    public partial class FormChuongTrinh : Form
    {
        private Caynhiphantimkiem.CayNhiPhan cayNguoiDung;
        private Caynhiphantimkiem.TreeNode nguoiDung;
        private bool isEditMode = false;


        public FormChuongTrinh(Caynhiphantimkiem.TreeNode nguoi, Caynhiphantimkiem.CayNhiPhan cay)
        {
            InitializeComponent();
            nguoiDung = nguoi;
            cayNguoiDung = cay;
            txtID.Text =  nguoiDung.ID.ToString();
            txtHoten.Text = nguoiDung.Ten;
            cbGioitinh.Text = nguoiDung.GioiTinh;
            dtNgaysinh.Value = nguoiDung.NgaySinh;   
            txtQuequan.Text = nguoiDung.QueQuan;
            txtQuoctich.Text = nguoiDung.QuocTich;
            
            txtDiachi.Text = nguoiDung.DiaChi;
            if (nguoiDung.anh != null)
                pictureBox1.Image = TaoAnh(nguoiDung.anh); 
            ToggleEditMode(false);

        }

        private static Image TaoAnh(byte[] anh )
        {
            using(MemoryStream ms = new MemoryStream(anh))
            {
                return Image.FromStream(ms);
            }
        }
        private void ToggleEditMode(bool edit)
        {
            isEditMode = edit;
            txtID.ReadOnly = true;
            txtHoten.ReadOnly = !edit;
            cbGioitinh.Enabled = edit;
            dtNgaysinh.Enabled = edit;
            txtDiachi.ReadOnly = !edit;
            txtQuequan.ReadOnly = !edit;
            txtQuoctich.ReadOnly = !edit;
            
            btLuu.Visible = edit;
            btxoa.Visible = edit;
            btChinhsua.Visible = !edit;
            txtbutton3.Visible = !edit; 
            txtbotton4.Visible = !edit;
        }
        private void btChinhsua_Click(object sender, EventArgs e)
        {
            txtHoten.Text = nguoiDung.Ten;
            cbGioitinh.SelectedItem = nguoiDung.GioiTinh;
            dtNgaysinh.Value = nguoiDung.NgaySinh;
            txtDiachi.Text = nguoiDung.DiaChi;
            txtQuequan.Text = nguoiDung.QueQuan;
            txtQuoctich.Text = nguoiDung.QuocTich;

            ToggleEditMode(true);
        }
        private void btLuu_Click(object sender, EventArgs e)
        {
            // Cập nhật dữ liệu vào đối tượng người dùng
            nguoiDung.Ten = txtHoten.Text.Trim();
            nguoiDung.GioiTinh = cbGioitinh.SelectedItem?.ToString() ?? "";
            nguoiDung.NgaySinh = dtNgaysinh.Value;
            nguoiDung.DiaChi = txtDiachi.Text.Trim();
            nguoiDung.QueQuan = txtQuequan.Text.Trim();
            nguoiDung.QuocTich = txtQuoctich.Text.Trim();

            // Cập nhật lại giao diện
            txtHoten.Text = nguoiDung.Ten;
            cbGioitinh.Text = nguoiDung.GioiTinh;
            dtNgaysinh.Text = nguoiDung.NgaySinh.ToString("MM/dd/yyyy");
            txtDiachi.Text = nguoiDung.DiaChi;
            txtQuequan.Text = nguoiDung.QueQuan;
            txtQuoctich.Text = nguoiDung.QuocTich;

            ToggleEditMode(false);

            MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void txtbutton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtbotton4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (!isEditMode) return;
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Ảnh (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(dlg.FileName);
            }
        }
       
        private void btxoa_Click_1(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc muốn xóa tài khoản này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                cayNguoiDung.XoaTaiKhoan(nguoiDung.ID);
                MessageBox.Show("Đã xóa tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close(); 
            }
        }
    }
}
