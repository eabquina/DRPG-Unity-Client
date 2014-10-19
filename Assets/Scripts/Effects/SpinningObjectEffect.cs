using UnityEngine;
using System.Collections;

public class SpinningObjectEffect : MonoBehaviour
{
	public float rotateSpeed = 10.0f;

	void Update()
	{
		transform.Rotate(0, 0, (this.rotateSpeed * Time.deltaTime));
	}
}
