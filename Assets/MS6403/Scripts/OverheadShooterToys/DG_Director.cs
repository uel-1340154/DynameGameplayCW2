using UnityEngine;
using System.Collections;
using MonsterLove.StateMachine;

// The Director class & Object manage the overall states of the game.
// It uses the MonsterLove statemachine functionality from
//
// https://github.com/thefuntastic/Unity3d-Finite-State-Machine
//
public class DG_Director : StateBehaviour {

    // Set up our states. These will be connected to the functions later
	public enum States
	{
		PreGame,    // Before our game starts
		InGame,     // While we're playing
		PostGame,   // After the main game has finished
	}

	// Use this for initialization
	void Start () {
        // Initialise the state system
		Initialize<States> ();

        // Set ourself to our initial pregame state
		ChangeState (States.PreGame);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // PreGame_Enter function
    // Called when we enter the PreGame State
    // It has a return type of IEnumerator because it is a co-routine
	public IEnumerator PreGame_Enter()
	{
		// Disable our player
		Messenger.Broadcast ("DisablePlayerInput");

        // Broadcast our message
        Messenger.Broadcast ("PreGame_Enter");

        // Wait for 1 second
		yield return new WaitForSeconds (1.0f);

        // Broadcast out Get Ready message
		Messenger.Broadcast ("PreGame_GetReady");

        // Wait for 1.3 seconds
		yield return new WaitForSeconds (1.3f);

        // Broadcast our Go message
		Messenger.Broadcast ("PreGame_Go");
		// Enable our player
		Messenger.Broadcast ("EnablePlayerInput");

        // Wait for 0.3 seconds
		yield return new WaitForSeconds (0.3f);

        // Change into our InGame state
		ChangeState (States.InGame);
	}

    // InGame_Enter function
    // Called when we enter our InGame state
	public void InGame_Enter()
	{
        // Just broadcast our message that we're InGame
		Messenger.Broadcast("InGame_Started");
	}

    // PostGame_Enter function
    // Called when we enter our PostGame State
	public void PostGame_Enter()
	{
	}
}
