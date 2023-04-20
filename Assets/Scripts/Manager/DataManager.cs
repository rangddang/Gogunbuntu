using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    static DataManager instance;

    public static DataManager Instance
    {
        get
        {
            return instance;
        }
    }
    private void Awake()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int Score = 0;
    public int BestScore = 0;
    public int Stage = 0;
    public bool isDead = false;
    public bool isEnd = false;

}
