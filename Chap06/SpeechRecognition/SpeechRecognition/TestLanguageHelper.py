import LanguageHelper.DetectLanguage as DetectLang
import LanguageHelper.Translate as Translate

print(DetectLang.DetectLanguage("Hello"))
print(Translate.TranslateText("Hello", "ja-jp"))
