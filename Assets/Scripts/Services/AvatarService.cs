using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class AvatarService : WebService
{
	public void GetActiveAvatar()
	{
		Debug.Log("Getting user's active avatar.");

		this.MakeRequest(server + "drpg/data/avatar");
	}
	
	protected override void HandleSuccess(WWW webRequest)
	{
		Debug.Log(webRequest.text);
		
		AvatarServiceResponseModel response = JsonMapper.ToObject<AvatarServiceResponseModel>(webRequest.text);
		
		if (response.success)
		{
			Debug.Log("Got avatar.");

			// Store avatar.
			PlayerPrefs.SetString("avatar", JsonMapper.ToJson(response.avatar));
			
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
		
		Debug.LogError("Failed to get avatar.");
	}
}
