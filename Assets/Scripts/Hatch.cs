using UnityEngine;
using System.Collections;

public class Hatch : StateMachineBehaviour
{

	public float timeToHatch = 8;
	public GameObject bar;

	GameObject _barInstance;

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.SetFloat ("TimeLeft", timeToHatch);

		_barInstance = Instantiate (bar);
		_barInstance.transform.localPosition = new Vector3 (animator.transform.position.x - _barInstance.GetComponent<Renderer> ().bounds.size.x / 2, animator.transform.position.y + 0.5f, animator.transform.position.z);
		_barInstance.transform.localScale = new Vector3 (0, 1, 1);
		_barInstance.GetComponent<SpriteRenderer> ().color = new Color (0.8f, 0.2f, 0.8f);
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		var time = animator.GetFloat ("TimeLeft") - Time.deltaTime;
		animator.SetFloat ("TimeLeft", time);
		_barInstance.transform.localScale = new Vector3 (time / timeToHatch, 1, 1);
		if (time < 0) {
			animator.SetTrigger ("HatchingComplete");
		}
	}


	override public void OnStateExit (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.gameObject.SendMessage ("Spawn");
		animator.ResetTrigger ("HatchingComplete");	

		Destroy (_barInstance);
	}
}
