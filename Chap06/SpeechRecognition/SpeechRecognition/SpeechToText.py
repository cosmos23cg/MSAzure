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
    #if result.reason == speechsdk.ResultReason.TranslatedSpeech:
    #    print("""Recognized: {}        
    #    Japanese translation: {}""".format(
    #        result.text, result.translations['ja']))
    if result.reason == speechsdk.ResultReason.RecognizedSpeech:
        print("Recognized: {}".format(result.text))
    elif result.reason == speechsdk.ResultReason.NoMatch:
        print("No speech could be recognized: {}".format(result.no_match_details))
    elif result.reason == speechsdk.ResultReason.Canceled:
        print("Translation canceled: {}".format(result.cancellation_details.reason))
        if result.cancellation_details.reason == speechsdk.CancellationReason.Error:
            print("Error details: {}".format(result.cancellation_details.error_details))

#def translate_speech_to_speech():

#    # Creates an instance of a speech translation config with specified subscription key and service region.
#    # Replace with your own subscription key and region identifier from here: https://aka.ms/speech/sdkregion
#    translation_config = speechsdk.translation.SpeechTranslationConfig(subscription=speech_key, region=service_region)

#    # Sets source and target languages.
#    # Replace with the languages of your choice, from list found here: https://aka.ms/speech/sttt-languages
#    fromLanguage = 'en'
#    toLanguage = 'ja'

#    translation_config.speech_recognition_language = fromLanguage
#    translation_config.add_target_language(toLanguage)

#    audio_config = speechsdk.audio.AudioConfig(filename=r"Datasets\Voice1.wav")

#    # Sets the synthesis output voice name.
#    # Replace with the languages of your choice, from list found here: https://aka.ms/speech/tts-languages
#    translation_config.voice_name = "ja-JP-NanamiNeural"

#    # Creates a translation recognizer using and audio file as input.
#    recognizer = speechsdk.translation.TranslationRecognizer(translation_config=translation_config, )

#    # Prepare to handle the synthesized audio data.
#    def synthesis_callback(evt):
#        size = len(evt.result.audio)
#        print('AUDIO SYNTHESIZED: {} byte(s) {}'.format(size, '(COMPLETED)' if size == 0 else ''))

#    recognizer.synthesizing.connect(synthesis_callback)

#    # Starts translation, and returns after a single utterance is recognized. The end of a
#    # single utterance is determined by listening for silence at the end or until a maximum of 15
#    # seconds of audio is processed. It returns the recognized text as well as the translation.
#    # Note: Since recognize_once() returns only a single utterance, it is suitable only for single
#    # shot recognition like command or query.
#    # For long-running multi-utterance recognition, use start_continuous_recognition() instead.
#    result = recognizer.recognize_once()

#    # Check the result
#    if result.reason == speechsdk.ResultReason.TranslatedSpeech:
#        print("RECOGNIZED '{}': {}".format(fromLanguage, result.text))
#        print("TRANSLATED into {}: {}".format(toLanguage, result.translations['de']))
#    elif result.reason == speechsdk.ResultReason.RecognizedSpeech:
#        print("RECOGNIZED: {} (text could not be translated)".format(result.text))
#    elif result.reason == speechsdk.ResultReason.NoMatch:
#        print("NOMATCH: Speech could not be recognized: {}".format(result.no_match_details))
#    elif result.reason == speechsdk.ResultReason.Canceled:
#        print("CANCELED: Reason={}".format(result.cancellation_details.reason))
#        if result.cancellation_details.reason == speechsdk.CancellationReason.Error:
#            print("CANCELED: ErrorDetails={}".format(result.cancellation_details.error_details))

translate_speech_to_speech()
