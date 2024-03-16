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
		//oyuncu yakaland���nda bu �al���r
		OnLevelFailed?.Invoke();
		Debug.Log("Oyuncu yakaland�");
	}

	public void LevelCompleted()
	{
		//B�l�m tamamland���nda bu �al���r
		OnLevelCompleted?.Invoke();
		Debug.Log("Oyuncu b�l�m� ge�ti");
	}
}
