using UnityEngine;
using System.Collections;

public class MoveForwardScript : MonoBehaviour {

	[Tooltip("in meter per second")]
	public float speed = 3f;

	// Update is called once per frame
	void Update () {
		transform.parent.Translate (Vector3.forward * Time.deltaTime * speed);
		handleStuckPlayer ();
	}

	void handleStuckPlayer ()
	{
		transform.parent.Translate (Vector3.forward * transform.localPosition.z);
		transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y, 0);
	}
}
