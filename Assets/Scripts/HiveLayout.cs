using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class HiveLayout : MonoBehaviour
{
	public GameObject text;

	// Use this for initialization
	void Start ()
	{
	}

	// Update is called once per frame
	void Update ()
	{
		Vector2 touchPos;
		bool aTouch;
		bool altTouch = false;

		if (Application.isMobilePlatform) {
			// touchscreen
			aTouch = (Input.touchCount > 0);
			touchPos = Input.touches [0].position;
		} else {
			// mouse
			aTouch = Input.GetMouseButtonDown (0);
			altTouch = Input.GetMouseButtonDown (1);
			touchPos = Input.mousePosition;
		}

		if (aTouch || altTouch) {
			var vector3 = Camera.main.ScreenToWorldPoint (touchPos);
			RaycastHit2D hit = Physics2D.Raycast (vector3, Vector3.forward, 10f);

			if (hit.transform != null) {
				OnCellTouch (hit.transform.gameObject, altTouch);
			}
		}
	}

	void OnCellTouch (GameObject cell, bool alt)
	{
		var animator = cell.GetComponent<Animator> ();
		if (animator == null) {
			return;
		}

		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Available"))
			animator.SetTrigger ("Selected");

//
//		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Available")) {
//			foreach (Collider2D hit in Physics2D.OverlapCircleAll(cell.transform.position, 4)) {
//				if (hit.tag == "Queen" && hit.GetComponent<StoreFaction>().GetFaction() == Faction.PLAYER) {
//					hit.SendMessage("SetTarget", cell);
//				}
//			}
//		}
//
//
//		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Empty"))
//			return;
//
//		///////////////////
//
//
//		var cost = 10;
//
//		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Basic"))
//			cost = 30;
//
//		var totalText = GameObject.FindGameObjectWithTag ("TotalNectar");
//		Text tt = totalText.GetComponent<Text> ();
//		int value = Int32.Parse(tt.text);
//
//		if (value < cost) {
//			return;
//		}
//		value -= cost;
//		tt.text = value.ToString ();
//
//
//		var t = Instantiate (text);
//		var _parent = GameObject.FindGameObjectWithTag ("TextEffects").transform;
//		t.transform.SetParent (_parent, false);
//
//		RectTransform CanvasRect = _parent.GetComponent<RectTransform> ();
//
//		Vector3[] corners = new Vector3[4];
//		CanvasRect.GetWorldCorners (corners);
//		Vector2 canvasRelativePosition = new Vector2 (
//			(animator.gameObject.transform.position.x - corners[0].x)/(corners[2].x - corners[0].x),
//			(animator.gameObject.transform.position.y - corners[0].y)/(corners[1].y - corners[0].y)
//		);
//		Vector2 WorldObject_ScreenPosition = new Vector2 (
//			(((canvasRelativePosition.x) * CanvasRect.sizeDelta.x)),
//			(((canvasRelativePosition.y) * CanvasRect.sizeDelta.y)));
//
//		t.GetComponent<Text> ().text = "-" + cost;
//		//now you can set the position of the ui element
//		t.GetComponent<RectTransform>().anchoredPosition = WorldObject_ScreenPosition;
//
		///////////////////

//		animator.SetTrigger ("Upgrade");
	}
}

