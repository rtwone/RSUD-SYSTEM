using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace RSUD_SYSTEM {
    public partial class FormTambahEdit : Form {
        private string tabel;
        private string pkValue;
        private string pkColumn;

        private TableLayoutPanel layout = new TableLayoutPanel();
        private Dictionary<string, Control> inputs = new Dictionary<string, Control>();

        public FormTambahEdit(string tabel, string id) {
            this.tabel = tabel;
            this.pkValue = id;

            InitForm();
            Load += Form_Load;
        }

        // ================= UI BASE =================
        void InitForm() {
            this.Text = pkValue == null ? "Tambah Data" : "Edit Data";
            this.Size = new Size(520, 650);
            this.StartPosition = FormStartPosition.CenterScreen;

            layout.Dock = DockStyle.Top;
            layout.AutoSize = true;
            layout.ColumnCount = 2;
            layout.Padding = new Padding(10);
            layout.AutoScroll = true;

            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60));

            this.Controls.Add(layout);

            Button btnSimpan = new Button();
            btnSimpan.Text = "SIMPAN";
            btnSimpan.BackColor = Color.SeaGreen;
            btnSimpan.ForeColor = Color.White;
            btnSimpan.FlatStyle = FlatStyle.Flat;
            btnSimpan.Width = 120;
            btnSimpan.Click += BtnSimpan_Click;

            Button btnBatal = new Button();
            btnBatal.Text = "BATAL";
            btnBatal.BackColor = Color.IndianRed;
            btnBatal.ForeColor = Color.White;
            btnBatal.FlatStyle = FlatStyle.Flat;
            btnBatal.Width = 120;
            btnBatal.Click += (s, e) => this.Close();

            FlowLayoutPanel panelBtn = new FlowLayoutPanel();
            panelBtn.Dock = DockStyle.Bottom;
            panelBtn.Height = 70;
            panelBtn.Padding = new Padding(10);

            panelBtn.Controls.Add(btnSimpan);
            panelBtn.Controls.Add(btnBatal);

            this.Controls.Add(panelBtn);
        }

        // ================= LOAD =================
        private void Form_Load(object sender, EventArgs e) {
            BuildUI();

            if (pkValue != null)
                LoadData();
        }

        // ================= BUILD UI AUTO =================
        void BuildUI() {
            var dt = DBHelper.GetData($"SHOW COLUMNS FROM {tabel}");

            foreach (DataRow row in dt.Rows) {
                string col = row["Field"].ToString();
                string key = row["Key"].ToString();

                Label lbl = new Label();
                lbl.Text = col;
                lbl.AutoSize = true;
                lbl.TextAlign = ContentAlignment.MiddleLeft;
                lbl.Dock = DockStyle.Fill;

                Control input;
                
                string type = row["Type"].ToString().ToLower();

                if (type.Contains("date")) {
                    DateTimePicker dtp = new DateTimePicker();

                    dtp.Format = DateTimePickerFormat.Custom;
                    dtp.CustomFormat = " ";
                    dtp.ShowCheckBox = true;

                    dtp.ValueChanged += (s, e) => {
                        if (dtp.Checked) {
                            dtp.CustomFormat = type == "date"
                                ? "yyyy-MM-dd"
                                : "yyyy-MM-dd HH:mm:ss";
                        } else {
                            dtp.CustomFormat = " ";
                        }
                    };

                    dtp.Dock = DockStyle.Fill;
                    input = dtp;
                } else {
                    TextBox tb = new TextBox();
                    tb.Dock = DockStyle.Fill;
                    input = tb;
                }

                // PRIMARY KEY
                if (key == "PRI") {
                    pkColumn = col;
                    input.Enabled = pkValue == null;
                }

                inputs[col] = input;

                layout.RowCount++;
                layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                layout.Controls.Add(lbl);
                layout.Controls.Add(input);
            }
        }

        // ================= LOAD EDIT DATA =================
        void LoadData() {
            var dt = DBHelper.GetData(
                $"SELECT * FROM {tabel} WHERE {pkColumn}=@id",
                new MySqlParameter("@id", pkValue)
            );

            if (dt.Rows.Count > 0) {
                foreach (var item in inputs) {
                    var val = dt.Rows[0][item.Key];

                    Control ctrl = item.Value;

                    if (ctrl is TextBox) {
                        ((TextBox)ctrl).Text = val == DBNull.Value ? "" : val.ToString();
                    } else if (ctrl is DateTimePicker) {
                        DateTimePicker dtp = (DateTimePicker)ctrl;

                        if (val == DBNull.Value) {
                            dtp.Checked = false;
                            dtp.CustomFormat = " ";
                        } else {
                            dtp.Value = Convert.ToDateTime(val);
                            dtp.Checked = true;

                            string type = dt.Rows[0].Table.Columns[item.Key].DataType.ToString();
                            dtp.CustomFormat = "yyyy-MM-dd HH:mm:ss";
                        }
                    }
                }
            }
        }

        // ================= SIMPAN =================
        private void BtnSimpan_Click(object sender, EventArgs e) {
            if (pkValue == null)
                InsertData();
            else
                UpdateData();

            MessageBox.Show("Berhasil disimpan!");
            this.Close();
        }

        // ================= INSERT =================
        void InsertData() {
            List<string> cols = new List<string>();
            List<string> vals = new List<string>();
            List<MySqlParameter> prms = new List<MySqlParameter>();

            foreach (var i in inputs) {
                cols.Add(i.Key);
                vals.Add("@" + i.Key);

                prms.Add(new MySqlParameter("@" + i.Key, GetValue(i.Value)));
            }

            string query = $"INSERT INTO {tabel} ({string.Join(",", cols)}) VALUES ({string.Join(",", vals)})";

            DBHelper.Execute(query, prms.ToArray());
        }

        // ================= UPDATE =================
        void UpdateData() {
            List<string> set = new List<string>();
            List<MySqlParameter> prms = new List<MySqlParameter>();

            foreach (var i in inputs) {
                if (i.Key == pkColumn) continue;

                set.Add($"{i.Key}=@{i.Key}");
                prms.Add(new MySqlParameter("@" + i.Key, GetValue(i.Value)));
            }

            prms.Add(new MySqlParameter("@pk", pkValue));

            string query = $"UPDATE {tabel} SET {string.Join(",", set)} WHERE {pkColumn}=@pk";

            DBHelper.Execute(query, prms.ToArray());
        }

        // ================= GET VALUE (FIX NULLABLE DATETIME) =================
        object GetValue(Control c) {
            if (c is TextBox)
                return string.IsNullOrWhiteSpace(((TextBox)c).Text) ? DBNull.Value : (object)((TextBox)c).Text;

            if (c is DateTimePicker) {
                DateTimePicker dtp = (DateTimePicker)c;
                return dtp.Checked ? (object)dtp.Value : DBNull.Value;
            }

            return DBNull.Value;
        }
    }
}