using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public Animator gameOverAC;

	void OnCollisionEnter(Collision collision) {
		if (collision.transform.tag.Equals(Tags.GOAL_SEGMENT)) {
			gameOverAC.SetTrigger ("Win");
		} else {
			gameOverAC.SetTrigger ("Lose");
		}
	}
}