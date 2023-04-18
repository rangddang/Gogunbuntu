using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private AudioClip clip;
    [SerializeField] private GameObject coinEffect;

    private void Start()
    {
        transform.localPosition += Vector3.forward * -0.1f;
    }

    private void MakeEffect()
    {
        GameObject effect = Instantiate(coinEffect, transform.position, Quaternion.identity);
        effect.transform.parent = transform.parent.parent.parent;
        effect.GetComponent<ParticleSystem>().Play();
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") == true)
        {
            if(transform.tag == "Coin")
            {
                DataManager.Instance.Score += 5;
            }
            else if(transform.tag == "Gold_Coin")
            {
                DataManager.Instance.Score += 50 - (5 * DataManager.Instance.Stage);
                transform.parent.parent.parent.GetComponent<MapSetting>().currentGoldCoins++;
            }

			SoundManager.Instance.SFXPlay(transform.tag, clip);
            MakeEffect();
			gameObject.SetActive(false);
        }
    }
}
