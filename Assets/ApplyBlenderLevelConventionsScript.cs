using UnityEngine;
using System.Collections;

public class ApplyBlenderLevelConventionsScript : MonoBehaviour {
	const string COLLIDER_OBJ = "ColliderObj";
	const string GOAL_SEGMENT = "GoalSegment";

	const string MAP_OBJ = "MapObj";

	// Use this for initialization
	void Start () {
		ApplyBlenderLevelConventions (transform);
	}

	void ApplyBlenderLevelConventions (Transform element){
		AddMeshColliders (element);
		AddLayers (element);
		AddTags (element);
		HideColliderMeshes (element);

		for (int i = 0; i < element.childCount; i++) {
			ApplyBlenderLevelConventions (element.GetChild(i));
		}
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
}
