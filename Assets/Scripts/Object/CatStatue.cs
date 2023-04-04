using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CatAnimation
{
    Nomal,
    Blink1,
    Blink2,
    Suprising,
	Laugh
}

public class CatStatue : MonoBehaviour
{
    [SerializeField] private Transform catHead;
    private Animator anim;

    int yBool = 1;
    public float yMax = 0.3f;
    public float ySpeed = 10;
    float yPos;
    int xBool = 1;
    public float xMax = 0.2f;
    public float xSpeed = 4;

    private void Awake()
    {
        anim = catHead.GetComponent<Animator>();
    }

    private void Start()
    {
        yPos = transform.position.y;
    }

    public void SetAnimation(CatAnimation catAnim)
    {
        anim.SetInteger("Anim", (int)catAnim);
    }

    private void Update()
    {
        //Sup();

        if (DataManager.Instance.isDead)
        {
            PlayerDead();
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
            return;
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
}
