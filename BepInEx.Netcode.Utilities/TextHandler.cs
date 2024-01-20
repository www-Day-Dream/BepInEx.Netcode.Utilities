using BepInEx.Netcode.Utilities.Resources;

namespace BepInEx.Netcode.Utilities
{
    internal static class TextHandler
    {
        public struct Logs
        {
            public struct Error
            {
                public static string TypeAlreadyPatchedByNgo(string pluginId, string typeName) =>
                    string.Format(Messages.ERROR_TypeAlreadyPatchedByNGO, pluginId, typeName);
            }
        }
    }
}