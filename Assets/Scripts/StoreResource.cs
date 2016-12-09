using UnityEngine;
using System.Collections;

public class StoreResource : MonoBehaviour {

	int _value;

	void SetAmount (int value) {
		_value = value;
	}

	public int GetAmount () {
		return _value;
	}
}
