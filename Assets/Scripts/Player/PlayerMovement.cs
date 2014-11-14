using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	private float speed = 2f;
	private Vector3 target;

	private int groundRaycastLayerMask;
	private int propsRaycastLayerMask;
	private RaycastHit raycastHit;

	private InteractiveProp currentProp;

	void Awake()
	{
		this.groundRaycastLayerMask = 1 << LayerMask.NameToLayer("Ground");
		this.propsRaycastLayerMask = 1 << LayerMask.NameToLayer("Props");
	}
	
	void Update()
	{
		if (Input.GetMouseButtonUp(0))
		{
			this.currentProp = null;

			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out this.raycastHit, Mathf.Infinity, this.groundRaycastLayerMask))
			{
				Debug.Log("Clicked Ground at point:");
				Debug.Log(this.raycastHit.point);

				this.SetNewMoveTarget(new Vector3(this.raycastHit.point.x, this.gameObject.transform.position.y, this.raycastHit.point.z));
			}
			else if (Physics.Raycast(ray, out this.raycastHit, Mathf.Infinity, this.propsRaycastLayerMask))
			{
				this.currentProp = (InteractiveProp) this.raycastHit.collider.gameObject.GetComponent("InteractiveProp");

				if (this.currentProp != null)
				{
					Debug.Log("Clicked prop: " + this.currentProp.gameObject.name);
					this.currentProp.HandleInteraction();
				}
			}
		}

		if ((this.gameObject.transform.position.x != this.target.x)
		    && (this.gameObject.transform.position.z != this.target.z))
		{
			float step = (this.speed * Time.deltaTime);
			this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.target, step);
		}
	}

	private void SetNewMoveTarget(Vector3 target)
	{
		this.target = target;

		this.gameObject.transform.LookAt(target);
	}
}
