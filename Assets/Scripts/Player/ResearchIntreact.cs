using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ResearchIntreact : MonoBehaviour, IInteractable
{
	[SerializeField] private TextMeshProUGUI uiText;
	[SerializeField] private string taskText;
	public void Intreact()
	{
		AudioManager.Instance.Play("Drawr");
		uiText.text = "\n" + taskText;
		transform.GetChild(0).GetComponentInChildren<Image>().color = Color.green;
	}
}
