using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Police : MonoBehaviour, IInteractable
{
	[SerializeField] private float moveSpeed = 8f;
	private Transform playerTransform;
	private bool canChasePlayer = false;
	Rigidbody rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		playerTransform = FindObjectOfType<PlayerMovement>().transform;
	}
	public void Intreact()
	{
		AudioManager.Instance.Play("Alarm");
		canChasePlayer = true;
		StartCoroutine(ActiveText());
	}

	private void Update()
	{
		if(Vector3.Distance(playerTransform.position, transform.position) < 5f)
		{
			canChasePlayer = false;
			GameMaster.Instance.LevelFailed();
		}
	}

	private void FixedUpdate()
	{
		if (canChasePlayer)
			ChasePlayer();
	}

	private void ChasePlayer()
	{
		Vector3 dir = playerTransform.position - transform.position;
		transform.forward = dir.normalized;
		rb.MovePosition(transform.position + dir.normalized * moveSpeed * Time.fixedDeltaTime);
	}

	IEnumerator ActiveText()
	{
		transform.GetChild(0).gameObject.SetActive(true);
		yield return new WaitForSeconds(2f);
		transform.GetChild(0).gameObject.SetActive(false);
	}
}
