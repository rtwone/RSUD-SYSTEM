namespace RSUD_SYSTEM {
    partial class FormPopupDetailKunjungan {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent() {
            this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.label1 = new System.Windows.Forms.Label();
            this.flowDetail = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTutup = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.SuspendLayout();
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Enabled = false;
            this.kryptonButton1.Location = new System.Drawing.Point(30, 30);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(1540, 824);
            this.kryptonButton1.StateDisabled.Back.Color1 = System.Drawing.Color.White;
            this.kryptonButton1.StateDisabled.Back.Color2 = System.Drawing.Color.White;
            this.kryptonButton1.StateDisabled.Border.Color1 = System.Drawing.Color.Silver;
            this.kryptonButton1.StateDisabled.Border.Color2 = System.Drawing.Color.Silver;
            this.kryptonButton1.StateDisabled.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton1.StateDisabled.Border.Rounding = 15;
            this.kryptonButton1.StateDisabled.Border.Width = 1;
            this.kryptonButton1.TabIndex = 1;
            this.kryptonButton1.Values.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Poppins SemiBold", 16F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(55, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(410, 76);
            this.label1.TabIndex = 0;
            this.label1.Text = "Detail Kunjungan";
            // 
            // flowDetail
            // 
            this.flowDetail.AutoScroll = true;
            this.flowDetail.BackColor = System.Drawing.Color.White;
            this.flowDetail.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowDetail.Location = new System.Drawing.Point(66, 130);
            this.flowDetail.Name = "flowDetail";
            this.flowDetail.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.flowDetail.Size = new System.Drawing.Size(1493, 700);
            this.flowDetail.TabIndex = 2;
            this.flowDetail.WrapContents = false;
            // 
            // btnTutup
            // 
            this.btnTutup.Location = new System.Drawing.Point(1353, 860);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(217, 58);
            this.btnTutup.StateCommon.Back.Color1 = System.Drawing.Color.Teal;
            this.btnTutup.StateCommon.Back.Color2 = System.Drawing.Color.Teal;
            this.btnTutup.StateCommon.Border.Color1 = System.Drawing.Color.Teal;
            this.btnTutup.StateCommon.Border.Color2 = System.Drawing.Color.Teal;
            this.btnTutup.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnTutup.StateCommon.Border.Rounding = 8;
            this.btnTutup.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnTutup.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Poppins SemiBold", 9F, System.Drawing.FontStyle.Bold);
            this.btnTutup.TabIndex = 3;
            this.btnTutup.Values.Text = "Tutup";
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // FormPopupDetailKunjungan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1600, 983);
            this.Controls.Add(this.btnTutup);
            this.Controls.Add(this.flowDetail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.kryptonButton1);
            this.Name = "FormPopupDetailKunjungan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormPopupDetailKunjungan";
            this.Load += new System.EventHandler(this.FormPopupDetailKunjungan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowDetail;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnTutup;
    }
}