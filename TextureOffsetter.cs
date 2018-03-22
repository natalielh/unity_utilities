using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureOffsetter : MonoBehaviour {

	/*
		This script allows you to offset textures' x and y offset values over time
		Use by attaching this script to a gameobject and setting the x and y scroll speeds

		In the inspector, set the "Size" of the "Scroll_speeds" array to the number of materials
		attached to your gameobject (if you have 1 material attached, type in "1")
	*/

	//array to store original offset data of textures set in the inspector
	private Vector2[] scroll_origoffsets;

	//inspector-settable scroll speed that acts as a manual multiplier
	[Range(-3.0f,3.0f)]
	public float local_scroll_speed = 1.0f;

	//material information
	private Material[] mats;
	//number of textures applied to this GameObject (the thing this script is attached to)
	private int num_mats;

	//inspector-settable array to set the speeds for the scrolling textures
	//[Range(-0.5f,0.5f)]
	public Vector2[] scroll_speeds;

	// Use this for initialization
	void Start () {

		Renderer renderer = GetComponent<Renderer>();
		mats = renderer.materials;
		num_mats = renderer.materials.Length;

		scroll_origoffsets = new Vector2[num_mats];

		//get original offsets set in the editor for each texture attached
		for(int i=0; i<num_mats; i++){
			scroll_origoffsets[i] = mats[i].GetTextureOffset("_MainTex");
		}

	}
	
	// Update is called once per frame
	void Update () {

		for(int i=0; i<num_mats; i++){
			Vector2 offset = (mats[i].GetTextureOffset("_MainTex")) + (Time.deltaTime * local_scroll_speed * scroll_speeds[i]);
			mats[i].SetTextureOffset("_MainTex", offset);
		}

	}
}
