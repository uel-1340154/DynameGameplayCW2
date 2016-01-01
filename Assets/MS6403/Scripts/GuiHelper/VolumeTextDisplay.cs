using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class VolumeTextDisplay : MonoBehaviour {

	public enum ePosition
	{
		Center,
		Coordinates,
	} 

	public ePosition 	m_Position = ePosition.Center;

	public string		m_TriggerTag;
	public Rect			m_rectBoxDimensions = new Rect(0, 0, 200, 100);
	[TextArea(4,10)]
	public string		m_DisplayText;

 	private bool 		bl_display_message;


	// Use this for initialization
	void Start () {
		bl_display_message = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider coll)
	{
		if (coll.tag == m_TriggerTag) {
			bl_display_message = true;
		}
	}

	void OnTriggerExit(Collider coll)
	{
		if (coll.tag == m_TriggerTag) {
			bl_display_message = false;
		}
	}

	void OnGUI()
	{
		if (bl_display_message) {

			Rect displayRect = m_rectBoxDimensions;
			switch (m_Position)
			{
			case ePosition.Center:
				displayRect.x = Screen.width / 2 - (m_rectBoxDimensions.width/2);
				displayRect.y = Screen.height / 2 - (m_rectBoxDimensions.height/2);
				break;
			}

			GUI.Box (displayRect, m_DisplayText);
		}
	}
}
