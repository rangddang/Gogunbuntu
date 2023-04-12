using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireController : MonoBehaviour
{
    [SerializeField] private Transform playerHand;
    [SerializeField] private Vector3 shotPos;
    [SerializeField] private float shotSpeed = 10f;
    [SerializeField] private float maxDistance = 9f;
    [SerializeField] private LayerMask wireBuilding;

    private float wireDistance;
    public float WireDistance => wireDistance;

    private bool onWire;
    public bool OnWire => onWire;

    private LineRenderer line;
    private Transform DRB;
    private RaycastHit hit;
    private bool isWire;

    private void Awake()
    {
        DRB = transform.GetChild(0);
        line = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        DisableWire();
    }

    private void Update()
    {
        line.SetPosition(0, playerHand.position);
        line.SetPosition(1, transform.position);
    }

    public void ShotWire()
    {
        if(isWire)
            return;
        isWire = true;
        DRB.gameObject.SetActive(true);
        line.enabled = true;
        StartCoroutine("Shot");
    }

    public void DisableWire()
    {
		onWire = false;
		isWire = false;
		DRB.gameObject.SetActive(false);
		line.enabled = false;
        transform.parent = null;
	}

    private IEnumerator Shot()
    {
        Vector3 lastHandPos = playerHand.position;
        transform.position = lastHandPos;
        Vector3 targetPos = (shotPos - lastHandPos).normalized * maxDistance;
        wireDistance = Vector3.Distance(transform.position, targetPos + lastHandPos);

        transform.up = targetPos.normalized;

		while (wireDistance > 0f)
        {
			wireDistance = Vector3.Distance(transform.position, targetPos + lastHandPos);
			transform.position = Vector3.MoveTowards(transform.position, targetPos + lastHandPos, Time.deltaTime * shotSpeed);
            Debug.DrawRay(lastHandPos, targetPos - (targetPos.normalized * (maxDistance - wireDistance)), Color.white, 0.2f);
            if (Physics.Raycast(lastHandPos, targetPos.normalized, out hit, (maxDistance - wireDistance), wireBuilding))
            {
                Target();
                break;
            }
            yield return null;
        }
        if(wireDistance == 0f)
            DisableWire();
    }

    private void Target()
    {
        transform.parent = hit.transform.parent.parent.parent.parent;
		onWire = true;
    }
}
