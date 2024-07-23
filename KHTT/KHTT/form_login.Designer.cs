namespace KHTT
{
    partial class form_login
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
            this.txt_tentaikhoan = new System.Windows.Forms.TextBox();
            this.txt_matkhau = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_hienmatkhau = new System.Windows.Forms.Button();
            this.btn_dangnhap = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_tentaikhoan
            // 
            this.txt_tentaikhoan.Location = new System.Drawing.Point(117, 92);
            this.txt_tentaikhoan.Name = "txt_tentaikhoan";
            this.txt_tentaikhoan.Size = new System.Drawing.Size(170, 22);
            this.txt_tentaikhoan.TabIndex = 0;
            // 
            // txt_matkhau
            // 
            this.txt_matkhau.Location = new System.Drawing.Point(117, 149);
            this.txt_matkhau.Name = "txt_matkhau";
            this.txt_matkhau.PasswordChar = '*';
            this.txt_matkhau.Size = new System.Drawing.Size(170, 22);
            this.txt_matkhau.TabIndex = 2;
            this.txt_matkhau.TextChanged += new System.EventHandler(this.txt_matkhau_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(85, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(202, 40);
            this.label3.TabIndex = 4;
            this.label3.Text = "Đăng Nhập";
            // 
            // button2
            // 
            this.button2.Image = global::KHTT.Properties.Resources.padlock;
            this.button2.Location = new System.Drawing.Point(25, 145);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(53, 42);
            this.button2.TabIndex = 8;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Image = global::KHTT.Properties.Resources.user1;
            this.button1.Location = new System.Drawing.Point(25, 80);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 42);
            this.button1.TabIndex = 7;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btn_hienmatkhau
            // 
            this.btn_hienmatkhau.BackColor = System.Drawing.SystemColors.Control;
            this.btn_hienmatkhau.Image = global::KHTT.Properties.Resources.eye1;
            this.btn_hienmatkhau.Location = new System.Drawing.Point(307, 145);
            this.btn_hienmatkhau.Name = "btn_hienmatkhau";
            this.btn_hienmatkhau.Size = new System.Drawing.Size(34, 30);
            this.btn_hienmatkhau.TabIndex = 6;
            this.btn_hienmatkhau.UseVisualStyleBackColor = false;
            this.btn_hienmatkhau.Click += new System.EventHandler(this.btn_hienmatkhau_Click);
            // 
            // btn_dangnhap
            // 
            this.btn_dangnhap.Image = global::KHTT.Properties.Resources.login;
            this.btn_dangnhap.Location = new System.Drawing.Point(117, 219);
            this.btn_dangnhap.Name = "btn_dangnhap";
            this.btn_dangnhap.Size = new System.Drawing.Size(104, 52);
            this.btn_dangnhap.TabIndex = 5;
            this.btn_dangnhap.UseVisualStyleBackColor = true;
            this.btn_dangnhap.Click += new System.EventHandler(this.btn_dangnhap_Click);
            // 
            // form_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 283);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_hienmatkhau);
            this.Controls.Add(this.btn_dangnhap);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_matkhau);
            this.Controls.Add(this.txt_tentaikhoan);
            this.Name = "form_login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "form_login";
            this.Load += new System.EventHandler(this.form_login_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_tentaikhoan;
        private System.Windows.Forms.TextBox txt_matkhau;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_dangnhap;
        private System.Windows.Forms.Button btn_hienmatkhau;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}