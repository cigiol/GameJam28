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
        //Hareket edip etmediðini kontrol et
        if (moveInput.magnitude > 0f)
            isMoving = true;
        else
            isMoving = false;

        //Yatay ve dikey inputlarý alýyor
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
    }

	private void FixedUpdate()
	{
        MovePlayer();
	}

    //Daha pürüzsüz dönüþler için late update içinde çaðýrýyoruz dönme fonksiyonunu
    private void LateUpdate()
    {
        LookAtWalkPoint();
    }

    void MovePlayer()
	{
        //Karakterimizi rigidbody kullanarak hareket ettiriyor
        rb.MovePosition(transform.position + moveInput.normalized * moveSpeed * Time.fixedDeltaTime);
	}

    //Gittiði yöne bakma
    private void LookAtWalkPoint()
    {
        if (!isMoving)
            return;
        
        Quaternion lookRotation = Quaternion.LookRotation(moveInput);
        lookRotation.eulerAngles = new Vector3(0f, lookRotation.eulerAngles.y, 0f);

        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
    }
}
