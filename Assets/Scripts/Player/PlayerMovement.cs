using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	private float speed = 2f;
	private Vector3 target;

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

			if (Physics.Raycast(ray, out this.raycastHit, Mathf.Infinity, this.raycastLayerMask))
			{
				Debug.Log("Clicked Ground at point:");
				Debug.Log(this.raycastHit.point);

				this.target = new Vector3(this.raycastHit.point.x, this.gameObject.transform.position.y, this.raycastHit.point.z);
			}
		}

		if ((this.gameObject.transform.position.x != this.target.x)
		    && (this.gameObject.transform.position.z != this.target.z))
		{
			float step = (this.speed * Time.deltaTime);
			this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.target, step);
		}
	}
}
