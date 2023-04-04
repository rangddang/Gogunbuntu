using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMesh bestScoreText;

    private void Start()
    {
        gameOverPanel.SetActive(false);
    }

    private void Update()
    {
        scoreText.text = DataManager.Instance.Score.ToString();
		bestScoreText.text = DataManager.Instance.BestScore.ToString("0000000");
		if (DataManager.Instance.isDead)
        {
            gameOverPanel.SetActive(true);
        }
	}
}
