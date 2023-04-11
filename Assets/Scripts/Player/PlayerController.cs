using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private WireController wire;
	[SerializeField] private LayerMask jumpableGround;
    
    private PlayerSprite playerSprite;
	private PlayerActive playerActive;
    private Rigidbody rigid;

    private Transform currentHand;
    private Vector3 jumpHandPos;
    private Vector3 wireHandPos;

    private bool isJump = false;
    private bool isDead;
    private bool isWire;

    private void Awake()
    {
        playerSprite = transform.Find("PlayerSprite").GetComponent<PlayerSprite>();
        playerActive = GetComponent<PlayerActive>();
        rigid = GetComponent<Rigidbody>();
        currentHand = transform.Find("CurrentHandPosition").transform;
        jumpHandPos = transform.Find("JumpHandPosition").transform.localPosition;
        wireHandPos = transform.Find("WireHandPosition").transform.localPosition;
    }

    private void Update()
    {
		if (DataManager.Instance.isDead)
		{
            if(isDead)
                return;
			rigid.velocity = Vector3.up * 40f;
			GetComponent<CapsuleCollider>().enabled = false;
			transform.position = new Vector3(transform.position.x, transform.position.y, -1);
			playerSprite.SetAnimation(PlayerAnimation.Dead);
            isDead = true;
			return;
		}

		if (inputManager.InputJumpKey)
        {
            if (OnGrounded())
            {
                currentHand.localPosition = jumpHandPos;
                StartCoroutine("Jumping");
                playerActive.Jump();
                playerSprite.SetAnimation(PlayerAnimation.Jump);
            }
            else
            {
                playerActive.JumpShot();
				playerSprite.SetAnimation(PlayerAnimation.JumpShot);
			}
        }
        if (wire.OnWire && !isWire)
        {
            currentHand.localPosition = wireHandPos;
            isWire = true;
            playerActive.OnWire();
			playerSprite.SetAnimation(PlayerAnimation.Wire);
		}
        else if (wire.OnWire)
        {
            transform.up = (wire.transform.position - transform.position).normalized;
        }
        else if (!wire.OnWire && isWire)
        {
            transform.rotation = Quaternion.identity;
            isWire = false;
			playerSprite.SetAnimation(PlayerAnimation.Rolling);
		}
        if(OnGrounded() && !isJump)
        {
			playerSprite.SetAnimation(PlayerAnimation.Run);
            if (DeadCast() && !wire.OnWire)
            {
                gameManager.GameOver();
            }
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

    private bool DeadCast()
    {
        return !Physics.Raycast(transform.position, Vector3.down, 4f, jumpableGround);
	}
}
