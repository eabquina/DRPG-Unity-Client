using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class EventService : WebService
{
	public void SendEvents(List<EventModel> events)
	{
		if (events.Count > 0)
		{
			if (PlayerPrefs.GetInt("offline") == 0)
			{
				Debug.Log("Sending " + events.Count + " events.");

				string eventsString = JsonMapper.ToJson(events);

				Dictionary<string, string> parameters = new Dictionary<string, string>();
				parameters.Add("events", eventsString);

				Debug.Log(eventsString);

				this.MakeRequest(server + "drpg/process/events", parameters);
			}
			else
			{
				Debug.Log(events.Count + " game events not sent in offline mode.");
			}
		}
	}
	
	protected override void HandleSuccess(WWW webRequest)
	{
		Debug.Log(webRequest.text);
		
		WebServiceResponseModel response = JsonMapper.ToObject<WebServiceResponseModel>(webRequest.text);
		
		if (response.success)
		{
			Debug.Log("Events successfully processed.");

			base.HandleSuccess(webRequest);
		}
		else
		{
			if (this.failureResponseHandler != null) {
				this.failureResponseHandler(webRequest);
			}

			this.HandleFailure(webRequest);
		}
	}
	
	protected override void HandleFailure(WWW webRequest)
	{
		base.HandleFailure(webRequest);
		
		Debug.Log(webRequest.text);
		
		Debug.LogError("Failed to process events.");
	}
}
