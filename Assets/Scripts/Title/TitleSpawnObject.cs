using UnityEngine;
using System.Collections;

public class TitleSpawnObject : MonoBehaviour
{
	public GameObject spawnPrefab;

	private float leftX = -5;
	private float rightX = 5;

	private float minY = 0;
	private float maxY = 0;

	private float spawnDelay = 0.6f;

	private float tDelta = 0;

	void Update()
	{
		this.tDelta += Time.deltaTime;

		if (this.tDelta >= this.spawnDelay)
		{
			this.SpawnObject();
			this.tDelta = 0;
		}
	}

	private void SpawnObject()
	{
		if (this.spawnPrefab != null)
		{
			float xPos = (Random.Range(0, 100) <= 50) ? this.leftX : this.rightX;
			
			Instantiate(this.spawnPrefab,
				new Vector3(xPos, Random.Range(this.minY, this.maxY), 0),
				this.spawnPrefab.transform.rotation);
		}
	}
}
