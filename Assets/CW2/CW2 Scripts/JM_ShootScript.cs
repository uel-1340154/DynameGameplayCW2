using UnityEngine;
using System.Collections;

public class JM_ShootScript : MonoBehaviour
{
    public GameObject mPF_Bullet;//bullet prefab
    public GameObject mGO_Bullet;//bullet object colned in game
	
	// Update is called once per frame
	void Update ()
    {
        Shoot();
	}

    void Shoot()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            mGO_Bullet = (GameObject) Instantiate(mPF_Bullet, transform.position, transform.rotation);//instantiate bullet
            mGO_Bullet.GetComponent<Rigidbody>().velocity = transform.rotation * new Vector3(0,0,-50);//add velocity to instantiated bullet based on rotation.

        }
    }
}
