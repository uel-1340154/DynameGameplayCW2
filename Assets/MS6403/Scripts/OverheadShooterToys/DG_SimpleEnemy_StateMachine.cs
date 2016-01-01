using UnityEngine;
using System.Collections;
using MonsterLove.StateMachine;

[RequireComponent(typeof(DG_SimpleEnemy_Audio))]
[RequireComponent(typeof(DG_SimpleEnemy_Collision))]
public class DG_SimpleEnemy_StateMachine : StateBehaviour {

	// The radius of the enemy's sensing of players
	// This will be rendered in the gizmo view
	public float		m_fPlayerSenseRadius = 10.0f;

	// How quickly I can move
	public float		m_fMovementSpeed = 3.0f;

	// My states
	public enum States
	{
		Idle,
		Pursuing,
		Dead,
	};

	// Use this for initialization
	void Start () {
		// Initialise my states
		Initialize<States>();
		ChangeState (States.Idle);
	
		// Keep track of the player
		m_player = GameObject.Find("Player");	// ASsumes there's a gameobejct called Player in the hierarchy
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Update for Idle
	void Idle_Update()
	{
		// Check the distance to the player
		float fDistanceToPlayer = Vector3.Distance (m_player.transform.position, transform.position);

		// If the player is closer than my sense radius
		if (fDistanceToPlayer < m_fPlayerSenseRadius)
		{
			// Change to pursuing
			ChangeState(States.Pursuing);

			// Send me a message that I've spotted the player
			gameObject.SendMessage("PlayerSpotted");
		}
	}

	// Update for pursuing
	void Pursuing_Update()
	{
		// Make me look at the player
		transform.LookAt (m_player.transform.position);

		// Move me towards the player
		transform.Translate (Vector3.forward * m_fMovementSpeed * Time.deltaTime);

		// Send my other systems a message that I'm moving
		gameObject.SendMessage ("PlayerMoving");
	}

	// Enter function for Dead
	IEnumerator Dead_Enter()
	{
		// check if I have a SimpleEnemy_Audio component
		DG_SimpleEnemy_Audio enemyAudio = GetComponent<DG_SimpleEnemy_Audio> ();
		if (enemyAudio == null)
			yield return null;

		// Get the dying clip
		AudioClip dyingClip = enemyAudio.m_characterBulletHit;
		if (dyingClip != null) {
			// hide me for the length of the dying clip
			GetComponent<Renderer>().enabled = false;	// hide the renderer
			GetComponent<Collider>().enabled = false;	// hide the collision

			// Wait for the length of the clip before I'm fully destroyed
			yield return new WaitForSeconds (dyingClip.length);
		}

		// Destroy me once I'm back from the yield
		GameObject.Destroy (gameObject);
	}

	// External signals
	void HitByBullet()
	{
		ChangeState (States.Dead);
	}

	// keep track of the player
	private GameObject m_player;

    // Debug Rendering functions
    void OnDrawGizmos()
    {
        // Render the objects sense radius as a wireframe sphere
        Gizmos.DrawWireSphere(transform.position, m_fPlayerSenseRadius);
    }

}
