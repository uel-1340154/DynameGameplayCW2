using UnityEngine;
using System.Collections;

// -----------------------------------------------------
// A base class for creating physics toys
// Handles enabling & disabling input.
// -----------------------------------------------------
public class DG_PhysicsToy_Base : MonoBehaviour {

	// Keep track if I'm active or not
	private bool	m_bToyInputActive;
	public bool		InputActive { get { return m_bToyInputActive; } }

	// Use this for initialization
	protected virtual void Start () {
		m_bToyInputActive = false;

		// Add some messengers whether or not I'm active or not.
		Messenger.AddListener<GameObject> ("EnablePhysicsToyInput", EnablePhysicsToyInput);
		Messenger.AddListener<GameObject> ("DisablePhysicsToyInput", DisablePhysicsToyInput);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Message handler - toggle this toy active
	void EnablePhysicsToyInput(GameObject o)
	{
		// Check if the message passed is meant for me
		// If it is, then make me active
		// Normally this comes from pressing the 'E' key on a DG_PhysicsToy_InputVolume
		if (o == this.gameObject) {
			m_bToyInputActive = true;
		}
	}

	// Message handler - toggle this toy inactive
	void DisablePhysicsToyInput(GameObject o)
	{
		// Check if the message passed is meant for me
		// If it is, then make me inactive
		// Normally this comes from pressing the 'E' key on a DG_PhysicsToy_InputVolume
		if (o == this.gameObject) {
			m_bToyInputActive = false;
		}
	}
}
