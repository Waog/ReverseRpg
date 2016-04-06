using UnityEngine;
using System.Collections;

public class PreparePromoLevelScript : MonoBehaviour {

	public void prepare() {
		Transform door3 = transform.Find ("level-test/DoorPlaceholder_003");
		Transform switch1 = transform.Find ("level-test/SwitchPlaceholder_001");
		switch1.GetComponentInChildren<SwitchScript> ().openDoorScript = door3.GetComponentInChildren<OpenDoorScript> ();
	}
}
