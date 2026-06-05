# 🏋️ BodyCheck

A console-based gym management system built with C# and .NET Framework 4.7.2. Manage client registrations, payments, BMI calculations, and daily revenue tracking.

## ✨ Features

- 📋 **Client Registration** – Register new clients with personal data, health info, and plan selection
- 💳 **Payment Processing** – Process monthly subscription payments and generate invoices
- 📊 **BMI Calculation** – Automatic Body Mass Index calculation with health diagnosis and routine recommendations
- 👨‍⚕️ **Nutritionist Review** – Placeholder for nutritionist consultation module
- 💰 **Daily Revenue Dashboard** – View registered users, paid plans, and total income for the day
- 🔒 **Age Validation** – Clients must be between 15 and 80 years old
- 👥 **Guardian Data** – Collects guardian information for clients under 18

## 📦 Plans Available

| Plan | Price |
|------|-------|
| 🖤 Black | $90,000 |
| 🧠 Smart | $75,000 |
| 🖤 Black (No Lock-in) | $100,000 |

## 🏥 BMI Classification

| Range | Diagnosis | Routine |
|-------|-----------|---------|
| ≤ 16.00 | Severe Thinness | A |
| 16.01 – 16.99 | Moderate Thinness | A |
| 17.00 – 18.49 | Mild Thinness | A |
| 18.50 – 24.99 | Normal (Healthy) | B |
| 25.00 – 29.99 | Overweight | B |
| 30.00 – 34.99 | Mild Obesity | B |
| 35.00 – 39.99 | Moderate Obesity | C |
| ≥ 40.00 | Severe Obesity | C |

## 🚀 Getting Started

### Prerequisites

- 🪟 Windows OS
- 🔧 Visual Studio 2017 or later
- 🎯 .NET Framework 4.7.2

### Build & Run

1. Clone the repository:
   ```bash
   git clone https://github.com/sebastianvasquezechavarria1234/net.git
   ```
2. Open `BodyCheck.sln` in Visual Studio
3. Build the solution (`Ctrl + Shift + B`)
4. Run the project (`F5`)

## 📁 Project Structure

```
BodyCheck/
├── 📄 BodyCheck.sln        # Solution file
├── 📄 README.md             # This file
└── 📂 BodyCheck/
    ├── 📄 BodyCheck.csproj  # Project file
    ├── 📄 Program.cs        # Main application logic
    ├── 📄 App.config        # Application configuration
    └── 📂 Properties/
        └── 📄 AssemblyInfo.cs
```

## 🛠️ Tech Stack

- 💻 **Language:** C#
- ⚙️ **Framework:** .NET Framework 4.7.2
- 🏗️ **IDE:** Visual Studio 2017+

## 📝 License

This project is for educational purposes.

---
Made with ❤️ by Sebastian Vasquez
