using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Globalization;

namespace RSUD_SYSTEM {
    public partial class menuDiagnosa : Form {
        public string pbno_rm;
        public string pbid_kunjungan;
        public int pbid_pasien;
        public string pbjenis_kunjungan;
        public DateTime? pbtanggal_masuk = null;
        public menuDiagnosa() {
            InitializeComponent();
        }

        private void menuRekamMedis_Load(object sender, EventArgs e) {
            dgvDiagnosa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDiagnosa.MultiSelect = false;
            dgvTindakan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTindakan.MultiSelect = false;
            dgvObat.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvObat.MultiSelect = false;

            textBoxCari.ForeColor = Color.Gray;
            cbFilterPasien.SelectedIndex = 0;
            string query = $@"SELECT 
    p.nama,
    p.no_rm,
    k.antrean,
    CONCAT(p.nama, ' (', p.no_rm, ') - ',
        CASE 
            WHEN k.status = 'menginap' THEN 'Ranap'
            ELSE IFNULL(k.antrean, 'IGD')
        END
    ) AS displayText
FROM pasien p
JOIN kunjungan k
    ON p.no_rm = k.no_rm
WHERE (
    DATE(k.tanggal) = CURDATE()
    AND k.status IN ('menunggu', 'menginap')
) OR (
    k.status = 'menginap'
)
ORDER BY k.id_kunjungan DESC;";
            var dt = DBHelper.GetData(query);
            DataRow row = dt.NewRow();
            row["displayText"] = "Pilih Pasien (diurut dari terbaru)";
            row["no_rm"] = "";
            dt.Rows.InsertAt(row, 0);
            cbFilterPasien.DataSource = dt;
            cbFilterPasien.DisplayMember = "displayText";
            cbFilterPasien.ValueMember = "no_rm";

            btnTambahDiagnosa.Enabled = false;
            btnHapusDiagnosa.Enabled = false;
            btnTambahTindakan.Enabled = false;
            btnHapusTindakan.Enabled = false;
            btnTambahObat.Enabled = false;
            btnHapusObat.Enabled = false;
            dgvObat.Enabled = false;
            dgvDiagnosa.Enabled = false;
            dgvTindakan.Enabled = false;
            cbStatus.Enabled = false;

            buttonSimpan.Enabled = false;
            butttonReset.Enabled = false;
            checkBStatus.Checked = false;
            checkBStatus.Enabled = false;
        }

        private void textBoxCari_Enter(object sender, EventArgs e) {
            if (textBoxCari.Text == "Cari...") {
                textBoxCari.Text = "";
                textBoxCari.ForeColor = Color.Black;
            }
        }

        private void textBoxCari_Leave(object sender, EventArgs e) {
            if (textBoxCari.Text == "") {
                textBoxCari.Text = "Cari...";
                textBoxCari.ForeColor = Color.Gray;
            }
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e) {
            if (textBoxCari.Text == "Cari...") {
                string queryT = $@"SELECT 
    p.nama,
    p.no_rm,
    k.antrean,
    CONCAT(p.nama, ' (', p.no_rm, ') - ',
        CASE 
            WHEN k.status = 'menginap' THEN 'Ranap'
            ELSE IFNULL(k.antrean, 'IGD')
        END
    ) AS displayText
FROM pasien p
JOIN kunjungan k
    ON p.no_rm = k.no_rm
WHERE (
    DATE(k.tanggal) = CURDATE()
    AND k.status IN ('menunggu', 'menginap')
) OR (
    k.status = 'menginap'
)
ORDER BY k.id_kunjungan DESC;";
                var dtt = DBHelper.GetData(queryT);
                DataRow row = dtt.NewRow();
                row["displayText"] = "Pilih Pasien (diurut dari terbaru)";
                row["no_rm"] = "";
                dtt.Rows.InsertAt(row, 0);
                cbFilterPasien.DataSource = dtt;
                cbFilterPasien.DisplayMember = "displayText";
                cbFilterPasien.ValueMember = "no_rm";
                return;
            } else if (textBoxCari.Text == "") {
                string queryT = $@"SELECT 
    p.nama,
    p.no_rm,
    k.antrean,
    CONCAT(p.nama, ' (', p.no_rm, ') - ',
        CASE 
            WHEN k.status = 'menginap' THEN 'Ranap'
            ELSE IFNULL(k.antrean, 'IGD')
        END
    ) AS displayText
FROM pasien p
JOIN kunjungan k
    ON p.no_rm = k.no_rm
WHERE (
    DATE(k.tanggal) = CURDATE()
    AND k.status IN ('menunggu', 'menginap')
) OR (
    k.status = 'menginap'
)
ORDER BY k.id_kunjungan DESC;";
                var dtt = DBHelper.GetData(queryT);
                DataRow row = dtt.NewRow();
                row["displayText"] = "Pilih Pasien (diurut dari terbaru)";
                row["no_rm"] = "";
                dtt.Rows.InsertAt(row, 0);
                cbFilterPasien.DataSource = dtt;
                cbFilterPasien.DisplayMember = "displayText";
                cbFilterPasien.ValueMember = "no_rm";
                return;
            }


            string keyword = textBoxCari.Text;
            List<string> kolomList = new List<string>()
            {
                "p.no_rm",
                "p.nama",
                "k.antrean",
                "k.status"
            };

            List<string> kondisiList = new List<string>();
            foreach (string kolom in kolomList) {
                kondisiList.Add($"{kolom} LIKE @key");
            }

            string kondisi = string.Join(" OR ", kondisiList);
            string query = $@"SELECT 
    p.nama,
    p.no_rm,
    k.antrean,
    CONCAT(p.nama, ' (', p.no_rm, ') - ',
        CASE 
            WHEN k.status = 'menginap' THEN 'Ranap'
            ELSE IFNULL(k.antrean, 'IGD')
        END
    ) AS displayText
FROM pasien p
JOIN kunjungan k
    ON p.no_rm = k.no_rm
WHERE (
    DATE(k.tanggal) = CURDATE()
    AND k.status IN ('menunggu', 'menginap')
    AND {kondisi}
) OR (
    k.status = 'menginap'
    AND {kondisi}
)
ORDER BY k.id_kunjungan DESC;";
            var dt = DBHelper.GetData(query, new MySqlParameter("@key", "%" + keyword.Replace("ranap", "menginap") + "%"));
            Debug.WriteLine(dt.Rows.Count);
            if (dt.Rows.Count == 0) {
                cbFilterPasien.DataSource = null;
                cbFilterPasien.Items.Clear();
                cbFilterPasien.Text = "Data tidak ditemukan!";
            } else {
                cbFilterPasien.DataSource = dt;
                cbFilterPasien.DisplayMember = "displayText";      
                cbFilterPasien.ValueMember = "p.no_rm";
            }
        }

        private void cbFilterPasien_SelectedIndexChanged(object sender, EventArgs e) {
            loadCBKunjungan();
        }

        void loadCBKunjungan() {
            if (cbFilterPasien.SelectedIndex > 0 || (cbFilterPasien.SelectedIndex == 0 && cbFilterPasien.Text.Contains("RM"))) {
                cbKunjungan.Enabled = true;
                string no_rm = cbFilterPasien.SelectedValue.ToString();
                pbno_rm = no_rm;
                string queryP = $"SELECT * FROM pasien where no_rm='{no_rm}'";
                var dt = DBHelper.GetData(queryP);
                pbid_pasien = int.Parse(dt.Rows[0]["id"].ToString());
                string nama = dt.Rows[0]["nama"].ToString();
                string nik = dt.Rows[0]["nik"].ToString();
                DateTime tgl_lahir = Convert.ToDateTime(dt.Rows[0]["tgl_lahir"]);
                string jeniskelamin = dt.Rows[0]["jenis_kelamin"].ToString() == "L" ? "Laki Laki" : "Perempuan";
                int umur = DateTime.Today.Year - tgl_lahir.Year;
                if (DateTime.Today < tgl_lahir.AddYears(umur)) umur--;
                if (dt.Rows.Count > 0) {
                    labelIsiDataPasien.Text = no_rm + "\n" +
                        nama + "\n" +
                        nik + "\n" +
                        umur + " Tahun\n" +
                        jeniskelamin + "\n" +
                        tgl_lahir.ToString("dddd, d MMMM yyyy", new CultureInfo("id-ID"));
                }
                
                string queryFcb = $"SELECT jenis_kunjungan, CONCAT(id_kunjungan, ' (', DATE_FORMAT(tanggal, '%d/%m/%Y'), ') - ', status) as displayText FROM kunjungan where no_rm='{no_rm}' and (status='menunggu' or status='menginap') order by id_kunjungan desc";
                var dtFcb = DBHelper.GetData(queryFcb);
                if (dtFcb.Rows.Count > 0) {
                    DataRow row = dtFcb.NewRow();
                    row["displayText"] = "Pilih Kunjungan (diurut dari terbaru)";
                    row["jenis_kunjungan"] = "";
                    dtFcb.Rows.InsertAt(row, 0);
                    cbKunjungan.DataSource = dtFcb;
                    cbKunjungan.DisplayMember = "displayText";
                    cbKunjungan.ValueMember = "jenis_kunjungan";
                } else {
                    cbKunjungan.DataSource = null;
                }
            } else {
                cbKunjungan.Enabled = false;
                labelIsiDataPasien.Text = "-\n-\n-\n-\n-\n-";
                cbKunjungan.DataSource = null;

                // matikan Diagnosa & Tindakan
                btnTambahDiagnosa.Enabled = false;
                btnHapusDiagnosa.Enabled = false;
                btnTambahTindakan.Enabled = false;
                btnHapusTindakan.Enabled = false;
                btnTambahObat.Enabled = false;
                btnHapusObat.Enabled = false;
                buttonSimpan.Enabled = false;
                butttonReset.Enabled = false;
                dgvObat.Rows.Clear();
                dgvDiagnosa.Rows.Clear();
                dgvTindakan.Rows.Clear();
                dgvDiagnosa.Enabled = false;
                dgvTindakan.Enabled = false;
                dgvObat.Enabled = false;
            }
        }

        private void cbKunjungan_SelectedIndexChanged(object sender, EventArgs e) {
            if (cbKunjungan.SelectedIndex > 0) {
                string id_kunjungan = cbKunjungan.Text.Split(' ')[0];
                pbid_kunjungan = id_kunjungan;
                pbjenis_kunjungan = cbKunjungan.SelectedValue.ToString();
                var query = $"SELECT * FROM kunjungan where id_kunjungan='{id_kunjungan}'";
                var dt = DBHelper.GetData(query);
                pbtanggal_masuk = dt.Rows[0]["tanggal_masuk"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["tanggal_masuk"]) : (DateTime?)null;
                if (dt.Rows[0]["id_poli"].ToString() != "") {
                    var dt_poli = DBHelper.GetData($"SELECT * FROM poli where id_poli='{dt.Rows[0]["id_poli"].ToString()}'");
                    var dt_dokter = DBHelper.GetData($"SELECT * FROM dokter where id_dokter='{dt.Rows[0]["id_dokter"].ToString()}'");
                    labelKunjungan.Text = cbKunjungan.SelectedValue.ToString()
                        + "\n" + dt_poli.Rows[0]["nama_poli"].ToString()
                        + "\n" + dt_dokter.Rows[0]["nama_dokter"].ToString()
                        + "\n\n\n" + (dt.Rows[0]["no_bpjs"].ToString() == "0" ? "NO" : "YES - " + dt.Rows[0]["no_bpjs"].ToString());
                    if (dt.Rows[0]["status"].ToString() == "menunggu")
                        cbStatus.SelectedIndex = 1;
                    else if (dt.Rows[0]["status"].ToString() == "menginap")
                        cbStatus.SelectedIndex = 2;
                } else {
                    labelKunjungan.Text = cbKunjungan.SelectedValue.ToString()
                        + "\n-" + "\n-" + "\n-" + "\n\n\n-";
                    labelKamar.Text = "-";
                    resetDataPilihKamar();
                    if (dt.Rows[0]["status"].ToString() == "menunggu")
                        cbStatus.SelectedIndex = 1;
                    else if (dt.Rows[0]["status"].ToString() == "menginap")
                        cbStatus.SelectedIndex = 2;
                }
                textBoxKeluhan.Text = dt.Rows[0]["keluhan"].ToString();
                if (dt.Rows[0]["status"].ToString() == "menunggu") {
                    checkBStatus.Checked = false;
                    checkBStatus.Enabled = true;
                    btnTambahDiagnosa.Enabled = true;
                    btnHapusDiagnosa.Enabled = true;
                    btnTambahTindakan.Enabled = true;
                    btnHapusTindakan.Enabled = true;
                    btnTambahObat.Enabled = true;
                    btnHapusObat.Enabled = true;
                    buttonSimpan.Enabled = true;
                    butttonReset.Enabled = true;
                    dgvObat.Enabled = true;
                    dgvDiagnosa.Enabled = true;
                    dgvTindakan.Enabled = true;
                    SetupGridTindakan();
                    SetupGridDiagnosa();
                    SetupGridObat();
                } else if (dt.Rows[0]["status"].ToString() == "menginap") {
                    checkBStatus.Checked = false;
                    checkBStatus.Enabled = true;
                    dgvObat.Rows.Clear();
                    dgvObat.Columns.Clear();
                    dgvDiagnosa.Rows.Clear();
                    dgvDiagnosa.Columns.Clear();
                    dgvTindakan.Rows.Clear();
                    dgvTindakan.Columns.Clear();

                    var dtHistoriKamar = DBHelper.GetData($@"SELECT hk.id_bed, k.nama_kamar FROM histori_kamar hk JOIN kamar k ON hk.id_kamar = k.id_kamar WHERE hk.id_kunjungan='{pbid_kunjungan}'AND hk.tanggal_keluar IS NULL ORDER BY hk.id_histori DESC LIMIT 1");

                    if (dtHistoriKamar.Rows.Count > 0) {
                        labelKamar.Text =
                            dtHistoriKamar.Rows[0]["nama_kamar"].ToString()
                            + ", "
                            + dtHistoriKamar.Rows[0]["id_bed"].ToString();
                    } else {
                        labelKamar.Text = "-";
                    }

                    // Load Diagnosa
                    dgvDiagnosa.Enabled = true;
                    dgvDiagnosa.RowHeadersVisible = false;
                    dgvDiagnosa.Columns.Add("diagnosa", "Diagnosa");
                    dgvDiagnosa.Columns.Add("tanggal", "Tanggal");
                    dgvDiagnosa.Columns.Add("isNew", "isNew");
                    dgvDiagnosa.Columns["isNew"].Visible = false;
                    dgvDiagnosa.Columns["diagnosa"].FillWeight = 60;
                    dgvDiagnosa.Columns["Tanggal"].FillWeight = 40;
                    var qDn = $"SELECT * FROM diagnosa WHERE id_kunjungan='{pbid_kunjungan}'";
                    var dtDn = DBHelper.GetData(qDn);
                    foreach (DataRow row in dtDn.Rows) {
                        dgvDiagnosa.Rows.Add(row["diagnosa"].ToString(), row["tanggal"].ToString(), false);
                    }

                    // Load Tindakan
                    dgvTindakan.Enabled = true;
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
                    var qTd = $"SELECT * FROM tindakan WHERE id_kunjungan='{pbid_kunjungan}'";
                    var dtTd = DBHelper.GetData(qTd);
                    foreach (DataRow row in dtTd.Rows) {
                        int i = dgvTindakan.Rows.Add(row["id_tindakan"], row["dokter"].ToString(), row["tanggal"].ToString(), row["harga"].ToString(), false);
                        dgvTindakan.Rows[i].ReadOnly = true;
                    }

                    // Load Obat
                    dgvObat.Enabled = true;
                    dgvObat.RowHeadersVisible = false;
                    DataGridViewComboBoxColumn colObat = new DataGridViewComboBoxColumn();
                    colObat.HeaderText = "Nama Obat";
                    colObat.Name = "obat";
                    colObat.Width = 100;
                    colObat.DataSource = DBHelper.GetData("SELECT * FROM obat ORDER BY nama_obat ASC");
                    colObat.DisplayMember = "nama_obat";
                    colObat.ValueMember = "id_obat";
                    dgvObat.Columns.Add(colObat);
                    dgvObat.Columns.Add("dosis", "Dosis");
                    dgvObat.Columns.Add("tanggal", "Tanggal");
                    dgvObat.Columns.Add("jumlah", "Jumlah");
                    dgvObat.Columns.Add("isNew", "isNew");
                    dgvObat.Columns["isNew"].Visible = false;
                    dgvObat.Columns["obat"].FillWeight = 30;
                    dgvObat.Columns["dosis"].FillWeight = 30;
                    dgvObat.Columns["tanggal"].FillWeight = 20;
                    dgvObat.Columns["jumlah"].FillWeight = 20;
                    var qOb = $"SELECT * FROM resep WHERE id_kunjungan='{pbid_kunjungan}'";
                    var dtOb = DBHelper.GetData(qOb);
                    foreach (DataRow row in dtOb.Rows) {
                        int i = dgvObat.Rows.Add(row["id_obat"].ToString(), row["dosis"].ToString(), row["tanggal"].ToString(), row["jumlah"].ToString(), false);
                        dgvObat.Rows[i].ReadOnly = true;
                    }

                    btnTambahDiagnosa.Enabled = true;
                    btnHapusDiagnosa.Enabled = true;
                    btnTambahTindakan.Enabled = true;
                    btnHapusTindakan.Enabled = true;
                    btnTambahObat.Enabled = true;
                    btnHapusObat.Enabled = true;
                    buttonSimpan.Enabled = true;
                    butttonReset.Enabled = false;
                    dgvObat.Enabled = true;
                    dgvDiagnosa.Enabled = true;
                    dgvTindakan.Enabled = true;
                } else {
                    btnTambahDiagnosa.Enabled = false;
                    btnHapusDiagnosa.Enabled = false;
                    btnTambahTindakan.Enabled = false;
                    btnHapusTindakan.Enabled = false;
                    btnTambahObat.Enabled = false;
                    btnHapusObat.Enabled = false;
                    buttonSimpan.Enabled = false;
                    butttonReset.Enabled = false;
                    checkBStatus.Enabled = false;
                    checkBStatus.Checked = false;

                    dgvDiagnosa.Enabled = false;
                    dgvDiagnosa.Rows.Clear();
                    dgvDiagnosa.Columns.Clear();

                    dgvTindakan.Enabled = false;
                    dgvTindakan.Rows.Clear();
                    dgvTindakan.Columns.Clear();

                    dgvObat.Enabled = false;
                    dgvObat.Rows.Clear();
                    dgvObat.Columns.Clear();
                }
            } else {
                labelKunjungan.Text = "-\n-\n-\n\n\n-";
                labelKamar.Text = "-";
                resetDataPilihKamar();
                cbStatus.SelectedIndex = 0;
                textBoxKeluhan.Text = "";
                btnTambahDiagnosa.Enabled = false;
                btnHapusDiagnosa.Enabled = false;
                btnTambahTindakan.Enabled = false;
                btnHapusTindakan.Enabled = false;
                btnTambahObat.Enabled = false;
                btnHapusObat.Enabled = false;
                buttonSimpan.Enabled = false;
                butttonReset.Enabled = false;
                dgvDiagnosa.Enabled = false;
                checkBStatus.Enabled = false;
                checkBStatus.Checked = false;

                dgvDiagnosa.Rows.Clear();
                dgvDiagnosa.Columns.Clear();

                dgvTindakan.Enabled = false;
                dgvTindakan.Rows.Clear();
                dgvTindakan.Columns.Clear();

                dgvObat.Enabled = false;
                dgvObat.Rows.Clear();
                dgvObat.Columns.Clear();
            }
        }

        private void butttonReset_Click(object sender, EventArgs e) {
            labelKamar.Text = "-";
            dgvObat.Rows.Clear();
            dgvObat.Columns.Clear();

            dgvDiagnosa.Rows.Clear();
            dgvDiagnosa.Columns.Clear();

            dgvTindakan.Rows.Clear();
            dgvTindakan.Columns.Clear();
        }

        void SetupGridDiagnosa() {
            dgvDiagnosa.Columns.Clear();
            
            dgvDiagnosa.Columns.Add("diagnosa", "Diagnosa");
            dgvDiagnosa.Columns.Add("tanggal", "Tanggal");
            dgvDiagnosa.Columns.Add("isNew", "isNew");
            dgvDiagnosa.Columns["isNew"].Visible = false;

            dgvDiagnosa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDiagnosa.RowHeadersVisible = false;
            dgvDiagnosa.AllowUserToAddRows = false;
            dgvDiagnosa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDiagnosa.DefaultCellStyle.Font = new Font("Segoe UI", 8);
            dgvDiagnosa.Columns["diagnosa"].FillWeight = 60;
            dgvDiagnosa.Columns["tanggal"].FillWeight = 40;

            dgvDiagnosa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDiagnosa.MultiSelect = false;
        }

        void SetupGridTindakan() {
            dgvTindakan.Columns.Clear();
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

            dgvTindakan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTindakan.RowHeadersVisible = false;
            dgvTindakan.AllowUserToAddRows = false;
            dgvTindakan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTindakan.DefaultCellStyle.Font = new Font("Segoe UI", 8);
            dgvTindakan.Columns["tindakan"].FillWeight = 25;
            dgvTindakan.Columns["dokter"].FillWeight = 30;
            dgvTindakan.Columns["tanggal"].FillWeight = 25;
            dgvTindakan.Columns["harga"].FillWeight = 20;

            dgvTindakan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTindakan.MultiSelect = false;
        }

        void SetupGridObat() {
            dgvObat.Columns.Clear();

            DataGridViewComboBoxColumn colObat = new DataGridViewComboBoxColumn();
            colObat.HeaderText = "Nama Obat";
            colObat.Name = "obat";
            colObat.Width = 100;

            colObat.DataSource = DBHelper.GetData("SELECT * FROM obat ORDER BY nama_obat ASC");
            colObat.DisplayMember = "nama_obat";
            colObat.ValueMember = "id_obat";

            dgvObat.Columns.Add(colObat);
            dgvObat.Columns.Add("dosis", "Dosis");
            dgvObat.Columns.Add("tanggal", "Tanggal");
            dgvObat.Columns.Add("jumlah", "Jumlah");
            dgvObat.Columns.Add("isNew", "isNew");
            dgvObat.Columns["isNew"].Visible = false;

            dgvObat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvObat.RowHeadersVisible = false;
            dgvObat.AllowUserToAddRows = false;
            dgvObat.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvObat.DefaultCellStyle.Font = new Font("Segoe UI", 8);
            dgvObat.Columns["obat"].FillWeight = 30;
            dgvObat.Columns["dosis"].FillWeight = 30;
            dgvObat.Columns["tanggal"].FillWeight = 20;
            dgvObat.Columns["jumlah"].FillWeight = 20;

            dgvObat.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvObat.MultiSelect = false;
        }

        private void buttonSimpan_Click(object sender, EventArgs e) {
            bool sDiagnosa = false;

            // VALIDASI DIAGNOSA
            foreach (DataGridViewRow row in dgvDiagnosa.Rows) {
                if (row.IsNewRow) continue;

                string diagnosa = row.Cells["diagnosa"].Value?.ToString();

                if (string.IsNullOrEmpty(diagnosa)) {
                    MessageBox.Show($"Silahkan isi diagnosa pada baris {row.Index + 1}");
                    return;
                } else {
                    sDiagnosa = true;
                }
            }

            // VALIDASI TINDAKAN
            foreach (DataGridViewRow row in dgvTindakan.Rows) {
                if (row.IsNewRow) continue;

                string tindakan = row.Cells["tindakan"].Value?.ToString();
                string dokter = row.Cells["dokter"].Value?.ToString();
                string harga = row.Cells["harga"].Value?.ToString();
                
                if (string.IsNullOrEmpty(tindakan) && string.IsNullOrEmpty(dokter) && string.IsNullOrEmpty(harga)) continue;

                // kalau sebagian diisi → wajib lengkap
                if (string.IsNullOrEmpty(tindakan)) {
                    MessageBox.Show($"Silahkan isi tindakan pada baris {row.Index + 1}");
                    return;
                }
                if (string.IsNullOrEmpty(dokter)) {
                    MessageBox.Show($"Silahkan isi dokter pada baris {row.Index + 1}");
                    return;
                }
                if (string.IsNullOrEmpty(harga)) {
                    MessageBox.Show($"Silahkan isi harga pada baris {row.Index + 1}");
                    return;
                }
            }

            // VALIDASI OBAT
            foreach (DataGridViewRow row in dgvObat.Rows) {
                if (row.IsNewRow) continue;

                string obat = row.Cells["obat"].Value?.ToString();
                string dosis = row.Cells["dosis"].Value?.ToString();
                string jumlah = row.Cells["jumlah"].Value?.ToString();

                // kosong semua → skip
                if (string.IsNullOrEmpty(obat) && string.IsNullOrEmpty(dosis) && string.IsNullOrEmpty(jumlah)) continue;

                // sebagian isi → wajib lengkap
                if (string.IsNullOrEmpty(obat)) {
                    MessageBox.Show($"Silahkan pilih obat pada baris {row.Index + 1}");
                    return;
                }
                if (string.IsNullOrEmpty(dosis)) {
                    MessageBox.Show($"Silahkan isi dosis pada baris {row.Index + 1}");
                    return;
                }
                if (string.IsNullOrEmpty(jumlah)) {
                    MessageBox.Show($"Silahkan isi jumlah pada baris {row.Index + 1}");
                    return;
                }
            }

            if(!sDiagnosa) {
                MessageBox.Show("Data Diagnosa harus diisi!");
                return;
            }

            try {
                // ================= OBAT =================
                foreach (DataGridViewRow row in dgvObat.Rows) {
                    if (row.IsNewRow) continue;

                    if (Convert.ToBoolean(row.Cells["isNew"].Value)) {
                        string obat = row.Cells["obat"].Value?.ToString();
                        string dosis = row.Cells["dosis"].Value?.ToString();
                        string tglStr = row.Cells["tanggal"].Value?.ToString();
                        DateTime tgl = Convert.ToDateTime(tglStr);
                        int jml;
                        int jumlah = int.TryParse(row.Cells["jumlah"].Value?.ToString(), out jml) ? jml : 0;

                        string query = "INSERT INTO resep (id_kunjungan, id_obat, dosis, tanggal, jumlah) VALUES (@id, @obat, @dosis, @tanggal, @jumlah)";

                        DBHelper.Execute(query,
                            new MySqlParameter("@id", pbid_kunjungan),
                            new MySqlParameter("@obat", obat),
                            new MySqlParameter("@dosis", dosis),
                            new MySqlParameter("@tanggal", tgl),
                            new MySqlParameter("@jumlah", jumlah)
                        );
                        row.Cells["isNew"].Value = false;
                    }
                }

                // ================= DIAGNOSA =================
                foreach (DataGridViewRow row in dgvDiagnosa.Rows) {
                    if (row.IsNewRow) continue;

                    if (Convert.ToBoolean(row.Cells["isNew"].Value)) {
                        string diagnosa = row.Cells["diagnosa"].Value?.ToString();
                        string tglStr = row.Cells["tanggal"].Value?.ToString();
                        DateTime tgl = Convert.ToDateTime(tglStr);

                        string query = "INSERT INTO diagnosa (id_kunjungan, tanggal, diagnosa) VALUES (@id, @tgl, @diag)";

                        DBHelper.Execute(query,
                            new MySqlParameter("@id", pbid_kunjungan),
                            new MySqlParameter("@tgl", tgl),
                            new MySqlParameter("@diag", diagnosa)
                        );
                        row.Cells["isNew"].Value = false;
                    }
                }

                // ================= TINDAKAN =================
                foreach (DataGridViewRow row in dgvTindakan.Rows) {
                    if (row.IsNewRow) continue;

                    if (Convert.ToBoolean(row.Cells["isNew"].Value)) {
                        string id_tindakan = row.Cells["tindakan"].Value?.ToString();
                        string dokter = row.Cells["dokter"].Value?.ToString();
                        string tglStr = row.Cells["tanggal"].Value?.ToString();
                        DateTime tgl = Convert.ToDateTime(tglStr);
                        int h;
                        int harga = int.TryParse(row.Cells["harga"].Value?.ToString(), out h) ? h : 0;

                        string query = "INSERT INTO tindakan (id_kunjungan, tanggal, id_tindakan, dokter, harga) VALUES (@id, @tgl, @id_tindakan, @dokter, @harga)";

                        DBHelper.Execute(query,
                            new MySqlParameter("@id", pbid_kunjungan),
                            new MySqlParameter("@tgl", tgl),
                            new MySqlParameter("@id_tindakan", id_tindakan),
                            new MySqlParameter("@dokter", dokter),
                            new MySqlParameter("@harga", harga)
                        );
                        row.Cells["isNew"].Value = false;
                    }
                }

                var queryk = $"SELECT * FROM kunjungan where id_kunjungan='{pbid_kunjungan}'";
                var dt = DBHelper.GetData(queryk);

                Debug.WriteLine("Masuk disini");

                if (dt.Rows[0]["status"].ToString() != "menginap") {
                    // ================= REKAM MEDIS =================
                    string queryRM = @"INSERT INTO rekam_medis 
        (no_rm, id_pasien, id_kunjungan, tanggal) 
        VALUES (@no_rm, @id_pasien, @id_kunjungan, @tanggal)";

                    DBHelper.Execute(queryRM,
                        new MySqlParameter("@no_rm", pbno_rm),
                        new MySqlParameter("@id_pasien", pbid_pasien),
                        new MySqlParameter("@id_kunjungan", pbid_kunjungan),
                        new MySqlParameter("@tanggal", DateTime.Now)
                    );
                    string queryUpdate = "UPDATE kunjungan SET tanggal_masuk = @tgl WHERE id_kunjungan = @id";
                    object tanggalMasuk = cbStatus.Text == "selesai" || cbStatus.Text == "menunggu" ? (object)DBNull.Value : DateTime.Now;
                    DBHelper.Execute(queryUpdate,
                        new MySqlParameter("@tgl", tanggalMasuk),
                        new MySqlParameter("@id", pbid_kunjungan)
                    );
                }

                if (dt.Rows[0]["status"].ToString() == "menunggu") {
                    string queryUpdate = "UPDATE kunjungan SET status = @status WHERE id_kunjungan = @id";
                    DBHelper.Execute(queryUpdate,
                        new MySqlParameter("@status", checkBStatus.Checked ? cbStatus.Text : "payment"),
                        new MySqlParameter("@id", pbid_kunjungan)
                    );

                    if (checkBStatus.Checked && cbStatus.Text == "menginap") {
                        DateTime tanggalMasuk = DateTime.Now;

                        string queryUpdateKJ =
                            "UPDATE kunjungan SET tanggal_masuk=@tglMasuk WHERE id_kunjungan=@id";

                        DBHelper.Execute(queryUpdateKJ,
                            new MySqlParameter("@id", pbid_kunjungan),
                            new MySqlParameter("@tglMasuk", tanggalMasuk)
                        );

                        string queryHistoriKamar = @"
INSERT INTO histori_kamar
(id_kunjungan, id_kamar, id_bed, tanggal_masuk, tanggal_keluar)
VALUES
(@id_kunjungan, @id_kamar, @id_bed, @tanggal_masuk, NULL)";

                        DBHelper.Execute(queryHistoriKamar,
                            new MySqlParameter("@id_kunjungan", pbid_kunjungan),
                            new MySqlParameter("@id_kamar", DataKamar.KodeKamar),
                            new MySqlParameter("@id_bed", DataKamar.Bed),
                            new MySqlParameter("@tanggal_masuk", tanggalMasuk)
                        );
                        string queryUpdateBed = $"UPDATE bed SET status=@status WHERE id_kamar=@id AND id_bed=@idBed";
                        DBHelper.Execute(queryUpdateBed,
                            new MySqlParameter("@status", "Terisi"),
                            new MySqlParameter("@id", DataKamar.KodeKamar),
                            new MySqlParameter("@idBed", DataKamar.Bed)
                        );
                    }
                } else if (dt.Rows[0]["status"].ToString() == "menginap") {
                    string queryUpdate = "UPDATE kunjungan SET status = @status WHERE id_kunjungan = @id";
                    DBHelper.Execute(queryUpdate,
                        new MySqlParameter("@status", cbStatus.Text == "menginap"? "menginap" : "payment"),
                        new MySqlParameter("@id", pbid_kunjungan)
                    );
                }

                if (cbStatus.Text == "selesai") {
                    // bed
                    if (dt.Rows[0]["status"].ToString() == "menginap") {

                        DateTime tanggalKeluar = DateTime.Now;

                        var dataHistori = DBHelper.GetData($@"
SELECT *
FROM histori_kamar
WHERE id_kunjungan='{pbid_kunjungan}'
AND tanggal_keluar IS NULL
ORDER BY id_histori DESC
LIMIT 1");

                        if (dataHistori.Rows.Count > 0) {
                            string idBed =
                                dataHistori.Rows[0]["id_bed"].ToString();

                            DBHelper.Execute(
                                "UPDATE bed SET status='Kosong' WHERE id_bed=@id_bed",
                                new MySqlParameter("@id_bed", idBed)
                            );

                            DBHelper.Execute(
                                @"UPDATE histori_kamar 
              SET tanggal_keluar=@tanggal_keluar 
              WHERE id_histori=@id_histori",
                                new MySqlParameter("@tanggal_keluar", tanggalKeluar),
                                new MySqlParameter("@id_histori", dataHistori.Rows[0]["id_histori"])
                            );
                        }

                        DBHelper.Execute(
                            "UPDATE kunjungan SET tanggal_keluar=@tgl WHERE id_kunjungan=@id",
                            new MySqlParameter("@tgl", tanggalKeluar),
                            new MySqlParameter("@id", pbid_kunjungan)
                        );
                    }
                    string queryUpdate = "UPDATE kunjungan SET status = @status WHERE id_kunjungan = @id";
                    DBHelper.Execute(queryUpdate,
                        new MySqlParameter("@status", "payment"),
                        new MySqlParameter("@id", pbid_kunjungan)
                    );
                    buttonSimpan.Enabled = false;
                }

                btnTambahDiagnosa.Enabled = false;
                btnHapusDiagnosa.Enabled = false;
                btnTambahTindakan.Enabled = false;
                btnHapusTindakan.Enabled = false;
                btnTambahObat.Enabled = false;
                btnHapusObat.Enabled = false;
                dgvObat.Enabled = false;
                dgvDiagnosa.Enabled = false;
                dgvTindakan.Enabled = false;
                cbStatus.Enabled = false;
                butttonReset.Enabled = false;
                checkBStatus.Checked = false;
                checkBStatus.Enabled = false;
                MessageBox.Show("Data berhasil disimpan!");
                loadCBKunjungan();
            } catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnTambahDiagnosa_Click(object sender, EventArgs e) {
            dgvDiagnosa.Rows.Add("", DateTime.Now, true);
        }

        private void btnHapusDiagnosa_Click(object sender, EventArgs e) {
            if (dgvDiagnosa.SelectedRows.Count > 0) {
                if (MessageBox.Show("Hapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    dgvDiagnosa.Rows.RemoveAt(dgvDiagnosa.SelectedRows[0].Index);
                }
            } else {
                MessageBox.Show("Pilih data dulu!");
            }
        }

        private void btnTambahTindakan_Click(object sender, EventArgs e) {
            dgvTindakan.Rows.Add("", "", DateTime.Now, "", true);
        }

        private void btnHapusTindakan_Click(object sender, EventArgs e) {
            if (dgvTindakan.SelectedRows.Count > 0) {
                if (MessageBox.Show("Hapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    dgvTindakan.Rows.RemoveAt(dgvTindakan.SelectedRows[0].Index);
                }
            } else {
                MessageBox.Show("Pilih data dulu!");
            }
        }

        private void btnTambahObat_Click(object sender, EventArgs e) {
            dgvObat.Rows.Add("", "", DateTime.Now, "", true);
        }

        private void btnHapusObat_Click(object sender, EventArgs e) {
            if (dgvObat.SelectedRows.Count > 0) {
                if (MessageBox.Show("Hapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    dgvObat.Rows.RemoveAt(dgvObat.SelectedRows[0].Index);
                }
            } else {
                MessageBox.Show("Pilih data dulu!");
            }
        }

        private void checkBStatus_CheckedChanged(object sender, EventArgs e) {
            var query = $"SELECT * FROM kunjungan where id_kunjungan='{pbid_kunjungan}'";
            var dt = DBHelper.GetData(query);
            if (checkBStatus.Checked) {
                cbStatus.Enabled = true;
            } else {
                cbStatus.Enabled = false;
                if (dt.Rows[0]["status"].ToString() == "menunggu")
                    cbStatus.SelectedIndex = 1;
                else if (dt.Rows[0]["status"].ToString() == "menginap")
                    cbStatus.SelectedIndex = 2;
            }
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e) {
            var queryDataPasien = $"SELECT * FROM kunjungan where id_kunjungan='{pbid_kunjungan}'";
            var data = DBHelper.GetData(queryDataPasien);
            if (checkBStatus.Checked && data.Rows[0]["status"].ToString() == "menunggu" && cbStatus.Text == "menginap") {
                pilihKamar frm = new pilihKamar(data);
                if (frm.ShowDialog() == DialogResult.OK) {
                    labelKamar.Text = $"{DataKamar.Kamar}, {DataKamar.Bed}";
                }
            } else if (checkBStatus.Checked && data.Rows[0]["status"].ToString() == "menginap" && (cbStatus.Text == "menunggu" || cbStatus.Text == "-")) {
                MessageBox.Show("Tidak bisa memilih status tersebut, karena status pasien menginap!");
                cbStatus.SelectedIndex = 2;
            }
        }

        void resetDataPilihKamar() {
            DataKamar.Kamar = "";
            DataKamar.KodeKamar = "";
            DataKamar.Bed = "";
        }

        private void dgvTindakan_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            if (e.ColumnIndex == dgvTindakan.Columns["tindakan"].Index && e.RowIndex >= 0) {
                var id_tindakan = dgvTindakan.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                var dtTD = DBHelper.GetData($"SELECT data_tindakan.harga, dokter.nama_dokter FROM data_tindakan JOIN dokter ON data_tindakan.id_dokter = dokter.id_dokter WHERE id_tindakan='{id_tindakan}'");
                dgvTindakan.Rows[e.RowIndex].Cells["harga"].Value = dtTD.Rows[0]["harga"].ToString();
                dgvTindakan.Rows[e.RowIndex].Cells["dokter"].Value = dtTD.Rows[0]["nama_dokter"].ToString();
            }
        }

        private void dgvTindakan_CurrentCellDirtyStateChanged(object sender, EventArgs e) {
            if (dgvTindakan.IsCurrentCellDirty) {
                dgvTindakan.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
    }
}