namespace KHTT
{
    partial class ThongKe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbl_KH = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_maThe = new System.Windows.Forms.TextBox();
            this.txt_HT = new System.Windows.Forms.TextBox();
            this.txt_soLanMua = new System.Windows.Forms.TextBox();
            this.txt_tongSoSPDM = new System.Windows.Forms.TextBox();
            this.txt_tongTien = new System.Windows.Forms.TextBox();
            this.txt_tbDiem = new System.Windows.Forms.TextBox();
            this.lb_tim = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdi_TimNgaySinh = new System.Windows.Forms.RadioButton();
            this.rdi_timGioiTinh = new System.Windows.Forms.RadioButton();
            this.rdi_timDiaChi = new System.Windows.Forms.RadioButton();
            this.rdi_timSDT = new System.Windows.Forms.RadioButton();
            this.rdi_TimTen = new System.Windows.Forms.RadioButton();
            this.txt_timKiem = new System.Windows.Forms.TextBox();
            this.btn_xuat_file_execl = new System.Windows.Forms.Button();
            this.btn_tim = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_KH)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbl_KH);
            this.groupBox1.Location = new System.Drawing.Point(3, 107);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(703, 446);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Khách hàng";
            // 
            // tbl_KH
            // 
            this.tbl_KH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbl_KH.Location = new System.Drawing.Point(3, 17);
            this.tbl_KH.Margin = new System.Windows.Forms.Padding(4);
            this.tbl_KH.Name = "tbl_KH";
            this.tbl_KH.RowHeadersWidth = 51;
            this.tbl_KH.Size = new System.Drawing.Size(695, 421);
            this.tbl_KH.TabIndex = 0;
            this.tbl_KH.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tbl_KH_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(712, 384);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Số lần mua";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(712, 428);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Tổng số sản phẩm đã mua";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(712, 293);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Mã thẻ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(712, 341);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "Hạng thẻ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(712, 478);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(154, 16);
            this.label6.TabIndex = 16;
            this.label6.Text = "Tổng giá trị đã giao dịch ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(712, 518);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(158, 16);
            this.label7.TabIndex = 17;
            this.label7.Text = "Trung bình điểm đánh giá";
            // 
            // txt_maThe
            // 
            this.txt_maThe.Enabled = false;
            this.txt_maThe.Location = new System.Drawing.Point(901, 284);
            this.txt_maThe.Margin = new System.Windows.Forms.Padding(4);
            this.txt_maThe.Name = "txt_maThe";
            this.txt_maThe.Size = new System.Drawing.Size(233, 22);
            this.txt_maThe.TabIndex = 20;
            // 
            // txt_HT
            // 
            this.txt_HT.Enabled = false;
            this.txt_HT.Location = new System.Drawing.Point(901, 332);
            this.txt_HT.Margin = new System.Windows.Forms.Padding(4);
            this.txt_HT.Name = "txt_HT";
            this.txt_HT.Size = new System.Drawing.Size(233, 22);
            this.txt_HT.TabIndex = 21;
            // 
            // txt_soLanMua
            // 
            this.txt_soLanMua.Enabled = false;
            this.txt_soLanMua.Location = new System.Drawing.Point(901, 384);
            this.txt_soLanMua.Margin = new System.Windows.Forms.Padding(4);
            this.txt_soLanMua.Name = "txt_soLanMua";
            this.txt_soLanMua.Size = new System.Drawing.Size(233, 22);
            this.txt_soLanMua.TabIndex = 22;
            // 
            // txt_tongSoSPDM
            // 
            this.txt_tongSoSPDM.Enabled = false;
            this.txt_tongSoSPDM.Location = new System.Drawing.Point(901, 425);
            this.txt_tongSoSPDM.Margin = new System.Windows.Forms.Padding(4);
            this.txt_tongSoSPDM.Name = "txt_tongSoSPDM";
            this.txt_tongSoSPDM.Size = new System.Drawing.Size(233, 22);
            this.txt_tongSoSPDM.TabIndex = 23;
            // 
            // txt_tongTien
            // 
            this.txt_tongTien.Enabled = false;
            this.txt_tongTien.Location = new System.Drawing.Point(901, 469);
            this.txt_tongTien.Margin = new System.Windows.Forms.Padding(4);
            this.txt_tongTien.Name = "txt_tongTien";
            this.txt_tongTien.Size = new System.Drawing.Size(233, 22);
            this.txt_tongTien.TabIndex = 24;
            // 
            // txt_tbDiem
            // 
            this.txt_tbDiem.Enabled = false;
            this.txt_tbDiem.Location = new System.Drawing.Point(901, 514);
            this.txt_tbDiem.Margin = new System.Windows.Forms.Padding(4);
            this.txt_tbDiem.Name = "txt_tbDiem";
            this.txt_tbDiem.Size = new System.Drawing.Size(233, 22);
            this.txt_tbDiem.TabIndex = 25;
            // 
            // lb_tim
            // 
            this.lb_tim.AutoSize = true;
            this.lb_tim.Location = new System.Drawing.Point(723, 213);
            this.lb_tim.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_tim.Name = "lb_tim";
            this.lb_tim.Size = new System.Drawing.Size(157, 16);
            this.lb_tim.TabIndex = 29;
            this.lb_tim.Text = "Nhập họ tên khách hàng :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdi_TimNgaySinh);
            this.groupBox2.Controls.Add(this.rdi_timGioiTinh);
            this.groupBox2.Controls.Add(this.rdi_timDiaChi);
            this.groupBox2.Controls.Add(this.rdi_timSDT);
            this.groupBox2.Controls.Add(this.rdi_TimTen);
            this.groupBox2.Location = new System.Drawing.Point(716, 47);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(420, 160);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm kiếm";
            // 
            // rdi_TimNgaySinh
            // 
            this.rdi_TimNgaySinh.AutoSize = true;
            this.rdi_TimNgaySinh.Location = new System.Drawing.Point(185, 78);
            this.rdi_TimNgaySinh.Margin = new System.Windows.Forms.Padding(4);
            this.rdi_TimNgaySinh.Name = "rdi_TimNgaySinh";
            this.rdi_TimNgaySinh.Size = new System.Drawing.Size(88, 20);
            this.rdi_TimNgaySinh.TabIndex = 4;
            this.rdi_TimNgaySinh.TabStop = true;
            this.rdi_TimNgaySinh.Text = "Ngày sinh";
            this.rdi_TimNgaySinh.UseVisualStyleBackColor = true;
            this.rdi_TimNgaySinh.Click += new System.EventHandler(this.rdb_tenKH_Click);
            // 
            // rdi_timGioiTinh
            // 
            this.rdi_timGioiTinh.AutoSize = true;
            this.rdi_timGioiTinh.Location = new System.Drawing.Point(16, 117);
            this.rdi_timGioiTinh.Margin = new System.Windows.Forms.Padding(4);
            this.rdi_timGioiTinh.Name = "rdi_timGioiTinh";
            this.rdi_timGioiTinh.Size = new System.Drawing.Size(75, 20);
            this.rdi_timGioiTinh.TabIndex = 3;
            this.rdi_timGioiTinh.TabStop = true;
            this.rdi_timGioiTinh.Text = "Giới tính";
            this.rdi_timGioiTinh.UseVisualStyleBackColor = true;
            this.rdi_timGioiTinh.Click += new System.EventHandler(this.rdb_tenKH_Click);
            // 
            // rdi_timDiaChi
            // 
            this.rdi_timDiaChi.AutoSize = true;
            this.rdi_timDiaChi.Location = new System.Drawing.Point(16, 78);
            this.rdi_timDiaChi.Margin = new System.Windows.Forms.Padding(4);
            this.rdi_timDiaChi.Name = "rdi_timDiaChi";
            this.rdi_timDiaChi.Size = new System.Drawing.Size(68, 20);
            this.rdi_timDiaChi.TabIndex = 2;
            this.rdi_timDiaChi.TabStop = true;
            this.rdi_timDiaChi.Text = "Địa chỉ";
            this.rdi_timDiaChi.UseVisualStyleBackColor = true;
            this.rdi_timDiaChi.Click += new System.EventHandler(this.rdb_tenKH_Click);
            // 
            // rdi_timSDT
            // 
            this.rdi_timSDT.AutoSize = true;
            this.rdi_timSDT.Location = new System.Drawing.Point(185, 36);
            this.rdi_timSDT.Margin = new System.Windows.Forms.Padding(4);
            this.rdi_timSDT.Name = "rdi_timSDT";
            this.rdi_timSDT.Size = new System.Drawing.Size(106, 20);
            this.rdi_timSDT.TabIndex = 1;
            this.rdi_timSDT.TabStop = true;
            this.rdi_timSDT.Text = "Số điện thoại";
            this.rdi_timSDT.UseVisualStyleBackColor = true;
            this.rdi_timSDT.Click += new System.EventHandler(this.rdb_tenKH_Click);
            // 
            // rdi_TimTen
            // 
            this.rdi_TimTen.AutoSize = true;
            this.rdi_TimTen.Location = new System.Drawing.Point(16, 36);
            this.rdi_TimTen.Margin = new System.Windows.Forms.Padding(4);
            this.rdi_TimTen.Name = "rdi_TimTen";
            this.rdi_TimTen.Size = new System.Drawing.Size(124, 20);
            this.rdi_TimTen.TabIndex = 0;
            this.rdi_TimTen.TabStop = true;
            this.rdi_TimTen.Text = "Tên khách hàng";
            this.rdi_TimTen.UseVisualStyleBackColor = true;
            this.rdi_TimTen.Click += new System.EventHandler(this.rdb_tenKH_Click);
            // 
            // txt_timKiem
            // 
            this.txt_timKiem.Location = new System.Drawing.Point(727, 235);
            this.txt_timKiem.Margin = new System.Windows.Forms.Padding(4);
            this.txt_timKiem.Name = "txt_timKiem";
            this.txt_timKiem.Size = new System.Drawing.Size(240, 22);
            this.txt_timKiem.TabIndex = 26;
            // 
            // btn_xuat_file_execl
            // 
            this.btn_xuat_file_execl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_xuat_file_execl.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_xuat_file_execl.Image = global::KHTT.Properties.Resources.form;
            this.btn_xuat_file_execl.Location = new System.Drawing.Point(594, 12);
            this.btn_xuat_file_execl.Name = "btn_xuat_file_execl";
            this.btn_xuat_file_execl.Size = new System.Drawing.Size(91, 93);
            this.btn_xuat_file_execl.TabIndex = 30;
            this.btn_xuat_file_execl.UseVisualStyleBackColor = true;
            this.btn_xuat_file_execl.Click += new System.EventHandler(this.btn_xuat_file_execl_Click);
            // 
            // btn_tim
            // 
            this.btn_tim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_tim.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_tim.Image = global::KHTT.Properties.Resources.search;
            this.btn_tim.Location = new System.Drawing.Point(997, 224);
            this.btn_tim.Margin = new System.Windows.Forms.Padding(4);
            this.btn_tim.Name = "btn_tim";
            this.btn_tim.Size = new System.Drawing.Size(75, 44);
            this.btn_tim.TabIndex = 27;
            this.btn_tim.UseVisualStyleBackColor = true;
            this.btn_tim.Click += new System.EventHandler(this.btn_tim_Click);
            // 
            // ThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 554);
            this.Controls.Add(this.btn_xuat_file_execl);
            this.Controls.Add(this.lb_tim);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btn_tim);
            this.Controls.Add(this.txt_timKiem);
            this.Controls.Add(this.txt_tbDiem);
            this.Controls.Add(this.txt_tongTien);
            this.Controls.Add(this.txt_tongSoSPDM);
            this.Controls.Add(this.txt_soLanMua);
            this.Controls.Add(this.txt_HT);
            this.Controls.Add(this.txt_maThe);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ThongKe";
            this.Text = "ThongKe";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbl_KH)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView tbl_KH;
        private System.Windows.Forms.TextBox txt_maThe;
        private System.Windows.Forms.TextBox txt_HT;
        private System.Windows.Forms.TextBox txt_soLanMua;
        private System.Windows.Forms.TextBox txt_tongSoSPDM;
        private System.Windows.Forms.TextBox txt_tongTien;
        private System.Windows.Forms.TextBox txt_tbDiem;
        private System.Windows.Forms.Label lb_tim;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdi_TimNgaySinh;
        private System.Windows.Forms.RadioButton rdi_timGioiTinh;
        private System.Windows.Forms.RadioButton rdi_timDiaChi;
        private System.Windows.Forms.RadioButton rdi_timSDT;
        private System.Windows.Forms.RadioButton rdi_TimTen;
        private System.Windows.Forms.Button btn_tim;
        private System.Windows.Forms.TextBox txt_timKiem;
        private System.Windows.Forms.Button btn_xuat_file_execl;
    }
}