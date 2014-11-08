using UnityEngine;
using System.Collections;

public class ContainerProp : InteractiveProp
{
	public ContainerItemsGUI guiPrefab;

	public ItemContainerModel itemContainer;

	public override void HandleInteraction()
	{
		if (this.itemContainer != null)
		{
			Debug.Log("Item Container: " + this.itemContainer.label);

			ContainerItemsGUI gui = (ContainerItemsGUI) Instantiate(this.guiPrefab,
				this.guiPrefab.transform.position,
				this.guiPrefab.transform.rotation);

			gui.type = ItemSlotTypeConstants.ITEM_CONTAINER;
			gui.SetItems(this.itemContainer.items);
		}
		else
		{
			Debug.LogWarning("Container Prop has no Item Container model.");
		}
	}
}
