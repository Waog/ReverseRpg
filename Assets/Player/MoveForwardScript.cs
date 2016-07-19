using UnityEngine;
using System.Collections;

public class MoveForwardScript : MonoBehaviour {

	[Tooltip("in meter per second")]
	public float speed = 3f;
	public TurnScript turnScript;
	public SwitchLaneScript switchLaneScript;
	public CameraMagnetActivationScript cameraMagnetDeactivationScript;
	public WallDetectorScript wallDetectorScript;

	private bool waitingForHorizontalAxisInput = true;

	private Transform enteredSegment = null;

	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.forward * Time.deltaTime * speed);
		Transform player = transform.GetChild (0);
		transform.Translate (Vector3.forward * player.transform.localPosition.z);
		player.transform.localPosition = new Vector3 (player.transform.localPosition.x, player.transform.localPosition.y, 0);


		if(Input.GetAxisRaw("Horizontal") != 0) {
			if(waitingForHorizontalAxisInput) {
				waitingForHorizontalAxisInput = false;

				if(Input.GetAxisRaw("Horizontal") > 0){
					if (wallDetectorScript.isDetectingWallRight ()) {
						switchLaneAccordingToInput ();
					} else if(enteredSegment != null){
						turnAccordingToInput ();
					}	
				}

				if(Input.GetAxisRaw("Horizontal") < 0){
					if (wallDetectorScript.isDetectingWallLeft ()) {
						switchLaneAccordingToInput ();
					} else if(enteredSegment != null) {
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
		turnScript.turn (Input.GetAxisRaw ("Horizontal"), enteredSegment);
		enteredSegment = null;
		cameraMagnetDeactivationScript.isActivated = true;
	}

	void switchLaneAccordingToInput ()
	{
		switchLaneScript.switchLane (Input.GetAxisRaw ("Horizontal"));
	}

	void OnTriggerEnter(Collider other) {
		if (other.transform.tag.Equals(Tags.SEGMENT_COLLIDER)){
			enteredSegment = other.transform;
		}
	}
}
