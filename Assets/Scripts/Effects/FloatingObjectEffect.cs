using UnityEngine;
using System.Collections;

public class FloatingObjectEffect : MonoBehaviour
{
	private Vector3 minPos = new Vector3(0f, -0.3f, 0f);
	private Vector3 maxPos = new Vector3(0f, 0.3f, 0f);

	private Vector3 velocity = new Vector3(0f, 0.005f, 0f);

	private Vector3 targetPos;

	void Awake()
	{
		this.targetPos = this.maxPos;
	}
	
	void Update()
	{
		this.gameObject.transform.position += this.velocity;

		if (this.gameObject.transform.position == this.targetPos)
		{
			if (this.targetPos == this.minPos)
			{
				this.targetPos = this.maxPos;
			}
			else
			{
				this.targetPos = this.minPos;
			}

			this.velocity *= -1;
		}
	}
}
