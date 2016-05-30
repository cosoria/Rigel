using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;

[assembly: AssemblyCompany("Rigel Technologies Inc")]
[assembly: AssemblyProduct("Rigel Infrastructure Libraries")]
[assembly: AssemblyCopyright("Copyright © Rigel Technologies Inc  2013")]
[assembly: AssemblyTrademark("These Libraries are relased under the terms of BSD license")]
[assembly: AssemblyCulture("")]
[assembly: AllowPartiallyTrustedCallers]
[assembly: ComVisible(false)]

namespace Rigel.Core
{
    public static class GlobalAssemblyInfo
    {
        internal const string Copyright = "Copyright (c) Rigel Technologies Inc 2013";
        internal const string Trademark = "These libraries are released under the terms of BSD licence";
        internal const string Company = "Rigel Technologies Inc";
        internal const string Product = "Rigel Infrastructure Libraries";         
    }
}
