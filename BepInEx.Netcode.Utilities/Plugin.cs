using System;
using System.Linq;

namespace BepInEx.Netcode.Utilities
{
    internal static class DependantRegistry
    {
        internal static PluginInfo[] Dependants { get; private set; }
        internal static void LoadDependants()
        {
            Dependants = Bootstrap.Chainloader.PluginInfos
                .Where(pluginInfo => pluginInfo.Value.Dependencies
                    .Any(dependency => dependency.DependencyGUID == Plugin.Id))
                .Select(keyValuePair => keyValuePair.Value).ToArray();
        }
    }
    
    [BepInAutoPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    public partial class Plugin : BaseUnityPlugin
    {
        internal new static Logging.ManualLogSource Logger { get; private set; }

        private void Awake()
        {
            Logger = base.Logger;

            AppDomain.CurrentDomain.AssemblyResolve += LoadDLLFromEmbeddedResource.OnAppDomainAssemblyResolveFailed;
        }
        private void Start()
        {
            DependantRegistry.LoadDependants();
        }
    }
}