using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour
{
    [SerializeField] private UIController ui;
    [SerializeField] private AudioSource backMusic;
    [SerializeField] private CatStatue catStatue;
    [SerializeField] private MapMove map;

    private void Start()
    {
		StartSettings();
    }

    private void Update()
    {
		if (DataManager.Instance.isDead)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameStart();
            }
        }
    }

    public void GameStart()
    {
        StartSettings();
		SceneManager.LoadScene("Game");
	}

    public void GameOver()
    {
        DataManager.Instance.isDead = true;
		map.StopStage();
		ui.GameOver();
        backMusic.Stop();
        catStatue.SetAnimation(CatAnimation.Laugh);
    }

    private void StartSettings()
    {
		DataManager.Instance.isDead = false;
		DataManager.Instance.Score = 0;
		DataManager.Instance.Stage = 0;
	}
}
