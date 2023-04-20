using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapMove : MonoBehaviour
{
	[SerializeField] private GameManager gameManager;
	[SerializeField] private float currentMapSpeed;
	[SerializeField] private float moveSpeed = 14;
	[SerializeField] private float changeSpeed = 6f;
	[SerializeField] private List<float> stageTime;

	public int MaxStage => stageTime.Count;

	public float distance = 0;
	public float currentDistance = 0;
	public float time = 0;
	public float maxTime;

	public float maxDistance = 0;

	private void Start()
	{
		//if(stageTime.Count - 1 <= DataManager.Instance.Stage)
		maxTime = stageTime[DataManager.Instance.Stage];
	}

	private void Update()
	{
		if (DataManager.Instance.isDead)
			return;

		currentMapSpeed = moveSpeed + (DataManager.Instance.Stage * changeSpeed);
		currentDistance += Time.deltaTime * currentMapSpeed;
		transform.position += Vector3.left * Time.deltaTime * currentMapSpeed;

		time += Time.deltaTime;

		if (time > maxTime && DataManager.Instance.Stage + 1 < MaxStage)
		{
			UpdateStage();
			time -= maxTime;
			maxTime = stageTime[DataManager.Instance.Stage];
		}
		else if(time > maxTime && DataManager.Instance.Stage + 1 >= MaxStage)
		{
			gameManager.Ending();
		}
	}

	private void UpdateStage()
	{
		gameManager.SpeedUp();
	}
}
