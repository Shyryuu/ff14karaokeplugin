namespace DalamudPluginProjectTemplate.Controller.Event
{
    public class LyricsUpdatedEventArgs
    {
        public double Delta { get; }

        public LyricsUpdatedEventArgs(double delta)
        {
            this.Delta = delta;
        }
    }
}