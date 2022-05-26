using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CludeMake : MonoBehaviour
{
    public GameObject Clude;
    private void Start()
    {
        StartCoroutine(MakeClude());
    }

    IEnumerator MakeClude()
    {
        while (true)
        {
            GameObject it = Instantiate(Clude);
            it.transform.position = new Vector3(40, Random.Range(-5f, -2f), Random.Range(8f, 10f));
            yield return new WaitForSeconds(Random.Range(0.3f, 1f));
        }
    }
}
