using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gallery : MonoBehaviour {

    [Header("Панель меню")]
    public GameObject MenuObject;

    [Header("Основа скрипта")]

    public GameObject[] buttons, fullButtons, decor;

    public void Button_Close()
    {
        for(int i = 0; i < buttons.Length;i++)
        {
            buttons[i].SetActive(false);
            fullButtons[i].SetActive(false);
        }
    }

    public void Button_Open()
    {
        for(int i = 0;i < PlayerPrefs.GetInt("GalleryProgress");i++)
        {
            buttons[i].SetActive(true);
        }
        foreach(GameObject value in decor)
        {
            value.SetActive(true);
        }
    }
}
