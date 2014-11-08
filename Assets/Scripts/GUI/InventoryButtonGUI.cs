using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryButtonGUI : GUI
{
	public GameState gameState;

	public ContainerItemsGUI guiPrefab;

	public void HandleSelected()
	{
		ContainerItemsGUI gui = (ContainerItemsGUI) Instantiate(this.guiPrefab,
			this.guiPrefab.transform.position,
			this.guiPrefab.transform.rotation);

		List<ItemModel> inventoryItems = this.gameState.player.GetInventoryItems();

		if (inventoryItems.Count != 0)
		{
			gui.SetItems(inventoryItems.ToArray());
		}
	}
}
