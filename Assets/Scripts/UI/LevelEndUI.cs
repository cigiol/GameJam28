using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndUI : MonoBehaviour
{
	[SerializeField] private GameObject levelCompletedPanel;
	[SerializeField] private GameObject levelFailedPanel;
	private void Start()
	{
		GameMaster.Instance.OnLevelCompleted += GameMaster_OnLevelCompleted;
		GameMaster.Instance.OnLevelFailed += GameMaster_OnLevelFailed;
	}

	private void GameMaster_OnLevelFailed()
	{
		levelFailedPanel.SetActive(true);
	}

	private void GameMaster_OnLevelCompleted()
	{
		levelCompletedPanel.SetActive(true);
	}
}
