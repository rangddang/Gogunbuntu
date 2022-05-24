using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public bool gameOver = false;
    public GameObject GameOverScreen;
    public RectTransform[] gameOverTextPos;
    public float textSpeed;

    private void Update()
    {
        //Á¡¼ö ¶ç¿ì±â
        Score();
        if (DataManager.Instance.PlayerDie)
        {
            gameOver = true;
        }
        if (gameOver)
        {
            GameOver();
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
