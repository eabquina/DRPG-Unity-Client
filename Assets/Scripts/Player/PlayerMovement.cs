using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	private int raycastLayerMask;
	
	private RaycastHit raycastHit;

	void Awake()
	{
		this.raycastLayerMask = 1 << LayerMask.NameToLayer("Ground");
	}
	
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out raycastHit, Mathf.Infinity, this.raycastLayerMask))
			{
				Debug.Log("Clicked Ground.");
			}
		}
	}
}
