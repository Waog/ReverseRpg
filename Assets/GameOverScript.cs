using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {

	public Animator gameOverAC;

	void OnCollisionEnter(Collision collision) {
		if (collision.transform.tag.Equals(Tags.GOAL_SEGMENT)) {
			gameOverAC.SetTrigger ("Win");
		} else if (collision.gameObject.layer.Equals(Layers.WALL)) {
			gameOverAC.SetTrigger ("Lose");
		} else if (collision.transform.tag.Equals(Tags.TRAP)) {
			gameOverAC.SetTrigger ("Lose");
		}
	}
}
