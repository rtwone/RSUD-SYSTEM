using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace RSUD_SYSTEM {
    public partial class menuDataMaster : Form {
        private Timer searchTimer = new Timer();

        public menuDataMaster() {
            InitializeComponent();
        }

        // ================= PRIMARY KEY =================
        string GetPrimaryKey(string tabel) {
            var dt = DBHelper.GetData($"SHOW KEYS FROM {tabel} WHERE Key_name = 'PRIMARY'");
            if (dt.Rows.Count > 0)
                return dt.Rows[0]["Column_name"].ToString();

            return "";
        }

        // ================= LOAD DATA =================
        void LoadData() {
            if (cbFilter.SelectedIndex <= 0) {
                dataGridView1.DataSource = null;
                labelTotalData.Text = "Total Data : 0";
                return;
            }

            string tabel = cbFilter.Text;
            var dt = DBHelper.GetData($"SELECT * FROM {tabel}");

            dataGridView1.DataSource = dt;
            labelTotalData.Text = $"Total Data : {dt.Rows.Count}";

            SetupGrid();
        }

        // ================= GRID SETUP =================
        void SetupGrid() {
            // BASIC
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.GridColor = Color.FromArgb(235, 235, 235);
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9);
            dataGridView1.ColumnHeadersHeight = 40;
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(240, 247, 255);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView1.RowTemplate.Height = 35;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(240, 247, 255);
            dataGridView1.DefaultCellStyle.Padding = new Padding(3);
            dataGridView1.Cursor = Cursors.Hand;
        }

        // ================= FORM LOAD =================
        private void menuDataMaster_Load(object sender, EventArgs e) {
            var dtAllTable = DBHelper.GetData("SHOW TABLES;");

            DataRow row = dtAllTable.NewRow();
            row["Tables_in_rsud_db"] = "-- PILIH TABEL --";
            dtAllTable.Rows.InsertAt(row, 0);

            cbFilter.DataSource = dtAllTable;
            cbFilter.DisplayMember = "Tables_in_rsud_db";
            SetupGrid();
            
            textBoxCari.Text = "Cari...";
            textBoxCari.ForeColor = Color.Gray;
            
            searchTimer.Interval = 400;
            searchTimer.Tick += SearchTimer_Tick;
        }

        // ================= FILTER =================
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e) {
            LoadData();
        }

        // ================= SEARCH TEXTBOX =================
        private void textBoxCari_Enter(object sender, EventArgs e) {
            if (textBoxCari.Text == "Cari...") {
                textBoxCari.Text = "";
                textBoxCari.ForeColor = Color.Black;
            }
        }

        private void textBoxCari_Leave(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(textBoxCari.Text)) {
                textBoxCari.Text = "Cari...";
                textBoxCari.ForeColor = Color.Gray;
                LoadData();
            }
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e) {
            searchTimer.Stop();
            searchTimer.Start();
        }

        // ================= SEARCH PRO ENGINE =================
        private void SearchTimer_Tick(object sender, EventArgs e) {
            searchTimer.Stop();

            if (cbFilter.SelectedIndex <= 0) return;

            string keyword = textBoxCari.Text;

            if (string.IsNullOrWhiteSpace(keyword) || keyword == "Cari...") {
                LoadData();
                return;
            }

            string tabel = cbFilter.Text;
            DataTable dtKolom = DBHelper.GetData($"SHOW COLUMNS FROM {tabel}");
            if (dtKolom.Rows.Count == 0) return;

            List<string> kondisiList = new List<string>();

            foreach (DataRow row in dtKolom.Rows) {
                string kolom = row["Field"].ToString();
                kondisiList.Add($"{kolom} LIKE @key");
            }

            string kondisi = string.Join(" OR ", kondisiList);
            string query = $"SELECT * FROM {tabel} WHERE {kondisi}";
            var dt = DBHelper.GetData(query,
                new MySqlParameter("@key", "%" + keyword + "%"));

            dataGridView1.DataSource = dt;
            labelTotalData.Text = $"Total Data : {dt.Rows.Count}";
        }

        // ================= DELETE =================
        private void buttonHapus_Click(object sender, EventArgs e) {
            if (cbFilter.SelectedIndex <= 0) return;
            if (dataGridView1.SelectedRows.Count == 0) return;

            string tabel = cbFilter.Text;
            string pk = GetPrimaryKey(tabel);

            if (string.IsNullOrEmpty(pk)) return;

            var row = dataGridView1.SelectedRows[0];
            string value = row.Cells[pk].Value.ToString();

            try {
                // ================= CEK FOREIGN KEY =================
                string queryFK = $@"
SELECT 
    TABLE_NAME,
    COLUMN_NAME
FROM information_schema.KEY_COLUMN_USAGE
WHERE 
    REFERENCED_TABLE_SCHEMA = DATABASE()
    AND REFERENCED_TABLE_NAME = '{tabel}'
    AND REFERENCED_COLUMN_NAME = '{pk}'";

                DataTable dtFK = DBHelper.GetData(queryFK);

                // ADA RELASI
                if (dtFK.Rows.Count > 0) {

                    List<string> daftarTabel = new List<string>();

                    foreach (DataRow fk in dtFK.Rows) {
                        string childTable = fk["TABLE_NAME"].ToString();

                        if (!daftarTabel.Contains(childTable)) {
                            daftarTabel.Add(childTable);
                        }
                    }

                    string tabelRelasi = string.Join(", ", daftarTabel);

                    string pesan = "Data ini memiliki relasi dengan tabel:\n" +
                        tabelRelasi +
                        "\n\nJika dihapus, semua data yang berhubungan juga akan ikut terhapus.\n\n" +
                        "Lanjutkan?";

                    DialogResult konfirmasi = MessageBox.Show(
                        pesan,
                        "Peringatan Foreign Key",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (konfirmasi == DialogResult.No)
                        return;

                    // ================= HAPUS RELASI =================
                    foreach (DataRow fk in dtFK.Rows) {

                        string childTable = fk["TABLE_NAME"].ToString();
                        string childColumn = fk["COLUMN_NAME"].ToString();

                        DBHelper.Execute(
                            $"DELETE FROM {childTable} WHERE {childColumn}=@id",
                            new MySqlParameter("@id", value)
                        );
                    }
                } else {

                    DialogResult res = MessageBox.Show(
                        "Yakin hapus data ini?",
                        "Konfirmasi",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (res == DialogResult.No)
                        return;
                }

                // ================= HAPUS DATA UTAMA =================
                DBHelper.Execute(
                    $"DELETE FROM {tabel} WHERE {pk}=@id",
                    new MySqlParameter("@id", value)
                );

                MessageBox.Show(
                    "Data berhasil dihapus!",
                    "Sukses",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LoadData();
            } catch (Exception ex) {
                MessageBox.Show(
                    "Gagal menghapus data : " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ================= TAMBAH =================
        private void buttonTambah_Click(object sender, EventArgs e) {
            if (cbFilter.SelectedIndex <= 0) return;
            string tabel = cbFilter.Text;
            FormTambahEdit frm = new FormTambahEdit(tabel, null);
            frm.ShowDialog();
            LoadData();
        }

        // ================= EDIT =================
        private void buttonEdit_Click(object sender, EventArgs e) {
            if (cbFilter.SelectedIndex <= 0) return;
            if (dataGridView1.SelectedRows.Count == 0) return;

            string tabel = cbFilter.Text;
            string pk = GetPrimaryKey(tabel);

            if (string.IsNullOrEmpty(pk)) return;

            var row = dataGridView1.SelectedRows[0];
            string value = row.Cells[pk].Value.ToString();

            FormTambahEdit frm = new FormTambahEdit(tabel, value);
            frm.ShowDialog();

            LoadData();
        }
    }
}