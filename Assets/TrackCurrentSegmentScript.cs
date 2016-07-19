using UnityEngine;
using System.Collections;

public class TrackCurrentSegmentScript : MonoBehaviour {

	private Transform enteredSegment = null;

	void OnTriggerEnter(Collider other) {
		if (other.transform.tag.Equals(Tags.SEGMENT_COLLIDER)){
			enteredSegment = other.transform;
		}
	}

	public Transform getCurrentSegment() {
		return enteredSegment;
	}
}
