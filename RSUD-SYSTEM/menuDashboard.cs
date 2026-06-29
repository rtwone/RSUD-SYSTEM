using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

using System.Globalization;

namespace RSUD_SYSTEM {
    public partial class menuDashboard : Form {
        public menuDashboard() {
            InitializeComponent();
        }

        private void menuDashboard_Load(object sender, EventArgs e) {
            labelTanggal.Text = func.getTanggal();
            timer1.Interval = 1000; // 1000 ms = 1 detik
            timer1.Start();

            // Data Pasien Rawat Jalan
            string queryAllPasienRawatJalan = "SELECT * FROM kunjungan WHERE DATE(tanggal)=CURDATE() AND jenis_kunjungan='Rawat Jalan'";
            var dataPasienRawatJalan = DBHelper.GetData(queryAllPasienRawatJalan);
            labelCountPRJ.Text = dataPasienRawatJalan.Rows.Count.ToString("D3");

            // Data Pasien Rawat Inap
            string queryAllPasienRawatInap = "SELECT * FROM bed where status='Terisi'";
            var dataPasienRawatInap = DBHelper.GetData(queryAllPasienRawatInap);
            labelCountPRIA.Text = dataPasienRawatInap.Rows.Count.ToString("D3");

            // Data Pasien UGD/IGD
            string queryAllPasienIGD = "SELECT * FROM kunjungan WHERE DATE(tanggal)=CURDATE() AND jenis_kunjungan='UGD/IGD'";
            var dataPasienIGD = DBHelper.GetData(queryAllPasienIGD);
            labelCountIGD.Text = dataPasienIGD.Rows.Count.ToString("D3");

            // Data Kamar Tersedia
            string queryAllBed = "SELECT k.tipe_kamar, COUNT(b.id_bed) AS total_bed, SUM(CASE WHEN b.status = 'Terisi' THEN 1 ELSE 0 END) AS terisi, SUM(CASE WHEN b.status = 'Kosong' THEN 1 ELSE 0 END) AS tersedia FROM kamar k JOIN bed b ON k.id_kamar = b.id_kamar GROUP BY k.tipe_kamar";
            var dataAllBed = DBHelper.GetData(queryAllBed);
            labelCount.Text = dataAllBed.Rows[0]["tersedia"].ToString() + " / " + dataAllBed.Rows[0]["total_bed"].ToString() + "\n" +
                dataAllBed.Rows[1]["tersedia"].ToString() + " / " + dataAllBed.Rows[1]["total_bed"].ToString() + "\n" +
                dataAllBed.Rows[2]["tersedia"].ToString() + " / " + dataAllBed.Rows[2]["total_bed"].ToString();

            // Data Total Kunjungan
            string queryTotalKunjungan = "SELECT * FROM kunjungan WHERE DATE(tanggal)=CURDATE()";
            var dataTotalKunjungan = DBHelper.GetData(queryTotalKunjungan);
            labelCountKunjungan.Text = dataTotalKunjungan.Rows.Count.ToString("D3");

            dtpFrom.Value = DateTime.Now.AddDays(-7);
            dtpTo.Value = DateTime.Now;
            loadChartKunjungan(dtpFrom.Value, dtpTo.Value);

            setupGridHistoryPasien();
            styleHistoryTable();
            loadHistoryPasienHariIni();
        }

        void timer1_Tick(object sender, EventArgs e) {
            labelJam.Text = DateTime.Now.ToString("HH:mm:ss", new CultureInfo("id-ID"));
        }

        void loadChartKunjungan(DateTime fromDate, DateTime toDate) {
            chartKunjungan.Series.Clear();
            chartKunjungan.Titles.Clear();
            chartKunjungan.Legends.Clear();

            chartKunjungan.ResetAutoValues();
            
            Legend lg = new Legend();
            lg.Docking = Docking.Top;
            lg.Font = new Font("Segoe UI", 9);
            chartKunjungan.Legends.Add(lg);
            
            Series s = new Series("Pasien");
            s.ChartType = SeriesChartType.Column;
            s.IsValueShownAsLabel = true;
            s.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            
            string whereTanggal = $@"WHERE DATE(k.tanggal) BETWEEN '{fromDate:yyyy-MM-dd}' AND '{toDate:yyyy-MM-dd}'";
            string query = $@"SELECT p.nama_poli, COUNT(k.id_kunjungan) AS total FROM kunjungan k JOIN poli p ON p.id_poli = k.id_poli {whereTanggal} GROUP BY p.nama_poli ORDER BY total DESC";

            DataTable dt = DBHelper.GetData(query);
            
            Color[] colors = {
                Color.DodgerBlue,
                Color.MediumSeaGreen,
                Color.Gold,
                Color.MediumPurple,
                Color.Orange,
                Color.DeepPink,
                Color.Teal
            };

            int i = 0;
            
            foreach (DataRow row in dt.Rows) {
                int total = Convert.ToInt32(row["total"]);

                int idx = s.Points.AddXY(
                    row["nama_poli"].ToString(),
                    total
                );

                s.Points[idx].Color = colors[i % colors.Length];
                s.Points[idx].LegendText = row["nama_poli"].ToString();

                i++;
            }

            chartKunjungan.Series.Add(s);
            ChartArea ca = chartKunjungan.ChartAreas[0];

            ca.BackColor = Color.White;

            ca.AxisX.MajorGrid.Enabled = false;
            ca.AxisY.MajorGrid.Enabled = false;
            ca.AxisX.LineColor = Color.Transparent;
            ca.AxisY.LineColor = Color.Transparent;
            ca.AxisX.MajorTickMark.Enabled = false;
            ca.AxisY.MajorTickMark.Enabled = false;
            ca.AxisX.LabelStyle.Font = new Font("Segoe UI", 9);
            ca.AxisY.LabelStyle.Font = new Font("Segoe UI", 9);
            ca.AxisX.Interval = 1;
            ca.AxisY.Minimum = 0;
            double max = s.Points.Count > 0 ? s.Points.Max(p => p.YValues[0]) : 0;
            ca.AxisY.Maximum = Math.Ceiling(max + (max * 0.2));
            chartKunjungan.BackColor = Color.White;
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e) {
            loadChartKunjungan(dtpFrom.Value.Date, dtpTo.Value.Date);
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e) {
            loadChartKunjungan(dtpFrom.Value.Date, dtpTo.Value.Date);
        }

        void setupGridHistoryPasien() {
            dgvHistory.Columns.Clear();

            dgvHistory.AutoGenerateColumns = false;

            dgvHistory.Columns.Add("colNo", "No.");
            dgvHistory.Columns.Add("colRM", "No. RM");
            dgvHistory.Columns.Add("colNama", "Nama Pasien");
            dgvHistory.Columns.Add("colPoli", "Poli/Unit");
            dgvHistory.Columns.Add("colJenis", "Jenis");
            dgvHistory.Columns.Add("colWaktu", "Waktu");
            dgvHistory.Columns.Add("colStatus", "Status");
            
            dgvHistory.Columns["colNo"].Width = 50;
            dgvHistory.Columns["colRM"].Width = 90;
            dgvHistory.Columns["colWaktu"].Width = 70;
            
            dgvHistory.Columns["colNo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHistory.Columns["colWaktu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        
        void styleHistoryTable() {
            dgvHistory.BorderStyle = BorderStyle.None;
            dgvHistory.RowHeadersVisible = false;
            dgvHistory.EnableHeadersVisualStyles = false;
            dgvHistory.BackgroundColor = Color.White;
            dgvHistory.GridColor = Color.FromArgb(230, 230, 230);
            dgvHistory.AllowUserToAddRows = false;
            dgvHistory.AllowUserToDeleteRows = false;
            
            dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // HEADER
            dgvHistory.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvHistory.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvHistory.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvHistory.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Bold", 8);
            dgvHistory.ColumnHeadersHeight = 38;

            // ROW
            dgvHistory.RowTemplate.Height = 32;
            dgvHistory.DefaultCellStyle.Font = new Font("Segoe UI", 8);
            dgvHistory.DefaultCellStyle.SelectionBackColor = Color.FromArgb(240, 247, 255);
            dgvHistory.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvHistory.DefaultCellStyle.Padding = new Padding(3);

            // AUTO SIZE
            dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // KOLOM KHUSUS
            dgvHistory.Columns["colNo"].FillWeight = 40;
            dgvHistory.Columns["colRM"].FillWeight = 90;
            dgvHistory.Columns["colNama"].FillWeight = 130;
            dgvHistory.Columns["colPoli"].FillWeight = 90;
            dgvHistory.Columns["colJenis"].FillWeight = 90;
            dgvHistory.Columns["colWaktu"].FillWeight = 60;
            dgvHistory.Columns["colStatus"].FillWeight = 80;

            // ALIGN
            dgvHistory.Columns["colNo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHistory.Columns["colWaktu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvHistory.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvHistory.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvHistory.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.White;

            dgvHistory.AllowUserToOrderColumns = false;
            dgvHistory.AllowUserToResizeColumns = false;
            dgvHistory.AllowUserToResizeRows = false;

            dgvHistory.MultiSelect = false;
            dgvHistory.ReadOnly = true;
        }
        
        void loadHistoryPasienHariIni() {
            string query = @"
            SELECT 
                k.no_rm,
                p.nama,
                pl.nama_poli,
                k.jenis_kunjungan,
                TIME_FORMAT(k.tanggal, '%H:%i') AS jam,
                k.status,
                k.id_kunjungan
            FROM kunjungan k
            JOIN pasien p 
                ON p.id = k.id_pasien
            LEFT JOIN poli pl 
                ON pl.id_poli = k.id_poli
            WHERE DATE(k.tanggal) = CURDATE()
            ORDER BY k.tanggal DESC LIMIT 5";

            DataTable dt = DBHelper.GetData(query);
            dgvHistory.Rows.Clear();

            int no = 1;

            foreach (DataRow row in dt.Rows) {
                int index = dgvHistory.Rows.Add();
                dgvHistory.Rows[index].Cells["colNo"].Value = no++;
                dgvHistory.Rows[index].Cells["colRM"].Value = row["no_rm"].ToString();
                dgvHistory.Rows[index].Cells["colNama"].Value = row["nama"].ToString();
                dgvHistory.Rows[index].Cells["colPoli"].Value = row["nama_poli"].ToString();
                dgvHistory.Rows[index].Cells["colJenis"].Value = row["jenis_kunjungan"].ToString();
                dgvHistory.Rows[index].Cells["colWaktu"].Value = row["jam"].ToString();
                dgvHistory.Rows[index].Cells["colStatus"].Value = row["status"].ToString();
            }
        }
        
        private void dgvHistory_CellFormatting(
            object sender,
            DataGridViewCellFormattingEventArgs e) {
            if (dgvHistory.Columns[e.ColumnIndex].Name == "colStatus") {
                string status = dgvHistory.Rows[e.RowIndex].Cells["colStatus"].Value?.ToString().ToLower();

                if (status == "selesai") {
                    e.CellStyle.BackColor = Color.FromArgb(220, 252, 231);
                    e.CellStyle.ForeColor = Color.Green;
                } else if (status == "menunggu") {
                    e.CellStyle.BackColor = Color.FromArgb(254, 243, 199);
                    e.CellStyle.ForeColor = Color.DarkOrange;
                } else if (status == "menginap") {
                    e.CellStyle.BackColor = Color.FromArgb(219, 234, 254);
                    e.CellStyle.ForeColor = Color.RoyalBlue;
                } else if (status == "payment") {
                    e.CellStyle.BackColor = Color.FromArgb(237, 233, 254);
                    e.CellStyle.ForeColor = Color.MediumPurple;
                }
            }
        }
    }
}