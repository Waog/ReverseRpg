using UnityEngine;
using System.Collections;

public class SwitchLaneScript : MonoBehaviour {
	
	private float[] playerPositions = { -1.9f, -0.95f, 0f, 0.95f, 1.9f };
	private int curPlayerPositionIndex = 2;

	public void switchLane(float direction)
	{
		curPlayerPositionIndex += Mathf.RoundToInt (direction);
		curPlayerPositionIndex = Mathf.Clamp (curPlayerPositionIndex, 0, 4);
		transform.localPosition = new Vector3 (playerPositions [curPlayerPositionIndex], 0.1f, 0);
	}
}
