using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class DG_VolumeObjectToggle : MonoBehaviour {

	public GameObject 	m_goTriggerObject;
	public GameObject 	m_goToggleObject;
	public bool 		m_bInitialState;

	// Use this for initialization
	void Start () {
		m_goToggleObject.SetActive (m_bInitialState);
	}

	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject == m_goTriggerObject)
		{
			m_goToggleObject.SetActive (!m_bInitialState);
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject == m_goTriggerObject)
		{
			m_goToggleObject.SetActive (m_bInitialState);
		}
	}


}
