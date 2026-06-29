using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace RSUD_SYSTEM {
    public partial class menuRawatInap : Form {
        public DataTable dataPB;
        public menuRawatInap() {
            InitializeComponent();
        }

        private void menuRawatInap_Load(object sender, EventArgs e) {
            load();
            loadFilterPasien();
        }

        void loadFilterPasien(string keyword = "") {
            string query = @"
SELECT 
    k.id_kunjungan,
    k.no_rm,
    p.nama,
    CONCAT(k.no_rm, ' - ', p.nama, ' - ', k.id_kunjungan) AS displayText
FROM kunjungan k
JOIN pasien p ON k.no_rm = p.no_rm
WHERE k.status='menginap'
    AND (
        k.no_rm LIKE @key OR
        p.nama LIKE @key OR
        k.id_kunjungan LIKE @key
    )";

            var dt = DBHelper.GetData(query,
                new MySqlParameter("@key", "%" + keyword + "%")
            );

            DataRow row = dt.NewRow();
            row["displayText"] = "-- Cari Pasien --";
            row["id_kunjungan"] = "";

            dt.Rows.InsertAt(row, 0);

            cbFilterPasien.DataSource = dt;
            cbFilterPasien.DisplayMember = "displayText";
            cbFilterPasien.ValueMember = "id_kunjungan";

            cbFilterPasien.SelectedIndex = 0;
        }

        void load() {
            labelDataPasien.Text = "-\n-\n-\n-\n-\n-";
            labelDataKunjungan.Text = "-\n-\n-\n-";
            textBoxAlamat.Enabled = false; textBoxAlamat.Text = "";
            var queryKamarAndJenis = "SELECT id_kamar, CONCAT(nama_kamar, ' - ', tipe_kamar) as displayText FROM kamar";
            var dataKamar = DBHelper.GetData(queryKamarAndJenis);
            cbKamar.DataSource = dataKamar;
            cbKamar.DisplayMember = "displayText";
            cbKamar.ValueMember = "id_kamar";

            cbKamar.SelectedIndex = 0;

            dgvObat.Rows.Clear();
            dgvObat.Columns.Clear();
            dgvDiagnosa.Rows.Clear();
            dgvDiagnosa.Columns.Clear();
            dgvTindakan.Rows.Clear();
            dgvTindakan.Columns.Clear();

            var queryKasurReguler = $"SELECT * FROM bed where id_kamar='{cbKamar.SelectedValue.ToString()}'";
            var dataKasur = DBHelper.GetData(queryKasurReguler);
            if (dataKasur.Rows.Count > 0) {
                int totalBed = 15;
                int jumlahTerisi = 0;
                foreach (DataRow data in dataKasur.Rows) {
                    if (data["status"].ToString() == "Terisi") {
                        jumlahTerisi += 1;
                    }
                }
                labelTotalBed.Text = totalBed.ToString();
                labelTerisi.Text = jumlahTerisi.ToString();
                labelKosong.Text = (totalBed - jumlahTerisi).ToString();

                reset();
                kamar1.Text = dataKasur.Rows[0]["id_bed"].ToString(); kamar1.BackColor = dataKasur.Rows[0]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                kamar2.Text = dataKasur.Rows[1]["id_bed"].ToString(); kamar2.BackColor = dataKasur.Rows[1]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                kamar3.Text = dataKasur.Rows[2]["id_bed"].ToString(); kamar3.BackColor = dataKasur.Rows[2]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                kamar4.Text = dataKasur.Rows[3]["id_bed"].ToString(); kamar4.BackColor = dataKasur.Rows[3]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                kamar5.Text = dataKasur.Rows[4]["id_bed"].ToString(); kamar5.BackColor = dataKasur.Rows[4]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                kamar6.Text = dataKasur.Rows[5]["id_bed"].ToString(); kamar6.BackColor = dataKasur.Rows[5]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                kamar7.Text = dataKasur.Rows[6]["id_bed"].ToString(); kamar7.BackColor = dataKasur.Rows[6]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                kamar8.Text = dataKasur.Rows[7]["id_bed"].ToString(); kamar8.BackColor = dataKasur.Rows[7]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                kamar9.Text = dataKasur.Rows[8]["id_bed"].ToString(); kamar9.BackColor = dataKasur.Rows[8]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                kamar10.Text = dataKasur.Rows[9]["id_bed"].ToString(); kamar10.BackColor = dataKasur.Rows[9]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                kamar11.Text = dataKasur.Rows[10]["id_bed"].ToString(); kamar11.BackColor = dataKasur.Rows[10]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                kamar12.Text = dataKasur.Rows[11]["id_bed"].ToString(); kamar12.BackColor = dataKasur.Rows[11]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                kamar13.Text = dataKasur.Rows[12]["id_bed"].ToString(); kamar13.BackColor = dataKasur.Rows[12]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                kamar14.Text = dataKasur.Rows[13]["id_bed"].ToString(); kamar14.BackColor = dataKasur.Rows[13]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                kamar15.Text = dataKasur.Rows[14]["id_bed"].ToString(); kamar15.BackColor = dataKasur.Rows[14]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
            }
        }

        void reset() {
            kamar1.Enabled = true; kamar1.Text = ""; kamar1.BackColor = Color.Gray;
            kamar2.Enabled = true; kamar2.Text = ""; kamar2.BackColor = Color.Gray;
            kamar3.Enabled = true; kamar3.Text = ""; kamar3.BackColor = Color.Gray;
            kamar4.Enabled = true; kamar4.Text = ""; kamar4.BackColor = Color.Gray;
            kamar5.Enabled = true; kamar5.Text = ""; kamar5.BackColor = Color.Gray;
            kamar6.Enabled = true; kamar6.Text = ""; kamar6.BackColor = Color.Gray;
            kamar7.Enabled = true; kamar7.Text = ""; kamar7.BackColor = Color.Gray;
            kamar8.Enabled = true; kamar8.Text = ""; kamar8.BackColor = Color.Gray;
            kamar9.Enabled = true; kamar9.Text = ""; kamar9.BackColor = Color.Gray;
            kamar10.Enabled = true; kamar10.Text = ""; kamar10.BackColor = Color.Gray;
            kamar11.Enabled = true; kamar11.Text = ""; kamar11.BackColor = Color.Gray;
            kamar12.Enabled = true; kamar12.Text = ""; kamar12.BackColor = Color.Gray;
            kamar13.Enabled = true; kamar13.Text = ""; kamar13.BackColor = Color.Gray;
            kamar14.Enabled = true; kamar14.Text = ""; kamar14.BackColor = Color.Gray;
            kamar15.Enabled = true; kamar15.Text = ""; kamar15.BackColor = Color.Gray;
        }

        private void cbKamar_SelectedIndexChanged(object sender, EventArgs e) {
            labelRingKamar.Text = cbKamar.Text;
            if (cbKamar.Text.EndsWith("Reguler")) {
                var queryKasurReguler = $"SELECT * FROM bed where id_kamar='{cbKamar.SelectedValue.ToString()}'";
                var dataKasur = DBHelper.GetData(queryKasurReguler);
                if (dataKasur.Rows.Count > 0) {
                    int totalBed = 15;
                    int jumlahTerisi = 0;
                    foreach (DataRow data in dataKasur.Rows) {
                        if (data["status"].ToString() == "Terisi") {
                            jumlahTerisi += 1;
                        }
                    }
                    labelTotalBed.Text = totalBed.ToString();
                    labelTerisi.Text = jumlahTerisi.ToString();
                    labelKosong.Text = (totalBed - jumlahTerisi).ToString();

                    reset();
                    kamar1.Text = dataKasur.Rows[0]["id_bed"].ToString(); kamar1.BackColor = dataKasur.Rows[0]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                    kamar2.Text = dataKasur.Rows[1]["id_bed"].ToString(); kamar2.BackColor = dataKasur.Rows[1]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                    kamar3.Text = dataKasur.Rows[2]["id_bed"].ToString(); kamar3.BackColor = dataKasur.Rows[2]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                    kamar4.Text = dataKasur.Rows[3]["id_bed"].ToString(); kamar4.BackColor = dataKasur.Rows[3]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                    kamar5.Text = dataKasur.Rows[4]["id_bed"].ToString(); kamar5.BackColor = dataKasur.Rows[4]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                    kamar6.Text = dataKasur.Rows[5]["id_bed"].ToString(); kamar6.BackColor = dataKasur.Rows[5]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                    kamar7.Text = dataKasur.Rows[6]["id_bed"].ToString(); kamar7.BackColor = dataKasur.Rows[6]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                    kamar8.Text = dataKasur.Rows[7]["id_bed"].ToString(); kamar8.BackColor = dataKasur.Rows[7]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                    kamar9.Text = dataKasur.Rows[8]["id_bed"].ToString(); kamar9.BackColor = dataKasur.Rows[8]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                    kamar10.Text = dataKasur.Rows[9]["id_bed"].ToString(); kamar10.BackColor = dataKasur.Rows[9]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                    kamar11.Text = dataKasur.Rows[10]["id_bed"].ToString(); kamar11.BackColor = dataKasur.Rows[10]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                    kamar12.Text = dataKasur.Rows[11]["id_bed"].ToString(); kamar12.BackColor = dataKasur.Rows[11]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                    kamar13.Text = dataKasur.Rows[12]["id_bed"].ToString(); kamar13.BackColor = dataKasur.Rows[12]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                    kamar14.Text = dataKasur.Rows[13]["id_bed"].ToString(); kamar14.BackColor = dataKasur.Rows[13]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                    kamar15.Text = dataKasur.Rows[14]["id_bed"].ToString(); kamar15.BackColor = dataKasur.Rows[14]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                }
            } else if (cbKamar.Text.EndsWith("VIP")) {
                labelRingKamar.Text = cbKamar.Text;
                var queryKasurVIP = $"SELECT * FROM bed where id_kamar='{cbKamar.SelectedValue.ToString()}'";
                var dataKasur = DBHelper.GetData(queryKasurVIP);
                if (dataKasur.Rows.Count > 0) {
                    int totalBed = 5;
                    int jumlahTerisi = 0;
                    foreach (DataRow data in dataKasur.Rows) {
                        if (data["status"].ToString() == "Terisi") {
                            jumlahTerisi += 1;
                        }
                    }
                    labelTotalBed.Text = totalBed.ToString();
                    labelTerisi.Text = jumlahTerisi.ToString();
                    labelKosong.Text = (totalBed - jumlahTerisi).ToString();

                    reset();
                    kamar1.Text = dataKasur.Rows[0]["id_bed"].ToString(); kamar1.BackColor = dataKasur.Rows[0]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                    kamar2.Text = dataKasur.Rows[1]["id_bed"].ToString(); kamar2.BackColor = dataKasur.Rows[1]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                    kamar3.Text = dataKasur.Rows[2]["id_bed"].ToString(); kamar3.BackColor = dataKasur.Rows[2]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                    kamar4.Text = dataKasur.Rows[3]["id_bed"].ToString(); kamar4.BackColor = dataKasur.Rows[3]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                    kamar5.Text = dataKasur.Rows[4]["id_bed"].ToString(); kamar5.BackColor = dataKasur.Rows[4]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                    kamar6.Enabled = false; kamar6.Text = "";
                    kamar7.Enabled = false; kamar7.Text = "";
                    kamar8.Enabled = false; kamar8.Text = "";
                    kamar9.Enabled = false; kamar9.Text = "";
                    kamar10.Enabled = false; kamar10.Text = "";
                    kamar11.Enabled = false; kamar11.Text = "";
                    kamar12.Enabled = false; kamar12.Text = "";
                    kamar13.Enabled = false; kamar13.Text = "";
                    kamar14.Enabled = false; kamar14.Text = "";
                    kamar15.Enabled = false; kamar15.Text = "";
                }
            } else if (cbKamar.Text.EndsWith("VVIP")) {
                labelRingKamar.Text = cbKamar.Text;
                var queryKasurVVIP = $"SELECT * FROM bed where id_kamar='{cbKamar.SelectedValue.ToString()}'";
                var dataKasur = DBHelper.GetData(queryKasurVVIP);
                if (dataKasur.Rows.Count > 0) {
                    int totalBed = 5;
                    int jumlahTerisi = 0;
                    foreach (DataRow data in dataKasur.Rows) {
                        if (data["status"].ToString() == "Terisi") {
                            jumlahTerisi += 1;
                        }
                    }
                    labelTotalBed.Text = totalBed.ToString();
                    labelTerisi.Text = jumlahTerisi.ToString();
                    labelKosong.Text = (totalBed - jumlahTerisi).ToString();

                    reset();
                    kamar1.Text = dataKasur.Rows[0]["id_bed"].ToString(); kamar1.BackColor = dataKasur.Rows[0]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                    kamar2.Text = dataKasur.Rows[1]["id_bed"].ToString(); kamar2.BackColor = dataKasur.Rows[1]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                    kamar3.Text = dataKasur.Rows[2]["id_bed"].ToString(); kamar3.BackColor = dataKasur.Rows[2]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                    kamar4.Text = dataKasur.Rows[3]["id_bed"].ToString(); kamar4.BackColor = dataKasur.Rows[3]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                    kamar5.Text = dataKasur.Rows[4]["id_bed"].ToString(); kamar5.BackColor = dataKasur.Rows[4]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                    kamar6.Enabled = false; kamar6.Text = "";
                    kamar7.Enabled = false; kamar7.Text = "";
                    kamar8.Enabled = false; kamar8.Text = "";
                    kamar9.Enabled = false; kamar9.Text = "";
                    kamar10.Enabled = false; kamar10.Text = "";
                    kamar11.Enabled = false; kamar11.Text = "";
                    kamar12.Enabled = false; kamar12.Text = "";
                    kamar13.Enabled = false; kamar13.Text = "";
                    kamar14.Enabled = false; kamar14.Text = "";
                    kamar15.Enabled = false; kamar15.Text = "";
                }
            }
        }

        void loadDataPasienFromKamar(string idKamar) {
            var dataBed = DBHelper.GetData($"SELECT * FROM bed WHERE id_bed='{idKamar}'").Rows;
            if (dataBed.Count <= 0) {
                MessageBox.Show("Data bed tidak ditemukan!");
                return;
            }

            var dataKamar = DBHelper.GetData($"SELECT * FROM kamar WHERE id_kamar='{dataBed[0]["id_kamar"]}'").Rows;
            var dataKJ = DBHelper.GetData($@"
SELECT k.*
FROM kunjungan k
JOIN histori_kamar hk ON k.id_kunjungan = hk.id_kunjungan
WHERE hk.id_bed = '{idKamar}'
AND hk.tanggal_keluar IS NULL
AND k.status = 'menginap'
ORDER BY hk.id_histori DESC
LIMIT 1");

            if (dataKJ.Rows.Count > 0) {
                labelKamar.Text = dataKamar[0]["nama_kamar"].ToString() + ", " + idKamar;
                var dataKunjungan = dataKJ.Rows[0];
                dataPB = dataKJ;
                var dataPS = DBHelper.GetData($"SELECT * FROM pasien WHERE no_rm='{dataKunjungan["no_rm"]}'");
                if (dataPS.Rows.Count > 0) {
                    var dataPasien = dataPS.Rows[0];

                    DateTime tglLahir = Convert.ToDateTime(dataPasien["tgl_lahir"]);
                    int umur = DateTime.Now.Year - tglLahir.Year;

                    if (DateTime.Today < tglLahir.AddYears(umur))
                        umur--;

                    string jk = dataPasien["jenis_kelamin"].ToString() == "L" ? "Laki - Laki" : "Perempuan";

                    labelDataPasien.Text =
                        dataKunjungan["no_rm"].ToString() + "\n" +
                        dataPasien["nama"].ToString() + "\n" +
                        dataPasien["nik"].ToString() + "\n" +
                        tglLahir.ToString("dddd, d MMMM yyyy") + "\n" +
                        umur + "\n" +
                        jk;

                    textBoxAlamat.Text = dataPasien["alamat"].ToString();

                    var dataPoliklinik = DBHelper.GetData($"SELECT * FROM poli WHERE id_poli='{dataKunjungan["id_poli"]}'").Rows;
                    var dataDokter = DBHelper.GetData($"SELECT * FROM dokter WHERE id_dokter='{dataKunjungan["id_dokter"]}'").Rows;

                    labelDataKunjungan.Text =
                        dataKunjungan["id_kunjungan"].ToString() + "\n" +
                        dataKunjungan["jenis_kunjungan"].ToString() + "\n" +
                        (dataPoliklinik.Count == 0 ? "-" : dataPoliklinik[0]["nama_poli"].ToString()) + "\n" +
                        (dataDokter.Count == 0 ? "-" : dataDokter[0]["nama_dokter"].ToString());
                    
                    dgvDiagnosa.Rows.Clear();
                    dgvDiagnosa.Columns.Clear();

                    dgvDiagnosa.Enabled = true;
                    dgvDiagnosa.RowHeadersVisible = false;

                    dgvDiagnosa.Columns.Add("diagnosa", "Diagnosa");
                    dgvDiagnosa.Columns.Add("tanggal", "Tanggal");
                    dgvDiagnosa.Columns.Add("isNew", "isNew");

                    dgvDiagnosa.Columns["isNew"].Visible = false;
                    dgvDiagnosa.Columns["diagnosa"].FillWeight = 60;
                    dgvDiagnosa.Columns["tanggal"].FillWeight = 40;

                    var qDn = $"SELECT * FROM diagnosa WHERE id_kunjungan='{dataKunjungan["id_kunjungan"].ToString()}'";
                    var dtDn = DBHelper.GetData(qDn);

                    foreach (DataRow row in dtDn.Rows) {
                        dgvDiagnosa.Rows.Add(
                            row["diagnosa"].ToString(),
                            Convert.ToDateTime(row["tanggal"]).ToString("dd/MM/yyyy HH:mm"),
                            false
                        );
                    }
                    
                    dgvTindakan.Rows.Clear();
                    dgvTindakan.Columns.Clear();

                    dgvTindakan.Enabled = true;
                    dgvTindakan.RowHeadersVisible = false;

                    DataGridViewComboBoxColumn colTindakan = new DataGridViewComboBoxColumn();

                    colTindakan.HeaderText = "Tindakan";
                    colTindakan.Name = "tindakan";
                    colTindakan.Width = 100;
                    colTindakan.DataSource = DBHelper.GetData("SELECT * FROM data_tindakan ORDER BY nama_tindakan ASC");
                    colTindakan.DisplayMember = "nama_tindakan";
                    colTindakan.ValueMember = "id_tindakan";

                    dgvTindakan.Columns.Add(colTindakan);
                    dgvTindakan.Columns.Add("dokter", "Dokter");
                    dgvTindakan.Columns.Add("tanggal", "Tanggal");
                    dgvTindakan.Columns.Add("harga", "Harga");
                    dgvTindakan.Columns.Add("isNew", "isNew");
                    dgvTindakan.Columns["isNew"].Visible = false;
                    dgvTindakan.Columns["tindakan"].FillWeight = 25;
                    dgvTindakan.Columns["dokter"].FillWeight = 30;
                    dgvTindakan.Columns["tanggal"].FillWeight = 25;
                    dgvTindakan.Columns["harga"].FillWeight = 20;

                    var qTd = $"SELECT * FROM tindakan WHERE id_kunjungan='{dataKunjungan["id_kunjungan"].ToString()}'";
                    var dtTd = DBHelper.GetData(qTd);

                    foreach (DataRow row in dtTd.Rows) {
                        int i = dgvTindakan.Rows.Add(
                            row["id_tindakan"],
                            row["dokter"].ToString(),
                            Convert.ToDateTime(row["tanggal"]).ToString("dd/MM/yyyy HH:mm"),
                            row["harga"].ToString(),
                            false
                        );

                        dgvTindakan.Rows[i].ReadOnly = true;
                    }

                    dgvObat.Rows.Clear();
                    dgvObat.Columns.Clear();
                    dgvDiagnosa.Rows.Clear();
                    dgvDiagnosa.Columns.Clear();
                    dgvTindakan.Rows.Clear();
                    dgvTindakan.Columns.Clear();
                    
                    dgvDiagnosa.Enabled = true;
                    dgvDiagnosa.RowHeadersVisible = false;

                    dgvDiagnosa.Columns.Add("diagnosa", "Diagnosa");
                    dgvDiagnosa.Columns.Add("tanggal", "Tanggal");
                    dgvDiagnosa.Columns.Add("isNew", "isNew");

                    dgvDiagnosa.Columns["isNew"].Visible = false;
                    dgvDiagnosa.Columns["diagnosa"].FillWeight = 60;
                    dgvDiagnosa.Columns["tanggal"].FillWeight = 40;

                    var dataDiagnosa = DBHelper.GetData(
                        $"SELECT * FROM diagnosa WHERE id_kunjungan='{dataKunjungan["id_kunjungan"]}'"
                    );

                    foreach (DataRow row in dataDiagnosa.Rows) {
                        DateTime waktu = Convert.ToDateTime(row["tanggal"]);

                        dgvDiagnosa.Rows.Add(
                            row["diagnosa"].ToString(),
                            waktu.ToString("dd/MM/yyyy HH:mm"),
                            false
                        );
                    }
                    
                    dgvTindakan.Enabled = true;
                    dgvTindakan.RowHeadersVisible = false;

                    dgvTindakan.Columns.Add("tindakan", "Tindakan");
                    dgvTindakan.Columns.Add("dokter", "Dokter");
                    dgvTindakan.Columns.Add("tanggal", "Tanggal");
                    dgvTindakan.Columns.Add("harga", "Harga");
                    dgvTindakan.Columns.Add("isNew", "isNew");

                    dgvTindakan.Columns["isNew"].Visible = false;
                    dgvTindakan.Columns["tindakan"].FillWeight = 25;
                    dgvTindakan.Columns["dokter"].FillWeight = 30;
                    dgvTindakan.Columns["tanggal"].FillWeight = 25;
                    dgvTindakan.Columns["harga"].FillWeight = 20;

                    var dataTindakan = DBHelper.GetData(
                        $"SELECT * FROM tindakan WHERE id_kunjungan='{dataKunjungan["id_kunjungan"]}'"
                    );

                    foreach (DataRow row in dataTindakan.Rows) {
                        var dtTD = DBHelper.GetData(
                            $"SELECT * FROM data_tindakan WHERE id_tindakan='{row["id_tindakan"]}'"
                        );

                        dgvTindakan.Rows.Add(
                            dtTD.Rows[0]["nama_tindakan"].ToString(),
                            row["dokter"].ToString(),
                            Convert.ToDateTime(row["tanggal"]).ToString("dd/MM/yyyy HH:mm"),
                            "Rp " + Convert.ToInt32(row["harga"]).ToString("N0"),
                            false
                        );
                    }
                    
                    dgvObat.Enabled = true;
                    dgvObat.RowHeadersVisible = false;

                    dgvObat.Columns.Add("obat", "Nama Obat");
                    dgvObat.Columns.Add("dosis", "Dosis");
                    dgvObat.Columns.Add("jumlah", "Jumlah");
                    dgvObat.Columns.Add("isNew", "isNew");

                    dgvObat.Columns["isNew"].Visible = false;
                    dgvObat.Columns["obat"].FillWeight = 30;
                    dgvObat.Columns["dosis"].FillWeight = 50;
                    dgvObat.Columns["jumlah"].FillWeight = 20;

                    var dataObat = DBHelper.GetData(
                        $"SELECT * FROM resep WHERE id_kunjungan='{dataKunjungan["id_kunjungan"]}'"
                    );

                    foreach (DataRow row in dataObat.Rows) {
                        var dtNOB = DBHelper.GetData(
                            $"SELECT * FROM obat WHERE id_obat='{row["id_obat"]}'"
                        );

                        dgvObat.Rows.Add(
                            dtNOB.Rows[0]["nama_obat"].ToString(),
                            row["dosis"].ToString(),
                            row["jumlah"].ToString(),
                            false
                        );
                    }
                }
            } else {
                MessageBox.Show("Kamar tersebut kosong!");
            }
        }

        private void kamar1_Click(object sender, EventArgs e) { loadDataPasienFromKamar(kamar1.Text); }
        private void kamar2_Click(object sender, EventArgs e) { loadDataPasienFromKamar(kamar2.Text); }
        private void kamar3_Click(object sender, EventArgs e) { loadDataPasienFromKamar(kamar3.Text); }
        private void kamar4_Click(object sender, EventArgs e) { loadDataPasienFromKamar(kamar4.Text); }
        private void kamar5_Click(object sender, EventArgs e) { loadDataPasienFromKamar(kamar5.Text); }

        private void kamar10_Click(object sender, EventArgs e) { loadDataPasienFromKamar(kamar10.Text); }
        private void kamar9_Click(object sender, EventArgs e) { loadDataPasienFromKamar(kamar9.Text); }
        private void kamar8_Click(object sender, EventArgs e) { loadDataPasienFromKamar(kamar8.Text); }
        private void kamar7_Click(object sender, EventArgs e) { loadDataPasienFromKamar(kamar7.Text); }
        private void kamar6_Click(object sender, EventArgs e) { loadDataPasienFromKamar(kamar6.Text); }

        private void kamar15_Click(object sender, EventArgs e) { loadDataPasienFromKamar(kamar15.Text); }
        private void kamar14_Click(object sender, EventArgs e) { loadDataPasienFromKamar(kamar14.Text); }
        private void kamar13_Click(object sender, EventArgs e) { loadDataPasienFromKamar(kamar13.Text); }
        private void kamar12_Click(object sender, EventArgs e) { loadDataPasienFromKamar(kamar12.Text); }
        private void kamar11_Click(object sender, EventArgs e) { loadDataPasienFromKamar(kamar11.Text); }

        private void textBoxCari_Enter(object sender, EventArgs e) {
            if (textBoxCari.Text == "Cari Pasien Rawat Inap...") {
                textBoxCari.Text = "";
                textBoxCari.ForeColor = Color.Black;
            }
        }

        private void textBoxCari_Leave(object sender, EventArgs e) {
            if (textBoxCari.Text == "") {
                textBoxCari.Text = "Cari Pasien Rawat Inap...";
                textBoxCari.ForeColor = Color.Gray;
            }
        }

        private void buttonPindah_Click(object sender, EventArgs e) {
            if (dataPB == null) {
                MessageBox.Show("Silahkan pilih terlebih dahulu pasien yang ingin dipindahkan!");
                return;
            }

            string idKunjungan = dataPB.Rows[0]["id_kunjungan"].ToString();
            var data = DBHelper.GetData(
                "SELECT * FROM kunjungan WHERE id_kunjungan=@id",
                new MySqlParameter("@id", idKunjungan)
            );

            if (data.Rows.Count <= 0)
                return;

            pilihKamar frm = new pilihKamar(data);
            if (frm.ShowDialog() == DialogResult.OK) {
                DateTime waktuPindah = DateTime.Now;
                var dataHistoriAktif = DBHelper.GetData($@"
SELECT *
FROM histori_kamar
WHERE id_kunjungan='{idKunjungan}'
AND tanggal_keluar IS NULL
ORDER BY id_histori DESC
LIMIT 1");

                if (dataHistoriAktif.Rows.Count > 0) {
                    string bedLama = dataHistoriAktif.Rows[0]["id_bed"].ToString();

                    DBHelper.Execute(
                        "UPDATE bed SET status='Kosong' WHERE id_bed=@id_bed",
                        new MySqlParameter("@id_bed", bedLama)
                    );

                    DBHelper.Execute(
                        @"UPDATE histori_kamar 
                  SET tanggal_keluar=@tanggal_keluar 
                  WHERE id_histori=@id_histori",
                        new MySqlParameter("@tanggal_keluar", waktuPindah),
                        new MySqlParameter("@id_histori", dataHistoriAktif.Rows[0]["id_histori"])
                    );
                }

                DBHelper.Execute(
                    @"INSERT INTO histori_kamar 
              (id_kunjungan, id_kamar, id_bed, tanggal_masuk, tanggal_keluar)
              VALUES
              (@id_kunjungan, @id_kamar, @id_bed, @tanggal_masuk, NULL)",
                    new MySqlParameter("@id_kunjungan", idKunjungan),
                    new MySqlParameter("@id_kamar", DataKamar.KodeKamar),
                    new MySqlParameter("@id_bed", DataKamar.Bed),
                    new MySqlParameter("@tanggal_masuk", waktuPindah)
                );

                DBHelper.Execute(
                    "UPDATE bed SET status='Terisi' WHERE id_bed=@id_bed",
                    new MySqlParameter("@id_bed", DataKamar.Bed)
                );

                MessageBox.Show($"Sukses memindah Pasien ke Kamar: {DataKamar.Kamar}, {DataKamar.Bed}");

                load();
                loadFilterPasien();
            }
        }

        private void butttonPulang_Click(object sender, EventArgs e) {
            if (dataPB == null || dataPB.Rows.Count == 0) {
                MessageBox.Show(
                    "Silahkan pilih pasien untuk dipulangkan!",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            DataTable dtMasukTerakhir = DBHelper.GetData(
                @"SELECT tanggal_masuk 
      FROM histori_kamar 
      WHERE id_kunjungan=@id 
      ORDER BY tanggal_masuk DESC, id_histori DESC 
      LIMIT 1",
                new MySqlParameter("@id", dataPB.Rows[0]["id_kunjungan"].ToString())
            );

            DateTime minTanggalKeluar = DateTime.Now;

            if (dtMasukTerakhir.Rows.Count > 0 && dtMasukTerakhir.Rows[0]["tanggal_masuk"] != DBNull.Value) {
                minTanggalKeluar = Convert.ToDateTime(dtMasukTerakhir.Rows[0]["tanggal_masuk"]);
            }

            DateTimePicker dtpKeluar = new DateTimePicker();
            dtpKeluar.Format = DateTimePickerFormat.Custom;
            dtpKeluar.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            dtpKeluar.Width = 200;
            dtpKeluar.MinDate = minTanggalKeluar;
            dtpKeluar.MaxDate = DateTime.Now;
            dtpKeluar.Value = DateTime.Now;

            Form popup = new Form();
            popup.Text = "Konfirmasi Tanggal Pulang";
            popup.Width = 320;
            popup.Height = 160;
            popup.StartPosition = FormStartPosition.CenterParent;

            Label lbl = new Label();
            lbl.Text = "Pastikan Tanggal & Jam Pulang:";
            lbl.Left = 20;
            lbl.Top = 20;
            lbl.Width = 250;

            dtpKeluar.Left = 20;
            dtpKeluar.Top = 50;

            Button btnOK = new Button();
            btnOK.Text = "OK";
            btnOK.Left = 60;
            btnOK.Top = 90;
            btnOK.DialogResult = DialogResult.OK;

            Button btnBatal = new Button();
            btnBatal.Text = "Batal";
            btnBatal.Left = 150;
            btnBatal.Top = 90;
            btnBatal.DialogResult = DialogResult.Cancel;

            popup.Controls.Add(lbl);
            popup.Controls.Add(dtpKeluar);
            popup.Controls.Add(btnOK);
            popup.Controls.Add(btnBatal);

            popup.AcceptButton = btnOK;
            popup.CancelButton = btnBatal;

            if (popup.ShowDialog() == DialogResult.OK) {
                string idKunjungan = dataPB.Rows[0]["id_kunjungan"].ToString();
                var dataKJ = DBHelper.GetData($"SELECT * FROM kunjungan WHERE id_kunjungan='{idKunjungan}'").Rows[0];
                if (dataKJ["status"].ToString() == "menginap") {
                    DateTime tanggalKeluar = dtpKeluar.Value;
                    if (tanggalKeluar < minTanggalKeluar) {
                        MessageBox.Show(
                            "Tanggal pulang tidak boleh kurang dari tanggal masuk kamar terakhir!",
                            "Peringatan",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return;
                    }
                    var dataHistori = DBHelper.GetData($@"
SELECT *
FROM histori_kamar
WHERE id_kunjungan='{idKunjungan}'
ORDER BY id_histori DESC
LIMIT 1");

                    if (dataHistori.Rows.Count > 0) {
                        string idBed = dataHistori.Rows[0]["id_bed"].ToString();
                        DBHelper.Execute($"UPDATE bed SET status='Kosong' WHERE id_bed='{idBed}'");
                        DBHelper.Execute(@"
UPDATE histori_kamar 
SET tanggal_keluar=@tgl
WHERE id_histori=@idHistori",
        new MySqlParameter("@tgl", tanggalKeluar),
        new MySqlParameter("@idHistori", dataHistori.Rows[0]["id_histori"])
    );
                    }

                    DBHelper.Execute($@"
UPDATE kunjungan 
SET tanggal_keluar=@tgl
WHERE id_kunjungan=@id",
                        new MySqlParameter("@tgl", tanggalKeluar),
                        new MySqlParameter("@id", idKunjungan)
                    );
                }

                DBHelper.Execute(@"
UPDATE kunjungan 
SET status=@status
WHERE id_kunjungan=@id",
                    new MySqlParameter("@status", "payment"),
                    new MySqlParameter("@id", idKunjungan)
                );

                MessageBox.Show("Sukses, pasien telah pulang!");
                load();
            }
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e) {
            if (textBoxCari.Text == "Cari Pasien Rawat Inap...") return;
            loadFilterPasien(textBoxCari.Text);
        }

        private void cbFilterPasien_SelectedIndexChanged(object sender, EventArgs e) {
            if (cbFilterPasien.SelectedIndex <= 0)
                return;

            string idKunjungan = cbFilterPasien.SelectedValue.ToString();
            var dt = DBHelper.GetData($@"
SELECT id_bed
FROM histori_kamar
WHERE id_kunjungan=@id
AND tanggal_keluar IS NULL
ORDER BY id_histori DESC
LIMIT 1",
                new MySqlParameter("@id", idKunjungan)
            );
            if (dt.Rows.Count > 0) {
                string idBed = dt.Rows[0]["id_bed"].ToString();
                loadDataPasienFromKamar(idBed);
            } else {
                MessageBox.Show("Histori kamar aktif tidak ditemukan!");
            }
        }
    }
}
