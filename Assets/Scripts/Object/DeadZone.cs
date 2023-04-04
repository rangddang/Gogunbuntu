using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(DataManager.Instance.Score > DataManager.Instance.BestScore)
                DataManager.Instance.BestScore = DataManager.Instance.Score;
            DataManager.Instance.isDead = true;
        }
    }
}
