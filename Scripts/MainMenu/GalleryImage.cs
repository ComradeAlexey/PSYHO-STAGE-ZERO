using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalleryImage : MonoBehaviour {
    public GameObject[] images, fullImages, cells;
    public GameObject thisImage;
    public void OnFullImage()
    {
        foreach (GameObject value in images)
        {
            value.SetActive(false);
        }
        thisImage.SetActive(true);
    }

    public void OffFullImage()
    {
        for (int i = 0; i < PlayerPrefs.GetInt("GalleryProgress"); i++)
        {
            images[i].SetActive(true);
        }
        foreach (GameObject value in fullImages)
        {
            value.SetActive(false);
        }

        foreach (GameObject value in cells)
        {
            value.SetActive(true);
        }
    }
}
