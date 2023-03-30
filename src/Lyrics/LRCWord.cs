using System.Text.RegularExpressions;

namespace DalamudPluginProjectTemplate.Lyrics
{
    public record LRCWord(double Timestamp, string Lyric)
    {
        public const string REGEX_EXPRESSION =
            @"<(?<minutes>[0-9]{2}):(?<seconds>[0-9]{2})\.(?<centiseconds>[0-9]{2})>(?<lyric>.+)";

        public static LRCWord FromString(string input)
        {
            var rx = new Regex(
                REGEX_EXPRESSION,
                RegexOptions.Compiled | RegexOptions.ExplicitCapture |
                RegexOptions.Singleline | RegexOptions.NonBacktracking
            );
            var match = rx.Match(input);

            return new LRCWord(
                double.Parse(match.Groups["minutes"].Value) * 60.0 +
                double.Parse(match.Groups["seconds"].Value) +
                double.Parse(match.Groups["centiseconds"].Value) * 0.01,
                match.Groups["lyric"].Value.Trim()
            );
        }

        public static bool IsValid(string input)
        {
            var rx = new Regex(
                REGEX_EXPRESSION,
                RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.NonBacktracking
            );
            return rx.IsMatch(input);
        }
    }
}