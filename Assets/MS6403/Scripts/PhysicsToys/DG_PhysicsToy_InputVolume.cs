using UnityEngine;
using System.Collections;

// -----------------------------------------------------
// A class for toggling input for our physics toys
// Uses a box collider volume set to Is Trigger
// Waits for the 'E' key and sends the respective messages
// -----------------------------------------------------

[RequireComponent(typeof(BoxCollider))]
public class DG_PhysicsToy_InputVolume : MonoBehaviour {

	// The owner of this object
	public GameObject 		m_goOwner;

	// Use this for initialization
	void Start () {
		// Players don't start inside the volume
		m_bPlayerInside = false;		

		// Grab the PhysicsToy_Base component from our owner.
		m_coToyBase = m_goOwner.GetComponent<DG_PhysicsToy_Base> ();	
	}
	
	// Update is called once per frame
	void Update () {
		// If the player is inside the volume
		// check if the player has pressed the 'E' key.
		// If they have, toggle the active state of our owner physics toy by
		// Sending out the relevant messages
		if (m_bPlayerInside) {
			if (Input.GetKeyUp(KeyCode.E))
			{
				if (m_coToyBase.InputActive)
				{
					Messenger.Broadcast ("DisablePhysicsToyInput", m_goOwner);
					Messenger.Broadcast ("EnablePlayerInput");
				}
				else
				{
					Messenger.Broadcast ("EnablePhysicsToyInput", m_goOwner);
					Messenger.Broadcast ("DisablePlayerInput");
				}
			}
		}

	}

	// OnTriggerEnter. Keep track of the player being inside
	void OnTriggerEnter(Collider coll)
	{
		m_bPlayerInside = true;
	}

	// OnTriggerExit. Keep track if the player leaves
	void OnTriggerExit(Collider coll)
	{
		m_bPlayerInside = false;
	}

	private DG_PhysicsToy_Base		m_coToyBase;			// Our component taken from our owner
	private bool					m_bPlayerInside;		// Keep track of whether the player is currently inside or outside

}
