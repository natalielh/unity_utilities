using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamePosAsCam : MonoBehaviour {

	Vector3 campos = new Vector3();

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

		campos = Camera.main.transform.position;

		//set the current transform's x and z values to the same values as the main camera
		//by default, the y-position is kept at ZERO every frame
		transform.position = new Vector3(campos.x, 0, campos.z);
	}
}
