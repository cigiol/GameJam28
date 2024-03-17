using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCollisions : MonoBehaviour
{

	// 60, 179, 113
	[SerializeField] private TMP_Text quest;
	float r=0f,g=1f,b=0.2f,a=1f;
	private void OnTriggerEnter(Collider other)
	{
		if(other.TryGetComponent(out IInteractable interactable))
		{
			interactable.Intreact();
		}
		if(other.CompareTag("UI")){
			AudioManager.Instance.Play("Grumble");
			var text = other.gameObject.transform.GetChild(0).gameObject;
			text.SetActive(true);
			quest.color = new Color(r,g,b,a);
			quest.text = "Gizlice Sohbeti Dinle!\nKanýtlarý Yok Etmeden Araþtýr Ve Fabrikadan Çýkýþý Bul!";
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
