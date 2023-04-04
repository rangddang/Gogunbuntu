using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour
{
    public RectTransform[] gameOverTextPos;
    public float textSpeed;
    public AudioSource backMusic;

    private void Start()
    {
		StartSettings();
    }

    private void Update()
    {
		if (DataManager.Instance.isDead)
        {
            GameOver();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameStart();
            }
            backMusic.Stop();
        }
    }

    public void GameOver()
    {
        gameOverTextPos[0].localPosition = new Vector3(Random.Range(-textSpeed, textSpeed + 1) + -60, Random.Range(-textSpeed, textSpeed + 1) + 90, 0);
        gameOverTextPos[1].localPosition = new Vector3(Random.Range(-textSpeed, textSpeed + 1) + 65, Random.Range(-textSpeed, textSpeed + 1) + 90, 0);
    }

    public void GameStart()
    {
        StartSettings();
		SceneManager.LoadScene("Game");
	}

    private void StartSettings()
    {
		DataManager.Instance.isDead = false;
		DataManager.Instance.Score = 0;
		DataManager.Instance.Stage = 0;
	}
}
