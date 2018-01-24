using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(CirclePlacement))]
[CanEditMultipleObjects]
public class CirclePlacementEditor : Editor {
	public override void OnInspectorGUI() {
		DrawDefaultInspector();

		var tgt = target as CirclePlacement;
		if(tgt == null) {
			return;
		}
		if(GUILayout.Button("Recalc")) {
			tgt.PlacePositions();
		}
	}
}
#endif

public class CirclePlacement : MonoBehaviour {

	public enum FaceDirection {
		East  = 0,
		North = 1,
		West  = 2,
		South = 3
	}
	public FaceDirection facing;

	[Range(0, 25)]
	public float distance;
	[Range(-180, 180)]
	public float rho;

	float _rho {
		get {
			return Mathf.Deg2Rad * (rho + (int) facing * 90);
		}
	}

	void Start () {
		PlacePositions();
	}

	public void PlacePositions() {
		transform.localPosition = new Vector3(Mathf.Cos(_rho) * distance, transform.localPosition.y, Mathf.Sin(_rho) * distance);
	}
}
