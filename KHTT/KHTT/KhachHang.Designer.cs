namespace KHTT
{
    partial class KhachHang
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tbl_KH = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_gioiTinh = new System.Windows.Forms.GroupBox();
            this.radio_Nu = new System.Windows.Forms.RadioButton();
            this.radio_Nam = new System.Windows.Forms.RadioButton();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.txt_timKiem = new System.Windows.Forms.TextBox();
            this.btn_tim = new System.Windows.Forms.Button();
            this.lb_tim = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePickerNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_diaChi = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdi_TimNgaySinh = new System.Windows.Forms.RadioButton();
            this.rdi_timGioiTinh = new System.Windows.Forms.RadioButton();
            this.rdi_timDiaChi = new System.Windows.Forms.RadioButton();
            this.rdi_timSDT = new System.Windows.Forms.RadioButton();
            this.rdi_TimTen = new System.Windows.Forms.RadioButton();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.btn_sua = new System.Windows.Forms.Button();
            this.btn_them = new System.Windows.Forms.Button();
            this.txt_maKH = new System.Windows.Forms.TextBox();
            this.txt_tenKH = new System.Windows.Forms.TextBox();
            this.txt_sdt = new System.Windows.Forms.TextBox();
            this.btn_luu = new System.Windows.Forms.Button();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_KH)).BeginInit();
            this.btn_gioiTinh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tbl_KH, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 388);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1059, 322);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // tbl_KH
            // 
            this.tbl_KH.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbl_KH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbl_KH.Location = new System.Drawing.Point(4, 4);
            this.tbl_KH.Margin = new System.Windows.Forms.Padding(4);
            this.tbl_KH.Name = "tbl_KH";
            this.tbl_KH.RowHeadersWidth = 51;
            this.tbl_KH.Size = new System.Drawing.Size(1051, 314);
            this.tbl_KH.TabIndex = 0;
            this.tbl_KH.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tbl_khachHang_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 83);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã khách hàng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 135);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên khách hàng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 184);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Số điện thoại";
            // 
            // btn_gioiTinh
            // 
            this.btn_gioiTinh.Controls.Add(this.radio_Nu);
            this.btn_gioiTinh.Controls.Add(this.radio_Nam);
            this.btn_gioiTinh.Location = new System.Drawing.Point(7, 320);
            this.btn_gioiTinh.Margin = new System.Windows.Forms.Padding(4);
            this.btn_gioiTinh.Name = "btn_gioiTinh";
            this.btn_gioiTinh.Padding = new System.Windows.Forms.Padding(4);
            this.btn_gioiTinh.Size = new System.Drawing.Size(389, 60);
            this.btn_gioiTinh.TabIndex = 4;
            this.btn_gioiTinh.TabStop = false;
            this.btn_gioiTinh.Text = "Giới tính";
            // 
            // radio_Nu
            // 
            this.radio_Nu.AutoSize = true;
            this.radio_Nu.Location = new System.Drawing.Point(299, 23);
            this.radio_Nu.Margin = new System.Windows.Forms.Padding(4);
            this.radio_Nu.Name = "radio_Nu";
            this.radio_Nu.Size = new System.Drawing.Size(45, 20);
            this.radio_Nu.TabIndex = 1;
            this.radio_Nu.Text = "Nữ";
            this.radio_Nu.UseVisualStyleBackColor = true;
            // 
            // radio_Nam
            // 
            this.radio_Nam.AutoSize = true;
            this.radio_Nam.Checked = true;
            this.radio_Nam.Location = new System.Drawing.Point(79, 23);
            this.radio_Nam.Margin = new System.Windows.Forms.Padding(4);
            this.radio_Nam.Name = "radio_Nam";
            this.radio_Nam.Size = new System.Drawing.Size(57, 20);
            this.radio_Nam.TabIndex = 0;
            this.radio_Nam.TabStop = true;
            this.radio_Nam.Text = "Nam";
            this.radio_Nam.UseVisualStyleBackColor = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // txt_timKiem
            // 
            this.txt_timKiem.Location = new System.Drawing.Point(722, 341);
            this.txt_timKiem.Margin = new System.Windows.Forms.Padding(4);
            this.txt_timKiem.Name = "txt_timKiem";
            this.txt_timKiem.Size = new System.Drawing.Size(240, 22);
            this.txt_timKiem.TabIndex = 6;
            // 
            // btn_tim
            // 
            this.btn_tim.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_tim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_tim.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_tim.Image = global::KHTT.Properties.Resources.search;
            this.btn_tim.Location = new System.Drawing.Point(979, 331);
            this.btn_tim.Margin = new System.Windows.Forms.Padding(4);
            this.btn_tim.Name = "btn_tim";
            this.btn_tim.Size = new System.Drawing.Size(61, 42);
            this.btn_tim.TabIndex = 7;
            this.btn_tim.UseVisualStyleBackColor = true;
            this.btn_tim.Click += new System.EventHandler(this.btn_tim_Click);
            // 
            // lb_tim
            // 
            this.lb_tim.AutoSize = true;
            this.lb_tim.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold);
            this.lb_tim.Location = new System.Drawing.Point(497, 344);
            this.lb_tim.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_tim.Name = "lb_tim";
            this.lb_tim.Size = new System.Drawing.Size(192, 19);
            this.lb_tim.TabIndex = 14;
            this.lb_tim.Text = "Nhập họ tên khách hàng :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(21, 236);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Ngày sinh";
            // 
            // dateTimePickerNgaySinh
            // 
            this.dateTimePickerNgaySinh.Location = new System.Drawing.Point(170, 234);
            this.dateTimePickerNgaySinh.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerNgaySinh.Name = "dateTimePickerNgaySinh";
            this.dateTimePickerNgaySinh.Size = new System.Drawing.Size(288, 22);
            this.dateTimePickerNgaySinh.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(21, 278);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "Địa chỉ";
            // 
            // txt_diaChi
            // 
            this.txt_diaChi.Location = new System.Drawing.Point(170, 278);
            this.txt_diaChi.Margin = new System.Windows.Forms.Padding(4);
            this.txt_diaChi.Name = "txt_diaChi";
            this.txt_diaChi.Size = new System.Drawing.Size(288, 22);
            this.txt_diaChi.TabIndex = 16;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdi_TimNgaySinh);
            this.groupBox2.Controls.Add(this.rdi_timGioiTinh);
            this.groupBox2.Controls.Add(this.rdi_timDiaChi);
            this.groupBox2.Controls.Add(this.rdi_timSDT);
            this.groupBox2.Controls.Add(this.rdi_TimTen);
            this.groupBox2.Location = new System.Drawing.Point(739, 83);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(306, 233);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm kiếm";
            // 
            // rdi_TimNgaySinh
            // 
            this.rdi_TimNgaySinh.AutoSize = true;
            this.rdi_TimNgaySinh.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdi_TimNgaySinh.Location = new System.Drawing.Point(68, 142);
            this.rdi_TimNgaySinh.Margin = new System.Windows.Forms.Padding(4);
            this.rdi_TimNgaySinh.Name = "rdi_TimNgaySinh";
            this.rdi_TimNgaySinh.Size = new System.Drawing.Size(102, 23);
            this.rdi_TimNgaySinh.TabIndex = 4;
            this.rdi_TimNgaySinh.Text = "Ngày sinh";
            this.rdi_TimNgaySinh.UseVisualStyleBackColor = true;
            // 
            // rdi_timGioiTinh
            // 
            this.rdi_timGioiTinh.AutoSize = true;
            this.rdi_timGioiTinh.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdi_timGioiTinh.Location = new System.Drawing.Point(68, 182);
            this.rdi_timGioiTinh.Margin = new System.Windows.Forms.Padding(4);
            this.rdi_timGioiTinh.Name = "rdi_timGioiTinh";
            this.rdi_timGioiTinh.Size = new System.Drawing.Size(99, 23);
            this.rdi_timGioiTinh.TabIndex = 3;
            this.rdi_timGioiTinh.Text = "Giới tính";
            this.rdi_timGioiTinh.UseVisualStyleBackColor = true;
            // 
            // rdi_timDiaChi
            // 
            this.rdi_timDiaChi.AutoSize = true;
            this.rdi_timDiaChi.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdi_timDiaChi.Location = new System.Drawing.Point(68, 101);
            this.rdi_timDiaChi.Margin = new System.Windows.Forms.Padding(4);
            this.rdi_timDiaChi.Name = "rdi_timDiaChi";
            this.rdi_timDiaChi.Size = new System.Drawing.Size(83, 23);
            this.rdi_timDiaChi.TabIndex = 2;
            this.rdi_timDiaChi.Text = "Địa chỉ";
            this.rdi_timDiaChi.UseVisualStyleBackColor = true;
            // 
            // rdi_timSDT
            // 
            this.rdi_timSDT.AutoSize = true;
            this.rdi_timSDT.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdi_timSDT.Location = new System.Drawing.Point(68, 64);
            this.rdi_timSDT.Margin = new System.Windows.Forms.Padding(4);
            this.rdi_timSDT.Name = "rdi_timSDT";
            this.rdi_timSDT.Size = new System.Drawing.Size(126, 23);
            this.rdi_timSDT.TabIndex = 1;
            this.rdi_timSDT.Text = "Số điện thoại";
            this.rdi_timSDT.UseVisualStyleBackColor = true;
            // 
            // rdi_TimTen
            // 
            this.rdi_TimTen.AutoSize = true;
            this.rdi_TimTen.Checked = true;
            this.rdi_TimTen.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdi_TimTen.Location = new System.Drawing.Point(68, 23);
            this.rdi_TimTen.Margin = new System.Windows.Forms.Padding(4);
            this.rdi_TimTen.Name = "rdi_TimTen";
            this.rdi_TimTen.Size = new System.Drawing.Size(143, 23);
            this.rdi_TimTen.TabIndex = 0;
            this.rdi_TimTen.TabStop = true;
            this.rdi_TimTen.Text = "Tên khách hàng";
            this.rdi_TimTen.UseVisualStyleBackColor = true;
            // 
            // btn_xoa
            // 
            this.btn_xoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_xoa.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold);
            this.btn_xoa.Image = global::KHTT.Properties.Resources.delete;
            this.btn_xoa.Location = new System.Drawing.Point(525, 125);
            this.btn_xoa.Margin = new System.Windows.Forms.Padding(4);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(164, 50);
            this.btn_xoa.TabIndex = 20;
            this.btn_xoa.UseVisualStyleBackColor = true;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // btn_sua
            // 
            this.btn_sua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sua.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold);
            this.btn_sua.Image = global::KHTT.Properties.Resources.updated;
            this.btn_sua.Location = new System.Drawing.Point(525, 195);
            this.btn_sua.Margin = new System.Windows.Forms.Padding(4);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Size = new System.Drawing.Size(164, 50);
            this.btn_sua.TabIndex = 21;
            this.btn_sua.UseVisualStyleBackColor = true;
            this.btn_sua.Click += new System.EventHandler(this.btn_sua_Click);
            // 
            // btn_them
            // 
            this.btn_them.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_them.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold);
            this.btn_them.Image = global::KHTT.Properties.Resources.reload;
            this.btn_them.Location = new System.Drawing.Point(525, 264);
            this.btn_them.Margin = new System.Windows.Forms.Padding(4);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(164, 50);
            this.btn_them.TabIndex = 19;
            this.btn_them.UseVisualStyleBackColor = true;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // txt_maKH
            // 
            this.txt_maKH.Enabled = false;
            this.txt_maKH.Location = new System.Drawing.Point(170, 81);
            this.txt_maKH.Name = "txt_maKH";
            this.txt_maKH.Size = new System.Drawing.Size(288, 22);
            this.txt_maKH.TabIndex = 24;
            // 
            // txt_tenKH
            // 
            this.txt_tenKH.Location = new System.Drawing.Point(170, 135);
            this.txt_tenKH.Name = "txt_tenKH";
            this.txt_tenKH.Size = new System.Drawing.Size(288, 22);
            this.txt_tenKH.TabIndex = 25;
            // 
            // txt_sdt
            // 
            this.txt_sdt.Location = new System.Drawing.Point(170, 184);
            this.txt_sdt.Name = "txt_sdt";
            this.txt_sdt.Size = new System.Drawing.Size(288, 22);
            this.txt_sdt.TabIndex = 26;
            // 
            // btn_luu
            // 
            this.btn_luu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_luu.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold);
            this.btn_luu.Image = global::KHTT.Properties.Resources.insert;
            this.btn_luu.Location = new System.Drawing.Point(525, 67);
            this.btn_luu.Margin = new System.Windows.Forms.Padding(4);
            this.btn_luu.Name = "btn_luu";
            this.btn_luu.Size = new System.Drawing.Size(164, 50);
            this.btn_luu.TabIndex = 22;
            this.btn_luu.UseVisualStyleBackColor = true;
            this.btn_luu.Click += new System.EventHandler(this.btn_luu_Click);
            // 
            // KhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 713);
            this.Controls.Add(this.txt_sdt);
            this.Controls.Add(this.txt_tenKH);
            this.Controls.Add(this.txt_maKH);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btn_xoa);
            this.Controls.Add(this.btn_luu);
            this.Controls.Add(this.btn_sua);
            this.Controls.Add(this.btn_them);
            this.Controls.Add(this.txt_diaChi);
            this.Controls.Add(this.dateTimePickerNgaySinh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lb_tim);
            this.Controls.Add(this.btn_tim);
            this.Controls.Add(this.txt_timKiem);
            this.Controls.Add(this.btn_gioiTinh);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "KhachHang";
            this.Text = "KhachHang";
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbl_KH)).EndInit();
            this.btn_gioiTinh.ResumeLayout(false);
            this.btn_gioiTinh.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox btn_gioiTinh;
        private System.Windows.Forms.RadioButton radio_Nu;
        private System.Windows.Forms.RadioButton radio_Nam;
        private System.Windows.Forms.DataGridView tbl_KH;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button btn_tim;
        private System.Windows.Forms.TextBox txt_timKiem;
        private System.Windows.Forms.Label lb_tim;
        private System.Windows.Forms.DateTimePicker dateTimePickerNgaySinh;
        private System.Windows.Forms.TextBox txt_diaChi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdi_TimNgaySinh;
        private System.Windows.Forms.RadioButton rdi_timGioiTinh;
        private System.Windows.Forms.RadioButton rdi_timDiaChi;
        private System.Windows.Forms.RadioButton rdi_timSDT;
        private System.Windows.Forms.RadioButton rdi_TimTen;
        private System.Windows.Forms.Button btn_xoa;
        private System.Windows.Forms.Button btn_sua;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.TextBox txt_maKH;
        private System.Windows.Forms.TextBox txt_sdt;
        private System.Windows.Forms.TextBox txt_tenKH;
        private System.Windows.Forms.Button btn_luu;
    }
}