using UnityEngine;
using System.Collections;

public class SwitchScript : MonoBehaviour {

	public OpenDoorScript openDoorScript;

	private Animator switchAC;

	// Use this for initialization
	void Start () {
		switchAC = transform.parent.GetComponent<Animator> ();
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag.Equals(Tags.PLAYER)) {
			switchAC.SetTrigger ("switch");
			openDoorScript.open ();
		}
	}
}
