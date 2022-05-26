using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryZon : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
    }
}
