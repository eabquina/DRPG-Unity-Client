using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ContainerItemsGUI : DialogGUI
{
	public ItemSlotGUI itemSlotPrefab;

	public float itemSlotPadding = 0.7f;

	public string type;
	
	private List<ItemSlotGUI> itemSlots = new List<ItemSlotGUI>();

	public void SetItemsFromContainer(ItemContainerModel itemContainer)
	{
		for (int i = 0; i < itemContainer.item_instances.Length; i++)
		{
			for (int j = 0; j < itemContainer.items.Length; j++)
			{
				if (itemContainer.items[j].item_id == itemContainer.item_instances[i].item_id)
				{
					this.CreateItemSlot(itemContainer.item_instances[i], itemContainer.items[j], i);
				}
			}
		}
	}

	public void SetItems(List<ItemModel> items)
	{
		this.itemSlots.Clear();

		for (int i = 0; i < items.Count; i++)
		{
			this.CreateItemSlot(null, items[i], i);
		}
	}

	private void CreateItemSlot(ItemInstanceModel itemInstance, ItemModel item, int count)
	{
		float yOffset = (this.itemSlotPadding * (float)count);
		ItemSlotGUI itemSlot = (ItemSlotGUI) Instantiate(this.itemSlotPrefab,
			this.itemSlotPrefab.transform.position - new Vector3(0, yOffset, 1),
			this.itemSlotPrefab.transform.rotation);

		itemSlot.gameObject.transform.parent = this.gameObject.transform;

		itemSlot.type = this.type;
		itemSlot.SetItemInstance(itemInstance);
		itemSlot.SetItem(item);

		this.itemSlots.Add(itemSlot);
	}
}
