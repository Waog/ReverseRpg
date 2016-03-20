using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}


	// Update is called once per frame
	void Update () {
		bool spaceDown = Input.GetKeyDown (KeyCode.Space);	
		if (spaceDown) {
			animator.SetTrigger("JumpTrigger");
		}
	}
}
