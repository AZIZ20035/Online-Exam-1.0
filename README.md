# Online Exam System 1.0

## Description

The Online Exam System is a simple MVC web application built with ASP.NET Core that allows users to create, manage, and take online exams. The system provides a comprehensive platform for educational assessment with automatic grade calculation and progress tracking capabilities.

## 🎯 Key Features

- **Exam Creation & Management**: Create and start online exams with customizable questions
- **Grade Tracking**: View exam grades and monitor progress across previous exams
- **Google Sheets Integration**: Automatically syncs and updates exam data with Google Spreadsheet
- **Progress Monitoring**: Track student performance and exam history
- **User-Friendly Interface**: Clean and intuitive web interface for seamless user experience

## 🛠️ Technology Stack

### Backend
- **Framework**: ASP.NET Core
- **Database**: SQL Server
- **ORM**: Entity Framework Core
- **Architecture**: MVC (Model-View-Controller)
- **Programming Language**: C#
- **Paradigm**: Object-Oriented Programming (OOP)

### Frontend
- **Markup**: HTML5
- **Styling**: CSS3
- **User Interface**: Responsive web design

### External Integration
- **Google Sheets API**: For automatic data synchronization and updates

## Prerequisites

Before running the project, ensure you have the following installed:

- [.NET Core SDK](https://dotnet.microsoft.com/download) (version compatible with ASP.NET Core)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (Local or Remote)
- [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)
- Google Account (for Google Sheets integration)

## Installation & Setup

### 1. Clone the Repository

```bash
git clone https://github.com/AZIZ20035/Online-Exam-1.0.git
cd Online-Exam-1.0
```

### 2. Install Dependencies

```bash
dotnet restore
```

### 3. Database Configuration

1. **Update Connection String**: 
   - Open `appsettings.json`
   - Update the connection string to point to your SQL Server instance:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=OnlineExamDB;Trusted_Connection=true;TrustServerCertificate=true;"
  }
}
```

### 4. Database Migration

```bash
# Create migration
dotnet ef migrations add InitialCreate

# Update database
dotnet ef database update
```

### 5. Run the Application

```bash
dotnet run
```

The application will be available at:
- **HTTP**: `http://localhost:5000`
- **HTTPS**: `https://localhost:5001`

## 📁 Project Structure

```
Online-Exam-1.0/
├── Controllers/          # MVC Controllers
├── Models/              # Data Models and ViewModels
├── Views/               # Razor Views (HTML templates)
├── wwwroot/            # Static files (CSS, JS, images)
├── Data/               # Database Context and configurations
├── Services/           # Business logic and Google Sheets integration
├── appsettings.json    # Configuration settings
└── Program.cs          # Application entry point
```

## 🚀 Features Overview

### For Users
- Create new online exams with multiple question types
- Start and complete exams within the system
- View individual exam grades and scores
- Track progress across multiple exam attempts
- Monitor performance over time

### For Administrators
- Manage exam content and questions
- Monitor system-wide exam statistics


## License

This project is developed for educational purposes and learning ASP.NET Core MVC development.

## Support

For support or questions about the project, please open an issue in the repository or contact the development team.

---

**Note**: This is a learning project demonstrating ASP.NET Core MVC architecture with Entity Framework and external API integration.
