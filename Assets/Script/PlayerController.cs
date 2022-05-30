using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigid;
    public float jumpPower = 7f;
    public bool isGround;
    public MapMove map;
    public Transform playerPos;
    public bool isHook;
    public bool useHook;
    private float hookRotate;
    public float hookRotateSpeed = 0f;
    public float maxRotate = 60f;
    public Animator anim;
    public bool isJump;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        //if(transform.)
    }

    
    void Update()
    {
        //PlayerPosSet();
        //OnGround();
        //Debug.DrawRay(transform.position + new Vector3(0.1f, -0.8f, 0), Vector3.down * 0.73f, Color.red);
        if (!DataManager.Instance.PlayerDie)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))
            {
                isJump = true;
                Jump();
            }
            if (isHook && hookRotate < maxRotate)
            {
                Hook();
            }
            if (hookRotate >= maxRotate)
            {
                rigid.useGravity = true;
                isHook = false;
                rigid.velocity = Vector3.up * 35f;
                hookRotate = 0f;
            }
            if(!isHook && useHook && !isGround)
            {
                transform.rotation *= Quaternion.Euler(0, 0, 1080f * Time.deltaTime);
                anim.SetInteger("Anim", 3);
            }
            else if (isGround)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                useHook=false;
            }
            //DeadLine();
        }
        else
        {
            if (GetComponent<SphereCollider>().enabled)
            {
                anim.SetBool("Player Die", true);
                transform.position += new Vector3(0, 0, -0.6f);
                rigid.velocity = Vector3.zero;
                rigid.velocity = Vector3.up * 90f;
                rigid.drag = 15f;
                GetComponent<SphereCollider>().enabled = false;
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
            anim.SetInteger("Anim", 4);
            RaycastHit hit;
            Debug.DrawRay(transform.position + new Vector3(0, 0, 0), new Vector3(1f, 0.8f, 0) * 8f, Color.yellow);
            if (Physics.Raycast(transform.position + new Vector3(0, 0, 0), new Vector3(1f, 0.8f, 0), out hit, 8f))
            {
                if (!isHook && hit.collider.gameObject.tag == "Roof")
                {
                    maxRotate = 60f;
                    transform.position += new Vector3(0, hookRotate * -0.4f, 0);
                    isHook = true;
                    useHook = true;
                    hookRotate = -30;
                    anim.SetInteger("Anim", 2);
                }
            }
        }
    }

    void Hook()
    {
        isJump = true;
        hookRotate += hookRotateSpeed * Time.deltaTime;
        if (hookRotate > maxRotate) hookRotate = maxRotate;

        if (Input.GetKey(KeyCode.Mouse0))
        {
            rigid.useGravity = false;
            transform.rotation = Quaternion.Euler(0, 0, hookRotate);
            rigid.velocity = new Vector3(0, 0, 0);
            transform.position = new Vector3(transform.position.x, transform.position.y + hookRotate * 0.4f * Time.deltaTime, transform.position.z);
        }
        else{
            maxRotate = 50f;
            rigid.useGravity = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void DeadLine()
    {
        RaycastHit hit;
        Debug.DrawRay(new Vector3(-2.1f, -0.4f, 0), (new Vector3(-0.01f,-1f,0)) * 2, Color.red);
        if (!Physics.Raycast(new Vector3(-2.1f, -0.4f, 0),new Vector3(-0.01f, -1f, 0), out hit, 2f))
        {
            if (isGround && !DataManager.Instance.PlayerDie)
            {
                DataManager.Instance.PlayerDie = true;
            }
        }
        else
        {
            if(isGround && hit.collider.gameObject.tag != "Ground")
            {
                DataManager.Instance.PlayerDie = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGround = true;
            anim.SetInteger("Anim", 0);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            RaycastHit hit;
            //임마 문제 없음
            if ((Physics.Raycast(transform.position + new Vector3(0.1f, -0.8f, 0), Vector3.down, out hit, 0.73f)))
            {
                if (hit.collider.gameObject.tag != "Ground")
                {
                    if (!isJump)
                        DataManager.Instance.PlayerDie = true;

                    isJump = false;
                    isGround = false;
                    anim.SetInteger("Anim", 1);
                }
            }
            //임마가 문제임;;
            else
            {
                if (!isJump)
                    DataManager.Instance.PlayerDie = true;

                isGround = false;
                isJump = false;
                anim.SetInteger("Anim", 1);
            }
        }
    }

}
