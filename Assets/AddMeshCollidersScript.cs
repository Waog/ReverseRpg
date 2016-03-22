using UnityEngine;
using System.Collections;

public class AddMeshCollidersScript : MonoBehaviour {

	[Tooltip("All gameobject which names contain this string, are provided with a mesh collider. Leave empty to affect all child objects.")]
	public string effectedName = "";

	// Use this for initialization
	void Start () {
		AddMeshCollider (transform);
	}

	private void AddMeshCollider(Transform transform) {
		if (transform.name.Contains(effectedName)) {
			transform.gameObject.AddComponent<MeshCollider> ();
		}

		for (int i = 0; i < transform.childCount; i++) {
			AddMeshCollider (transform.GetChild (i));
		}
	}
}
