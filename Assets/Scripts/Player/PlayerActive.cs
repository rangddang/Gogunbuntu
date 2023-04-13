using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActive : MonoBehaviour
{
    private Rigidbody rigid;

    [SerializeField] private SoundManager soundManager;
    [SerializeField] private AudioClip jumpSound;
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
        // 2스테이지 갔을때 점프판정 막막한거 방지용
        if(DataManager.Instance.Stage > 0)
            currentJumpPower = jumpPower + 3;
        rigid.velocity = Vector3.up * currentJumpPower;
        soundManager.SFXPlay("Jump", jumpSound);
    }

    public void JumpShot()
    {
        wire.ShotWire();
    }

    public void OnWire()
    {
        StartCoroutine("Wire");
    }

	private void WireJump()
	{
		rigid.velocity = Vector3.up * jumpPower * 1.2f;
	}

	private IEnumerator Wire()
    {
		rigid.useGravity = false;
		rigid.isKinematic = true;
        float transY = transform.position.y;
        float veloY = 0;
        float gra = 9.8f;
        float graScale = 12;
        float rev = 20f * wire.WireDistance * 0.15f;
        veloY -= rev;
        do
        {
            veloY += gra * graScale * Time.deltaTime;
            transform.position += Vector3.up * veloY * Time.deltaTime;
            yield return null;
        }
        while (transY > transform.position.y);
		rigid.useGravity = true;
		rigid.isKinematic = false;
        WireJump();
		wire.DisableWire();
	}
}
