using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip clip;
    [SerializeField]
    private bool isGold = false;

    private void Start()
    {
        transform.localPosition += Vector3.forward * -0.1f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") == true)
        {
            if(!isGold)
            {
                DataManager.Instance.Score += 5;
                SoundManager.Instance.SFXPlay("Coin", clip);
            }
            else if(isGold)
            {
                DataManager.Instance.Score += 50 - (5*(DataManager.Instance.Stage - 1));
                SoundManager.Instance.SFXPlay("Gold Coin", clip);
            }

            //Debug.Log(DataManager.Instance.Score);
            Destroy(gameObject);
        }
    }
}
