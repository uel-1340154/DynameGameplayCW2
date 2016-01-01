using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class DG_VolumeBroadcastMessage : MonoBehaviour {

	public string	m_OnEnterMessage;
	public string 	m_OnExitMessage;
	public string	m_TriggerTag;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == m_TriggerTag &&
		    m_OnEnterMessage != "")
		{
			Messenger.Broadcast (m_OnEnterMessage);
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == m_TriggerTag &&
		    m_OnExitMessage != "") {
			Messenger.Broadcast (m_OnExitMessage);
		}
	}
}
