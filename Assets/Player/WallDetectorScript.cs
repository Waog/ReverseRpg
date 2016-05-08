using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WallDetectorScript : MonoBehaviour {

	IList<Transform> CollidingSegments = new List<Transform>();

	public bool isDetectingWall (){
		return CollidingSegments.Count > 0; 
	}

	void OnTriggerEnter(Collider other) {
		CollidingSegments.Add (other.transform);	
	}

	void OnTriggerExit(Collider other) {
		CollidingSegments.Remove (other.transform);
	}
	
}
