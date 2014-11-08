using UnityEngine;
using System.Collections;

public class TitleLaunchedObject : MonoBehaviour
{
	void Start()
	{
		float forceX = (this.transform.position.x > 0)? -150 : 150;

		this.rigidbody.AddForce(forceX, Random.Range(250, 500), 0);
	}
}
