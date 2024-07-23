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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KHTT
{
    public partial class form_login : Form
    {
        ErrorProvider errorProvider = new ErrorProvider();
        private IMongoCollection<BsonDocument> collection;
        public form_login()
        {
            InitializeComponent();
            this.Load += Form_login_Load;

        }

        private void Form_login_Load(object sender, EventArgs e)
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("QL_KhachHangThanThiet");
            collection = database.GetCollection<BsonDocument>("NhanVien");
            ToolTip passwordToolTip = new ToolTip();
            passwordToolTip.ToolTipTitle = "Yêu cầu mật khẩu";
            passwordToolTip.UseFading = true;
            passwordToolTip.UseAnimation = true;
            passwordToolTip.IsBalloon = true;
            passwordToolTip.SetToolTip(txt_matkhau, "Mật khẩu phải chứa ít nhất một chữ cái hoa, một chữ cái thường, một số và một ký tự đặc biệt.");
        }

        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            string taiKhoan = txt_tentaikhoan.Text.Trim();
            string matKhau = txt_matkhau.Text.Trim();

            if (string.IsNullOrEmpty(taiKhoan) || string.IsNullOrEmpty(matKhau))
            {
                // Show an error message indicating that both fields are required
                MessageBox.Show("Vui lòng nhập đủ thông tin tên tài khoản và mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool passwordErrorMessage = kiemtra_user_pass(txt_tentaikhoan.Text,txt_matkhau.Text);
                if (!passwordErrorMessage)
                {
                    // Show an error message indicating the password requirements
                    MessageBox.Show("Hãy kiểm tra lại mật khẩu và tài khoản", "Đăng nhập không thành công", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                   
                   DialogResult r=  MessageBox.Show("Đăng Nhập Thông Công", "Thông Báo", MessageBoxButtons.OK);
                    if(r==DialogResult.OK)
                    {
                        FormMain fm = new FormMain(txt_tentaikhoan.Text, txt_matkhau.Text);
                        fm.ShowDialog();
                    }    
                    
                    

                }
            }
        }
        private bool kiemtra_user_pass(string user, string password)
        {
            try
            {
                var filter = Builders<BsonDocument>.Filter.Eq("User", user);
                var document = collection.Find(filter).FirstOrDefault();

                if (document != null)
                {
                    var storedPassword = document.GetValue("Pass").AsString;
                    if (string.Equals(password, storedPassword))
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {   
                Console.WriteLine(ex.Message);
            }
            return false;
        }
        private void txt_matkhau_TextChanged(object sender, EventArgs e)
        {
            //string password = txt_matkhau.Text.Trim();
            //Regex passwordRegex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$");
            //if (!passwordRegex.IsMatch(password))
            //{
            //    string errorMessage = "Mật khẩu phải chứa ít nhất một chữ cái hoa.\r\n" +
            //                          "Một chữ cái thường và một chữ số.\r\n" +
            //                          "Một ký tự đặc biệt.";
            //    errorProvider.SetError(txt_matkhau, errorMessage);
            //}
            //else
            //{
            //    errorProvider.SetError(txt_matkhau, "");
            //}
        }
        private void ShowPassword(bool show)
        {
            if (show)
            {
                // Hiển thị mật khẩu
                txt_matkhau.PasswordChar = '\0'; // Hiển thị mật khẩu với ký tự rỗng
            }
            else
            {
                // Ẩn mật khẩu
                txt_matkhau.PasswordChar = '*'; // Hoặc bạn có thể sử dụng ký tự khác như '*'
            }
        }
        private void btn_hienmatkhau_Click(object sender, EventArgs e)
        {
            ShowPassword(txt_matkhau.PasswordChar == '*');
        }

        private void form_login_Load_1(object sender, EventArgs e)
        {

        }
    }
}
