using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireController : MonoBehaviour
{
    [SerializeField] private Transform playerHand;
    [SerializeField] private Vector3 ShotPos;

    private LineRenderer line;
    private SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        line = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        sprite.enabled = false;
        line.enabled = false;
    }

    private void Update()
    {
        line.SetPosition(0, playerHand.position);
        line.SetPosition(1, transform.position);
    }

    public void Shot()
    {
        sprite.enabled = true;
        line.enabled = true;

    }
}
