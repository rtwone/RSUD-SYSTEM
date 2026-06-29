using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace RSUD_SYSTEM {
    public partial class menuLaporan : Form {

        string modeLaporan = "transaksi";

        public menuLaporan() {
            InitializeComponent();
        }

        private void menuLaporan_Load(object sender, EventArgs e) {
            cbPeriode.SelectedIndex = 4;
            cbJenisPasien.SelectedIndex = 0;
            cbMetodeBayar.SelectedIndex = 0;
            cbStatusKunjungan.SelectedIndex = 0;

            cbStatusKunjungan.Enabled = false;

            dtpMulai.Value = DateTime.Now.AddMonths(-1);
            dtpAkhir.Value = DateTime.Now;

            StyleDGV();
            LoadLaporanTransaksi();
        }

        void StyleDGV() {
            dgvLaporan.EnableHeadersVisualStyles = false;
            dgvLaporan.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 247, 255);
            dgvLaporan.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvLaporan.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9);
            dgvLaporan.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgvLaporan.BackgroundColor = Color.White;
            dgvLaporan.GridColor = Color.FromArgb(230, 230, 230);
            dgvLaporan.RowHeadersVisible = false;
            dgvLaporan.AllowUserToAddRows = false;
            dgvLaporan.AllowUserToDeleteRows = false;
            dgvLaporan.ReadOnly = true;
            dgvLaporan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLaporan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLaporan.ReadOnly = true;
            dgvLaporan.AllowUserToResizeColumns = false;
            dgvLaporan.AllowUserToResizeRows = false;
            dgvLaporan.MultiSelect = false;
        }

        void SetActiveButton(Button active) {
            btnLaporanTransaksi.BackColor = Color.White;
            btnLaporanKunjungan.BackColor = Color.White;
            btnRekap.BackColor = Color.White;

            btnLaporanTransaksi.ForeColor = Color.FromArgb(0, 64, 64);
            btnLaporanKunjungan.ForeColor = Color.FromArgb(0, 64, 64);
            btnRekap.ForeColor = Color.FromArgb(0, 64, 64);

            active.BackColor = Color.FromArgb(50, 0, 64, 64);
            active.ForeColor = Color.FromArgb(0, 64, 64);
        }

        string FilterTanggal(string kolomTanggal) {
            string where = "";
            if (cbPeriode.Text == "Hari Ini") {
                where += $" AND DATE({kolomTanggal}) = CURDATE() ";
            } else if (cbPeriode.Text == "Minggu Ini") {
                where += $" AND YEARWEEK({kolomTanggal}, 1) = YEARWEEK(CURDATE(), 1) ";
            } else if (cbPeriode.Text == "Bulan Ini") {
                where += $" AND MONTH({kolomTanggal}) = MONTH(CURDATE()) AND YEAR({kolomTanggal}) = YEAR(CURDATE()) ";
            } else if (cbPeriode.Text == "Rentang Tanggal") {
                where += $" AND DATE({kolomTanggal}) BETWEEN @mulai AND @akhir ";
            }
            return where;
        }

        void LoadLaporanTransaksi() {
            modeLaporan = "transaksi";

            labelJudul.Text = "Laporan Transaksi";
            labelSubJudul.Text = "Laporan pembayaran pasien";
            labelInfo.Text = "Data transaksi sesuai filter yang dipilih.";

            SetActiveButton(btnLaporanTransaksi);

            string query = @"
SELECT
    t.id_transaksi AS 'ID Transaksi',
    DATE_FORMAT(tanggal_transaksi, '%d/%m/%Y %H:%i') AS 'Tanggal',
    t.nama_pasien AS 'Nama Pasien',
    t.no_rm AS 'No. RM',
    t.jenis_pasien AS 'Jenis Pasien',
    CONCAT('Rp ', FORMAT(t.subtotal, 0)) AS 'Subtotal',
    CONCAT('Rp ', FORMAT(IFNULL(t.diskon_bpjs, 0), 0)) AS 'Diskon BPJS',
    CONCAT('Rp ', FORMAT(t.diskon, 0)) AS 'Diskon',
    CONCAT('Rp ', FORMAT(t.total_bayar, 0)) AS 'Total Bayar',
    t.metode_pembayaran AS 'Metode Bayar',
    CONCAT('Rp ', FORMAT(t.bayar, 0)) AS 'Bayar',
    CONCAT('Rp ', FORMAT(t.kembali, 0)) AS 'Kembali'
FROM transaksi t
WHERE 1=1 ";

            query += FilterTanggal("tanggal_transaksi");

            if (cbJenisPasien.Text != "Semua")
                query += " AND t.jenis_pasien = @jenis ";

            if (cbMetodeBayar.Text != "Semua")
                query += " AND t.metode_pembayaran = @metode ";

            if (!string.IsNullOrWhiteSpace(tbCari.Text))
                query += " AND (t.nama_pasien LIKE @cari OR t.no_rm LIKE @cari OR t.id_transaksi LIKE @cari) ";

            query += " ORDER BY t.tanggal_transaksi DESC";

            DataTable dt = DBHelper.GetData(query,
                new MySqlParameter("@mulai", dtpMulai.Value.ToString("yyyy-MM-dd")),
                new MySqlParameter("@akhir", dtpAkhir.Value.ToString("yyyy-MM-dd")),
                new MySqlParameter("@jenis", cbJenisPasien.Text),
                new MySqlParameter("@metode", cbMetodeBayar.Text),
                new MySqlParameter("@cari", "%" + tbCari.Text + "%")
            );

            dgvLaporan.DataSource = dt;
            HitungSummaryTransaksi();
        }

        void LoadLaporanKunjungan() {
            modeLaporan = "kunjungan";

            labelJudul.Text = "Laporan Kunjungan";
            labelSubJudul.Text = "Laporan data kunjungan pasien";
            labelInfo.Text = "Data kunjungan sesuai filter yang dipilih.";

            SetActiveButton(btnLaporanKunjungan);

            string query = @"
SELECT
    k.id_kunjungan AS 'ID Kunjungan',
    DATE_FORMAT(k.tanggal, '%d/%m/%Y %H:%i') AS 'Tanggal',
    p.nama AS 'Nama Pasien',
    k.no_rm AS 'No. RM',
    k.jenis_pasien AS 'Jenis Pasien',
    IFNULL(pol.nama_poli, 'IGD') AS 'Poli / Unit',
    IFNULL(d.nama_dokter, '-') AS 'Dokter',
    k.keluhan AS 'Keluhan',
    k.status AS 'Status'
FROM kunjungan k
JOIN pasien p ON k.no_rm = p.no_rm
LEFT JOIN poli pol ON k.id_poli = pol.id_poli
LEFT JOIN dokter d ON k.id_dokter = d.id_dokter
WHERE 1=1 ";

            query += FilterTanggal("k.tanggal");

            if (cbJenisPasien.Text != "Semua")
                query += " AND k.jenis_pasien = @jenis ";

            if (cbStatusKunjungan.Text != "Semua")
                query += " AND k.status = @status";

            if (!string.IsNullOrWhiteSpace(tbCari.Text))
                query += " AND (p.nama LIKE @cari OR k.no_rm LIKE @cari OR k.id_kunjungan LIKE @cari) ";

            query += " ORDER BY k.tanggal DESC";

            DataTable dt = DBHelper.GetData(query,
                new MySqlParameter("@mulai", dtpMulai.Value.ToString("yyyy-MM-dd")),
                new MySqlParameter("@akhir", dtpAkhir.Value.ToString("yyyy-MM-dd")),
                new MySqlParameter("@jenis", cbJenisPasien.Text),
                new MySqlParameter("@status", cbStatusKunjungan.Text),
                new MySqlParameter("@cari", "%" + tbCari.Text + "%")
            );

            dgvLaporan.DataSource = dt;
            HitungSummaryKunjungan();
        }

        void LoadRekapRingkasan() {
            modeLaporan = "rekap";

            labelJudul.Text = "Rekap Ringkasan";
            labelSubJudul.Text = "Ringkasan total transaksi dan kunjungan";
            labelInfo.Text = "Rekap data berdasarkan periode yang dipilih.";
            SetActiveButton(btnRekap);

            string query = @"
SELECT
    'Total Kunjungan' AS 'Keterangan',
    COUNT(k.id_kunjungan) AS 'Jumlah',
    '-' AS 'Nominal'
FROM kunjungan k
WHERE 1=1 ";
            query += FilterTanggal("k.tanggal");
            query += @"
UNION ALL
SELECT
    'Total Transaksi',
    COUNT(t.id_transaksi),
    CONCAT('Rp ', FORMAT(IFNULL(SUM(t.total_bayar), 0), 0))
FROM transaksi t
WHERE 1=1 ";

            query += FilterTanggal("t.tanggal_transaksi");

            DataTable dt = DBHelper.GetData(query,
                new MySqlParameter("@mulai", dtpMulai.Value.ToString("yyyy-MM-dd")),
                new MySqlParameter("@akhir", dtpAkhir.Value.ToString("yyyy-MM-dd"))
            );

            dgvLaporan.DataSource = dt;
            HitungSummaryTransaksi();
        }

        void HitungSummaryTransaksi() {
            string query = @"
SELECT
    COUNT(*) AS total_transaksi,
    IFNULL(SUM(subtotal), 0) AS subtotal,
    IFNULL(SUM(diskon_bpjs), 0) AS diskon_bpjs,
    IFNULL(SUM(diskon), 0) AS diskon,
    IFNULL(SUM(total_bayar), 0) AS total_bayar,
    IFNULL(SUM(kembali), 0) AS kembali
FROM transaksi
WHERE 1=1 ";

            query += FilterTanggal("tanggal_transaksi");

            if (cbJenisPasien.Text != "Semua")
                query += " AND jenis_pasien = @jenis ";

            if (cbMetodeBayar.Text != "Semua")
                query += " AND metode_pembayaran = @metode ";

            if (!string.IsNullOrWhiteSpace(tbCari.Text))
                query += " AND (nama_pasien LIKE @cari OR no_rm LIKE @cari OR id_transaksi LIKE @cari) ";

            DataTable dt = DBHelper.GetData(query,
                new MySqlParameter("@mulai", dtpMulai.Value.ToString("yyyy-MM-dd")),
                new MySqlParameter("@akhir", dtpAkhir.Value.ToString("yyyy-MM-dd")),
                new MySqlParameter("@jenis", cbJenisPasien.Text),
                new MySqlParameter("@metode", cbMetodeBayar.Text),
                new MySqlParameter("@cari", "%" + tbCari.Text + "%")
            );

            if (dt.Rows.Count > 0) {
                labelTotalTransaksi.Text = dt.Rows[0]["total_transaksi"].ToString();
                labelTotalSubtotal.Text = "Rp " + Convert.ToInt64(dt.Rows[0]["subtotal"]).ToString("N0");
                labelTotalBPJS.Text = "Rp " + Convert.ToInt64(dt.Rows[0]["diskon_bpjs"]).ToString("N0");
                labelTotalDiskon.Text = "Rp " + Convert.ToInt64(dt.Rows[0]["diskon"]).ToString("N0");
                labelTotalBayar.Text = "Rp " + Convert.ToInt64(dt.Rows[0]["total_bayar"]).ToString("N0");
                labelTotalKembali.Text = "Rp " + Convert.ToInt64(dt.Rows[0]["kembali"]).ToString("N0");
            }
        }

        void HitungSummaryKunjungan() {
            labelTotalTransaksi.Text = dgvLaporan.Rows.Count.ToString();
            labelTotalSubtotal.Text = "Rp 0";
            labelTotalBPJS.Text = "Rp 0";
            labelTotalDiskon.Text = "Rp 0";
            labelTotalBayar.Text = "Rp 0";
            labelTotalKembali.Text = "Rp 0";
        }

        private void btnLaporanTransaksi_Click(object sender, EventArgs e) {
            cbMetodeBayar.Enabled = true;
            cbStatusKunjungan.Enabled = false;
            LoadLaporanTransaksi();
        }

        private void btnLaporanKunjungan_Click(object sender, EventArgs e) {
            cbMetodeBayar.Enabled = false;
            cbStatusKunjungan.Enabled = true;
            LoadLaporanKunjungan();
        }

        private void btnRekap_Click(object sender, EventArgs e) {
            cbMetodeBayar.Enabled = false;
            cbStatusKunjungan.Enabled = false;
            LoadRekapRingkasan();
        }

        private void btnTampilkan_Click(object sender, EventArgs e) {
            if (modeLaporan == "transaksi")
                LoadLaporanTransaksi();
            else if (modeLaporan == "kunjungan")
                LoadLaporanKunjungan();
            else
                LoadRekapRingkasan();
        }

        private void btnReset_Click(object sender, EventArgs e) {
            cbPeriode.SelectedIndex = 4;
            cbJenisPasien.SelectedIndex = 0;
            cbMetodeBayar.SelectedIndex = 0;
            cbStatusKunjungan.SelectedIndex = 0;
            dtpMulai.Value = DateTime.Now.AddMonths(-1);
            dtpAkhir.Value = DateTime.Now;
            tbCari.Text = "";

            btnTampilkan_Click(sender, e);
        }

        private void btnTutup_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}