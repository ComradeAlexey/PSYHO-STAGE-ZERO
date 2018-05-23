using UnityEngine;
using UnityEngine.UI;
public class Menu : MonoBehaviour {
    public AudioReverbFilter Aud_Filter;

    public Color32 Color_Open, Color_Close;
    public Image Img, Img_2;

    public GameObject Panel_Settings, Panel_Text;
    public bool open = false;

    public Image img_Dec;

    public void Click()
    {
        if (open == false)
        {
            img_Dec.enabled = false;

            Aud_Filter.reverbPreset = AudioReverbPreset.Underwater;

            Img.color = Color_Open;
            Img_2.color = Color_Open;

            Panel_Settings.SetActive(true);
            Panel_Text.SetActive(false);

            open = true;

        }
        else if (open == true)
        {
            img_Dec.enabled = true;

            Aud_Filter.reverbPreset = AudioReverbPreset.Generic;

            Img.color = Color_Close;
            Img_2.color = Color_Close;

            Panel_Text.SetActive(true);
            Panel_Settings.SetActive(false);

            open = false;
        }
    }
}
