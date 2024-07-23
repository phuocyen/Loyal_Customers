using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Amazon.Runtime.Documents;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace KHTT
{
    public partial class SanPham : Form
    {
        private IMongoCollection<BsonDocument> collection;

        public SanPham()
        {
            InitializeComponent();         
        }

        private void SanPham_Load(object sender, EventArgs e)
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("QL_KhachHangThanThiet");
            collection = database.GetCollection<BsonDocument>("SanPham");

            dgv_sanPham.Columns.Add("MaSP", "Mã SP");
            dgv_sanPham.Columns.Add("TenSP", "Tên SP");
            dgv_sanPham.Columns.Add("DonViTinh", "Đơn vị tính");
            dgv_sanPham.Columns.Add("SoLuongTon", "Số lượng tồn");
            dgv_sanPham.Columns.Add("DonGia", "Đơn giá");

            LoadData();
        }

        private void LoadData()
        {
            dgv_sanPham.Rows.Clear();
            var documents = collection.Find(new BsonDocument()).ToList();
            foreach (var document in documents)
            {
                string maSP = document.GetValue("MaSP").ToString();
                string tenSP = document.GetValue("TenSP").ToString();
                string donViTinh = document.GetValue("DonViTinh").ToString();
                int soLuongTon = document.Contains("SoLuongTon") ? int.Parse(document.GetValue("SoLuongTon").ToString()) : 0;
                int donGia = document.Contains("DonGia") ? int.Parse(document.GetValue("DonGia").ToString()) : 0;

                dgv_sanPham.Rows.Add(maSP, tenSP, donViTinh, soLuongTon, donGia);
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
          
            // Xóa giá trị trên các TextBox
            txt_maSp.Clear();
            txt_tenSp.Clear();
            txt_dvt.Clear();
            txt_dongGia.Clear();
            txt_soLuong.Clear();

            txt_tenSp.Focus();

            // Cập nhật lại dữ liệu trong DataGridView
            LoadData();
        }
    

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn Muốn Xóa Sản Phẩm:  " + txt_tenSp.Text + " có Mã: " + txt_maSp.Text + " Không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                var filter = Builders<BsonDocument>.Filter.Eq("MaSP", txt_maSp.Text);
                collection.DeleteOne(filter);

                txt_maSp.Clear();
                txt_tenSp.Clear();
                txt_dvt.Clear();
                txt_dongGia.Clear();
                txt_soLuong.Clear();

                txt_maSp.Focus();
                LoadData();
                MessageBox.Show("Xóa Nhân Viên Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgv_sanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_sanPham.Rows[e.RowIndex];
                txt_maSp.Text = row.Cells["MaSP"].Value.ToString();
                txt_tenSp.Text = row.Cells["TenSP"].Value.ToString();
                txt_dvt.Text = row.Cells["DonViTinh"].Value.ToString();
                txt_dongGia.Text = row.Cells["DonGia"].Value.ToString();
                txt_soLuong.Text = row.Cells["SoLuongTon"].Value.ToString();
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn Muốn Sửa Sản Phẩm:  " + txt_tenSp.Text + " có Mã: " + txt_maSp.Text + " Không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                var query = new QueryDocument("MaSP", txt_maSp.Text);

                BsonDocument document = new BsonDocument()
                {
                    { "MaSP", txt_maSp.Text },
                    { "TenSP", txt_tenSp.Text },
                    { "DonViTinh", txt_dvt.Text },
                    { "SoLuongTon", txt_soLuong.Text },
                    { "DonGia", txt_dongGia.Text }
                };

                var update = new UpdateDocument { { "$set", document } };

                collection.UpdateOne(query, update);

                
                LoadData();

                txt_maSp.Clear();
                txt_tenSp.Clear();
                txt_dvt.Clear();
                txt_dongGia.Clear();
                txt_soLuong.Clear();

                txt_maSp.Focus();
                MessageBox.Show("Sửa Sản Phẩm Có Mã " + txt_tenSp.Text + " Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }


        private void btn_luu_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn Muốn Thêm Sản Phẩm " + txt_tenSp.Text + " Không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                var lastDocument = collection.Find(new BsonDocument()).SortByDescending(x => x["MaSP"]).FirstOrDefault();
                int nextMaSP = 1;

                if (lastDocument != null)
                {
                    string lastMaSP = lastDocument.GetValue("MaSP").ToString();
                    if (int.TryParse(lastMaSP.Substring(2), out int lastNumber))
                    {
                        nextMaSP = lastNumber + 1;
                    }
                }

                string newMaSP = "SP" + nextMaSP.ToString("D3");
                txt_maSp.Text = newMaSP;

                BsonDocument document = new BsonDocument()
                {
                    { "MaSP", newMaSP },
                    { "TenSP", txt_tenSp.Text },
                    { "DonViTinh", txt_dvt.Text },
                    { "SoLuongTon", txt_soLuong.Text },
                    { "DonGia", txt_dongGia.Text }
                };

                collection.InsertOne(document);

                txt_maSp.Clear();
                txt_tenSp.Clear();
                txt_dvt.Clear();
                txt_dongGia.Clear();
                txt_soLuong.Clear();
                txt_tenSp.Focus();
               
                LoadData();
                MessageBox.Show("Thêm Nhân Viên Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_timKiem_Click(object sender, EventArgs e)
        {
            string textSearch = txt_timKiem.Text.Trim();
            if (string.IsNullOrEmpty(textSearch))
            {
                LoadData();
            }
            else
            {              
                var filter = Builders<BsonDocument>.Filter.Regex("TenSP", new BsonRegularExpression(textSearch, "i"));
                var searchResults = collection.Find(filter).ToList();

                dgv_sanPham.Rows.Clear();
                foreach (var result in searchResults)
                {
                    string maSP = result.GetValue("MaSP").ToString();
                    string tenSP = result.GetValue("TenSP").ToString();
                    string donViTinh = result.GetValue("DonViTinh").ToString();
                    int soLuongTon = result.Contains("SoLuongTon") ? int.Parse(result.GetValue("SoLuongTon").ToString()) : 0;
                    int donGia = result.Contains("DonGia") ? int.Parse(result.GetValue("DonGia").ToString()) : 0;

                    dgv_sanPham.Rows.Add(maSP, tenSP, donViTinh, soLuongTon, donGia);
                }
            }
        }

        private void sapXepTheoChuDe(string name, int i)
        {
            dgv_sanPham.Rows.Clear();
            var documents = collection.Find(new BsonDocument()).Sort(new BsonDocument(name, i)).ToList();
            foreach (var document in documents)
            {
                string maSP = document.GetValue("MaSP").ToString();
                string tenSP = document.GetValue("TenSP").ToString();
                string donViTinh = document.GetValue("DonViTinh").ToString();
                int soLuongTon = document.Contains("SoLuongTon") ? int.Parse(document.GetValue("SoLuongTon").ToString()) : 0;
                int donGia = document.Contains("DonGia") ? int.Parse(document.GetValue("DonGia").ToString()) : 0;

                dgv_sanPham.Rows.Add(maSP, tenSP, donViTinh, soLuongTon, donGia);
            }
        }

        private void cbo_sapXep_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = cbo_sapXep.SelectedItem.ToString();
            if (rdb_tang.Checked)
            {          
                if (item.Equals("Đơn giá"))
                {
                    sapXepTheoChuDe("DonGia", 1);
                }
                else if (item.Equals("Số lượng tồn"))
                {
                    sapXepTheoChuDe("SoLuongTon", 1);
                }
            }
            else if (rdb_giam.Checked)
            {            
                if (item.Equals("Đơn giá"))
                {
                    sapXepTheoChuDe("DonGia", -1);
                }
                else if (item.Equals("Số lượng tồn"))
                {
                    sapXepTheoChuDe("SoLuongTon", -1);
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            if (rdb_tang.Checked)
            {
                cbo_sapXep.SelectedIndex = -1;
            }
            else
            {
                cbo_sapXep.SelectedIndex = -1;
            }
        }

        private void dgv_sanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

