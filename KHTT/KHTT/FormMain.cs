using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KHTT
{
    public partial class FormMain : Form
    {
        private IMongoCollection<BsonDocument> collection;
        public string user, password;
        public FormMain()
        {
           
        }
        public FormMain(string us, string pas)
        {
            InitializeComponent();
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("QL_KhachHangThanThiet");
            collection = database.GetCollection<BsonDocument>("NhanVien");
            khachhang();
            try
            {
                var filter = Builders<BsonDocument>.Filter.Eq("User", us);
                var document = collection.Find(filter).FirstOrDefault();

                if (document != null)
                {
                    var storedPassword = document.GetValue("Pass").AsString;
                    if (string.Equals(pas, storedPassword))
                    {
                        lab_tentaikhoan.Text = document.GetValue("TenNV").AsString;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void FormMain_Load1(object sender, EventArgs e)
        {
           
        
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

         
        }



        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }
        public void loadthongtin()
        {
           
          
        }

        private void đánhGiáToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            lab_tieude.Text = "Đánh Giá";
            panel_show.Controls.Clear();
            form_danhgia frm_dg=new form_danhgia(); 
            frm_dg.TopLevel = false;
            frm_dg.FormBorderStyle = FormBorderStyle.None;
            frm_dg.Size = panel_show.Size;
            panel_show.Controls.Add(frm_dg);
            frm_dg.Parent = panel_show;
            frm_dg.Show();
        }




        private void btn_nhanvien_Click(object sender, EventArgs e)
        {
            lab_tieude.Text = "Nhân Viên";
            panel_show.Controls.Clear();
            NhanVien sp = new NhanVien();
            sp.TopLevel = false;
            sp.FormBorderStyle = FormBorderStyle.None;
            sp.Size = panel_show.Size;
            panel_show.Controls.Add(sp);
            sp.Parent = panel_show;
            sp.Show();
        }

        private void btn_khachhang_Click_1(object sender, EventArgs e)
        {
            khachhang();
        }
        public void khachhang()
        {
            panel_show.Controls.Clear();
            lab_tieude.Text = "Khách Hàng";
            KhachHang kh = new KhachHang();
            kh.TopLevel = false;
            kh.FormBorderStyle = FormBorderStyle.None;
            kh.Size = panel_show.Size;
            panel_show.Controls.Add(kh);
            kh.Parent = panel_show;
            kh.Show();
        }
        private void btn_sanpham_Click_1(object sender, EventArgs e)
        {
            panel_show.Controls.Clear();
            lab_tieude.Text = "Sản Phẩm";
            SanPham sp = new SanPham();
            sp.TopLevel = false;
            sp.FormBorderStyle = FormBorderStyle.None;
            sp.Size = panel_show.Size;
            panel_show.Controls.Add(sp);
            sp.Parent = panel_show;
            sp.Show();
        }

        private void btn_lichsumuahang_Click_1(object sender, EventArgs e)
        {
            panel_show.Controls.Clear();
            lab_tieude.Text = "Lịch Sử Mua";
            LichSuMuaHang ls = new LichSuMuaHang();
            ls.TopLevel = false;
            ls.FormBorderStyle = FormBorderStyle.None;
            ls.Size = panel_show.Size;
            panel_show.Controls.Add(ls);
            ls.Parent = panel_show;
            ls.Show();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result= MessageBox.Show("Bạn Muốn Đóng Ứng Dụng Chứ ?", "Thông Báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void thongkeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel_show.Controls.Clear();
            lab_tieude.Text = "Thống Kê";
            ThongKe ls = new ThongKe();
            ls.TopLevel = false;
            ls.FormBorderStyle = FormBorderStyle.None;
            ls.Size = panel_show.Size;
            panel_show.Controls.Add(ls);
            ls.Parent = panel_show;
            ls.Show();
        }
    }
}
