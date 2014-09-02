using UnityEngine;
using System.Collections;

public class PlayerNameIndicator : PlayerIndicator
{
	public TextMesh value;

	protected override void HandleUpdate(object sender, PlayerEventArgs e)
	{
		if (this.value != null)
		{
			this.value.text = e.Name;
		}
	}
}
