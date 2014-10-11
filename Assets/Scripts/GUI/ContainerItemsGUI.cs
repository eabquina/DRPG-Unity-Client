using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ContainerItemsGUI : MonoBehaviour
{
	public ItemSlotGUI itemSlotPrefab;

	public float itemSlotPadding = 0.7f;
	
	private List<ItemSlotGUI> itemSlots = new List<ItemSlotGUI>();

	public void SetItems(ItemModel[] items)
	{
		this.itemSlots.Clear();

		for (int i = 0; i < items.Length; i++)
		{
			this.CreateItemSlot(items[i], i);
		}
	}

	private void CreateItemSlot(ItemModel item, int count)
	{
		float yOffset = (this.itemSlotPadding * (float)count);
		ItemSlotGUI itemSlot = (ItemSlotGUI) Instantiate(this.itemSlotPrefab,
			this.itemSlotPrefab.transform.position - new Vector3(0, yOffset, 1),
			this.itemSlotPrefab.transform.rotation);

		itemSlot.gameObject.transform.parent = this.gameObject.transform;
		
		itemSlot.SetItem(item);

		this.itemSlots.Add(itemSlot);
	}
}
