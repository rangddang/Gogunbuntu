using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigid;
    public float jumpPower = 7f;
    public bool isGround;
    Vector3 hookPos;
    public MapMove map;
    public Transform playerPos;
    public bool isHook;
    private float hookRotate;
    public float hookRotateSpeed = 0f;

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
        if (!DataManager.Instance.PlayerDie)
        {
            DeadLine();
            if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
            if (isHook && hookRotate < 70)
            {
                Hook();
            }
            else
            {
                isHook = false;
                //rigid.drag = 0.5f;
                hookRotate = 0f;
                transform.rotation = Quaternion.Euler(0, 0, 0);
                rigid.useGravity = true;
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

            //RaycastHit hit;
            //Debug.DrawRay(transform.position + new Vector3(0, 0, 0), new Vector3(1f, 1f, 0) * 3f, Color.yellow);
            if (isHook)
            {
                transform.position += new Vector3(0, hookRotate * -0.4f, 0);
                isHook = true;
                hookRotate = -70;
            }
            //hookPos = transform.position + new Vector3(2, 3, 0);

            //if (Physics.Raycast(transform.position + new Vector3(0, 0, 0), new Vector3(1f, 1f, 0), out hit, 3f))
            //{
            //    //DataManager.Instance.PlayerDie = true;
            //}
        }
    }

    void Hook()
    {
        //rigid.velocity = hookPos;
        //hookPos -= new Vector3(map.mapSpeed * Time.deltaTime,0,0);
        rigid.useGravity = false;
        hookRotate += hookRotateSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, 0, hookRotate);
        //rigid.drag = 5f;
        //rigid.AddForce(Vector3.up * 2,ForceMode.Impulse);
        rigid.velocity = new Vector3(0, 0, 0);
        transform.position = new Vector3(transform.position.x, transform.position.y + hookRotate * 0.4f * Time.deltaTime, transform.position.z);
        if (hookRotate > -10 && !Input.GetKey(KeyCode.Mouse0))
        {
            hookRotate = 70;
        }
    }

    void OnGround()
    {
        //Debug.Log("ground");
        if (playerPos.transform.position.y > -1.51f && playerPos.transform.position.y < -1.47f)
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
        Debug.DrawRay(new Vector3(-2f, -0.4f, 0), Vector3.down * 2, Color.red);
        if (!(Physics.Raycast(new Vector3(-2f, -0.4f, 0), Vector3.down, out hit, 2f)))
        {
            if (isGround)
            {
                DataManager.Instance.PlayerDie = true;
            }
        }
        //Debug.Log(hit.collider.gameObject.name);
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
