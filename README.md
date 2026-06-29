<div align="center">

# 🏥 RSUD-SYSTEM

### Hospital Information System (HIS)

A desktop-based Hospital Information System developed using **C# Windows Forms** and **MySQL** to simplify hospital administration processes, including patient registration, medical records, inpatient management, payments, and reporting.

![C#](https://img.shields.io/badge/C%23-Windows%20Forms-blue)
![Framework](https://img.shields.io/badge/.NET_Framework-4.x-purple)
![Database](https://img.shields.io/badge/MySQL-Database-orange)
![Visual Studio](https://img.shields.io/badge/IDE-Visual%20Studio-blueviolet)

</div>

---

# 📖 About

RSUD-SYSTEM is a desktop application designed to assist hospital staff in managing patient administration efficiently.

The application is built using **Windows Forms (.NET Framework)** and uses **MySQL** as its database management system.

---

# ✨ Features

## 🔐 Authentication

- Login System
- User Session
- Greeting Based on Time

---

## 📊 Dashboard

- Main Navigation
- Quick Access Menu
- User Information

📷

> `preview/dashboard.png`

---

## 🗂 Data Master

Manage hospital master data such as:

- Patients
- Doctors
- Rooms
- Medicines
- Medical Staff
- Other Master Data

📷

> `preview/data-master.png`

---

## 📝 Patient Registration

- Register New Patient
- Outpatient Registration
- Search Patient
- Registration History

📷

> `preview/pendaftaran.png`

---

## 🩺 Diagnosis

- Patient Examination
- Diagnosis Input
- Medical Treatment
- Prescription

📷

> `preview/diagnosa.png`

---

## 📄 Medical Record

- Patient History
- Diagnosis History
- Treatment History
- Medical Record Management

📷

> `preview/rekam-medis.png`

---

## 🛏 Inpatient

- Room Selection
- Room Availability
- Check-In
- Check-Out

📷

> `preview/rawat-inap.png`

---

## 💳 Payment

- Billing
- Payment Processing
- Receipt

📷

> `preview/pembayaran.png`

---

## 📈 Reports

Generate reports including:

- Patient Report
- Medical Record Report
- Payment Report
- Registration Report

📷

> `preview/laporan.png`

---

# 🖼 Application Preview

| Menu | Screenshot |
|------|------------|
| Dashboard | `preview/dashboard.png` |
| Data Master | `preview/data-master.png` |
| Registration | `preview/pendaftaran.png` |
| Diagnosis | `preview/diagnosa.png` |
| Medical Record | `preview/rekam-medis.png` |
| Inpatient | `preview/rawat-inap.png` |
| Payment | `preview/pembayaran.png` |
| Reports | `preview/laporan.png` |

---

# 🛠 Technology Stack

| Technology | Description |
|------------|-------------|
| Language | C# |
| Framework | Windows Forms (.NET Framework) |
| IDE | Visual Studio |
| Database | MySQL |
| Connector | MySql.Data 6.7.9 |

---

# 📂 Project Structure

```
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
│   └── Koneksi.cs
│
├── packages/
└── README.md
```

---

# 🚀 Getting Started

### Clone Repository

```bash
git clone https://github.com/rtwone/RSUD-SYSTEM.git
```

### Open Project

Open

```
RSUD-SYSTEM.sln
```

using **Visual Studio**.

### Database

Import your MySQL database, then configure the database connection inside:

```
Koneksi.cs
```

or

```
App.config
```

depending on your local setup.

---

# 📌 Notes

- Developed for educational purposes.
- Built with Windows Forms (.NET Framework).
- Requires MySQL Server.

---

# 👨‍💻 Developer

**Irfan Hariyanto**

GitHub

https://github.com/rtwone

---

<div align="center">

⭐ If you find this project useful, don't forget to leave a Star!

</div>
