using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blinder : MonoBehaviour
{
    [SerializeField] private float blindSpeed;
    [SerializeField] private GameManager gameManager;

    private RectTransform midBlinder;
    private Image rightBlinder;
    private Image leftBlinder;

    private bool endBlind;
    public bool EndBlind => endBlind;

    private void Awake()
    {
        midBlinder = transform.Find("Blinder Mid").GetComponent<RectTransform>();
		rightBlinder = transform.Find("Blinder Right").GetComponent<Image>();
		leftBlinder = transform.Find("Blinder Left").GetComponent<Image>();
	}

    private void Start()
    {
		rightBlinder.fillAmount = 1;
		leftBlinder.fillAmount = 1;
		OffBlind();
    }

    public void Blind()
    {
        endBlind = false;
        StartCoroutine("BlindScreen");
    }

    private void OffBlind()
    {
		StartCoroutine("OffBlindScreen");
	}

    private IEnumerator BlindScreen()
    {
		float height = 0;
        float width = 70f;
        float fillAmount = 0;

        float maxHeight = 1080;
        float maxWidth = 50f;
        while (fillAmount < 1)
        {
            yield return null;
            if(height < maxHeight)
            {
                height = Mathf.Lerp(height, maxHeight + 1, Time.deltaTime * blindSpeed);
                width = Mathf.Lerp(width, maxWidth, Time.deltaTime * blindSpeed);
                midBlinder.sizeDelta = new Vector2(width, height);
            }
            else
            {
                fillAmount = Mathf.Lerp(fillAmount, 1 + 0.1f, Time.deltaTime * blindSpeed);
                rightBlinder.fillAmount = fillAmount;
                leftBlinder.fillAmount = fillAmount;
            }
        }
        endBlind = true;
    }

	private IEnumerator OffBlindScreen()
	{
		float fillAmount = 1;
		while (fillAmount > 0)
        {
            yield return null;
            fillAmount = Mathf.Lerp(fillAmount, 0 - 0.1f, Time.deltaTime * blindSpeed);
            rightBlinder.fillAmount = fillAmount;
            leftBlinder.fillAmount = fillAmount;
        }
	}
}
