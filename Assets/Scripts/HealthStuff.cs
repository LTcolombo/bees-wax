using UnityEngine;
using System.Collections;

public class HealthStuff : MonoBehaviour
{

	public int maxHealth;
	public GameObject bar;

	int _current;
	bool _killed;
	GameObject _barInstance;

	// Use this for initialization
	void Start ()
	{
		_current = maxHealth;
		_barInstance = (GameObject)Instantiate (bar, transform.parent);
		_barInstance.transform.localPosition = new Vector3 (transform.position.x, transform.position.y + 0.3f, transform.position.z);
		_barInstance.GetComponent<SpriteRenderer> ().color = new Color (0, 1, 0);
		_barInstance.SetActive (false);
	}

	void Update ()
	{
		_barInstance.transform.localPosition = new Vector3 (transform.position.x, transform.position.y + 0.3f, transform.position.z);
	}

	// Update is called once per frame
	void DecHealth (int value)
	{
		_current -= value;

		if (_current <= 0) {
			_current = 0;
			_killed = true;
			GetComponent<Animator> ().SetTrigger ("NeedsHealing");
		}

		var percent = (float)_current / maxHealth;
		var sqrt_percent = Mathf.Sqrt (percent);
		_barInstance.SetActive (true);
		_barInstance.transform.localScale = new Vector3 (percent, 1, 1);
		_barInstance.GetComponent<SpriteRenderer> ().color = new Color (1 - percent * percent * percent, sqrt_percent, 0);
	}

	void IncHealth (int value)
	{
		_current += value;

		if (_current >= maxHealth) {
			_killed = false;
			_current = maxHealth;
			_barInstance.SetActive (false);
			GetComponent<Animator> ().SetTrigger ("Healed");
		}	

		var percent = (float)_current / maxHealth;
		var sqrt_percent = Mathf.Sqrt (percent);
		_barInstance.transform.localScale = new Vector3 (percent, 1, 1);
		_barInstance.GetComponent<SpriteRenderer> ().color = new Color (1 - percent * percent * percent, sqrt_percent, 0);
	}

	public bool IsFull ()
	{
		return _current == maxHealth;
	}

	public bool IsKilled ()
	{
		return _killed;
	}
}
