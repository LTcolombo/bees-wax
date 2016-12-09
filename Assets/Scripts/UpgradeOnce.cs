using UnityEngine;
using System.Collections;

public class UpgradeOnce : MonoBehaviour {
	
	void Start () {
		GetComponent<Animator> ().SetTrigger ("EggLayed");
	}
}
