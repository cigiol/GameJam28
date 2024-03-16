using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSight : MonoBehaviour
{
	[Header("Sight Logic")]
	[SerializeField] private LayerMask sightLayer;
	[SerializeField] private Collider col;
	[SerializeField] private float maxDistance = 3f;
	bool detectObject;
	RaycastHit hit;
	void Start()
    {
		col = GetComponentInChildren<Collider>();
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.E) && detectObject)
		{
			ResearchPaper();
		}
	}

	private void FixedUpdate()
	{
		//Baktýðý yere doðru bir ýþýn fýrlatýr ve ýþýnýn çarptýðý nesneleri algýlar
		detectObject = Physics.BoxCast(col.bounds.center, transform.localScale * 0.5f, transform.forward, out hit,
			transform.rotation, maxDistance, sightLayer);
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawCube(col.bounds.center + new Vector3(0f, 0f, maxDistance / 2), new Vector3(1f, 1f, maxDistance));
	}

	private void ResearchPaper()
	{
		//Oyuncu kanýtlarý araþtýrdýðý yer
		if (hit.collider.transform.parent.TryGetComponent(out ResearchIntreact research))
		{
			Debug.Log(hit.collider.transform.parent.name);
			research.Intreact();
		}
	}
}
