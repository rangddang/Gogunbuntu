using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void Awake()
    {
        //transform.position += new Vector3(-0.5f, 0, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.CompareTo("Player") == 0)
        {
            if(gameObject.tag == "Coin")
                DataManager.Instance.Score += 5;
            else if(gameObject.tag == "Gold Coin")
                DataManager.Instance.Score += 50;
            gameObject.SetActive(false);
        }
    }
}
