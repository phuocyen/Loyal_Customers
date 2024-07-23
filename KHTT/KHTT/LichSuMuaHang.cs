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
    public partial class LichSuMuaHang : Form
    {
        private IMongoCollection<BsonDocument> collection;

        public LichSuMuaHang()
        {
            InitializeComponent();
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("QL_KhachHangThanThiet");
            collection = database.GetCollection<BsonDocument>("HoaDon");

            dataHoaDon.Columns.Add("MaDonHang", "Mã HD");
            dataHoaDon.Columns.Add("NgayDat", "Ngày đặt");
            dataHoaDon.Columns.Add("ThanhTien", "Thành tiền");
            dataHoaDon.Columns.Add("HoTen", "Khách hàng");
            dataHoaDon.Columns.Add("MaThe", "Mã thẻ");
            dataHoaDon.Columns.Add("HangThe", "Hạng thẻ");

            dataSP.Columns.Add("MaSP", "Mã SP");
            dataSP.Columns.Add("TenSP", "Tên SP");
            dataSP.Columns.Add("DonViTinh", "Đơn vị tính");
            dataSP.Columns.Add("SoLuong", "Số lượng mua");
            dataSP.Columns.Add("DonGia", "Đơn giá");

            LoadData();

            thongkehoadon();

        }

        private void LoadData()
        {
            dataHoaDon.Rows.Clear();
            var documents = collection.Find(new BsonDocument()).ToList();
            foreach (var document in documents)
            {
                string madh = document.GetValue("MaDonHang").ToString();
                string ngaydat = document.GetValue("NgayDat").ToString();
                int thanhtien = document.Contains("ThanhTien") ? document["ThanhTien"].AsInt32 : 0;
                string hoten = document["KhachHang"]["HoTen"].ToString();
                string mathe = document["TheThanhVien"]["MaThe"].ToString();
                string hangthe = document["TheThanhVien"]["HangThe"].ToString();

                dataHoaDon.Rows.Add(madh, ngaydat, thanhtien, hoten, mathe, hangthe);
            }
        }

        private void LoadDataSP(string maDonHang)
        {
            dataSP.Rows.Clear();

            // Truy vấn cơ sở dữ liệu để lấy danh sách sản phẩm đã mua theo mã đơn hàng
            var filter = Builders<BsonDocument>.Filter.Eq("MaDonHang", maDonHang);
            var document = collection.Find(filter).FirstOrDefault();

            if (document != null)
            {
                int soLuong = 0;
                int donGia = 0;

                if (document != null)
                {
                    var sanPhamList = document.GetValue("SanPham").AsBsonArray;
                    foreach (var sanPham in sanPhamList)
                    {
                        string maSP = sanPham["MaSP"].ToString();
                        string tenSP = sanPham["TenSP"].ToString();
                        string donViTinh = sanPham["DonViTinh"].ToString();

                        if (sanPham.IsBsonDocument)
                        {
                            if (sanPham.AsBsonDocument.Contains("SoLuong"))
                            {
                                soLuong = sanPham.AsBsonDocument["SoLuong"].AsInt32;
                            }

                            if (sanPham.AsBsonDocument.Contains("DonGia"))
                            {
                                donGia = sanPham.AsBsonDocument["DonGia"].AsInt32;
                            }
                        }

                        dataSP.Rows.Add(maSP, tenSP, donViTinh, soLuong, donGia);
                    }
                }

            }


        }


        /// <summary>
        ///Tìm mã kháhc hàng
        /// </summary>
        /// <param name="document"></param>


        private string FindMaKhachHangBySDT(string sdt)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("KhachHang.SDT", sdt);
            var document = collection.Find(filter).FirstOrDefault();
            if (document != null)
            {
                var khachHang = document.GetValue("KhachHang").AsBsonDocument;
                if (khachHang.Contains("MaKH"))
                {
                    var maKhachHang = khachHang["MaKH"].ToString();
                    return maKhachHang;
                }
            }
            return null; // Trả về null nếu không tìm thấy
        }




        //load text box 
        private void LoadDataToTextBoxes(BsonDocument document)
        {
            // Hiển thị thông tin hoá đơn trên các TextBox
            txt_maHoaDon.Text = document.GetValue("MaDonHang").ToString();
            txt_ngayDat.Text = document.GetValue("NgayDat").ToString();
            txt_thanhtien.Text = document.GetValue("ThanhTien").ToString();

            var khachHang = document.GetValue("KhachHang").AsBsonDocument;

            txt_tenKH.Text = khachHang.GetValue("HoTen").ToString();
            txt_sdt.Text = khachHang.GetValue("SDT").ToString();
            txt_diaChi.Text = khachHang.GetValue("DiaChi").ToString();

            var gioiTinh = khachHang.GetValue("GioiTinh").ToString();
            if (gioiTinh == "Nam")
            {
                radio_Nam.Checked = true;
                radio_Nu.Checked = false;
            }
            else if (gioiTinh == "Nữ")
            {
                radio_Nam.Checked = false;
                radio_Nu.Checked = true;
            }

            dateTimePickerNgaySinh.Text = khachHang.GetValue("NgaySinh").ToString();

            // Lấy số điện thoại khách hàng từ thông tin hoá đơn
            string sdtKhachHang = document["KhachHang"]["SDT"].ToString();

            // Tìm mã khách hàng dựa trên số điện thoại và hiển thị lên TextBox
            string maKhachHang = FindMaKhachHangBySDT(sdtKhachHang);
            if (maKhachHang != null)
            {
                // txt_maKH.Text = maKhachHang;
            }
            else
            {
                //  txt_maKH.Text = ""; // Đặt giáa trị rỗng nếu không tìm thấy mã khách hàng
            }
        }




        private void dataHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy mã hoá đơn từ hàng đã chọn
                string maDonHang = dataHoaDon.Rows[e.RowIndex].Cells["MaDonHang"].Value.ToString();

                // Gọi hàm LoadDataSP để hiển thị danh sách sản phẩm đã mua
                LoadDataSP(maDonHang);
            }

            // hiển thị text box

            if (e.RowIndex >= 0)
            {
                // Lấy mã hoá đơn từ hàng đã chọn
                string maDonHang = dataHoaDon.Rows[e.RowIndex].Cells["MaDonHang"].Value.ToString();

                // Truy vấn cơ sở dữ liệu để lấy thông tin hoá đơn theo mã hoá đơn
                var filter = Builders<BsonDocument>.Filter.Eq("MaDonHang", maDonHang);
                var document = collection.Find(filter).FirstOrDefault();

                if (document != null)
                {
                    // Gọi hàm LoadDataToTextBoxes để hiển thị thông tin hoá đơn
                    LoadDataToTextBoxes(document);

                    // Lấy số điện thoại khách hàng từ thông tin hoá đơn
                    string sdtKhachHang = document["KhachHang"]["SDT"].ToString();

                    // Tìm mã khách hàng dựa trên số điện thoại và hiển thị lên TextBox
                    string maKhachHang = FindMaKhachHangBySDT(sdtKhachHang);
                    if (maKhachHang != null)
                    {
                        // txt_maKH.Text = maKhachHang;
                    }
                    else
                    {
                        //txt_maKH.Text = ""; // Đặt giá trị rỗng nếu không tìm thấy mã khách hàng
                    }

                    // Thêm dòng này để in ra giá trị của maKhachHang
                    Console.WriteLine("Mã khách hàng: " + maKhachHang);

                }
            }
            txt_maSp.Clear();
            txt_tenSp.Clear();
            txt_dvt.Clear();
            txt_soLuong.Clear();
            txt_dongGia.Clear();


        }

        private void label5_Click(object sender, EventArgs e)
        {

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
                dataHoaDon.Rows.Clear();
                foreach (var document in searchResults)
                {
                    string madh = document.GetValue("MaDonHang").ToString();
                    string ngaydat = document.GetValue("NgayDat").ToString();
                    int thanhtien = document.Contains("ThanhTien") ? document["ThanhTien"].AsInt32 : 0;
                    string hoten = document["KhachHang"]["HoTen"].ToString();
                    string mathe = document["TheThanhVien"]["MaThe"].ToString();
                    string hangthe = document["TheThanhVien"]["HangThe"].ToString();

                    dataHoaDon.Rows.Add(madh, ngaydat, thanhtien, hoten, mathe, hangthe);
                }

                // Nếu có kết quả tìm kiếm, chọn dòng đầu tiên trong DataGridView và hiển thị thông tin lên các TextBox
                if (searchResults.Count > 0)
                {
                    dataHoaDon.Rows[0].Selected = true;
                    string maDonHang = searchResults[0].GetValue("MaDonHang").ToString();
                    LoadDataToTextBoxes(searchResults[0]);
                    LoadDataSP(maDonHang);
                }
                else
                {
                    // Nếu không tìm thấy kết quả, xóa nội dung các TextBox
                    ClearTextBoxes();
                    dataSP.Rows.Clear();
                }
            } 
            
        }


        public void cleartt()
        {
            txt_maHoaDon.Clear();
            txt_ngayDat.Clear();
            txt_tenKH.Clear();
            txt_diaChi.Clear();
            txt_sdt.Clear();
            
        }



        private void btn_tim_Click(object sender, EventArgs e)
        {



            string textSearch = txt_timKiem.Text.Trim();

            if (rdi_TimTen.Checked)
            {
                timKiemTheoChuDe(textSearch, "KhachHang.HoTen");
            }
            else if (rdi_timND.Checked)
            {
                timKiemTheoChuDe(textSearch, "NgayDat");
            }
            else if (rdi_HangThe.Checked)
            {
                timKiemTheoChuDe(textSearch, "TheThanhVien.HangThe");
            }
        }


        private void rdb_tenKH_Click(object sender, EventArgs e)
        {
            if (rdi_TimTen.Checked)
            {
                lb_tim.Text = "Nhập tên khách hàng:";

            }
            else if (rdi_HangThe.Checked)
            {
                lb_tim.Text = "Nhập hạng thẻ:";
            }
            else if (rdi_timND.Checked)
            {
                lb_tim.Text = "Nhập ngày đặt:";
            }
            
        }


        //private void btn_tim_Click(object sender, EventArgs e)
        //{
        //    string searchName = txt_timKiem.Text.Trim(); // Lấy tên cần tìm từ TextBox

        //    if (!string.IsNullOrEmpty(searchName))
        //    {
        //        // Tạo một bộ lọc để tìm theo tên khách hàng
        //        var filter = Builders<BsonDocument>.Filter.Regex("KhachHang.HoTen", new BsonRegularExpression(searchName, "i")); // "i" để tìm kiếm không phân biệt chữ hoa chữ thường

        //        // Thực hiện truy vấn tìm kiếm
        //        var searchResults = collection.Find(filter).ToList();

        //        // Hiển thị kết quả tìm kiếm trong DataGridView
        //        dataHoaDon.Rows.Clear();
        //        foreach (var document in searchResults)
        //        {
        //            string madh = document.GetValue("MaDonHang").ToString();
        //            string ngaydat = document.GetValue("NgayDat").ToString();
        //            int thanhtien = document.Contains("ThanhTien") ? document["ThanhTien"].AsInt32 : 0;
        //            string hoten = document["KhachHang"]["HoTen"].ToString();
        //            string mathe = document["TheThanhVien"]["MaThe"].ToString();
        //            string hangthe = document["TheThanhVien"]["HangThe"].ToString();

        //            dataHoaDon.Rows.Add(madh, ngaydat, thanhtien, hoten, mathe, hangthe);
        //        }

        //        // Nếu có kết quả tìm kiếm, chọn dòng đầu tiên trong DataGridView và hiển thị thông tin lên các TextBox
        //        if (searchResults.Count > 0)
        //        {
        //            dataHoaDon.Rows[0].Selected = true;
        //            string maDonHang = searchResults[0].GetValue("MaDonHang").ToString();
        //            LoadDataToTextBoxes(searchResults[0]);
        //            LoadDataSP(maDonHang);
        //        }
        //        else
        //        {
        //            // Nếu không tìm thấy kết quả, xóa nội dung các TextBox
        //            ClearTextBoxes();
        //            dataSP.Rows.Clear();
        //        }
        //    }
        //    else
        //    {
        //        // Nếu TextBox tìm kiếm trống, hiển thị tất cả dữ liệu
        //        LoadData();
        //    }
        //}


        private void ClearTextBoxes()
        {
            txt_maHoaDon.Text = "";
            txt_ngayDat.Text = "";
            txt_thanhtien.Text = "";
            txt_tenKH.Text = "";
            txt_sdt.Text = "";
            txt_diaChi.Text = "";
            radio_Nam.Checked = false;
            radio_Nu.Checked = false;
            dateTimePickerNgaySinh.Text = "";

        }



        private void btn_suaHD_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Bạn có muốn cập nhật hoá đơn '"+txt_maHoaDon.Text+"' không?", "Xác nhận", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                // Lấy mã hoá đơn hiện tại từ TextBox
            string maDonHang = txt_maHoaDon.Text;

            // Truy vấn cơ sở dữ liệu để lấy thông tin hoá đơn hiện tại
            var filter = Builders<BsonDocument>.Filter.Eq("MaDonHang", maDonHang);
            var hoaDon = collection.Find(filter).FirstOrDefault();

            if (hoaDon != null)
            {
                // Cập nhật thông tin khách hàng từ các TextBox
                hoaDon["KhachHang"]["HoTen"] = txt_tenKH.Text;
                hoaDon["KhachHang"]["DiaChi"] = txt_diaChi.Text;
                hoaDon["KhachHang"]["SDT"] = txt_sdt.Text;

                // Lấy giá trị ngày tháng năm từ DateTimePicker
                DateTime ngaySinh = dateTimePickerNgaySinh.Value;

                // Chuyển đổi giá trị DateTime thành chuỗi "yyyy-MM-dd"
                string ngaySinhStr = ngaySinh.ToString("yyyy-MM-dd");

                // Lưu chuỗi ngày sinh vào MongoDB
                hoaDon["KhachHang"]["NgaySinh"] = ngaySinhStr;

                // Lấy danh sách sản phẩm từ DataGridView dataSP
                var sanPhamList = new BsonArray();
                foreach (DataGridViewRow row in dataSP.Rows)
                {
                    if (row.Cells["MaSP"].Value != null)
                    {
                        string maSPMoi = row.Cells["MaSP"].Value.ToString();
                        string tenSPMoi = row.Cells["TenSP"].Value.ToString();
                        string donViTinhMoi = row.Cells["DonViTinh"].Value.ToString();
                        int soLuongMuaMoi = Convert.ToInt32(row.Cells["SoLuong"].Value);
                        int donGiaMoi = Convert.ToInt32(row.Cells["DonGia"].Value);

                        var sanPhamMoi = new BsonDocument
                {
                    { "MaSP", maSPMoi },
                    { "TenSP", tenSPMoi },
                    { "DonViTinh", donViTinhMoi },
                    { "SoLuong", soLuongMuaMoi },
                    { "DonGia", donGiaMoi }
                };

                        sanPhamList.Add(sanPhamMoi);
                    }
                }

                // Cập nhật danh sách sản phẩm trong hoá đơn
                hoaDon["SanPham"] = sanPhamList;

                // Tính lại tổng thành tiền và cập nhật vào hoá đơn
                int tongThanhTien = 0;
                foreach (var sanPham in sanPhamList)
                {
                    int soLuong = sanPham["SoLuong"].AsInt32;
                    int donGia = sanPham["DonGia"].AsInt32;
                    int thanhTien = soLuong * donGia;
                    tongThanhTien += thanhTien;
                }

                hoaDon["ThanhTien"] = tongThanhTien;

                // Lưu hoá đơn đã cập nhật vào MongoDB
                collection.ReplaceOne(filter, hoaDon);

                // Hiển thị thông báo hoặc thông tin cập nhật thành công
                MessageBox.Show("Cập nhật hoá đơn thành công.");
            }
            else
            {
                MessageBox.Show("Không tìm thấy hoá đơn.");
            }

            // Sau khi cập nhật, bạn có thể làm sạch các TextBox nếu cần
            txt_tenKH.Clear();
            txt_diaChi.Clear();
            txt_sdt.Clear();
            txt_maHoaDon.Clear();
            txt_ngayDat.Clear();
            txt_thanhtien.Clear();

            // Đặt lại giá trị mặc định cho DateTimePicker (nếu cần)
            dateTimePickerNgaySinh.Value = DateTime.Now;

            // Sau khi cập nhật tổng thành tiền, bạn có thể hiển thị giá trị này nếu cần
            // Ví dụ: lblTongThanhTien.Text = tongThanhTien.ToString();

            dataSP.Rows.Clear();

            // Sau khi cập nhật, bạn cũng có thể load lại dữ liệu và thống kê hoá đơn
            LoadData();
            thongkehoadon(); 
            }


           
        }




        private void btn_xoaHD_Click(object sender, EventArgs e)
        {   
            // Lấy mã hoá đơn bạn muốn xóa từ TextBox hoặc một nguồn dữ liệu khác
            string maDonHang = txt_maHoaDon.Text;

            
            
            
             // Truy vấn cơ sở dữ liệu để xác định hoá đơn cần xóa
            var filter = Builders<BsonDocument>.Filter.Eq("MaDonHang", maDonHang);
            var result = collection.DeleteOne(filter); 

            // Xóa hoá đơn từ cơ sở dữ liệu
            

            if (result.DeletedCount > 0)
            {
                // Nếu có ít nhất một hoá đơn được xóa, hiển thị thông báo xóa thành công
                MessageBox.Show("Hoá đơn đã được xóa thành công.");
            }
            else
            {
                // Nếu không tìm thấy hoá đơn để xóa, hiển thị thông báo không tìm thấy
                MessageBox.Show("Không tìm thấy hoá đơn để xóa.");
            }
            LoadData();
            thongkehoadon();  
           

            
        }

        private void dataSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataSP.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
           
            if (e.RowIndex >= 0 && e.RowIndex < dataSP.Rows.Count)
            {
                // Lấy thông tin sản phẩm từ hàng đã chọn
                string maSP = dataSP.Rows[e.RowIndex].Cells["MaSP"].Value?.ToString();
                string tenSP = dataSP.Rows[e.RowIndex].Cells["TenSP"].Value?.ToString();
                string donViTinh = dataSP.Rows[e.RowIndex].Cells["DonViTinh"].Value?.ToString();
                int soLuong = 0;
                int donGia = 0;

                int.TryParse(dataSP.Rows[e.RowIndex].Cells["SoLuong"].Value?.ToString(), out soLuong);
                int.TryParse(dataSP.Rows[e.RowIndex].Cells["DonGia"].Value?.ToString(), out donGia);

                // Hiển thị thông tin sản phẩm lên các TextBox tương ứng
                txt_maSp.Text = maSP;
                txt_tenSp.Text = tenSP;
                txt_dvt.Text = donViTinh;
                txt_soLuong.Text = soLuong.ToString();
                txt_dongGia.Text = donGia.ToString();
            }
        }


        public void thongkehoadon()
        {

            var documents = collection.Find(new BsonDocument()).ToList();
            decimal tongTienHoaDon = 0;
            foreach (var document in documents)
            {
                if (document.Contains("ThanhTien"))
                {
                    var thanhTienValue = document["ThanhTien"];

                    if (thanhTienValue.IsDecimal128)
                    {
                        tongTienHoaDon += thanhTienValue.AsDecimal;
                    }
                    else if (thanhTienValue.IsInt32)
                    {
                        tongTienHoaDon += Convert.ToDecimal(thanhTienValue.AsInt32);
                    }
                    // Các trường hợp khác có thể xử lý tại đây (float, double, v.v.)
                }
            }

            int tongSoLuongSanPham = 0;
            foreach (var document in documents)
            {
                var sanPhamList = document.GetValue("SanPham").AsBsonArray;
                foreach (var sanPham in sanPhamList)
                {
                    if (sanPham.IsBsonDocument && sanPham.AsBsonDocument.Contains("SoLuong"))
                    {
                        tongSoLuongSanPham += sanPham.AsBsonDocument["SoLuong"].AsInt32;
                    }
                }
            }

            int tongSoHoaDon = documents.Count;
            txt_tongHoaDon.Text = tongSoHoaDon.ToString();

            decimal tongDiemDanhGia = 0;
            foreach (var document in documents)
            {
                if (document.Contains("DanhGia") && document["DanhGia"].IsBsonDocument && document["DanhGia"].AsBsonDocument.Contains("ThangDiem"))
                {
                    var thangDiem = document["DanhGia"]["ThangDiem"];

                    if (thangDiem.IsInt32)
                    {
                        tongDiemDanhGia += Convert.ToDecimal(thangDiem.AsInt32);
                    }
                    else if (thangDiem.IsDouble)
                    {
                        tongDiemDanhGia += Convert.ToDecimal(thangDiem.AsDouble);
                    }
                    else if (thangDiem.IsDecimal128)
                    {
                        tongDiemDanhGia += thangDiem.AsDecimal;
                    }
                }
            }
            // Gán giá trị vào các TextBox
            txt_TongTien.Text = tongTienHoaDon.ToString();
            txt_TongSoSP.Text = tongSoLuongSanPham.ToString();
            txt_tbDiemDG.Text = (tongDiemDanhGia / tongSoHoaDon).ToString("N1");

        }



        private void btn_themSP_Click(object sender, EventArgs e)
        {




            txt_maSp.Clear();
            txt_tenSp.Clear();
            txt_dvt.Clear();
            txt_soLuong.Clear();
            txt_dongGia.Clear();

            // Cập nhật lại dữ liệu trong DataGridView

            // Lấy mã hoá đơn từ hàng đã chọn


            // Gọi hàm LoadDataSP để hiển thị danh sách sản phẩm đã mua
           // LoadDataSP(txt_maHoaDon.Text);
        }



        private void btn_suaSP_Click(object sender, EventArgs e)
        {
            
          
            if (dataSP.SelectedRows.Count > 0)
            {
                    DataGridViewRow selectedRow = dataSP.SelectedRows[0];
                    string maSP = selectedRow.Cells["MaSP"].Value.ToString();


                    if (string.IsNullOrWhiteSpace(txt_tenSp.Text) ||
                         string.IsNullOrWhiteSpace(txt_dongGia.Text) ||
                         string.IsNullOrWhiteSpace(txt_soLuong.Text)
                         )
                    {
                        // Show the error message
                        MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {

                        // Lấy thông tin đã chỉnh sửa từ các TextBox
                        string tenSPMoi = txt_tenSp.Text;
                        string donViTinhMoi = txt_dvt.Text;
                        int soLuongMuaMoi = Convert.ToInt32(txt_soLuong.Text);
                        int donGiaMoi = Convert.ToInt32(txt_dongGia.Text);

                        // Cập nhật thông tin sản phẩm trong DataGridView
                        selectedRow.Cells["TenSP"].Value = tenSPMoi;
                        selectedRow.Cells["DonViTinh"].Value = donViTinhMoi;
                        selectedRow.Cells["SoLuong"].Value = soLuongMuaMoi;
                        selectedRow.Cells["DonGia"].Value = donGiaMoi;

                    // Sau khi cập nhật xong,  có thể xóa dữ liệu trong các TextBox
                    txt_maSp.Clear();
                        txt_tenSp.Clear();
                        txt_dvt.Clear();
                        txt_soLuong.Clear();
                        txt_dongGia.Clear();

                        MessageBox.Show("Đã cập nhật thông tin sản phẩm thành công.");
                    }
                   
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để sửa.");
            }

            
            

        }

       
            private void btn_xoaSP_Click(object sender, EventArgs e)
            {

            
            if (dataSP.SelectedRows.Count > 0)
            {
                // Kiểm tra xem có một sản phẩm đã được chọn trong DataGridView hay không
                
                    // Lấy mã sản phẩm từ hàng đã chọn trong DataGridView
                    string maSP = dataSP.SelectedRows[0].Cells["MaSP"].Value.ToString();

                    // Xác định sản phẩm cần xóa trong DataGridView và loại bỏ nó
                    foreach (DataGridViewRow row in dataSP.Rows)
                    {
                        if (row.Cells["MaSP"].Value != null && row.Cells["MaSP"].Value.ToString() == maSP)
                        {
                            dataSP.Rows.Remove(row);
                            break;
                        }
                    }

                    // Cập nhật lại danh sách sản phẩm trong hoá đơn (nếu cần)
                    // Đây bạn có thể lấy danh sách sản phẩm trong DataGridView và cập nhật lại hoá đơn.
                    // Bạn có thể lưu thông tin sản phẩm đã cập nhật vào cơ sở dữ liệu sau khi cập nhật danh sách sản phẩm trong DataGridView.

                    // Hiển thị thông báo hoặc thông tin xóa sản phẩm thành công
                    MessageBox.Show("Sản phẩm đã được xóa thành công.");
                    txt_maSp.Clear();
                    txt_tenSp.Clear();
                    txt_dvt.Clear();
                    txt_soLuong.Clear();
                    txt_dongGia.Clear();

                
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để xóa.");
            }
            
            
            }

        private void btn_luuSP_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_tenSp.Text) ||
                 string.IsNullOrWhiteSpace(txt_dongGia.Text) ||
                 string.IsNullOrWhiteSpace(txt_soLuong.Text)
                 )
            {
                // Show the error message
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {

            // Lấy thông tin sản phẩm từ các TextBox hoặc điều khiển khác
            string maSP = txt_maSp.Text;
                string tenSP = txt_tenSp.Text;
                string donViTinh = txt_dvt.Text;
                int soLuongMua = Convert.ToInt32(txt_soLuong.Text);
                int donGia = Convert.ToInt32(txt_dongGia.Text);

                // Thêm thông tin sản phẩm vào DataGridView dataSP
                dataSP.Rows.Add(maSP, tenSP, donViTinh, soLuongMua, donGia);

                // Sau khi thêm sản phẩm mới, bạn có thể làm sạch các TextBox nếu cần
                txt_maSp.Clear();
                txt_tenSp.Clear();
                txt_dvt.Clear();
                txt_soLuong.Clear();
                txt_dongGia.Clear();

                // Hiển thị thông báo hoặc thông tin thêm sản phẩm thành công
                MessageBox.Show("Sản phẩm đã được thêm vào danh sách thành công.");
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
            errorProvider1.SetError(txt_sdt, "");

            if (txt_sdt.Text.Length == 10)
            {
                errorProvider1.SetError(txt_sdt, ""); // Xóa thông báo lỗi nếu có
            }
            else
            {
                errorProvider1.SetError(txt_sdt, "Số điện thoại phải có đúng 10 số"); // Hiển thị thông báo lỗi
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

        private void txt_tenKH_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_tenKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra xem ký tự nhập vào có phải là ký tự chữ không
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Nếu không phải là ký tự chữ hoặc ký tự điều khiển (như Backspace), hủy sự kiện
                e.Handled = true;
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}





