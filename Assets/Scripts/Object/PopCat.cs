using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopCat : MonoBehaviour
{
    [SerializeField] private Transform pointer;
    [SerializeField] private AudioClip popSound;
    private Pointer pnt;
    private Animator anim;

    private float speed = 10;
    private bool onPop;

    private void Awake()
    {
        pnt = pointer.GetComponent<Pointer>();
        anim = GetComponent<Animator>();
	}

    private void Update()
    {
        if (pnt.Following)
        {
            transform.position = Vector3.Lerp(transform.position, pointer.position - new Vector3(0.11f, 0.08f, 0), speed);
        }
        else if(!onPop)
        {
            onPop=true;
            StartCoroutine("Pop");
		}
    }

    private IEnumerator Pop()
    {
        yield return new WaitForSeconds(1);
        SetAnim(1);
		SoundManager.Instance.SFXPlay("Pop", popSound);
	}

    public void SetAnim(int an)
    {
		anim.SetInteger("Anim", an);
	}
}
