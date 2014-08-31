using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WebService : MonoBehaviour
{
	public delegate void SuccessResponseHandler(WWW webRequest);
	public delegate void FailureResponseHandler(WWW webRequest);
	
	public SuccessResponseHandler successResponseHandler;
	public FailureResponseHandler failureResponseHandler;
	
	protected void MakeRequest(string url)
	{
		Debug.Log("Web request: " + url);
		
		WWW webRequest = new WWW(url);
		
		StartCoroutine(WaitForResponse(webRequest));
	}
	
	protected void MakeRequest(string url, Dictionary<string, string> parameters)
	{
		Debug.Log("Web request: " + url);
		
		WWWForm form = new WWWForm();
		
		foreach (string key in parameters.Keys)
		{
			form.AddField(key, parameters[key]);
		}
		
		WWW webRequest = new WWW(url, form);
		
		StartCoroutine(WaitForResponse(webRequest));
	}
	
	protected virtual void HandleSuccess(WWW webRequest)
	{
		Debug.Log("Web response: " + webRequest.text);
		
		if (this.successResponseHandler != null)
		{
			this.successResponseHandler(webRequest);
		}
	}
	
	protected virtual void HandleFailure(WWW webRequest)
	{
		Debug.LogError("Error making web request: " + webRequest.error);
		
		if (this.failureResponseHandler != null)
		{
			this.failureResponseHandler(webRequest);
		}
	}
	
	private IEnumerator WaitForResponse(WWW webRequest)
	{
		yield return webRequest;
		
		if (webRequest.error == null)
		{
			this.HandleSuccess(webRequest);
		}
		else
		{
			this.HandleFailure(webRequest);
		}
	}
}
