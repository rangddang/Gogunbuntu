using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSkyBox : MonoBehaviour
{
    float degree = 0;
    public float skySpeed;

    //void Start()
    //{
    //    degree = 0;
    //}

    void Update()
    {
        degree += skySpeed * Time.deltaTime;
        if (degree >= 360)
            degree = 0;

        RenderSettings.skybox.SetFloat("_Rotation", degree);
    }
}
