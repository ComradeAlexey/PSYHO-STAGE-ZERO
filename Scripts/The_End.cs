using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class The_End : MonoBehaviour {

    public string Name_Level;

    public void TheEnd()
    {
        SceneManager.LoadScene(Name_Level);
    }

    public void Group_game()
    {
        Application.OpenURL("https://vk.com/gamepsyho");
    }
}
