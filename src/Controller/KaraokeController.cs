using Dalamud.Game;
using DalamudPluginProjectTemplate.Controller.Event;

namespace DalamudPluginProjectTemplate.Controller
{
    public class KaraokeController
    {
        public delegate void OnLyricsUpdateDelegate(LyricsUpdatedEventArgs args);

        public event OnLyricsUpdateDelegate LyricsUpdate;

        public void OnFrameworkUpdate(Framework framework)
        {
            this.LyricsUpdate?.Invoke(
                new LyricsUpdatedEventArgs(framework.UpdateDelta.TotalSeconds)
            );
        }
    }
}