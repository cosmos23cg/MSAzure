import azure.cognitiveservices.speech as speechsdk
from azure.cognitiveservices.speech import AudioDataStream, SpeechConfig, SpeechSynthesizer, SpeechSynthesisOutputFormat

speech_key = "6a09108ed36540ee8c308cb06b13fefe"
service_region = "southcentralus"

def translate_speech_to_speech():
    """performs one-shot speech translation from input from an audio file"""
    # <TranslationOnceWithFile>
    # set up translation parameters: source language and target languages
    translation_config = speechsdk.translation.SpeechTranslationConfig(
        subscription=speech_key, region=service_region,
        speech_recognition_language='en-US',
        target_languages=('ja'))
    audio_config = speechsdk.audio.AudioConfig(filename=r"Datasets\Voice1.wav")

    # Creates a translation recognizer using and audio file as input.
    recognizer = speechsdk.translation.TranslationRecognizer(
        translation_config=translation_config, audio_config=audio_config)

    # Starts translation, and returns after a single utterance is recognized. The end of a
    # single utterance is determined by listening for silence at the end or until a maximum of 15
    # seconds of audio is processed. The task returns the recognition text as result.
    # Note: Since recognize_once() returns only a single utterance, it is suitable only for single
    # shot recognition like command or query.
    # For long-running multi-utterance recognition, use start_continuous_recognition() instead.
    result = recognizer.recognize_once()

    # Check the result
    if result.reason == speechsdk.ResultReason.RecognizedSpeech:
        print("Recognized: {}".format(result.text))
        ######Translate to Japanese#######
        import LanguageHelper.Translate as tran
        translateText=tran.TranslateText(result.text, "ja")
        ######End Translate to Japanese#######
        speech_config = SpeechConfig(subscription=speech_key, region=service_region)
        #支援合成的語言清單
        #https://docs.microsoft.com/zh-tw/azure/cognitive-services/speech-service/language-support#text-to-speech
        speech_config.speech_synthesis_language="ja-jp"

        synthesizer = SpeechSynthesizer(speech_config=speech_config, audio_config=None)
        result = synthesizer.speak_text_async(translateText).get()
        stream = AudioDataStream(result)
        stream.save_to_wav_file("output.wav")

    elif result.reason == speechsdk.ResultReason.NoMatch:
        print("No speech could be recognized: {}".format(result.no_match_details))
    elif result.reason == speechsdk.ResultReason.Canceled:
        print("Translation canceled: {}".format(result.cancellation_details.reason))
        if result.cancellation_details.reason == speechsdk.CancellationReason.Error:
            print("Error details: {}".format(result.cancellation_details.error_details))

translate_speech_to_speech()
