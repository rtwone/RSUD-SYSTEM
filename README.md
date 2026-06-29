<div align="center">

# 🏥 RSUD-SYSTEM

### Sistem Informasi Rumah Sakit (RSUD)

Aplikasi desktop berbasis **C# Windows Forms** yang dirancang untuk membantu proses administrasi rumah sakit, mulai dari pendaftaran pasien, pengelolaan data master, rekam medis, rawat inap, pembayaran, hingga pembuatan laporan.

![C#](https://img.shields.io/badge/C%23-Windows%20Forms-blue)
![Framework](https://img.shields.io/badge/.NET_Framework-4.x-purple)
![Database](https://img.shields.io/badge/Database-MySQL-orange)
![IDE](https://img.shields.io/badge/IDE-Visual%20Studio-blueviolet)

</div>

---

# 📖 Tentang Project

**RSUD-SYSTEM** merupakan aplikasi Sistem Informasi Rumah Sakit berbasis desktop yang dikembangkan menggunakan **C# Windows Forms** dengan **MySQL** sebagai basis data.

Aplikasi ini dibuat untuk membantu pengelolaan administrasi rumah sakit agar proses pelayanan pasien menjadi lebih terstruktur, cepat, dan efisien.

---

# ✨ Fitur Utama

## 🔐 Login

- Sistem Login Admin
- Manajemen Sesi Pengguna
- Sapaan otomatis berdasarkan waktu (Pagi, Siang, Sore, Malam)

---

## 📊 Dashboard

Menampilkan halaman utama aplikasi sebagai pusat navigasi menuju seluruh menu yang tersedia.

📷

> `preview/dashboard.png`

---

## 🗂 Data Master

Mengelola seluruh data utama yang digunakan dalam sistem.

**Fitur**

- Data Pasien
- Data Dokter
- Data Kamar
- Data Obat
- Data Petugas
- Data lainnya

📷

> `preview/data-master.png`

---

## 📝 Pendaftaran

Digunakan untuk melakukan proses registrasi pasien.

**Fitur**

- Registrasi Pasien
- Pendaftaran Rawat Jalan
- Pendaftaran Rawat Inap
- Pencarian Data Pasien

📷

> `preview/pendaftaran.png`

---

## 🩺 Diagnosa

Digunakan oleh petugas atau dokter untuk melakukan pencatatan hasil pemeriksaan pasien.

**Fitur**

- Input Diagnosa
- Pemeriksaan Pasien
- Tindakan Medis
- Resep Obat

📷

> `preview/diagnosa.png`

---

## 📄 Rekam Medis

Menyimpan seluruh riwayat pemeriksaan pasien.

**Fitur**

- Riwayat Pemeriksaan
- Riwayat Diagnosa
- Riwayat Pengobatan
- Data Rekam Medis

📷

> `preview/rekam-medis.png`

---

## 🛏 Rawat Inap

Mengelola proses rawat inap pasien.

**Fitur**

- Pemilihan Kamar
- Informasi Ketersediaan Kamar
- Check In Pasien
- Check Out Pasien

📷

> `preview/rawat-inap.png`

---

## 💳 Pembayaran

Mengelola proses transaksi pembayaran pasien.

**Fitur**

- Perhitungan Tagihan
- Pembayaran
- Cetak Kwitansi

📷

> `preview/pembayaran.png`

---

## 📈 Laporan

Menyediakan berbagai laporan yang dapat dicetak.

**Fitur**

- Laporan Data Pasien
- Laporan Rekam Medis
- Laporan Pembayaran
- Laporan Pendaftaran

📷

> `preview/laporan.png`

---

# 🖼 Preview Aplikasi

| Menu | Screenshot |
|------|------------|
| Dashboard | `preview/dashboard.png` |
| Data Master | `preview/data-master.png` |
| Pendaftaran | `preview/pendaftaran.png` |
| Diagnosa | `preview/diagnosa.png` |
| Rekam Medis | `preview/rekam-medis.png` |
| Rawat Inap | `preview/rawat-inap.png` |
| Pembayaran | `preview/pembayaran.png` |
| Laporan | `preview/laporan.png` |

---

# 🛠 Teknologi yang Digunakan

| Teknologi | Keterangan |
|-----------|------------|
| Bahasa Pemrograman | C# |
| Framework | Windows Forms (.NET Framework) |
| Database | MySQL |
| IDE | Microsoft Visual Studio |
| Library | MySql.Data 6.7.9 |

---

# 📂 Struktur Project

```text
RSUD-SYSTEM
│
├── RSUD-SYSTEM.sln
│
├── RSUD-SYSTEM/
│   ├── menuLogin
│   ├── menuUtama
│   ├── menuDashboard
│   ├── menuDataMaster
│   ├── menuPendaftaran
│   ├── menuDiagnosa
│   ├── menuRekamMedis
│   ├── menuRawatInap
│   ├── menuPembayaran
│   ├── menuLaporan
│   ├── FormTambahEdit
│   ├── FormPopupDetailKunjungan
│   ├── pilihKamar
│   └── koneksi.cs
│
├── packages/
└── README.md
```

---

# 🚀 Cara Menjalankan

### 1. Clone Repository

```bash
git clone https://github.com/rtwone/RSUD-SYSTEM.git
```

### 2. Buka Project

Buka file berikut menggunakan **Microsoft Visual Studio**.

```
RSUD-SYSTEM.sln
```

### 3. Restore Package

Apabila diperlukan, lakukan Restore NuGet Package melalui Visual Studio.

### 4. Konfigurasi Database

Import database MySQL yang digunakan, kemudian sesuaikan konfigurasi koneksi database pada file:

```
koneksi.cs
```

atau

```
App.config
```

sesuai dengan konfigurasi project.

### 5. Jalankan Aplikasi

Build project, kemudian jalankan aplikasi menggunakan Visual Studio.

---

# 📌 Catatan

- Project ini dibuat sebagai media pembelajaran dan pengembangan aplikasi desktop menggunakan C# Windows Forms.
- Database yang digunakan adalah MySQL.
- Disarankan menggunakan Microsoft Visual Studio agar seluruh dependensi dapat berjalan dengan baik.

---

# 👨‍💻 Developer

**Irfan Hariyanto**

GitHub: https://github.com/rtwone

---

<div align="center">

⭐ Jika repository ini bermanfaat, jangan lupa berikan **Star** sebagai bentuk apresiasi.

Terima kasih telah berkunjung.

</div>
