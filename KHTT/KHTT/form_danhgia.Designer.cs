namespace KHTT
{
    partial class form_danhgia
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
            this.flow_panel_danhgia = new System.Windows.Forms.FlowLayoutPanel();
            this.cmb_danhgia = new System.Windows.Forms.ComboBox();
            this.txt_tongdg = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // flow_panel_danhgia
            // 
            this.flow_panel_danhgia.Location = new System.Drawing.Point(294, 2);
            this.flow_panel_danhgia.Name = "flow_panel_danhgia";
            this.flow_panel_danhgia.Size = new System.Drawing.Size(913, 330);
            this.flow_panel_danhgia.TabIndex = 0;
            this.flow_panel_danhgia.Paint += new System.Windows.Forms.PaintEventHandler(this.flow_panel_danhgia_Paint);
            // 
            // cmb_danhgia
            // 
            this.cmb_danhgia.FormattingEnabled = true;
            this.cmb_danhgia.Location = new System.Drawing.Point(38, 88);
            this.cmb_danhgia.Name = "cmb_danhgia";
            this.cmb_danhgia.Size = new System.Drawing.Size(179, 24);
            this.cmb_danhgia.TabIndex = 1;
            this.cmb_danhgia.SelectedIndexChanged += new System.EventHandler(this.cmb_danhgia_SelectedIndexChanged);
            // 
            // txt_tongdg
            // 
            this.txt_tongdg.BackColor = System.Drawing.SystemColors.Control;
            this.txt_tongdg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_tongdg.Enabled = false;
            this.txt_tongdg.Location = new System.Drawing.Point(38, 158);
            this.txt_tongdg.Multiline = true;
            this.txt_tongdg.Name = "txt_tongdg";
            this.txt_tongdg.Size = new System.Drawing.Size(179, 22);
            this.txt_tongdg.TabIndex = 2;
            this.txt_tongdg.Text = "Tổng đánh giá";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Lọc đánh giá";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::KHTT.Properties.Resources.dieuhoa;
            this.pictureBox1.Location = new System.Drawing.Point(0, 186);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(293, 146);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // form_danhgia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 332);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_tongdg);
            this.Controls.Add(this.cmb_danhgia);
            this.Controls.Add(this.flow_panel_danhgia);
            this.Name = "form_danhgia";
            this.Text = "Đánh giá";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flow_panel_danhgia;
        private System.Windows.Forms.ComboBox cmb_danhgia;
        private System.Windows.Forms.TextBox txt_tongdg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}