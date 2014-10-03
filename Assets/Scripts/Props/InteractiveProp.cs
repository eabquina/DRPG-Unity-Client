using UnityEngine;
using System.Collections;

public class InteractiveProp : MonoBehaviour
{
	public virtual void HandleInteraction()
	{
		Debug.Log("Interacted with prop: " + this.gameObject.name);
	}
}
