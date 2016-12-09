using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnCell : MonoBehaviour
{
	void Spawn ()
	{
		if (SpawnQueue.queue.Count == 0)
			return;
		
		GameObject instance = (GameObject)Instantiate (SpawnQueue.queue[0], transform.parent);
		SpawnQueue.queue.RemoveAt(0);
		instance.transform.localPosition = new Vector3 (transform.position.x, transform.position.y, -0.2f);
		instance.GetComponent<StoreFaction> ().SetFaction (GetComponent<StoreFaction> ().GetFaction());
	}
}
