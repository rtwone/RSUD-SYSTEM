using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace RSUD_SYSTEM {
    public partial class menuRekamMedis : Form {
        public menuRekamMedis() {
            InitializeComponent();
        }

        private void tbCari_Enter(object sender, EventArgs e) {
            if (tbCari.Text == "Ketik No RM atau Nama Pasien") {
                tbCari.Text = "";
                tbCari.ForeColor = Color.Black;
            }
        }

        private void tbCari_Leave(object sender, EventArgs e) {
            if (tbCari.Text == "") {
                tbCari.Text = "Ketik No RM atau Nama Pasien";
                tbCari.ForeColor = Color.Gray;
            }
        }

        private void menuRekamMedis_Load(object sender, EventArgs e) {
            LoadForm();
        }

        void LoadData() {
            btnEdit.Enabled = false;
            btnReset.Enabled = false;
            btnSimpan.Enabled = false;
            
            tbNama.Enabled = false;
            dtTL.Enabled = false;
            cbJK.Enabled = false;
            tbNIK.Enabled = false;
            tbAlamat.Enabled = false;
            tbNoHP.Enabled = false;
            
            tbTanggalKunjungan.Text = "";
            tbPoliUnit.Text = "";
            tbDokter.Text = "";
            tbKeluhan.Text = "";
            tbBPJS.Text = "";
            tbRanapMasuk.Text = "";
            tbRanapKeluar.Text = "";
            tbKamar.Text = "";
            tbDibuatTanggal.Text = "";

            tbNoRM.Text = "";
            tbNama.Text = "";
            tbNIK.Text = "";
            tbAlamat.Text = "";
            tbNoHP.Text = "";
            
            cbDiagnosa.DataSource = null;
            cbDiagnosa.Items.Clear();
            cbDiagnosa.Text = "";

            cbTindakan.DataSource = null;
            cbTindakan.Items.Clear();
            cbTindakan.Text = "";

            cbObat.DataSource = null;
            cbObat.Items.Clear();
            cbObat.Text = "";
            
            labelIsiPasien.Text = "-\n-";
            dgvKunjungan.Rows.Clear();
            cbPasien.SelectedIndex = 0;
        }
        
        void LoadForm() {
            var dataPasien = DBHelper.GetData(@"SELECT id, CONCAT(nama, ' - ', no_rm) AS displayNama FROM pasien");
            
            DataRow row = dataPasien.NewRow();
            row["id"] = 0;
            row["displayNama"] = "-- Pilih Pasien --";
            dataPasien.Rows.InsertAt(row, 0);
            cbPasien.DataSource = dataPasien;
            cbPasien.DisplayMember = "displayNama";
            cbPasien.ValueMember = "id";

            cbPasien.SelectedIndex = 0;
            LoadData();
            dgvKunjungan.Visible = false;
        }

        private void btnEdit_Click(object sender, EventArgs e) {
            btnReset.Enabled = true;
            btnSimpan.Enabled = true;

            tbNama.Enabled = true;
            dtTL.Enabled = true;
            cbJK.Enabled = true;
            tbNIK.Enabled = true;
            tbAlamat.Enabled = true;
            tbNoHP.Enabled = true;
        }

        private void cbPasien_SelectedIndexChanged(object sender, EventArgs e) {
            if (cbPasien.SelectedIndex <= 0) {
                LoadData();
                return;
            }

            tbNama.Enabled = false;
            dtTL.Enabled = false;
            cbJK.Enabled = false;
            tbNIK.Enabled = false;
            tbAlamat.Enabled = false;
            tbNoHP.Enabled = false;

            btnReset.Enabled = false;
            btnSimpan.Enabled = false;

            tbTanggalKunjungan.Text = "";
            tbPoliUnit.Text = "";
            tbDokter.Text = "";
            tbKeluhan.Text = "";
            tbBPJS.Text = "";
            tbRanapMasuk.Text = "";
            tbRanapKeluar.Text = "";
            tbKamar.Text = "";
            tbDibuatTanggal.Text = "";

            cbDiagnosa.DataSource = null;
            cbTindakan.DataSource = null;
            cbObat.DataSource = null;

            var dataPasien = DBHelper.GetData($"SELECT * FROM pasien WHERE id='{cbPasien.SelectedValue}'").Rows;

            if (dataPasien.Count > 0) {
                btnEdit.Enabled = true;

                labelIsiPasien.Text = dataPasien[0]["no_rm"].ToString() + "\n" + dataPasien[0]["nama"].ToString();
                tbNoRM.Text = dataPasien[0]["no_rm"].ToString();
                tbNama.Text = dataPasien[0]["nama"].ToString();
                dtTL.Value = Convert.ToDateTime(dataPasien[0]["tgl_lahir"]);
                cbJK.SelectedIndex = dataPasien[0]["jenis_kelamin"].ToString() == "L" ? 0 : 1;
                tbNIK.Text = dataPasien[0]["nik"].ToString();
                tbAlamat.Text = dataPasien[0]["alamat"].ToString();
                tbNoHP.Text = dataPasien[0]["no_hp"].ToString();
                loadDGVKunjungan(dataPasien[0]["no_rm"].ToString()
                );
            }
        }

        private void tbCari_TextChanged(object sender, EventArgs e) {
            string keyword = tbCari.Text;

            if (keyword == "Ketik No RM atau Nama Pasien")
                keyword = "";

            string query = @"SELECT id, CONCAT(nama, ' - ', no_rm) AS displayNama FROM pasien WHERE no_rm LIKE @key OR nama LIKE @key";

            var dt = DBHelper.GetData(
                query,
                new MySqlParameter("@key", "%" + keyword + "%")
            );
            
            DataRow row = dt.NewRow();
            row["id"] = 0;
            row["displayNama"] = "-- Pilih Pasien --";

            dt.Rows.InsertAt(row, 0);

            cbPasien.DataSource = dt;
            cbPasien.DisplayMember = "displayNama";
            cbPasien.ValueMember = "id";

            cbPasien.SelectedIndex = 0;
        }

        private void btnReset_Click(object sender, EventArgs e) {
            var dataPasien = DBHelper.GetData($"SELECT * FROM pasien WHERE id='{cbPasien.SelectedValue}'").Rows;
            if (dataPasien.Count > 0) {
                btnEdit.Enabled = true;
                btnSimpan.Enabled = true;
                labelIsiPasien.Text = dataPasien[0]["no_rm"].ToString() + "\n" + dataPasien[0]["nama"].ToString();
                tbNoRM.Text = dataPasien[0]["no_rm"].ToString();
                tbNama.Text = dataPasien[0]["nama"].ToString();
                dtTL.Value = Convert.ToDateTime(dataPasien[0]["tgl_lahir"]);
                cbJK.SelectedIndex = dataPasien[0]["jenis_kelamin"].ToString() == "L" ? 0 : 1;

                tbNIK.Text = dataPasien[0]["nik"].ToString();
                tbAlamat.Text = dataPasien[0]["alamat"].ToString();
                tbNoHP.Text = dataPasien[0]["no_hp"].ToString();
            }

            tbNama.Enabled = false;
            dtTL.Enabled = false;
            cbJK.Enabled = false;
            tbNIK.Enabled = false;
            tbAlamat.Enabled = false;
            tbNoHP.Enabled = false;

            btnReset.Enabled = false;
            btnSimpan.Enabled = false;
        }

        void loadDGVKunjungan(string no_rm) {
            dgvKunjungan.Visible = true;
            dgvKunjungan.Columns.Clear();

            dgvKunjungan.Columns.Add("no", "No");
            dgvKunjungan.Columns.Add("id_kunjungan", "ID Kunjungan");
            dgvKunjungan.Columns.Add("tanggal", "Tanggal Kunjungan");
            dgvKunjungan.Columns.Add("poli", "Poli / Unit");
            dgvKunjungan.Columns.Add("status", "Status");
            
            DataGridViewButtonColumn btnAksi = new DataGridViewButtonColumn();

            btnAksi.Name = "aksi";
            btnAksi.HeaderText = "Aksi";
            btnAksi.Text = "Lihat";
            btnAksi.UseColumnTextForButtonValue = true;
            btnAksi.FlatStyle = FlatStyle.Flat;

            dgvKunjungan.Columns.Add(btnAksi);
            dgvKunjungan.AutoGenerateColumns = false;
            dgvKunjungan.AllowUserToAddRows = false;
            dgvKunjungan.AllowUserToDeleteRows = false;
            dgvKunjungan.AllowUserToResizeColumns = false;
            dgvKunjungan.AllowUserToResizeRows = false;

            dgvKunjungan.ReadOnly = true;
            dgvKunjungan.MultiSelect = false;
            dgvKunjungan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKunjungan.RowHeadersVisible = false;

            dgvKunjungan.BorderStyle = BorderStyle.None;
            dgvKunjungan.BackgroundColor = Color.White;
            dgvKunjungan.EnableHeadersVisualStyles = false;
            dgvKunjungan.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvKunjungan.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dgvKunjungan.GridColor = Color.FromArgb(235, 235, 235);
            dgvKunjungan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKunjungan.RowTemplate.Height = 36;

            dgvKunjungan.ColumnHeadersHeight = 42;
            dgvKunjungan.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvKunjungan.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvKunjungan.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9);
            dgvKunjungan.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvKunjungan.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.White;
            dgvKunjungan.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;

            dgvKunjungan.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgvKunjungan.DefaultCellStyle.ForeColor = Color.Black;
            dgvKunjungan.DefaultCellStyle.BackColor = Color.White;
            dgvKunjungan.DefaultCellStyle.SelectionBackColor = Color.FromArgb(240, 247, 255);
            dgvKunjungan.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvKunjungan.DefaultCellStyle.Padding = new Padding(3);
            dgvKunjungan.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            
            dgvKunjungan.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgvKunjungan.Columns["no"].FillWeight = 6;
            dgvKunjungan.Columns["id_kunjungan"].FillWeight = 22;
            dgvKunjungan.Columns["tanggal"].FillWeight = 28;
            dgvKunjungan.Columns["poli"].FillWeight = 25;
            dgvKunjungan.Columns["status"].FillWeight = 15;
            dgvKunjungan.Columns["aksi"].FillWeight = 12;

            dgvKunjungan.Columns["no"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvKunjungan.Columns["id_kunjungan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvKunjungan.Columns["tanggal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvKunjungan.Columns["poli"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvKunjungan.Columns["status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvKunjungan.Columns["aksi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridViewButtonColumn btn = (DataGridViewButtonColumn)dgvKunjungan.Columns["aksi"];
            btn.FlatStyle = FlatStyle.Flat;

            var dtKunjungan = DBHelper.GetData($@"
    SELECT 
        id_kunjungan,
        tanggal,
        id_poli,
        status
    FROM kunjungan
    WHERE no_rm = '{no_rm}'
    ORDER BY tanggal DESC");

            dgvKunjungan.Rows.Clear();

            int no = 1;

            foreach (DataRow row in dtKunjungan.Rows) {
                string idKunjungan = row["id_kunjungan"].ToString();
                string tanggal = Convert.ToDateTime(row["tanggal"]) .ToString("dd MMM yyyy - HH:mm");
                var dataPoli = DBHelper.GetData($@"
        SELECT nama_poli
        FROM poli
        WHERE id_poli='{row["id_poli"]}'");

                string poliunit;

                if (dataPoli.Rows.Count > 0) {
                    poliunit = dataPoli.Rows[0]["nama_poli"].ToString();
                } else {
                    poliunit = "UGD / IGD";
                }

                string status = row["status"].ToString();

                int rowIndex = dgvKunjungan.Rows.Add(
                    no++,
                    idKunjungan,
                    tanggal,
                    poliunit,
                    status,
                    "Lihat"
                );

                dgvKunjungan.Rows[rowIndex].Tag =
                    idKunjungan;
            }
        }

        private void dgvKunjungan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            if (dgvKunjungan.Columns[e.ColumnIndex].Name == "status") {
                string val = e.Value?.ToString();
                if (val == "selesai") {
                    e.CellStyle.BackColor = Color.LightGreen;
                } else if (val == "menunggu" || val == "payment" || val == "menginap") {
                    e.CellStyle.BackColor = Color.Khaki;
                }
            }
        }

        private void dgvKunjungan_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex < 0) return;
            
            if (dgvKunjungan.Columns[e.ColumnIndex].Name == "aksi") {
                string aksi = dgvKunjungan.Rows[e.RowIndex].Cells["aksi"].Value.ToString();
                string idKunjungan = dgvKunjungan.Rows[e.RowIndex].Tag.ToString();
                if (aksi == "Lihat") {
                    FormPopupDetailKunjungan frm = new FormPopupDetailKunjungan(idKunjungan);
                    frm.ShowDialog(this);
                }
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e) {
            DBHelper.Execute("UPDATE pasien SET nama=@nama, tgl_lahir=@tgl, jenis_kelamin=@jk, nik=@nik, alamat=@alamat, no_hp=@no WHERE id=@id",
                new MySqlParameter("@id", cbPasien.SelectedValue),
                new MySqlParameter("@nama", tbNama.Text),
                new MySqlParameter("@tgl", Convert.ToDateTime(dtTL.Value)),
                new MySqlParameter("@jk", cbJK.SelectedIndex == 0 ? "L" : "P"),
                new MySqlParameter("@nik", tbNIK.Text),
                new MySqlParameter("@alamat", tbAlamat.Text),
                new MySqlParameter("@no", tbNoHP.Text)
            );
            MessageBox.Show("Sukses mengubah Data Pasien!");
            tbNama.Enabled = false;
            dtTL.Enabled = false;
            cbJK.Enabled = false;
            tbNIK.Enabled = false;
            tbAlamat.Enabled = false;
            tbNoHP.Enabled = false;

            btnReset.Enabled = false;
            btnSimpan.Enabled = false;
            LoadForm();
        }
    }
}
