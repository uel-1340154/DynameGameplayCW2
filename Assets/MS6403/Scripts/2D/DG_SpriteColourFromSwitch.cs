using UnityEngine;
using System.Collections;

public class DG_SpriteColourFromSwitch : MonoBehaviour {

	public GameObject	m_attachedSwitch;
	public Color		m_ActiveColor;
	public Color		m_InactiveColor;

	private SpriteRenderer				m_spriteRenderer;
	private DG_VolumeToggleSwitch		m_switch;

	// Use this for initialization
	void Start () {
		m_spriteRenderer = GetComponent<SpriteRenderer> ();
		m_switch = m_attachedSwitch.GetComponent<DG_VolumeToggleSwitch> ();	
	}
	
	// Update is called once per frame
	void Update () {
		if (m_switch.GetCurrentState () == true) {
			m_spriteRenderer.color = m_ActiveColor;
		} else {
			m_spriteRenderer.color = m_InactiveColor;
		}
	}
}
