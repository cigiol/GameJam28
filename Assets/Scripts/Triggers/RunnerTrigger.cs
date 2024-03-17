using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerTrigger : MonoBehaviour, IInteractable
{
	[SerializeField] private CameraManager cameraManager;
	[SerializeField] private int cameraIndex;
	public void Intreact()
	{
		cameraManager.SetCamerasOrthoSize(15, cameraManager.cameras[cameraIndex]);
		FindObjectOfType<PlayerMovement>().MoveSpeed = 15f;
	}
}
