using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private PlayerSprite playerSprite;
	[SerializeField] private LayerMask jumpableGround;

	private PlayerActive playerActive;

    private bool isJump = false;

    private void Awake()
    {
        playerActive = GetComponent<PlayerActive>();
    }

    private void Update()
    {
		if (DataManager.Instance.isDead)
		{
			playerSprite.SetAnimation(PlayerAnimation.Dead);
            return;
		}

		if (inputManager.InputJumpKey)
        {
            if (OnGrounded())
            {
                StartCoroutine("Jumping");
                playerActive.Jump();
                playerSprite.SetAnimation(PlayerAnimation.Jump);
            }
            else
            {
				playerSprite.SetAnimation(PlayerAnimation.JumpShot);
			}
        }
        if(OnGrounded() && !isJump)
        {
			playerSprite.SetAnimation(PlayerAnimation.Run);
		}
	}

    private IEnumerator Jumping()
    {
        isJump = true;
        yield return new WaitForSeconds(0.1f);
        isJump = false;
    }

	private bool OnGrounded()
	{
        return Physics.BoxCast(transform.position, new Vector3(1.5f, 0.2f, 1f) * 0.5f, Vector3.down, Quaternion.identity, 1.5f, jumpableGround);
	}
}
