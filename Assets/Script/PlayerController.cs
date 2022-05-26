using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigid;
    public float jumpPower = 7f;
    public bool isGround;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        OnGround();
        DeadLine();
        if (!DataManager.Instance.PlayerDie)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Jump();
            }
        }
        else
        {
            if (GetComponent<CapsuleCollider>().enabled)
            {
                transform.position += new Vector3(0, 0, -0.6f);
                rigid.drag = 20f;
                GetComponent<CapsuleCollider>().enabled = false;
            }
        }
    }

    void Jump()
    {
        if (isGround)
        {
            rigid.velocity = Vector3.up * jumpPower;
        }
        else
        {

            RaycastHit hit;
            Debug.DrawRay(transform.position + new Vector3(0, 0, 0), new Vector3(1f, 1f, 0) * 3f, Color.yellow);

            //if (Physics.Raycast(transform.position + new Vector3(0, 0, 0), new Vector3(1f, 1f, 0), out hit, 3f))
            //{
            //    //DataManager.Instance.PlayerDie = true;
            //}
        }
    }

    void OnGround()
    {
        //Debug.Log("ground");
        if (transform.position.y > -0.51f && transform.position.y < -0.47f)
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }
    }

    void DeadLine()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position + new Vector3(-0.1f, 0, 0), Vector3.down, out hit, 2f) == false)
        {
            if (isGround)
            {
                DataManager.Instance.PlayerDie = true;
            }
        }
    }

    //private void OnCollisionStay(Collision collision)
    //{
    //    isGround = true;
        
    //}

    //private void OnCollisionExit(Collision collision)
    //{
    //    if(transform.position.y <= 0.5f && transform.position.y > 0.49f)
    //        isGround = false;
    //}
}
