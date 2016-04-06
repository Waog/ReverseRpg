using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(ApplyBlenderLevelConventionsScript))]
public class ApplyBlenderLevelConventionsEditor : Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

		ApplyBlenderLevelConventionsScript myScript = (ApplyBlenderLevelConventionsScript)target;
		if(GUILayout.Button("Build Object"))
		{
			myScript.apply ();
		}
	}
}