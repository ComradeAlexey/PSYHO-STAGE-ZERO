using System.Collections;
using UnityEngine.Audio;
using UnityEngine;

public class Random_Music : MonoBehaviour
{

    public AudioClip[] clip;
    public AudioSource AS;

    int rand;

    void Start()
    {

        rand = Random.Range(0, 3);

        AS.clip = clip[rand];
        AS.Play();

    }

    private void Update()
    {
        
    }
}
