using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerAnimation
{
	Run,
	Jump,
	JumpShot,
	Wire,
	Rolling,
	Dead
}

public class PlayerSprite : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
	private Animator anim;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

	public void SetAnimation(PlayerAnimation an)
	{
		anim.SetInteger("Anim", (int)an);
	}
}
