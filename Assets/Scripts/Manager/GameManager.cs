using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour
{
    [SerializeField] private UIController ui;
    [SerializeField] private AudioSource backMusic;
    [SerializeField] private CatStatue catStatue;
    [SerializeField] private MapMove map;
    [SerializeField] private TextEffect textEffect;
    [SerializeField] private RainbowWobble rainbowText;

  //  private void Update()
  //  {
		//if (DataManager.Instance.isDead)
  //      {
  //          if (Input.GetKeyDown(KeyCode.Space))
  //          {
  //              GameStart();
  //          }
  //      }
  //  }

    public void GameStart()
    {
        StartSettings();
		SceneManager.LoadScene("Game");
	}

    public void GameOver()
    {
        DataManager.Instance.isDead = true;
		map.StopStage();
		ui.GameOver();
        backMusic.Stop();
        catStatue.SetAnimation(CatAnimation.Laugh);
    }

    private void StartSettings()
    {
		DataManager.Instance.isDead = false;
		DataManager.Instance.Score = 0;
		DataManager.Instance.Stage = 0;
	}

    public void Best()
    {
        rainbowText.enabled = true;
        textEffect.Best();
		catStatue.SetAnimation(CatAnimation.Suprising);
	}

    public void Bonus()
    {
        DataManager.Instance.Score += 200;
        textEffect.Bonus();
        catStatue.SetAnimation(CatAnimation.Blink1);
    }

    public void SpeedUp()
    {
        DataManager.Instance.Stage++;
        textEffect.SpeedUp();
		catStatue.SetAnimation(CatAnimation.Suprising);
	}
}
