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

    int yBool = 1;
    public float yMax = 0.3f;
    public float ySpeed = 10;
    float yPos;
    int xBool = 1;
    public float xMax = 0.2f;
    public float xSpeed = 4;

    private void Awake()
    {
        anim = catHead.GetComponent<Animator>();
    }

    private void Start()
    {
        yPos = transform.position.y;
    }

    public void SetAnimation(CatAnimation catAnim)
    {
		anim.SetInteger("Anim", (int)CatAnimation.Nomal);
		anim.SetInteger("Anim", (int)catAnim);
        StopCoroutine("SetNomalAnim");
        if(catAnim == CatAnimation.Blink1 || catAnim == CatAnimation.Blink2)
        {
            StartCoroutine("SetNomalAnim");
        }
    }

    private IEnumerator SetNomalAnim()
    {
        yield return new WaitForSeconds(1f);
		anim.SetInteger("Anim", (int)CatAnimation.Nomal);
	}
}
