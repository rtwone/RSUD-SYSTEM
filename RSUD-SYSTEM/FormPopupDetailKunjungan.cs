using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace RSUD_SYSTEM {
    public partial class FormPopupDetailKunjungan : Form {

        private string idKunjungan;

        public FormPopupDetailKunjungan(string id) {
            InitializeComponent();
            idKunjungan = id;
        }

        private void FormPopupDetailKunjungan_Load(object sender, EventArgs e) {
            int maxRight = 0;
            int maxBottom = 0;

            foreach (Control c in this.Controls) {
                if (c.Right > maxRight)
                    maxRight = c.Right;

                if (c.Bottom > maxBottom)
                    maxBottom = c.Bottom;
            }

            this.Width = maxRight + 35;
            this.Height = maxBottom + 55;
            loadSemuaDetail();
        }

        void loadSemuaDetail() {
            try {
                flowDetail.Controls.Clear();

                loadDetailKunjungan();
                loadDiagnosa();
                loadTindakan();
                loadObat();
                loadHistoriKamar();
                loadDibuatTanggal();

            } catch (Exception ex) {
                MessageBox.Show("Gagal load detail!\n" + ex.Message);
            }
        }

        void tambahJudul(string judul) {
            Label lbl = new Label();

            lbl.Text = judul;
            lbl.AutoSize = true;
            lbl.Font = new Font("Poppins SemiBold", 10F, FontStyle.Bold);
            lbl.ForeColor = Color.Teal;
            lbl.BackColor = Color.White;
            lbl.Margin = new Padding(0, 18, 0, 6);

            flowDetail.Controls.Add(lbl);
        }

        void tambahIsi(string isi) {
            Label lbl = new Label();

            lbl.Text = isi;
            lbl.AutoSize = true;
            lbl.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lbl.ForeColor = Color.FromArgb(45, 45, 45);
            lbl.BackColor = Color.White;
            lbl.MaximumSize = new Size(1350, 0);
            lbl.Margin = new Padding(18, 0, 0, 4);

            flowDetail.Controls.Add(lbl);
        }

        void tambahSection(string judul, string isi) {
            tambahJudul(judul);
            if (string.IsNullOrWhiteSpace(isi)) {
                tambahIsi("-");
            } else {
                tambahIsi(isi);
            }
        }

        void loadDetailKunjungan() {
            DataTable dataKunjungan = DBHelper.GetData($"SELECT * FROM kunjungan WHERE id_kunjungan='{idKunjungan}'");

            if (dataKunjungan.Rows.Count == 0) {
                tambahSection("Data Kunjungan", "Data tidak ditemukan");
                return;
            }

            DataRow row = dataKunjungan.Rows[0];
            string tanggal = Convert.ToDateTime(row["tanggal"]).ToString("dd MMM yyyy HH:mm");

            string poli = "-";
            DataTable dataPoli = DBHelper.GetData($"SELECT nama_poli FROM poli WHERE id_poli='{row["id_poli"]}'");

            if (dataPoli.Rows.Count > 0) {
                poli = dataPoli.Rows[0]["nama_poli"].ToString();
            } else {
                poli = "UGD/IGD";
            }

            string dokter = "-";
            DataTable dataDokter = DBHelper.GetData($"SELECT nama_dokter FROM dokter WHERE id_dokter='{row["id_dokter"]}'");
            if (dataDokter.Rows.Count > 0) {
                dokter = dataDokter.Rows[0]["nama_dokter"].ToString();
            }
            string keluhan = row["keluhan"].ToString();
            string bpjs = row["jenis_pasien"].ToString() == "BPJS" ? row["no_bpjs"].ToString() : row["jenis_pasien"].ToString();
            string isi =
                "Tanggal Kunjungan  : " + tanggal + "\n" +
                "Poli / Unit                : " + poli + "\n" +
                "Dokter                     : " + dokter + "\n" +
                "BPJS / Pasien           : " + bpjs + "\n" +
                "Keluhan                   : " + keluhan;
                       
            tambahSection("Informasi Kunjungan", isi);
        }

        void loadDiagnosa() {
            string query = $@"
SELECT 
    CONCAT(diagnosa, ' - ', DATE_FORMAT(tanggal, '%d %M %Y %H:%i')) AS Diagnosa
FROM diagnosa
WHERE id_kunjungan = '{idKunjungan}'";

            DataTable dt = DBHelper.GetData(query);
            string isi = "";
            foreach (DataRow row in dt.Rows) {
                isi += "• " + row["Diagnosa"].ToString() + "\n";
            }
            tambahSection("Diagnosa", isi);
        }

        void loadTindakan() {
            string query = $@"
SELECT 
    CONCAT(dt.nama_tindakan, ' - ', t.dokter, ' - ', DATE_FORMAT(t.tanggal, '%d %M %Y %H:%i')) AS Tindakan
FROM tindakan t
JOIN data_tindakan dt 
    ON t.id_tindakan = dt.id_tindakan
WHERE t.id_kunjungan = '{idKunjungan}'";

            DataTable dt = DBHelper.GetData(query);

            string isi = "";
            foreach (DataRow row in dt.Rows) {
                isi += "• " + row["Tindakan"].ToString() + "\n";
            }
            tambahSection("Tindakan", isi);
        }

        void loadObat() {
            string query = $@"
SELECT 
    CONCAT(o.nama_obat, ' - ', r.dosis, ' - ', r.jumlah, ' Tablet') AS Obat
FROM resep r
JOIN obat o 
    ON r.id_obat = o.id_obat
WHERE r.id_kunjungan = '{idKunjungan}'";

            DataTable dt = DBHelper.GetData(query);
            string isi = "";
            foreach (DataRow row in dt.Rows) {
                isi += "• " + row["Obat"].ToString() + "\n";
            }
            tambahSection("Obat", isi);
        }

        void loadHistoriKamar() {
            string query = $@"
SELECT 
    CONCAT(
        k.nama_kamar,
        ' - Bed ', hk.id_bed,
        ' - Masuk: ', DATE_FORMAT(hk.tanggal_masuk, '%d/%m/%Y %H:%i'),
        ' - Keluar: ', IFNULL(DATE_FORMAT(hk.tanggal_keluar, '%d/%m/%Y %H:%i'), '-')
    ) AS Kamar
FROM histori_kamar hk
JOIN kamar k
    ON hk.id_kamar = k.id_kamar
WHERE hk.id_kunjungan = '{idKunjungan}'
ORDER BY hk.id_histori DESC";

            DataTable dt = DBHelper.GetData(query);
            string isi = "";
            foreach (DataRow row in dt.Rows) {
                isi += "• " + row["Kamar"].ToString() + "\n";
            }
            tambahSection("Histori Kamar", isi);
        }

        void loadDibuatTanggal() {
            string query = $@"
SELECT tanggal
FROM rekam_medis
WHERE id_kunjungan = '{idKunjungan}'";

            DataTable dt = DBHelper.GetData(query);
            string isi = "-";
            if (dt.Rows.Count > 0) {
                isi = Convert.ToDateTime(dt.Rows[0]["tanggal"])
                    .ToString("dd MMM yyyy HH:mm");
            }
            tambahSection("Dibuat Tanggal", isi);
        }

        private void btnTutup_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}