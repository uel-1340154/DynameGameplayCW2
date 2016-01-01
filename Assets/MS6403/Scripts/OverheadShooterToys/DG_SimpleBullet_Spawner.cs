using UnityEngine;
using System.Collections;

public class DG_SimpleBullet_Spawner : MonoBehaviour {

	// The transform to spawn new bullets at
	public Transform	m_spawnPoint;

	// The prefab we're spawning
	public GameObject	m_bulletPrefab;

	// Reload time
	public float 		m_fReloadTime;
	
	// Use this for initialization
	void Start () {
		m_fReloadTimer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
	
		// Decrement our reload timer
		if (m_fReloadTimer > 0.0f)
			m_fReloadTimer -= Time.deltaTime;

		// If fire is pressed
		if (Input.GetButton ("Fire1"))
		{	
			// Only fire if our reload timer is <= 0
			if (m_fReloadTimer <= 0.0f)
			{
				// We send the message to let multiple systems - us, audio, effects, do what they will
				gameObject.SendMessage("FireBullet");

				// Reset our reload timer
				m_fReloadTimer = m_fReloadTime;
			}
		}
	}

	// Message handler that actually fires a bullet
	void FireBullet()
	{
		PoolingSystem.Instance.InstantiateAPS (m_bulletPrefab.name, m_spawnPoint.position, m_spawnPoint.rotation);
	}

	// Reload timer
	private float 		m_fReloadTimer;

}
