using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Button_Rections : MonoBehaviour {

    public AudioClip clip;

    private void OnMouseEnter()
    {
        GameObject.FindGameObjectWithTag("Button_Audio").GetComponent<AudioSource>().clip = clip;
        GameObject.FindGameObjectWithTag("Button_Audio").GetComponent<AudioSource>().Play();
    }
}
