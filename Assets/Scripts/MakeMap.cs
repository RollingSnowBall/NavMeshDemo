using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MakeMap : MonoBehaviour {

	public NavMeshData navMeshData;

	void Awake(){
		Instantiate (Resources.Load ("Walls"));
		if (navMeshData) {
//			NavMeshDataInstance dI = NavMesh.AddNavMeshData (navMeshData);
//			dI.Remove ();
		}

		var surface = GetComponent<NavMeshSurface> ();
		if (surface) {
//			NavMesh.RemoveNavMeshData(
			surface.BuildNavMesh ();
			print ("MakeMap  BuildNavMesh");
		}
	}
}
