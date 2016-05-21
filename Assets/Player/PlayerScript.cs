using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public int JUMP_VELOCITY = 8;

	public Animator gameOverAC;

	bool grounded = false;

	void Update() {
		if(Input.GetButton("Jump") && grounded) {
			Vector3 oldVelocity = GetComponent<Rigidbody> ().velocity;
			GetComponent<Rigidbody> ().velocity = new Vector3 (oldVelocity.x, JUMP_VELOCITY, oldVelocity.z);
			grounded = false;f
		}

	}

	void OnCollisionStay(Collision collision) {
		if (collision.gameObject.layer.Equals (Layers.FLOOR) && GetComponent<Rigidbody> ().velocity.y <= 0) {
			grounded = true;
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