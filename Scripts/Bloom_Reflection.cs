using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
    public class Bloom_Reflection : MonoBehaviour {

        public bool Active = true;

        void Awake() {
            int i = PlayerPrefs.GetInt("Bloom_En");
            if (Active)
            {
                if (i == 1)
                {
                    FindObjectOfType<BloomOptimized>().enabled = true;
                }
                else
                {
                    FindObjectOfType<BloomOptimized>().enabled = false;
                }
            }
        }
    }
}
