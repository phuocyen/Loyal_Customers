namespace KHTT
{
    partial class danhgia
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelDanhGia = new System.Windows.Forms.Panel();
            this.label_khachhang = new System.Windows.Forms.Label();
            this.txt_nhanxet = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // panelDanhGia
            // 
            this.panelDanhGia.Location = new System.Drawing.Point(15, 42);
            this.panelDanhGia.Name = "panelDanhGia";
            this.panelDanhGia.Size = new System.Drawing.Size(357, 21);
            this.panelDanhGia.TabIndex = 1;
            // 
            // label_khachhang
            // 
            this.label_khachhang.AutoSize = true;
            this.label_khachhang.Location = new System.Drawing.Point(12, 14);
            this.label_khachhang.Name = "label_khachhang";
            this.label_khachhang.Size = new System.Drawing.Size(77, 16);
            this.label_khachhang.TabIndex = 3;
            this.label_khachhang.Text = "Khách hàng";
            // 
            // txt_nhanxet
            // 
            this.txt_nhanxet.BackColor = System.Drawing.SystemColors.Control;
            this.txt_nhanxet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_nhanxet.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nhanxet.ForeColor = System.Drawing.Color.Red;
            this.txt_nhanxet.Location = new System.Drawing.Point(15, 79);
            this.txt_nhanxet.Multiline = true;
            this.txt_nhanxet.Name = "txt_nhanxet";
            this.txt_nhanxet.Size = new System.Drawing.Size(357, 28);
            this.txt_nhanxet.TabIndex = 4;
            // 
            // danhgia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txt_nhanxet);
            this.Controls.Add(this.label_khachhang);
            this.Controls.Add(this.panelDanhGia);
            this.Name = "danhgia";
            this.Size = new System.Drawing.Size(412, 121);
            this.Load += new System.EventHandler(this.danhgia_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelDanhGia;
        private System.Windows.Forms.Label label_khachhang;
        private System.Windows.Forms.TextBox txt_nhanxet;
    }
}
