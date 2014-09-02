using UnityEngine;
using System.Collections;

public class PlayerHPIndicator : PlayerIndicator
{
	public TextMesh value;
	
	protected override void HandleUpdate(object sender, PlayerEventArgs e)
	{
		if (this.value != null)
		{
			this.value.text = e.HP.ToString();
		}
	}
}
