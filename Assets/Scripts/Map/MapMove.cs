using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapMove : MonoBehaviour
{
	[SerializeField] private GameManager gameManager;
	[SerializeField] private float currentMapSpeed;
	[SerializeField] private float moveSpeed = 14;
	[SerializeField] private float changeSpeed = 6f;

	public float distance = 0;
	public float currentDistance = 0;

	public float maxDistance = 0;

	private void Start()
	{
		StartCoroutine("ChangeStage");
	}

	private void Update()
	{
		if (DataManager.Instance.isDead)
			return;

		currentMapSpeed = moveSpeed + (DataManager.Instance.Stage * changeSpeed);
		currentDistance += Time.deltaTime * currentMapSpeed;
		transform.position += Vector3.left * Time.deltaTime * currentMapSpeed;
	}

	public void StopStage()
	{
		StopCoroutine("ChangeStage");
	}

	private IEnumerator ChangeStage()
	{
		yield return new WaitForSeconds(17f);
		UpdateStage();
		yield return new WaitForSeconds(27f);
		UpdateStage();
		yield return new WaitForSeconds(35f);
		Debug.Log("게임 클리어");
	}

	private void UpdateStage()
	{
		gameManager.SpeedUp();
	}
}
