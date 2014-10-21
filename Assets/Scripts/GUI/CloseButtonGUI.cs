using UnityEngine;
using System.Collections;

public class CloseButtonGUI : GUI
{
	public DialogGUI dialogGUI;

	public void HandleSelected()
	{
		if (this.dialogGUI != null)
		{
			this.dialogGUI.Close();
		}
	}
}
