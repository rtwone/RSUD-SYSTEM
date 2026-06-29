namespace RSUD_SYSTEM {
    partial class menuDiagnosa {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label5 = new System.Windows.Forms.Label();
            this.shapeBack = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.cbFilterPasien = new System.Windows.Forms.ComboBox();
            this.textBoxCari = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelIsiDataPasien = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbKunjungan = new System.Windows.Forms.ComboBox();
            this.labelKunjungan = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.butttonReset = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.buttonSimpan = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.textBoxKeluhan = new System.Windows.Forms.TextBox();
            this.dgvObat = new System.Windows.Forms.DataGridView();
            this.btnTambahObat = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnHapusObat = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnHapusTindakan = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnTambahTindakan = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.dgvTindakan = new System.Windows.Forms.DataGridView();
            this.btnHapusDiagnosa = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnTambahDiagnosa = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.dgvDiagnosa = new System.Windows.Forms.DataGridView();
            this.checkBStatus = new System.Windows.Forms.CheckBox();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.labelKamar = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvObat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTindakan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiagnosa)).BeginInit();
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
            this.label5.Size = new System.Drawing.Size(270, 84);
            this.label5.TabIndex = 9;
            this.label5.Text = "Diagnosa";
            // 
            // shapeBack
            // 
            this.shapeBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.shapeBack.Enabled = false;
            this.shapeBack.Location = new System.Drawing.Point(49, 273);
            this.shapeBack.Name = "shapeBack";
            this.shapeBack.Size = new System.Drawing.Size(2318, 1144);
            this.shapeBack.StateDisabled.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.shapeBack.StateDisabled.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.shapeBack.StateDisabled.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.shapeBack.StateDisabled.Border.Rounding = 20;
            this.shapeBack.StateDisabled.Border.Width = 0;
            this.shapeBack.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.shapeBack.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.shapeBack.TabIndex = 14;
            this.shapeBack.Values.Text = "";
            // 
            // cbFilterPasien
            // 
            this.cbFilterPasien.BackColor = System.Drawing.Color.White;
            this.cbFilterPasien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterPasien.Font = new System.Drawing.Font("Poppins Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterPasien.ForeColor = System.Drawing.Color.Black;
            this.cbFilterPasien.FormattingEnabled = true;
            this.cbFilterPasien.Items.AddRange(new object[] {
            "Pilih Pasien",
            "Tes"});
            this.cbFilterPasien.Location = new System.Drawing.Point(1541, 162);
            this.cbFilterPasien.Name = "cbFilterPasien";
            this.cbFilterPasien.Size = new System.Drawing.Size(767, 64);
            this.cbFilterPasien.TabIndex = 15;
            this.cbFilterPasien.SelectedIndexChanged += new System.EventHandler(this.cbFilterPasien_SelectedIndexChanged);
            // 
            // textBoxCari
            // 
            this.textBoxCari.BackColor = System.Drawing.Color.White;
            this.textBoxCari.Font = new System.Drawing.Font("Poppins Medium", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCari.ForeColor = System.Drawing.Color.Black;
            this.textBoxCari.Location = new System.Drawing.Point(466, 159);
            this.textBoxCari.Multiline = true;
            this.textBoxCari.Name = "textBoxCari";
            this.textBoxCari.Size = new System.Drawing.Size(1045, 70);
            this.textBoxCari.TabIndex = 63;
            this.textBoxCari.Text = "Cari...";
            this.textBoxCari.TextChanged += new System.EventHandler(this.textBoxCari_TextChanged);
            this.textBoxCari.Enter += new System.EventHandler(this.textBoxCari_Enter);
            this.textBoxCari.Leave += new System.EventHandler(this.textBoxCari_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Font = new System.Drawing.Font("Poppins Medium", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(83, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(327, 96);
            this.label1.TabIndex = 64;
            this.label1.Text = "Cari No Rekam Medis\r\natau Nama Pasien";
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonButton1.Enabled = false;
            this.kryptonButton1.Location = new System.Drawing.Point(49, 100);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(2318, 163);
            this.kryptonButton1.StateDisabled.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.kryptonButton1.StateDisabled.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.kryptonButton1.StateDisabled.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton1.StateDisabled.Border.Rounding = 20;
            this.kryptonButton1.StateDisabled.Border.Width = 0;
            this.kryptonButton1.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.kryptonButton1.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.kryptonButton1.TabIndex = 65;
            this.kryptonButton1.Values.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Font = new System.Drawing.Font("Poppins Black", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(105, 317);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(301, 76);
            this.label2.TabIndex = 66;
            this.label2.Text = "Data Pasien";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Font = new System.Drawing.Font("Poppins Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(108, 403);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(261, 336);
            this.label3.TabIndex = 67;
            this.label3.Text = "No. RM\r\nNama\r\nNIK\r\nUmur\r\nJenis Kelamin\r\nTanggal Lahir";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Font = new System.Drawing.Font("Poppins Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(429, 403);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 336);
            this.label4.TabIndex = 68;
            this.label4.Text = ":\r\n:\r\n:\r\n:\r\n:\r\n:";
            // 
            // labelIsiDataPasien
            // 
            this.labelIsiDataPasien.AutoSize = true;
            this.labelIsiDataPasien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelIsiDataPasien.Font = new System.Drawing.Font("Poppins Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIsiDataPasien.ForeColor = System.Drawing.Color.White;
            this.labelIsiDataPasien.Location = new System.Drawing.Point(481, 403);
            this.labelIsiDataPasien.Name = "labelIsiDataPasien";
            this.labelIsiDataPasien.Size = new System.Drawing.Size(248, 336);
            this.labelIsiDataPasien.TabIndex = 69;
            this.labelIsiDataPasien.Text = "No. RM\r\nNama\r\nNIK\r\nUmur\r\nJenis Kelamin\r\nTanggal Lahir";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Font = new System.Drawing.Font("Poppins Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(108, 753);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(308, 392);
            this.label6.TabIndex = 70;
            this.label6.Text = "Kunjungan\r\nJenis Kunjungan\r\nPoliklinik\r\nDokter\r\nStatus\r\nKamar\r\nBPJS";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Font = new System.Drawing.Font("Poppins Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(429, 753);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 392);
            this.label7.TabIndex = 71;
            this.label7.Text = ":\r\n:\r\n:\r\n:\r\n:\r\n:\r\n:";
            // 
            // cbKunjungan
            // 
            this.cbKunjungan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKunjungan.Font = new System.Drawing.Font("Poppins Medium", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbKunjungan.FormattingEnabled = true;
            this.cbKunjungan.Location = new System.Drawing.Point(491, 753);
            this.cbKunjungan.Name = "cbKunjungan";
            this.cbKunjungan.Size = new System.Drawing.Size(580, 50);
            this.cbKunjungan.TabIndex = 72;
            this.cbKunjungan.SelectedIndexChanged += new System.EventHandler(this.cbKunjungan_SelectedIndexChanged);
            // 
            // labelKunjungan
            // 
            this.labelKunjungan.AutoSize = true;
            this.labelKunjungan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelKunjungan.Font = new System.Drawing.Font("Poppins Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKunjungan.ForeColor = System.Drawing.Color.White;
            this.labelKunjungan.Location = new System.Drawing.Point(481, 809);
            this.labelKunjungan.Name = "labelKunjungan";
            this.labelKunjungan.Size = new System.Drawing.Size(43, 168);
            this.labelKunjungan.TabIndex = 73;
            this.labelKunjungan.Text = "-\r\n-\r\n-";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Font = new System.Drawing.Font("Poppins Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(108, 1157);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(164, 56);
            this.label9.TabIndex = 75;
            this.label9.Text = "Keluhan";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label10.Font = new System.Drawing.Font("Poppins Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(429, 1157);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 56);
            this.label10.TabIndex = 76;
            this.label10.Text = ":";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label11.Font = new System.Drawing.Font("Poppins Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(1679, 330);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 56);
            this.label11.TabIndex = 81;
            this.label11.Text = ":";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label12.Font = new System.Drawing.Font("Poppins Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(1358, 330);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(187, 56);
            this.label12.TabIndex = 80;
            this.label12.Text = "Diagnosa";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label13.Font = new System.Drawing.Font("Poppins Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(1679, 646);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(33, 56);
            this.label13.TabIndex = 84;
            this.label13.Text = ":";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label14.Font = new System.Drawing.Font("Poppins Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(1358, 646);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(184, 56);
            this.label14.TabIndex = 83;
            this.label14.Text = "Tindakan";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label15.Font = new System.Drawing.Font("Poppins Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(1682, 955);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(33, 56);
            this.label15.TabIndex = 87;
            this.label15.Text = ":";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label16.Font = new System.Drawing.Font("Poppins Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(1361, 955);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(109, 56);
            this.label16.TabIndex = 86;
            this.label16.Text = "Obat";
            // 
            // butttonReset
            // 
            this.butttonReset.Location = new System.Drawing.Point(1602, 1249);
            this.butttonReset.Name = "butttonReset";
            this.butttonReset.Size = new System.Drawing.Size(211, 65);
            this.butttonReset.StateNormal.Back.Color1 = System.Drawing.Color.Teal;
            this.butttonReset.StateNormal.Back.Color2 = System.Drawing.Color.Teal;
            this.butttonReset.StateNormal.Border.Color1 = System.Drawing.Color.White;
            this.butttonReset.StateNormal.Border.Color2 = System.Drawing.Color.White;
            this.butttonReset.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.butttonReset.StateNormal.Border.Rounding = 0;
            this.butttonReset.StateNormal.Border.Width = 2;
            this.butttonReset.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.butttonReset.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.butttonReset.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Poppins SemiBold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butttonReset.StatePressed.Back.Color1 = System.Drawing.Color.Teal;
            this.butttonReset.StatePressed.Back.Color2 = System.Drawing.Color.Teal;
            this.butttonReset.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.butttonReset.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.butttonReset.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Poppins SemiBold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butttonReset.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.butttonReset.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.butttonReset.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.butttonReset.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.butttonReset.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Poppins SemiBold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butttonReset.TabIndex = 90;
            this.butttonReset.Values.Text = "Reset";
            this.butttonReset.Click += new System.EventHandler(this.butttonReset_Click);
            // 
            // buttonSimpan
            // 
            this.buttonSimpan.Location = new System.Drawing.Point(1371, 1249);
            this.buttonSimpan.Name = "buttonSimpan";
            this.buttonSimpan.Size = new System.Drawing.Size(211, 65);
            this.buttonSimpan.StateNormal.Back.Color1 = System.Drawing.Color.Teal;
            this.buttonSimpan.StateNormal.Back.Color2 = System.Drawing.Color.Teal;
            this.buttonSimpan.StateNormal.Border.Color1 = System.Drawing.Color.White;
            this.buttonSimpan.StateNormal.Border.Color2 = System.Drawing.Color.White;
            this.buttonSimpan.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.buttonSimpan.StateNormal.Border.Rounding = 0;
            this.buttonSimpan.StateNormal.Border.Width = 2;
            this.buttonSimpan.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.buttonSimpan.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.buttonSimpan.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Poppins SemiBold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSimpan.StatePressed.Back.Color1 = System.Drawing.Color.Teal;
            this.buttonSimpan.StatePressed.Back.Color2 = System.Drawing.Color.Teal;
            this.buttonSimpan.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.buttonSimpan.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.buttonSimpan.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Poppins SemiBold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSimpan.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonSimpan.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonSimpan.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.buttonSimpan.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.buttonSimpan.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Poppins SemiBold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSimpan.TabIndex = 89;
            this.buttonSimpan.Values.Text = "Simpan";
            this.buttonSimpan.Click += new System.EventHandler(this.buttonSimpan_Click);
            // 
            // textBoxKeluhan
            // 
            this.textBoxKeluhan.BackColor = System.Drawing.Color.White;
            this.textBoxKeluhan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxKeluhan.Enabled = false;
            this.textBoxKeluhan.Font = new System.Drawing.Font("Poppins Medium", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxKeluhan.Location = new System.Drawing.Point(491, 1157);
            this.textBoxKeluhan.Multiline = true;
            this.textBoxKeluhan.Name = "textBoxKeluhan";
            this.textBoxKeluhan.ReadOnly = true;
            this.textBoxKeluhan.Size = new System.Drawing.Size(580, 148);
            this.textBoxKeluhan.TabIndex = 92;
            this.textBoxKeluhan.TabStop = false;
            // 
            // dgvObat
            // 
            this.dgvObat.AllowUserToAddRows = false;
            this.dgvObat.AllowUserToDeleteRows = false;
            this.dgvObat.AllowUserToResizeColumns = false;
            this.dgvObat.AllowUserToResizeRows = false;
            this.dgvObat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvObat.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvObat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvObat.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvObat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvObat.EnableHeadersVisualStyles = false;
            this.dgvObat.Location = new System.Drawing.Point(1371, 1014);
            this.dgvObat.Name = "dgvObat";
            this.dgvObat.RowTemplate.Height = 35;
            this.dgvObat.Size = new System.Drawing.Size(924, 229);
            this.dgvObat.TabIndex = 93;
            // 
            // btnTambahObat
            // 
            this.btnTambahObat.Location = new System.Drawing.Point(1925, 962);
            this.btnTambahObat.Name = "btnTambahObat";
            this.btnTambahObat.Size = new System.Drawing.Size(182, 49);
            this.btnTambahObat.StateNormal.Back.Color1 = System.Drawing.Color.Teal;
            this.btnTambahObat.StateNormal.Back.Color2 = System.Drawing.Color.Teal;
            this.btnTambahObat.StateNormal.Border.Color1 = System.Drawing.Color.White;
            this.btnTambahObat.StateNormal.Border.Color2 = System.Drawing.Color.White;
            this.btnTambahObat.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnTambahObat.StateNormal.Border.Rounding = 0;
            this.btnTambahObat.StateNormal.Border.Width = 2;
            this.btnTambahObat.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnTambahObat.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnTambahObat.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Poppins SemiBold", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTambahObat.StateNormal.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnTambahObat.StateNormal.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnTambahObat.StatePressed.Back.Color1 = System.Drawing.Color.Teal;
            this.btnTambahObat.StatePressed.Back.Color2 = System.Drawing.Color.Teal;
            this.btnTambahObat.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.btnTambahObat.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.Black;
            this.btnTambahObat.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Poppins SemiBold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTambahObat.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnTambahObat.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnTambahObat.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnTambahObat.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnTambahObat.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Poppins SemiBold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTambahObat.StateTracking.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnTambahObat.StateTracking.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnTambahObat.TabIndex = 94;
            this.btnTambahObat.Values.Text = "  Tambah";
            this.btnTambahObat.Click += new System.EventHandler(this.btnTambahObat_Click);
            // 
            // btnHapusObat
            // 
            this.btnHapusObat.Location = new System.Drawing.Point(2113, 962);
            this.btnHapusObat.Name = "btnHapusObat";
            this.btnHapusObat.Size = new System.Drawing.Size(182, 49);
            this.btnHapusObat.StateNormal.Back.Color1 = System.Drawing.Color.Teal;
            this.btnHapusObat.StateNormal.Back.Color2 = System.Drawing.Color.Teal;
            this.btnHapusObat.StateNormal.Border.Color1 = System.Drawing.Color.White;
            this.btnHapusObat.StateNormal.Border.Color2 = System.Drawing.Color.White;
            this.btnHapusObat.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnHapusObat.StateNormal.Border.Rounding = 0;
            this.btnHapusObat.StateNormal.Border.Width = 2;
            this.btnHapusObat.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnHapusObat.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnHapusObat.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Poppins SemiBold", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHapusObat.StateNormal.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnHapusObat.StateNormal.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnHapusObat.StatePressed.Back.Color1 = System.Drawing.Color.Teal;
            this.btnHapusObat.StatePressed.Back.Color2 = System.Drawing.Color.Teal;
            this.btnHapusObat.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.btnHapusObat.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.Black;
            this.btnHapusObat.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Poppins SemiBold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHapusObat.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnHapusObat.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnHapusObat.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnHapusObat.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnHapusObat.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Poppins SemiBold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHapusObat.StateTracking.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnHapusObat.StateTracking.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnHapusObat.TabIndex = 95;
            this.btnHapusObat.Values.Text = "  Hapus";
            this.btnHapusObat.Click += new System.EventHandler(this.btnHapusObat_Click);
            // 
            // btnHapusTindakan
            // 
            this.btnHapusTindakan.Location = new System.Drawing.Point(2110, 653);
            this.btnHapusTindakan.Name = "btnHapusTindakan";
            this.btnHapusTindakan.Size = new System.Drawing.Size(182, 49);
            this.btnHapusTindakan.StateNormal.Back.Color1 = System.Drawing.Color.Teal;
            this.btnHapusTindakan.StateNormal.Back.Color2 = System.Drawing.Color.Teal;
            this.btnHapusTindakan.StateNormal.Border.Color1 = System.Drawing.Color.White;
            this.btnHapusTindakan.StateNormal.Border.Color2 = System.Drawing.Color.White;
            this.btnHapusTindakan.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnHapusTindakan.StateNormal.Border.Rounding = 0;
            this.btnHapusTindakan.StateNormal.Border.Width = 2;
            this.btnHapusTindakan.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnHapusTindakan.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnHapusTindakan.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Poppins SemiBold", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHapusTindakan.StateNormal.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnHapusTindakan.StateNormal.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnHapusTindakan.StatePressed.Back.Color1 = System.Drawing.Color.Teal;
            this.btnHapusTindakan.StatePressed.Back.Color2 = System.Drawing.Color.Teal;
            this.btnHapusTindakan.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.btnHapusTindakan.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.Black;
            this.btnHapusTindakan.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Poppins SemiBold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHapusTindakan.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnHapusTindakan.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnHapusTindakan.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnHapusTindakan.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnHapusTindakan.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Poppins SemiBold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHapusTindakan.StateTracking.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnHapusTindakan.StateTracking.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnHapusTindakan.TabIndex = 100;
            this.btnHapusTindakan.Values.Text = "  Hapus";
            this.btnHapusTindakan.Click += new System.EventHandler(this.btnHapusTindakan_Click);
            // 
            // btnTambahTindakan
            // 
            this.btnTambahTindakan.Location = new System.Drawing.Point(1922, 653);
            this.btnTambahTindakan.Name = "btnTambahTindakan";
            this.btnTambahTindakan.Size = new System.Drawing.Size(182, 49);
            this.btnTambahTindakan.StateNormal.Back.Color1 = System.Drawing.Color.Teal;
            this.btnTambahTindakan.StateNormal.Back.Color2 = System.Drawing.Color.Teal;
            this.btnTambahTindakan.StateNormal.Border.Color1 = System.Drawing.Color.White;
            this.btnTambahTindakan.StateNormal.Border.Color2 = System.Drawing.Color.White;
            this.btnTambahTindakan.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnTambahTindakan.StateNormal.Border.Rounding = 0;
            this.btnTambahTindakan.StateNormal.Border.Width = 2;
            this.btnTambahTindakan.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnTambahTindakan.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnTambahTindakan.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Poppins SemiBold", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTambahTindakan.StateNormal.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnTambahTindakan.StateNormal.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnTambahTindakan.StatePressed.Back.Color1 = System.Drawing.Color.Teal;
            this.btnTambahTindakan.StatePressed.Back.Color2 = System.Drawing.Color.Teal;
            this.btnTambahTindakan.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.btnTambahTindakan.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.Black;
            this.btnTambahTindakan.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Poppins SemiBold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTambahTindakan.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnTambahTindakan.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnTambahTindakan.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnTambahTindakan.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnTambahTindakan.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Poppins SemiBold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTambahTindakan.StateTracking.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnTambahTindakan.StateTracking.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnTambahTindakan.TabIndex = 99;
            this.btnTambahTindakan.Values.Text = "  Tambah";
            this.btnTambahTindakan.Click += new System.EventHandler(this.btnTambahTindakan_Click);
            // 
            // dgvTindakan
            // 
            this.dgvTindakan.AllowUserToAddRows = false;
            this.dgvTindakan.AllowUserToDeleteRows = false;
            this.dgvTindakan.AllowUserToResizeColumns = false;
            this.dgvTindakan.AllowUserToResizeRows = false;
            this.dgvTindakan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTindakan.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvTindakan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTindakan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTindakan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTindakan.EnableHeadersVisualStyles = false;
            this.dgvTindakan.Location = new System.Drawing.Point(1368, 705);
            this.dgvTindakan.Name = "dgvTindakan";
            this.dgvTindakan.RowTemplate.Height = 35;
            this.dgvTindakan.Size = new System.Drawing.Size(924, 229);
            this.dgvTindakan.TabIndex = 98;
            this.dgvTindakan.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTindakan_CellValueChanged);
            this.dgvTindakan.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvTindakan_CurrentCellDirtyStateChanged);
            // 
            // btnHapusDiagnosa
            // 
            this.btnHapusDiagnosa.Location = new System.Drawing.Point(2110, 337);
            this.btnHapusDiagnosa.Name = "btnHapusDiagnosa";
            this.btnHapusDiagnosa.Size = new System.Drawing.Size(182, 49);
            this.btnHapusDiagnosa.StateNormal.Back.Color1 = System.Drawing.Color.Teal;
            this.btnHapusDiagnosa.StateNormal.Back.Color2 = System.Drawing.Color.Teal;
            this.btnHapusDiagnosa.StateNormal.Border.Color1 = System.Drawing.Color.White;
            this.btnHapusDiagnosa.StateNormal.Border.Color2 = System.Drawing.Color.White;
            this.btnHapusDiagnosa.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnHapusDiagnosa.StateNormal.Border.Rounding = 0;
            this.btnHapusDiagnosa.StateNormal.Border.Width = 2;
            this.btnHapusDiagnosa.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnHapusDiagnosa.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnHapusDiagnosa.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Poppins SemiBold", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHapusDiagnosa.StateNormal.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnHapusDiagnosa.StateNormal.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnHapusDiagnosa.StatePressed.Back.Color1 = System.Drawing.Color.Teal;
            this.btnHapusDiagnosa.StatePressed.Back.Color2 = System.Drawing.Color.Teal;
            this.btnHapusDiagnosa.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.btnHapusDiagnosa.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.Black;
            this.btnHapusDiagnosa.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Poppins SemiBold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHapusDiagnosa.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnHapusDiagnosa.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnHapusDiagnosa.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnHapusDiagnosa.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnHapusDiagnosa.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Poppins SemiBold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHapusDiagnosa.StateTracking.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnHapusDiagnosa.StateTracking.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnHapusDiagnosa.TabIndex = 103;
            this.btnHapusDiagnosa.Values.Text = "  Hapus";
            this.btnHapusDiagnosa.Click += new System.EventHandler(this.btnHapusDiagnosa_Click);
            // 
            // btnTambahDiagnosa
            // 
            this.btnTambahDiagnosa.Location = new System.Drawing.Point(1922, 337);
            this.btnTambahDiagnosa.Name = "btnTambahDiagnosa";
            this.btnTambahDiagnosa.Size = new System.Drawing.Size(182, 49);
            this.btnTambahDiagnosa.StateNormal.Back.Color1 = System.Drawing.Color.Teal;
            this.btnTambahDiagnosa.StateNormal.Back.Color2 = System.Drawing.Color.Teal;
            this.btnTambahDiagnosa.StateNormal.Border.Color1 = System.Drawing.Color.White;
            this.btnTambahDiagnosa.StateNormal.Border.Color2 = System.Drawing.Color.White;
            this.btnTambahDiagnosa.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnTambahDiagnosa.StateNormal.Border.Rounding = 0;
            this.btnTambahDiagnosa.StateNormal.Border.Width = 2;
            this.btnTambahDiagnosa.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnTambahDiagnosa.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnTambahDiagnosa.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Poppins SemiBold", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTambahDiagnosa.StateNormal.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnTambahDiagnosa.StateNormal.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnTambahDiagnosa.StatePressed.Back.Color1 = System.Drawing.Color.Teal;
            this.btnTambahDiagnosa.StatePressed.Back.Color2 = System.Drawing.Color.Teal;
            this.btnTambahDiagnosa.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.btnTambahDiagnosa.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.Black;
            this.btnTambahDiagnosa.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Poppins SemiBold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTambahDiagnosa.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnTambahDiagnosa.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnTambahDiagnosa.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnTambahDiagnosa.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnTambahDiagnosa.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Poppins SemiBold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTambahDiagnosa.StateTracking.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnTambahDiagnosa.StateTracking.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnTambahDiagnosa.TabIndex = 102;
            this.btnTambahDiagnosa.Values.Text = "  Tambah";
            this.btnTambahDiagnosa.Click += new System.EventHandler(this.btnTambahDiagnosa_Click);
            // 
            // dgvDiagnosa
            // 
            this.dgvDiagnosa.AllowUserToAddRows = false;
            this.dgvDiagnosa.AllowUserToDeleteRows = false;
            this.dgvDiagnosa.AllowUserToResizeColumns = false;
            this.dgvDiagnosa.AllowUserToResizeRows = false;
            this.dgvDiagnosa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDiagnosa.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDiagnosa.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDiagnosa.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDiagnosa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiagnosa.EnableHeadersVisualStyles = false;
            this.dgvDiagnosa.Location = new System.Drawing.Point(1368, 389);
            this.dgvDiagnosa.Name = "dgvDiagnosa";
            this.dgvDiagnosa.RowTemplate.Height = 35;
            this.dgvDiagnosa.Size = new System.Drawing.Size(924, 229);
            this.dgvDiagnosa.TabIndex = 101;
            // 
            // checkBStatus
            // 
            this.checkBStatus.AutoSize = true;
            this.checkBStatus.Font = new System.Drawing.Font("Poppins Medium", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBStatus.Location = new System.Drawing.Point(779, 972);
            this.checkBStatus.Name = "checkBStatus";
            this.checkBStatus.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.checkBStatus.Size = new System.Drawing.Size(189, 41);
            this.checkBStatus.TabIndex = 105;
            this.checkBStatus.Text = "Ganti Status";
            this.checkBStatus.UseVisualStyleBackColor = true;
            this.checkBStatus.CheckedChanged += new System.EventHandler(this.checkBStatus_CheckedChanged);
            // 
            // cbStatus
            // 
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.Font = new System.Drawing.Font("Poppins Medium", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
            "-",
            "menunggu",
            "menginap",
            "selesai"});
            this.cbStatus.Location = new System.Drawing.Point(491, 968);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(270, 45);
            this.cbStatus.TabIndex = 106;
            this.cbStatus.SelectedIndexChanged += new System.EventHandler(this.cbStatus_SelectedIndexChanged);
            // 
            // labelKamar
            // 
            this.labelKamar.AutoSize = true;
            this.labelKamar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelKamar.Font = new System.Drawing.Font("Poppins Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKamar.ForeColor = System.Drawing.Color.White;
            this.labelKamar.Location = new System.Drawing.Point(481, 1033);
            this.labelKamar.Name = "labelKamar";
            this.labelKamar.Size = new System.Drawing.Size(43, 112);
            this.labelKamar.TabIndex = 107;
            this.labelKamar.Text = "-\r\n-";
            // 
            // menuDiagnosa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(2417, 1350);
            this.Controls.Add(this.labelKamar);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.checkBStatus);
            this.Controls.Add(this.btnHapusDiagnosa);
            this.Controls.Add(this.btnTambahDiagnosa);
            this.Controls.Add(this.dgvDiagnosa);
            this.Controls.Add(this.btnHapusTindakan);
            this.Controls.Add(this.btnTambahTindakan);
            this.Controls.Add(this.dgvTindakan);
            this.Controls.Add(this.btnHapusObat);
            this.Controls.Add(this.btnTambahObat);
            this.Controls.Add(this.dgvObat);
            this.Controls.Add(this.textBoxKeluhan);
            this.Controls.Add(this.butttonReset);
            this.Controls.Add(this.buttonSimpan);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbKunjungan);
            this.Controls.Add(this.labelKunjungan);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelIsiDataPasien);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxCari);
            this.Controls.Add(this.cbFilterPasien);
            this.Controls.Add(this.shapeBack);
            this.Controls.Add(this.kryptonButton1);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "menuDiagnosa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "menuDiagnosa";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.menuRekamMedis_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvObat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTindakan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiagnosa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private ComponentFactory.Krypton.Toolkit.KryptonButton shapeBack;
        private System.Windows.Forms.ComboBox cbFilterPasien;
        private System.Windows.Forms.TextBox textBoxCari;
        private System.Windows.Forms.Label label1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelIsiDataPasien;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbKunjungan;
        private System.Windows.Forms.Label labelKunjungan;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private ComponentFactory.Krypton.Toolkit.KryptonButton butttonReset;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonSimpan;
        private System.Windows.Forms.TextBox textBoxKeluhan;
        private System.Windows.Forms.DataGridView dgvObat;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnTambahObat;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnHapusObat;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnHapusTindakan;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnTambahTindakan;
        private System.Windows.Forms.DataGridView dgvTindakan;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnHapusDiagnosa;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnTambahDiagnosa;
        private System.Windows.Forms.DataGridView dgvDiagnosa;
        private System.Windows.Forms.CheckBox checkBStatus;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Label labelKamar;
    }
}