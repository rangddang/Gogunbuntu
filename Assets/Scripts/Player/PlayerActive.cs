using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActive : MonoBehaviour
{
    private Rigidbody rigid;
    [SerializeField] private AudioClip jumpSound;
	[SerializeField] private AudioClip wireSound;
	[SerializeField] private WireController wire;

    [SerializeField] private float jumpPower = 25f;
    private float currentJumpPower;

	private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        currentJumpPower = jumpPower;
    }

    public void Jump()
    {
        rigid.velocity = Vector3.up * currentJumpPower;
        SoundManager.Instance.SFXPlay("Jump", jumpSound);
    }

    public void JumpShot()
    {
        wire.ShotWire();
	}

    public void OnWire()
    {
		SoundManager.Instance.SFXPlay("Wire", wireSound);
        StartCoroutine("Wire");
	}

    private void WireJump()
    {
        if(DataManager.Instance.Stage < 2)
        {
			rigid.useGravity = true;
			rigid.isKinematic = false;
			rigid.velocity = Vector3.up * jumpPower * 1.3f;
		}
        else
        {
            StartCoroutine("WireJumping");
        }
    }

	private IEnumerator Wire()
    {
		rigid.useGravity = false;
		rigid.isKinematic = true;
        float transY = transform.position.y;
        float veloY = 0;
        float gra = 9.8f;
        float graScale = 14;
        float rev = 15f + wire.WireDistance * 1.2f;
        veloY -= rev;
        do
        {
            veloY += gra * graScale * Time.deltaTime;
            transform.position += Vector3.up * veloY * Time.deltaTime;
            yield return null;
        }
        while (transY > transform.position.y);
        WireJump();
		wire.DisableWire();
	}

    private IEnumerator WireJumping()
    {
        while(transform.position.y < 7.5f)
        {
            transform.position += Vector3.up * jumpPower * Time.deltaTime;
            yield return null;
        }
		rigid.useGravity = true;
		rigid.isKinematic = false;
        rigid.velocity = Vector3.up * 6f;
	}
}
