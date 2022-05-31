using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapMove : MonoBehaviour
{
    public float mapSpeed;
    public float x=0;
    public float saveX = 0;
    public GameObject[] StageMap;
    public Slider StageSlider;


    private void Start()
    {
        x += 20;
        //saveX += 20;
    }

    private void Update()
    {
        
        if(!DataManager.Instance.PlayerDie)
        {
            transform.Translate(-mapSpeed * Time.deltaTime, 0, 0);
            mapSpeed += 0.1f * Time.deltaTime;
            StageSlider.value = (mapSpeed - 13) * 0.02f;
            x += mapSpeed * Time.deltaTime;
        }
        else
        {
            if(mapSpeed> 0)
                mapSpeed -= 50f * Time.deltaTime;
            else
                mapSpeed = 0;
            transform.Translate(-mapSpeed * Time.deltaTime, 0, 0);
        }
        if(x >= 20)
        {
            int ran;
            saveX += 20;
            if (Random.Range(1, 10 + 1) <= 6)
                ran = Random.Range(0, 4);
            else
                ran = Random.Range(4, StageMap.Length);
            GameObject fish = Instantiate(StageMap[ran]) as GameObject;
            fish.transform.position += new Vector3(saveX, 0, 0);
            if (ran >= 16 && ran <= 21)
            {
                x -= 8;
                saveX += 8;
            }
            fish.transform.SetParent(gameObject.transform, false);
            x -= 20;
            
        }
        
    }
}
