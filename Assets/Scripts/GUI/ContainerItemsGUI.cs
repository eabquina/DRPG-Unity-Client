using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ContainerItemsGUI : MonoBehaviour
{
	public ItemSlotGUI itemSlotPrefab;

	private List<ItemSlotGUI> itemSlots = new List<ItemSlotGUI>();

	public void SetItems(ItemModel[] items)
	{
		this.itemSlots.Clear();

		for (int i = 0; i < items.Length; i++)
		{
			this.CreateItemSlot(items[i]);
		}
	}

	private void CreateItemSlot(ItemModel item)
	{
		ItemSlotGUI itemSlot = (ItemSlotGUI) Instantiate(this.itemSlotPrefab,
			this.itemSlotPrefab.transform.position,
			this.itemSlotPrefab.transform.rotation);
		
		itemSlot.SetItem(item);

		this.itemSlots.Add(itemSlot);
	}
}
