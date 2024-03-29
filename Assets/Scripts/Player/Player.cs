﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
	public delegate void UpdateEventHandler(object sender, PlayerEventArgs e);

	public event UpdateEventHandler UpdateEvent;

	private int avatarId;
	private string name;
	private int xp;
	private int hp;

	private List<ItemModel> inventoryItems = new List<ItemModel>();

	private InventoryService inventoryService;

	public int AvatarId
	{
		get { return this.avatarId; }
		set { this.avatarId = value; }
	}

	public string Name
	{
		get { return this.name; }
		set {
			this.name = value;
			
			this.RaiseUpdateEvent();
		}
	}

	public int XP
	{
		get { return this.xp; }
		set {
			this.xp = value;
			
			this.RaiseUpdateEvent();
		}
	}

	public int HP
	{
		get { return this.hp; }
		set {
			this.hp = value;
				
				this.RaiseUpdateEvent();
		}
	}

	void Start()
	{
		this.inventoryService = (InventoryService) this.gameObject.GetComponent("InventoryService");
		this.inventoryService.successResponseHandler = new WebService.SuccessResponseHandler(this.PopulateInventory);

		this.inventoryService.GetInventory("drpg_avatar", this.avatarId);
	}

	public List<ItemModel> GetInventoryItems()
	{
		return this.inventoryItems;
	}

	public void AddInventoryItem(ItemModel item)
	{
		this.inventoryItems.Add(item);
	}

	protected virtual void RaiseUpdateEvent()
	{
		Debug.Log("Updated player stats. Name: " + this.name + ", XP: " + this.xp + ", HP: " + this.hp);

		if (UpdateEvent != null)
		{
			UpdateEvent(this, new PlayerEventArgs(this.name, this.xp, this.hp));
		}
	}

	private void PopulateInventory(WWW webRequest)
	{
		for (int i = 0; i < this.inventoryService.inventory.items.Length; i++)
		{
			this.AddInventoryItem(this.inventoryService.inventory.items[i]);
		}
	}
}

public class PlayerEventArgs
{
	public PlayerEventArgs(string name, int xp, int hp) { Name = name; XP = xp; HP = hp; }
	public string Name {get; private set;}
	public int XP {get; private set;}
	public int HP {get; private set;}
}
