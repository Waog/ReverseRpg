using UnityEngine;
using System.Collections;

public class CallTurnOrSwitchLaneScript : MonoBehaviour {

	public TurnScript turnScript;
	public SwitchLaneScript switchLaneScript;
	public CameraMagnetActivationScript cameraMagnetDeactivationScript;
	public WallDetectorScript wallDetectorScript;
	public TrackCurrentSegmentScript trackCurrentSegmentScript;
	private bool waitingForHorizontalAxisInput = true;
	private Transform latestTurnSegment = null;

	// Update is called once per frame
	void Update () {
		if(Input.GetAxisRaw("Horizontal") != 0) {
			if(waitingForHorizontalAxisInput) {
				waitingForHorizontalAxisInput = false;

				if(Input.GetAxisRaw("Horizontal") > 0){
					if (wallDetectorScript.isDetectingWallRight ()) {
						switchLaneAccordingToInput ();
					} else if(latestTurnSegment != trackCurrentSegmentScript.getCurrentSegment()){
						turnAccordingToInput ();
					}	
				}

				if(Input.GetAxisRaw("Horizontal") < 0){
					if (wallDetectorScript.isDetectingWallLeft ()) {
						switchLaneAccordingToInput ();
					} else if(latestTurnSegment != trackCurrentSegmentScript.getCurrentSegment()) {
						turnAccordingToInput ();
					}
				}
			}
		}

		if( Input.GetAxisRaw("Horizontal") == 0) {
			waitingForHorizontalAxisInput = true;
		}    
	}

	void turnAccordingToInput ()
	{
		turnScript.turn (Input.GetAxisRaw ("Horizontal"), trackCurrentSegmentScript.getCurrentSegment());
		latestTurnSegment = trackCurrentSegmentScript.getCurrentSegment();
		cameraMagnetDeactivationScript.isActivated = true;
	}

	void switchLaneAccordingToInput ()
	{
		switchLaneScript.switchLane (Input.GetAxisRaw ("Horizontal"));
	}

	void OnTriggerEnter(Collider other) {
		if (other.transform.tag.Equals(Tags.SEGMENT_COLLIDER)){
			latestTurnSegment = other.transform;
		}
	}
}
