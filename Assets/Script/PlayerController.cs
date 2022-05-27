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
        //PlayerPosSet();
        //OnGround();
        //Debug.DrawRay(transform.position + new Vector3(0.1f, -0.8f, 0), Vector3.down * 0.52f, Color.red);
        if (!DataManager.Instance.PlayerDie)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))
            {
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
                transform.rotation *= Quaternion.Euler(0, 0, 720f * Time.deltaTime);
            }
            else if (isGround)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                useHook=false;
            }
            DeadLine();
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
                }
            }
        }
    }

    void Hook()
    {
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
            maxRotate = 30f;
            rigid.useGravity = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void DeadLine()
    {
        RaycastHit hit;
        Debug.DrawRay(new Vector3(-2.0f, -0.4f, 0), (Vector3.down + new Vector3(0.1f,0,0)) * 2, Color.red);
        if (!(Physics.Raycast(new Vector3(-2.0f, -0.4f, 0), Vector3.down + new Vector3(0.1f, 0, 0), out hit, 2f)))
        {
            if (isGround && !DataManager.Instance.PlayerDie)
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
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            RaycastHit hit;
            
            if ((Physics.Raycast(transform.position + new Vector3(0.1f, -0.8f, 0), Vector3.down, out hit, 0.52f)))
            {
                if(hit.collider.gameObject.tag != "Ground")
                    isGround = false;
            }
            else
            {
                isGround = false;
            }
        }
    }

}
