using UnityEngine;
using System.Collections;

public class LayEgg : StateMachineBehaviour {

	GameObject _target;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		_target = animator.GetComponent<MoveAround> ().GetTarget ();
		_target.GetComponent<StoreFaction> ().SetFaction (animator.GetComponent<StoreFaction> ().GetFaction ());//todo cell can do that on collision with queen
		_target.GetComponent<Animator> ().SetTrigger ("EggLayed");//todo cell can do that on collision with queen

	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if (_target.GetComponent<Animator> ().GetCurrentAnimatorStateInfo(0).IsName("Spawning")){
			animator.SetTrigger("ActionDone");
		}
			
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		animator.ResetTrigger("ActionDone");
	}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
