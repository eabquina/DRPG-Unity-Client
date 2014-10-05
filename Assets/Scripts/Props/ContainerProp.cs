using UnityEngine;
using System.Collections;

public class ContainerProp : InteractiveProp
{
	public ItemContainerModel itemContainer;

	public override void HandleInteraction()
	{
		if (this.itemContainer != null)
		{
			Debug.Log("Item Container: " + this.itemContainer.label);

			// TODO: Open inventory.
		}
		else
		{
			Debug.LogWarning("Container Prop has no Item Container model.");
		}
	}
}
