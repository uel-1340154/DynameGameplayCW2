using UnityEngine;
using System.Collections;

// -----------------------------------------------------
// A Physics Toy that implements the block slider / ball drop
// 
// -----------------------------------------------------
public class DG_PhysicsToy_Slider : DG_PhysicsToy_Base {

	// Owner gameobjects for the sliders. Generally, these will be an empty object with 
	// 2x cubes creating a gap
	public GameObject[] m_blocks = new GameObject[0];

	// The nudge force applied to each block on a keypress
	public float m_fNudgeForce = 2.0f;

	// Use this for initialization
	void Start () {
		base.Start ();

		// Reset our index. This keeps track of which block we're interacting with
		m_nCurrentIndex = 0;

		// The actual object (just grab it from our array)
		m_goCurrentActiveBlock = m_blocks [m_nCurrentIndex];
	}
	
	// Update is called once per frame
	void Update () {
		if (InputActive == false)
			return;

		// If the player presses the up arrow, change to the previous
		// block in our array. 
		if (Input.GetKeyUp (KeyCode.UpArrow)) {
			m_nCurrentIndex--;
			// Handle wrapping our index if we go below zero
			if (m_nCurrentIndex < 0)
				m_nCurrentIndex = m_blocks.Length - 1;
		}

		// If the player presses the down arrow, change to the next
		// block in our array.
		if (Input.GetKeyUp (KeyCode.DownArrow)) {
			m_nCurrentIndex++;

			// Handle wrapping our index if we go above how many we have
			if (m_nCurrentIndex >= m_blocks.Length) {
				m_nCurrentIndex = 0;
			}
		}

		// Set our current active block to our newly updated index
		m_goCurrentActiveBlock = m_blocks [m_nCurrentIndex];

		// Apply the nudge force if the player presses the left / right arrows
		if (Input.GetKey (KeyCode.RightArrow)) {
			m_goCurrentActiveBlock.GetComponent<Rigidbody> ().AddForce (-transform.forward * m_fNudgeForce);
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			m_goCurrentActiveBlock.GetComponent<Rigidbody> ().AddForce (transform.forward * m_fNudgeForce);
		}
	}

	private int			m_nCurrentIndex;				// Keep track of our current index into our block array
	private GameObject	m_goCurrentActiveBlock;			// The actually current active block

}
