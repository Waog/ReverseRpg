using UnityEngine;
using System.Collections;

public class CoinScript : MonoBehaviour {
	
	void OnTriggerEnter(Collider other) {
		if (other.tag.Equals(Tags.PLAYER)) {
			Destroy (transform.parent.gameObject);
		}
	}
}
