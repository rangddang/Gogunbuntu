using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
	private AudioSource buttonSound;

	private void Awake()
	{
		buttonSound = GetComponent<AudioSource>();
	}

	private void Start()
	{
		SetSound();
	}

	private void Update()
	{
		SetSound();
	}

	private void SetSound()
	{
		buttonSound.volume = PlayerPrefs.GetFloat("SFXScale");
	}
}
