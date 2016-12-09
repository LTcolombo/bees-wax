using UnityEngine;
using System.Collections;

[System.Serializable]
public struct TargetDesc
{
	public string tag;
	public float sight;
}

public class FindTarget : StateMachineBehaviour
{
	
	public TargetDesc[] targets;

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{

		foreach (TargetDesc target in targets) {

			var tag = target.tag;

			if (tag == "VacantCell" && SpawnQueue.queue.Count == 0)
				continue;
			
			foreach (Collider2D hit in Physics2D.OverlapCircleAll(animator.gameObject.transform.position, target.sight)) {

				if (hit.gameObject == null)
					continue;

				if (hit.tag == "Cell") {
					if (tag == "VacantCell" && hit.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("ReadyToHatch")) {
						animator.gameObject.SendMessage ("SetTarget", hit.gameObject);
						animator.SetTrigger ("TargetFound");
						return;
					} else if (tag == "HatchingCell" && hit.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("Hatching")) {

						animator.gameObject.SendMessage ("SetTarget", hit.gameObject);
						animator.SetTrigger ("TargetFound");
						return;
					
					} else if (tag == "SelectedCell" && hit.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("Selected")) {
						animator.gameObject.SendMessage ("SetTarget", hit.gameObject);
						animator.SetTrigger ("TargetFound");
						return;
					} else
						continue;
				}
				if (target.tag == "Enemy") {
					var faction = animator.gameObject.GetComponent<StoreFaction> ().GetFaction ();
					bool targetHasFaction = hit.gameObject.GetComponent<StoreFaction> () != null;
					bool isKilled = hit.gameObject.GetComponent<HealthStuff> () != null && hit.gameObject.GetComponent<HealthStuff> ().IsKilled ();

					if (targetHasFaction && !isKilled) {
						if (faction == Faction.ENEMY && hit.gameObject.GetComponent<StoreFaction> ().GetFaction () == Faction.PLAYER) {
							animator.gameObject.SendMessage ("SetTarget", hit.gameObject);
							animator.SetTrigger ("TargetFound");
							return;
						} else if (faction == Faction.PLAYER && hit.gameObject.GetComponent<StoreFaction> ().GetFaction () == Faction.ENEMY) {
							animator.gameObject.SendMessage ("SetTarget", hit.gameObject);
							animator.SetTrigger ("TargetFound");
							return;
						}
					}
				}

				if (hit.tag == tag) {
					animator.gameObject.SendMessage ("SetTarget", hit.gameObject);
					animator.SetTrigger ("TargetFound");
					return;
				}
			}
		}
			
		animator.SetTrigger ("NoTargetFound");
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
