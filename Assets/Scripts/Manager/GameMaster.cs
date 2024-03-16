using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster Instance { get; private set; }

	public event Action OnLevelFailed;
	public event Action OnLevelCompleted;

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
		//oyuncu yakalandýðýnda bu çalýþýr
		OnLevelFailed?.Invoke();
		Debug.Log("Oyuncu yakalandý");
	}

	public void LevelCompleted()
	{
		//Bölüm tamamlandýðýnda bu çalýþýr
		OnLevelCompleted?.Invoke();
		Debug.Log("Oyuncu bölümü geçti");
	}
}
