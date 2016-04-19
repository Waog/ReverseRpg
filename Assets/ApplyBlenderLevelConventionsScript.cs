using UnityEngine;
using System.Collections;
using UnityEditor;

public class ApplyBlenderLevelConventionsScript : MonoBehaviour {
	const string COLLIDER_OBJ = "ColliderObj";
	const string TRIGGER_OBJ = "TriggerObj";
	const string GOAL_SEGMENT = "GoalSegment";
	const string SWITCH = "SwitchPlaceholder";
	const string DOOR = "DoorPlaceholder";

	const string PLACEHOLDER = "Placeholder";

	const string TEMPLATE = "Template";

	const string MAP_OBJ = "MapObj";

	public GameObject levelPrefab;

	// Use this for initialization
	void Start () {
		// ApplyBlenderLevelConventions (transform);
	}

	public void apply () {
		PrefabUtility.ConnectGameObjectToPrefab(transform.GetChild(0).gameObject, levelPrefab);
		//PrefabUtility.ResetToPrefabState (transform.GetChild(0).gameObject);
		PrefabUtility.RevertPrefabInstance (transform.GetChild (0).gameObject);
		ApplyBlenderLevelConventions(transform);
		GetComponent<PreparePromoLevelScript> ().prepare ();
	}

	void ApplyBlenderLevelConventions (Transform element){
		AddMeshColliders (element);
		HideColliderMeshes (element);
		AddMeshTriggers (element);
		HideTriggerMeshes (element);
		AddLayers (element);
		AddTags (element);
		DeleteTemplate (element);
		if (element == null) {
			return;
		}
		FillPlaceHolder (element);

		for (int i = element.childCount - 1; i >= 0; i--) {
			ApplyBlenderLevelConventions (element.GetChild(i));
		}
		PrepareDoors (element);
		PrepareSwitches (element);
	}

	void AddTags(Transform transform){
		if (transform.name.Contains (COLLIDER_OBJ)) {
			transform.tag = Tags.SEGMENT_COLLIDER;
		}

		if (transform.name.Contains (GOAL_SEGMENT)) {
			transform.tag = Tags.GOAL_SEGMENT;
		}
	}

	void AddLayers(Transform transform){
		if (transform.name.Contains (MAP_OBJ)) {
			transform.gameObject.layer = Layers.MINI_MAP;
		}
	}

	void AddMeshColliders(Transform transform) {
		if (transform.name.Contains(COLLIDER_OBJ)) {
			transform.gameObject.AddComponent<MeshCollider> ();
		}
	}

	void HideColliderMeshes(Transform transform) {
		if (transform.name.Contains(COLLIDER_OBJ)) {
			transform.GetComponent<MeshRenderer> ().enabled = false;
		}
	}

	void AddMeshTriggers (Transform transform) {
		if (transform.name.Contains(TRIGGER_OBJ)) {
			MeshCollider newCollider = transform.gameObject.AddComponent<MeshCollider> ();
			newCollider.convex = true;
			newCollider.isTrigger = true;
		}
	}

	void PrepareSwitches (Transform transform) {
		if (transform.name.Contains(SWITCH)) {
			GameObject colliderGo = transform.GetComponentInChildren<Collider> ().gameObject;
			colliderGo.AddComponent<SwitchScript> ();
			Animator animator = transform.GetComponentInChildren<Animator> ();
			RuntimeAnimatorController rac = Resources.Load("switchAC") as RuntimeAnimatorController;
			animator.runtimeAnimatorController = rac;

		}
	}

	void PrepareDoors (Transform transform) {
		if (transform.name.Contains(DOOR)) {
			Animator animator = transform.GetComponentInChildren<Animator> ();
			animator.applyRootMotion = true;
			RuntimeAnimatorController rac = Resources.Load("doorAC") as RuntimeAnimatorController;
			animator.runtimeAnimatorController = rac;
			animator.gameObject.AddComponent<OpenDoorScript> ();
		}
	}

	void HideTriggerMeshes(Transform transform) {
		if (transform.name.Contains(TRIGGER_OBJ)) {
			transform.GetComponent<MeshRenderer> ().enabled = false;
		}
	}

	void DeleteTemplate(Transform transform) {
		if (transform.name.Contains (TEMPLATE)) {
			DestroyImmediate (transform.gameObject);
		}
	}

	void FillPlaceHolder(Transform transform) {
		if (transform.name.Contains (PLACEHOLDER)) {
			int indexOfPlaceholder = transform.name.IndexOf (PLACEHOLDER);
			string nameBeforePlaceholder = transform.name.Substring (0, indexOfPlaceholder);
			GameObject replacerPrefab = GetComponent<ReplacementPrefabs> ().getByName (nameBeforePlaceholder);
			GameObject newObject = (GameObject) Instantiate (replacerPrefab, transform.position, transform.rotation);
			transform.localRotation = Quaternion.identity;
			newObject.transform.parent = transform;
//			DestroyImmediate (transform.gameObject);
		}
	}
}
