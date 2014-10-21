using UnityEngine;
using System.Collections;

public class DialogGUI : GUI
{
	public virtual void Close()
	{
		GameObject.Destroy(this.gameObject);
	}
}
