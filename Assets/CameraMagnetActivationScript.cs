using UnityEngine;
using System.Collections;

public class CameraMagnetActivationScript : MonoBehaviour {

	public bool isActivated = true;
	
	void OnTriggerEnter(Collider other) {

		if (other.gameObject.layer.Equals (Layers.WALL)) {
			isActivated = false;
		}
	}
}
