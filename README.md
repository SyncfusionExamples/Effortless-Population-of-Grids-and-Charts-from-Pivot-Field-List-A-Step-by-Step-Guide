# 📊 Effortless Population of Grids and Charts from Pivot Field List

[![License](https://img.shields.io/badge/license-SEE%20LICENSE-blue.svg)](https://www.syncfusion.com/content/downloads/syncfusion_license.pdf)
[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4.svg)](https://dotnet.microsoft.com/)
[![Visual Studio](https://img.shields.io/badge/Visual%20Studio-2022-5C2D91.svg)](https://visualstudio.microsoft.com/)
[![Status](https://img.shields.io/badge/status-stable-brightgreen.svg)](#)

> **Server-side pivot controls integration with dynamic client-side grid and chart visualization** — Build powerful data analytics dashboards with ASP.NET Core backend and responsive HTML5/JavaScript frontend.

## 🔍 Overview

This project demonstrates a complete, production-ready implementation of integrating **server-side pivot field list functionality** with **dynamic client-side grid and chart rendering**. Perfect for building business intelligence dashboards, financial reporting tools, and data analytics applications using ASP.NET Core and modern web technologies.

## ✨ Key Features

- ✅ **Server-Side Pivot Field List**: Efficiently process and configure pivot components on the backend
- ✅ **Dynamic Grid Population**: Auto-populate grids based on real-time pivot configurations
- ✅ **Interactive Charts**: Render professional charts alongside grid data
- ✅ **Real-Time Updates**: Charts and grids refresh automatically as pivot settings change
- ✅ **Cross-Platform Compatibility**: Works seamlessly across all modern browsers
- ✅ **RESTful API Integration**: Clean communication between backend and frontend
- ✅ **Production Ready**: Built with best practices and scalable architecture

## 🛠 Technology Stack & Requirements

### Prerequisites
- **Visual Studio 2022** or later
- **.NET 8.0 SDK** or runtime
- **Modern web browser** (Chrome, Edge, Firefox, Safari)
- **ASP.NET Core runtime**

### Core Technologies
- **Backend**: ASP.NET Core 8.0
- **Frontend**: HTML5, JavaScript, CSS3
- **Data Format**: JSON
- **Communication**: RESTful API over HTTP

## 📦 Installation & Setup

### Step 1: Open Project
Open the `PivotController.sln` solution file in Visual Studio 2022:
```
File → Open → PivotController/PivotController.sln
```

### Step 2: Restore Dependencies
NuGet packages restore automatically during the build process. If needed, manually restore:
```bash
Right-click Solution → Restore NuGet Packages
```

### Step 3: Build Solution
Build the entire solution:
```bash
Build → Build Solution (Ctrl+Shift+B)
```

### Step 4: Run Application
Start the ASP.NET Core application:
```bash
Debug → Start Debugging (F5)
```
The application will start on a local development server (typically `http://localhost:5000` or `http://localhost:5001`).

### Step 5: Configure Frontend URL
Copy the running application URL and update it in `Sample/pivot.js`:
```javascript
const API_URL = 'http://localhost:5000'; // Update with your local URL
```

### Step 6: View Results
Open `Sample/pivot.html` in your browser to see the rendered grids and charts.

## 🚀 Quick Start

1. **Clone or open the project** in Visual Studio
2. **Build the solution** (`Ctrl+Shift+B`)
3. **Run the application** (`F5`)
4. **Copy the localhost URL** from the console output
5. **Update `Sample/pivot.js`** with the localhost URL
6. **Open `Sample/pivot.html`** in your browser
7. **Interact with the pivot field list** to see real-time grid and chart updates

## 🗂 Project Structure

```
PivotController/
├── PivotController.csproj        # Project configuration
├── Program.cs                    # ASP.NET Core startup configuration
├── PivotController.cs            # Main controller logic
├── appsettings.json              # Application settings
├── appsettings.Development.json  # Development configuration
├── Properties/
│   └── launchSettings.json       # Debug launch settings
├── bin/                          # Compiled binaries
└── obj/                          # Build artifacts

Sample/
├── pivot.html                    # Main HTML interface
├── pivot.js                      # Client-side logic & API integration
└── require.js                    # Module loader
```

## 💡 Core Concepts

### Server-Side Processing
The `PivotController` handles:
- Data aggregation from backend sources
- Pivot field configuration
- Grid and chart data generation
- RESTful API responses

### Client-Side Rendering
The frontend (`pivot.html` and `pivot.js`) handles:
- Interactive pivot field list UI
- Dynamic grid rendering
- Chart visualization
- Real-time data updates via API calls

### Data Flow
```
User Interaction (UI) → API Request (pivot.js) 
  → Server Processing (PivotController) 
  → JSON Response → Grid & Chart Rendering
```

## ⚙️ Configuration

### Application Settings
Configure the application in `appsettings.json`:
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information"
    }
  }
}
```

### Development Mode
For development-specific settings, use `appsettings.Development.json`. Enable developer exception pages and detailed logging.

## 🎯 Usage Examples

### Basic Pivot Configuration
Interact with the pivot field list in `Sample/pivot.html` to:
1. **Drag fields** to rows, columns, and values sections
2. **Configure aggregation** (Sum, Count, Average, etc.)
3. **Apply filters** to pivot data
4. Watch grids and charts update **in real-time**

### Accessing Data via API
The backend exposes RESTful endpoints for:
- Fetching pivot configurations
- Getting aggregated data
- Retrieving chart-ready datasets

## ❓ Troubleshooting & FAQ

**Q: Application won't start**
- Ensure .NET 8.0 SDK is installed: `dotnet --version`
- Check that port 5000/5001 is available
- Review console output for specific errors

**Q: Grids/Charts not appearing**
- Verify the `API_URL` in `Sample/pivot.js` matches your running server
- Check browser console for JavaScript errors
- Ensure CORS is properly configured in ASP.NET Core

**Q: Port already in use**
- Change the launch URL in `Properties/launchSettings.json`
- Or use `netstat` to find and terminate conflicting processes

## 📚 Resources

- [ASP.NET Core Documentation](https://learn.microsoft.com/en-us/aspnet/core/)
- [MDN Web Docs](https://developer.mozilla.org/)
- [Syncfusion Pivot Table Components](https://www.syncfusion.com/)

## 🤝 Contributing

Contributions are welcome! Please feel free to submit issues and pull requests to improve this project.

## 📄 License

This project is licensed under the **Syncfusion Community License**. See [Syncfusion License](https://www.syncfusion.com/content/downloads/syncfusion_license.pdf) for details.

## 🆘 Support

For questions, issues, or suggestions:
- 📧 Open an GitHub issue
- 💬 Review the troubleshooting section above
- 🔍 Check the project structure and code comments
