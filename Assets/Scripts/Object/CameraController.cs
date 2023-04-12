using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float nomalSize = 60f;
    [SerializeField] private float nomalZ = -11f;
    [SerializeField] private float zoomSize = 70f;
    [SerializeField] private float zoomZ = -9;
    [SerializeField] private float zoomSpeed = 5f;
    [SerializeField] private Vector3 offset;

    private Camera camera;
    private float fieldOfView;
    private float transZ;
    private bool isZoomOut = false;

    private void Awake()
    {
        camera = GetComponent<Camera>();
    }

    private void Start()
    {
        fieldOfView = nomalSize;
        transZ = nomalZ;
    }

    private void FixedUpdate()
    {
		//transform.position = new Vector3(transform.position.x, player.position.y * 0.5f + 3.5f, transform.position.z);
	}

    public void ZoomInCamera()
    {
        StopCoroutine("ZoomOut");
		isZoomOut = false;
		transform.position = offset;
        StartCoroutine("ZoomIn");
    }
	public void ZoomOutCamera()
	{
        StopCoroutine("ZoomIn");
		if (!isZoomOut)
        {
            isZoomOut = true;
		    StartCoroutine("ZoomOut");
        }
	}

    private IEnumerator ZoomIn()
    {
        while (true)
        {
            transZ = Mathf.Lerp(transZ, zoomZ, Time.deltaTime * zoomSpeed);
            fieldOfView = Mathf.Lerp(fieldOfView, zoomSize, Time.deltaTime * zoomSpeed);

			transform.position = Vector3.Lerp(transform.position, new Vector3(player.position.x, player.position.y, transZ), Time.deltaTime * zoomSpeed);
            camera.fieldOfView = fieldOfView;
            yield return null;
        }
    }


	private IEnumerator ZoomOut()
	{
        transZ = nomalZ;
		while (true)
		{
			fieldOfView = Mathf.Lerp(fieldOfView, nomalSize, Time.deltaTime * zoomSpeed);

			transform.position = Vector3.Lerp(transform.position, offset, Time.deltaTime * zoomSpeed);
			camera.fieldOfView = fieldOfView;
			yield return null;
		}
	}

    //public void Jump()
    //{
    //    StartCoroutine("JumpCameraMove");
    //}

    //private IEnumerator JumpCameraMove()
    //{
    //    while (true)
    //    {
    //        transform.position = new Vector3(transform.position.x, player.position.y * 0.5f + 3.5f, transform.position.z);
    //        yield return null;
    //    }
    //}
}
