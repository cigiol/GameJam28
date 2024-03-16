using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if(other.TryGetComponent(out IInteractable interactable))
		{
			interactable.Intreact();
		}
		if(other.CompareTag("UI")){
			var text = other.gameObject.transform.GetChild(0).gameObject;
			text.SetActive(true);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if(other.CompareTag("UI")){
			var text = other.gameObject.transform.GetChild(0).gameObject;
			text.SetActive(false);
		}
	}
}
