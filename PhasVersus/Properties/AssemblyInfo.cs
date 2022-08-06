using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using MelonLoader;
using BI = PhasVersus.BuildInfo;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("PhasVersus")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyProduct("PhasVersus")]
[assembly: AssemblyCopyright("Copyright © Microsoft 2022")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: MelonInfo(typeof(PhasVersus.Main), BI.ModName, BI.ModVersion, BI.ModAuthor)]
[assembly: MelonGame(BI.GameStudio, BI.GameName)]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("02890623-1499-4b99-a680-db89cb414432")]

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
[assembly: AssemblyVersion(BI.ModVersion)]
[assembly: AssemblyFileVersion(BI.ModVersion)]
