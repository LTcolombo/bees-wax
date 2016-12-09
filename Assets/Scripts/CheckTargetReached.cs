using UnityEngine;
using System.Collections;

public class CheckTargetReached : StateMachineBehaviour {
	Collider2D _targetCollider;
	Collider2D _collider;
	MoveAround _moveAround;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		_moveAround = animator.gameObject.GetComponent<MoveAround> ();
		_collider = animator.gameObject.GetComponent<Collider2D>();
		_targetCollider = null;
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if (_targetCollider == null) {
			//todo need somehow to get this value from findTargetState
			if (_moveAround.GetTarget () == null) {
				return;
			} else {
				_targetCollider = _moveAround.GetTarget ().GetComponent<Collider2D> ();
			}
		}
//
		if (_targetCollider.OverlapPoint (_collider.bounds.center)){
			animator.SetTrigger ("TargetReached"); //todo decouple from animation (maybe a different behaviour)
		}
	}

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
