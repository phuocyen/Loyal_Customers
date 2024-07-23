using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KHTT
{
    public partial class danhgia : UserControl
    {
        public danhgia()
        {
            InitializeComponent();
        }

        private void danhgia_Load(object sender, EventArgs e)
        {
            panelDanhGia.Visible = true;
            txt_nhanxet.Enabled = false;
        }
        public void HienThiDanhGia(float diemDanhGia,string khachhang,string nhanxet)
        {
            label_khachhang.Text = "";
            txt_nhanxet.Text = "Nhận xét: "+nhanxet;
            label_khachhang.Text = khachhang;
            int soNguyen = (int)Math.Floor(diemDanhGia);
            float phanDu = diemDanhGia - soNguyen;
            if (soNguyen > 5) soNguyen = 5;
            panelDanhGia.Controls.Clear();
            for (int i = 0; i < soNguyen; i++)
            {
                PictureBox sao = new PictureBox();
                sao.Image = Properties.Resources.star;
                sao.Size = new Size(16, 16);
                sao.Location = new Point(50 * i, 0);
                panelDanhGia.Controls.Add(sao);
            }
            if (phanDu > 0)
            {
                PictureBox nuaSao = new PictureBox();
                nuaSao.Image = Properties.Resources.nuasao;
                nuaSao.Size = new Size(16, 16);
                nuaSao.Location = new Point(50 * soNguyen, 0);
                panelDanhGia.Controls.Add(nuaSao);
            }
        }
    }
}
