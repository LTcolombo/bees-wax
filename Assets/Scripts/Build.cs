using UnityEngine;
using System.Collections;

public class Build : StateMachineBehaviour
{
	public float timeToBuild = 5f;
	public GameObject bar;
	GameObject _barInstance;

	float _accumulated = 0f;

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		_accumulated = 0;
		_barInstance = Instantiate (bar);
		_barInstance.transform.localPosition = new Vector3 (animator.transform.position.x - _barInstance.GetComponent<Renderer>().bounds.size.x/2, animator.transform.position.y + 0.5f, animator.transform.position.z);
		_barInstance.transform.localScale = new Vector3 (0, 1, 1);
		_barInstance.GetComponent<SpriteRenderer> ().color = new Color (0.3f, 0.5f, 0.8f);
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		_accumulated += Time.deltaTime;
		_barInstance.transform.localScale = new Vector3 (_accumulated/timeToBuild, 1, 1);
		if (_accumulated > timeToBuild) {
			animator.SetTrigger ("Built");	
		}
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		Destroy (_barInstance);
		_accumulated = 0;
		animator.ResetTrigger ("Built");	
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
