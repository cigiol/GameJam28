using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryCamRotation : MonoBehaviour
{
    [Header("Rotate Logic")]
    [SerializeField] private Transform[] rotationPositions;
    [SerializeField] private float rotateSpeed = 5f;
    private int positionIndex = 0;
    private int positionIndexSetter = -1;
    private bool isRotating = true;
    void Start()
    {
        positionIndexSetter = -1;
        positionIndex = 0;
        isRotating = true;
    }

    // Update is called once per frame
    /*void Update()
    {
        //Bir sonraki y�r�me noktas�na var�p varmad���n� kontrol ediyor
        if (isRotating && )
        {
            //Son noktaya gelince ilerleme y�n�n� ters �evirip tersten ilerliyor, en ba�a gelince de tekrar ileri gitmesini sa�l�yor
            //ilk ve son nokta aras�nda s�rekli bir d�ng� olu�turuyor
            if (positionIndex <= 0 || positionIndex >= walkPoints.Length - 1)
            {
                positionIndexSetter *= -1;
            }
            positionIndex += positionIndexSetter;
        }

        RotateToNextPoint();
    }*/

	private void RotateToNextPoint()
	{
		
	}
}
