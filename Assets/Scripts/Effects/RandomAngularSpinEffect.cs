using UnityEngine;
using System.Collections;

public class RandomAngularSpinEffect : MonoBehaviour
{
	void Start()
	{
		this.GetComponent<Rigidbody>().angularVelocity = new Vector3(
			Random.Range(0, 10),
			Random.Range(0, 10),
			Random.Range(0, 10));
	}
}
