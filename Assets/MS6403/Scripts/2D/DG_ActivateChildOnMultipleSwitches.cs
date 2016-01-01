using UnityEngine;
using System.Collections;

public class DG_ActivateChildOnMultipleSwitches : MonoBehaviour {

	public GameObject[]	m_switches;
	// Use this for initialization
	void Start () {
		// Disable all children
		foreach (Transform child in transform) {
			child.gameObject.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject o in m_switches) {
			DG_VolumeToggleSwitch s = o.GetComponent<DG_VolumeToggleSwitch>();
			if (s != null)
			{
				if (s.GetCurrentState() == false)
					return;
			}
		}

		// If we make it through to hear, all switches are true
		foreach (Transform child in transform) {
			child.gameObject.SetActive (true);
		}
	}
}
