using UnityEngine;
using System.Collections;

public class DG_ActivateChildrenOnMessage : MonoBehaviour {

	public string	m_Message;

	// Use this for initialization
	void Start () {
		// Deactivate all of my children!
		foreach (Transform child in transform) {
			child.gameObject.SetActive (false);
		}

		// Register for messages
		Messenger.AddListener (m_Message, ActivateChildren);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ActivateChildren()
	{
		foreach (Transform child in transform) {
			child.gameObject.SetActive (true);
		}
	}
}
