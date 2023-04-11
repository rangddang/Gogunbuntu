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
    [SerializeField] private CatStatue catStatue;
	[SerializeField] private float textSpeed = 2;

    private bool isBestScore;

	private void Start()
    {
        gameOverPanel.SetActive(false);
    }

    private void Update()
    {
		if (DataManager.Instance.Score > DataManager.Instance.BestScore)
        {
            if (!isBestScore)
            {
                catStatue.SetAnimation(CatAnimation.Suprising);
                isBestScore = true;
            }
			DataManager.Instance.BestScore = DataManager.Instance.Score;
        }
        scoreText.text = DataManager.Instance.Score.ToString();
		bestScoreText.text = DataManager.Instance.BestScore.ToString("0000000");
	}

    public void GameOver()
    {
		gameOverPanel.SetActive(true);
	}

 //   private IEnumerator MoveGameOverText()
 //   {
 //       while (true)
 //       {
 //           gameOverTextPos[0].localPosition = new Vector3(Random.Range(-textSpeed, textSpeed + 1) + -120, Random.Range(-textSpeed, textSpeed + 1), 0);
 //           gameOverTextPos[1].localPosition = new Vector3(Random.Range(-textSpeed, textSpeed + 1) + 120, Random.Range(-textSpeed, textSpeed + 1), 0);
 //           yield return null;
 //       }
	//}
}
