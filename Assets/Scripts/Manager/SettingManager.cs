using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
	[SerializeField] private GameObject SettingPanel;
	[SerializeField] private Slider BGMSilder;
	[SerializeField] private Slider SFXSlider;

	public void OnSetting()
	{
		BGMSilder.value = PlayerPrefs.GetFloat("BGMScale");
		SFXSlider.value = PlayerPrefs.GetFloat("SFXScale");
		SettingPanel.SetActive(true);
		StartCoroutine("ShowSetting");
	}

	public void OffSetting()
	{
		SettingPanel.SetActive(false);
	}

	public void SetBGM()
	{
		float back = BGMSilder.value;
		back = Mathf.Clamp(back, 0f, 1f);
		PlayerPrefs.SetFloat("BGMScale", back);
	}

	public void SetSFX()
	{
		float play = SFXSlider.value;
		play = Mathf.Clamp(play, 0f, 1f);
		PlayerPrefs.SetFloat("SFXScale", play);
	}

	private IEnumerator ShowSetting()
	{
		yield return null;
	}
}
