using UnityEngine;
using System.Collections;

// -----------------------------------------------------------------------------------
// Support class that displays a text message when a tagged gameobject enters it
// -----------------------------------------------------------------------------------
[RequireComponent(typeof(Collider))]
public class DG_VolumeTextDisplay : MonoBehaviour {

    // Public enum to manage an object's position
	public enum ePosition
	{
		Center,
		Coordinates,
	} 

    // How to align the text
	public ePosition 	m_Position = ePosition.Center;

    // Tag which the object responds to.
	public string		m_TriggerTag;

	// Where to display the text if m_Position is set to Coordinates
    public Rect			m_rectBoxDimensions = new Rect(0, 0, 200, 100);
    
    // Text to display
    [TextArea(4,10)]
	public string		m_DisplayText;

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

    // OnGui function - actually display things
	void OnGUI()
	{
        // Check if we're set to display our message
		if (bl_display_message) {

            // Calculate the position
			Rect displayRect = m_rectBoxDimensions;
			switch (m_Position)
			{
			case ePosition.Center:
				displayRect.x = Screen.width / 2 - (m_rectBoxDimensions.width/2);
				displayRect.y = Screen.height / 2 - (m_rectBoxDimensions.height/2);
				break;
			}

            // Display our text box
			GUI.Box (displayRect, m_DisplayText);
		}
    }

    // Indicate if we are currently displaying text
    private bool bl_display_message;
}
