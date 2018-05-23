using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    public Text text_load;
    public Slider Slide;
    public int procent;
    public string name_level;
    AsyncOperation async;
    public AudioSource audioSource;

    void Start()
    {
        StartCoroutine("LaunchLevel");

        if (PlayerPrefs.HasKey("SoundValue"))
        {
            audioSource.volume = PlayerPrefs.GetFloat("SoundValue");
        }
        else
        {
            PlayerPrefs.SetFloat("SoundValue", 0.5f);
            audioSource.volume = PlayerPrefs.GetFloat("SoundValue");
        }
    }

    private void Update()
    {
        float Load = async.progress * 100;
        procent = Mathf.CeilToInt(Load);
        text_load.text = "Загрузка завершена на : " + procent + " %";
        Slide.value = Load;
        if (Slide.value == Slide.maxValue)
            async.allowSceneActivation = true;
    }

    IEnumerator LaunchLevel()
    {
        async = SceneManager.LoadSceneAsync(name_level);
        yield return true;
    }
}