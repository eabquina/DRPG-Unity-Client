using UnityEngine;
using System.Collections;

public class AvatarLoader : MonoBehaviour
{
	private AvatarService avatarService;

	void Awake()
	{
		this.avatarService = (AvatarService) this.gameObject.GetComponent("AvatarService");
		
		if (this.avatarService != null)
		{
			this.avatarService.successResponseHandler = new WebService.SuccessResponseHandler(this.HandleLoadSuccess);
			this.avatarService.failureResponseHandler = new WebService.FailureResponseHandler(this.HandleLoadFailure);
		}
		else
		{
			Debug.LogWarning("Unable to find AvatarService. Make sure script is attached.");
		}
	}

	void Start()
	{
		this.avatarService.GetActiveAvatar();
	}

	void HandleLoadSuccess(WWW webRequest)
	{
		Application.LoadLevel("EntryScene");
	}
	
	void HandleLoadFailure(WWW webRequest)
	{
		Debug.LogWarning("Failed to load avatar.");

		// Return user to the title scene to reconnect.
		Application.LoadLevel("TitleScene");
	}
}
