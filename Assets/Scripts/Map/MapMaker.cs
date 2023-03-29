using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMaker : MonoBehaviour
{
	public List<GameObject> stageMap1 = new List<GameObject>();
	public List<GameObject> stageMap2 = new List<GameObject>();

	private MapMove mapMove;

	private void Awake()
	{
		mapMove = GetComponent<MapMove>();
	}

	private void Update()
	{
		if (mapMove.currentDistance > mapMove.maxDistance)
		{
			int random = Random.Range(0, stageMap1.Count);

			mapMove.maxDistance = 20;
			mapMove.distance += mapMove.maxDistance;
			mapMove.currentDistance -= mapMove.maxDistance;
			GameObject go = Instantiate(stageMap1[random], transform.localPosition + Vector3.right * mapMove.distance, Quaternion.identity);
			go.transform.parent = transform;
		}
	}

}
