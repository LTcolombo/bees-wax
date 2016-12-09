using UnityEngine;
using System.Collections;

public class checkCollideTo : MonoBehaviour {

	public GameObject other;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(GetComponent<CircleCollider2D>().IsTouching(other.GetComponent<CircleCollider2D>()));
	}
}
