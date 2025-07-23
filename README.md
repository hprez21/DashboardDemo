# DashboardDemo

A .NET MAUI application designed to demonstrate and practice **Markup Extensions** implementation, specifically focusing on role-based UI visibility control through attached properties. This project showcases how to create custom attached properties that can be used directly in XAML to control UI element visibility based on user roles.

## Project Overview

This dashboard application implements a role-based visibility system using custom attached properties as markup extensions. The main feature is the `RoleManager` attached property that allows developers to declaratively specify which UI elements should be visible for different user roles (User vs Admin) directly in XAML markup.

### Key Features

- **Custom Attached Properties**: Implementation of `RoleManager.Visibility` attached property for role-based UI control
- **Role-Based Dashboard**: Different UI elements visible depending on user role (User/Admin)
- **Chart Integration**: Sales statistics visualization using Microcharts library (visible for Admin role)
- **MVVM Pattern**: Clean separation of concerns using ViewModels and ObservableObject
- **Cross-Platform**: Built with .NET MAUI for multiple platform support

### Learning Objectives

- Understanding how to create and implement custom attached properties in .NET MAUI
- Learning how attached properties work as markup extensions in XAML
- Practicing role-based UI design patterns
- Working with bindable properties and their lifecycle
- Implementing conditional UI visibility based on application state

## Project Structure

The project is organized following standard .NET MAUI conventions with additional folders for custom implementations:

### Core Components

- **`AttachedProperties/`**
  - `RoleManager.cs` - Custom attached property implementation for role-based visibility control

- **`Enums/`**
  - `UserRole.cs` - Enumeration defining available user roles (User, Admin)

- **`Models/`**
  - `DailySales.cs` - Data model representing daily sales information

- **`ViewModels/`**
  - `DashboardViewModel.cs` - MVVM ViewModel managing dashboard data and chart entries

- **`Views/`**
  - `DashboardView.xaml` - Main dashboard UI with role-based element visibility
  - `DashboardView.xaml.cs` - Code-behind for dashboard view

### Platform-Specific Folders

- **`Platforms/`** - Contains platform-specific implementations for Android, iOS, MacCatalyst, Windows, and Tizen
- **`Resources/`** - Application resources including fonts, images, styles, and app icons

### Configuration Files

- **`MauiProgram.cs`** - Application startup and service configuration
- **`App.xaml`** - Application-level resources and styling
- **`AppShell.xaml`** - Navigation shell configuration
- **`MainPage.xaml`** - Application entry point page

### Key Implementation Details

The `RoleManager` attached property is implemented as a bindable property that can be attached to any UI element:

```csharp
public static BindableProperty VisibilityProperty =
    BindableProperty.CreateAttached("Visibility",
        typeof(UserRole), typeof(RoleManager), UserRole.User);
```

This allows XAML usage like:
```xaml
<Label attached:RoleManager.Visibility="Admin" Text="Admin Only Content" />
```

The project demonstrates how custom attached properties can serve as powerful markup extensions, enabling declarative UI control directly in XAML while maintaining clean separation between UI logic and business logic.