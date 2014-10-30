using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class GameState : MonoBehaviour
{
	public delegate void UpdateEventHandler(object sender);
	public event UpdateEventHandler UpdateEvent;

	public int roomId;
	public ContainerProp containerPrefab;

	private Player player;

	private List<EventModel> events = new List<EventModel>();

	private EventService eventService;
	private RoomService roomService;

	void Awake()
	{
		this.player = (Player) GameObject.FindGameObjectWithTag("Player").GetComponent("Player");

		this.eventService = (EventService) this.gameObject.GetComponent("EventService");
		this.eventService.successResponseHandler = new WebService.SuccessResponseHandler(this.HandleSendEventsSuccess);

		this.roomService = (RoomService) this.gameObject.GetComponent("RoomService");

		if (PlayerPrefs.HasKey("avatar"))
		{
			Debug.Log(PlayerPrefs.GetString("avatar"));

			AvatarModel avatar = JsonMapper.ToObject<AvatarModel>(PlayerPrefs.GetString("avatar"));

			if (avatar != null)
			{
				this.player.Name = avatar.label;
				this.player.XP = avatar.GetAttributeValue("xp");
				this.player.HP = avatar.GetAttributeValue("hp");
			}
		}
		else
		{
			Debug.LogWarning("Started game with no avatar data.");
		}

		if (this.roomId != 0)
		{
			this.roomService.successResponseHandler = new WebService.SuccessResponseHandler(this.PopulateRoomContainers);
			this.roomService.GetRoom(this.roomId);
		}
	}

	public void CreateEvent(string method, List<string> arguments)
	{
		EventModel eventModel = new EventModel();
		eventModel.method = method;
		eventModel.arguments = arguments;

		this.events.Add(eventModel);

		this.RaiseUpdateEvent();
	}

	public void SendEvents()
	{
		this.eventService.SendEvents(this.events);
	}

	public void PopulateRoomContainers(WWW webRequest)
	{
		RoomModel room = JsonMapper.ToObject<RoomModel>(PlayerPrefs.GetString("room"));

		if (room != null)
		{
			GameObject[] containerNodes = GameObject.FindGameObjectsWithTag("ContainerNode");

			if (containerNodes.Length > 0)
			{
				ContainerProp containerProp = null;

				for (int i = 0; i < containerNodes.Length; i++)
				{
					if (i < room.item_containers.Length)
					{
						// Instantiate new Item Container Prop.
						containerProp = (ContainerProp) Instantiate(this.containerPrefab,
							containerNodes[i].transform.position,
							this.containerPrefab.transform.rotation);

						containerProp.itemContainer = room.item_containers[i];
					}
				}
			}
			else
			{
				Debug.Log("Room contains no item containers.");
			}
		}
		else
		{
			Debug.LogWarning("Started game with no room data for room ID: " + this.roomId);
		}
	}

	private void HandleSendEventsSuccess(WWW webRequest)
	{
		this.events.Clear();
	}

	private void RaiseUpdateEvent()
	{
		if (UpdateEvent != null)
		{
			UpdateEvent(this);
		}
	}
}
