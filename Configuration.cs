using Dalamud.Configuration;
using Dalamud.Plugin;

namespace DalamudPluginProjectTemplate
{
    public class Configuration : IPluginConfiguration
    {
        private readonly DalamudPluginInterface pluginInterface;

        public Configuration(DalamudPluginInterface pi)
        {
            pluginInterface = pi;
        }

        #region Saved configuration values

        public string CoolText { get; set; }

        #endregion

        int IPluginConfiguration.Version { get; set; }

        public void Save()
        {
            pluginInterface.SavePluginConfig(this);
        }
    }
}