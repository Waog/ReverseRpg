using UnityEngine;
using System.Collections;

public class PreparePromoLevelScript : MonoBehaviour {

	public void prepare() {
		Transform doorA = transform.Find ("promo-level/DoorPlaceholderA");
		Transform switchA = transform.Find ("promo-level/SwitchPlaceholderA");
		switchA.GetComponentInChildren<SwitchScript> ().openDoorScript = doorA.GetComponentInChildren<OpenDoorScript> ();
	}
}
