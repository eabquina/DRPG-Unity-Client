using UnityEngine;
using System.Collections;

public class SaveButtonGUI : GUI
{
	public Sprite enabledSprite;
	public Sprite disabledSprite;

	public GameState gameState;

	private SpriteRenderer spriteRenderer;

	private bool buttonEnabled;

	void Awake()
	{
		this.spriteRenderer = (SpriteRenderer) this.gameObject.GetComponent("SpriteRenderer");

		if (this.gameState != null)
		{
			this.gameState.UpdateEvent += this.HandleUpdate;
		}
	}

	public void HandleUpdate(object sender)
	{
		this.SetEnabled();
	}

	public void HandleSelected()
	{
		if (buttonEnabled)
		{
			this.gameState.SendEvents();

			this.SetDisabled();
		}
	}

	private void SetEnabled()
	{
		this.spriteRenderer.sprite = this.enabledSprite;
		this.buttonEnabled = true;
	}

	private void SetDisabled()
	{
		this.spriteRenderer.sprite = this.disabledSprite;
		this.buttonEnabled = false;
	}
}
