using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
	[SerializeField] private GameObject settingPanel;
	[SerializeField] private Slider BGMSilder;
	[SerializeField] private Slider SFXSlider;

	public void OnSetting()
	{
		BGMSilder.value = PlayerPrefs.GetFloat("BGMScale");
		SFXSlider.value = PlayerPrefs.GetFloat("SFXScale");
		settingPanel.SetActive(true);
		StartCoroutine("ShowSetting");
	}

	public void OffSetting()
	{
		StartCoroutine("CloseSetting");
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

	private void SetComponent(Transform trans, bool b)
	{
		for(int i=0;i< trans.childCount; i++)
		{
			trans.GetChild(i).gameObject.SetActive(b);
		}
	}

	private IEnumerator ShowSetting()
	{
		RectTransform panelTransform = settingPanel.transform.GetChild(0).GetComponent<RectTransform>();
		SettingPanel panel = settingPanel.GetComponent<SettingPanel>();

		float yPos = -1000;
		float panelSpeed = 10f;
		SetComponent(panelTransform.transform, false);
		panelTransform.position = new Vector3(0, yPos, 0);
		
		while (true)
		{
			yield return null;
			if(yPos < 0)
			{
			yPos = Mathf.Lerp(yPos, 0 + 10, Time.deltaTime * panelSpeed);
			panelTransform.localPosition = new Vector3(0, yPos, 0);
			}
			else
			{
				panel.OpenAnim();
				yield return new WaitForSeconds(1f);
				SetComponent(panelTransform.transform, true);

				yield break;
			}
		}
	}

	private IEnumerator CloseSetting()
	{
		RectTransform panelTransform = settingPanel.transform.GetChild(0).GetComponent<RectTransform>();
		SettingPanel panel = settingPanel.GetComponent<SettingPanel>();

		float yPos = 0;
		float panelSpeed = 10f;

		panelTransform.localPosition = new Vector3(0, yPos, 0);
		SetComponent(panelTransform.transform, false);
		panel.CloseAnim();
		yield return new WaitForSeconds(1f);
		while (true)
		{
			yield return null;
			if (yPos > -1000)
			{
				yPos = Mathf.Lerp(yPos, -1000 - 10, Time.deltaTime * panelSpeed);
				panelTransform.localPosition = new Vector3(0, yPos, 0);
			}
			else
			{
				settingPanel.SetActive(false);
				yield break;
			}
		}
	}
}
