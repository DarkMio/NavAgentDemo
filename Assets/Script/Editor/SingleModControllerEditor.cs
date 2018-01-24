using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(SingleMobController))]
public class SingleModControllerEditor : Editor {

	public void OnSceneGUI() {
		var tgt = target as SingleMobController;
		if(!tgt.debug) {
			return;
		}
		if(Application.isPlaying) {
			Handles.color = Color.green;
			Handles.DrawWireDisc(tgt.originalPosition, Vector3.up, tgt.roamingRadius);
			Handles.color = Color.red;
			Handles.DrawWireDisc(tgt.transform.position, Vector3.up, tgt.aggressiveRadius);
			return;
		}
		Handles.color = Color.green;
		Handles.DrawWireDisc(tgt.transform.position, Vector3.up, tgt.roamingRadius);
		Handles.color = Color.red;
		Handles.DrawWireDisc(tgt.transform.position, Vector3.up, tgt.aggressiveRadius);
	}
}
