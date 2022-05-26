using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CludeMove : MonoBehaviour
{
    int speed;

    private void Start()
    {
        speed = Random.Range(3, 10);
    }

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
