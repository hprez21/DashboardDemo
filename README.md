# DashboardDemo

A .NET MAUI application designed to demonstrate and practice **Bindable Properties** and **Attached Properties** implementation, specifically focusing on role-based UI visibility control. This project showcases how to create custom attached properties using bindable properties that can be used directly in XAML to control UI element visibility based on user roles.

## Project Overview

This dashboard application implements a role-based visibility system using custom attached properties built on bindable properties. The main feature is the `RoleManager` attached property that allows developers to declaratively specify which UI elements should be visible for different user roles (User vs Admin) directly in XAML markup.

### Key Features

- **Custom Attached Properties**: Implementation of `RoleManager.Visibility` attached property using bindable properties for role-based UI control
- **Role-Based Dashboard**: Different UI elements visible depending on user role (User/Admin)
- **Chart Integration**: Sales statistics visualization using Microcharts library (visible for Admin role)
- **MVVM Pattern**: Clean separation of concerns using ViewModels and ObservableObject
- **Cross-Platform**: Built with .NET MAUI for multiple platform support

### Learning Objectives

- Understanding how to create and implement custom attached properties in .NET MAUI using bindable properties
- Learning how attached properties work and their relationship with bindable properties in XAML
- Practicing role-based UI design patterns
- Working with bindable properties and their lifecycle
- Understanding the BindableProperty.CreateAttached method and its parameters
- Implementing conditional UI visibility based on application state using custom properties

## Project Structure

The project is organized following standard .NET MAUI conventions with additional folders for custom implementations:

### Core Components

- **`AttachedProperties/`**
  - `RoleManager.cs` - Custom attached property implementation using bindable properties for role-based visibility control

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

The `RoleManager` attached property is implemented using the `BindableProperty.CreateAttached` method, creating a bindable property that can be attached to any UI element:

```csharp
public static BindableProperty VisibilityProperty =
    BindableProperty.CreateAttached("Visibility",
        typeof(UserRole), typeof(RoleManager), UserRole.User);
```

This demonstrates the core concepts of:
- **Bindable Properties**: The foundation that enables data binding and property change notifications
- **Attached Properties**: Properties that can be "attached" to any UI element, even if the element doesn't originally define that property

The XAML usage shows how attached properties work:
```xaml
<Label attached:RoleManager.Visibility="Admin" Text="Admin Only Content" />
```

The project demonstrates how bindable properties serve as the foundation for attached properties, enabling powerful declarative UI control directly in XAML while maintaining clean separation between UI logic and business logic.