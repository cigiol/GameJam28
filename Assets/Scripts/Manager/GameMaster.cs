using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster Instance { get; private set; }

	public event Action OnLevelFailed;
	public event Action OnLevelCompleted;

	public bool IsGameEnded { get => isGameEnded; private set => isGameEnded = value; }
	private bool isGameEnded = false;

	private void Awake()
	{
		if(Instance == null)
		{
			Instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public void LevelFailed()
	{
		if (isGameEnded)
			return;

		IsGameEnded = true;
		//oyuncu yakalandýðýnda bu çalýþýr
		OnLevelFailed?.Invoke();
		Debug.Log("Oyuncu yakalandý");
	}

	public void LevelCompleted()
	{
		if (isGameEnded)
			return;

		IsGameEnded = true;
		//Bölüm tamamlandýðýnda bu çalýþýr
		OnLevelCompleted?.Invoke();
		Debug.Log("Oyuncu bölümü geçti");
	}
}
