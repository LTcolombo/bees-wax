using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class ReleaseResources : StateMachineBehaviour {
	public GameObject text;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		var storedValue = animator.gameObject.GetComponent<StoreResource> ().GetAmount ();

		if (animator.gameObject.GetComponent<StoreFaction> ().GetFaction() == Faction.PLAYER) {
			var t = Instantiate (text);
			var _parent = GameObject.FindGameObjectWithTag ("TextEffects").transform;
			t.transform.SetParent (_parent, false);

			RectTransform CanvasRect = _parent.GetComponent<RectTransform> ();

			Vector3[] corners = new Vector3[4];
			CanvasRect.GetWorldCorners (corners);
			Vector2 canvasRelativePosition = new Vector2 (
				                                (animator.gameObject.transform.position.x - corners [0].x) / (corners [2].x - corners [0].x),
				                                (animator.gameObject.transform.position.y - corners [0].y) / (corners [1].y - corners [0].y)
			                                );
			Vector2 WorldObject_ScreenPosition = new Vector2 (
				                                    (((canvasRelativePosition.x) * CanvasRect.sizeDelta.x)),
				                                    (((canvasRelativePosition.y) * CanvasRect.sizeDelta.y)));

			t.GetComponent<Text> ().text = "+" + storedValue;
			//now you can set the position of the ui element
			t.GetComponent<RectTransform> ().anchoredPosition = WorldObject_ScreenPosition;


			var totalText = GameObject.FindGameObjectWithTag ("TotalNectar");
			Text tt = totalText.GetComponent<Text> ();
			int value = Int32.Parse (tt.text);
			value += storedValue;
			tt.text = value.ToString ();
		}

		if (animator.gameObject.GetComponent<StoreFaction> ().GetFaction() == Faction.ENEMY) {
			EnemyState.addNectar(storedValue);
		}

		animator.SetTrigger ("ResourcesReleased");
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
