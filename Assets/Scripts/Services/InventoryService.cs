using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class InventoryService : WebService
{
	public InventoryModel inventory;

	public void GetInventory(string type, int entityId)
	{
		if (PlayerPrefs.GetInt("offline") == 1)
		{
			TextAsset jsonAsset = (TextAsset) Resources.Load("ExampleData/ExampleInventoryData", typeof(TextAsset));
			InventoryServiceResponseModel response = JsonMapper.ToObject<InventoryServiceResponseModel>(jsonAsset.text);

			this.inventory = response.inventory;

			if (this.successResponseHandler != null)
			{
				this.successResponseHandler(null);
			}
		}
		else
		{
			Debug.Log("Getting inventory for entity type: " + type + ", ID: " + entityId);

			this.MakeRequest(server + "drpg/data/inventory/" + type + "/" + entityId);
		}
	}
	
	protected override void HandleSuccess(WWW webRequest)
	{
		Debug.Log(webRequest.text);
		
		InventoryServiceResponseModel response = JsonMapper.ToObject<InventoryServiceResponseModel>(webRequest.text);

		this.inventory = response.inventory;
		
		if (response.success)
		{
			Debug.Log("Got inventory.");

			base.HandleSuccess(webRequest);
		}
		else
		{
			this.failureResponseHandler(webRequest);
		}
	}
	
	protected override void HandleFailure(WWW webRequest)
	{
		base.HandleFailure(webRequest);
		
		Debug.Log(webRequest.text);
		
		Debug.LogError("Failed to get inventory.");
	}
}
