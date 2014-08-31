using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	private PlayerMovement playerMovement;

	void Awake()
	{
		this.playerMovement = (PlayerMovement) this.gameObject.GetComponent("PlayerMovement");
	}
}
