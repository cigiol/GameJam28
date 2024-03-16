using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
    [Header("Sight Logic")]
	[SerializeField] private LayerMask sightLayer;
    [SerializeField] private Collider col;
	[SerializeField] private float maxDistance = 50f;
    bool detectObject;
	RaycastHit hit;

	private void Start()
	{
		col = GetComponentInChildren<Collider>();
	}

	private void FixedUpdate()
	{
		//Baktýðý yere doðru bir ýþýn fýrlatýr ve ýþýnýn çarptýðý nesneleri algýlar
		detectObject = Physics.BoxCast(col.bounds.center, transform.localScale * 0.5f, transform.forward, out hit, 
			transform.rotation, maxDistance, sightLayer);

		if (detectObject)
		{
			//Oyuncunun yakalanma kodunu buraya yaz
			if (hit.collider.CompareTag("Player"))
			{
				Debug.Log(hit.collider.transform.parent.name);
				GameMaster.Instance.LevelFailed();
			}
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawCube(col.bounds.center + new Vector3(0f,0f, maxDistance / 2), new Vector3(1f,1f, maxDistance));
	}
}
