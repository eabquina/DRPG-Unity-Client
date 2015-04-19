using UnityEngine;
using System.Collections;

public class Cursor : MonoBehaviour
{
	public Camera uiCamera;
	
	private int raycastLayerMask;
	
	private RaycastHit2D raycastHit;
	
	private GUI currentGUI;
	
	void Awake()
	{
		UnityEngine.Cursor.visible = false;
		
		this.raycastLayerMask = 1 << LayerMask.NameToLayer("UI");
	}
	
	void Update()
	{
		if (Input.GetMouseButtonUp(0))
		{
			this.currentGUI = null;

			Vector3 cursorPoint = this.uiCamera.ScreenToWorldPoint(Input.mousePosition);

			this.raycastHit = Physics2D.Raycast(cursorPoint, Vector2.up, 1f, this.raycastLayerMask);

			if (this.raycastHit.collider != null)
			{
				this.currentGUI = (GUI) this.raycastHit.collider.gameObject.GetComponent("GUI");
			}

			if (this.currentGUI != null)
			{
				Debug.Log("Selected GUI item: " + this.currentGUI.gameObject.name);

				this.currentGUI.SendMessage("HandleSelected");
			}
		}
	}

	void FixedUpdate()
	{
		Vector3 cursorPoint = this.uiCamera.ScreenToWorldPoint(Input.mousePosition);
		
		this.transform.position = new Vector3(
			cursorPoint.x,
			cursorPoint.y,
			this.transform.position.z);
	}
}
