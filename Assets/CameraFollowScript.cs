using UnityEngine;
using System.Collections;

public class CameraFollowScript : MonoBehaviour {

	public Transform targetTransform;

	[Tooltip("0 = camera doesn't move; 1 = camera is at target position instantly")]
	public float drag = 0.2f;

	void Update () {
		transform.position = Vector3.Lerp (transform.position, targetTransform.position, drag);
		Vector3 newEulerAngles = new Vector3 ();
		newEulerAngles.x = Mathf.LerpAngle (transform.eulerAngles.x, targetTransform.eulerAngles.x, drag);
		newEulerAngles.y = Mathf.LerpAngle (transform.eulerAngles.y, targetTransform.eulerAngles.y, drag);
		newEulerAngles.z = Mathf.LerpAngle (transform.eulerAngles.z, targetTransform.eulerAngles.z, drag);
		transform.eulerAngles = newEulerAngles;
	}
}
