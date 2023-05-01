using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
	private TextMeshProUGUI scoreText;

	private void Awake()
	{
		scoreText=GetComponent<TextMeshProUGUI>();
	}

	private void Update()
	{
		scoreText.text = DataManager.Instance.Score.ToString();
	}
}
