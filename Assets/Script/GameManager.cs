using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public static bool gameOver = false;
    public GameObject GameOverScreen;
    public RectTransform[] gameOverTextPos;
    public float textSpeed;
    public TextMesh BestScoreText;
    public static int Stage = 1;

    private void Start()
    {
        //Time.timeScale = 1.5f;
        DataManager.Instance.PlayerDie = false;
        gameOver = false;
        GameOverScreen.SetActive(false);
        DataManager.Instance.Score = 0;
    }

    private void Update()
    {
        //점수 표시
        Score();
        if (DataManager.Instance.PlayerDie)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameStart();
            }
            gameOver = true;
        }
        if (gameOver)
        {
            GameOver();
        }
        //최고기록 표시
        BestScoreText.text = (DataManager.Instance.BestScore / 1000000).ToString() +
            ((DataManager.Instance.BestScore % 1000000)/100000).ToString() +
            ((DataManager.Instance.BestScore % 100000) / 10000).ToString() +
            ((DataManager.Instance.BestScore % 10000) / 1000).ToString() +
            ((DataManager.Instance.BestScore % 1000) / 100).ToString() +
            ((DataManager.Instance.BestScore % 100) / 10).ToString() +
            (DataManager.Instance.BestScore % 10).ToString();

        //if (Input.GetKeyDown(KeyCode.Tab))
        //{
        //    Debug.Log(DataManager.Instance.BestScore / 1000000);
        //    Debug.Log((DataManager.Instance.BestScore % 1000000) / 100000);
        //    Debug.Log((DataManager.Instance.BestScore % 100000) / 10000);
        //    Debug.Log((DataManager.Instance.BestScore % 10000) / 1000);
        //    Debug.Log((DataManager.Instance.BestScore % 1000) / 100);
        //    Debug.Log((DataManager.Instance.BestScore % 100) / 10);
        //    Debug.Log(DataManager.Instance.BestScore % 10);
        //}

        if (DataManager.Instance.BestScore < DataManager.Instance.Score)
        {
            DataManager.Instance.BestScore = DataManager.Instance.Score;
        }
    }

    void Score()
    {
        scoreText.text = DataManager.Instance.Score.ToString();
    }

    void GameOver()
    {
        GameOverScreen.SetActive(true);
        gameOverTextPos[0].localPosition = new Vector3(Random.Range(-textSpeed, textSpeed + 1) + -70, Random.Range(-textSpeed, textSpeed + 1) + 90, 0);
        gameOverTextPos[1].localPosition = new Vector3(Random.Range(-textSpeed, textSpeed + 1) + 75, Random.Range(-textSpeed, textSpeed + 1) + 90, 0);
    }

    public void GameStart()
    {
        DataManager.Instance.PlayerDie = false;
        gameOver = false;
        GameOverScreen.SetActive(false);
        DataManager.Instance.Score = 0;
        Stage = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
