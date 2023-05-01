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
    [SerializeField] private Blinder blinder;
    [SerializeField] private AudioClip gameOverSound;
    [SerializeField] private AudioClip bestSound;
	[SerializeField] private AudioClip bonusSound;
	[SerializeField] private AudioClip speedUpSound;

	private string sceneName;

	public void GoToMain()
    {
		DataManager.Instance.isEnd = false;
		blinder.Blind();
		if (sceneName == null)
			sceneName = "Main";
		StartCoroutine("Ready");
	}

    public void Exit()
    {
        Application.Quit();
    }

	public void GameStart()
    {
		blinder.Blind();
        if(sceneName == null)
            sceneName = "Game";
        StartCoroutine("Ready");
		StartSettings();
	}

    public void GameOver()
    {
        DataManager.Instance.isDead = true;
		ui.GameOver();
        backMusic.Stop();
        backMusic.PlayOneShot(gameOverSound);
        catStatue.SetAnimation(CatAnimation.Laugh);
    }

    private void StartSettings()
    {
		DataManager.Instance.Score = 0;
		DataManager.Instance.Stage = 0;
	}

    public void Best()
    {
        rainbowText.enabled = true;
        textEffect.Best();
		catStatue.SetAnimation(CatAnimation.Suprising);
        SoundManager.Instance.SFXPlay("Best", bestSound);
	}

    public void Bonus()
    {
        DataManager.Instance.Score += 200;
        textEffect.Bonus();
        catStatue.SetAnimation(CatAnimation.Blink1);
		SoundManager.Instance.SFXPlay("Bonus", bonusSound);
	}

    public void SpeedUp()
    {
        DataManager.Instance.Stage++;
        textEffect.SpeedUp();
		catStatue.SetAnimation(CatAnimation.Suprising);
		SoundManager.Instance.SFXPlay("SpeedUp", speedUpSound);
	}

    public void Ending()
    {
        if (!DataManager.Instance.isEnd)
        {
            DataManager.Instance.isEnd = true;
            StartCoroutine("End");
        }
	}

    private IEnumerator Ready()
    {
        while (true)
        {
            yield return null;
			if (blinder.EndBlind)
			{
				DataManager.Instance.isDead = false;
				LoadingManager.LoadScene(sceneName);
                yield break;
			}
		}
	}

    private IEnumerator End()
    {
        yield return new WaitForSeconds(4.5f);
		blinder.Blind();
		if (sceneName == null)
			sceneName = "Ending";
		StartCoroutine("Ready");
	}
}
