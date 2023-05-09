<h1 style="font-weight: bolder; text-align: center;">
    MSB STUDIOS
</h1>
<div align="center">
    <img src="/Icon.png" alt="Logo de mi proyecto" style="width: 256px; height: 256px; margin: 50px 0; border-radius: 15%;"/>
    <h2 style="text-align: center; margin-bottom: 25px;">
        MSB.UI (Windows Presentation Foundation)
    </h2>
    <p style="text-align:justify; font-size: 18px;">
        Welcome to the <strong>MSB.UI-WPF</strong> controls library, a collection of custom controls designed to enhance the user experience of your WPF applications. This library contains controls for a variety of use cases, including:
    </p>
</div>

- **ModernWindow:** An ordinary window at first glance, but it brings new functions, such as the possibility of hiding the icon, the title or extending the window content to the title bar. :O
- **SplitView:** It provides an easy way to implement the Master-Detail pattern in Win32 applications by splitting the user interface into two panes: one for the main content and one for navigation and configuration.
- **NavigationView:** This control provides an easy way to implement navigation in the application and is often used in combination with the Master-Detail pattern.
                      On the left side you can add your navigation options, navigation buttons and configuration areas and in the main area the content you want to navigate to.  
                      The control also adapts automatically to the various sizes of the containing window, you can modify the breakpoints using the `CompactModeThresholdWidth` and `ExpandedModeThresholdWidth` properties.
- **NavigationViewItem:** Represents an item in the list of navigation options in the `NavigationView` control.  
                          Nesting has not been implemented at this time. :'(
![NavigationViewItem sample](/Assets/Images/NavigationViewItem.png){ width = 540 }
- **NavigationViewList:** A container used in the `NavigationView` control to group and display the Menu and Footer items..
- **PathIcon:** Based on the already known `Path` control, but inherits the foreground of the parent element, giving a better result.
- **FontIcon:** Provides a fairly quick and easy way to display icons in our user interface using icon fonts.  
                At the moment you can only use the elements included in the `Segoe MDL2 Assets` font.  
![FontIcon sample](/Assets/Images/FontIcon.png){ width = 440 }
- **AppBarButton:** A variant of the classic button to allow displaying an icon and a label, or just the icon.  
![AppBarButton sample](/Assets/Images/AppBarButton.png){ width = 540 }
- **MessageDialog:** Custom controls for displaying data in an elegant and appealing way, such as charts, tables, and heat maps.  
![MessageDialog sample](/Assets/Images/MessageDialog.png){ width = 540 }

## Installation

To install the library simply download it from [NuGet](https://www.nuget.org/) and add the reference to your project.  
Below we give you several options to install it using your preferred package manager.

- #### .NET CLI
```bash
> dotnet add package MSB.UI-WPF --version 1.4.5
```
- #### Package Manager
```bash
PM> Install-Package MSB.UI-WPF -Version 1.4.5
```
- #### PackageReference
```bash
<PackageReference Include="MSB.UI-WPF" Version="1.4.5" />
```
- #### Paket CLI
```bash
> paket add MSB.UI-WPF --version 1.4.5
```
- #### Script & Interactive
```bash
> #r "nuget: MSB.UI-WPF, 1.4.5"
```
- #### Cake
```bash
// Install MSB.UI-WPF as a Cake Addin
#addin nuget:?package=MSB.UI-WPF&version=1.4.1

// Install MSB.UI-WPF as a Cake Tool
#tool nuget:?package=MSB.UI-WPF&version=1.4.1
```

## Usage

The controls in this library are used in the same way as standard WPF .NET controls. Simply add the control to your XAML window or page, set the necessary properties, and bind the required events.  
Here's an example of how to use the `NavigationView` control:

```XAML
<Window x:Class="MyApp.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:msb="http://ui.msb-studios.com/winfx/xaml">

    <Grid>
        <msb:NavigationView IsTitleBarPaddingEnabled="True">
            <!--place your content here...-->
            ...
        </msb:NavigationView>
    </Grid>
</Window>
```

Almost all controls in this library depend on resources included in a `XamlControlsResources.xaml` file that is not automatically referenced, this file contains important resources for the controls in this library as well as custom styles for the default WPF controls.  
Here is an example of how to reference this file in your project:

```XAML
<Application x:Class="MyWpfApp.App"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:local="clr-namespace:MyWpfApp"
             StartupUri="MainWindow.xaml">

    <Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="/MSB.UI-WPF;component/Assets/XamlControlsResources.xaml"/>
                <!--here you can include your own dictionaries of resources...-->
                ...
            </ResourceDictionary.MergedDictionaries>
            <!--other resources...-->
            ...
        </ResourceDictionary>
    </Application.Resources>
</Application>
```

## Contribute

If you want to contribute to this control library, we'd love your help! Here are some ways you can contribute:

- **Fix bugs:** If you find any bugs or issues with any of the controls, please create an issue on the [GitHub repository](https://github.com/MSB-Studios/MSB-Studios-Toolkit/issues).
- **Add new controls:** If you have an idea for a new useful control, please create a feature request on the [GitHub repository](https://github.com/MSB-Studios/MSB-Studios-Toolkit/pulls).
- **Improve existing controls:** If you want to improve the functionality or appearance of an existing control, please create a feature request on the [GitHub repository](https://github.com/MSB-Studios/MSB-Studios-Toolkit/pulls).

## License

This library is licensed under the MIT license. Check out the LICENSE.txt file for more information.

## Contact

If you have any questions or comments about this library, please drop us an email at msbstudios@outlook.com or create an issue on the [GitHub repository](https://github.com/MSB-Studios/MSB-Studios-Toolkit/issues).
