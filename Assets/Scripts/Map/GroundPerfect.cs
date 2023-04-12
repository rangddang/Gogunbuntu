using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPerfect : MonoBehaviour
{
    private void Update()
    {
        transform.position = new Vector3(transform.position.x,transform.position.y, transform.position.x * 0.0001f);
    }
}
