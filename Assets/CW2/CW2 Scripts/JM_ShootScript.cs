using UnityEngine;
using System.Collections;

public class JM_ShootScript : MonoBehaviour
{
    public GameObject mPF_Bullet;//bullet prefab
    public GameObject mPF_FireBullet;
    public GameObject mPF_ShockBullet;
    public GameObject mPF_FreezeBullet;
    public GameObject mPF_PoisonBullet;
    public GameObject mGO_Bullet;//bullet object cloned in game

    GameObject Prefab;

    public string TraitType;

    private bool Parented;
	
    void Start()
    {
        CheckParent();
        Prefab = TraitTypeCheck();
    }
	// Update is called once per frame
	void Update ()
    {
        CheckParent();
        Shoot();
	}

    GameObject TraitTypeCheck()
    {
        GameObject newPrefab;
        TraitType = Parent.gameObject.GetComponent<JM_ItemPickUp>().TraitSlot1;
        if (TraitType == "Burning")
        {
            newPrefab = mPF_FireBullet;
        }
        else if (TraitType == "Shocking")
        {
            newPrefab = mPF_ShockBullet;
        }
        else if (TraitType == "Posion")
        {
            newPrefab = mPF_PoisonBullet;
        }
        else if (TraitType == "Freezing")
        {
            newPrefab = mPF_FreezeBullet;
        }
        else if (TraitType == "Multishot")
        {
            newPrefab = mPF_Bullet;
        }
        else
        {
            newPrefab = mPF_Bullet;
        }

        return newPrefab;
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
            mGO_Bullet = (GameObject)Instantiate(Prefab, transform.position, transform.rotation);//instantiate bullet
            mGO_Bullet.GetComponent<Rigidbody>().velocity = transform.rotation * new Vector3(0,0,-5);//add velocity to instantiated bullet based on rotation.
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && !Parented)
        {

        }
    }

    public Transform Parent
    {
        get; set;
    }
}
