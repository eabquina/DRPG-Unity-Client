using UnityEngine;
using System.Collections;

public class ItemSlotGUI : MonoBehaviour
{
	private ItemModel item;

	public void SetItem(ItemModel item)
	{
		Debug.Log("Setting Item Slot GUI item: " + item.label);
	}
}
