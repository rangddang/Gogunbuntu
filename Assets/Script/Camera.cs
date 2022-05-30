using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    int xBool = 1;
    public float xMax = 3;
    public float xSpeed = 1;

    void Update()
    {
        if (transform.eulerAngles.x > xMax || transform.eulerAngles.x < -xMax)
        {
            transform.rotation = Quaternion.Euler(xMax * xBool,transform.rotation.y, transform.rotation.z);
            xBool *= -1;
        }
        else
        {
            transform.rotation *= Quaternion.Euler(xBool * xSpeed * Time.deltaTime, 0,0);
            //Debug.Log(transform.rotation.x);
            //Debug.Log(transform.eulerAngles.x);
        }
    }
}
