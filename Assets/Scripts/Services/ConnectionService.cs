﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class ConnectionService : WebService
{
	public void Connect(string server, string username, string password)
	{
		Debug.Log("Connecting to server at: " + server);

		Dictionary<string, string> parameters = new Dictionary<string, string>();
		
		parameters.Add("username", username);
		parameters.Add("password", password);
		
		this.MakeRequest(server + "drpg_rest/user/login", parameters);
	}
	
	protected override void HandleSuccess(WWW webRequest)
	{
		Debug.Log(webRequest.text);
		
		ConnectionServiceResponseModel response = JsonMapper.ToObject<ConnectionServiceResponseModel>(webRequest.text);
		
		if (response.sessid.Length > 0)
		{
			Debug.Log("Connected to server.");
			
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
		
		Debug.LogError("Failed to connect to server.");
	}
}
