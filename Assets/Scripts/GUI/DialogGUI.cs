using UnityEngine;
using System.Collections;

public class DialogGUI : MonoBehaviour
{
	protected virtual void Close()
	{
		GameObject.Destroy(this.gameObject);
	}
}
