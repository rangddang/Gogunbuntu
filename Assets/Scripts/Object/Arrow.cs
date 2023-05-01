using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private Pointer pointer;
    private SpriteRenderer sprite;
    [SerializeField] Sprite nomal;
    [SerializeField] Sprite yellow;

    private float time;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (pointer.Following)
        {
            sprite.sprite = yellow;
            time = 0;
		}
        else
        {
            sprite.sprite = nomal;
			time += Time.deltaTime;
		}

        if(time > 0.8f)
        {
            sprite.enabled = false;
        }
        else
        {
			sprite.enabled = true;
		}
    }
}
