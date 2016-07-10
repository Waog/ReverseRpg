using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WallDetectorScript : MonoBehaviour {

	public bool isDetectingWall (){
		Ray ray = new Ray (transform.position + Vector3.up + 2 * Vector3.left, Vector3.left);

		return Physics.Raycast (ray, 2, Layers.WALL);
	}

	void Update() {
		Debug.DrawRay (transform.position + Vector3.up + 2 * Vector3.left, Vector3.left, Color.blue);
		Debug.DrawRay (transform.position + Vector3.up + 2 * Vector3.right, Vector3.right, Color.green);
	}
}
