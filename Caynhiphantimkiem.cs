using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_winform
{
    public class Caynhiphantimkiem
    {
        public class TreeNode
        {
            public int ID;
            public string Ten;
            public string MatKhau;
            public string GioiTinh;
            public string DiaChi;
            public string QuocTich;
            public string QueQuan;
            public DateTime NgaySinh;
            public byte[] anh;
            public TreeNode Left;
            public TreeNode Right;

            public TreeNode(int id, string ten, string matKhau, string gioiTinh, 
            string diaChi, string queQuan, string quocTich, DateTime ngaySinh, byte[] anh)
            {
                ID = id;
                Ten = ten;
                MatKhau = matKhau;
                GioiTinh = gioiTinh;
                DiaChi = diaChi;
                QueQuan = queQuan;
                QuocTich = quocTich;
                NgaySinh = ngaySinh;
                this.anh = anh;
                Left = null;
                Right = null;
            }

        }

        public class CayNhiPhan
        {
            public TreeNode root;

            public void ChenThongTin(int id, string ten, string matKhau, string gioiTinh, 
            string diaChi, string queQuan, string quocTich, DateTime ngaySinh, byte[] anh)
            {
                root = ThemThongTinRec(root, id, ten, matKhau, gioiTinh, diaChi, queQuan, quocTich, ngaySinh, anh);
            }

            private TreeNode ThemThongTinRec(TreeNode node, int id, string ten, string matKhau, string gioiTinh, 
            string diaChi, string queQuan, string quocTich, DateTime ngaySinh, byte[] anh)
            {
                if (node == null)
                {
                    return new TreeNode(id, ten, matKhau, gioiTinh, diaChi, queQuan, quocTich, ngaySinh, anh);
                }

                int sosanh = id.CompareTo(node.ID); // So sánh ID

                if (sosanh > 0)
                {
                    node.Right = ThemThongTinRec(node.Right, id, ten, matKhau, gioiTinh, diaChi, queQuan, quocTich, ngaySinh, anh);
                }
                else if (sosanh < 0)
                {
                    node.Left = ThemThongTinRec(node.Left, id, ten, matKhau, gioiTinh, diaChi, queQuan, quocTich, ngaySinh, anh);
                }
                else
                {
                    MessageBox.Show("Tài khoản đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                return node;
            }

            public TreeNode TimKiemThongTin(int id, string matKhau)
            {
                return TimKiemThongTinRec(root, id, matKhau);
            }

            private TreeNode TimKiemThongTinRec(TreeNode node, int id, string matKhau)
            {
                if (node == null) return null;

                int sosanh = id.CompareTo(node.ID); // So sánh ID

                if (sosanh == 0)
                {
                    if (node.MatKhau == matKhau)
                    {
                        return node;
                    }
                    else
                    {
                        return null;
                    }
                }
                else if (sosanh < 0)
                {
                    return TimKiemThongTinRec(node.Left, id, matKhau);
                }
                else
                {
                    return TimKiemThongTinRec(node.Right, id, matKhau);
                }
            }

            public TreeNode XoaTaiKhoan(int id)
            {
                root = XoaTaiKhoanRec(root, id);
                return root;
            }

            private TreeNode XoaTaiKhoanRec(TreeNode node, int id)
            {
                if (node == null) return null;
                int sosanh = id.CompareTo(node.ID);

                if (sosanh > 0)
                {
                    node.Right = XoaTaiKhoanRec(node.Right, id);
                }
                else if (sosanh < 0)
                {
                    node.Left = XoaTaiKhoanRec(node.Left, id);
                }
                else
                {
                    // Trường hợp node không có con
                    if (node.Left == null && node.Right == null)
                    {
                        return null;
                    }

                    // Trường hợp node chỉ có một con
                    if (node.Right == null)
                    {
                        return node.Left;
                    }
                    else if (node.Left == null)
                    {
                        return node.Right;
                    }

                    // Trường hợp node có cả hai con
                    else
                    {
                        TreeNode thayThe = TimNodeNhoNhat(node.Right); // Tìm node nhỏ nhất ở cây con phải
                        node.ID = thayThe.ID;
                        node.Ten = thayThe.Ten;
                        node.MatKhau = thayThe.MatKhau;
                        node.GioiTinh = thayThe.GioiTinh;
                        node.DiaChi = thayThe.DiaChi;
                        node.QueQuan = thayThe.QueQuan;
                        node.QuocTich = thayThe.QuocTich;
                        node.NgaySinh = thayThe.NgaySinh;
                        node.anh = thayThe.anh;

                        // Sau khi sao chép, xóa node thay thế (là node nhỏ nhất ở nhánh phải)
                        node.Right = XoaTaiKhoanRec(node.Right, thayThe.ID);
                    }
                }

                return node;
            }

            private TreeNode TimNodeNhoNhat(TreeNode node)
            {
                while (node.Left != null)
                {
                    node = node.Left;
                }
                return node;
            }
        }
    }
}
