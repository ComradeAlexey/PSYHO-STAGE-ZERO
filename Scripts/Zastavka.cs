using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Zastavka : MonoBehaviour {

    public bool Load_Scene;
    int Nice;
    public float Timer, MaxTimer;

	void Awake ()
    {
        //Nice = PlayerPrefs.GetInt("Zastavka");
        //if(Nice == 1)
        //{
        //    SceneManager.LoadScene("Load_Menu");
        //}
	}
	
	void Update ()
    {
        Timer += Time.deltaTime;
        if (Timer >= MaxTimer)
            SceneManager.LoadScene("Load_Menu");
        //if (Load_Scene)
        //{
        //    SceneManager.LoadScene("Load_Menu");
        //    PlayerPrefs.SetInt("Zastavka", 1);
        //}
    }

    public void Button_Skip()
    {
        SceneManager.LoadScene("Load_Menu");
    }
}
