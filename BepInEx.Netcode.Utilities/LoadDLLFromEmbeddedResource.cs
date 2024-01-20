using System;
using System.Reflection;

namespace BepInEx.Netcode.Utilities
{
    internal static class LoadDLLFromEmbeddedResource
    {
        internal static Assembly OnAppDomainAssemblyResolveFailed(object sender, ResolveEventArgs args)
        {
            var assemName = new AssemblyName(args.Name);
            var resourceName = 
                Assembly.GetExecutingAssembly().GetName().Name + 
                ".Resources." + 
                assemName.CultureInfo.Name.ToLower().Replace('-', '_') + 
                "." + assemName.Name + ".dll";
            
            // ReSharper disable once ConvertToUsingDeclaration
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                if (stream == null) return null;
                var assemblyData = new byte[stream.Length];
                var dataRead = stream.Read(assemblyData, 0, assemblyData.Length);
                return dataRead == 0 ? null : Assembly.Load(assemblyData);
            }
        }
    }
}