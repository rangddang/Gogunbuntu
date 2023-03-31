using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDistance : MonoBehaviour
{
    [SerializeField] private float distance = 20f;
    public float Distance => distance;

    private void Update()
    {
        if(transform.position.x < -(distance + 10))
        {
            Destroy(gameObject);
        }
    }
}
