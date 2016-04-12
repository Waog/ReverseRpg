using UnityEngine;
using System.Collections;

public class DoorOpeningSwitchScript : MonoBehaviour {

	public GameObject door;

	private Animator switchAC;

	// Use this for initialization
	void Start () {
		switchAC = transform.parent.GetComponent<Animator> ();
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.tag.Equals(Tags.PLAYER)) {
			switchAC.SetTrigger ("switch");
			door.GetComponent<Animator>().SetTrigger ("Open");
		}
	}
}
