using System;
using System.Drawing;
using System.Windows.Forms;

namespace RSUD_SYSTEM {
    public partial class menuUtama : Form {
        public menuUtama() {
            InitializeComponent();
        }

        void ResetMenu() {
            buttonDashboard.BackColor = Color.Transparent;
            buttonDataMaster.BackColor = Color.Transparent;
            buttonPendaftaran.BackColor = Color.Transparent;
            buttonDiagnosa.BackColor = Color.Transparent;
            buttonRekamMedis.BackColor = Color.Transparent;
            buttonRanap.BackColor = Color.Transparent;
            buttonPembayaran.BackColor = Color.Transparent;
            buttonLaporan.BackColor = Color.Transparent;
        }

        private void menuUtama_Load(object sender, EventArgs e) {
            labelUcapan.Text = func.GetUcapan();
            labelUsername.Text = Session.Role;
            ResetMenu();
            buttonDashboard.BackColor = Color.Teal;
            func.LoadForm(new menuDashboard(), panelFill);
        }

        private void buttonKeluar_Click(object sender, EventArgs e) {
            Session.IdUser = 0;
            Session.Email = null;
            Session.Role = null;
            Session.IsLogin = false;

            menuLogin form = new menuLogin();
            form.Show();
            this.Hide();
        }

        // Tombol Dashboard
        private void buttonDashboard_Click(object sender, EventArgs e) {
            ResetMenu();
            buttonDashboard.BackColor = Color.Teal;
            func.LoadForm(new menuDashboard(), panelFill);
        }

        // Tombol Data Master
        private void buttonDataMaster_Click(object sender, EventArgs e) {
            ResetMenu();
            buttonDataMaster.BackColor = Color.Teal;
            func.LoadForm(new menuDataMaster(), panelFill);
        }

        // Tombol Pendafataran
        private void buttonPendaftaran_Click(object sender, EventArgs e) {
            ResetMenu();
            buttonPendaftaran.BackColor = Color.Teal;
            func.LoadForm(new menuPendaftaran(), panelFill);
        }

        // Tombol Rawat Inap
        private void buttonRanap_Click(object sender, EventArgs e) {
            ResetMenu();
            buttonRanap.BackColor = Color.Teal;
            func.LoadForm(new menuRawatInap(), panelFill);
        }

        // Tombol Diagnosa
        private void buttonDiagnosa_Click(object sender, EventArgs e) {
            ResetMenu();
            buttonDiagnosa.BackColor = Color.Teal;
            func.LoadForm(new menuDiagnosa(), panelFill);
        }

        // Tombol Rekam Medis
        private void buttonRekamMedis_Click(object sender, EventArgs e) {
            ResetMenu();
            buttonRekamMedis.BackColor = Color.Teal;
            func.LoadForm(new menuRekamMedis(), panelFill);
        }

        // Tombol Pembayaran
        private void buttonPembayaran_Click(object sender, EventArgs e) {
            ResetMenu();
            buttonPembayaran.BackColor = Color.Teal;
            func.LoadForm(new menuPembayaran(), panelFill);
        }

        // Tombol Laporan
        private void buttonLaporan_Click(object sender, EventArgs e) {
            ResetMenu();
            buttonLaporan.BackColor = Color.Teal;
            func.LoadForm(new menuLaporan(), panelFill);
        }
    }
}
