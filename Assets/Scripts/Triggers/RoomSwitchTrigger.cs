using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSwitchTrigger : MonoBehaviour, IInteractable
{
	[SerializeField] private CameraManager cameraManager;
	[SerializeField] private int cameraIndex;
	public void Intreact()
	{
		cameraManager.SwitchCamera(cameraManager.cameras[cameraIndex]);
	}
}
