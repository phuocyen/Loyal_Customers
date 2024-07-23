using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Windows.Forms;
using OfficeOpenXml;
using System.IO;

namespace KHTT
{
    public partial class ThongKe : Form
    {
   
        private IMongoCollection<BsonDocument> khachHangCollection;
        private IMongoCollection<BsonDocument> hoaDonCollection;

        public ThongKe()
        {
            InitializeComponent();

            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("QL_KhachHangThanThiet");

            khachHangCollection = database.GetCollection<BsonDocument>("KhachHang");
            hoaDonCollection = database.GetCollection<BsonDocument>("HoaDon");

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
            var documents = khachHangCollection.Find(new BsonDocument()).ToList();
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

        private void tbl_KH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem đã chọn dòng hợp lệ chưa (chẳng hạn, không phải dòng header)
            if (e.RowIndex >= 0)
            {
                // Lấy số điện thoại từ cột "SDT" trong dòng được chọn
                string sdt = tbl_KH.Rows[e.RowIndex].Cells["SDT"].Value.ToString();

                // Truy vấn cơ sở dữ liệu MongoDB để tìm hoá đơn trong collection "HoaDon" dựa trên số điện thoại
                var filterHoaDon = Builders<BsonDocument>.Filter.Eq("KhachHang.SDT", sdt);
                var hoaDonList = hoaDonCollection.Find(filterHoaDon).ToList();

                if (hoaDonList.Count > 0)
                {
                    // Lấy thông tin mã thẻ và hạng thẻ từ hoá đơn đầu tiên (hoặc theo logic của bạn)
                    var firstHoaDon = hoaDonList[0];
                    string maThe = firstHoaDon["TheThanhVien"]["MaThe"].AsString;
                    string hangThe = firstHoaDon["TheThanhVien"]["HangThe"].AsString;

                    // Hiển thị thông tin lên TextBox
                    txt_maThe.Text = maThe;
                    txt_HT.Text = hangThe;

                    // Đếm số lượng hoá đơn
                    int soLuongHoaDon = hoaDonList.Count;

                    // Hiển thị kết quả lên TextBox
                    txt_soLanMua.Text = soLuongHoaDon.ToString();

                    int tongSoLuongSanPham = 0;
                    int tongGiaTri = 0;
                    double tongDiemDanhGia = 0;

                    // Duyệt qua danh sách các hoá đơn và tính tổng số lượng sản phẩm mua, tổng giá trị và tổng điểm đánh giá
                    foreach (var hoaDon in hoaDonList)
                    {
                        var sanPhamList = hoaDon["SanPham"].AsBsonArray;
                        foreach (var sanPham in sanPhamList)
                        {
                            int soLuong = sanPham["SoLuong"].AsInt32;
                            int donGia = sanPham["DonGia"].AsInt32;
                            tongSoLuongSanPham += soLuong;
                            tongGiaTri += soLuong * donGia;
                        }

                        double diemDanhGia = 0.0; // Giá trị mặc định là 0.0

                        if (hoaDon["DanhGia"]["ThangDiem"].IsDouble)
                        {
                            diemDanhGia = hoaDon["DanhGia"]["ThangDiem"].AsDouble;
                        }
                        else if (hoaDon["DanhGia"]["ThangDiem"].IsInt32)
                        {
                            diemDanhGia = (double)hoaDon["DanhGia"]["ThangDiem"].AsInt32;
                        }

                        tongDiemDanhGia += diemDanhGia;
                    }

                    // Tính điểm trung bình đánh giá
                    double diemTrungBinh = tongDiemDanhGia / soLuongHoaDon;

                    // Hiển thị kết quả tổng số lượng sản phẩm, tổng giá trị và điểm trung bình lên TextBox
                    txt_tongSoSPDM.Text = tongSoLuongSanPham.ToString();
                    txt_tongTien.Text = tongGiaTri.ToString();
                    txt_tbDiem.Text = diemTrungBinh.ToString("N2"); // Hiển thị điểm trung bình với 2 chữ số sau dấu thập phân.
                }
                else
                {
                    // Xử lý trường hợp không tìm thấy thông tin hoá đơn.
                    MessageBox.Show("Không tìm thấy hoá đơn cho khách hàng này.");
                }
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
                var searchResults = khachHangCollection.Find(filter).ToList();

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


        public void cleartt()
        {
            txt_HT.Clear();
            txt_maThe.Clear();
            txt_soLanMua.Clear();
            txt_tongSoSPDM.Clear();
            txt_tongTien.Clear();
            txt_tbDiem.Clear();
        }



        private void btn_tim_Click(object sender, EventArgs e)
        {

           

            string textSearch = txt_timKiem.Text.Trim();

            if (rdi_TimTen.Checked)
            {
                timKiemTheoChuDe(textSearch, "HoTen");
                cleartt();
            }
            else if (rdi_timSDT.Checked)
            {
                timKiemTheoChuDe(textSearch, "SDT");
                cleartt();
            }
            else if (rdi_TimNgaySinh.Checked)
            {
                timKiemTheoChuDe(textSearch, "NgaySinh");
                cleartt();
            }
            else if (rdi_timDiaChi.Checked)
            {
                timKiemTheoChuDe(textSearch, "DiaChi");
                cleartt();
            }
            else
            {
                timKiemTheoChuDe(textSearch, "GioiTinh");
                cleartt();
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
       



    private void btn_xuat_file_execl_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            sfd.Filter = "Excel Files | *.xlsx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                FileInfo file = new FileInfo(sfd.FileName);

                using (ExcelPackage package = new ExcelPackage(file))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");

                    // Bắt đầu từ hàng 1, cột 1
                    int rowStart = 1;
                    int colStart = 1;

                    // Tiêu đề cột
                    for (int i = 0; i < tbl_KH.Columns.Count; i++)
                    {
                        worksheet.Cells[rowStart, colStart + i].Value = tbl_KH.Columns[i].HeaderText;
                    }

                    // Dữ liệu
                    for (int i = 0; i < tbl_KH.Rows.Count; i++)
                    {
                        if (tbl_KH.Rows[i] != null)
                        {
                            for (int j = 0; j < tbl_KH.Columns.Count; j++)
                            {
                                if (tbl_KH.Rows[i].Cells != null && j < tbl_KH.Rows[i].Cells.Count)
                                {
                                    worksheet.Cells[rowStart + 1 + i, colStart + j].Value = tbl_KH.Rows[i].Cells[j].Value?.ToString();
                                }
                                else
                                {
                                    MessageBox.Show($"tbl_KH.Rows[{i}].Cells[{j}] is null or out of range");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show($"tbl_KH.Rows[{i}] is null");
                        }
                    }


                    package.Save();
                }

                MessageBox.Show("Xuất Excel thành công!");
            }
        }
    }
}
