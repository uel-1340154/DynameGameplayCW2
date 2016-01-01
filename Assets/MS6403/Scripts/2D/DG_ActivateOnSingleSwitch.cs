using UnityEngine;
using System.Collections;

[RequireComponent(typeof(DG_VolumeToggleSwitch))]
public class DG_ActivateOnSingleSwitch : MonoBehaviour {

	public GameObject			m_goTarget;
	public bool					m_bInvertSwitchState = false;

	private DG_VolumeToggleSwitch	m_coSwitch;

	// Use this for initialization
	void Start () {
		m_coSwitch = GetComponent<DG_VolumeToggleSwitch> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (m_bInvertSwitchState != true) {
			m_goTarget.SetActive (m_coSwitch.GetCurrentState ());
		} else {
			m_goTarget.SetActive (!m_coSwitch.GetCurrentState ());
		}
	}
}
