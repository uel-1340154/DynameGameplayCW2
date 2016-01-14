using UnityEngine;
using System.Collections;

public class JM_ShootScript : MonoBehaviour
{
    public GameObject mPF_Bullet;//bullet prefab
    public GameObject mGO_Bullet;//bullet object cloned in game


    private bool Parented;
	
    void Start()
    {
        CheckParent();
        mGO_Bullet = mPF_Bullet;
        BulletParticles(Parent);
    }
	// Update is called once per frame
	void Update ()
    {
        CheckParent();
        Shoot();
	}

    void CheckParent()
    {
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
            mGO_Bullet = (GameObject) Instantiate(mPF_Bullet, transform.position, transform.rotation);//instantiate bullet
            mGO_Bullet.GetComponent<Rigidbody>().velocity = transform.rotation * new Vector3(0,0,-5);//add velocity to instantiated bullet based on rotation.
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && !Parented)
        {

        }
    }

    void BulletParticles(Transform Parent)//simple script to change bullet particle colours
    {
        Color BulletColor;//variable to be used throughout this script to avoid hardcoding colour
        if (Parent.gameObject.GetComponent<JM_ItemPickUp>().TraitSlot1 == null)
        {
            BulletColor = new Color(255, 255, 255);
            mGO_Bullet.GetComponent<ParticleSystem>().startColor = BulletColor;//changes particle system colour based on (red, green, blue) values
            mGO_Bullet.GetComponent<Light>().color = BulletColor;
        }
        else if (Parent.gameObject.GetComponent<JM_ItemPickUp>().TraitSlot1 == "Burning")
        {
            BulletColor = new Color(205, 109, 36);
            mGO_Bullet.GetComponent<ParticleSystem>().startColor = BulletColor;//changes particle system colour based on (red, green, blue) values
            mGO_Bullet.GetComponent<Light>().color = BulletColor;
        }
        else if (Parent.gameObject.GetComponent<JM_ItemPickUp>().TraitSlot1 == "Shocking")
        {
            BulletColor = new Color(41, 86, 233);
            mGO_Bullet.GetComponent<ParticleSystem>().startColor = BulletColor;
            mGO_Bullet.GetComponent<Light>().color = BulletColor;
        }
        else if (Parent.gameObject.GetComponent<JM_ItemPickUp>().TraitSlot1 == "Freezing")
        {
            BulletColor = new Color(59, 215, 246);
            mGO_Bullet.GetComponent<ParticleSystem>().startColor = BulletColor;
            mGO_Bullet.GetComponent<Light>().color = BulletColor;
        }
        else if (Parent.gameObject.GetComponent<JM_ItemPickUp>().TraitSlot1 == "Posion")
        {
            BulletColor = new Color(34, 178, 62);
            mGO_Bullet.GetComponent<ParticleSystem>().startColor = BulletColor;
            mGO_Bullet.GetComponent<Light>().color = BulletColor;
        }
        //else if (Parent.gameObject.GetComponent<JM_ItemPickUp>().TraitSlot1 == "Multishot")//exception as it changes how many bullets are instantiated
        //{
            //TODO code to edit amount of shots etc.
        //}
    }

    public Transform Parent
    {
        get; set;
    }
}
