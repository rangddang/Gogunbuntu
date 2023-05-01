using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    [SerializeField] private Pointer pointer;
    [SerializeField] private PopCat cat;
    [SerializeField] private int fishPrice = 1000;
    [SerializeField] private List<AudioClip> eatSound;
    [SerializeField] private AudioClip burpSound;


	private ParticleSystem particle;
    private bool isPlay;
    private bool one;

    private void Awake()
    {
		particle = GetComponent<ParticleSystem>();
	}

    private void Update()
    {
        if (!pointer.Following && !one)
        {
            one = true;
            isPlay = true;
			StartCoroutine("StartFish");
            StartCoroutine("Fishs");
            StartCoroutine("EatSound");
			StartCoroutine("StopFish");
        }
	}

	private IEnumerator StartFish()
	{
		yield return new WaitForSeconds(1f);
		particle.Play();
	}

	private IEnumerator StopFish()
    {
        float fishTime = particle.emission.rateOverTime.constantMax;
		float sec = (DataManager.Instance.Score / fishPrice) * (1 / fishTime);
        yield return new WaitForSeconds(sec);
		particle.Stop();
        yield return new WaitForSeconds(1f);
		SoundManager.Instance.SFXPlay("Burp", burpSound);
		cat.SetAnim(0);
        pointer.GoToRight();
	}

    private IEnumerator Fishs()
    {
		yield return new WaitForSeconds(1f);
		while (DataManager.Instance.Score >= fishPrice)
        {
            DataManager.Instance.Score -= fishPrice;
			yield return new WaitForSeconds(1 / particle.emission.rateOverTime.constantMax);
		}
		//yield return new WaitForSeconds(particle.startLifetime);
        isPlay = false;
	}
    private IEnumerator EatSound()
    {
        yield return new WaitForSeconds(particle.startLifetime + 0.9f);
        while (isPlay)
        {
            yield return new WaitForSeconds(1 / particle.emission.rateOverTime.constantMax);
            SoundManager.Instance.SFXPlay("Eat", eatSound[Random.Range(0, eatSound.Count)]);
        }
    }
}
