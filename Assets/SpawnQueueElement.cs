using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpawnQueueElement : MonoBehaviour
{
	public int index;

	string _currentName;
	
	// Update is called once per frame
	void Update ()
	{
		if (SpawnQueue.queue.Count > index) {
			GameObject queueElem = SpawnQueue.queue [index];
			if (_currentName != queueElem.name) {
				Sprite sprite = ((GameObject)queueElem).GetComponent<SpriteRenderer> ().sprite;
				transform.Find ("placeholder").gameObject.GetComponent<Image> ().sprite = sprite;
				transform.Find ("placeholder").gameObject.SetActive (true);
				transform.
				transform.Find ("index").gameObject.SetActive (false);
			} 
		}else {
			transform.Find ("placeholder").gameObject.SetActive (false);
			transform.Find ("index").gameObject.SetActive (true);
			_currentName = null;
		}
	}
}
