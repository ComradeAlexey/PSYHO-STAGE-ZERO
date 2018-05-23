using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace UnityStandardAssets.ImageEffects
{
    public class MainMenu : MonoBehaviour
    {

        public bool test;

        public GameObject menu;
        public GameObject loadScreen;

        public int i, k;
        [HideInInspector]
        public BloomOptimized Bloom_;
        [HideInInspector]
        public Fisheye Fish_eye;
        [HideInInspector]
        public VignetteAndChromaticAberration VACA;

        public Toggle Bloom_enabled, Fisheye_enabled,Instant_Enabled;
        [Space(10)]

        public AudioClip clip;
        public AudioClip clip_2, clip_3;

        public GameObject Panel_Menu, Panel_Play, Panel_Gallery;
        public AudioReverbFilter Audio_Filter;

        public Slider speedPrintingSlider;
        public Slider speedDeletingSlider;
        public GameObject windowSettings;
        [Header("Кнопка загрузки игры")]
        public GameObject Cont_Game;
        [HideInInspector]
        public bool InstantPrintingEnabled;

        public Gallery gallery;

        public Slider soundValue;
        public AudioSource[] audioSources;


        private void Awake()
        {
            Bloom_ = FindObjectOfType<BloomOptimized>();
            Fish_eye = FindObjectOfType<Fisheye>();
            VACA = FindObjectOfType<VignetteAndChromaticAberration>();
            //if(test)
            //    PlayerPrefs.SetInt("GalleryProgress", 0);
            //print(PlayerPrefs.GetInt("GalleryProgress"));
        }
        private void Update()
        {
            foreach (AudioSource value in audioSources)
            {
                value.volume = soundValue.value;
            }
        }
        private void Start()
        {
            if(PlayerPrefs.HasKey("SoundValue"))
            {
                soundValue.value = PlayerPrefs.GetFloat("SoundValue");
                foreach (AudioSource value in audioSources)
                {
                    value.volume = soundValue.value;
                }
            }
            else
            {
                PlayerPrefs.SetFloat("SoundValue", 0.5f);
                soundValue.value = PlayerPrefs.GetFloat("SoundValue");
                foreach (AudioSource value in audioSources)
                {
                    value.volume = soundValue.value;
                }
            }


            if (PlayerPrefs.HasKey("Fisheye_En")) k = PlayerPrefs.GetInt("Fisheye_En");
            else k = 1;
            if (PlayerPrefs.HasKey("Bloom_En")) i = PlayerPrefs.GetInt("Bloom_En");
            else i = 1;
            if (PlayerPrefs.HasKey("ValueSliderSpeedPrinting")) speedPrintingSlider.value = PlayerPrefs.GetInt("ValueSliderSpeedPrinting");
            else
            {
                speedPrintingSlider.value = 1;
                PlayerPrefs.SetInt("ValueSliderSpeedPrinting", (int)speedDeletingSlider.value);
            }

            if (PlayerPrefs.HasKey("ValueSliderSpeedDeleting")) speedDeletingSlider.value = PlayerPrefs.GetInt("ValueSliderSpeedDeleting");
            else
            {
                speedDeletingSlider.value = 1;
                PlayerPrefs.SetInt("ValueSliderSpeedDeleting", (int)speedDeletingSlider.value);
            }
            if (k == 1)
            {
                VACA.chromaticAberration = 10.40f;
                Fisheye_enabled.isOn = true;
            }
            else
            {
                VACA.chromaticAberration = 0f;
                Fisheye_enabled.isOn = false;
            }

            if (i == 1)
            {
                Bloom_enabled.isOn = true;
            }
            else
            {
                Bloom_enabled.isOn = false;
            }

            if (PlayerPrefs.HasKey("InstantPrinting"))
            {
                if (PlayerPrefs.GetInt("InstantPrinting") == 0)
                {
                    Instant_Enabled.isOn = false;
                }
                else if (PlayerPrefs.GetInt("InstantPrinting") == 1)
                {
                    Instant_Enabled.isOn = true;
                }
            }
            else if (!PlayerPrefs.HasKey("InstantPrinting"))
            {
                Instant_Enabled.isOn = false;
            }

            gallery.Button_Close();

            PlayerPrefs.Save();

        }

        public void Play()
        {
            GameObject.FindGameObjectWithTag("Canvas_Anim").GetComponent<Animator>().enabled = false;
            Panel_Menu.SetActive(false);
            Panel_Play.SetActive(true);
            Audio_Filter.reverbPreset = AudioReverbPreset.Underwater;
            if(!CheckSave())
            {
                Cont_Game.GetComponent<Button>().interactable = false;
            }
            else if (CheckSave())
            {
                Cont_Game.GetComponent<Button>().interactable = true;
            }
        }

        public void Exit_Play()
        {
            Panel_Menu.SetActive(true);
            Panel_Play.SetActive(false);
            Audio_Filter.reverbPreset = AudioReverbPreset.Generic;
        }

        public void Start_Game()
        {
            loadScreen.SetActive(true);
            menu.SetActive(false);
            PlayerPrefs.SetInt("newGame", 1);
            PlayerPrefs.Save();
        }

        public void PressedButtonLoadGame()
        {
            LoadGame();
        }

        public void LoadGame()
        {
            if (CheckSave())
            {
                loadScreen.SetActive(true);
                menu.SetActive(false);
                PlayerPrefs.SetInt("loadGame", 1);
                PlayerPrefs.SetInt("InstantPrinting", 0);
                PlayerPrefs.Save();
            }
        }


        public void Exit()
        {
            Application.Quit();
        }

        bool CheckSave()
        {
            if (!PlayerPrefs.HasKey("MainText")) return false;
            if (!PlayerPrefs.HasKey("OneAnswerText")) return false;
            if (!PlayerPrefs.HasKey("TwoAnswerText")) return false;
            if (!PlayerPrefs.HasKey("step")) return false;
            if (!PlayerPrefs.HasKey("printingMainTextFinality")) return false;
            if (!PlayerPrefs.HasKey("printingAnswerOneFinality")) return false;
            if (!PlayerPrefs.HasKey("printingAnswerTwoFinality")) return false;
            if (!PlayerPrefs.HasKey("deletingMainTextFinality")) return false;
            if (!PlayerPrefs.HasKey("deletingAnswerOneFinality")) return false;
            if (!PlayerPrefs.HasKey("deletingAnswerTwoFinality")) return false;
            if (!PlayerPrefs.HasKey("ButtonPressed")) return false;
            return true;
        }

        public void SaveSettings()
        {
            PlayerPrefs.SetInt("ValueSliderSpeedPrinting", (int)speedPrintingSlider.value);
            PlayerPrefs.SetInt("ValueSliderSpeedDeleting", (int)speedDeletingSlider.value);
            PlayerPrefs.Save();
        }
        public void SetDefaultSettings()
        {
            speedPrintingSlider.value = 1f;
            speedDeletingSlider.value = 1f;
            PlayerPrefs.SetInt("ValueSliderSpeedPrinting", (int)speedPrintingSlider.value);
            PlayerPrefs.SetInt("ValueSliderSpeedDeleting", (int)speedDeletingSlider.value);
            PlayerPrefs.Save();
        }

        public void CloseWindowSettings()
        {
            
            if (windowSettings.activeSelf)
            {
                Panel_Menu.SetActive(true);
                windowSettings.SetActive(false);
            }
            else if (!windowSettings.activeSelf)
            {
                GameObject.FindGameObjectWithTag("Canvas_Anim").GetComponent<Animator>().enabled = false;
                Panel_Menu.SetActive(false);
                windowSettings.SetActive(true);
            }
            if (Fisheye_enabled.isOn == true)
            {
                k = 1;
                VACA.chromaticAberration = 10.40f;
                Fish_eye.enabled = true;
            }
            else
            {
                k = 2;
                VACA.chromaticAberration = 0f;
                Fish_eye.enabled = false;
            }

            if (Bloom_enabled.isOn == true)
            {
                i = 1;
                Bloom_.enabled = true;
            }
            else
            {
                i = 2;
                Bloom_.enabled = false;
            }

            if (Instant_Enabled.isOn)
            {
                PlayerPrefs.SetInt("InstantPrinting", 1);
            }
            else if (!Instant_Enabled.isOn)
            {
                PlayerPrefs.SetInt("InstantPrinting", 0);
            }

            PlayerPrefs.SetInt("ValueSliderSpeedPrinting", (int)speedPrintingSlider.value);
            PlayerPrefs.SetInt("ValueSliderSpeedDeleting", (int)speedDeletingSlider.value);

            PlayerPrefs.SetFloat("SoundValue", soundValue.value);
            foreach (AudioSource value in audioSources)
            {
                value.volume = soundValue.value;
            }

            PlayerPrefs.SetInt("Fisheye_En", k);
            PlayerPrefs.SetInt("Bloom_En", i);
            PlayerPrefs.Save();
        }

        public void OpenWindowSettings()
        {
            k = PlayerPrefs.GetInt("Fisheye_En");
            i = PlayerPrefs.GetInt("Bloom_En");
            if (windowSettings.activeSelf)
            {
                Panel_Menu.SetActive(true);
                windowSettings.SetActive(false);
            }
            else if (!windowSettings.activeSelf)
            {
                GameObject.FindGameObjectWithTag("Canvas_Anim").GetComponent<Animator>().enabled = false;
                Panel_Menu.SetActive(false);
                windowSettings.SetActive(true);
            }
            if (k == 1)
                Fisheye_enabled.isOn = true;
            else if(k == 2)
                Fisheye_enabled.isOn = false;

            if (i == 1)
                Bloom_enabled.isOn = true;
            else if(i == 2)
                Bloom_enabled.isOn = false;

            speedPrintingSlider.value = PlayerPrefs.GetInt("ValueSliderSpeedPrinting");
            speedDeletingSlider.value = PlayerPrefs.GetInt("ValueSliderSpeedDeleting");
        }
        public void Button_Click()
        {
            GameObject.FindGameObjectWithTag("Button_Audio").GetComponent<AudioSource>().clip = clip;
            GameObject.FindGameObjectWithTag("Button_Audio").GetComponent<AudioSource>().Play();
        }

        public void Button_Click_2()
        {
            //GameObject.FindGameObjectWithTag("Button_Audio").GetComponent<AudioSource>().clip = clip_2;
           // GameObject.FindGameObjectWithTag("Button_Audio").GetComponent<AudioSource>().Play();
        }

        public void Button_Click_3()
        {
            GameObject.FindGameObjectWithTag("Button_Audio").GetComponent<AudioSource>().clip = clip_3;
            GameObject.FindGameObjectWithTag("Button_Audio").GetComponent<AudioSource>().Play();
        }

        public void Button_Gallery_Open()
        {
            gameObject.GetComponent<Animator>().enabled = false;
            Panel_Gallery.SetActive(true);
            Panel_Menu.SetActive(false);
            gallery.Button_Open();
        }
        public void Button_Gallery_Close()
        {
            gameObject.GetComponent<Animator>().enabled = true;
            Panel_Gallery.SetActive(false);
            Panel_Menu.SetActive(true);
            gallery.Button_Close();
        }
    }
}