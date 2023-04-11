using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private WireController wire;
    private BoxCollider collider;

    private void Awake()
    {
        collider = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        collider.enabled = !wire.OnWire;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameManager.GameOver();
        }
    }
}
