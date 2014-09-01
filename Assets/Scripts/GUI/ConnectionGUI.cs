using UnityEngine;
using System.Collections;
using LitJson;

public class ConnectionGUI : MonoBehaviour
{
	private string server = "http://";
	private string username = "admin";
	private string password = "admin";

	private ConnectionService connectionService;

	void Awake()
	{
		if (PlayerPrefs.HasKey("server"))
		{
			this.server = PlayerPrefs.GetString("server");
		}

		this.connectionService = (ConnectionService) this.gameObject.GetComponent("ConnectionService");

		if (this.connectionService != null)
		{
			this.connectionService.successResponseHandler = new WebService.SuccessResponseHandler(this.HandleConnectionSuccess);
			this.connectionService.failureResponseHandler = new WebService.FailureResponseHandler(this.HandleConnectionFailure);
		}
		else
		{
			Debug.LogWarning("Unable to find ConnectionService. Make sure script is attached.");
		}
	}

	void OnGUI()
	{
		GUILayout.BeginArea(new Rect(30, 30, 300, 300));

		GUILayout.BeginVertical("box");

		GUILayout.BeginHorizontal("box");
		GUILayout.Label("Server:");
		this.server = GUILayout.TextField(this.server, 255);
		GUILayout.EndHorizontal();

		GUILayout.BeginHorizontal("box");
		GUILayout.Label("Username:");
		this.username = GUILayout.TextField(this.username, 255);
		GUILayout.EndHorizontal();

		GUILayout.BeginHorizontal("box");
		GUILayout.Label("Password:");
		this.password = GUILayout.TextField(this.password, 255);
		GUILayout.EndHorizontal();

		if (GUILayout.Button("Connect!"))
		{
			this.Connect();
		}

		GUILayout.EndVertical();

		GUILayout.EndArea();
	}

	void Connect()
	{
		string server = this.server.Trim();
		string username = this.username.Trim();

		if (!server.EndsWith("/"))
		{
			server += "/";
		}
		
		this.connectionService.Connect(server, username, this.password);
	}

	void HandleConnectionSuccess(WWW webRequest)
	{
		Debug.Log("Service connection successful.");

		Application.LoadLevel("LoadScene");
	}
	
	void HandleConnectionFailure(WWW webRequest)
	{
		Debug.LogWarning("Service connection failed.");
	}
}
