using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Load_Scene_Game : MonoBehaviour
{
    public string nameLevel;
    public int Max_Value = 100;
    public Slider Slide;
    public Text text, text2;
    float Level;
    AsyncOperation async;

    public AudioSource audioSource;
    void Start()
    {
        audioSource.volume = PlayerPrefs.GetFloat("SoundValue");
        text.text = Level + "%";
        Slide.value = Level;
    }
    void Update()
    {
        if (async == null)
            StartCoroutine(LaunchLevel());
        Slide.maxValue = Max_Value;
        Level = async.progress * 100;
        text.text = Level + "%";
        Slide.value = Level;
        if (Slide.value >= Slide.maxValue)
            async.allowSceneActivation = true;
        if (Level < 25)
        {
            text2.text = "...Загрузка профиля";
        }
        if (Level > 25 & Level < 50)
        {
            text2.text = "...Поиск ретрансляторов";
        }
        if (Level > 50 & Level < 60)
        {
            text2.text = "...Ингрардное шифрование данных";
        }
        if (Level > 60 & Level < 70)
        {
            text2.text = "...Подключение основных массивов";
        }
        if (Level > 70 & Level < 90)
        {
            text2.text = "...Попытка подключения";
        }
        if (Level > 90 & Level < 100)
        {
            text2.text = "...Соединение";
        }
    }
    IEnumerator LaunchLevel()
    {
        async = SceneManager.LoadSceneAsync(nameLevel);
        yield return true;
    }
}