namespace BepInEx.Netcode.Utilities.Tester
{
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        public static string PluginGuid => MyPluginInfo.PLUGIN_GUID;
        public new static Logging.ManualLogSource Logger { get; private set; }

        private void Awake()
        {
            Logger = base.Logger;
        }
    }
}