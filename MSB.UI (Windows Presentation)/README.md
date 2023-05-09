# MSB STUDIOS
Welcome to the **MSB.UI-WPF** controls library, a collection of custom controls designed to enhance the user experience of your WPF applications. This library contains controls for a variety of use cases, including:

- **ModernWindow**
- **SplitView**
- **NavigationView**
- **NavigationViewItem**
- **NavigationViewList**
- **PathIcon**
- **FontIcon**
- **AppBarButton**
- **MessageDialog**
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
