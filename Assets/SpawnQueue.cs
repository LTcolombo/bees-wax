using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnQueue : MonoBehaviour {

	public static List<GameObject> queue = new List<GameObject> ();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Enqueue(GameObject prefab){
		if (queue.Count < 4) {
			queue.Add (prefab);
		}	
	}
}
