using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace RSUD_SYSTEM {
    public partial class menuPendaftaran : Form {
        public menuPendaftaran() {
            InitializeComponent();
        }

        private void menuPendaftaran_Load(object sender, EventArgs e) {
            cbJenisPasien.SelectedIndex = 0;
            cbJenisMasuk.SelectedIndex = 0;
            cbPoliklinik.SelectedIndex = 0;
            cbDokter.SelectedIndex = 0;
            
            textBoxTanggal.Text = func.getTanggal();
            textBoxTanggal.ForeColor = Color.Black;
            textBoxNoHP.Text = "+62 ";
            textBoxNoHP.SelectionStart = textBoxNoHP.Text.Length;
        }

        private void comboBoxJenisPasien_SelectedIndexChanged(object sender, EventArgs e) {
            if (cbJenisPasien.SelectedIndex == 0 || cbJenisPasien.Text == "Umum") {
                textBoxNoBPJS.Enabled = false;
                textBoxNoBPJS.Text = "";
                textBoxNoBPJS.BackColor = Color.Gray;
            } else {
                textBoxNoBPJS.Enabled = true;
                textBoxNoBPJS.BackColor = Color.White;
            }
        }

        private void cbJenisMasuk_SelectedIndexChanged(object sender, EventArgs e) {
            if (cbJenisMasuk.SelectedIndex > 0) {
                if (cbJenisMasuk.Text == "UGD/IGD") {
                    cbDokter.SelectedIndex = 0;
                    cbDokter.Enabled = false;
                    cbPoliklinik.Enabled = true;
                    // cbPoliklinik
                    string queryPoli = "SELECT * FROM poli WHERE id_poli='POL-006'";
                    var dP = DBHelper.GetData(queryPoli);
                    DataRow row = dP.NewRow();
                    row["id_poli"] = "";
                    row["nama_poli"] = "Pilih Poliklinik";
                    dP.Rows.InsertAt(row, 0);
                    cbPoliklinik.DataSource = dP;
                    cbPoliklinik.DisplayMember = "nama_poli";
                    cbPoliklinik.ValueMember = "id_poli";
                    cbPoliklinik.SelectedIndex = 0;
                    cbPoliklinik.BackColor = Color.White;
                } else {
                    cbPoliklinik.Enabled = true;
                    // cbPoliklinik
                    string queryPoli = "SELECT * FROM poli WHERE id_poli!='POL-006'";
                    var dP = DBHelper.GetData(queryPoli);
                    DataRow row = dP.NewRow();
                    row["id_poli"] = "";
                    row["nama_poli"] = "Pilih Poliklinik";
                    dP.Rows.InsertAt(row, 0);
                    cbPoliklinik.DataSource = dP;
                    cbPoliklinik.DisplayMember = "nama_poli";
                    cbPoliklinik.ValueMember = "id_poli";
                    cbPoliklinik.SelectedIndex = 0;
                    cbPoliklinik.BackColor = Color.White;
                }
            } else {
                cbPoliklinik.Enabled = false;
                cbDokter.Enabled = false;
            }
        }

        private void cbPoliklinik_SelectedIndexChanged(object sender, EventArgs e) {
            // Aktifkan dokter Jika memilih salah satu Poli
            if (cbPoliklinik.SelectedIndex > 0) {
                if (cbJenisMasuk.Text == "UGD/IGD") {
                    cbDokter.Enabled = true;
                    cbDokter.BackColor = Color.White;
                    // cbDokter
                    string idPoli = cbPoliklinik.SelectedValue.ToString();
                    if (idPoli != "") {
                        string queryPoli = "SELECT * FROM dokter where id_poli=@idPoli";
                        var dP = DBHelper.GetData(queryPoli, new MySqlParameter("@idPoli", idPoli));
                        DataRow row = dP.NewRow();
                        row["id_dokter"] = 0;
                        row["nama_dokter"] = "Pilih Dokter";
                        dP.Rows.InsertAt(row, 0);
                        cbDokter.DataSource = dP;
                        cbDokter.DisplayMember = "nama_dokter";
                        cbDokter.ValueMember = "id_dokter";
                    }
                } else {
                    cbDokter.Enabled = true;
                    cbDokter.BackColor = Color.White;
                    // cbDokter
                    string idPoli = cbPoliklinik.SelectedValue.ToString();
                    if (idPoli != "") {
                        string queryPoli = "SELECT * FROM dokter where id_poli=@idPoli";
                        var dP = DBHelper.GetData(queryPoli, new MySqlParameter("@idPoli", idPoli));
                        DataRow row = dP.NewRow();
                        row["id_dokter"] = 0;
                        row["nama_dokter"] = "Pilih Dokter";
                        dP.Rows.InsertAt(row, 0);
                        cbDokter.DataSource = dP;
                        cbDokter.DisplayMember = "nama_dokter";
                        cbDokter.ValueMember = "id_dokter";
                    }
                }
            } else {
                cbDokter.SelectedIndex = 0;
                cbDokter.Enabled = false;
            }
        }

        private void butttonReset_Click(object sender, EventArgs e) {
            textBoxNoRM.Text = "";
            textBoxNIK.Text = "";
            textBoxNamaPasien.Text = "";
            rbLakiLaki.Checked = false;
            rbPerempuan.Checked = false;
            textBoxNoHP.Text = "";
            textBoxAlamat.Text = "";
            cbJenisPasien.SelectedIndex = 0;
            cbJenisMasuk.SelectedIndex = 0;
            cbPoliklinik.SelectedIndex = 0;
            cbDokter.SelectedIndex = 0;
            textBoxKeluhan.Text = "";
        }

        private void textBoxNoHP_KeyDown(object sender, KeyEventArgs e) {
            if (textBoxNoHP.SelectionStart <= 4 && e.KeyCode == Keys.Back) {
                e.SuppressKeyPress = true;
            }
        }

        private void textBoxNoHP_TextChanged(object sender, EventArgs e) {
            if (!textBoxNoHP.Text.StartsWith("+62")) {
                textBoxNoHP.Text = "+62 ";
                textBoxNoHP.SelectionStart = textBoxNoHP.Text.Length;
            }
        }


        private void textBoxNoBPJS_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) {
                e.Handled = true;
            }
        }

        private void textBoxNIK_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) {
                e.Handled = true;
            }
        }

        private void textBoxNoHP_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) {
                e.Handled = true;
            }
            if (textBoxNoHP.SelectionStart < 3) {
                textBoxNoHP.SelectionStart = textBoxNoHP.Text.Length;
            }
        }

        bool checkNIK(string nik) {
            return DBHelper.GetData(
                "SELECT nik FROM pasien WHERE nik=@nik LIMIT 1",
                new MySqlParameter("@nik", nik)
            ).Rows.Count > 0;
        }

        private void buttonSimpan_Click(object sender, EventArgs e) {
            if (textBoxNIK.Text == "" || textBoxNamaPasien.Text == "" ||
                (!rbLakiLaki.Checked && !rbPerempuan.Checked) ||
                textBoxNoHP.Text == "" || textBoxAlamat.Text == "" ||
                cbJenisPasien.SelectedIndex == 0 || cbJenisMasuk.SelectedIndex == 0 ||
                textBoxKeluhan.Text == "") {
                MessageBox.Show(
                    "Silakan isi semua Form terlebih dahulu!",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            } else if (cbJenisPasien.Text == "BPJS" && textBoxNoBPJS.Text == "") {
                MessageBox.Show(
                    "Masukkan Nomer BPJS terlebih dahulu!",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            } else if (cbJenisMasuk.Text == "Rawat Jalan" && cbPoliklinik.SelectedIndex == 0) {
                MessageBox.Show(
                    "Silahkan pilih Poliklinik dan Dokter terlebih dahulu!",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            } else if (cbJenisMasuk.Text == "Rawat Jalan" && cbPoliklinik.SelectedIndex != 0 && cbDokter.SelectedIndex == 0) {
                MessageBox.Show(
                    "Silahkan pilih Dokter terlebih dahulu!",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            } else {
                string queryCekRM = $"SELECT no_rm FROM pasien where no_rm='{textBoxNoRM.Text}'";
                var dRM = DBHelper.GetData(queryCekRM);
                if (textBoxNoRM.Text == "" || dRM.Rows.Count > 0) {
                    if (textBoxNoRM.Text == "" && checkNIK(textBoxNIK.Text)) {
                        var dataPasien = DBHelper.GetData($"SELECT no_rm FROM pasien WHERE nik='{textBoxNIK.Text}'");
                        if (dataPasien.Rows.Count > 0) {
                            DialogResult result = MessageBox.Show($"NIK tersebut sudah terdaftar dalam database Rumah Sakit dengan Nomer Rekam Medis: {dataPasien.Rows[0]["no_rm"].ToString()}\nMau Load data Pasien tersebut?",
                                "Konfirmasi",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question
                            );
                            if (result == DialogResult.Yes) {
                                string queryCekR = $"SELECT * FROM pasien where no_rm='{dataPasien.Rows[0]["no_rm"].ToString()}'";
                                var dt = DBHelper.GetData(queryCekR);
                                if (dt.Rows.Count > 0) {
                                    textBoxNoRM.Text = dataPasien.Rows[0]["no_rm"].ToString();
                                    textBoxNIK.Text = dt.Rows[0]["nik"].ToString();
                                    textBoxNamaPasien.Text = dt.Rows[0]["nama"].ToString();
                                    dateTimePickTL.Value = Convert.ToDateTime(dt.Rows[0]["tgl_lahir"]);
                                    string jk = Convert.ToString(dt.Rows[0]["jenis_kelamin"]);
                                    if (jk == "L")
                                        rbLakiLaki.Checked = true;
                                    else
                                        rbPerempuan.Checked = true;
                                    string noHP = dt.Rows[0]["no_hp"].ToString().Substring(2);
                                    textBoxNoHP.Text = "+62 " + noHP;
                                    textBoxAlamat.Text = dt.Rows[0]["alamat"].ToString();
                                    MessageBox.Show(
                                        "Data pasien berhasil dimuat.",
                                        "Informasi",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information
                                    );
                                }
                            }
                        }
                    } else {
                        string no_rm = dRM.Rows.Count > 0 ? dRM.Rows[0]["no_rm"].ToString() : DBHelper.GenerateNoRM();
                        string jenis_kelamin = rbLakiLaki.Checked ? "L" : "P";
                        string id_pasien = DBHelper.GenerateIdPasien();
                        string id_kunjungan = DBHelper.GenerateIdKunjungan();
                        string id_poli = cbPoliklinik.SelectedIndex == 0 ? null : cbPoliklinik.SelectedValue.ToString();
                        string id_dokter = cbDokter.SelectedIndex == 0 ? null : cbDokter.SelectedValue.ToString();
                        string antrean = cbJenisMasuk.Text != "UGD/IGD" ? DBHelper.GenerateAntrian(cbPoliklinik.SelectedValue.ToString(), cbDokter.SelectedValue.ToString()) : null;
                        Debug.WriteLine(antrean);  
                        // input ke Pasien
                        if (dRM.Rows.Count == 0) {
                            string queryInsertToPasien = "INSERT INTO pasien (id, no_rm, nik, nama, tgl_lahir, jenis_kelamin, no_hp, alamat) values " +
                                "(@idPasien, @noRM, @nik, @namaPasien, @tglLahir, @JK, @noHP, @alamat)";
                            DBHelper.Execute(queryInsertToPasien, new MySqlParameter[] {
                            new MySqlParameter("@idPasien", id_pasien),
                            new MySqlParameter("@noRM", no_rm),
                            new MySqlParameter("@nik", textBoxNIK.Text),
                            new MySqlParameter("@namaPasien", textBoxNamaPasien.Text),
                            new MySqlParameter("@tglLahir", dateTimePickTL.Value),
                            new MySqlParameter("@JK", jenis_kelamin),
                            new MySqlParameter("@noHP", "62" + textBoxNoHP.Text.Split(' ')[1]),
                            new MySqlParameter("@alamat", textBoxAlamat.Text)
                        });
                        } else {
                            var dt = DBHelper.GetData($"SELECT * FROM pasien where no_rm='{no_rm}'");
                            id_pasien = dt.Rows[0]["id"].ToString();
                        }

                        int biaya = 0;
                        var dataBiaya = DBHelper.GetData(
                            "SELECT harga FROM poli WHERE id_poli = @id",
                            new MySqlParameter("@id", id_poli)
                        );
                        if (dataBiaya.Rows.Count > 0) {
                            biaya = int.Parse(dataBiaya.Rows[0]["harga"].ToString());
                        } else {
                            biaya = 50000; // biaya igd
                        }

                        // cek apakah pasien masih punya tagihan/payment
                        string queryCekStatus = "SELECT status FROM kunjungan WHERE no_rm=@noRM AND status IN ('menunggu','payment') LIMIT 1";
                        var dataStatus = DBHelper.GetData(queryCekStatus, new MySqlParameter("@noRM", no_rm));

                        if (dataStatus.Rows.Count > 0) {
                            string status = dataStatus.Rows[0]["status"].ToString();
                            if (status == "menunggu") {
                                MessageBox.Show(
                                    "Pasien masih memiliki antrean kunjungan yang aktif!",
                                    "Pendaftaran Ditolak",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning
                                );
                            } else if (status == "payment") {
                                MessageBox.Show(
                                    "Pasien masih memiliki pembayaran yang belum selesai!\n" +
                                    "Silakan selesaikan pembayaran terlebih dahulu.",
                                    "Pendaftaran Ditolak",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning
                                );
                            }
                            return;
                        }

                        // input ke Kunjungan
                        string queryInsertToKunjungan = "INSERT INTO kunjungan (id_kunjungan, id_pasien, no_rm, tanggal, jenis_kunjungan, jenis_pasien, no_bpjs, id_poli, id_dokter, keluhan, tanggal_masuk, tanggal_keluar, antrean, status, biayaLayanan) values " +
                            "(@idKunjungan, @idPasien, @noRM, @tanggal, @jenisMasuk, @jenisPasien, @noBPJS, @idPoli, @dokter, @keluhan, @tanggal_masuk, @tanggal_keluar, @antrean, @status, @biaya)";
                        DBHelper.Execute(queryInsertToKunjungan, new MySqlParameter[] {
                        new MySqlParameter("@idKunjungan", id_kunjungan),
                        new MySqlParameter("@idPasien", id_pasien),
                        new MySqlParameter("@noRM", no_rm),
                        new MySqlParameter("@tanggal", DateTime.Now),
                        new MySqlParameter("@jenisMasuk", cbJenisMasuk.Text),
                        new MySqlParameter("@jenisPasien", cbJenisPasien.Text),
                        new MySqlParameter("@noBPJS", textBoxNoBPJS.Text.Trim()),
                        new MySqlParameter("@idPoli", id_poli),
                        new MySqlParameter("@dokter", id_dokter),
                        new MySqlParameter("@keluhan", textBoxKeluhan.Text),
                        new MySqlParameter("@tanggal_masuk", DateTime.Now),
                        new MySqlParameter("@tanggal_keluar", null),
                        new MySqlParameter("@antrean", antrean),
                        new MySqlParameter("@status", "menunggu"),
                        new MySqlParameter("@biaya", biaya)
                    });

                        textBoxNoRM.Text = "";
                        textBoxNIK.Text = "";
                        textBoxNamaPasien.Text = "";
                        rbLakiLaki.Checked = false;
                        rbPerempuan.Checked = false;
                        textBoxNoHP.Text = "";
                        textBoxAlamat.Text = "";
                        cbJenisPasien.SelectedIndex = 0;
                        cbJenisMasuk.SelectedIndex = 0;
                        cbPoliklinik.SelectedIndex = 0;
                        cbDokter.SelectedIndex = 0;
                        textBoxKeluhan.Text = "";

                        MessageBox.Show(
                            "Data Berhasil di Input!",
                            "Peringatan",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                    }
                } else {
                    MessageBox.Show(
                        "Nomer Rekam Medis tidak ditemukan, kosongkan Text Box jika pasien baru!",
                        "Peringatan",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
        }

        private void cbDokter_SelectedIndexChanged(object sender, EventArgs e) {
            Debug.WriteLine(cbPoliklinik.SelectedIndex == 0 ? null : cbPoliklinik.SelectedValue.ToString());
        }

        private void buttonCariRM_Click(object sender, EventArgs e) {
            string queryCekRM = $"SELECT * FROM pasien where no_rm='{textBoxNoRM.Text}'";
            var dt = DBHelper.GetData(queryCekRM);
            if (dt.Rows.Count > 0) {
                textBoxNIK.Text = dt.Rows[0]["nik"].ToString();
                textBoxNamaPasien.Text = dt.Rows[0]["nama"].ToString();
                dateTimePickTL.Value = Convert.ToDateTime(dt.Rows[0]["tgl_lahir"]);
                string jk = Convert.ToString(dt.Rows[0]["jenis_kelamin"]);
                if (jk == "L")
                    rbLakiLaki.Checked = true;
                else
                    rbPerempuan.Checked = true;
                string noHP = dt.Rows[0]["no_hp"].ToString().Substring(2);
                textBoxNoHP.Text = "+62 " + noHP;
                textBoxAlamat.Text = dt.Rows[0]["alamat"].ToString();
                MessageBox.Show(
                    "Nomer Rekam Medis ditemukan! Data pasien berhasil dimuat.",
                    "Informasi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            } else {
                if (textBoxNoRM.Text == "") {
                    MessageBox.Show(
                        "Isi Nomer Rekam Medis terlebih dahulu, atau kosongkan jika anda pasien baru!",
                        "Peringatan",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                } else {
                    MessageBox.Show(
                        "Nomer Rekam Medis tidak ditemukan, kosongkan Text Box jika pasien baru!",
                        "Peringatan",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
        }
    }
}
