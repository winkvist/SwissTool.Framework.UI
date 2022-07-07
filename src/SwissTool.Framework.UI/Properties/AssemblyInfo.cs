using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Markup;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("SwissTool.Framework.UI")]
[assembly: AssemblyDescription("UI components for developing SwissTool extensions")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Fredrik Winkvist")]
[assembly: AssemblyProduct("SwissTool.Framework.UI")]
[assembly: AssemblyCopyright("Copyright © Fredrik Winkvist")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

[assembly: ThemeInfo(ResourceDictionaryLocation.None, ResourceDictionaryLocation.SourceAssembly)]

[assembly: XmlnsPrefix("http://metro.mahapps.com/winfx/xaml/controls", "mah")]
[assembly: XmlnsPrefix("http://metro.mahapps.com/winfx/xaml/shared", "mah")]

[assembly: XmlnsDefinition("http://metro.mahapps.com/winfx/xaml/shared", "MahApps.Metro.Behaviours")]
[assembly: XmlnsDefinition("http://metro.mahapps.com/winfx/xaml/shared", "MahApps.Metro.Actions")]
[assembly: XmlnsDefinition("http://metro.mahapps.com/winfx/xaml/shared", "MahApps.Metro.Converters")]
[assembly: XmlnsDefinition("http://metro.mahapps.com/winfx/xaml/controls", "MahApps.Metro")]
[assembly: XmlnsDefinition("http://metro.mahapps.com/winfx/xaml/controls", "MahApps.Metro.Controls")]
[assembly: XmlnsDefinition("http://metro.mahapps.com/winfx/xaml/controls", "MahApps.Metro.Controls.Dialogs")]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("8ac97ebe-9b3b-435a-922e-a8961cd1b485")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.4.0")]
[assembly: AssemblyFileVersion("1.0.4.0")]

[assembly: InternalsVisibleTo("SwissTool")]
[assembly: InternalsVisibleTo("SwissTool.Application")]
[assembly: InternalsVisibleTo("Loader")]