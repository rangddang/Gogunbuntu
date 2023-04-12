using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEffect : MonoBehaviour
{
    [SerializeField] private RectTransform Besttext;
	[SerializeField] private RectTransform bonusText;
	[SerializeField] private RectTransform speedUpText;

	private RectTransform textEffect;

	private Coroutine bestCo;
	private Coroutine bonusCo;
	private Coroutine speedCo;

	private void Start()
	{
		Besttext.gameObject.SetActive(false);
		bonusText.gameObject.SetActive(false);
		speedUpText.gameObject.SetActive(false);
	}

	public void Best()
	{
		if (bestCo != null)
			StopCoroutine(bestCo);
		Besttext.gameObject.SetActive(true);
		textEffect = Besttext;
		bestCo = StartCoroutine("TextEffectAnimation");
	}

	public void Bonus()
	{
		if (bonusCo != null)
			StopCoroutine(bonusCo);
		bonusText.gameObject.SetActive(true);
		textEffect = bonusText;
		bonusCo = StartCoroutine("TextEffectAnimation");
	}

	public void SpeedUp()
	{
		if (speedCo != null)
			StopCoroutine(speedCo);
		speedUpText.gameObject.SetActive(true);
		textEffect = speedUpText;
		speedCo = StartCoroutine("TextEffectAnimation");
	}

	private IEnumerator TextEffectAnimation()
	{
		RectTransform text = textEffect;
		Vector3 offset = new Vector3(1500, text.localPosition.y, 0);
		Vector3 sizeOffset = new Vector3(2, 0.3f, 1);
		float animSpeed = 10f;
		float sizeSpeed = 10f;

		text.localPosition = offset;
		text.localScale = sizeOffset;
		sizeOffset = new Vector3(0.5f, 1.5f, 1);
		offset = new Vector3(0, text.localPosition.y, 0);
		while (text.localPosition.x > 50)
		{
			text.localPosition = Vector3.Lerp(text.localPosition, offset, Time.deltaTime * animSpeed);
			text.localScale = Vector3.Lerp(text.localScale, sizeOffset, Time.deltaTime * sizeSpeed);
			yield return null;
		}
		sizeOffset = new Vector3(1, 1, 1);
		offset = new Vector3(-100, text.localPosition.y, 0);
		animSpeed = 1f;
		while (text.localPosition.x > -50)
		{
			text.localPosition = Vector3.Lerp(text.localPosition, offset, Time.deltaTime * animSpeed);
			text.localScale = Vector3.Lerp(text.localScale, sizeOffset, Time.deltaTime * sizeSpeed);
			yield return null;
		}
		sizeOffset = new Vector3(2, 0.3f, 1);
		offset = new Vector3(-1550, text.localPosition.y, 0);
		animSpeed = 10f;
		while (text.localPosition.x > -1500)
		{
			text.localPosition = Vector3.Lerp(text.localPosition, offset, Time.deltaTime * animSpeed);
			text.localScale = Vector3.Lerp(text.localScale, sizeOffset, Time.deltaTime * sizeSpeed);
			yield return null;
		}
		text.gameObject.SetActive(false);
	}

	//private IEnumerator BestEffect()
	//{
	//	RectTransform text = Besttext;
	//	Vector3 offset = new Vector3(1300, 200, 0);
	//	Vector3 sizeOffset = new Vector3(2, 0.3f, 1);
	//	float animSpeed = 10f;
	//	float sizeSpeed = 10f;

	//	text.localPosition = offset;
	//	text.localScale = sizeOffset;
	//	sizeOffset = new Vector3(0.5f, 1.5f, 1);
	//	offset = new Vector3(0, 200, 0);
	//	while (text.localPosition.x > 50)
	//	{
	//		text.localPosition = Vector3.Lerp(text.localPosition, offset, Time.deltaTime * animSpeed);
	//		text.localScale = Vector3.Lerp(text.localScale, sizeOffset, Time.deltaTime * sizeSpeed);
	//		yield return null;
	//	}
	//	sizeOffset = new Vector3(1, 1, 1);
	//	offset = new Vector3(-100, 200, 0);
	//	animSpeed = 1f;
	//	while (text.localPosition.x > -50)
	//	{
	//		text.localPosition = Vector3.Lerp(text.localPosition, offset, Time.deltaTime * animSpeed);
	//		text.localScale = Vector3.Lerp(text.localScale, sizeOffset, Time.deltaTime * sizeSpeed);
	//		yield return null;
	//	}
	//	sizeOffset = new Vector3(2, 0.3f, 1);
	//	offset = new Vector3(-1350, 200, 0);
	//	animSpeed = 10f;
	//	while (text.localPosition.x > -1300)
	//	{
	//		text.localPosition = Vector3.Lerp(text.localPosition, offset, Time.deltaTime * animSpeed);
	//		text.localScale = Vector3.Lerp(text.localScale, sizeOffset, Time.deltaTime * sizeSpeed);
	//		yield return null;
	//	}
	//	text.gameObject.SetActive(false);
	//}

	//private IEnumerator BonusEffect()
	//{
	//	RectTransform text = bonusText;
	//	Vector3 offset = new Vector3(1300, -80, 0);
	//	Vector3 sizeOffset = new Vector3(2, 0.3f, 1);
	//	float animSpeed = 10f;
	//	float sizeSpeed = 10f;

	//	text.localPosition = offset;
	//	text.localScale = sizeOffset;
	//	sizeOffset = new Vector3(0.5f, 1.5f, 1);
	//	offset = new Vector3(0, -80, 0);
	//	while (text.localPosition.x > 50)
	//	{
	//		text.localPosition = Vector3.Lerp(text.localPosition, offset, Time.deltaTime * animSpeed);
	//		text.localScale = Vector3.Lerp(text.localScale, sizeOffset, Time.deltaTime * sizeSpeed);
	//		yield return null;
	//	}
	//	sizeOffset = new Vector3(1, 1, 1);
	//	offset = new Vector3(-100, -80, 0);
	//	animSpeed = 1f;
	//	while (text.localPosition.x > -50)
	//	{
	//		text.localPosition = Vector3.Lerp(text.localPosition, offset, Time.deltaTime * animSpeed);
	//		text.localScale = Vector3.Lerp(text.localScale, sizeOffset, Time.deltaTime * sizeSpeed);
	//		yield return null;
	//	}
	//	sizeOffset = new Vector3(2, 0.3f, 1);
	//	offset = new Vector3(-1350, -80, 0);
	//	animSpeed = 10f;
	//	while (text.localPosition.x > -1300)
	//	{
	//		text.localPosition = Vector3.Lerp(text.localPosition, offset, Time.deltaTime * animSpeed);
	//		text.localScale = Vector3.Lerp(text.localScale, sizeOffset, Time.deltaTime * sizeSpeed);
	//		yield return null;
	//	}
	//	text.gameObject.SetActive(false);
	//}

	//private IEnumerator SpeedUpEffect()
	//{
	//	RectTransform text = speedUpText;
	//	Vector3 offset = new Vector3(1300, -240, 0);
	//	Vector3 sizeOffset = new Vector3(2, 0.3f, 1);
	//	float animSpeed = 10f;
	//	float sizeSpeed = 10f;

	//	text.localPosition = offset;
	//	text.localScale = sizeOffset;
	//	sizeOffset = new Vector3(0.5f, 1.5f, 1);
	//	offset = new Vector3(0, -240, 0);
	//	while (text.localPosition.x > 50)
	//	{
	//		text.localPosition = Vector3.Lerp(text.localPosition, offset, Time.deltaTime * animSpeed);
	//		text.localScale = Vector3.Lerp(text.localScale, sizeOffset, Time.deltaTime * sizeSpeed);
	//		yield return null;
	//	}
	//	sizeOffset = new Vector3(1, 1, 1);
	//	offset = new Vector3(-100, -240, 0);
	//	animSpeed = 1f;
	//	while (text.localPosition.x > -50)
	//	{
	//		text.localPosition = Vector3.Lerp(text.localPosition, offset, Time.deltaTime * animSpeed);
	//		text.localScale = Vector3.Lerp(text.localScale, sizeOffset, Time.deltaTime * sizeSpeed);
	//		yield return null;
	//	}
	//	sizeOffset = new Vector3(2, 0.3f, 1);
	//	offset = new Vector3(-1350, -240, 0);
	//	animSpeed = 10f;
	//	while (text.localPosition.x > -1300)
	//	{
	//		text.localPosition = Vector3.Lerp(text.localPosition, offset, Time.deltaTime * animSpeed);
	//		text.localScale = Vector3.Lerp(text.localScale, sizeOffset, Time.deltaTime * sizeSpeed);
	//		yield return null;
	//	}
	//	text.gameObject.SetActive(false);
	//}
}
