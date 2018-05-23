using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Check_Button : MonoBehaviour {

    public Animator anim;

    public Slider slide;

	void Update () {

        if (slide.value < slide.maxValue)
        {
            anim.SetBool("Up", false);
        }
        if (slide.value == slide.maxValue)
        {            
            anim.SetBool("Up", true);
        }
	}
}
