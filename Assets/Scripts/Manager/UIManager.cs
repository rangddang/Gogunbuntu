using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject GameOverPanel;

    private void Start()
    {
        GameOverPanel.SetActive(false);
    }

    private void Update()
    {
        if (DataManager.Instance.isDead)
        {
            GameOverPanel.SetActive(true);
        }
    }
}
