using UnityEngine;
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
		
		this.MakeRequest(server + "/user/login", parameters);
	}
	
	protected override void HandleSuccess(WWW webRequest)
	{
		Debug.Log(webRequest.text);
		
		WebServiceResponseModel response = JsonMapper.ToObject<WebServiceResponseModel>(webRequest.text);
		
		if (response.success)
		{
			Debug.Log("Connected to server.");
			
			base.HandleSuccess(webRequest);
		}
		else
		{
			Debug.LogError(response.message);
			
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
