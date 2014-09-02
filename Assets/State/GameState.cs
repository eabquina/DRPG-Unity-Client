using UnityEngine;
using System.Collections;
using LitJson;

public class GameState : MonoBehaviour
{
	Player player;

	void Awake()
	{
		this.player = (Player) GameObject.FindGameObjectWithTag("Player").GetComponent("Player");

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
}
