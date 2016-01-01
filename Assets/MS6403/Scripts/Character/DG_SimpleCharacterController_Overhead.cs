using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class DG_SimpleCharacterController_Overhead : MonoBehaviour {

	// Variables 	==================================================================================
	// Movement
	private CharacterController cc_PC;
	public float fl_speed = 6.0f; 
	public float fl_runModifier = 2.0f;
	public float fl_turn_rate = 90.0f; 
	public float fl_jump_force = 10.0f;
	public float fl_gravity = 20.0f;
	private Vector3 v3_direction; 

	private bool	b_input_active = true;

	// Use this for initialization
	void Start () {
		cc_PC = GetComponent<CharacterController>();
		
		// Set initial values and game states 
		v3_direction = Vector3.zero;

		Messenger.AddListener ("EnablePlayerInput", EnablePlayerInput);
		Messenger.AddListener ("DisablePlayerInput", DisablePlayerInput);
	}
	
	// Update is called once per frame
	void Update () {
		HandleMovement ();
	}

	void HandleMovement()
	{
		if (b_input_active == false)
			return;

		float fRunScalar = 1.0f;
		// If the run key pressed double the speed
		if (Input.GetKey (KeyCode.LeftShift))
			fRunScalar = fl_runModifier;
		
		// Is the PC on some ground
		if ( cc_PC.isGrounded ) 
		{
			// Rotate the PC based on Horizontal input (A,D or Cursor L,R)
			//transform.Rotate( 0, ( fl_turn_rate * Input.GetAxis("Horizontal") * Time.deltaTime), 0 );

			// point the PC at the mouse cursor
			Vector3 v3PlayerScreenPoint = Camera.main.WorldToScreenPoint (transform.position);
			Vector3 v3MousePos = Camera.main.ScreenToWorldPoint (new Vector3(Input.mousePosition.x, Input.mousePosition.y, v3PlayerScreenPoint.z));
			transform.LookAt(v3MousePos, Vector3.up);

			// Add Z movement to the direction vector based on Vertical input (W,S or Cursor U,D) 
			v3_direction = new Vector3( Input.GetAxis ("Horizontal"), 0.0f, Input.GetAxis("Vertical") );
			
			// Convert world coordinates to local for the PC
			v3_direction = fl_speed * fRunScalar * transform.TransformDirection(v3_direction);
			
			// if the jump key is pressed add jump force to the direction vector
			if ( Input.GetButton("Jump") ) v3_direction.y = fl_jump_force;
		}
		else
		{ // when the PC is in the air
			
			// Add fl_gravity to the direction vector
			v3_direction.y -= fl_gravity * Time.deltaTime;
		}	
		
		// Move the character controller with the direction vector
		cc_PC.Move( v3_direction * Time.deltaTime );
	}

	void EnablePlayerInput()
	{
		b_input_active = true;
	}

	void DisablePlayerInput()
	{
		b_input_active = false;
	}

}
