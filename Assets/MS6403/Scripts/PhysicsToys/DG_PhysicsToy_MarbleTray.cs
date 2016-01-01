using UnityEngine;
using System.Collections;

// -----------------------------------------------------
// A Physics Toy that implements a simple Marble Tilt Table
// 
// -----------------------------------------------------
public class DG_PhysicsToy_MarbleTray : DG_PhysicsToy_Base {

	// Property for controlling the amount of modification per keypress
	public float p_fRotateAmount = 0.1f;

	// Use this for initialization
	void Start () {
		base.Start ();
	}
	
	// Update is called once per frame
	void Update () {
		// Check if I'm active or not
		if (InputActive == false)
			return;

		// Check player has pressed action keys and Rotate tilt table		
		if (Input.GetKey(KeyCode.UpArrow)) 		transform.Rotate(p_fRotateAmount,0,0);	
		if (Input.GetKey(KeyCode.DownArrow)) 	transform.Rotate(-p_fRotateAmount,0,0);	
		if (Input.GetKey(KeyCode.LeftArrow)) 	transform.Rotate(0,-p_fRotateAmount,0);	
		if (Input.GetKey(KeyCode.RightArrow)) 	transform.Rotate(0,p_fRotateAmount,0);	
	}
}
