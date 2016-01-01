using UnityEngine;
using System.Collections;

public class DG_PhysicsToy_ObjectToggle : DG_PhysicsToy_Base
{
    public GameObject p_goToggleObject;

	// Use this for initialization
	void Start () {
        base.Start();
        m_bObjectActive = true;
	}
	
	// Update is called once per frame
	void Update () {
        // check if we're active
      //  if (InputActive == false)
        //    return;

        // Test for the player pressing 'E'
        if (Input.GetKeyUp(KeyCode.E))
        {
            // Toggle the object's active state
            m_bObjectActive = !m_bObjectActive; 
            p_goToggleObject.SetActive(m_bObjectActive);
        }
	}

    private bool m_bObjectActive;
}
