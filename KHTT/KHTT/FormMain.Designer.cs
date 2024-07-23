namespace KHTT
{
    partial class FormMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thongkeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đánhGiáToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lab_tentaikhoan = new System.Windows.Forms.ToolStripTextBox();
            this.panel_show = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lab_tieude = new System.Windows.Forms.Label();
            this.btn_nhanvien = new System.Windows.Forms.Button();
            this.btn_lichsumuahang = new System.Windows.Forms.Button();
            this.btn_sanpham = new System.Windows.Forms.Button();
            this.btn_khachhang = new System.Windows.Forms.Button();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hệThốngToolStripMenuItem,
            this.thongkeToolStripMenuItem,
            this.đánhGiáToolStripMenuItem1,
            this.lab_tentaikhoan,
            this.thoátToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1924, 31);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(88, 27);
            this.hệThốngToolStripMenuItem.Text = "Hệ Thống";
            // 
            // thongkeToolStripMenuItem
            // 
            this.thongkeToolStripMenuItem.Name = "thongkeToolStripMenuItem";
            this.thongkeToolStripMenuItem.Size = new System.Drawing.Size(84, 27);
            this.thongkeToolStripMenuItem.Text = "Thống kê";
            this.thongkeToolStripMenuItem.Click += new System.EventHandler(this.thongkeToolStripMenuItem_Click);
            // 
            // đánhGiáToolStripMenuItem1
            // 
            this.đánhGiáToolStripMenuItem1.Name = "đánhGiáToolStripMenuItem1";
            this.đánhGiáToolStripMenuItem1.Size = new System.Drawing.Size(83, 27);
            this.đánhGiáToolStripMenuItem1.Text = "Đánh giá";
            this.đánhGiáToolStripMenuItem1.Click += new System.EventHandler(this.đánhGiáToolStripMenuItem1_Click);
            // 
            // lab_tentaikhoan
            // 
            this.lab_tentaikhoan.Enabled = false;
            this.lab_tentaikhoan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lab_tentaikhoan.Name = "lab_tentaikhoan";
            this.lab_tentaikhoan.Size = new System.Drawing.Size(250, 27);
            // 
            // panel_show
            // 
            this.panel_show.Location = new System.Drawing.Point(258, 44);
            this.panel_show.Name = "panel_show";
            this.panel_show.Size = new System.Drawing.Size(1417, 850);
            this.panel_show.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lab_tieude);
            this.panel1.Controls.Add(this.btn_nhanvien);
            this.panel1.Controls.Add(this.btn_lichsumuahang);
            this.panel1.Controls.Add(this.btn_sanpham);
            this.panel1.Controls.Add(this.btn_khachhang);
            this.panel1.Location = new System.Drawing.Point(12, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 717);
            this.panel1.TabIndex = 0;
            // 
            // lab_tieude
            // 
            this.lab_tieude.AutoSize = true;
            this.lab_tieude.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
            this.lab_tieude.Location = new System.Drawing.Point(3, 18);
            this.lab_tieude.Name = "lab_tieude";
            this.lab_tieude.Size = new System.Drawing.Size(177, 38);
            this.lab_tieude.TabIndex = 2;
            this.lab_tieude.Text = "Trang Chủ";
            // 
            // btn_nhanvien
            // 
            this.btn_nhanvien.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_nhanvien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_nhanvien.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_nhanvien.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_nhanvien.Image = global::KHTT.Properties.Resources.team;
            this.btn_nhanvien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_nhanvien.Location = new System.Drawing.Point(19, 403);
            this.btn_nhanvien.Name = "btn_nhanvien";
            this.btn_nhanvien.Size = new System.Drawing.Size(201, 71);
            this.btn_nhanvien.TabIndex = 8;
            this.btn_nhanvien.Text = "Nhân Viên";
            this.btn_nhanvien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_nhanvien.UseVisualStyleBackColor = false;
            this.btn_nhanvien.Click += new System.EventHandler(this.btn_nhanvien_Click);
            // 
            // btn_lichsumuahang
            // 
            this.btn_lichsumuahang.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_lichsumuahang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_lichsumuahang.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_lichsumuahang.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_lichsumuahang.Image = global::KHTT.Properties.Resources.shopping_cart;
            this.btn_lichsumuahang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_lichsumuahang.Location = new System.Drawing.Point(19, 311);
            this.btn_lichsumuahang.Name = "btn_lichsumuahang";
            this.btn_lichsumuahang.Size = new System.Drawing.Size(201, 71);
            this.btn_lichsumuahang.TabIndex = 7;
            this.btn_lichsumuahang.Text = "Hóa Đơn";
            this.btn_lichsumuahang.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_lichsumuahang.UseVisualStyleBackColor = false;
            this.btn_lichsumuahang.Click += new System.EventHandler(this.btn_lichsumuahang_Click_1);
            // 
            // btn_sanpham
            // 
            this.btn_sanpham.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_sanpham.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sanpham.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_sanpham.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_sanpham.Image = global::KHTT.Properties.Resources.products;
            this.btn_sanpham.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_sanpham.Location = new System.Drawing.Point(19, 220);
            this.btn_sanpham.Name = "btn_sanpham";
            this.btn_sanpham.Size = new System.Drawing.Size(201, 71);
            this.btn_sanpham.TabIndex = 6;
            this.btn_sanpham.Text = "Sản Phẩm";
            this.btn_sanpham.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_sanpham.UseVisualStyleBackColor = false;
            this.btn_sanpham.Click += new System.EventHandler(this.btn_sanpham_Click_1);
            // 
            // btn_khachhang
            // 
            this.btn_khachhang.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_khachhang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_khachhang.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_khachhang.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_khachhang.Image = global::KHTT.Properties.Resources.client2;
            this.btn_khachhang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_khachhang.Location = new System.Drawing.Point(19, 125);
            this.btn_khachhang.Name = "btn_khachhang";
            this.btn_khachhang.Size = new System.Drawing.Size(201, 71);
            this.btn_khachhang.TabIndex = 5;
            this.btn_khachhang.Text = "Khách Hàng";
            this.btn_khachhang.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_khachhang.UseVisualStyleBackColor = false;
            this.btn_khachhang.Click += new System.EventHandler(this.btn_khachhang_Click_1);
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(61, 27);
            this.thoátToolStripMenuItem.Text = "Thoát";
            this.thoátToolStripMenuItem.Click += new System.EventHandler(this.thoátToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_show);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thongkeToolStripMenuItem;
        private System.Windows.Forms.Panel panel_show;
        private System.Windows.Forms.ToolStripMenuItem đánhGiáToolStripMenuItem1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_nhanvien;
        private System.Windows.Forms.Button btn_lichsumuahang;
        private System.Windows.Forms.Button btn_sanpham;
        private System.Windows.Forms.Button btn_khachhang;
        private System.Windows.Forms.Label lab_tieude;
        private System.Windows.Forms.ToolStripTextBox lab_tentaikhoan;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
    }
}