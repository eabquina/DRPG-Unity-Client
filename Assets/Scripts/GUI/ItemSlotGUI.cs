using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemSlotGUI : GUI
{
	public TextMesh nameLabel;

	public string type;

	private ItemInstanceModel itemInstance;
	private ItemModel item;

	private GameState gameState;

	void Awake()
	{
		GameObject gameState = GameObject.FindGameObjectWithTag("GameState");
		this.gameState = (GameState) gameState.GetComponent("GameState");
	}

	public void SetItemInstance(ItemInstanceModel itemInstance)
	{
		this.itemInstance = itemInstance;
	}

	public void SetItem(ItemModel item)
	{
		Debug.Log("Setting Item Slot GUI item: " + item.label);

		this.item = item;

		this.nameLabel.text = this.item.label;
	}

	public void HandleSelected()
	{
		if (this.type == ItemSlotTypeConstants.ITEM_INVENTORY)
		{
			// TODO: Equip inventory item.
		}
		else if (this.type == ItemSlotTypeConstants.ITEM_CONTAINER)
		{
			this.gameState.player.AddInventoryItem(this.item);

			List<string> arguments = new List<string>();
			arguments.Add("avatar");
			arguments.Add(this.gameState.player.AvatarId.ToString());
			arguments.Add(this.itemInstance.item_instance_id.ToString());

			this.gameState.CreateEvent("drpg_inventory_add_item_event", arguments);

			GameObject.Destroy(this.gameObject);
		}
	}
}
