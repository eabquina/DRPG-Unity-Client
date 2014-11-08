using UnityEngine;
using System.Collections;

public class TitleLaunchedObject : MonoBehaviour
{
	private float lifespan = 3.0f;

	private float tDelta;

	void Start()
	{
		float forceX = (this.transform.position.x > 0)? -150 : 150;

		this.rigidbody.AddForce(forceX, Random.Range(250, 500), 0);
	}

	void Update()
	{
		this.tDelta += Time.deltaTime;

		if (this.tDelta >= this.lifespan)
		{
			GameObject.Destroy(this.gameObject);
		}
	}
}
