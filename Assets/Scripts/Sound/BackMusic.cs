using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackMusic : MonoBehaviour
{
    private AudioSource backMusic;

    private void Awake()
    {
        backMusic = GetComponent<AudioSource>();
    }

    private void Start()
    {
        SetSound();
        backMusic.Play();
    }

    public void SetSound()
    {
        backMusic.volume = PlayerPrefs.GetFloat("BGMScale");
    }
}
