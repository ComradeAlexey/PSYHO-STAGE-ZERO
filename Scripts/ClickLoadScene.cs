using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickLoadScene : MonoBehaviour {

    public string nameLevel;
    public Load_Scene_Game lSG;
    public GameObject loadScreen, menu;
    public void EditLoadLevel()
    {
        lSG.nameLevel = nameLevel;
        loadScreen.SetActive(true);
        menu.SetActive(false);
    }
}
