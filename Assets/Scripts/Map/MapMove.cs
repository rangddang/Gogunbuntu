using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapMove : MonoBehaviour
{
	[SerializeField] private float moveSpeed = 14;

	public float distance = 0;
	public float currentDistance = 0;

	public float maxDistance = 0;

	private void Update()
	{
		if (DataManager.Instance.PlayerDie)
			return;
		currentDistance += Time.deltaTime * moveSpeed;
		transform.position += Vector3.left * Time.deltaTime * moveSpeed;
	}

}
