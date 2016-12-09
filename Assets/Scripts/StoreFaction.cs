using UnityEngine;
using System.Collections;

public enum Faction {
	PLAYER,
	ENEMY,
	NEUTRAL,
	NONE
}

public class StoreFaction : MonoBehaviour {

	public Faction faction = Faction.NONE;

	void Start(){
		if (faction == Faction.ENEMY) {
			GetComponent<SpriteRenderer> ().color = new Color (0.7f, 1f, 0.7f);
		}
	}

	// Use this for initialization
	public void SetFaction(Faction value){
		faction = value;

		if (faction == Faction.ENEMY) {
			GetComponent<SpriteRenderer> ().color = new Color (0.7f, 1f, 0.7f);
		}
	}


	// Use this for initialization
	public Faction GetFaction(){
		return faction;
	}
}
