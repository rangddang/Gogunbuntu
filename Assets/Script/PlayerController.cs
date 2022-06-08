using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigid;
    public float jumpPower = 7f;
    public bool isGround;
    public MapMove map;
    public bool isHook;
    public bool useHook;
    private float hookRotate;
    public float hookRotateSpeed = 0f;
    public float maxRotate = 60f;
    public Animator anim;
    public bool isJump;
    public GameObject playerSprite;
    public Vector3 RopePos = new Vector3(1f, 0.8f, 0);
    public float RopeSize = 8;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Start()
    {
        //if(transform.)
    }

    
    void Update()
    {
        //Debug.DrawRay(transform.position + new Vector3(0.0f, -1f, 0), Vector3.down * 0.75f, Color.red);
        //플레이어가 죽지 않았을때 (!게임오버)
        if (!DataManager.Instance.PlayerDie)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))
            {//점프키를 눌렀을때
                isJump = true;
                Jump();
            }
            if (isHook && hookRotate < maxRotate)
            {//와이어를 발사하고 맞추면
                Hook();
            }
            if (hookRotate >= maxRotate)
            {//와이어를 다 탔을때
                rigid.useGravity = true;
                isHook = false;
                rigid.velocity = Vector3.up * 40f;
                hookRotate = 0f;
            }
            if(!isHook && useHook && !isGround)
            {//와이어를 다 타고 공중에 있을때
                playerSprite.transform.rotation *= Quaternion.Euler(0, 0, 1080f * Time.deltaTime);
                anim.SetInteger("Anim", 3);
            }
            else if (isGround)
            {//공중에서 땅으로 닿았을때
                playerSprite.transform.rotation = Quaternion.Euler(0, 0, 0);
                useHook=false;
            }
            if (!isGround)
            {
                //Dead Line(야메)
                //if (!isJump && (transform.position.y < -0.4f || transform.position.y > 0.4f))
                //    DataManager.Instance.PlayerDie = true;
                
            }

            //DeadLine();
        }
        else
        {
            if (GetComponent<CapsuleCollider>().enabled)
            {
                anim.SetBool("Player Die", true);
                transform.position += new Vector3(0, 0, -0.6f);
                rigid.velocity = Vector3.zero;
                rigid.velocity = Vector3.up * 90f;
                rigid.drag = 15f;
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
            anim.SetInteger("Anim", 4);
            RaycastHit hit;
            Debug.DrawRay(transform.position + new Vector3(0, 0, 0), RopePos * RopeSize, Color.yellow);
            if (Physics.Raycast(transform.position + new Vector3(0, 0, 0), RopePos, out hit, RopeSize))
            {
                if (!isHook && hit.collider.gameObject.tag == "Roof")
                {
                    maxRotate = 60f;
                    transform.position += new Vector3(0, hookRotate * -0.4f, 0);
                    isHook = true;
                    useHook = true;
                    hookRotate = -50;
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

        if (Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.Space))
        {
            rigid.useGravity = false;
            playerSprite.transform.rotation = Quaternion.Euler(0, 0, hookRotate);
            rigid.velocity = new Vector3(0, 0, 0);
            if(maxRotate > 60)
                maxRotate = 60;
            transform.position = new Vector3(transform.position.x, transform.position.y + hookRotate * 0.4f * Time.deltaTime, transform.position.z);
        }
        else{
            maxRotate = 50f;
            rigid.useGravity = true;
        }
    }

    //void DeadLine()
    //{
    //    RaycastHit hit;
    //    Debug.DrawRay(new Vector3(-2.1f, -0.4f, 0), (new Vector3(-0.01f,-1f,0)) * 2, Color.red);
    //    if (!Physics.Raycast(new Vector3(-2.1f, -0.4f, 0),new Vector3(-0.01f, -1f, 0), out hit, 2f))
    //    {
    //        if (isGround && !DataManager.Instance.PlayerDie)
    //        {
    //            DataManager.Instance.PlayerDie = true;
    //        }
    //    }
    //    else
    //    {
    //        if(isGround && hit.collider.gameObject.tag != "Ground")
    //        {
    //            DataManager.Instance.PlayerDie = true;
    //        }
    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            //isJump = false;
            playerSprite.transform.rotation = Quaternion.Euler(0, 0, 0);
            isGround = true;
            isJump = false;
            anim.SetInteger("Anim", 0);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            RaycastHit hit;
            if ((Physics.Raycast(transform.position + new Vector3(0.0f, -1f, 0), Vector3.down, out hit, 0.75f)))
            {
                if (hit.collider.gameObject.tag != "Ground")
                {
                    isGround = false;
                    anim.SetInteger("Anim", 1);
                }
            }
            else
            {
                isGround = false;
                anim.SetInteger("Anim", 1);
            }
        }
    }
}
