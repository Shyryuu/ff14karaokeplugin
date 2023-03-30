namespace DalamudPluginProjectTemplate.Controller.Event
{
    public class LyricsUpdatedEventArgs
    {
        public LyricsUpdatedEventArgs(double delta)
        {
            Delta = delta;
        }

        public double Delta { get; }
    }
}