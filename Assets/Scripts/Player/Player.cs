using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public delegate void UpdateEventHandler(object sender, PlayerEventArgs e);

	public event UpdateEventHandler UpdateEvent;

	private int xp;
	private int hp;

	public virtual int XP
	{
		get { return this.xp; }
		set {
			this.xp = value;
			
			this.RaiseUpdateEvent();
		}
	}

	public virtual int HP
	{
		get { return this.hp; }
		set {
			this.hp = value;
				
				this.RaiseUpdateEvent();
		}
	}

	protected virtual void RaiseUpdateEvent()
	{
		Debug.Log("Updated player stats. XP: " + this.xp + ", HP: " + this.hp);

		if (UpdateEvent != null)
		{
			UpdateEvent(this, new PlayerEventArgs(this.xp, this.hp));
		}
	}
}

public class PlayerEventArgs
{
	public PlayerEventArgs(int xp, int hp) { XP = xp; HP = hp; }
	public int XP {get; private set;}
	public int HP {get; private set;}
}
