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

    }
}
