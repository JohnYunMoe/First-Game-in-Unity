using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    AudioSource bkgMusic;
    AudioSource jumpMusic;
    AudioSource coinMusic;
    AudioSource gameover;

    // Start is called before the first frame update
    void Start()
    {
        bkgMusic = gameObject.GetComponent<AudioSource>();
        bkgMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
