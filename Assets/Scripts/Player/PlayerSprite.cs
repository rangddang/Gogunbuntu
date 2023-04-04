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

	[SerializeField] private float rollSpeed = 1f;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

	public void SetAnimation(PlayerAnimation an)
	{
		anim.SetInteger("Anim", (int)an);
	}

	private IEnumerator Rolling()
	{
		while(anim.GetInteger("Anim") == 4)
		{
			transform.rotation *= Quaternion.Euler(0, 0, (360 * rollSpeed * Time.deltaTime));
			yield return null;
		}
		transform.rotation = Quaternion.identity;
	}
}
