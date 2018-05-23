using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Settings : MonoBehaviour {

    [Header("Звук")]
    public AudioClip clip_1;
    public AudioClip clip_2;
    public AudioSource A_Source;
    public AudioSource audioSource;

    [Header("Прочее")]
    public Slider slider;
    public Animator animator;
    public bool close = true;

    public void Button_Click()
    {
        A_Source.clip = clip_1;
        A_Source.Play();
    }

    public void Button_Click_2()
    {
        A_Source.clip = clip_1;
        A_Source.Play();
    }

    private void Start()
    {
        audioSource.gameObject.SetActive(true);

        slider.value = PlayerPrefs.GetFloat("SoundValue");
    }
    void Update () {
        audioSource.volume = slider.value;

    }
    
    public void OpenAndCloseSettingWindow()
    {
        if (close == true)
        {
            animator.SetTrigger("Open");
            close = false;
        }
        else if (close == false)
        {
            animator.SetTrigger("Close");
            close = true;
        }
    }
}
