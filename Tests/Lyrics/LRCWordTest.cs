using DalamudPluginProjectTemplate.Lyrics;

namespace Tests.Lyrics;

public class LRCWordTest
{
    [Test]
    public void TestItCanValidateSuccessfully()
    {
        const string correctLyrics = "<00:23.20> One brings shadow ";
        
        Assert.IsTrue(LRCWord.IsValid(correctLyrics));
    }

    [Test]
    public void TestItDoesNotValidateInvalidString()
    {
        const string incorrectLyrics = "<0:2.5> One brings shadow <vfsadv>";
        
        Assert.IsFalse(LRCWord.IsValid(incorrectLyrics));
    }

    [Test]
    public void TestItCanLoadCorrectLyrics()
    {
        const string correctLyrics = "<00:23.20> One brings shadow ";
        
        LRCWord word = LRCWord.FromString(correctLyrics);
        
        Assert.That(word.Timestamp, Is.EqualTo(23.20).Within(0.01));
        Assert.That(word.Lyric, Is.EqualTo("One brings shadow"));
    }
}