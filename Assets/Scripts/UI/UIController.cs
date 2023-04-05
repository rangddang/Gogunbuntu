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
	[SerializeField] private RectTransform[] gameOverTextPos;
	[SerializeField] private float textSpeed = 2;

	private void Start()
    {
        gameOverPanel.SetActive(false);
    }

    private void Update()
    {
		if (DataManager.Instance.Score > DataManager.Instance.BestScore)
			DataManager.Instance.BestScore = DataManager.Instance.Score;
        scoreText.text = DataManager.Instance.Score.ToString();
		bestScoreText.text = DataManager.Instance.BestScore.ToString("0000000");
	}

    public void GameOver()
    {
		gameOverPanel.SetActive(true);
        StartCoroutine("MoveGameOverText");
	}

    private IEnumerator MoveGameOverText()
    {
        while (true)
        {
            gameOverTextPos[0].localPosition = new Vector3(Random.Range(-textSpeed, textSpeed + 1) + -60, Random.Range(-textSpeed, textSpeed + 1) + 90, 0);
            gameOverTextPos[1].localPosition = new Vector3(Random.Range(-textSpeed, textSpeed + 1) + 65, Random.Range(-textSpeed, textSpeed + 1) + 90, 0);
            yield return null;
        }
	}
}
