using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
	[SerializeField] private LayerMask jumpableGround;

	private PlayerActive playerActive;

    private void Awake()
    {
        playerActive = GetComponent<PlayerActive>();
    }

    private void Update()
    {
        if (inputManager.InputJumpKey && OnGrounded())
        {
            playerActive.Jump();
        }
	}

	private bool OnGrounded()
	{
        return Physics.BoxCast(transform.position, new Vector3(1.5f, 0.3f, 1f) * 0.5f, Vector3.down, Quaternion.identity, 1.6f, jumpableGround);
	}
}
