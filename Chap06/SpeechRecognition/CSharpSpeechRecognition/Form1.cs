using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpSpeechRecognition
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string SpeechRegion = "eastus";
        string SpeechKey = "82680a740c4c4dfc8bab9a876e5f2386";

        private async Task<string> TextFromMic(SpeechConfig speechConfig)
        {
            using (AudioConfig audioConfig = AudioConfig.FromDefaultMicrophoneInput())
            {
                using (SpeechRecognizer recognizer = new SpeechRecognizer(speechConfig, audioConfig))
                {
                    Console.WriteLine("Speak into your microphone.");
                    var result = await recognizer.RecognizeOnceAsync();
                    //Console.WriteLine($"RECOGNIZED: Text={result.Text}");
                    return result.Text;
                }
            }                
        }

        private async Task<string> TextFromFile(SpeechConfig speechConfig, string Filename)
        {
            using (AudioConfig audioConfig = AudioConfig.FromWavFileInput(Filename))
            {
                using (SpeechRecognizer recognizer = new SpeechRecognizer(speechConfig, audioConfig))
                {
                    var result = await recognizer.RecognizeOnceAsync();
                    //Console.WriteLine($"RECOGNIZED: Text={result.Text}");
                    return result.Text;
                }                    
            }                
        }

        async Task SpeechFromText(SpeechConfig speechConfig, string Text)
        {
            using (AudioConfig audioConfig = AudioConfig.FromWavFileOutput("output.wav"))
            {
                using (var synthesizer = new SpeechSynthesizer(speechConfig, audioConfig))
                {
                    await synthesizer.SpeakTextAsync(Text);
                }
            }
        }
        private async void btnSpeech2TextMic_Click(object sender, EventArgs e)
        {
            SpeechConfig speechConfig = SpeechConfig.FromSubscription(SpeechKey, SpeechRegion);
            Console.WriteLine(await TextFromMic(speechConfig));
        }

        private async void btnSpeech2TextFile_Click(object sender, EventArgs e)
        {
            SpeechConfig speechConfig = SpeechConfig.FromSubscription(SpeechKey, SpeechRegion);
            Console.WriteLine(await TextFromFile(speechConfig, @"Audios\Voice1.wav"));
        }

        private async void btnDetectLanguage_Click(object sender, EventArgs e)
        {
            Console.WriteLine(await LanguageHelper.DetectLanguage("Hello"));
        }

        private async void btnTranslate_Click(object sender, EventArgs e)
        {
            Console.WriteLine(await LanguageHelper.TranslateText("How are you doing?", "zh"));
        }

        private async void btnText2Speech_Click(object sender, EventArgs e)
        {
            SpeechConfig config = SpeechConfig.FromSubscription(SpeechKey, SpeechRegion);
            await SpeechFromText(config, "I believe I can fly");
        }

        private async void btnSpeech2Speech_Click(object sender, EventArgs e)
        {
            SpeechConfig speechConfig = SpeechConfig.FromSubscription(SpeechKey, SpeechRegion);
            string OriginalText = await TextFromFile(speechConfig, @"Audios\Voice1.wav");

            string TranslatedText = await LanguageHelper.TranslateText(OriginalText, "ja");

            SpeechConfig config = SpeechConfig.FromSubscription(SpeechKey, SpeechRegion);
            config.SpeechSynthesisLanguage = "ja-jp";
            await SpeechFromText(config, TranslatedText);
        }
    }
}
