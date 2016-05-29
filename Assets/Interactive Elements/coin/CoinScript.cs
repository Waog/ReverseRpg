using UnityEngine;
using System.Collections;

public class CoinScript : MonoBehaviour {

	CoinPouchScript coinPouchScript;

	void Start() {
		coinPouchScript = FindObjectOfType<CoinPouchScript> ();
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag.Equals(Tags.PLAYER)) {
			coinPouchScript.collectedCoins++;
			Destroy (transform.parent.gameObject);
		}
	}
}
