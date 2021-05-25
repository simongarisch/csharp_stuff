// doesn't appear to be supported in .NET core yet
// Go to References -> Add Reference... -> Assemblies / Framework -> System.Speech
using System;
using System.Speech.Synthesis;

class Program
{
    public static void Main()
    {
        var synthesizer = new SpeechSynthesizer();
        synthesizer.SetOutputToDefaultAudioDevice();
        synthesizer.Speak("The quick brown fox jumped over the lazy dog");
    }
}
