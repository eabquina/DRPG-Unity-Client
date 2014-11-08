using UnityEngine;
using System.Collections;

public class ItemSlotGUI : GUI
{
	public TextMesh nameLabel;
	
	private ItemModel item;

	private GameState gameState;

	void Awake()
	{
		GameObject gameState = GameObject.FindGameObjectWithTag("GameState");
		this.gameState = (GameState) gameState.GetComponent("GameState");
	}

	public void SetItem(ItemModel item)
	{
		Debug.Log("Setting Item Slot GUI item: " + item.label);

		this.item = item;

		this.nameLabel.text = this.item.label;
	}

	public void HandleSelected()
	{
		this.gameState.player.AddInventoryItem(this.item);

		GameObject.Destroy(this.gameObject);
	}
}
