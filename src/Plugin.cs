using System;
using Dalamud.Game;
using Dalamud.Game.ClientState;
using Dalamud.Game.Command;
using Dalamud.Game.Gui;
using Dalamud.Interface.Windowing;
using Dalamud.Logging;
using Dalamud.Plugin;
using DalamudPluginProjectTemplate.Command;
using DalamudPluginProjectTemplate.Controller;
using DalamudPluginProjectTemplate.UI;

namespace DalamudPluginProjectTemplate
{
    public class Plugin : IDalamudPlugin
    {
        private readonly ChatGui chat;
        private readonly ClientState clientState;

        private readonly PluginCommandManager<Plugin> commandManager;
        private readonly Configuration config;
        private readonly DalamudPluginInterface pluginInterface;
        private readonly WindowSystem windowSystem;

        public Plugin(
            DalamudPluginInterface pi,
            CommandManager commands,
            ChatGui chat,
            ClientState clientState,
            Framework framework
        )
        {
            pluginInterface = pi;
            this.chat = chat;
            this.clientState = clientState;

            // Get or create a configuration object
            config = (Configuration)pluginInterface.GetPluginConfig()
                     ?? pluginInterface.Create<Configuration>();

            // Initialize the UI
            windowSystem = new WindowSystem(typeof(Plugin).AssemblyQualifiedName);

            var window = pluginInterface.Create<KaraokeWindow>();
            if (window is null) return;

            windowSystem.AddWindow(window);


            pluginInterface.UiBuilder.Draw += windowSystem.Draw;

            // Load all of our commands
            commandManager = new PluginCommandManager<Plugin>(this, commands);

            // Load controller
            var controller = pluginInterface.Create<KaraokeController>();
            if (controller is null) return;

            framework.Update += controller.OnFrameworkUpdate;
            controller.LyricsUpdate += window.OnLyricsUpdated;
        }

        public string Name => "Your Plugin's Display Name";

        [Command("/example1")]
        [HelpMessage("Example help message.")]
        public void ExampleCommand1(string command, string args)
        {
            // You may want to assign these references to private variables for convenience.
            // Keep in mind that the local player does not exist until after logging in.
            var world = clientState.LocalPlayer?.CurrentWorld.GameData;
            chat.Print($"Hello, {world?.Name}!");
            PluginLog.Log("Message sent successfully.");
        }

        #region IDisposable Support

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;

            commandManager.Dispose();

            pluginInterface.SavePluginConfig(config);

            pluginInterface.UiBuilder.Draw -= windowSystem.Draw;
            windowSystem.RemoveAllWindows();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}