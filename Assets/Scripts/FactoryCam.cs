using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryCam : MonoBehaviour, IInteractable
{
	public void Intreact()
	{
		Debug.Log("Yakalandınn!!");
		GameMaster.Instance.LevelFailed();
	}
}
