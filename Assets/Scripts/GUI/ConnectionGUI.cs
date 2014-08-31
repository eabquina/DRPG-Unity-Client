using UnityEngine;
using System.Collections;

public class ConnectionGUI : MonoBehaviour
{
	private string server = "http://";
	private string username = "";
	private string password = "";

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
			Debug.Log("Connecting...");
		}

		GUILayout.EndVertical();

		GUILayout.EndArea();
	}
}
