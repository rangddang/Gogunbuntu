using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
	public static InputManager Instance;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(Instance);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public KeyCode[] jumpKeys;
	//private int idx = -1;

    public bool GetJumpKey()
    {
		int jumpKeyCount = 0;
		for (int i = 0; i < jumpKeys.Length; i++)
		{
			if (Input.GetKeyDown(jumpKeys[i]))
			{
				jumpKeyCount++;
			}
		}
		return jumpKeyCount > 0 ? true : false;
	}

	//private void OnGUI()
	//{
	//	Event keyEvent = Event.current;
	//	if (keyEvent.isKey && idx != -1)
	//	{
	//		jumpKeys[idx] = keyEvent.keyCode;
	//		idx = -1;
	//	}
	//}

	//public void ChangeButton(int index)
	//{
	//	idx = index;
	//}
}
