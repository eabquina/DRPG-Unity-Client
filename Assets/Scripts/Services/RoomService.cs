﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class RoomService : WebService
{
	public void GetRoom(int roomId)
	{
		if (PlayerPrefs.GetInt("offline") == 1)
		{
			TextAsset jsonAsset = (TextAsset) Resources.Load("ExampleData/ExampleRoomData", typeof(TextAsset));
			RoomServiceResponseModel response = JsonMapper.ToObject<RoomServiceResponseModel>(jsonAsset.text);
			PlayerPrefs.SetString("room", JsonMapper.ToJson(response.room));
			
			if (this.successResponseHandler != null)
			{
				this.successResponseHandler(null);
			}
		}
		else
		{
			Debug.Log("Getting room ID: " + roomId);

			this.MakeRequest(server + "drpg/data/room/" + roomId);
		}
	}
	
	protected override void HandleSuccess(WWW webRequest)
	{
		Debug.Log(webRequest.text);
		
		RoomServiceResponseModel response = JsonMapper.ToObject<RoomServiceResponseModel>(webRequest.text);
		
		if (response.success)
		{
			Debug.Log("Got room.");

			// Store current room.
			PlayerPrefs.SetString("room", JsonMapper.ToJson(response.room));
			
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
		
		Debug.LogError("Failed to get room.");
	}
}
