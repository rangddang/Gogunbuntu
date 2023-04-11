using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CatAnimation
{
    Nomal,
    Blink1,
    Blink2,
    Suprising,
	Laugh
}

public class CatStatue : MonoBehaviour
{
    [SerializeField] private Transform catHead;
    private Animator anim;
    private float waitSec;

    private void Awake()
    {
        anim = catHead.GetComponent<Animator>();
    }

    public void SetAnimation(CatAnimation catAnim)
    {
		anim.SetInteger("Anim", (int)CatAnimation.Nomal);
		anim.SetInteger("Anim", (int)catAnim);
        StopCoroutine("SetNomalAnim");
        if(catAnim == CatAnimation.Blink1 || catAnim == CatAnimation.Blink2)
        {
            waitSec = 1;
            StartCoroutine("SetNomalAnim");
        }
		if (catAnim == CatAnimation.Suprising)
		{
            waitSec = 5;
			StartCoroutine("SetNomalAnim");
		}
	}

    private IEnumerator SetNomalAnim()
    {
        yield return new WaitForSeconds(waitSec);
		anim.SetInteger("Anim", (int)CatAnimation.Nomal);
	}
}
