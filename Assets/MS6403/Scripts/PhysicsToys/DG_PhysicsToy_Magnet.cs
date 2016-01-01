using UnityEngine;
using System.Collections;

// -----------------------------------------------------
// A Physics Toy that implements a central magnet
// that players can toggle on and off
// -----------------------------------------------------
public class DG_PhysicsToy_Magnet : DG_PhysicsToy_Base {
	
	public float	m_fMagnetForce = 0.2f;		// Strength of the magnet
	public float	m_fForceDirection = 1.0f;	// Initial force direction

	// Use this for initialization
	void Start ()
    {
		// Just call the DG_PhysicsToy_Base
		base.Start ();
	}
	
	// Update is called once per frame
	void Update () {
		// Check if our input is active. InputActive belongs to our base DG_PhysicsToy_Base
		if (InputActive == false)
			return;

		// If the player presses the up arrow, set the force direction to be +ve
		if (Input.GetKey (KeyCode.UpArrow)) {
			m_fForceDirection = 1.0f;	
		}

		// If the player presses the down arrow, set the force direction to be -ve
		if (Input.GetKey (KeyCode.DownArrow))
		{
			m_fForceDirection = -2.0f;
		}

		// Find all game objects tagged 'Magnetic'
		GameObject[] objects = GameObject.FindGameObjectsWithTag ("Magnetic");
	
		// Loop through all of the found objects and apply a force to each in line with our magnet position & direction
		foreach (GameObject o in objects) {
			Vector3 v3Dir = o.transform.position - transform.position;
			v3Dir.Normalize();

			o.GetComponent<Rigidbody>().AddForce (-v3Dir * m_fMagnetForce * m_fForceDirection);
		}
	}
}
