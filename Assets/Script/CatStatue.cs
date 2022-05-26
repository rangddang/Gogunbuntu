using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatStatue : MonoBehaviour
{
    int yBool = 1;
    public float yMax = 1;
    public float ySpeed = 3;

    void Update()
    {
        if (DataManager.Instance.PlayerDie)
        {
            PlayerDead();
        }
    }

    void PlayerDead()
    {
        if (transform.position.y > yMax || transform.position.y < -yMax)
        {
            transform.position = new Vector3(transform.position.x, yBool * yMax, transform.position.z);
            yBool *= -1;
        }
        else
        {
            transform.Translate(Vector3.up * yBool * ySpeed * Time.deltaTime);

        }
    }
}
