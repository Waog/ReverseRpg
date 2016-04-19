using UnityEngine;
using System.Collections;

public class PreparePromoLevelScript : MonoBehaviour {

	public void prepare() {
		Transform doorA = transform.Find ("promo-level/DoorPlaceholderA");
		Transform switchA = transform.Find ("promo-level/SwitchPlaceholderA");
		Transform doorB = transform.Find ("promo-level/DoorPlaceholderB");
		Transform switchB = transform.Find ("promo-level/SwitchPlaceholderB");
		Transform doorC = transform.Find ("promo-level/DoorPlaceholderC");
		Transform switchC = transform.Find ("promo-level/SwitchPlaceholderC");
		switchA.GetComponentInChildren<SwitchScript> ().openDoorScript = doorA.GetComponentInChildren<OpenDoorScript> ();
		switchB.GetComponentInChildren<SwitchScript> ().openDoorScript = doorB.GetComponentInChildren<OpenDoorScript> ();
		switchC.GetComponentInChildren<SwitchScript> ().openDoorScript = doorC.GetComponentInChildren<OpenDoorScript> ();
	}
}
