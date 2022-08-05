using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using Microsoft.CognitiveServices.Speech.Speaker;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpSpeakerRecognition
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public async Task VerificationEnroll(SpeechConfig config, Dictionary<string, string> profileMapping)
        {
            using (VoiceProfileClient client = new VoiceProfileClient(config))
            {
                using (VoiceProfile profile = await client.CreateProfileAsync(VoiceProfileType.TextDependentVerification, "en-us"))
                {
                    //using (AudioConfig audioInput = AudioConfig.FromWavFileInput(@"Audios\Voice1-Mono.wav"))
                    using (AudioConfig audioInput = AudioConfig.FromDefaultMicrophoneInput())
                    {
                        Console.WriteLine($"Enrolling profile id {profile.Id}.");
                        // give the profile a human-readable display name
                        profileMapping.Add(profile.Id, "Tester");

                        VoiceProfileEnrollmentResult result = null;
                        while (result is null || result.RemainingEnrollmentsCount > 0)
                        {
                            Console.WriteLine("Speak the passphrase, \"My voice is my passport, verify me.\"");
                            result = await client.EnrollProfileAsync(profile, audioInput);
                            Console.WriteLine($"Remaining enrollments needed: {result.RemainingEnrollmentsCount}");
                            Console.WriteLine("");
                        }

                        if (result.Reason == ResultReason.EnrolledVoiceProfile)
                        {
                            await SpeakerVerify(config, profile, profileMapping);
                        }
                        else if (result.Reason == ResultReason.Canceled)
                        {
                            var cancellation = VoiceProfileEnrollmentCancellationDetails.FromResult(result);
                            Console.WriteLine($"CANCELED {profile.Id}: ErrorCode={cancellation.ErrorCode} ErrorDetails={cancellation.ErrorDetails}");
                        }
                    }
                }
            }
        }

        public async Task SpeakerVerify(SpeechConfig config, VoiceProfile profile, Dictionary<string, string> profileMapping)
        {
            //var speakerRecognizer = new SpeakerRecognizer(config, AudioConfig.FromWavFileInput(@"Audios\WelcomeToTaiwan-Mono.wav"));
            var speakerRecognizer = new SpeakerRecognizer(config, AudioConfig.FromDefaultMicrophoneInput());
            var model = SpeakerVerificationModel.FromProfile(profile);

            Console.WriteLine("Speak the passphrase to verify: \"My voice is my passport, please verify me.\"");
            var result = await speakerRecognizer.RecognizeOnceAsync(model);
            Console.WriteLine($"Verified voice profile for speaker {profileMapping[result.ProfileId]}, score is {result.Score}");
        }

        private async void btnSpeakerVerification_Click(object sender, EventArgs e)
        {
            string SpeechRegion = "westus";
            string SpeechKey = "a7510db74a424227b5b86370fa3b7364";

            SpeechConfig config = SpeechConfig.FromSubscription(SpeechKey, SpeechRegion);

            // persist profileMapping if you want to store a record of who the profile is
            var profileMapping = new Dictionary<string, string>();
            await VerificationEnroll(config, profileMapping);

        }
    }
}
