using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour {

    public GameObject menu;
    public GameObject loadScreen;

    void Awake()
    {
        menu.SetActive(true);
        loadScreen.SetActive(false);
    }
}
