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
    [SerializeField] private float changeSize = 2f;
    [SerializeField] private Vector3 offset;

    private float saveNomalSize;
    private float saveZoomSIze;

    private Camera camera;
    private float fieldOfView;
    private float transZ;
    private bool isZoomOut = false;

    private void Awake()
    {
        camera = GetComponent<Camera>();
    }

    private void Update()
    {
        UpdateCameraZoom();
    }

    private void Start()
    {
        fieldOfView = nomalSize;
        transZ = nomalZ;
        saveNomalSize = nomalSize;
        saveZoomSIze = zoomSize;
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

    private void UpdateCameraZoom()
    {
        nomalSize = saveNomalSize + (DataManager.Instance.Stage * changeSize);
        zoomSize = saveZoomSIze + (DataManager.Instance.Stage * changeSize);
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

}
