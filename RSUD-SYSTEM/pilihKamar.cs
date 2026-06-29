using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace RSUD_SYSTEM {
    public partial class pilihKamar : Form {
        DataTable dataFromDiagnosa;
        string kasurDiPilih = null;
        public pilihKamar(DataTable data) {
            InitializeComponent();
            dataFromDiagnosa = data;
        }

        private void pilihKamar_Load(object sender, EventArgs e) {
            this.ClientSize = new Size(panel1.Width, panel1.Height);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            load();
        }

        void load() {
            label2.Text = dataFromDiagnosa.Rows[0]["no_rm"].ToString();
            var queryKamarAndJenis = "SELECT id_kamar, CONCAT(nama_kamar, ' - ', tipe_kamar) as displayText FROM kamar";
            var dataKamar = DBHelper.GetData(queryKamarAndJenis);
            cbKamar.DataSource = dataKamar;
            cbKamar.DisplayMember = "displayText";
            cbKamar.ValueMember = "id_kamar";

            var queryKasurReguler = $"SELECT * FROM bed where id_kamar='{cbKamar.SelectedValue.ToString()}'";
            var dataKasur = DBHelper.GetData(queryKasurReguler);
            if (dataKasur.Rows.Count > 0) {
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
            kasurDiPilih = null;
            kamar1.Enabled = true; kamar1.Text = "";
            kamar2.Enabled = true; kamar2.Text = "";
            kamar3.Enabled = true; kamar3.Text = "";
            kamar4.Enabled = true; kamar4.Text = "";
            kamar5.Enabled = true; kamar5.Text = "";
            kamar6.Enabled = true; kamar6.Text = "";
            kamar7.Enabled = true; kamar7.Text = "";
            kamar8.Enabled = true; kamar8.Text = "";
            kamar9.Enabled = true; kamar9.Text = "";
            kamar10.Enabled = true; kamar10.Text = "";
            kamar11.Enabled = true; kamar11.Text = "";
            kamar12.Enabled = true; kamar12.Text = "";
            kamar13.Enabled = true; kamar13.Text = "";
            kamar14.Enabled = true; kamar14.Text = "";
            kamar15.Enabled = true; kamar15.Text = "";
        }

        private void cbKamar_SelectedIndexChanged(object sender, EventArgs e) {
            reset();
            resetWarnaKamar();
        }

        void resetWarnaKamar() {
            if (cbKamar.Text.EndsWith("Reguler")) {
                var queryKasurReguler = $"SELECT * FROM bed where id_kamar='{cbKamar.SelectedValue.ToString()}'";
                var dataKasur = DBHelper.GetData(queryKasurReguler);
                if (dataKasur.Rows.Count > 0) {
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
                var queryKasurVIP = $"SELECT * FROM bed where id_kamar='{cbKamar.SelectedValue.ToString()}'";
                var dataKasur = DBHelper.GetData(queryKasurVIP);
                if (dataKasur.Rows.Count > 0) {
                    kamar1.Text = dataKasur.Rows[0]["id_bed"].ToString(); kamar1.BackColor = dataKasur.Rows[0]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                    kamar2.Text = dataKasur.Rows[1]["id_bed"].ToString(); kamar2.BackColor = dataKasur.Rows[1]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                    kamar3.Text = dataKasur.Rows[2]["id_bed"].ToString(); kamar3.BackColor = dataKasur.Rows[2]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                    kamar4.Text = dataKasur.Rows[3]["id_bed"].ToString(); kamar4.BackColor = dataKasur.Rows[3]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                    kamar5.Text = dataKasur.Rows[4]["id_bed"].ToString(); kamar5.BackColor = dataKasur.Rows[4]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                    kamar1.Text = dataKasur.Rows[0]["id_bed"].ToString(); kamar1.BackColor = dataKasur.Rows[0]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                    kamar2.Text = dataKasur.Rows[1]["id_bed"].ToString(); kamar2.BackColor = dataKasur.Rows[1]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                    kamar3.Text = dataKasur.Rows[2]["id_bed"].ToString(); kamar3.BackColor = dataKasur.Rows[2]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                    kamar4.Text = dataKasur.Rows[3]["id_bed"].ToString(); kamar4.BackColor = dataKasur.Rows[3]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                    kamar5.Text = dataKasur.Rows[4]["id_bed"].ToString(); kamar5.BackColor = dataKasur.Rows[4]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                    kamar6.Enabled = false; kamar6.Text = ""; kamar6.BackColor = Color.Gray;
                    kamar7.Enabled = false; kamar7.Text = ""; kamar7.BackColor = Color.Gray;
                    kamar8.Enabled = false; kamar8.Text = ""; kamar8.BackColor = Color.Gray;
                    kamar9.Enabled = false; kamar9.Text = ""; kamar9.BackColor = Color.Gray;
                    kamar10.Enabled = false; kamar10.Text = ""; kamar10.BackColor = Color.Gray;
                    kamar11.Enabled = false; kamar11.Text = ""; kamar11.BackColor = Color.Gray;
                    kamar12.Enabled = false; kamar12.Text = ""; kamar12.BackColor = Color.Gray;
                    kamar13.Enabled = false; kamar13.Text = ""; kamar13.BackColor = Color.Gray;
                    kamar14.Enabled = false; kamar14.Text = ""; kamar14.BackColor = Color.Gray;
                    kamar15.Enabled = false; kamar15.Text = ""; kamar15.BackColor = Color.Gray;
                }
            } else if (cbKamar.Text.EndsWith("VVIP")) {
                var queryKasurVVIP = $"SELECT * FROM bed where id_kamar='{cbKamar.SelectedValue.ToString()}'";
                var dataKasur = DBHelper.GetData(queryKasurVVIP);
                if (dataKasur.Rows.Count > 0) {
                    kamar1.Text = dataKasur.Rows[0]["id_bed"].ToString(); kamar1.BackColor = dataKasur.Rows[0]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                    kamar2.Text = dataKasur.Rows[1]["id_bed"].ToString(); kamar2.BackColor = dataKasur.Rows[1]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                    kamar3.Text = dataKasur.Rows[2]["id_bed"].ToString(); kamar3.BackColor = dataKasur.Rows[2]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                    kamar4.Text = dataKasur.Rows[3]["id_bed"].ToString(); kamar4.BackColor = dataKasur.Rows[3]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                    kamar5.Text = dataKasur.Rows[4]["id_bed"].ToString(); kamar5.BackColor = dataKasur.Rows[4]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                    kamar1.Text = dataKasur.Rows[0]["id_bed"].ToString(); kamar1.BackColor = dataKasur.Rows[0]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                    kamar2.Text = dataKasur.Rows[1]["id_bed"].ToString(); kamar2.BackColor = dataKasur.Rows[1]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                    kamar3.Text = dataKasur.Rows[2]["id_bed"].ToString(); kamar3.BackColor = dataKasur.Rows[2]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                    kamar4.Text = dataKasur.Rows[3]["id_bed"].ToString(); kamar4.BackColor = dataKasur.Rows[3]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                    kamar5.Text = dataKasur.Rows[4]["id_bed"].ToString(); kamar5.BackColor = dataKasur.Rows[4]["status"].ToString() == "Terisi" ? Color.Green : Color.Gray;
                    kamar6.Enabled = false; kamar6.Text = ""; kamar6.BackColor = Color.Gray;
                    kamar7.Enabled = false; kamar7.Text = ""; kamar7.BackColor = Color.Gray;
                    kamar8.Enabled = false; kamar8.Text = ""; kamar8.BackColor = Color.Gray;
                    kamar9.Enabled = false; kamar9.Text = ""; kamar9.BackColor = Color.Gray;
                    kamar10.Enabled = false; kamar10.Text = ""; kamar10.BackColor = Color.Gray;
                    kamar11.Enabled = false; kamar11.Text = ""; kamar11.BackColor = Color.Gray;
                    kamar12.Enabled = false; kamar12.Text = ""; kamar12.BackColor = Color.Gray;
                    kamar13.Enabled = false; kamar13.Text = ""; kamar13.BackColor = Color.Gray;
                    kamar14.Enabled = false; kamar14.Text = ""; kamar14.BackColor = Color.Gray;
                    kamar15.Enabled = false; kamar15.Text = ""; kamar15.BackColor = Color.Gray;
                }
            }
        }
        bool checkKamar(Button kamar) {
            bool status = false;
            if (kamar.BackColor == Color.Green) {
                status = true;
                MessageBox.Show("Kamar tersebut sudah terisi!");
            }
            return status;
        }
        
        private void kamar1_Click(object sender, EventArgs e) {
            if (checkKamar(kamar1)) return;
            resetWarnaKamar();
            kamar1.BackColor = Color.DodgerBlue;
            kasurDiPilih = kamar1.Text;
        } 

        private void kamar2_Click(object sender, EventArgs e) {
            if (checkKamar(kamar2)) return;
            resetWarnaKamar();
            kamar2.BackColor = Color.DodgerBlue;
            kasurDiPilih = kamar2.Text;
        } 

        private void kamar3_Click(object sender, EventArgs e) {
            if (checkKamar(kamar3)) return;
            resetWarnaKamar();
            kamar3.BackColor = Color.DodgerBlue;
            kasurDiPilih = kamar3.Text;
        } 

        private void kamar4_Click(object sender, EventArgs e) {
            if (checkKamar(kamar4)) return;
            resetWarnaKamar();
            kamar4.BackColor = Color.DodgerBlue;
            kasurDiPilih = kamar4.Text;
        } 

        private void kamar5_Click(object sender, EventArgs e) {
            if (checkKamar(kamar5)) return;
            resetWarnaKamar();
            kamar5.BackColor = Color.DodgerBlue;
            kasurDiPilih = kamar5.Text;
        } 

        private void kamar6_Click(object sender, EventArgs e) {
            if (checkKamar(kamar6)) return;
            resetWarnaKamar();
            kamar6.BackColor = Color.DodgerBlue;
            kasurDiPilih = kamar6.Text;
        } 

        private void kamar7_Click(object sender, EventArgs e) {
            if (checkKamar(kamar7)) return;
            resetWarnaKamar();
            kamar7.BackColor = Color.DodgerBlue;
            kasurDiPilih = kamar7.Text;
        } 

        private void kamar8_Click(object sender, EventArgs e) {
            if (checkKamar(kamar8)) return;
            resetWarnaKamar();
            kamar8.BackColor = Color.DodgerBlue;
            kasurDiPilih = kamar8.Text;
        } 

        private void kamar9_Click(object sender, EventArgs e) {
            if (checkKamar(kamar9)) return;
            resetWarnaKamar();
            kamar9.BackColor = Color.DodgerBlue;
            kasurDiPilih = kamar9.Text;
        }

        private void kamar10_Click(object sender, EventArgs e) {
            if (checkKamar(kamar10)) return;
            resetWarnaKamar();
            kamar10.BackColor = Color.DodgerBlue;
            kasurDiPilih = kamar10.Text;
        } 

        private void kamar11_Click(object sender, EventArgs e) {
            if (checkKamar(kamar11)) return;
            resetWarnaKamar();
            kamar11.BackColor = Color.DodgerBlue;
            kasurDiPilih = kamar11.Text;
        } 

        private void kamar12_Click(object sender, EventArgs e) {
            if (checkKamar(kamar12)) return;
            resetWarnaKamar();
            kamar12.BackColor = Color.DodgerBlue;
            kasurDiPilih = kamar12.Text;
        } 

        private void kamar13_Click(object sender, EventArgs e) {
            if (checkKamar(kamar13)) return;
            resetWarnaKamar();
            kamar13.BackColor = Color.DodgerBlue;
            kasurDiPilih = kamar13.Text;
        }

        private void kamar14_Click(object sender, EventArgs e) {
            if (checkKamar(kamar14)) return;
            resetWarnaKamar();
            kamar14.BackColor = Color.DodgerBlue;
            kasurDiPilih = kamar14.Text;
        }

        private void kamar15_Click(object sender, EventArgs e) {
            if (checkKamar(kamar15)) return;
            resetWarnaKamar();
            kamar15.BackColor = Color.DodgerBlue;
            kasurDiPilih = kamar15.Text;
        }
        

        private void buttonSimpan_Click(object sender, EventArgs e) {
            if (kasurDiPilih != null) {
                DataKamar.Kamar = cbKamar.Text;
                DataKamar.KodeKamar = cbKamar.SelectedValue.ToString();
                DataKamar.Bed = kasurDiPilih;

                this.DialogResult = DialogResult.OK;
                this.Close();
            } else {
                MessageBox.Show("Silahkan pilih Kamar dan Kasur terlebih dahulu!");
            }
        }
    }
    public static class DataKamar {
        public static string Kamar;
        public static string KodeKamar;
        public static string Bed;
    }
}
