using System;
using System.Reflection;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyCompany("GW2.NET Coding Team")]
[assembly: AssemblyProduct("GW2.NET")]
[assembly: AssemblyCopyright("GNU General Public License version 2 (GPLv2)")]
[assembly: AssemblyTrademark("")]
[assembly: CLSCompliant(true)]
[assembly: ComVisible(false)]

// Version information for an assembly consists of the following four values:
//      Major Version
//      Minor Version 
//      Build Number
//      Revision

// MEMO: [AssemblyVersion] is used by the .NET runtime to decide whether assemblies are backwards-compatible.
// Only set the major version component. The minor version component is still required, so we use 0.
// Format         ---> {major}.0
// Valid examples ---> 1.0; 2.0; 3.0; 32767.0
// The reasoning is that only the major version component indicates breaking changes.
[assembly: AssemblyVersion("1.0")]

// MEMO: [AssemblyFileVersion] is used for display
[assembly: AssemblyFileVersion("1.2")]

// MEMO: [AssemblyInformationalVersion] is the NuGet package version.
// The informational version uses different versioning rules, based on semantic versioning (SemVer).
// For beta releases, append a label to the informational version, separated by a hyphen (-).
// Valid example: 1.0.0-beta
// Note: version '1.0.0' is considered greater than '1.0.0-beta'.
// Note: version '1.0.0-beta1' is considered greater than '1.0.0-beta12' ---> lexical sort instead of numeric sort.
// More information: http://semver.org/
[assembly: AssemblyInformationalVersion("1.2.0")]