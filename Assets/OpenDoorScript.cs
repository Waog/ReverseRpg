using UnityEngine;
using System.Collections;

public class OpenDoorScript : MonoBehaviour {

	public void open() {
		Debug.Log ("door: open!");
		GetComponentInChildren<Animator>().SetTrigger ("Open");
	}
}
