using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WallDetectorScript : MonoBehaviour {

	public bool isDetectingWallLeft (){
		Ray ray = new Ray (transform.position + transform.TransformDirection(Vector3.up + 2 * Vector3.left), transform.TransformDirection(Vector3.left));
		int layerMask = 1 << Layers.WALL;
		return Physics.Raycast (ray, 2, layerMask);
	}

	public bool isDetectingWallRight (){
		Ray ray = new Ray (transform.position + transform.TransformDirection(Vector3.up + 2 * Vector3.right), transform.TransformDirection(Vector3.right));
		int layerMask = 1 << Layers.WALL;
		return Physics.Raycast (ray, 2, layerMask);
	}

	void Update() {
		Debug.DrawRay (transform.position + transform.TransformDirection(Vector3.up + 2 * Vector3.left), transform.TransformDirection(Vector3.left), Color.blue);
		Debug.DrawRay (transform.position + transform.TransformDirection(Vector3.up + 2 * Vector3.right), transform.TransformDirection(Vector3.right), Color.green);
	}
}
