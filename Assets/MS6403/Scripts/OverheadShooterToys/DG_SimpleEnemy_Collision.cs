using UnityEngine;
using System.Collections;

public class DG_SimpleEnemy_Collision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//void OnCollisionEnter(Collision collision)
	void OnTriggerEnter(Collider coll)
	{
		if (coll.gameObject.tag == "PlayerBullet") {
			gameObject.SendMessage ("HitByBullet");
		}
	}
}
