using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMove : MonoBehaviour
{
    public float mapSpeed;

    private void Update()
    {
        if(!DataManager.Instance.PlayerDie)
        {
            transform.Translate(-mapSpeed * Time.deltaTime, 0, 0);
        }
        else
        {
            if(mapSpeed> 0)
                mapSpeed -= 35f * Time.deltaTime;
            else
                mapSpeed = 0;
            transform.Translate(-mapSpeed * Time.deltaTime, 0, 0);
        }
        
    }
}
