using System;
using UnityEngine;
using System.Collections.Generic;

public class EnemyState
{
	static List<GameObject> cells = new List<GameObject>();

	public static int storedNectar = 0;
	public static void addNectar(int value){
		storedNectar += value;
		TryUpgrade ();
	}

	public static void addCell(GameObject cell){
		if (!cells.Contains (cell)) {
			cells.Add (cell);
			TryUpgrade ();
		}
	}

	static void TryUpgrade(){
		//int tries = 10;

//		while (storedNectar >= 10) {
//			var index = UnityEngine.Random.Range (0, cells.Count);
//			var animator = cells [index].GetComponent<Animator> ();
//			if (!animator.GetCurrentAnimatorStateInfo (0).IsName ("Advanced")) {
//				animator.SetTrigger ("Upgrade");
//				storedNectar -= 10;
//			} else {
//				tries--;
//				if (tries < 1)
//					break;
//			}
//		}
	}
}

