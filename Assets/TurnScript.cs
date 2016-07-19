using UnityEngine;
using System.Collections;

public class TurnScript : MonoBehaviour {

	public void turn (float direction, Transform enteredSegment)
	{
		var sled = transform.parent;
		sled.position = new Vector3 (transform.position.x, 0, transform.position.z);
		sled.RotateAround (sled.position, Vector3.up, direction * 90);
		Vector3 globalDiffVectorToCurveCenter = enteredSegment.position - sled.position;
		Vector3 localDiffVectorToCurveCenter = sled.InverseTransformDirection (globalDiffVectorToCurveCenter);
		Vector3 localDiffVectorToCurveCenterProjected = new Vector3 (localDiffVectorToCurveCenter.x, 0, 0);
		Vector3 globalDiffVectorToCurveCenterProjected = sled.TransformDirection (localDiffVectorToCurveCenterProjected);
		sled.position += globalDiffVectorToCurveCenterProjected;
		//					curPlayerPositionIndex = 2;
		//					player.localPosition = new Vector3 (playerPositions [curPlayerPositionIndex], 0.1f, 0);
	}
}
