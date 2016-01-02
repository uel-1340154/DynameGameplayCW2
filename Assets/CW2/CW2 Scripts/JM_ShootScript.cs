using UnityEngine;
using System.Collections;

public class JM_ShootScript : MonoBehaviour
{
    public GameObject mPF_Bullet;//bullet prefab
    public GameObject mGO_Bullet;//bullet object colned in game

    private bool Parented;
	
	// Update is called once per frame
	void Update ()
    {
        CheckParent();
        Shoot();
	}

    void CheckParent()
    {
        Transform Parent;
        Transform Grandparent;

        Parent = gameObject.transform.parent;
        Grandparent = Parent.transform.parent;

        if (Grandparent == null)
        {
            Parented = false;
        }
        else if (Grandparent != null)
        {
            Parented = true;
        }
    }

    void Shoot()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && Parented)
        {
            mGO_Bullet = (GameObject) Instantiate(mPF_Bullet, -1 * transform.position, transform.rotation);//instantiate bullet
            //mGO_Bullet.GetComponent<Rigidbody>().velocity = transform.rotation * new Vector3(5,0,0);//add velocity to instantiated bullet based on rotation.

        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && !Parented)
        {

        }
    }
}
