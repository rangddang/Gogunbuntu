using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatStatue : MonoBehaviour
{
    int yBool = 1;
    public float yMax = 1;
    public float ySpeed = 3;
    float yPos;

    private void Start()
    {
        yPos = transform.position.y;
    }

    void Update()
    {
        if (DataManager.Instance.PlayerDie)
        {
            PlayerDead();
        }
    }

    void PlayerDead()
    {
        if ((transform.position.y > yMax + yPos && yBool == 1) || (transform.position.y < (yMax * -1) + yPos && yBool == -1))
        {
            //Debug.Log("방향전환" + yBool);
            transform.position = new Vector3(transform.position.x, yPos + (yBool * yMax), transform.position.z);
            yBool *= -1;
        }
        else
        {
            transform.Translate(Vector3.up * yBool * ySpeed * Time.deltaTime);

        }
    }
}
