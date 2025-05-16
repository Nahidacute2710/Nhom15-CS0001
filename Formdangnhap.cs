using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static Test_winform.Caynhiphantimkiem;
using MyTreeNode = Test_winform.Caynhiphantimkiem.TreeNode;

namespace Test_winform
{
    
    public partial class FormDangNhap : Form
    {
        public static Caynhiphantimkiem.CayNhiPhan cay = new Caynhiphantimkiem.CayNhiPhan(); 


        public FormDangNhap(CayNhiPhan cayTruyenVao)
        {
            InitializeComponent();
            this.FormClosed += FormDangNhap_FormClosed;
            cay = cayTruyenVao;
            if (cay.root == null)
            {
                cay.ChenThongTin(123, "Đinh Hoàng Nhã", "nha123", "Nam", "Động gay, phường 69, Quận 36, Tp.Hcm", "Kular Lampour", "Thailand", new DateTime(2006, 09, 08), Properties.Resources.Nha);
                cay.ChenThongTin(467, "Đức Thành", "thanh123", "Nam", "Ehomes Phú Hữu, Phường Phú Hữu, Quận 9, Tp.Hcm", "Vĩnh Phúc", "Việt Nam", new DateTime(2006, 09, 04), Properties.Resources.Thanh);
                cay.ChenThongTin(890, "Duy Lợi", "duyloi123", "Nam", "đường Trần Hưng Đạo, Quận 1, Tp.Hcm", "Califonia", "Hoa Kì", new DateTime(2006, 07, 04), Properties.Resources.Loi);
                cay.ChenThongTin(106, "Nghĩa Lê", "lee11", "Nam", "đường Hai Bà Trưng, Quận 3, Tp.Hcm", "Tp.Hcm", "Việt Nam", new DateTime(2006, 08, 30), Properties.Resources.Nghia);
                cay.ChenThongTin(107, "Nam", "nam11", "Nam", "đường Bùi Viện, Quận 3, Tp.Hcm ", "TPHcm", "Việt Nam", new DateTime(2006, 01, 01), Properties.Resources.Nam);
            }
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id;
            if (!int.TryParse(txbtaikhoan.Text, out id))
            {
                MessageBox.Show("ID phải là số!", "Lỗi");
                return;
            }

            string matkhau = txbmatkhau.Text;
            var nguoi = cay.TimKiemThongTin(id, matkhau);

            if (nguoi != null)
            {
                txbmatkhau.Clear();
                txbtaikhoan.Clear();
                FormChuongTrinh f = new FormChuongTrinh(nguoi, cay); // Truyền thông tin người dùng
                f.FormClosed += (a, l) => { this.Show(); };
                f.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Sai ID hoặc mật khẩu", "Lỗi");
                txbtaikhoan.Focus();
            }
        }
        private void txtbotton4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void FormDangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void btdangki_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Formdangki dkForm = new Formdangki(cay);
            dkForm.ShowDialog();
            this.Show();
          
        }
    }
}
