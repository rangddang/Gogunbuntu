using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageBar : MonoBehaviour
{
    [SerializeField] private MapMove map;
    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void Update()
    {
        if (DataManager.Instance.isDead) return;
        slider.value = (map.time / map.maxTime) * (1f / map.MaxStage) + (1f / map.MaxStage) * DataManager.Instance.Stage;
    }
}
