using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{

	public Vector3 offset;

	public float time;

	void Start ()
	{
		transform.DOBlendableMoveBy (offset, time + 0.1f).OnComplete(Kill);
		GetComponent<Text> ().DOFade (0, time);
	}

	void Kill ()
	{
		Destroy (gameObject);
	}
}
