using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private TextMeshProUGUI ScoreText;

    private void Start()
    {
        GameOverPanel.SetActive(false);
    }

    private void Update()
    {
        if (DataManager.Instance.isDead)
        {
            GameOverPanel.SetActive(true);
        }
        ScoreText.text = DataManager.Instance.Score.ToString();
    }
}
