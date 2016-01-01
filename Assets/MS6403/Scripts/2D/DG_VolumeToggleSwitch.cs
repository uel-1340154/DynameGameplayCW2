using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class DG_VolumeToggleSwitch : MonoBehaviour {

	public string	m_TriggerTag;

	public bool	m_bInitialState = false;

	// Use this for initialization
	void Start () {
		m_bSwitchState = m_bInitialState;
		m_bTrippedFrame = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		const int c_nFrameDelay = 2;

		if (other.gameObject.tag == m_TriggerTag &&
		    Time.frameCount - m_bTrippedFrame  > c_nFrameDelay)
		{
			//m_goToggleObject.SetActive (!m_bInitialState);
			m_bSwitchState = !m_bSwitchState;

			m_bTrippedFrame = Time.frameCount;
		}
	}

	public bool GetCurrentState()
	{
		return m_bSwitchState;
	}

	private bool	m_bSwitchState;
	private int		m_bTrippedFrame;

}
