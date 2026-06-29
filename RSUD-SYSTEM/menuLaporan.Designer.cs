namespace RSUD_SYSTEM {
    partial class menuLaporan {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent() {
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.btnRekap = new System.Windows.Forms.Button();
            this.btnLaporanKunjungan = new System.Windows.Forms.Button();
            this.btnLaporanTransaksi = new System.Windows.Forms.Button();
            this.labelMenu = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.labelInfo = new System.Windows.Forms.Label();
            this.panelSummary = new System.Windows.Forms.Panel();
            this.panelTotalKembali = new System.Windows.Forms.Panel();
            this.labelTotalKembali = new System.Windows.Forms.Label();
            this.labelKembaliTitle = new System.Windows.Forms.Label();
            this.panelTotalBayar = new System.Windows.Forms.Panel();
            this.labelTotalBayar = new System.Windows.Forms.Label();
            this.labelTotalBayarTitle = new System.Windows.Forms.Label();
            this.panelTotalDiskon = new System.Windows.Forms.Panel();
            this.labelTotalDiskon = new System.Windows.Forms.Label();
            this.labelDiskonTitle = new System.Windows.Forms.Label();
            this.panelTotalBPJS = new System.Windows.Forms.Panel();
            this.labelTotalBPJS = new System.Windows.Forms.Label();
            this.labelBPJSTitle = new System.Windows.Forms.Label();
            this.panelSubtotal = new System.Windows.Forms.Panel();
            this.labelTotalSubtotal = new System.Windows.Forms.Label();
            this.labelSubtotalTitle = new System.Windows.Forms.Label();
            this.panelTotalTransaksi = new System.Windows.Forms.Panel();
            this.labelTotalTransaksi = new System.Windows.Forms.Label();
            this.labelTransaksiTitle = new System.Windows.Forms.Label();
            this.dgvLaporan = new System.Windows.Forms.DataGridView();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnTampilkan = new System.Windows.Forms.Button();
            this.tbCari = new System.Windows.Forms.TextBox();
            this.labelCari = new System.Windows.Forms.Label();
            this.cbMetodeBayar = new System.Windows.Forms.ComboBox();
            this.labelMetode = new System.Windows.Forms.Label();
            this.cbJenisPasien = new System.Windows.Forms.ComboBox();
            this.labelJenisPasien = new System.Windows.Forms.Label();
            this.dtpAkhir = new System.Windows.Forms.DateTimePicker();
            this.labelAkhir = new System.Windows.Forms.Label();
            this.dtpMulai = new System.Windows.Forms.DateTimePicker();
            this.labelMulai = new System.Windows.Forms.Label();
            this.cbPeriode = new System.Windows.Forms.ComboBox();
            this.labelPeriode = new System.Windows.Forms.Label();
            this.labelFilter = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelSubJudul = new System.Windows.Forms.Label();
            this.labelJudul = new System.Windows.Forms.Label();
            this.cbStatusKunjungan = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelSidebar.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.panelSummary.SuspendLayout();
            this.panelTotalKembali.SuspendLayout();
            this.panelTotalBayar.SuspendLayout();
            this.panelTotalDiskon.SuspendLayout();
            this.panelTotalBPJS.SuspendLayout();
            this.panelSubtotal.SuspendLayout();
            this.panelTotalTransaksi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaporan)).BeginInit();
            this.panelFilter.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.White;
            this.panelSidebar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSidebar.Controls.Add(this.btnRekap);
            this.panelSidebar.Controls.Add(this.btnLaporanKunjungan);
            this.panelSidebar.Controls.Add(this.btnLaporanTransaksi);
            this.panelSidebar.Controls.Add(this.labelMenu);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(340, 1350);
            this.panelSidebar.TabIndex = 0;
            // 
            // btnRekap
            // 
            this.btnRekap.BackColor = System.Drawing.Color.White;
            this.btnRekap.FlatAppearance.BorderSize = 0;
            this.btnRekap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRekap.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnRekap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.btnRekap.Location = new System.Drawing.Point(22, 236);
            this.btnRekap.Name = "btnRekap";
            this.btnRekap.Size = new System.Drawing.Size(297, 52);
            this.btnRekap.TabIndex = 3;
            this.btnRekap.Text = "Rekap Ringkasan";
            this.btnRekap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRekap.UseVisualStyleBackColor = false;
            this.btnRekap.Click += new System.EventHandler(this.btnRekap_Click);
            // 
            // btnLaporanKunjungan
            // 
            this.btnLaporanKunjungan.BackColor = System.Drawing.Color.White;
            this.btnLaporanKunjungan.FlatAppearance.BorderSize = 0;
            this.btnLaporanKunjungan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLaporanKunjungan.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnLaporanKunjungan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.btnLaporanKunjungan.Location = new System.Drawing.Point(22, 178);
            this.btnLaporanKunjungan.Name = "btnLaporanKunjungan";
            this.btnLaporanKunjungan.Size = new System.Drawing.Size(297, 52);
            this.btnLaporanKunjungan.TabIndex = 2;
            this.btnLaporanKunjungan.Text = "Laporan Kunjungan";
            this.btnLaporanKunjungan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLaporanKunjungan.UseVisualStyleBackColor = false;
            this.btnLaporanKunjungan.Click += new System.EventHandler(this.btnLaporanKunjungan_Click);
            // 
            // btnLaporanTransaksi
            // 
            this.btnLaporanTransaksi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLaporanTransaksi.FlatAppearance.BorderSize = 0;
            this.btnLaporanTransaksi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLaporanTransaksi.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnLaporanTransaksi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLaporanTransaksi.Location = new System.Drawing.Point(22, 120);
            this.btnLaporanTransaksi.Name = "btnLaporanTransaksi";
            this.btnLaporanTransaksi.Size = new System.Drawing.Size(297, 52);
            this.btnLaporanTransaksi.TabIndex = 1;
            this.btnLaporanTransaksi.Text = "Laporan Transaksi";
            this.btnLaporanTransaksi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLaporanTransaksi.UseVisualStyleBackColor = false;
            this.btnLaporanTransaksi.Click += new System.EventHandler(this.btnLaporanTransaksi_Click);
            // 
            // labelMenu
            // 
            this.labelMenu.AutoSize = true;
            this.labelMenu.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.labelMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelMenu.Location = new System.Drawing.Point(31, 45);
            this.labelMenu.Name = "labelMenu";
            this.labelMenu.Size = new System.Drawing.Size(157, 41);
            this.labelMenu.TabIndex = 0;
            this.labelMenu.Text = "LAPORAN";
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.panelContent.Controls.Add(this.labelInfo);
            this.panelContent.Controls.Add(this.panelSummary);
            this.panelContent.Controls.Add(this.dgvLaporan);
            this.panelContent.Controls.Add(this.panelFilter);
            this.panelContent.Controls.Add(this.panelHeader);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(340, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(18);
            this.panelContent.Size = new System.Drawing.Size(2077, 1350);
            this.panelContent.TabIndex = 1;
            // 
            // labelInfo
            // 
            this.labelInfo.BackColor = System.Drawing.Color.White;
            this.labelInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelInfo.ForeColor = System.Drawing.Color.DimGray;
            this.labelInfo.Location = new System.Drawing.Point(18, 1286);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.labelInfo.Size = new System.Drawing.Size(2041, 46);
            this.labelInfo.TabIndex = 4;
            this.labelInfo.Text = "Data sesuai dengan filter yang dipilih.";
            this.labelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelSummary
            // 
            this.panelSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.panelSummary.Controls.Add(this.panelTotalKembali);
            this.panelSummary.Controls.Add(this.panelTotalBayar);
            this.panelSummary.Controls.Add(this.panelTotalDiskon);
            this.panelSummary.Controls.Add(this.panelTotalBPJS);
            this.panelSummary.Controls.Add(this.panelSubtotal);
            this.panelSummary.Controls.Add(this.panelTotalTransaksi);
            this.panelSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSummary.Location = new System.Drawing.Point(18, 1171);
            this.panelSummary.Name = "panelSummary";
            this.panelSummary.Padding = new System.Windows.Forms.Padding(0, 16, 0, 0);
            this.panelSummary.Size = new System.Drawing.Size(2041, 183);
            this.panelSummary.TabIndex = 3;
            // 
            // panelTotalKembali
            // 
            this.panelTotalKembali.BackColor = System.Drawing.Color.White;
            this.panelTotalKembali.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTotalKembali.Controls.Add(this.labelTotalKembali);
            this.panelTotalKembali.Controls.Add(this.labelKembaliTitle);
            this.panelTotalKembali.Location = new System.Drawing.Point(1244, 10);
            this.panelTotalKembali.Name = "panelTotalKembali";
            this.panelTotalKembali.Size = new System.Drawing.Size(234, 106);
            this.panelTotalKembali.TabIndex = 5;
            // 
            // labelTotalKembali
            // 
            this.labelTotalKembali.AutoSize = true;
            this.labelTotalKembali.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.labelTotalKembali.Location = new System.Drawing.Point(18, 43);
            this.labelTotalKembali.Name = "labelTotalKembali";
            this.labelTotalKembali.Size = new System.Drawing.Size(86, 45);
            this.labelTotalKembali.TabIndex = 1;
            this.labelTotalKembali.Text = "Rp 0";
            // 
            // labelKembaliTitle
            // 
            this.labelKembaliTitle.AutoSize = true;
            this.labelKembaliTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.labelKembaliTitle.Location = new System.Drawing.Point(18, 13);
            this.labelKembaliTitle.Name = "labelKembaliTitle";
            this.labelKembaliTitle.Size = new System.Drawing.Size(155, 31);
            this.labelKembaliTitle.TabIndex = 0;
            this.labelKembaliTitle.Text = "Total Kembali";
            // 
            // panelTotalBayar
            // 
            this.panelTotalBayar.BackColor = System.Drawing.Color.White;
            this.panelTotalBayar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTotalBayar.Controls.Add(this.labelTotalBayar);
            this.panelTotalBayar.Controls.Add(this.labelTotalBayarTitle);
            this.panelTotalBayar.Location = new System.Drawing.Point(987, 10);
            this.panelTotalBayar.Name = "panelTotalBayar";
            this.panelTotalBayar.Size = new System.Drawing.Size(251, 106);
            this.panelTotalBayar.TabIndex = 4;
            // 
            // labelTotalBayar
            // 
            this.labelTotalBayar.AutoSize = true;
            this.labelTotalBayar.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.labelTotalBayar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(220)))));
            this.labelTotalBayar.Location = new System.Drawing.Point(18, 43);
            this.labelTotalBayar.Name = "labelTotalBayar";
            this.labelTotalBayar.Size = new System.Drawing.Size(86, 45);
            this.labelTotalBayar.TabIndex = 1;
            this.labelTotalBayar.Text = "Rp 0";
            // 
            // labelTotalBayarTitle
            // 
            this.labelTotalBayarTitle.AutoSize = true;
            this.labelTotalBayarTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.labelTotalBayarTitle.Location = new System.Drawing.Point(18, 13);
            this.labelTotalBayarTitle.Name = "labelTotalBayarTitle";
            this.labelTotalBayarTitle.Size = new System.Drawing.Size(130, 31);
            this.labelTotalBayarTitle.TabIndex = 0;
            this.labelTotalBayarTitle.Text = "Total Bayar";
            // 
            // panelTotalDiskon
            // 
            this.panelTotalDiskon.BackColor = System.Drawing.Color.White;
            this.panelTotalDiskon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTotalDiskon.Controls.Add(this.labelTotalDiskon);
            this.panelTotalDiskon.Controls.Add(this.labelDiskonTitle);
            this.panelTotalDiskon.Location = new System.Drawing.Point(734, 10);
            this.panelTotalDiskon.Name = "panelTotalDiskon";
            this.panelTotalDiskon.Size = new System.Drawing.Size(247, 106);
            this.panelTotalDiskon.TabIndex = 3;
            // 
            // labelTotalDiskon
            // 
            this.labelTotalDiskon.AutoSize = true;
            this.labelTotalDiskon.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.labelTotalDiskon.ForeColor = System.Drawing.Color.OrangeRed;
            this.labelTotalDiskon.Location = new System.Drawing.Point(18, 43);
            this.labelTotalDiskon.Name = "labelTotalDiskon";
            this.labelTotalDiskon.Size = new System.Drawing.Size(86, 45);
            this.labelTotalDiskon.TabIndex = 1;
            this.labelTotalDiskon.Text = "Rp 0";
            // 
            // labelDiskonTitle
            // 
            this.labelDiskonTitle.AutoSize = true;
            this.labelDiskonTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.labelDiskonTitle.Location = new System.Drawing.Point(18, 13);
            this.labelDiskonTitle.Name = "labelDiskonTitle";
            this.labelDiskonTitle.Size = new System.Drawing.Size(143, 31);
            this.labelDiskonTitle.TabIndex = 0;
            this.labelDiskonTitle.Text = "Total Diskon";
            // 
            // panelTotalBPJS
            // 
            this.panelTotalBPJS.BackColor = System.Drawing.Color.White;
            this.panelTotalBPJS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTotalBPJS.Controls.Add(this.labelTotalBPJS);
            this.panelTotalBPJS.Controls.Add(this.labelBPJSTitle);
            this.panelTotalBPJS.Location = new System.Drawing.Point(476, 10);
            this.panelTotalBPJS.Name = "panelTotalBPJS";
            this.panelTotalBPJS.Size = new System.Drawing.Size(252, 106);
            this.panelTotalBPJS.TabIndex = 2;
            // 
            // labelTotalBPJS
            // 
            this.labelTotalBPJS.AutoSize = true;
            this.labelTotalBPJS.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.labelTotalBPJS.ForeColor = System.Drawing.Color.Green;
            this.labelTotalBPJS.Location = new System.Drawing.Point(18, 43);
            this.labelTotalBPJS.Name = "labelTotalBPJS";
            this.labelTotalBPJS.Size = new System.Drawing.Size(86, 45);
            this.labelTotalBPJS.TabIndex = 1;
            this.labelTotalBPJS.Text = "Rp 0";
            // 
            // labelBPJSTitle
            // 
            this.labelBPJSTitle.AutoSize = true;
            this.labelBPJSTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.labelBPJSTitle.Location = new System.Drawing.Point(18, 13);
            this.labelBPJSTitle.Name = "labelBPJSTitle";
            this.labelBPJSTitle.Size = new System.Drawing.Size(197, 31);
            this.labelBPJSTitle.TabIndex = 0;
            this.labelBPJSTitle.Text = "Total Diskon BPJS";
            // 
            // panelSubtotal
            // 
            this.panelSubtotal.BackColor = System.Drawing.Color.White;
            this.panelSubtotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSubtotal.Controls.Add(this.labelTotalSubtotal);
            this.panelSubtotal.Controls.Add(this.labelSubtotalTitle);
            this.panelSubtotal.Location = new System.Drawing.Point(220, 10);
            this.panelSubtotal.Name = "panelSubtotal";
            this.panelSubtotal.Size = new System.Drawing.Size(250, 106);
            this.panelSubtotal.TabIndex = 1;
            // 
            // labelTotalSubtotal
            // 
            this.labelTotalSubtotal.AutoSize = true;
            this.labelTotalSubtotal.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.labelTotalSubtotal.Location = new System.Drawing.Point(18, 43);
            this.labelTotalSubtotal.Name = "labelTotalSubtotal";
            this.labelTotalSubtotal.Size = new System.Drawing.Size(86, 45);
            this.labelTotalSubtotal.TabIndex = 1;
            this.labelTotalSubtotal.Text = "Rp 0";
            // 
            // labelSubtotalTitle
            // 
            this.labelSubtotalTitle.AutoSize = true;
            this.labelSubtotalTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.labelSubtotalTitle.Location = new System.Drawing.Point(18, 13);
            this.labelSubtotalTitle.Name = "labelSubtotalTitle";
            this.labelSubtotalTitle.Size = new System.Drawing.Size(159, 31);
            this.labelSubtotalTitle.TabIndex = 0;
            this.labelSubtotalTitle.Text = "Total Subtotal";
            // 
            // panelTotalTransaksi
            // 
            this.panelTotalTransaksi.BackColor = System.Drawing.Color.White;
            this.panelTotalTransaksi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTotalTransaksi.Controls.Add(this.labelTotalTransaksi);
            this.panelTotalTransaksi.Controls.Add(this.labelTransaksiTitle);
            this.panelTotalTransaksi.Location = new System.Drawing.Point(0, 10);
            this.panelTotalTransaksi.Name = "panelTotalTransaksi";
            this.panelTotalTransaksi.Size = new System.Drawing.Size(214, 106);
            this.panelTotalTransaksi.TabIndex = 0;
            // 
            // labelTotalTransaksi
            // 
            this.labelTotalTransaksi.AutoSize = true;
            this.labelTotalTransaksi.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.labelTotalTransaksi.Location = new System.Drawing.Point(20, 42);
            this.labelTotalTransaksi.Name = "labelTotalTransaksi";
            this.labelTotalTransaksi.Size = new System.Drawing.Size(39, 47);
            this.labelTotalTransaksi.TabIndex = 1;
            this.labelTotalTransaksi.Text = "0";
            // 
            // labelTransaksiTitle
            // 
            this.labelTransaksiTitle.AutoSize = true;
            this.labelTransaksiTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.labelTransaksiTitle.Location = new System.Drawing.Point(20, 13);
            this.labelTransaksiTitle.Name = "labelTransaksiTitle";
            this.labelTransaksiTitle.Size = new System.Drawing.Size(166, 31);
            this.labelTransaksiTitle.TabIndex = 0;
            this.labelTransaksiTitle.Text = "Total Transaksi";
            // 
            // dgvLaporan
            // 
            this.dgvLaporan.AllowUserToAddRows = false;
            this.dgvLaporan.AllowUserToDeleteRows = false;
            this.dgvLaporan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLaporan.BackgroundColor = System.Drawing.Color.White;
            this.dgvLaporan.ColumnHeadersHeight = 42;
            this.dgvLaporan.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvLaporan.EnableHeadersVisualStyles = false;
            this.dgvLaporan.Location = new System.Drawing.Point(18, 409);
            this.dgvLaporan.Name = "dgvLaporan";
            this.dgvLaporan.ReadOnly = true;
            this.dgvLaporan.RowHeadersVisible = false;
            this.dgvLaporan.RowTemplate.Height = 32;
            this.dgvLaporan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLaporan.Size = new System.Drawing.Size(2041, 762);
            this.dgvLaporan.TabIndex = 2;
            // 
            // panelFilter
            // 
            this.panelFilter.BackColor = System.Drawing.Color.White;
            this.panelFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFilter.Controls.Add(this.cbStatusKunjungan);
            this.panelFilter.Controls.Add(this.label1);
            this.panelFilter.Controls.Add(this.btnReset);
            this.panelFilter.Controls.Add(this.btnTampilkan);
            this.panelFilter.Controls.Add(this.tbCari);
            this.panelFilter.Controls.Add(this.labelCari);
            this.panelFilter.Controls.Add(this.cbMetodeBayar);
            this.panelFilter.Controls.Add(this.labelMetode);
            this.panelFilter.Controls.Add(this.cbJenisPasien);
            this.panelFilter.Controls.Add(this.labelJenisPasien);
            this.panelFilter.Controls.Add(this.dtpAkhir);
            this.panelFilter.Controls.Add(this.labelAkhir);
            this.panelFilter.Controls.Add(this.dtpMulai);
            this.panelFilter.Controls.Add(this.labelMulai);
            this.panelFilter.Controls.Add(this.cbPeriode);
            this.panelFilter.Controls.Add(this.labelPeriode);
            this.panelFilter.Controls.Add(this.labelFilter);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilter.Location = new System.Drawing.Point(18, 157);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(2041, 252);
            this.panelFilter.TabIndex = 1;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.White;
            this.btnReset.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnReset.Location = new System.Drawing.Point(1267, 153);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(150, 42);
            this.btnReset.TabIndex = 14;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnTampilkan
            // 
            this.btnTampilkan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnTampilkan.FlatAppearance.BorderSize = 0;
            this.btnTampilkan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTampilkan.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnTampilkan.ForeColor = System.Drawing.Color.White;
            this.btnTampilkan.Location = new System.Drawing.Point(1100, 153);
            this.btnTampilkan.Name = "btnTampilkan";
            this.btnTampilkan.Size = new System.Drawing.Size(150, 42);
            this.btnTampilkan.TabIndex = 13;
            this.btnTampilkan.Text = "Tampilkan";
            this.btnTampilkan.UseVisualStyleBackColor = false;
            this.btnTampilkan.Click += new System.EventHandler(this.btnTampilkan_Click);
            // 
            // tbCari
            // 
            this.tbCari.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbCari.Location = new System.Drawing.Point(32, 185);
            this.tbCari.Name = "tbCari";
            this.tbCari.Size = new System.Drawing.Size(470, 39);
            this.tbCari.TabIndex = 12;
            // 
            // labelCari
            // 
            this.labelCari.AutoSize = true;
            this.labelCari.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.labelCari.Location = new System.Drawing.Point(28, 153);
            this.labelCari.Name = "labelCari";
            this.labelCari.Size = new System.Drawing.Size(273, 31);
            this.labelCari.TabIndex = 11;
            this.labelCari.Text = "Cari Pasien / No. RM / ID";
            // 
            // cbMetodeBayar
            // 
            this.cbMetodeBayar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMetodeBayar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbMetodeBayar.FormattingEnabled = true;
            this.cbMetodeBayar.Items.AddRange(new object[] {
            "Semua",
            "Tunai",
            "Transfer",
            "BPJS"});
            this.cbMetodeBayar.Location = new System.Drawing.Point(999, 95);
            this.cbMetodeBayar.Name = "cbMetodeBayar";
            this.cbMetodeBayar.Size = new System.Drawing.Size(170, 40);
            this.cbMetodeBayar.TabIndex = 10;
            // 
            // labelMetode
            // 
            this.labelMetode.AutoSize = true;
            this.labelMetode.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.labelMetode.Location = new System.Drawing.Point(995, 63);
            this.labelMetode.Name = "labelMetode";
            this.labelMetode.Size = new System.Drawing.Size(160, 31);
            this.labelMetode.TabIndex = 9;
            this.labelMetode.Text = "Metode Bayar";
            // 
            // cbJenisPasien
            // 
            this.cbJenisPasien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbJenisPasien.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbJenisPasien.FormattingEnabled = true;
            this.cbJenisPasien.Items.AddRange(new object[] {
            "Semua",
            "Umum",
            "BPJS"});
            this.cbJenisPasien.Location = new System.Drawing.Point(779, 95);
            this.cbJenisPasien.Name = "cbJenisPasien";
            this.cbJenisPasien.Size = new System.Drawing.Size(190, 40);
            this.cbJenisPasien.TabIndex = 8;
            // 
            // labelJenisPasien
            // 
            this.labelJenisPasien.AutoSize = true;
            this.labelJenisPasien.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.labelJenisPasien.Location = new System.Drawing.Point(775, 63);
            this.labelJenisPasien.Name = "labelJenisPasien";
            this.labelJenisPasien.Size = new System.Drawing.Size(135, 31);
            this.labelJenisPasien.TabIndex = 7;
            this.labelJenisPasien.Text = "Jenis Pasien";
            // 
            // dtpAkhir
            // 
            this.dtpAkhir.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpAkhir.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAkhir.Location = new System.Drawing.Point(539, 96);
            this.dtpAkhir.Name = "dtpAkhir";
            this.dtpAkhir.Size = new System.Drawing.Size(210, 39);
            this.dtpAkhir.TabIndex = 6;
            // 
            // labelAkhir
            // 
            this.labelAkhir.AutoSize = true;
            this.labelAkhir.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.labelAkhir.Location = new System.Drawing.Point(535, 63);
            this.labelAkhir.Name = "labelAkhir";
            this.labelAkhir.Size = new System.Drawing.Size(157, 31);
            this.labelAkhir.TabIndex = 5;
            this.labelAkhir.Text = "Tanggal Akhir";
            // 
            // dtpMulai
            // 
            this.dtpMulai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpMulai.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpMulai.Location = new System.Drawing.Point(299, 96);
            this.dtpMulai.Name = "dtpMulai";
            this.dtpMulai.Size = new System.Drawing.Size(210, 39);
            this.dtpMulai.TabIndex = 4;
            // 
            // labelMulai
            // 
            this.labelMulai.AutoSize = true;
            this.labelMulai.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.labelMulai.Location = new System.Drawing.Point(295, 63);
            this.labelMulai.Name = "labelMulai";
            this.labelMulai.Size = new System.Drawing.Size(160, 31);
            this.labelMulai.TabIndex = 3;
            this.labelMulai.Text = "Tanggal Mulai";
            // 
            // cbPeriode
            // 
            this.cbPeriode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPeriode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbPeriode.FormattingEnabled = true;
            this.cbPeriode.Items.AddRange(new object[] {
            "Semua",
            "Hari Ini",
            "Minggu Ini",
            "Bulan Ini",
            "Rentang Tanggal"});
            this.cbPeriode.Location = new System.Drawing.Point(32, 95);
            this.cbPeriode.Name = "cbPeriode";
            this.cbPeriode.Size = new System.Drawing.Size(230, 40);
            this.cbPeriode.TabIndex = 2;
            // 
            // labelPeriode
            // 
            this.labelPeriode.AutoSize = true;
            this.labelPeriode.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.labelPeriode.Location = new System.Drawing.Point(28, 63);
            this.labelPeriode.Name = "labelPeriode";
            this.labelPeriode.Size = new System.Drawing.Size(93, 31);
            this.labelPeriode.TabIndex = 1;
            this.labelPeriode.Text = "Periode";
            // 
            // labelFilter
            // 
            this.labelFilter.AutoSize = true;
            this.labelFilter.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.labelFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelFilter.Location = new System.Drawing.Point(24, 16);
            this.labelFilter.Name = "labelFilter";
            this.labelFilter.Size = new System.Drawing.Size(93, 45);
            this.labelFilter.TabIndex = 0;
            this.labelFilter.Text = "Filter";
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelHeader.Controls.Add(this.labelSubJudul);
            this.panelHeader.Controls.Add(this.labelJudul);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(18, 18);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(2041, 139);
            this.panelHeader.TabIndex = 0;
            // 
            // labelSubJudul
            // 
            this.labelSubJudul.AutoSize = true;
            this.labelSubJudul.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelSubJudul.ForeColor = System.Drawing.Color.DimGray;
            this.labelSubJudul.Location = new System.Drawing.Point(28, 87);
            this.labelSubJudul.Name = "labelSubJudul";
            this.labelSubJudul.Size = new System.Drawing.Size(315, 32);
            this.labelSubJudul.TabIndex = 1;
            this.labelSubJudul.Text = "Laporan pembayaran pasien";
            // 
            // labelJudul
            // 
            this.labelJudul.AutoSize = true;
            this.labelJudul.Font = new System.Drawing.Font("Segoe UI Semibold", 17F, System.Drawing.FontStyle.Bold);
            this.labelJudul.Location = new System.Drawing.Point(20, 26);
            this.labelJudul.Name = "labelJudul";
            this.labelJudul.Size = new System.Drawing.Size(398, 62);
            this.labelJudul.TabIndex = 0;
            this.labelJudul.Text = "Laporan Transaksi";
            // 
            // cbStatusKunjungan
            // 
            this.cbStatusKunjungan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatusKunjungan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbStatusKunjungan.FormattingEnabled = true;
            this.cbStatusKunjungan.Items.AddRange(new object[] {
            "Semua",
            "Menunggu",
            "Menginap",
            "Payment",
            "Selesai"});
            this.cbStatusKunjungan.Location = new System.Drawing.Point(1198, 95);
            this.cbStatusKunjungan.Name = "cbStatusKunjungan";
            this.cbStatusKunjungan.Size = new System.Drawing.Size(219, 40);
            this.cbStatusKunjungan.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(1194, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 31);
            this.label1.TabIndex = 15;
            this.label1.Text = "Status Kunjungan";
            // 
            // menuLaporan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(2417, 1350);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelSidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "menuLaporan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "menuLaporan";
            this.Load += new System.EventHandler(this.menuLaporan_Load);
            this.panelSidebar.ResumeLayout(false);
            this.panelSidebar.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.panelSummary.ResumeLayout(false);
            this.panelTotalKembali.ResumeLayout(false);
            this.panelTotalKembali.PerformLayout();
            this.panelTotalBayar.ResumeLayout(false);
            this.panelTotalBayar.PerformLayout();
            this.panelTotalDiskon.ResumeLayout(false);
            this.panelTotalDiskon.PerformLayout();
            this.panelTotalBPJS.ResumeLayout(false);
            this.panelTotalBPJS.PerformLayout();
            this.panelSubtotal.ResumeLayout(false);
            this.panelSubtotal.PerformLayout();
            this.panelTotalTransaksi.ResumeLayout(false);
            this.panelTotalTransaksi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaporan)).EndInit();
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Button btnRekap;
        private System.Windows.Forms.Button btnLaporanKunjungan;
        private System.Windows.Forms.Button btnLaporanTransaksi;
        private System.Windows.Forms.Label labelMenu;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelSubJudul;
        private System.Windows.Forms.Label labelJudul;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnTampilkan;
        private System.Windows.Forms.TextBox tbCari;
        private System.Windows.Forms.Label labelCari;
        private System.Windows.Forms.ComboBox cbMetodeBayar;
        private System.Windows.Forms.Label labelMetode;
        private System.Windows.Forms.ComboBox cbJenisPasien;
        private System.Windows.Forms.Label labelJenisPasien;
        private System.Windows.Forms.DateTimePicker dtpAkhir;
        private System.Windows.Forms.Label labelAkhir;
        private System.Windows.Forms.DateTimePicker dtpMulai;
        private System.Windows.Forms.Label labelMulai;
        private System.Windows.Forms.ComboBox cbPeriode;
        private System.Windows.Forms.Label labelPeriode;
        private System.Windows.Forms.Label labelFilter;
        private System.Windows.Forms.DataGridView dgvLaporan;
        private System.Windows.Forms.Panel panelSummary;
        private System.Windows.Forms.Panel panelTotalKembali;
        private System.Windows.Forms.Label labelTotalKembali;
        private System.Windows.Forms.Label labelKembaliTitle;
        private System.Windows.Forms.Panel panelTotalBayar;
        private System.Windows.Forms.Label labelTotalBayar;
        private System.Windows.Forms.Label labelTotalBayarTitle;
        private System.Windows.Forms.Panel panelTotalDiskon;
        private System.Windows.Forms.Label labelTotalDiskon;
        private System.Windows.Forms.Label labelDiskonTitle;
        private System.Windows.Forms.Panel panelTotalBPJS;
        private System.Windows.Forms.Label labelTotalBPJS;
        private System.Windows.Forms.Label labelBPJSTitle;
        private System.Windows.Forms.Panel panelSubtotal;
        private System.Windows.Forms.Label labelTotalSubtotal;
        private System.Windows.Forms.Label labelSubtotalTitle;
        private System.Windows.Forms.Panel panelTotalTransaksi;
        private System.Windows.Forms.Label labelTotalTransaksi;
        private System.Windows.Forms.Label labelTransaksiTitle;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.ComboBox cbStatusKunjungan;
        private System.Windows.Forms.Label label1;
    }
}