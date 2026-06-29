using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace RSUD_SYSTEM {
    public partial class menuPembayaran : Form {

        public int subtotalAsli = 0;
        public int subsidiBPJS = 0;

        public menuPembayaran() {
            InitializeComponent();
        }

        private void menuPembayaran_Load(object sender, EventArgs e) {
            tabPembayaran.DrawItem += tabPembayaran_DrawItem;
            SetupGrid();
            
            var dataPasien = DBHelper.GetData($"SELECT k.no_rm, CONCAT(p.nama, ' - ', p.no_rm) AS displayText FROM kunjungan k JOIN pasien p ON k.no_rm = p.no_rm WHERE k.status='payment' GROUP BY k.no_rm");
            DataRow row = dataPasien.NewRow();
            row["displayText"] = "Pilih Pasien";
            row["no_rm"] = "";

            dataPasien.Rows.InsertAt(row, 0);
            cbPasien.DataSource = dataPasien;
            cbPasien.DisplayMember = "displayText";
            cbPasien.ValueMember = "no_rm";

            cbPasien.SelectedIndex = 0;
            panelGaris.Height = 1;
            panelGaris2.Height = 1;
        }

        private void tabPembayaran_DrawItem(object sender, DrawItemEventArgs e) {
            Graphics g = e.Graphics;
            TabPage tabPage = tabPembayaran.TabPages[e.Index];
            Rectangle tabRect = tabPembayaran.GetTabRect(e.Index);

            bool isSelected = (e.Index == tabPembayaran.SelectedIndex);

            Color bgColor = isSelected ? Color.FromArgb(33, 150, 243) : Color.White;
            Color textColor = isSelected ? Color.White : Color.Black;

            using (SolidBrush bgBrush = new SolidBrush(bgColor)) {
                g.FillRectangle(bgBrush, tabRect);
            }

            using (SolidBrush textBrush = new SolidBrush(textColor)) {
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;

                g.DrawString(tabPage.Text, new Font("Segoe UI", 8, FontStyle.Bold), textBrush, tabRect, sf);
            }
            
            if (isSelected) {
                using (Pen pen = new Pen(Color.FromArgb(0, 102, 204), 3)) {
                    g.DrawLine(pen,
                        tabRect.Left,
                        tabRect.Bottom - 1,
                        tabRect.Right,
                        tabRect.Bottom - 1);
                }
            }
        }

        void SetStyleDGV(DataGridView dgv) {
            dgv.Font = new Font("Segoe UI", 8);
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 8);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8, FontStyle.Bold);

            dgv.RowHeadersVisible = false;
            dgv.EnableHeadersVisualStyles = false;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(33, 150, 243);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.BackgroundColor = Color.White;

            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgv.RowTemplate.Height = 20;

            dgv.ReadOnly = true;
            dgv.ClearSelection();
            dgv.DefaultCellStyle.SelectionBackColor = dgv.DefaultCellStyle.BackColor;
            dgv.DefaultCellStyle.SelectionForeColor = dgv.DefaultCellStyle.ForeColor;
            dgv.SelectionChanged += (s, e) => {
                dgv.ClearSelection();
            };
        }

        void SetupGrid() {
            dgvRingkasan.AllowUserToAddRows = false;
            dgvKamar.AllowUserToAddRows = false;
            dgvObat.AllowUserToAddRows = false;
            dgvTindakan.AllowUserToAddRows = false;
            
            dgvRingkasan.Columns.Add("no", "No");
            dgvRingkasan.Columns.Add("jenis", "Jenis Biaya");
            dgvRingkasan.Columns.Add("item", "Item");
            dgvRingkasan.Columns.Add("qty", "Qty");
            dgvRingkasan.Columns.Add("subtotal", "Subtotal");
            dgvRingkasan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRingkasan.Columns["no"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvRingkasan.Columns["no"].Width = 40;
            dgvRingkasan.Columns["jenis"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvRingkasan.Columns["item"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvRingkasan.Columns["qty"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvRingkasan.Columns["subtotal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvRingkasan.Columns["subtotal"].Width = 110;
            dgvRingkasan.RowHeadersVisible = false;
            dgvRingkasan.BorderStyle = BorderStyle.None;
            dgvRingkasan.BackgroundColor = Color.White;
            dgvRingkasan.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            SetStyleDGV(dgvRingkasan);
            
            dgvObat.Columns.Add("no", "No");
            dgvObat.Columns.Add("nama", "Nama Obat");
            dgvObat.Columns.Add("qty", "Qty");
            dgvObat.Columns.Add("harga", "Harga");
            dgvObat.Columns.Add("total", "Total");
            dgvObat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvObat.Columns["no"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvObat.Columns["no"].Width = 40;
            dgvObat.Columns["nama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvObat.Columns["qty"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvObat.Columns["harga"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvObat.Columns["harga"].Width = 110;
            dgvObat.Columns["total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvObat.Columns["total"].Width = 120;
            dgvObat.RowHeadersVisible = false;
            dgvObat.BorderStyle = BorderStyle.None;
            dgvObat.BackgroundColor = Color.White;
            dgvObat.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            SetStyleDGV(dgvObat);
            
            dgvTindakan.Columns.Add("no", "No");
            dgvTindakan.Columns.Add("nama", "Nama Tindakan");
            dgvTindakan.Columns.Add("dokter", "Nama Dokter");
            dgvTindakan.Columns.Add("harga", "Harga");
            dgvTindakan.Columns["no"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvTindakan.Columns["no"].Width = 40;
            dgvTindakan.Columns["nama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvTindakan.Columns["dokter"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvTindakan.Columns["harga"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvTindakan.Columns["harga"].Width = 110;
            dgvTindakan.RowHeadersVisible = false;
            dgvTindakan.BorderStyle = BorderStyle.None;
            dgvTindakan.BackgroundColor = Color.White;
            dgvTindakan.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            SetStyleDGV(dgvTindakan);
            
            dgvKamar.Columns.Add("no", "No");
            dgvKamar.Columns.Add("nama", "Nama Kamar");
            dgvKamar.Columns.Add("periode", "Periode");
            dgvKamar.Columns.Add("harga", "Harga");
            dgvKamar.Columns.Add("lama", "Lama\nInap");
            dgvKamar.Columns.Add("subtotal", "Subtotal");
            dgvKamar.Columns.Add("subsidi", "Subsidi BPJS");
            dgvKamar.Columns.Add("total", "Total");

            dgvKamar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKamar.Columns["no"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvKamar.Columns["no"].Width = 45;
            dgvKamar.Columns["nama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvKamar.Columns["periode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvKamar.Columns["periode"].Width = 80;
            dgvKamar.Columns["harga"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvKamar.Columns["harga"].Width = 95;
            dgvKamar.Columns["lama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvKamar.Columns["lama"].Width = 45;
            dgvKamar.Columns["subtotal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvKamar.Columns["subtotal"].Width = 90;
            dgvKamar.Columns["subsidi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvKamar.Columns["subsidi"].Width = 100;
            dgvKamar.Columns["total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvKamar.Columns["total"].Width = 95;
            dgvKamar.RowHeadersVisible = false;
            dgvKamar.BorderStyle = BorderStyle.None;
            dgvKamar.BackgroundColor = Color.White;
            dgvKamar.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvKamar.RowTemplate.Height = 28;
            dgvKamar.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvKamar.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvKamar.Columns["no"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvKamar.Columns["lama"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            SetStyleDGV(dgvKamar);
        }

        void LoadDataObat(string idKunjungan) {
            dgvObat.Rows.Clear();
            string query = $@"
SELECT 
    o.nama_obat,
    d.jumlah,
    o.harga,
    (d.jumlah * o.harga) AS total
FROM kunjungan k
JOIN resep d ON k.id_kunjungan = d.id_kunjungan
JOIN obat o ON d.id_obat = o.id_obat
WHERE k.status = 'payment' AND k.id_kunjungan = '{idKunjungan}'";
            DataTable dt = DBHelper.GetData(query);
            int no = 1;
            foreach (DataRow row in dt.Rows) {
                int qty = row["jumlah"] == DBNull.Value ? 0 : Convert.ToInt32(row["jumlah"]);
                int harga = row["harga"] == DBNull.Value ? 0 : Convert.ToInt32(row["harga"]);
                int total = row["total"] == DBNull.Value ? 0 : Convert.ToInt32(row["total"]);

                dgvObat.Rows.Add(
                    no++,
                    row["nama_obat"].ToString(),
                    qty,
                    "Rp " + harga.ToString("N0"),
                    "Rp " + total.ToString("N0")
                );
            }
        }

        void LoadDataTindakan(string idKunjungan) {
            dgvTindakan.Rows.Clear();
            string query = $@"
SELECT 
    t.nama_tindakan,
    d.dokter,
    d.harga
FROM kunjungan k
JOIN tindakan d ON k.id_kunjungan = d.id_kunjungan
JOIN data_tindakan t ON d.id_tindakan = t.id_tindakan
WHERE k.status = 'payment' AND k.id_kunjungan = '{idKunjungan}'";
            DataTable dt = DBHelper.GetData(query);

            int no = 1;
            foreach (DataRow row in dt.Rows) {
                int harga = row["harga"] == DBNull.Value ? 0 : Convert.ToInt32(row["harga"]);
                dgvTindakan.Rows.Add(
                    no++,
                    row["nama_tindakan"].ToString(),
                    row["dokter"].ToString(),
                    "Rp " + harga.ToString("N0")
                );
            }
        }

        void LoadDataKamar(string idKunjungan) {
            dgvKamar.Rows.Clear();

            if (string.IsNullOrWhiteSpace(idKunjungan) || idKunjungan == "Pilih Kunjungan")
                return;

            string jenisPasien = labelJenisBayar.Text;
            string query = @"
SELECT 
    hk.id_histori,
    k.nama_kamar,
    k.tipe_kamar,
    hk.id_bed,
    b.harga,
    hk.tanggal_masuk,
    hk.tanggal_keluar
FROM histori_kamar hk
JOIN kamar k ON hk.id_kamar = k.id_kamar
JOIN bed b ON hk.id_bed = b.id_bed
WHERE hk.id_kunjungan = @id
ORDER BY hk.tanggal_masuk ASC, hk.id_histori ASC";

            DataTable dt = DBHelper.GetData(query, new MySqlParameter("@id", idKunjungan));
            List<string> idYangDihitung = new List<string>();

            var rows = dt.AsEnumerable().ToList();
            foreach (DataRow row in rows) {
                DateTime masuk = Convert.ToDateTime(row["tanggal_masuk"]);
                DateTime keluar = row["tanggal_keluar"] != DBNull.Value ? Convert.ToDateTime(row["tanggal_keluar"]) : DateTime.Now;
                TimeSpan durasi = keluar - masuk;
                if (durasi.TotalHours >= 24) {
                    idYangDihitung.Add(row["id_histori"].ToString());
                }
            }
            
            var grupKurangSehari = rows.Where(row => {
                    DateTime masuk = Convert.ToDateTime(row["tanggal_masuk"]);
                    DateTime keluar = row["tanggal_keluar"] != DBNull.Value ? Convert.ToDateTime(row["tanggal_keluar"]) : DateTime.Now;
                    return (keluar - masuk).TotalHours < 24;
                }).GroupBy(row => Convert.ToDateTime(row["tanggal_masuk"]).Date);

            foreach (var grup in grupKurangSehari) {
                var list = grup
                    .OrderBy(r => Convert.ToDateTime(r["tanggal_masuk"]))
                    .ThenBy(r => Convert.ToInt32(r["id_histori"]))
                    .ToList();
                
                DataRow kamarTerakhir = list.Last();
                string idKamarTerakhir = kamarTerakhir["id_histori"].ToString();

                if (!idYangDihitung.Contains(idKamarTerakhir)) {
                    idYangDihitung.Add(idKamarTerakhir);
                }
                
                if (jenisPasien == "BPJS") {
                    DataRow vipTerakhir = list
                        .Where(r => {
                            string tipe = r["tipe_kamar"].ToString().ToUpper();
                            return tipe == "VIP" || tipe == "VVIP";
                        }).LastOrDefault();
                    if (vipTerakhir != null) {
                        string idVipTerakhir = vipTerakhir["id_histori"].ToString();
                        if (!idYangDihitung.Contains(idVipTerakhir)) {
                            idYangDihitung.Add(idVipTerakhir);
                        }
                    }
                }
            }

            int no = 1;

            foreach (DataRow row in rows) {
                string idHistori = row["id_histori"].ToString();
                bool dihitung = idYangDihitung.Contains(idHistori);

                DateTime masuk = Convert.ToDateTime(row["tanggal_masuk"]);
                DateTime keluar = row["tanggal_keluar"] != DBNull.Value ? Convert.ToDateTime(row["tanggal_keluar"]) : DateTime.Now;
                TimeSpan durasi = keluar - masuk;

                int lama = 0;

                if (dihitung) {
                    lama = (keluar.Date - masuk.Date).Days;
                    if (lama <= 0)
                        lama = 1;
                }

                int hargaAsli = row["harga"] == DBNull.Value ? 0 : Convert.ToInt32(row["harga"]);
                string tipeKamar = row["tipe_kamar"].ToString();

                int subtotal = dihitung ? hargaAsli * lama : 0;
                int subsidi = 0;

                if (dihitung && jenisPasien == "BPJS") {
                    if (tipeKamar == "Reguler") {
                        subsidi = subtotal;
                    } else if (tipeKamar == "VIP" || tipeKamar == "VVIP") {
                        subsidi = subtotal * 25 / 100;
                    }
                }

                int total = subtotal - subsidi;
                string periode = masuk.ToString("dd/MM") + " - " + keluar.ToString("dd/MM");

                dgvKamar.Rows.Add(
                    no++,
                    row["nama_kamar"].ToString() + " - " + tipeKamar + " - Bed " + row["id_bed"].ToString(),
                    periode,
                    "Rp " + hargaAsli.ToString("N0"),
                    dihitung ? lama.ToString() : "-",
                    dihitung ? "Rp " + subtotal.ToString("N0") : "-",
                    dihitung && subsidi > 0 ? "Rp " + subsidi.ToString("N0") : "-",
                    dihitung ? "Rp " + total.ToString("N0") : "-"
                );
            }
        }

        void UpdateRingkasan() {
            dgvRingkasan.Rows.Clear();
            int total = 0;
            int no = 1;
            
            var data = DBHelper.GetData(@"SELECT biayaLayanan, id_poli FROM kunjungan WHERE id_kunjungan = @id AND status = 'payment'",
                new MySqlParameter("@id", cbKunjungan.Text)
            );

            int biayaLayanan = 0;
            string idPoli = "";

            if (data.Rows.Count > 0) {
                biayaLayanan = data.Rows[0]["biayaLayanan"] != DBNull.Value ? Convert.ToInt32(data.Rows[0]["biayaLayanan"]) : 0;

                idPoli = data.Rows[0]["id_poli"].ToString();
                var dataPoli = DBHelper.GetData(@"SELECT nama_poli FROM poli WHERE id_poli = @id",
                    new MySqlParameter("@id", idPoli)
                );
                string namaPoli = "-";
                if (dataPoli.Rows.Count > 0) {
                    namaPoli = dataPoli.Rows[0]["nama_poli"].ToString();
                }

                total += biayaLayanan;
                dgvRingkasan.Rows.Add(
                    no++,
                    "Biaya Layanan",
                    namaPoli,
                    "1",
                    "Rp " + biayaLayanan.ToString("N0")
                );
            }
            
            if (dgvKamar.Rows.Count > 0) {
                int totalKamar = 0;
                int jumlahItem = dgvKamar.Rows
                    .Cast<DataGridViewRow>()
                    .Count(r => !r.IsNewRow);

                foreach (DataGridViewRow row in dgvKamar.Rows) {
                    if (row.IsNewRow) continue;

                    string subtotalText = row.Cells["subtotal"].Value?.ToString();

                    if (string.IsNullOrWhiteSpace(subtotalText) || subtotalText == "-")
                        continue;

                    int t = Convert.ToInt32(
                        subtotalText.Replace("Rp", "")
                                    .Replace(".", "")
                                    .Replace(",", "")
                                    .Trim()
                    );

                    totalKamar += t;
                }

                int lamaAsli = 0;

                if (tbMasuk.Text != "-" && tbKeluar.Text != "-") {
                    DateTime masuk = DateTime.ParseExact(tbMasuk.Text, "dd/MM/yyyy HH:mm:ss", null);
                    DateTime keluar = DateTime.ParseExact(tbKeluar.Text, "dd/MM/yyyy HH:mm:ss", null);

                    lamaAsli = (keluar.Date - masuk.Date).Days;
                    if (lamaAsli <= 0) lamaAsli = 1;
                }

                total += totalKamar;

                dgvRingkasan.Rows.Add(
                    no++,
                    "Kamar",
                    $"{jumlahItem} item",
                    $"{lamaAsli} hari",
                    "Rp " + totalKamar.ToString("N0")
                );
            }
            
            if (dgvObat.Rows.Count > 0) {
                int totalObat = 0;
                int qty = 0;
                int jumlahItem = 0;

                foreach (DataGridViewRow row in dgvObat.Rows) {
                    if (row.IsNewRow) continue;

                    int q = Convert.ToInt32(row.Cells["qty"].Value);
                    int t = Convert.ToInt32(row.Cells["total"].Value.ToString().Replace("Rp", "").Replace(".", "").Trim());

                    qty += q;
                    totalObat += t;
                    jumlahItem++;
                }

                total += totalObat;
                dgvRingkasan.Rows.Add(
                    no++,
                    "Obat",
                    $"{jumlahItem} item",
                    qty,
                    "Rp " + totalObat.ToString("N0")
                );
            }
            
            if (dgvTindakan.Rows.Count > 0) {
                int totalTindakan = 0;
                int qty = 0;
                int jumlahItem = 0;

                foreach (DataGridViewRow row in dgvTindakan.Rows) {
                    if (row.IsNewRow) continue;

                    int q = 1;
                    int t = Convert.ToInt32(row.Cells["harga"].Value.ToString().Replace("Rp", "").Replace(".", "").Trim());

                    qty += q;
                    totalTindakan += t;
                    jumlahItem++;
                }

                total += totalTindakan;
                dgvRingkasan.Rows.Add(
                    no++,
                    "Tindakan",
                    $"{jumlahItem} item",
                    qty,
                    "Rp " + totalTindakan.ToString("N0")
                );
            }
            labelTotal.Text = total.ToString("N0");
        }

        private void tbCari_Enter(object sender, EventArgs e) {
            if (tbCari.Text == "No. RM / Nama / ID Kunjungan") {
                tbCari.Text = "";
            }
        }

        private void tbCari_Leave(object sender, EventArgs e) {
            if (tbCari.Text == "") {
                tbCari.Text = "No. RM / Nama / ID Kunjungan";
            }
        }

        private void cbPasien_SelectedIndexChanged(object sender, EventArgs e) {
            Debug.WriteLine(cbPasien.SelectedIndex);
            if (cbPasien.SelectedIndex > 0) {
                var dataKunjungan = DBHelper.GetData($"SELECT * FROM kunjungan k JOIN pasien p ON p.no_rm = k.no_rm WHERE k.no_rm='{cbPasien.SelectedValue}' AND status='payment'");
                labelNama.Text = dataKunjungan.Rows[0]["nama"].ToString();
                labelNoRM.Text = dataKunjungan.Rows[0]["no_rm"].ToString();
                labelAlamat.Text = dataKunjungan.Rows[0]["alamat"].ToString();
                DataRow row = dataKunjungan.NewRow();
                row["id_kunjungan"] = "Pilih Kunjungan";
                cbKunjungan.Enabled = true;
                dataKunjungan.Rows.InsertAt(row, 0);
                cbKunjungan.DataSource = dataKunjungan;
                cbKunjungan.DisplayMember = "id_kunjungan";
                cbKunjungan.SelectedIndex = 0;
            } else {
                resetPasien();
                resetKunjungan();
            }
        }

        void resetPasien() {
            labelNama.Text = "-";
            labelNoRM.Text = "-";
            labelAlamat.Text = "-";

            cbKunjungan.DataSource = null;
            cbKunjungan.Items.Clear();
            cbKunjungan.SelectedIndex = -1;
            cbKunjungan.Text = "";
            cbKunjungan.Enabled = false;
        }

        void resetKunjungan() {
            tbPoliklinik.Text = "-";
            tbDokter.Text = "-";
            tbKamar.Text = "-";
            tbMasuk.Text = "-";
            tbKeluar.Text = "-";
            tbLamaInap.Text = "-";
            labelJenisBayar.Text = "-";

            LoadDataKamar("");
            LoadDataObat("");
            LoadDataTindakan("");
            UpdateRingkasan();

            labelSubtotal.Text = "0";
            labelBPJS.Text = "0";
            labelBPJS.ForeColor = Color.Black;
            tbDiskon.Text = "0"; tbDiskon.Enabled = false;
            labelTotalBayar.Text = "0";

            tbBayar.Text = "0"; tbBayar.Enabled = false;
            tbKembali.Text = "0";
            rbTunai.Checked = true;
            rbTunai.Enabled = false;
            rbTransfer.Enabled = false;
            rbBPJS.Enabled = false;
        }

        private void cbKunjungan_SelectedIndexChanged(object sender, EventArgs e) {
            if (cbKunjungan.SelectedIndex != 0) {
                resetKunjungan();
                var dataKunjungan = DBHelper.GetData($"SELECT * FROM kunjungan WHERE id_kunjungan='{cbKunjungan.Text}'");
                if (dataKunjungan.Rows.Count > 0) {
                    labelJenisBayar.Text = dataKunjungan.Rows[0]["jenis_pasien"].ToString();
                    var dataPoli = DBHelper.GetData($"SELECT nama_poli FROM poli WHERE id_poli='{dataKunjungan.Rows[0]["id_poli"].ToString()}'");
                    tbPoliklinik.Text = dataPoli.Rows.Count > 0 ? dataPoli.Rows[0]["nama_poli"] != DBNull.Value ? dataPoli.Rows[0]["nama_poli"].ToString() : "IGD" : "IGD";
                    var dataDokter = DBHelper.GetData($"SELECT nama_dokter FROM dokter WHERE id_dokter='{dataKunjungan.Rows[0]["id_dokter"].ToString()}'");
                    tbDokter.Text = dataDokter.Rows.Count > 0 ? dataDokter.Rows[0]["nama_dokter"].ToString() : "-";
                    var dataKamar = DBHelper.GetData($"SELECT CONCAT(k.nama_kamar, ' ', h.id_bed) AS displayText FROM histori_kamar h JOIN kamar k ON k.id_kamar = h.id_kamar WHERE id_kunjungan='{cbKunjungan.Text}' order by h.id_histori DESC");
                    tbKamar.Text = dataKamar.Rows.Count > 0 ? dataKamar.Rows[0]["displayText"].ToString() : "-";

                    var dataMasuk = DBHelper.GetData($@"
SELECT tanggal_masuk
FROM histori_kamar
WHERE id_kunjungan='{cbKunjungan.Text}'
ORDER BY id_histori ASC
LIMIT 1");

                    DateTime tanggalMasukk;

                    if (dataMasuk.Rows.Count > 0 && dataMasuk.Rows[0]["tanggal_masuk"] != DBNull.Value) {
                        tanggalMasukk = Convert.ToDateTime(dataMasuk.Rows[0]["tanggal_masuk"]);
                    } else {
                        tanggalMasukk = Convert.ToDateTime(dataKunjungan.Rows[0]["tanggal_masuk"] == DBNull.Value ? dataKunjungan.Rows[0]["tanggal"] : dataKunjungan.Rows[0]["tanggal_masuk"]);
                    }

                    tbMasuk.Text = tanggalMasukk.ToString("dd/MM/yyyy HH:mm:ss");
                    DateTime tanggalMasuk = Convert.ToDateTime(dataKunjungan.Rows[0]["tanggal_masuk"] == DBNull.Value ? dataKunjungan.Rows[0]["tanggal"] : dataKunjungan.Rows[0]["tanggal_masuk"]);

                    tbMasuk.Text = tanggalMasuk.ToString("dd/MM/yyyy HH:mm:ss");
                    tbKeluar.Text = dataKunjungan.Rows[0]["tanggal_keluar"] != DBNull.Value ? Convert.ToDateTime(dataKunjungan.Rows[0]["tanggal_keluar"]).ToString("dd/MM/yyyy HH:mm:ss") : "-";
                    
                    LoadDataKamar(cbKunjungan.Text);
                    LoadDataObat(cbKunjungan.Text);
                    LoadDataTindakan(cbKunjungan.Text);
                    HitungLamaInap();

                    UpdateRingkasan();
                    
                    labelSubtotal.Text = labelTotal.Text;

                    if (labelJenisBayar.Text == "BPJS") {
                        int subtotal = int.Parse(Regex.Replace(labelTotal.Text, @"\D", ""));
                        int totalBayar = 0;

                        foreach (DataGridViewRow row in dgvKamar.Rows) {
                            if (row.IsNewRow) continue;

                            string totalText = row.Cells["total"].Value?.ToString();

                            if (string.IsNullOrWhiteSpace(totalText) || totalText == "-")
                                continue;

                            int totalKamar = int.Parse(Regex.Replace(totalText, @"\D", ""));
                            totalBayar += totalKamar;
                        }

                        int subsidi = subtotal - totalBayar;

                        subtotalAsli = subtotal;
                        subsidiBPJS = subsidi;

                        labelBPJS.Text = "Rp " + subsidi.ToString("N0");
                        labelBPJS.ForeColor = Color.Green;
                        labelTotalBayar.Text = totalBayar.ToString("N0");

                        tbDiskon.Enabled = false;

                        if (totalBayar > 0) {
                            tbDiskon.Enabled = true;
                            tbDiskon.Text = "0";
                            rbBPJS.Enabled = false;
                            rbTunai.Enabled = true;
                            rbTransfer.Enabled = true;
                            rbTunai.Checked = true;
                            tbBayar.Enabled = true;
                            tbBayar.ReadOnly = false;
                        } else {
                            tbDiskon.Enabled = false;
                            tbDiskon.Text = "0";
                            rbBPJS.Enabled = true;
                            rbBPJS.Checked = true;
                            rbTunai.Enabled = false;
                            rbTransfer.Enabled = false;
                            tbBayar.Enabled = true;
                            tbBayar.ReadOnly = true;
                        }
                    } else {
                        labelBPJS.Text = "(Pasien Umum)";
                        labelBPJS.ForeColor = Color.Gray;
                        tbDiskon.Enabled = true;
                        labelTotalBayar.Text = labelTotal.Text;
                        subtotalAsli = int.Parse(Regex.Replace(labelTotal.Text, @"\D", ""));
                        subsidiBPJS = 0;

                        rbTunai.Enabled = true;
                        rbTransfer.Enabled = true;
                        rbBPJS.Enabled = false;
                        rbTunai.Checked = true;
                        tbBayar.Enabled = true;
                        tbBayar.ReadOnly = false;
                    }
                }
            } else {
                resetKunjungan();
            }
        }

        void HitungLamaInap() {
            if (tbMasuk.Text == "-" || tbKeluar.Text == "-") {
                tbLamaInap.Text = "-";
                return;
            }

            DateTime masuk = DateTime.ParseExact(
                tbMasuk.Text,
                "dd/MM/yyyy HH:mm:ss",
                null
            );

            DateTime keluar = DateTime.ParseExact(
                tbKeluar.Text,
                "dd/MM/yyyy HH:mm:ss",
                null
            );

            int lama = (keluar.Date - masuk.Date).Days;

            if (lama <= 0)
                lama = 1;

            tbLamaInap.Text = lama + " hari";
        }

        private void btnCari_Click(object sender, EventArgs e) {
            string keyword = tbCari.Text.Trim();

            if (string.IsNullOrEmpty(keyword) || keyword == "No. RM / Nama / ID Kunjungan") {
                MessageBox.Show("Masukkan kata kunci dulu!");
                return;
            }

            try {
                cbPasien.DataSource = null;

                string query = $@"SELECT 
    k.id_kunjungan,
    p.no_rm,
    p.nama,
CONCAT(p.nama, ' - ', p.no_rm) AS display_text
FROM kunjungan k
JOIN pasien p ON k.no_rm = p.no_rm
WHERE 
    p.no_rm LIKE '%{keyword}%' OR
    p.nama LIKE '%{keyword}%' OR
    k.id_kunjungan LIKE '%{keyword}%'
ORDER BY p.nama ASC
LIMIT 1";

                DataTable dt = DBHelper.GetData(query);

                if (dt.Rows.Count == 0) {
                    MessageBox.Show("Data tidak ditemukan!");
                    return;
                }

                cbPasien.DataSource = dt;
                DataRow row = dt.NewRow();
                row["display_text"] = "Data Ditemukan, Pilih Pasien";
                row["no_rm"] = "";

                dt.Rows.InsertAt(row, 0);
                cbPasien.DisplayMember = "display_text";
                cbPasien.ValueMember = "no_rm";
                cbPasien.SelectedIndex = 0;
            } catch (Exception ex) {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void tbCari_TextChanged(object sender, EventArgs e) {
            if (tbCari.Text == "") {
                var dataPasien = DBHelper.GetData($"SELECT k.no_rm, CONCAT(p.nama, ' - ', p.no_rm) AS displayText FROM kunjungan k JOIN pasien p ON k.no_rm = p.no_rm WHERE k.status='payment' GROUP BY k.no_rm");
                DataRow row = dataPasien.NewRow();
                row["displayText"] = "Pilih Pasien";
                row["no_rm"] = "";

                dataPasien.Rows.InsertAt(row, 0);
                cbPasien.DataSource = dataPasien;
                cbPasien.DisplayMember = "displayText";
                cbPasien.ValueMember = "no_rm";

                cbPasien.SelectedIndex = 0;
            }
        }

        private void tbDiskon_TextChanged(object sender, EventArgs e) {
            int diskon = tbDiskon.Text == "" ? 0 : int.Parse(Regex.Replace(tbDiskon.Text, @"\D", ""));
            int dasarBayar = subtotalAsli - subsidiBPJS;

            if (diskon > dasarBayar) {
                MessageBox.Show(
                    "Diskon lebih besar dari total bayar!",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                tbDiskon.Text = "0";
                return;
            }

            int totalAkhir = dasarBayar - diskon;
            labelTotalBayar.Text = totalAkhir.ToString("N0");

            if (rbTunai.Checked) {
                int bayar = tbBayar.Text == "" ? 0 : int.Parse(Regex.Replace(tbBayar.Text, @"\D", ""));
                if (bayar < totalAkhir) {
                    tbKembali.Text = bayar == 0 ? "0" : "-" + (totalAkhir - bayar).ToString("N0");
                } else {
                    tbKembali.Text = (bayar - totalAkhir).ToString("N0");
                }
            }
            
            if (string.IsNullOrWhiteSpace(tbDiskon.Text))
                return;

            string angka = tbDiskon.Text.Replace(".", "").Replace(",", "");
            decimal nilai;

            if (decimal.TryParse(angka, out nilai)) {
                tbDiskon.TextChanged -= tbDiskon_TextChanged;
                tbDiskon.Text = nilai.ToString("N0");
                tbDiskon.SelectionStart = tbDiskon.Text.Length;
                tbDiskon.SelectionLength = 0;
                tbDiskon.TextChanged += tbDiskon_TextChanged;
            }
        }

        private void tbDiskon_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }
        }

        private void tbDiskon_Enter(object sender, EventArgs e) {
            BeginInvoke((Action)(() => {
                tbDiskon.SelectionStart = tbDiskon.Text.Length;
                tbDiskon.SelectionLength = 0;
            }));
        }

        private void tbDiskon_Leave(object sender, EventArgs e) {
            if (tbDiskon.Text == "") {
                tbDiskon.Text = "0";
            }
        }

        private void tbBayar_TextChanged(object sender, EventArgs e) {
            if (rbTunai.Checked) {
                int subtotal = int.Parse(Regex.Replace(labelTotalBayar.Text, @"\D", ""));
                int bayar = tbBayar.Text == "" ? 0 : int.Parse(Regex.Replace(tbBayar.Text, @"\D", ""));

                if (bayar < subtotal) {
                    tbKembali.Text = bayar == 0 ? "0" : "-" + (subtotal - bayar).ToString("N0");
                } else {
                    tbKembali.Text = (bayar - subtotal).ToString("N0");
                }
            } else {
                return;
            }

            if (string.IsNullOrWhiteSpace(tbBayar.Text))
                return;

            string angka = tbBayar.Text.Replace(".", "").Replace(",", "");
            decimal nilai;

            if (decimal.TryParse(angka, out nilai)) {
                tbBayar.TextChanged -= tbBayar_TextChanged;

                tbBayar.Text = nilai.ToString("N0");
                tbBayar.SelectionStart = tbBayar.Text.Length;
                tbBayar.SelectionLength = 0;

                tbBayar.TextChanged += tbBayar_TextChanged;
            }
        }

        private void tbBayar_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }
        }

        private void tbBayar_Enter(object sender, EventArgs e) {
            BeginInvoke((Action)(() => {
                tbBayar.SelectionStart = tbBayar.Text.Length;
                tbBayar.SelectionLength = 0;
            }));
        }

        private void tbBayar_Leave(object sender, EventArgs e) {
            if (tbBayar.Text == "") {
                tbBayar.Text = "0";
            }
        }

        private void rbTunai_CheckedChanged(object sender, EventArgs e) {
            if (rbTunai.Checked) {
                tbBayar.ReadOnly = false;
                tbKembali.Visible = true;
                labelBayar.Text = "Bayar (Tunai)";
                labelKembali.Text = "Kembali";
                labelRp1.Text = ":     Rp"; labelRp2.Text = ":     Rp";
                tbBayar.Text = "0";
                tbKembali.Text = "0";

                labelNoReferensi.Visible = false;
                labelRp3.Visible = false;
                tbNoReferensi.Visible = false;
            }
        }

        private void rbTransfer_CheckedChanged(object sender, EventArgs e) {
            if (rbTransfer.Checked) {
                tbKembali.Visible = true;
                labelBayar.Text = "BANK";
                tbBayar.Text = "Blu Digital (BCA)";
                tbBayar.ReadOnly = true;
                labelKembali.Text = "No. Rekening";
                tbKembali.Text = "1199 1199 1199";
                labelRp1.Text = ":"; labelRp2.Text = ":";

                labelNoReferensi.Visible = true;
                labelRp3.Visible = true;
                tbNoReferensi.Visible = true;
                tbNoReferensi.Text = "";
            }
        }

        private void rbBPJS_CheckedChanged(object sender, EventArgs e) {
            if (rbBPJS.Checked) {
                var dataKunjungan = DBHelper.GetData($"SELECT * FROM kunjungan WHERE id_kunjungan='{cbKunjungan.Text}'");
                labelBayar.Text = "NO. BPJS";
                tbBayar.Text = dataKunjungan.Rows.Count > 0 ? dataKunjungan.Rows[0]["no_bpjs"].ToString() : "-";
                tbBayar.ReadOnly = true;
                labelKembali.Text = "";
                tbKembali.Visible = false;
                labelRp1.Text = ":"; labelRp2.Text = "";

                labelNoReferensi.Visible = false;
                labelRp3.Visible = false;
                tbNoReferensi.Visible = false;
            }
        }

        private void btnBatal_Click(object sender, EventArgs e) {
            var dataPasien = DBHelper.GetData($"SELECT k.no_rm, CONCAT(p.nama, ' - ', p.no_rm) AS displayText FROM kunjungan k JOIN pasien p ON k.no_rm = p.no_rm WHERE k.status='payment' GROUP BY k.no_rm");
            DataRow row = dataPasien.NewRow();
            row["displayText"] = "Pilih Pasien";
            row["no_rm"] = "";

            dataPasien.Rows.InsertAt(row, 0);
            cbPasien.DataSource = dataPasien;
            cbPasien.DisplayMember = "displayText";
            cbPasien.ValueMember = "no_rm";

            cbPasien.SelectedIndex = 0;
            tbCari.Text = "No. RM / Nama / ID Kunjungan";
        }

        private void btnCetak_Click(object sender, EventArgs e) {
            MessageBox.Show("Sukses mencetak struk pembayaran!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            var dataPasien = DBHelper.GetData($"SELECT k.no_rm, CONCAT(p.nama, ' - ', p.no_rm) AS displayText FROM kunjungan k JOIN pasien p ON k.no_rm = p.no_rm WHERE k.status='payment' GROUP BY k.no_rm");
            DataRow row = dataPasien.NewRow();
            row["displayText"] = "Pilih Pasien";
            row["no_rm"] = "";

            dataPasien.Rows.InsertAt(row, 0);
            cbPasien.DataSource = dataPasien;
            cbPasien.DisplayMember = "displayText";
            cbPasien.ValueMember = "no_rm";

            cbPasien.SelectedIndex = 0;
            tbCari.Text = "No. RM / Nama / ID Kunjungan";
        }

        private void btnSimpan_Click(object sender, EventArgs e) {
            try {
                if (cbPasien.SelectedIndex <= 0 || cbKunjungan.SelectedIndex <= 0) {
                    MessageBox.Show("Pilih pasien dan kunjungan terlebih dahulu!",
                        "Peringatan",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (rbTunai.Checked) {
                    long totalBayarCek = long.Parse(Regex.Replace(labelTotalBayar.Text, @"\D", ""));
                    long bayarCek = tbBayar.Text == "" ? 0 : long.Parse(Regex.Replace(tbBayar.Text, @"\D", ""));

                    if (totalBayarCek != 0 && bayarCek <= 0) {
                        MessageBox.Show(
                            "Nominal bayar tidak boleh 0!",
                            "Peringatan",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return;
                    }

                    if (bayarCek < totalBayarCek) {
                        MessageBox.Show(
                            "Uang pembayaran masih kurang!",
                            "Peringatan",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return;
                    }
                }

                string idTransaksi = DBHelper.GenerateIdTransaksi();
                Debug.WriteLine(idTransaksi);
                string metodePembayaran = "";

                if (rbTunai.Checked) {
                    metodePembayaran = "Tunai";
                } else if (rbTransfer.Checked) {
                    metodePembayaran = "Transfer";
                } else if (rbBPJS.Checked) {
                    metodePembayaran = "BPJS";
                }

                long subtotal = long.Parse(Regex.Replace(labelSubtotal.Text, @"\D", ""));
                long diskonbpjs = labelBPJS.Text == "(Pasien Umum)" ? 0 : long.Parse(Regex.Replace(labelBPJS.Text, @"\D", ""));
                long diskon = tbDiskon.Text == "" ? 0 : long.Parse(Regex.Replace(tbDiskon.Text, @"\D", ""));
                long totalBayar = long.Parse(Regex.Replace(labelTotalBayar.Text, @"\D", ""));
                long bayar = 0;
                long kembali = 0;
                long noref = 0;

                if (rbTunai.Checked) {
                    bayar = tbBayar.Text == "" ? 0 : long.Parse(Regex.Replace(tbBayar.Text, @"\D", ""));
                    kembali = tbKembali.Text == "" ? 0 : long.Parse(Regex.Replace(tbKembali.Text, @"\D", ""));
                }

                if (tbNoReferensi.Visible == true) {
                    noref = long.Parse(tbNoReferensi.Text == "" ? "0" : tbNoReferensi.Text);
                    if (noref == 0) {
                        MessageBox.Show(
                            "Silahkan isi No. Referensi terlebih dahulu dari Transfer dibawah!",
                            "Peringatan",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return;
                    }
                }

                string query = @"INSERT INTO transaksi (id_transaksi, id_kunjungan, nama_pasien, no_rm, jenis_pasien, subtotal, diskon_bpjs, diskon, total_bayar, metode_pembayaran, bayar, kembali, no_referensi
) VALUES (
    @id_transaksi, @id_kunjungan, @nama_pasien, @no_rm, @jenis_pasien, @subtotal, @diskonbpjs, @diskon, @total_bayar, @metode_pembayaran, @bayar, @kembali, @noref
)";

                MySqlParameter[] param = {
                    new MySqlParameter("@id_transaksi", idTransaksi),
                    new MySqlParameter("@id_kunjungan", cbKunjungan.Text),
                    new MySqlParameter("@nama_pasien", labelNama.Text),
                    new MySqlParameter("@no_rm", labelNoRM.Text),
                    new MySqlParameter("@jenis_pasien", labelJenisBayar.Text),
                    new MySqlParameter("@subtotal", subtotal),
                    new MySqlParameter("@diskonbpjs", diskonbpjs),
                    new MySqlParameter("@diskon", diskon),
                    new MySqlParameter("@total_bayar", totalBayar),
                    new MySqlParameter("@metode_pembayaran", metodePembayaran),
                    new MySqlParameter("@bayar", bayar),
                    new MySqlParameter("@kembali", kembali),
                    new MySqlParameter("@noref", noref)
                };
                DBHelper.Execute(query, param);

                DBHelper.Execute(
                    "UPDATE kunjungan SET status='selesai' WHERE id_kunjungan=@id",
                    new MySqlParameter("@id", cbKunjungan.Text)
                );

                MessageBox.Show(
                    "Transaksi berhasil disimpan!",
                    "Sukses",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                var dataPasien = DBHelper.GetData(
                    @"SELECT k.no_rm, CONCAT(p.nama, ' - ', p.no_rm) AS displayText FROM kunjungan k JOIN pasien p ON k.no_rm = p.no_rm WHERE k.status='payment' GROUP BY k.no_rm"
                );

                DataRow row = dataPasien.NewRow();
                row["displayText"] = "Pilih Pasien";
                row["no_rm"] = "";
                dataPasien.Rows.InsertAt(row, 0);

                cbPasien.DataSource = dataPasien;
                cbPasien.DisplayMember = "displayText";
                cbPasien.ValueMember = "no_rm";
                cbPasien.SelectedIndex = 0;
                tbCari.Text = "No. RM / Nama / ID Kunjungan";
            } catch (Exception ex) {
                MessageBox.Show(
                    "Terjadi kesalahan : " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void tbNoReferensi_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }
        }
    }
}