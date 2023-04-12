using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TMP_Text bestScore;

    private bool isBestScore;

	private void Start()
    {
        gameOverPanel.SetActive(false);
    }

    private void Update()
    {
		if (DataManager.Instance.Score > DataManager.Instance.BestScore && DataManager.Instance.BestScore > 0)
        {
            if (!isBestScore)
            {
                isBestScore = true;
                gameManager.Best();
            }
			DataManager.Instance.BestScore = DataManager.Instance.Score;
        }
        scoreText.text = DataManager.Instance.Score.ToString();
		bestScore.text = DataManager.Instance.BestScore.ToString("0000000");
	}

    public void GameOver()
    {
		gameOverPanel.SetActive(true);
		if (DataManager.Instance.Score > DataManager.Instance.BestScore)
			DataManager.Instance.BestScore = DataManager.Instance.Score;
	}
}
