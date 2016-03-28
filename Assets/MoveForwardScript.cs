using UnityEngine;
using System.Collections;

public class MoveForwardScript : MonoBehaviour {

	[Tooltip("in meter per second")]
	public float speed = 3f;

	private float[] playerPositions = { -1.9f, -0.95f, 0f, 0.95f, 1.9f };
	private int curPlayerPositionIndex = 2;

	private Transform enteredTurnSegment = null;

	private bool waitingForHorizontalAxisInput = true;
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.forward * Time.deltaTime * speed);

		if(Input.GetAxisRaw("Horizontal") != 0) {
			if(waitingForHorizontalAxisInput) {
				waitingForHorizontalAxisInput = false;

				Transform player = transform.GetChild (0);

				if (enteredTurnSegment != null) {
					turnAccordingToInput (player);
				} else {
					switchLaneAccordingToInput (player);
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
		Vector3 globalDiffVectorToCurveCenter = enteredTurnSegment.position - transform.position;
		Vector3 localDiffVectorToCurveCenter = transform.InverseTransformDirection (globalDiffVectorToCurveCenter);
		Vector3 localDiffVectorToCurveCenterProjected = new Vector3 (localDiffVectorToCurveCenter.x, 0, 0);
		Vector3 globalDiffVectorToCurveCenterProjected = transform.TransformDirection (localDiffVectorToCurveCenterProjected);
		transform.position += globalDiffVectorToCurveCenterProjected;
		enteredTurnSegment = null;
		//					curPlayerPositionIndex = 2;
		//					player.localPosition = new Vector3 (playerPositions [curPlayerPositionIndex], 0.1f, 0);
	}

	void switchLaneAccordingToInput (Transform player)
	{
		curPlayerPositionIndex += Mathf.RoundToInt (Input.GetAxisRaw ("Horizontal"));
		curPlayerPositionIndex = Mathf.Clamp (curPlayerPositionIndex, 0, 4);
		player.localPosition = new Vector3 (playerPositions [curPlayerPositionIndex], 0.1f, 0);
	}

	void OnTriggerEnter(Collider other) {
		if (other.transform.name.Contains ("L-Segment") 
				|| other.transform.name.Contains ("T-Segment") 
				|| other.transform.name.Contains ("O-Segment")) {
			enteredTurnSegment = other.transform;
			Debug.Log ("global: " + (enteredTurnSegment.position - transform.position));
			Debug.Log ("local direction: " + transform.InverseTransformDirection(enteredTurnSegment.position - transform.position));
		} else {
			enteredTurnSegment = null;
		}
	}
}
