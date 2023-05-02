using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
	[SerializeField] private GameManager gameManager;
	[SerializeField] private Transform popCat;
	[SerializeField] private List<AudioClip> moveSound;
	private bool following;
	public bool Following => following;
	private float speed;
	private bool isMove = false;
	private void Start()
	{
		GoToMid();
	}

	private void GoToMid()
	{
		StartCoroutine("MovePointer");
	}

	public void GoToRight()
	{
		StartCoroutine("MoveToPointer");
	}

	private IEnumerator MovePointer()
	{
		following = true;
		isMove = true;
		StartCoroutine(Move(0));
		while (isMove)
		{
			yield return null;
		}
		transform.position = Vector3.zero;
		following = false;
		float y = Random.Range(-0.5f, 3.0f);
		while (transform.position.x < 3.6f)
		{
			speed = Random.Range(3f, 20f);
			transform.position = Vector3.Lerp(transform.position, new Vector3(3.7f, y, 0), Time.deltaTime * speed);
			yield return null;
		}
	}

	private IEnumerator MoveToPointer()
	{
		while (Vector3.Distance(transform.position, popCat.position) > 0.03f)
		{
			speed = Random.Range(3f, 10f);
			transform.position = Vector3.Lerp(transform.position, popCat.position, Time.deltaTime * speed);
			yield return null;
		}

		following = true;
		isMove = true;
		StartCoroutine(Move(5));
		while (isMove)
		{
			yield return null;
		}
		following = false;
		gameManager.GoToMain();
	}

	private IEnumerator Move(int X)
	{
		float saveY = transform.position.y;
		bool pop = false;
		while (transform.position.x < X)
		{
			saveY = transform.position.y;
			speed = Random.Range(0.1f, 3f);
			transform.position += Vector3.right * Time.deltaTime * speed;
			transform.position = new Vector3(transform.position.x, (Mathf.Abs(Mathf.Sin(transform.position.x * 5.5f)) * 0.4f), 0);
			if (transform.position.y < saveY && !pop)
			{
				pop = true;
			}
			if (transform.position.y > saveY && pop)
			{
				pop = false;
				SoundManager.Instance.SFXPlay("Move", moveSound[Random.Range(0, moveSound.Count)]);
			}
			yield return null;
		}
		isMove = false;
	}
}
