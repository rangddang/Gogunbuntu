using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPanel : MonoBehaviour
{
    private Animator panelAnim;

    private void Awake()
    {
        panelAnim = transform.GetChild(0).GetComponent<Animator>();
    }

    private void Start()
    {
        CloseAnim();
		gameObject.SetActive(false);
    }

    public void OpenAnim()
    {
        panelAnim.SetBool("IsOpen", true);
    }

    public void CloseAnim()
    {
		panelAnim.SetBool("IsOpen", false);
	}
}
