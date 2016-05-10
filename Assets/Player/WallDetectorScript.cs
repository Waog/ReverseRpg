using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WallDetectorScript : MonoBehaviour {

	IList<Transform> CollidingWalls = new List<Transform>();

	public bool isDetectingWall (){
		return CollidingWalls.Count > 0; 
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.layer.Equals (Layers.WALL)) {
			CollidingWalls.Add (other.transform);	
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.layer.Equals (Layers.WALL)) {
			CollidingWalls.Remove (other.transform);
		}
	}
	
}
