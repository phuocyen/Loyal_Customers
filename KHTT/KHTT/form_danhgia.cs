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
    public partial class form_danhgia : Form
    {
        private IMongoCollection<BsonDocument> collection;
        public form_danhgia()
        {
            InitializeComponent();
            this.Load += Demo_Load;
        }

        private void Demo_Load(object sender, EventArgs e)
        {
         
            load_ketnoi();
 load_data();
            //load cmb 1-5
            for (int i = 1; i <= 5; i++)
            {
                cmb_danhgia.Items.Add(i);
            }
            Controls.Add(cmb_danhgia);

        }
        public void load_ketnoi()
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("QL_KhachHangThanThiet");
            collection = database.GetCollection<BsonDocument>("HoaDon");
        }
        /// <summary>
        ///load không tham số
        /// </summary>
        public void load_data()
        {
            txt_tongdg.ResetText();
            flow_panel_danhgia.AutoScroll= true;
            var documents = collection.Find(new BsonDocument()).ToList();
            foreach (var document in documents)
            {
                danhgia userControl = new danhgia();
                string hoTen = document["KhachHang"]["HoTen"].AsString;
                string nhanxet=document["DanhGia"]["NhanXet"].AsString;
                float thangdiem =float.Parse(document["DanhGia"]["ThangDiem"].ToString());
          
                userControl.HienThiDanhGia(thangdiem, hoTen, nhanxet);
                flow_panel_danhgia.Controls.Add(userControl);
            }
            Controls.Add(flow_panel_danhgia);
            txt_tongdg.Text ="Tổng đánh giá: "+ flow_panel_danhgia.Controls.Count.ToString();
        }
        /// <summary>
        /// load có tham số
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        public void load_data_thamso(int a, int b)
        {
         txt_tongdg.ResetText();
            flow_panel_danhgia.AutoScroll = true;
            var documents = collection.Find(new BsonDocument()).ToList();
            foreach (var document in documents)
            {
               float thangdiem = float.Parse(document["DanhGia"]["ThangDiem"].ToString());
               if (thangdiem >=a && thangdiem<b)
               {
                   danhgia userControl = new danhgia();
                   string hoTen = document["KhachHang"]["HoTen"].AsString;
                   string nhanxet = document["DanhGia"]["NhanXet"].AsString;
                   userControl.Size = new Size(300, 150);
                   userControl.HienThiDanhGia(thangdiem, hoTen, nhanxet);
                   flow_panel_danhgia.Controls.Add(userControl);
               }
            }
            Controls.Add(flow_panel_danhgia);
            txt_tongdg.Text = "Tổng đánh giá: " + flow_panel_danhgia.Controls.Count.ToString();
        }
        private void cmb_danhgia_SelectedIndexChanged(object sender, EventArgs e)
        {
           flow_panel_danhgia.Controls.Clear();
           if (cmb_danhgia.SelectedItem != null)
            {
                    if ((int)cmb_danhgia.SelectedItem == 1)
                    {
                        load_data_thamso(1, 2);
                    }
                    else if ((int)cmb_danhgia.SelectedItem == 2)
                    {
                        load_data_thamso(2, 3);
                    }
                    else if ((int)cmb_danhgia.SelectedItem == 3)
                    {
                        load_data_thamso(3, 4);
                    }
                    else if ((int)cmb_danhgia.SelectedItem == 4)
                    {
                        load_data_thamso(4, 5);
                    }
                    else
                    {
                        load_data_thamso(5, 6);
                    }
            }
        }

        private void flow_panel_danhgia_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
