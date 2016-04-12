using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ReplacementPrefabs : MonoBehaviour {
	public List<GameObject> prefabs;

	public GameObject getByName(string name) {
		foreach (GameObject prefab in prefabs) {
			if (prefab.name.Equals (name, StringComparison.InvariantCultureIgnoreCase)) {
				return prefab;
			}
		}
		return null;
	}
}
