using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace RSUD_SYSTEM {
    public partial class menuLogin : Form {
        public menuLogin() {
            InitializeComponent();
        }

        private void menuLogin_Load(object sender, EventArgs e) {
            emailTextBox.Text = "Masukkan email akses Anda";
            passwordTextBox.Text = "Kata sandi";
        }

        private void emailTextBox_Leave(object sender, EventArgs e) {
            if (emailTextBox.Text == "") {
                emailTextBox.Text = "Masukkan email akses Anda";
                emailTextBox.StateCommon.Content.Color1 = Color.Gray;
            }
        }

        private void emailTextBox_Enter(object sender, EventArgs e) {
            if (emailTextBox.Text == "Masukkan email akses Anda") {
                emailTextBox.Text = "";
                emailTextBox.StateCommon.Content.Color1 = Color.Black;
            }
        }

        private void passwordTextBox_Enter(object sender, EventArgs e) {
            if (passwordTextBox.Text == "Kata sandi") {
                passwordTextBox.Text = "";
                passwordTextBox.StateCommon.Content.Color1 = Color.Black;
                passwordTextBox.UseSystemPasswordChar = true;

                checkBoxPassword.Checked = false;
            }
        }

        private void passwordTextBox_Leave(object sender, EventArgs e) {
            if (passwordTextBox.Text == "") {
                passwordTextBox.Text = "Kata sandi";
                passwordTextBox.StateCommon.Content.Color1 = Color.Gray;
                passwordTextBox.UseSystemPasswordChar = false;
            }
        }

        private void buttonMasuk_Click(object sender, EventArgs e) {
            string query = "SELECT * FROM admin WHERE email=@email AND password=@password";
            var dt = DBHelper.GetData(query,
                new MySqlParameter("@email", emailTextBox.Text),
                new MySqlParameter("@password", passwordTextBox.Text)
            );
            if (emailTextBox.Text == "Masukkan email akses Anda" && passwordTextBox.Text == "Kata sandi") {
                labelIf.Text = "Masukkan email dan kata sandi";
            } else if (emailTextBox.Text == "Masukkan email akses Anda" || emailTextBox.Text == "" || !emailTextBox.Text.Contains("@")) {
                labelIf.Text = "Masukkan email yang valid";
            } else if (passwordTextBox.Text == "Kata sandi" || passwordTextBox.Text == "") {
                labelIf.Text = "Masukkan kata sandi";
            } else {
                if (dt.Rows.Count > 0) {
                    Session.IdUser = Convert.ToInt32(dt.Rows[0]["id"]);
                    Session.Email = dt.Rows[0]["email"].ToString();
                    Session.Role = dt.Rows[0]["role"].ToString();
                    Session.IsLogin = true;

                    menuUtama form = new menuUtama();
                    form.Show();
                    this.Hide();
                } else {
                    labelIf.Text = "Email atau kata sandi salah!";
                }
            }
        }

        private void closeButton_Click(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show(
                "Yakin ingin keluar?",
                "Konfirmasi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes) {
                Application.Exit();
            }
        }

        private void checkBoxPassword_CheckedChanged(object sender, EventArgs e) {
            if (passwordTextBox.Text == "Kata sandi") {
                passwordTextBox.UseSystemPasswordChar = false;
                return;
            }

            if (checkBoxPassword.Checked) {
                passwordTextBox.UseSystemPasswordChar = false; // tampilkan
                checkBoxPassword.Text = "Sembunyikan sandi";
            } else {
                passwordTextBox.UseSystemPasswordChar = true; // sembunyikan
                checkBoxPassword.Text = "Tampilkan sandi";
            }
        }
    }
}
