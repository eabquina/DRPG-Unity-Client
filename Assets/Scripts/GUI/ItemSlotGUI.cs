using UnityEngine;
using System.Collections;

public class ItemSlotGUI : MonoBehaviour
{
	public TextMesh nameLabel;

	private ItemModel item;

	public void SetItem(ItemModel item)
	{
		Debug.Log("Setting Item Slot GUI item: " + item.label);

		this.nameLabel.text = item.label;
	}
}
