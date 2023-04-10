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


	private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    public void Jump()
    {
        rigid.velocity = Vector3.up * jumpPower;
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

    private IEnumerator Wire()
    {
		rigid.useGravity = false;
		rigid.isKinematic = true;
        float transY = transform.position.y;
        float veloY = 0;
        float gra = 9.8f;
        float graScale = 9;
        float rev = 19f * wire.WireDistance * 0.12f;
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
        Jump();
		wire.DisableWire();
	}
}
