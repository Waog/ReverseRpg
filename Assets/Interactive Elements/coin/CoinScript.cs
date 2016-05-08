using UnityEngine;
using System.Collections;

public class CoinScript : MonoBehaviour {
	
	void OnTriggerEnter(Collider other) {
		if (other.tag.Equals(Tags.PLAYER)) {
			FindObjectOfType<CoinPouchScript> ().collectedCoins++;
			Destroy (transform.parent.gameObject);
		}
	}
}
