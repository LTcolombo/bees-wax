using UnityEngine;
using System.Collections;

public class CheckTargetTimer : StateMachineBehaviour
{
	public float interval;
	public float delay = 0;

	float _accumulated;
//
	override public void OnStateEnter (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		_accumulated = interval - delay;
	}
//
	override public void OnStateUpdate (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		_accumulated += Time.deltaTime;
		if (_accumulated > interval) {
			_accumulated = 0;
			animator.SetTrigger ("TimeToCheckTarget");
		}
	}
}
