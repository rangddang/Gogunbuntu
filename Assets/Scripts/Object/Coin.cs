using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip clip;

    private void Start()
    {
        transform.localPosition += Vector3.forward * -0.1f;
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
                DataManager.Instance.Score += 50 - (5*(DataManager.Instance.Stage - 1));
                transform.parent.transform.parent.transform.parent.GetComponent<MapSetting>().currentGoldCoins++;
            }

			SoundManager.Instance.SFXPlay(transform.tag, clip);

			gameObject.SetActive(false);
        }
    }
}
