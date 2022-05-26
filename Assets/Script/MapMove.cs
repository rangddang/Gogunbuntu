using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMove : MonoBehaviour
{
    public float mapSpeed;
    public float x=0;
    public float saveX = 0;
    public GameObject[] Stage1Map;

    private void Start()
    {
        x += 20;
        saveX += 20;
    }

    private void Update()
    {
        
        if(!DataManager.Instance.PlayerDie)
        {
            transform.Translate(-mapSpeed * Time.deltaTime, 0, 0);
            mapSpeed += 0.1f * Time.deltaTime;
            x += mapSpeed * Time.deltaTime;
        }
        else
        {
            if(mapSpeed> 0)
                mapSpeed -= 35f * Time.deltaTime;
            else
                mapSpeed = 0;
            transform.Translate(-mapSpeed * Time.deltaTime, 0, 0);
        }
        if(x >= 20)
        {
            int ran;
            saveX += 20;
            if(Random.Range(1,10+1) <= 6)
                ran = Random.Range(0, 4);
            else
                ran = Random.Range(5, Stage1Map.Length);
            GameObject fish = Instantiate(Stage1Map[ran]) as GameObject;
            fish.transform.position += new Vector3(saveX, 0, 0);
            if (ran != 0 && ran != 3 && ran != 4)
            {
                saveX += 1;
            }
            fish.transform.SetParent(gameObject.transform, false);
            x -= 20;
            
        }
        
    }
}
