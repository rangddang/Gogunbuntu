using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	public static SoundManager Instance;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

	public Transform soundGroup;

	public void SFXPlay(string sfxName, AudioClip clip)
    {
        GameObject go = new GameObject(sfxName + "Sound");
        go.transform.parent = soundGroup;
        AudioSource audioSource = go.AddComponent<AudioSource>();
        audioSource.volume = PlayerPrefs.GetFloat("SFXScale");
        audioSource.clip = clip;
        audioSource.Play();

        Destroy(go, clip.length);
    }
}
