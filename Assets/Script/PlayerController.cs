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
                rigid.velocity = rigid.velocity = Vector3.up * 5f;
                rigid.drag = 5f;
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
            //rigid.velocity = Vector3.up * jumpPower * 1.5f;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        isGround = true;
        //RaycastHit hit;
        //if (Physics.Raycast(transform.position, Vector3.down, out hit, 2f) == false)
        //{
        //    DataManager.Instance.PlayerDie = true;
        //}
    }

    private void OnCollisionExit(Collision collision)
    {
        isGround = false;
    }
}
