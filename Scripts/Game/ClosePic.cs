using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePic : MonoBehaviour {

    public GameObject pic;
    void Close(int value)
    {
        pic.SetActive(false);
    }
}
