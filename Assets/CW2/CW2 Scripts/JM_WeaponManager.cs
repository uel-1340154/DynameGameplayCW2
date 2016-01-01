using UnityEngine;
using System.Collections;

public class JM_WeaponManager : MonoBehaviour
{
    public GameObject CurrentWeapon;
    public GameObject NewWeapon;
    public GameObject OldWeapon;
    public GameObject CurrentWeaponPrefab;

    public Transform PlayerChild;

    public bool Equipped;

    public JM_ItemGeneration mMB_ItemGenScript;
    public GameObject ItemGen;
	
	// Update is called once per frame
	void Update ()
    {
        EquipCheck();
	}

    void EquipCheck()
    {
        if(NewWeapon)
        {
            if (!Equipped)
            {
                if (CurrentWeapon == null)
                {
                    CurrentWeapon = NewWeapon;
                    Destroy(CurrentWeapon.GetComponent<BoxCollider>());
                    NewWeapon = null;
                    Equipped = true;
                }
            }
            else if (Equipped)
            {
                if (CurrentWeapon != null)
                {
                    OldWeapon = CurrentWeapon;
                    CurrentWeapon = null;
                    CurrentWeapon = NewWeapon;
                    Destroy(CurrentWeapon.GetComponent<BoxCollider>());
                    NewWeapon = null;
                    OldWeapon.SetActive(false);
                }
            }
        }           
    }
}

