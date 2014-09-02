using UnityEngine;
using System.Collections;

public abstract class PlayerIndicator : MonoBehaviour
{
	protected virtual void Awake()
	{
		Player player = (Player) GameObject.FindGameObjectWithTag("Player").GetComponent("Player");

		player.UpdateEvent += this.HandleUpdate;
	}

	protected abstract void HandleUpdate(object sender, PlayerEventArgs e);
}
