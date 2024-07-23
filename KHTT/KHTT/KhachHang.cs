using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace KHTT
{
    public partial class KhachHang : Form
    {
        private IMongoCollection<BsonDocument> collection;

        public KhachHang()
        {
            InitializeComponent();

            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("QL_KhachHangThanThiet");
            collection = database.GetCollection<BsonDocument>("KhachHang");

            tbl_KH.Columns.Add("MaKH", "Mã KH");
            tbl_KH.Columns.Add("HoTen", "Họ và Tên");
            tbl_KH.Columns.Add("SDT", "Số Điện Thoại");
            tbl_KH.Columns.Add("NgaySinh", "Ngày Sinh");
            tbl_KH.Columns.Add("GioiTinh", "Giới Tính");
            tbl_KH.Columns.Add("DiaChi", "Địa Chỉ");

            LoadData();
        }

        private void LoadData()
        {
            tbl_KH.Rows.Clear();
            var documents = collection.Find(new BsonDocument()).ToList();
            foreach (var document in documents)
            {
                string maKH = document.GetValue("MaKH").ToString();
                string hoTen = document.GetValue("HoTen").ToString();
                string sdt = document.GetValue("SDT").ToString();
                string ngaySinh = document.GetValue("NgaySinh").ToString();
                string gioiTinh = document.GetValue("GioiTinh").ToString();
                string diaChi = document.GetValue("DiaChi").ToString();

                tbl_KH.Rows.Add(maKH, hoTen, sdt, ngaySinh, gioiTinh, diaChi);
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {


            // Xóa giá trị trên các TextBox và RadioButton
            txt_maKH.Clear();
            txt_tenKH.Clear();
            txt_sdt.Clear();
            dateTimePickerNgaySinh.Value = DateTime.Now;
            txt_diaChi.Clear();
            radio_Nam.Checked = false;
            radio_Nu.Checked = false;

            // Cập nhật lại dữ liệu trong DataGridView
            LoadData();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("MaKH", txt_maKH.Text);
           
               
                collection.DeleteOne(filter);

                // Xóa giá trị trên các TextBox và RadioButton
                txt_maKH.Clear();
                txt_tenKH.Clear();
                txt_sdt.Clear();
                dateTimePickerNgaySinh.Value = DateTime.Now;
                txt_diaChi.Clear();
                radio_Nam.Checked = false;
                radio_Nu.Checked = false;

                // Cập nhật lại dữ liệu trong DataGridView
                LoadData();
            
            

        }

        private void tbl_khachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = tbl_KH.Rows[e.RowIndex];
                txt_maKH.Text = row.Cells["MaKH"].Value.ToString();
                txt_tenKH.Text = row.Cells["HoTen"].Value.ToString();
                txt_sdt.Text = row.Cells["SDT"].Value.ToString();
                dateTimePickerNgaySinh.Text = row.Cells["NgaySinh"].Value.ToString();
                string gioiTinh = row.Cells["GioiTinh"].Value.ToString();
                txt_diaChi.Text = row.Cells["DiaChi"].Value.ToString();

                // Đặt giới tính trở lại cho RadioButton tương ứng
                if (gioiTinh == "Nam")
                {
                    radio_Nam.Checked = true;
                }
                else if (gioiTinh == "Nữ")
                {
                    radio_Nu.Checked = true;
                }
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            var query = new QueryDocument("MaKH", txt_maKH.Text);


          
               if (string.IsNullOrWhiteSpace(txt_tenKH.Text) ||
               string.IsNullOrWhiteSpace(txt_sdt.Text) ||
               string.IsNullOrWhiteSpace(txt_diaChi.Text) ||
               (!radio_Nu.Checked && !radio_Nam.Checked))
                {
                    // Show the error message
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            else
            {


                // Lấy giới tính từ RadioButton
                string gioiTinh = "";
                if (radio_Nam.Checked)
                {
                    gioiTinh = "Nam";
                }
                else if (radio_Nu.Checked)
                {
                    gioiTinh = "Nữ";
                }

                string ngaySinh = dateTimePickerNgaySinh.Value.ToString("yyyy/MM/dd");

                BsonDocument document = new BsonDocument()
        {
            { "MaKH", txt_maKH.Text },
            { "HoTen", txt_tenKH.Text },
            { "SDT", txt_sdt.Text },
            { "NgaySinh", ngaySinh },
            { "GioiTinh", gioiTinh },
            { "DiaChi", txt_diaChi.Text }
        };

                var update = new UpdateDocument { { "$set", document } };

                collection.UpdateOne(query, update);

                // Cập nhật lại DataGridView sau khi sửa dữ liệu
                LoadData();

                // Xóa giá trị trên các TextBox và RadioButton
                txt_maKH.Clear();
                txt_tenKH.Clear();
                txt_sdt.Clear();
                dateTimePickerNgaySinh.Value = DateTime.Now;
                txt_diaChi.Clear();
                radio_Nam.Checked = false;
                radio_Nu.Checked = false;
            }

            
            
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {


                if (string.IsNullOrWhiteSpace(txt_tenKH.Text) ||
                string.IsNullOrWhiteSpace(txt_sdt.Text) ||
                string.IsNullOrWhiteSpace(txt_diaChi.Text) ||
                (!radio_Nu.Checked && !radio_Nam.Checked))
            {
                // Show the error message
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Tạo mã KH tự động
                var lastDocument = collection.Find(new BsonDocument()).SortByDescending(x => x["MaKH"]).FirstOrDefault();
                int nextMaKH = 1;

                if (lastDocument != null)
                {
                    string lastMaKH = lastDocument.GetValue("MaKH").ToString();
                    if (int.TryParse(lastMaKH.Substring(2), out int lastNumber))
                    {
                        nextMaKH = lastNumber + 1;
                    }
                }

                string newMaKH = "KH" + nextMaKH.ToString("D3");


                // Lấy giới tính từ RadioButton
                string gioiTinh = "";

                if (radio_Nam.Checked)
                {
                    gioiTinh = "Nam";
                }
                else if (radio_Nu.Checked)
                {
                    gioiTinh = "Nữ";
                }
                String ngaySinh = dateTimePickerNgaySinh.Value.ToString("yyyy/MM/dd");


                BsonDocument document = new BsonDocument()
               {
                    { "MaKH", newMaKH },
                    { "HoTen", txt_tenKH.Text },
                    { "SDT", txt_sdt.Text },
                    { "NgaySinh", ngaySinh },
                    { "GioiTinh", gioiTinh },
                    { "DiaChi", txt_diaChi.Text }
                  };

                collection.InsertOne(document);

                // Xóa giá trị trên các TextBox và RadioButton
                txt_tenKH.Clear();
                txt_sdt.Clear();
                dateTimePickerNgaySinh.Value = DateTime.Now;
                txt_diaChi.Clear();
                radio_Nam.Checked = false;
                radio_Nu.Checked = false;

                // Cập nhật lại dữ liệu trong DataGridView
                LoadData();
            }

            

            


        }


        private void txt_sdt_TextChanged(object sender, EventArgs e)
        {
            // Xóa tất cả khoảng trắng trong số điện thoại (nếu có)
            string phoneNumber = txt_sdt.Text.Replace(" ", "");

            // Giới hạn độ dài của số điện thoại thành 10 số
            if (phoneNumber.Length > 10)
            {
                phoneNumber = phoneNumber.Substring(0, 10);
            }

            txt_sdt.Text = phoneNumber; // Cập nhật TextBox

            // Di chuyển con trỏ về cuối TextBox để ngăn người dùng nhập thêm
            txt_sdt.SelectionStart = txt_sdt.TextLength;

            // Đảm bảo hiển thị đúng định dạng
            errorProvider.SetError(txt_sdt, "");

            if (txt_sdt.Text.Length == 10)
            {
                errorProvider.SetError(txt_sdt, ""); // Xóa thông báo lỗi nếu có
            }
            else
            {
                errorProvider.SetError(txt_sdt, "Số điện thoại phải có đúng 10 số"); // Hiển thị thông báo lỗi
            }
        }

        private void txt_sdt_KeyPress(object sender, KeyPressEventArgs e)
        {

            // Kiểm tra xem ký tự nhập vào có phải là số (0-9) hoặc Backspace không
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Loại bỏ ký tự không hợp lệ
            }
        }

        private void timKiemTheoChuDe(string textSearch, string attribute)
        {
            if (string.IsNullOrEmpty(textSearch))
            {
                // Nếu TextBox tìm kiếm trống, hiển thị tất cả dữ liệu
                LoadData();
            }
            else
            {
                // Tạo một bộ lọc để tìm theo tên khách hàng
                var filter = Builders<BsonDocument>.Filter.Regex(attribute, new BsonRegularExpression(textSearch, "i")); // "i" để tìm kiếm không phân biệt chữ hoa chữ thường

                // Thực hiện truy vấn tìm kiếm
                var searchResults = collection.Find(filter).ToList();

                // Hiển thị kết quả tìm kiếm trong DataGridView
                tbl_KH.Rows.Clear();
                foreach (var result in searchResults)
                {
                    string maKH = result.GetValue("MaKH").ToString();
                    string hoTen = result.GetValue("HoTen").ToString();
                    string sdt = result.GetValue("SDT").ToString();
                    string ngaySinh = result.GetValue("NgaySinh").ToString();
                    string gioiTinh = result.GetValue("GioiTinh").ToString();
                    string diaChi = result.GetValue("DiaChi").ToString();

                    tbl_KH.Rows.Add(maKH, hoTen, sdt, ngaySinh, gioiTinh, diaChi);
                }
            }
        }

        private void btn_tim_Click(object sender, EventArgs e)
        {
            string textSearch = txt_timKiem.Text.Trim();

            if (rdi_TimTen.Checked)
            {
                timKiemTheoChuDe(textSearch, "HoTen");
            }
            else if (rdi_timSDT.Checked)
            {
                timKiemTheoChuDe(textSearch, "SDT");
            }
            else if (rdi_TimNgaySinh.Checked)
            {
                timKiemTheoChuDe(textSearch, "NgaySinh");
            }
            else if (rdi_timDiaChi.Checked)
            {
                timKiemTheoChuDe(textSearch, "DiaChi");
            }
            else
            {
                timKiemTheoChuDe(textSearch, "GioiTinh");
            }
        }


        private void rdb_tenKH_Click(object sender, EventArgs e)
        {
            if (rdi_TimTen.Checked)
            {
                lb_tim.Text = "Nhập tên khách hàng:";

            }
            else if (rdi_timSDT.Checked)
            {
                lb_tim.Text = "Nhập số điện thoại:";
            }
            else if (rdi_TimNgaySinh.Checked)
            {
                lb_tim.Text = "Nhập ngày sinh:";
            }
            else if (rdi_timDiaChi.Checked)
            {
                lb_tim.Text = "Nhập địa chỉ:";
            }
            else
            {
                lb_tim.Text = "Nhập giới tính:";
            }
        }



        private void txt_tenKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra xem ký tự nhập vào có phải là ký tự chữ không
            //if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            //{
            //    // Nếu không phải là ký tự chữ hoặc ký tự điều khiển (như Backspace), hủy sự kiện
            //    e.Handled = true;
            //}
        }
    }
}
