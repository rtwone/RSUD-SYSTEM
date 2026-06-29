namespace RSUD_SYSTEM {
    partial class menuDataMaster {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBoxCari = new System.Windows.Forms.TextBox();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonHapus = new System.Windows.Forms.Button();
            this.shapeAtas = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.labelTotalData = new System.Windows.Forms.Label();
            this.buttonTambah = new System.Windows.Forms.Button();
            this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Poppins SemiBold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(33, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(335, 84);
            this.label5.TabIndex = 8;
            this.label5.Text = "Data Master";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.Silver;
            this.dataGridView1.Location = new System.Drawing.Point(70, 280);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(2251, 1058);
            this.dataGridView1.TabIndex = 0;
            // 
            // textBoxCari
            // 
            this.textBoxCari.BackColor = System.Drawing.Color.White;
            this.textBoxCari.Font = new System.Drawing.Font("Poppins Medium", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCari.ForeColor = System.Drawing.Color.Gray;
            this.textBoxCari.Location = new System.Drawing.Point(433, 157);
            this.textBoxCari.Multiline = true;
            this.textBoxCari.Name = "textBoxCari";
            this.textBoxCari.Size = new System.Drawing.Size(751, 56);
            this.textBoxCari.TabIndex = 62;
            this.textBoxCari.Text = "Cari...";
            this.textBoxCari.TextChanged += new System.EventHandler(this.textBoxCari_TextChanged);
            this.textBoxCari.Enter += new System.EventHandler(this.textBoxCari_Enter);
            this.textBoxCari.Leave += new System.EventHandler(this.textBoxCari_Leave);
            // 
            // cbFilter
            // 
            this.cbFilter.BackColor = System.Drawing.Color.White;
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.Font = new System.Drawing.Font("Poppins Medium", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilter.ForeColor = System.Drawing.Color.Black;
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Items.AddRange(new object[] {
            "Pilih Jenis Masuk",
            "Rawat Inap",
            "Rawat Jalan",
            "UGD/IGD"});
            this.cbFilter.Location = new System.Drawing.Point(104, 157);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(294, 56);
            this.cbFilter.TabIndex = 61;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Font = new System.Drawing.Font("Poppins Medium", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button2.Location = new System.Drawing.Point(1882, 153);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.button2.Size = new System.Drawing.Size(190, 65);
            this.button2.TabIndex = 64;
            this.button2.Text = "Edit";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonHapus
            // 
            this.buttonHapus.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonHapus.BackColor = System.Drawing.Color.White;
            this.buttonHapus.Font = new System.Drawing.Font("Poppins Medium", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHapus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonHapus.Location = new System.Drawing.Point(2096, 153);
            this.buttonHapus.Name = "buttonHapus";
            this.buttonHapus.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.buttonHapus.Size = new System.Drawing.Size(190, 65);
            this.buttonHapus.TabIndex = 65;
            this.buttonHapus.Text = "Hapus";
            this.buttonHapus.UseVisualStyleBackColor = false;
            this.buttonHapus.Click += new System.EventHandler(this.buttonHapus_Click);
            // 
            // shapeAtas
            // 
            this.shapeAtas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.shapeAtas.Enabled = false;
            this.shapeAtas.Location = new System.Drawing.Point(47, 124);
            this.shapeAtas.Name = "shapeAtas";
            this.shapeAtas.Size = new System.Drawing.Size(2303, 126);
            this.shapeAtas.StateDisabled.Back.Color1 = System.Drawing.Color.White;
            this.shapeAtas.StateDisabled.Back.Color2 = System.Drawing.Color.White;
            this.shapeAtas.StateDisabled.Border.Color1 = System.Drawing.Color.Silver;
            this.shapeAtas.StateDisabled.Border.Color2 = System.Drawing.Color.Silver;
            this.shapeAtas.StateDisabled.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.shapeAtas.StateDisabled.Border.Rounding = 15;
            this.shapeAtas.StateDisabled.Border.Width = 1;
            this.shapeAtas.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.shapeAtas.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.shapeAtas.TabIndex = 11;
            this.shapeAtas.Values.Text = "";
            // 
            // labelTotalData
            // 
            this.labelTotalData.AutoSize = true;
            this.labelTotalData.BackColor = System.Drawing.Color.White;
            this.labelTotalData.Font = new System.Drawing.Font("Poppins Medium", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelTotalData.Location = new System.Drawing.Point(1209, 165);
            this.labelTotalData.Name = "labelTotalData";
            this.labelTotalData.Size = new System.Drawing.Size(211, 48);
            this.labelTotalData.TabIndex = 66;
            this.labelTotalData.Text = "Total Data : 0";
            // 
            // buttonTambah
            // 
            this.buttonTambah.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonTambah.BackColor = System.Drawing.Color.White;
            this.buttonTambah.Font = new System.Drawing.Font("Poppins Medium", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTambah.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonTambah.Location = new System.Drawing.Point(1667, 153);
            this.buttonTambah.Name = "buttonTambah";
            this.buttonTambah.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.buttonTambah.Size = new System.Drawing.Size(190, 65);
            this.buttonTambah.TabIndex = 63;
            this.buttonTambah.Text = "Tambah";
            this.buttonTambah.UseVisualStyleBackColor = false;
            this.buttonTambah.Click += new System.EventHandler(this.buttonTambah_Click);
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonButton1.Enabled = false;
            this.kryptonButton1.Location = new System.Drawing.Point(47, 256);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(2303, 1097);
            this.kryptonButton1.StateDisabled.Back.Color1 = System.Drawing.Color.White;
            this.kryptonButton1.StateDisabled.Back.Color2 = System.Drawing.Color.White;
            this.kryptonButton1.StateDisabled.Border.Color1 = System.Drawing.Color.Silver;
            this.kryptonButton1.StateDisabled.Border.Color2 = System.Drawing.Color.Silver;
            this.kryptonButton1.StateDisabled.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton1.StateDisabled.Border.Rounding = 15;
            this.kryptonButton1.StateDisabled.Border.Width = 1;
            this.kryptonButton1.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.kryptonButton1.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.kryptonButton1.TabIndex = 67;
            this.kryptonButton1.Values.Text = "";
            // 
            // menuDataMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(2417, 1350);
            this.Controls.Add(this.labelTotalData);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonHapus);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.textBoxCari);
            this.Controls.Add(this.buttonTambah);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.shapeAtas);
            this.Controls.Add(this.kryptonButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "menuDataMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "menuDataMaster";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.menuDataMaster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.TextBox textBoxCari;
        private System.Windows.Forms.Button buttonHapus;
        private System.Windows.Forms.Button button2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton shapeAtas;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelTotalData;
        private System.Windows.Forms.Button buttonTambah;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
    }
}