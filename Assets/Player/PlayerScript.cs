using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public Animator gameOverAC;

	bool isFalling = true;

	void Update() {
		if(Input.GetButton("Jump") && !isFalling) {
			Vector3 oldVelocity = GetComponent<Rigidbody> ().velocity;
			GetComponent<Rigidbody> ().velocity = new Vector3 (oldVelocity.x, oldVelocity.y + 5, oldVelocity.z);
		}

		isFalling = true;
	}

	void OnCollisionStay(Collision collision) {
		if (collision.gameObject.layer.Equals (Layers.FLOOR)) {
			isFalling = false;
		}
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.transform.tag.Equals(Tags.GOAL_SEGMENT)) {
			gameOverAC.SetTrigger ("Win");
		} else if (collision.gameObject.layer.Equals(Layers.WALL)) {
			gameOverAC.SetTrigger ("Lose");
		}
	}
}