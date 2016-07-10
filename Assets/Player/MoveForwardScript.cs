using UnityEngine;
using System.Collections;

public class MoveForwardScript : MonoBehaviour {

	[Tooltip("in meter per second")]
	public float speed = 3f;
	public CameraMagnetActivationScript cameraMagnetDeactivationScript;
	private float[] playerPositions = { -1.9f, -0.95f, 0f, 0.95f, 1.9f };
	private int curPlayerPositionIndex = 2;

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

				Transform wallDetectorLeft = transform.FindChild ("wallDetectorLeft");
				Transform wallDetectorRight = transform.FindChild ("wallDetectorRight");

				if(Input.GetAxisRaw("Horizontal") > 0){
					//TODO TurnCharacterRight or switch Lane to right
					if (wallDetectorRight.GetComponent<WallDetectorScript>().isDetectingWall ()) {
						switchLaneAccordingToInput (player);
					} else if(enteredSegment != null){
						turnAccordingToInput (player);
					}	
				}

				if(Input.GetAxisRaw("Horizontal") < 0){
					//TODO TurnCharacterLeft or switch Lane to left
					if (wallDetectorLeft.GetComponent<WallDetectorScript>().isDetectingWall ()) {
						switchLaneAccordingToInput (player);
					} else if(enteredSegment != null) {
						turnAccordingToInput (player);
					}	
				}
			}
		}

		if( Input.GetAxisRaw("Horizontal") == 0) {
			waitingForHorizontalAxisInput = true;
		}    
	}

	void turnAccordingToInput (Transform player)
	{
		transform.position = new Vector3 (player.position.x, 0, player.position.z);
		transform.RotateAround (transform.position, Vector3.up, Input.GetAxisRaw ("Horizontal") * 90);
		Vector3 globalDiffVectorToCurveCenter = enteredSegment.position - transform.position;
		Vector3 localDiffVectorToCurveCenter = transform.InverseTransformDirection (globalDiffVectorToCurveCenter);
		Vector3 localDiffVectorToCurveCenterProjected = new Vector3 (localDiffVectorToCurveCenter.x, 0, 0);
		Vector3 globalDiffVectorToCurveCenterProjected = transform.TransformDirection (localDiffVectorToCurveCenterProjected);
		transform.position += globalDiffVectorToCurveCenterProjected;
		enteredSegment = null;
		//					curPlayerPositionIndex = 2;
		//					player.localPosition = new Vector3 (playerPositions [curPlayerPositionIndex], 0.1f, 0);
		cameraMagnetDeactivationScript.isActivated = true;
	}

	void switchLaneAccordingToInput (Transform player)
	{
		curPlayerPositionIndex += Mathf.RoundToInt (Input.GetAxisRaw ("Horizontal"));
		curPlayerPositionIndex = Mathf.Clamp (curPlayerPositionIndex, 0, 4);
		player.localPosition = new Vector3 (playerPositions [curPlayerPositionIndex], 0.1f, 0);
	}

	void OnTriggerEnter(Collider other) {
		if (other.transform.tag.Equals(Tags.SEGMENT_COLLIDER)){
			enteredSegment = other.transform;
		}
	}
}
