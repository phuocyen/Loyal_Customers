using Amazon.Runtime.Documents;
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
    public partial class NhanVien : Form
    {
        private IMongoCollection<BsonDocument> collection;

        public NhanVien()
        {
            InitializeComponent();            
        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("QL_KhachHangThanThiet");
            collection = database.GetCollection<BsonDocument>("NhanVien");

            dgv_nhanvien.Columns.Add("MaNV", "Mã NV");
            dgv_nhanvien.Columns.Add("TenNV", "Tên NV");
            dgv_nhanvien.Columns.Add("ChucVu", "Chức vụ");
            dgv_nhanvien.Columns.Add("User", "Tài khoản");
            dgv_nhanvien.Columns.Add("Pass", "Mật khẩu");
            dgv_nhanvien.Columns.Add("SoDT", "SDT");
            dgv_nhanvien.Columns.Add("DiaChi", "Địa chỉ");

            LoadData();          
        }

        private void LoadData()
        {
            dgv_nhanvien.Rows.Clear();
            var documents = collection.Find(new BsonDocument()).ToList();
            foreach (var document in documents)
            {
                string maNV = document.GetValue("MaNV").ToString();
                string tenNV = document.GetValue("TenNV").ToString();
                string chucVu = document.GetValue("ChucVu").ToString();
                string user = document.GetValue("User").ToString();
                string pass = document.GetValue("Pass").ToString();
                string sdt = document.GetValue("SoDT").ToString();
                string diaChi = document.GetValue("DiaChi").ToString();


                dgv_nhanvien.Rows.Add(maNV, tenNV, chucVu, user, pass, sdt, diaChi);
            }
        }

        private void dgv_nhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_nhanvien.Rows[e.RowIndex];
                txt_maNV.Text = row.Cells["MaNV"].Value.ToString();
                txt_tenNV.Text = row.Cells["TenNV"].Value.ToString();
                txt_chucVu.Text = row.Cells["ChucVu"].Value.ToString();
                txt_tenTK.Text = row.Cells["User"].Value.ToString();
                txt_matKhau.Text = row.Cells["Pass"].Value.ToString();
                txt_sdt.Text = row.Cells["SoDT"].Value.ToString();
                txt_diaChi.Text = row.Cells["DiaChi"].Value.ToString();
            }
        }

        private void timKiemTheoChuDe(string textSearch, string attribute)
        {
            if (string.IsNullOrEmpty(textSearch))
            {                
                LoadData();
            }
            else
            {
                // Tạo một bộ lọc để tìm theo tên khách hàng
                var filter = Builders<BsonDocument>.Filter.Regex(attribute, new BsonRegularExpression(textSearch, "i")); // "i" để tìm kiếm không phân biệt chữ hoa chữ thường               
                var searchResults = collection.Find(filter).ToList();

                dgv_nhanvien.Rows.Clear();
                foreach (var result in searchResults)
                {
                    string maNV = result.GetValue("MaNV").ToString();
                    string tenNV = result.GetValue("TenNV").ToString();
                    string chucVu = result.GetValue("ChucVu").ToString();
                    string user = result.GetValue("User").ToString();
                    string pass = result.GetValue("Pass").ToString();
                    string sdt = result.GetValue("SoDT").ToString();
                    string diaChi = result.GetValue("DiaChi").ToString();


                    dgv_nhanvien.Rows.Add(maNV, tenNV, chucVu, user, pass, sdt, diaChi);
                }
            }
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            string textSearch = txt_timKiem.Text.Trim();

            if (rdb_tenNV.Checked)
            {
                timKiemTheoChuDe(textSearch, "TenNV");
            }
            else if (rdb_sdt.Checked)
            {
                timKiemTheoChuDe(textSearch, "SoDT");
            }
            else if (rdb_chucVu.Checked)
            {
                timKiemTheoChuDe(textSearch, "ChucVu");
            }
            else
            {
                timKiemTheoChuDe(textSearch, "DiaChi");
            }           
        }

        private void rdb_tenNV_Click(object sender, EventArgs e)
        {
            if (rdb_tenNV.Checked)
            {
                lbl_timKiem.Text = "Nhập tên nhân viên:";

            }
            else if (rdb_sdt.Checked)
            {
                lbl_timKiem.Text = "Nhập số điện thoại:";
            }
            else if (rdb_chucVu.Checked)
            {
                lbl_timKiem.Text = "Nhập chức vụ:";
            }
            else
            {
                lbl_timKiem.Text = "Nhập địa chỉ:";
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            txt_maNV.Clear();
            txt_tenNV.Clear();
            txt_chucVu.Clear();
            txt_tenTK.Clear();
            txt_matKhau.Clear();
            txt_sdt.Clear();
            txt_diaChi.Clear();

            txt_tenNV.Focus();
            LoadData();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn Muốn Xóa Nhân Viên:  " + txt_tenNV.Text + " có Mã: " + txt_maNV.Text + " Không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                var filter = Builders<BsonDocument>.Filter.Eq("MaNV", txt_maNV.Text);
                collection.DeleteOne(filter);

                txt_maNV.Clear();
                txt_tenNV.Clear();
                txt_chucVu.Clear();
                txt_tenTK.Clear();
                txt_matKhau.Clear();
                txt_sdt.Clear();
                txt_diaChi.Clear();

                txt_tenNV.Focus();
                LoadData();
                MessageBox.Show("Xóa Nhân Viên Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }           
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn Muốn Sửa Nhân Viên:  " + txt_tenNV.Text + " có Mã: " + txt_maNV.Text + " Không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                var query = new QueryDocument("MaNV", txt_maNV.Text);
                if (string.IsNullOrWhiteSpace(txt_tenNV.Text) || string.IsNullOrWhiteSpace(txt_chucVu.Text) || string.IsNullOrWhiteSpace(txt_tenTK.Text) || string.IsNullOrWhiteSpace(txt_matKhau.Text) ||
                   string.IsNullOrWhiteSpace(txt_sdt.Text) ||
                   string.IsNullOrWhiteSpace(txt_diaChi.Text))
                {
                    MessageBox.Show("Vui Lòng Nhập Đầy Đủ Thông Tin!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }   
                else
                {
                    BsonDocument document = new BsonDocument()
                    {
                        { "MaNV", txt_maNV.Text },
                        { "TenNV", txt_tenNV.Text },
                        { "ChucVu", txt_chucVu.Text },
                        { "User", txt_tenTK.Text },
                        { "Pass", txt_matKhau.Text },
                        { "SoDT", txt_sdt.Text },
                        { "DiaChi", txt_diaChi.Text }
                    };

                    var update = new UpdateDocument { { "$set", document } };

                    collection.UpdateOne(query, update);

                    txt_maNV.Clear();
                    txt_tenNV.Clear();
                    txt_chucVu.Clear();
                    txt_tenTK.Clear();
                    txt_matKhau.Clear();
                    txt_sdt.Clear();
                    txt_diaChi.Clear();

                    txt_tenNV.Focus();
                    LoadData();

                    MessageBox.Show("Sửa Nhân Viên Có Mã " + txt_tenNV.Text + " Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }             
            }
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn Muốn Thêm Nhân Viên " + txt_tenNV.Text + " Không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                var lastDocument = collection.Find(new BsonDocument()).SortByDescending(x => x["MaNV"]).FirstOrDefault();
                int nextMaNV = 1;

                if (lastDocument != null)
                {
                    string lastMaNV = lastDocument.GetValue("MaNV").ToString();
                    if (int.TryParse(lastMaNV.Substring(2), out int lastNumber))
                    {
                        nextMaNV = lastNumber + 1;
                    }
                }

                string newMaNV = "NV" + nextMaNV.ToString("D3");
                txt_maNV.Text = newMaNV;

                BsonDocument document = new BsonDocument()
            {
                { "MaNV", newMaNV },
                { "TenNV", txt_tenNV.Text },
                { "ChucVu", txt_chucVu.Text },
                { "User", txt_tenTK.Text },
                { "Pass", txt_matKhau.Text },
                { "SoDT", txt_sdt.Text },
                { "DiaChi", txt_diaChi.Text }
            };

                collection.InsertOne(document);

                txt_maNV.Clear();
                txt_tenNV.Clear();
                txt_chucVu.Clear();
                txt_tenTK.Clear();
                txt_matKhau.Clear();
                txt_sdt.Clear();
                txt_diaChi.Clear();

                txt_tenNV.Focus();

                LoadData();
                MessageBox.Show("Thêm Nhân Viên Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
