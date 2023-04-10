using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public List<KeyCode> jumpKeys = new List<KeyCode>();
    private bool inputJumpKey;
    public bool InputJumpKey => inputJumpKey;


    private void Update()
    {
		GetJumpKey();
	}

    private void GetJumpKey()
    {
		int jumpKeyCount = 0;
		for (int i = 0; i < jumpKeys.Count; i++)
		{
			if (Input.GetKeyDown(jumpKeys[i]))
			{
				jumpKeyCount++;
				inputJumpKey = true;
			}
		}
		inputJumpKey = jumpKeyCount > 0 ? true : false;
	}
}
