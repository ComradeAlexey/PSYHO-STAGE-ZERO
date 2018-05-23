using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
    public class Fisheye_Reactions : MonoBehaviour
    {
        public bool Active = true;
        void Awake()
        {
            int k = PlayerPrefs.GetInt("Fisheye_En");
            if (Active)
            {
                if (k == 1)
                {
                    FindObjectOfType<VignetteAndChromaticAberration>().chromaticAberration = 8f;
                    FindObjectOfType<Fisheye>().enabled = true;
                }
                else
                {
                    FindObjectOfType<VignetteAndChromaticAberration>().chromaticAberration = 0f;
                    FindObjectOfType<Fisheye>().enabled = false;
                }
            }
        }
    }
}
