using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
using System.Globalization;
using System.Diagnostics;

namespace RSUD_SYSTEM {
    public static class Session {
        public static int IdUser;
        public static string Email;
        public static string Role;
        public static bool IsLogin = false;
    }
    
    public class Koneksi {
        private static string connStr = "server=localhost;user=root;password=;database=rsud_db;";
        public static MySqlConnection conn = new MySqlConnection(connStr);

        public static void Open() {
            if (conn.State == ConnectionState.Closed) {
                conn.Open();
            }
        }

        public static void Close() {
            if (conn.State == ConnectionState.Open) {
                conn.Close();
            }
        }
    }

    public class DBHelper {
        public static DataTable GetData(string query, params MySqlParameter[] parameters) {
            DataTable dt = new DataTable();

            try {
                Koneksi.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, Koneksi.conn)) {
                    if (parameters != null) {
                        cmd.Parameters.AddRange(parameters);
                    }

                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd)) {
                        da.Fill(dt);
                    }
                }
            } catch (Exception e) {
                throw e;
            } finally {
                Koneksi.Close();
            }

            return dt;
        }

        public static void PrintDataTable(DataTable dt) {
            if (dt.Rows.Count == 0) {
                Debug.WriteLine("Data kosong");
                return;
            }

            int[] colWidths = new int[dt.Columns.Count];

            for (int i = 0; i < dt.Columns.Count; i++) {
                colWidths[i] = dt.Columns[i].ColumnName.Length;

                foreach (DataRow row in dt.Rows) {
                    int len = row[i].ToString().Length;
                    if (len > colWidths[i])
                        colWidths[i] = len;
                }
            }

            Debug.WriteLine("\n");

            string header = "| ";
            for (int i = 0; i < dt.Columns.Count; i++) {
                header += dt.Columns[i].ColumnName.PadRight(colWidths[i]) + " | ";
            }
            Debug.WriteLine(header);

            Debug.WriteLine(new string('-', header.Length));

            foreach (DataRow row in dt.Rows) {
                string line = "| ";
                for (int i = 0; i < dt.Columns.Count; i++) {
                    line += row[i].ToString().PadRight(colWidths[i]) + " | ";
                }
                Debug.WriteLine(line);
            }
        }

        public static int Execute(string query, params MySqlParameter[] parameters) {
            int result = 0;

            try {
                Koneksi.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, Koneksi.conn)) {
                    if (parameters != null && parameters.Length > 0) {
                        cmd.Parameters.AddRange(parameters);
                    }

                    result = cmd.ExecuteNonQuery();
                }
            } catch (MySql.Data.MySqlClient.MySqlException ex) {
                MessageBox.Show(
                    "Message: " + ex.Message + "\n\n" +
                    "Code: " + ex.Number + "\n\n" +
                    "Stack: " + ex.StackTrace
                );
            } finally {
                Koneksi.Close();
            }

            return result;
        }

        public static void RunAndPrintQuery(string query) {
            string q = query.Trim().ToLower();

            if (q.StartsWith("select") || q.StartsWith("desc") || q.StartsWith("show")) {
                DataTable dt = GetData(query);
                PrintDataTable(dt);
            } else {
                int result = Execute(query);
                Debug.WriteLine("\nQuery berhasil, affected rows: " + result);
            }
        }

        public static string GenerateNoRM() {
            string lastRM = "";

            string query = "SELECT no_rm FROM pasien ORDER BY id DESC LIMIT 1";

            MySqlCommand cmd = new MySqlCommand(query, Koneksi.conn);
            Koneksi.Open();

            object result = cmd.ExecuteScalar();

            if (result != null) {
                lastRM = result.ToString();
            }

            Koneksi.Close();

            if (string.IsNullOrEmpty(lastRM)) {
                return "RM-000001";
            }

            // ambil angka dari RM-000001
            int number = int.Parse(lastRM.Substring(3));

            number++;

            return "RM-" + number.ToString("D6");
        }

        public static string GenerateIdPasien() {
            string tahun = DateTime.Now.Year.ToString();
            string lastId = "";

            string query = "SELECT id FROM pasien WHERE id LIKE @tahun ORDER BY id DESC LIMIT 1";

            MySqlCommand cmd = new MySqlCommand(query, Koneksi.conn);
            cmd.Parameters.AddWithValue("@tahun", tahun + "%");

            Koneksi.Open();
            object result = cmd.ExecuteScalar();
            Koneksi.Close();

            if (result == null) {
                return tahun + "000001";
            }

            lastId = result.ToString();

            // ambil angka belakang (setelah tahun)
            int number = int.Parse(lastId.Substring(4));
            number++;

            return tahun + number.ToString("D6");
        }

        public static string GenerateIdKunjungan() {
            string tahun = DateTime.Now.Year.ToString();
            string prefix = "KJ" + tahun;
            string lastId = "";

            string query = "SELECT id_kunjungan FROM kunjungan " +
                           "WHERE id_kunjungan LIKE @prefix " +
                           "ORDER BY id_kunjungan DESC LIMIT 1";

            MySqlCommand cmd = new MySqlCommand(query, Koneksi.conn);
            cmd.Parameters.AddWithValue("@prefix", prefix + "%");

            Koneksi.Open();
            object result = cmd.ExecuteScalar();
            Koneksi.Close();

            if (result == null) {
                return prefix + "000001";
            }

            lastId = result.ToString();

            // ambil angka terakhir (setelah KJ + tahun)
            int number = int.Parse(lastId.Substring(6));
            number++;

            return prefix + number.ToString("D6");
        }

        public static string GenerateAntrian(string idPoli, string idDokter) {
            string prefix = "U";

            // mapping prefix poli
            if (idPoli == "POL-001") prefix = "U";
            else if (idPoli == "POL-002") prefix = "G";
            else if (idPoli == "POL-003") prefix = "A";
            else if (idPoli == "POL-004") prefix = "T";
            else if (idPoli == "POL-005") prefix = "M";

            string query = @"SELECT antrean FROM kunjungan WHERE id_poli=@idPoli AND DATE(tanggal)=@tanggal AND id_dokter=@idDokter ORDER BY antrean DESC LIMIT 1";

            MySqlCommand cmd = new MySqlCommand(query, Koneksi.conn);
            cmd.Parameters.AddWithValue("@idPoli", idPoli);
            cmd.Parameters.AddWithValue("@idDokter", idDokter);
            cmd.Parameters.AddWithValue("@tanggal", DateTime.Now.Date.ToString("yyyy-MM-dd"));

            Koneksi.Open();
            object result = cmd.ExecuteScalar();
            Koneksi.Close();

            int nomor = 1;

            if (result != null) {
                string last = result.ToString(); // contoh: U005

                // ambil angka saja
                string angka = last.Substring(1);

                nomor = int.Parse(angka) + 1;
            }

            return prefix + nomor.ToString("D3");
        }

        public static string GenerateIdTransaksi() {
            string tanggal = DateTime.Now.ToString("yyyyMMdd");
            string prefix = "TRX" + tanggal;
            string query = @"SELECT id_transaksi FROM transaksi WHERE id_transaksi LIKE @prefix ORDER BY id_transaksi DESC LIMIT 1";

            Koneksi.Open();
            MySqlCommand cmd = new MySqlCommand(query, Koneksi.conn);
            cmd.Parameters.AddWithValue("@prefix", prefix + "%");
            object result = cmd.ExecuteScalar();
            Koneksi.Close();

            if (result == null || result == DBNull.Value) {
                return prefix + "001";
            }

            string lastId = result.ToString();
            int number = int.Parse(lastId.Substring(prefix.Length));
            number++;
            return prefix + number.ToString("D3");
        }
    }

    public class func {
        public static string GetUcapan() {
            int jam = DateTime.Now.Hour;

            if (jam >= 5 && jam < 11)
                return "Selamat Pagi";
            else if (jam >= 11 && jam < 15)
                return "Selamat Siang";
            else if (jam >= 15 && jam < 18)
                return "Selamat Sore";
            else
                return "Selamat Malam";
        }

        public static void LoadForm(Form form, Panel panelMain) {
            panelMain.Controls.Clear();

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            panelMain.Controls.Add(form);
            form.Show();
        }

        public static string getTanggal(string format = null) {
            if (format == null) {
                return DateTime.Now.ToString(
                    "dddd, d MMMM yyyy",
                    new CultureInfo("id-ID"));
            } else {
                return DateTime.Now.ToString(
                    format,
                    new CultureInfo("id-ID"));
            }
        }
    }
}