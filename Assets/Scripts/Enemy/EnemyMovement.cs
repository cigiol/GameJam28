using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyMovement : MonoBehaviour
{
	[Header("Move Logic")]
    [SerializeField] private Transform[] walkPoints;
	[SerializeField] private float moveSpeed = 4f;
    private int positionIndex = 0;
	private int positionIndexSetter = -1;
	private bool isMoving = true;

	private float rotationSpeed = 5f;

	Rigidbody rb;

	private void Start()
	{
		positionIndexSetter = -1;
		rb = GetComponent<Rigidbody>();
		positionIndex = 0;
		isMoving = true;
	}

	void Update()
    {
		//Bir sonraki y�r�me noktas�na var�p varmad���n� kontrol ediyor
        if(isMoving && Vector3.Distance(transform.position, walkPoints[positionIndex].position) <= 0.2f)
		{
			//Son noktaya gelince ilerleme y�n�n� ters �evirip tersten ilerliyor, en ba�a gelince de tekrar ileri gitmesini sa�l�yor
			//ilk ve son nokta aras�nda s�rekli bir d�ng� olu�turuyor
			if (positionIndex <= 0 || positionIndex >= walkPoints.Length - 1)
			{
				positionIndexSetter *= -1;
			}
			positionIndex += positionIndexSetter;
		}

		MoveToNextPoint();
	}

	//Daha p�r�zs�z d�n��ler i�in late update i�inde �a��r�yoruz d�nme fonksiyonunu
	private void LateUpdate()
	{
		LookAtWalkPoint();
	}

	//Bir sonraki y�r�me noktas�na ilerleme
	private void MoveToNextPoint()
	{
		isMoving = true;
		Vector3 dir = walkPoints[positionIndex].position - transform.position;
		rb.MovePosition(transform.position + dir.normalized * moveSpeed * Time.fixedDeltaTime);
	}

	//Gitti�i y�ne bakma
	private void LookAtWalkPoint()
	{
		Quaternion lookRotation = Quaternion.LookRotation(walkPoints[positionIndex].position - transform.position);

		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
	}
}
