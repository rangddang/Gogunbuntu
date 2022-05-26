using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private PlayerController player;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (!DataManager.Instance.PlayerDie)
        {
            if(other.gameObject.tag.CompareTo("Player") == 0 && !player.isHook)
            {
                DataManager.Instance.PlayerDie = true;
            }
        }
    }
}
