using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Fps : MonoBehaviour
{
    private TextMeshProUGUI fpsText;

    private void Awake()
    {
        fpsText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        StartCoroutine("FPS");
    }

    private IEnumerator FPS()
    {
        while (true)
        {
			fpsText.text = "FPS : " + (int)(1 / Time.deltaTime);
            yield return new WaitForSeconds(0.1f);
		}
    }
}
