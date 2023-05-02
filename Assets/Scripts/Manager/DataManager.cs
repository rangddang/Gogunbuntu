using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class DataManager : MonoBehaviour
{
	static DataManager instance;

    public static DataManager Instance
    {
        get
        {
            return instance;
        }
    }
    private void Awake()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
	}

    public int Score = 0;
    public int Stage = 0;
    public bool isDead = false;
    public bool isEnd = false;

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	static void FirstLoad()
	{
		Application.targetFrameRate = 70;
		QualitySettings.vSyncCount = 0;

		if (!PlayerPrefs.HasKey("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", 0);
		}
		if (!PlayerPrefs.HasKey("BGMScale"))
		{
			PlayerPrefs.SetFloat("BGMScale", 1f);
		}
		if (!PlayerPrefs.HasKey("SFXScale"))
		{
			PlayerPrefs.SetFloat("SFXScale", 1f);
		}
	}
}
