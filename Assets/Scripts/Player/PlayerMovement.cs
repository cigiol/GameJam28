using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    Rigidbody rb;
    Vector3 moveInput;

    private float rotationSpeed = 5f;
    private bool isMoving = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Hareket edip etmedi�ini kontrol et
        if (moveInput.magnitude > 0f)
            isMoving = true;
        else
            isMoving = false;

        //Yatay ve dikey inputlar� al�yor
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
    }

	private void FixedUpdate()
	{
        MovePlayer();
	}

    //Daha p�r�zs�z d�n��ler i�in late update i�inde �a��r�yoruz d�nme fonksiyonunu
    private void LateUpdate()
    {
        LookAtWalkPoint();
    }

    void MovePlayer()
	{
        //Karakterimizi rigidbody kullanarak hareket ettiriyor
        rb.MovePosition(transform.position + moveInput.normalized * moveSpeed * Time.fixedDeltaTime);
	}

    //Gitti�i y�ne bakma
    private void LookAtWalkPoint()
    {
        if (!isMoving)
            return;
        
        Quaternion lookRotation = Quaternion.LookRotation(moveInput);
        lookRotation.eulerAngles = new Vector3(0f, lookRotation.eulerAngles.y, 0f);

        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
    }
}
