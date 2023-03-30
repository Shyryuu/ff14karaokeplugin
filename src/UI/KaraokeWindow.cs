using System.Numerics;
using Dalamud.Interface.Windowing;
using DalamudPluginProjectTemplate.Controller.Event;
using ImGuiNET;

namespace DalamudPluginProjectTemplate.UI
{
    public class KaraokeWindow : Window
    {
        public KaraokeWindow() : base("TemplateWindow", ImGuiWindowFlags.NoTitleBar)
        {
            IsOpen = true;
            Size = new Vector2(810, 520);
            SizeCondition = ImGuiCond.FirstUseEver;
            BgAlpha = 0.3f;
            ShowCloseButton = false;
        }

        private double TotalTime { get; set; }

        public override void Draw()
        {
            var windowSize = ImGui.GetWindowSize();
            var textSize = ImGui.CalcTextSize("Karaoke Plugin shall be born");

            ImGui.SetCursorPos((windowSize - textSize) * 0.5f);
            ImGui.Text("Karaoke Plugin shall be born " + TotalTime);
        }

        public void OnLyricsUpdated(LyricsUpdatedEventArgs args)
        {
            TotalTime += args.Delta;
        }
    }
}