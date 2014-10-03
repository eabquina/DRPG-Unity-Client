using UnityEngine;
using System.Collections;

public class PortalProp : InteractiveProp
{
	public string targetScene;

	public override void HandleInteraction()
	{
		if (this.targetScene.Length > 0)
		{
			Application.LoadLevel(this.targetScene);
		}
	}
}
