using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatStatue : MonoBehaviour
{
    int yBool = 1;
    public float yMax = 1;
    public float ySpeed = 3;
    float yPos;
    int xBool = 1;
    public float xMax = 1;
    public float xSpeed = 3;
    public Animator anim;
    public int randInt;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        yPos = transform.position.y;
        StartCoroutine(rRand());
    }

    void Update()
    {
        //Sup();
        
        if (DataManager.Instance.PlayerDie)
        {
            PlayerDead();
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
            anim.SetBool("Player Die", true);
        }
        else
        {
            switch (randInt)
            {
                case 0:
                    anim.SetBool("Sup", false);
                    anim.SetInteger("Blink", 0);
                    break;
                case 1:
                    anim.SetInteger("Blink", 1);
                    break;
                case 2:
                    anim.SetInteger("Blink", 2);
                    break;
                case 3:
                    anim.SetInteger("Blink", 0);
                    anim.SetBool("Sup", true);
                    Sup();
                    break;
            }
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

    void Sup()
    {
        if ((transform.position.x > xMax && xBool == 1) || (transform.position.x < -xMax && xBool ==-1))
        {
            transform.position = new Vector3(xBool * xMax, transform.position.y, transform.position.z);
            xBool *= -1;
        }
        else
        {
            transform.Translate(Vector3.right * xBool * xSpeed * Time.deltaTime);

        }
    }

    IEnumerator rRand()
    {
        while (!DataManager.Instance.PlayerDie)
        {
            yield return new WaitForSeconds(Random.Range(5f,10f));
            randInt = Random.Range(0, 4);
            if(randInt == 1)
                yield return new WaitForSeconds(0.4f);
            else if (randInt == 2)
                yield return new WaitForSeconds(2f);
            else
                yield return new WaitForSeconds(3f);
            randInt = 0;
        }
    }
}
