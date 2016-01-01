using UnityEngine;
using System.Collections;

public class DG_SimpleBullet_Collision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//void OnCollisionEnter(Collision coll)
	void OnTriggerEnter(Collider coll)
	{
		if (coll.gameObject.tag == "Enemy") {
			//gameObject.SendMessage ("BulletHitEnemy");
			gameObject.DestroyAPS ();
		}
	}

}
