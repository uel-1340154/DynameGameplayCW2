using UnityEngine;
using System.Collections;

// A simple script that simply follows the attached transform in 2D, retaining it's y position (height)
// Attach a camera as a child of this with a transform offset to get the overhead following camera functionality
//
public class DG_OverheadFollowCamera : MonoBehaviour {

    // Transform to follow
	public Transform		m_followTarget;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		// Create a new position from our target & current y position
        Vector3 v3NewPosition = new Vector3(m_followTarget.position.x, transform.position.y, m_followTarget.position.z);

        // Reposition me
		transform.position = v3NewPosition;
	}
}
