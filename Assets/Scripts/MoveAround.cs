using UnityEngine;
using System.Collections;

public class MoveAround : MonoBehaviour
{
	public int[] disperse = { 3, 30 };
	public float velocity = 5;

	GameObject _home;
	GameObject _target;
	Vector2 _direction;
	int sign = 1;

	float _accumulated = 0;
	float _nextChange = 0;


	void Start ()
	{
		if (_home == null) {
			foreach (Collider2D hit in Physics2D.OverlapCircleAll(transform.position, 10f)) {
				if (hit.name.Contains ("queenBeeCell") && hit.GetComponent<StoreFaction> ().GetFaction () == GetComponent<StoreFaction> ().GetFaction ()) {
					_home = hit.gameObject;
					_target = _home;
				}
			}
			_direction = Quaternion.Euler (0, 0, Random.Range (0, 360)) * Vector3.up;
		}

		if (_home==null)
		Debug.Log (name);
	}


	void ResetTarget ()
	{
		_target = _home;
	}

	public GameObject GetTarget ()
	{
		return _target;
	}

	void SetTarget (GameObject value)
	{
		_target = value;
	}

	void SetDisperse (int[] value)
	{
		disperse = value;
	}

	void SetVelocity (float value)
	{
		velocity = value;
	}

	void Update ()
	{
		if (_target == null) {
			if (_home == null)
				return;
			else
				_target = _home;
		}

		if (velocity == 0)
			return;

		transform.Translate (_direction * Time.deltaTime * velocity, transform.parent);
		_direction = Quaternion.Euler (0, 0, sign * Vector2.Angle (_direction, (_target.transform.position - transform.position)) * 60 * Time.deltaTime / Random.Range (disperse [0], disperse [1])) * _direction;

		float angle = Mathf.DeltaAngle (Mathf.Atan2 (Vector2.up.y, Vector2.up.x) * Mathf.Rad2Deg,
			              Mathf.Atan2 (_direction.y, _direction.x) * Mathf.Rad2Deg);

		transform.eulerAngles = new Vector3 (0, 0, angle);

		_accumulated += Time.deltaTime;
		if (_accumulated > _nextChange) {
			sign *= -1;
			_accumulated = 0;
			_nextChange = Random.Range (5, 15) / 10f;
		}
	}
}
