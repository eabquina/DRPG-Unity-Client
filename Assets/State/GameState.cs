using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class GameState : MonoBehaviour
{
	private Player player;

	private List<EventModel> events = new List<EventModel>();

	private EventService eventService;

	void Awake()
	{
		this.player = (Player) GameObject.FindGameObjectWithTag("Player").GetComponent("Player");

		this.eventService = (EventService) this.gameObject.GetComponent("EventService");

		if (PlayerPrefs.HasKey("avatar"))
		{
			Debug.Log(PlayerPrefs.GetString("avatar"));

			AvatarModel avatar = JsonMapper.ToObject<AvatarModel>(PlayerPrefs.GetString("avatar"));

			if (avatar != null)
			{
				this.player.Name = avatar.label;
				this.player.XP = avatar.xp;
				this.player.HP = avatar.hp;
			}
		}
		else
		{
			Debug.LogWarning("Started game with no avatar data.");
		}
	}
	
	public void CreateEvent(string method, List<string> arguments)
	{
		EventModel eventModel = new EventModel();
		eventModel.method = method;
		eventModel.arguments = arguments;

		this.events.Add(eventModel);
	}
}
