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
        //Bir sonraki yürüme noktasýna varýp varmadýðýný kontrol ediyor
        if (isRotating && )
        {
            //Son noktaya gelince ilerleme yönünü ters çevirip tersten ilerliyor, en baþa gelince de tekrar ileri gitmesini saðlýyor
            //ilk ve son nokta arasýnda sürekli bir döngü oluþturuyor
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
