using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLight : MonoBehaviour
{
    int xBool = 1;
    public float xMax = 5;
    public float xSpeed = 1;

    void Update()
    {
        if(transform.position.x > xMax || transform.position.x < -xMax)
        {
            transform.position = new Vector3(xBool * xMax,transform.position.y,transform.position.z);
            xBool *= -1;
        }
        else
        {
            transform.position += Vector3.right * xBool * xSpeed * Time.deltaTime;
            
        }
    }
}
