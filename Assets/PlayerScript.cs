using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public Animator gameOverAC;

	void OnCollisionEnter(Collision collision) {
		Debug.Log (collision.transform.name);
		gameOverAC.SetTrigger ("GameOver");
	}
}