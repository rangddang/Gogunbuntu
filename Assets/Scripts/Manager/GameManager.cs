using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public static bool gameOver = false;
    public GameObject GameOverScreen;
    public RectTransform[] gameOverTextPos;
    public float textSpeed;
    public TextMesh BestScoreText;
    public AudioSource backMusic;
    public MapMove map;

    private void Start()
    {
        if (!DataManager.Instance.gameStart) return;
        DataManager.Instance.PlayerDie = false;
        DataManager.Instance.gameStart = true;
        gameOver = false;
        GameOverScreen.SetActive(false);
        DataManager.Instance.Score = 0;
        map = FindObjectOfType<MapMove>().GetComponent<MapMove>();
    }

    private void Update()
    {
        if (!DataManager.Instance.gameStart) return;
		//점수 표시
		scoreText.text = DataManager.Instance.Score.ToString();
		if (DataManager.Instance.PlayerDie)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameStart();
            }
            gameOver = true;
            backMusic.Stop();
        }
        if (gameOver)
        {
            GameOver();
        }
        //최고기록 표시
        //BestScoreText.text = (DataManager.Instance.BestScore / 1000000).ToString() +
        //    ((DataManager.Instance.BestScore % 1000000) / 100000).ToString() +
        //    ((DataManager.Instance.BestScore % 100000) / 10000).ToString() +
        //    ((DataManager.Instance.BestScore % 10000) / 1000).ToString() +
        //    ((DataManager.Instance.BestScore % 1000) / 100).ToString() +
        //    ((DataManager.Instance.BestScore % 100) / 10).ToString() +
        //    (DataManager.Instance.BestScore % 10).ToString();

        //BestScoreText.text = DataManager.Instance.BestScore.ToString("0000000");

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

    private void Score()
    {
        
    }

    void GameOver()
    {
        GameOverScreen.SetActive(true);
        gameOverTextPos[0].localPosition = new Vector3(Random.Range(-textSpeed, textSpeed + 1) + -60, Random.Range(-textSpeed, textSpeed + 1) + 90, 0);
        gameOverTextPos[1].localPosition = new Vector3(Random.Range(-textSpeed, textSpeed + 1) + 65, Random.Range(-textSpeed, textSpeed + 1) + 90, 0);
    }

    public void ReStart()
    {
        DataManager.Instance.PlayerDie = false;
        gameOver = false;
        GameOverScreen.SetActive(false);
        DataManager.Instance.Score = 0;
        DataManager.Instance.Stage = 1;
        SceneManager.LoadScene("Game");
        DataManager.Instance.gameStart = true;
    }

    public void GameStart()
    {
        SceneManager.LoadScene("Game");
        DataManager.Instance.gameStart = true;
    }
}
