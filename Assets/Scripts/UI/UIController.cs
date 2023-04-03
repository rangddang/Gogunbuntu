using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Start()
    {
        gameOverPanel.SetActive(false);
    }

    private void Update()
    {
        scoreText.text = DataManager.Instance.Score.ToString();
        if (DataManager.Instance.isDead)
        {
            gameOverPanel.SetActive(true);
        }
	}
}
