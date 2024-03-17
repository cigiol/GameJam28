using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompletedTrigger : MonoBehaviour, IInteractable
{
	public void Intreact()
	{
		GameMaster.Instance.LevelCompleted();
	}
}
