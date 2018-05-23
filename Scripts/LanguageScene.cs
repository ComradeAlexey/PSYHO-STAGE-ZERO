using UnityEngine;
using System.IO;
public class LanguageScene : MonoBehaviour {
    string pathJson;
    string textJson;
    public Language language = new Language();
    //private void Awake()
    //{
    //    languageLoad();
    //}
    ////public static void languageLoad()
    ////{
    ////    pathJson = Application.streamingAssetsPath + "/Language/" + PlayerPrefs.GetString("Language") + ".json";
    ////    textJson = File.ReadAllText(pathJson);
    ////    language = JsonUtility.FromJson<Language>(textJson);
    ////}
    //public void languageLoad()
    //{
    //    pathJson = Application.streamingAssetsPath + "/Language/" + "ru_RU"/*PlayerPrefs.GetString("Language")*/ + ".json";
    //    textJson = File.ReadAllText(pathJson);
    //    language = JsonUtility.FromJson<Language>(textJson);
    //}
    //public void DefaultLanguage()
    //{
    //    if (!PlayerPrefs.HasKey("Language"))
    //    {
    //        if (Application.systemLanguage == SystemLanguage.Russian)
    //        {
    //            PlayerPrefs.SetString("Language", "ru_RU");
    //            PlayerPrefs.Save();
    //        }
    //        else
    //        {
    //            PlayerPrefs.SetString("Language", "en_EN");
    //            PlayerPrefs.Save();
    //        }
    //    }
    //    languageLoad();
    //}
}
public class Language
{
    public string[] MainText = new string[42];
}
