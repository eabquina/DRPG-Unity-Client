using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WebService : MonoBehaviour
{
	public delegate void SuccessResponseHandler(WWW webRequest);
	public delegate void FailureResponseHandler(WWW webRequest);
	
	public SuccessResponseHandler successResponseHandler;
	public FailureResponseHandler failureResponseHandler;

	protected string server;
	protected string sessionName;
	protected string sessionId;

	void Awake()
	{
		if (PlayerPrefs.HasKey("server"))
		{
			this.server = PlayerPrefs.GetString("server");
		}

		if (PlayerPrefs.HasKey("sessionName"))
		{
			this.sessionName = PlayerPrefs.GetString("sessionName");
		}

		if (PlayerPrefs.HasKey("sessionId"))
		{
			this.sessionId = PlayerPrefs.GetString("sessionId");
		}
	}

	protected Dictionary<string, string> GetRequestHeaders()
	{
		Dictionary<string, string> headers = new Dictionary<string, string>();

		if ((this.sessionId != null) && (this.sessionId.Length > 0))
		{
			string cookie = this.sessionName + "=" + this.sessionId;

			Debug.Log("Setting request header: Cookie = " + cookie);
			headers.Add("Cookie", cookie);
		}

		return headers;
	}
	
	protected void MakeRequest(string url)
	{
		Debug.Log("Web request: " + url);

		WWW webRequest = new WWW(url, null, this.GetRequestHeaders());
		
		StartCoroutine(WaitForResponse(webRequest));
	}
	
	protected void MakeRequest(string url, Dictionary<string, string> parameters)
	{
		Debug.Log("Web request: " + url);
		
		WWWForm form = new WWWForm();
		Dictionary<string, string> headers = this.GetRequestHeaders();

		foreach (string key in headers.Keys)
		{
			form.headers.Add(key, headers[key]);
		}

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
