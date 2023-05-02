using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TMP_Text bestScore;

    private bool isBestScore;

	private void Start()
    {
        gameOverPanel.SetActive(false);
    }

    private void Update()
    {
		if (DataManager.Instance.Score > PlayerPrefs.GetInt("BestScore") && PlayerPrefs.GetInt("BestScore") > 0)
        {
            if (!isBestScore)
            {
                isBestScore = true;
                gameManager.Best();
            }
			PlayerPrefs.SetInt("BestScore", DataManager.Instance.Score);
        }
		bestScore.text = PlayerPrefs.GetInt("BestScore").ToString("0000000");
	}

    public void GameOver()
    {
		gameOverPanel.SetActive(true);
		if (DataManager.Instance.Score > PlayerPrefs.GetInt("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", DataManager.Instance.Score);
        }
	}
}
