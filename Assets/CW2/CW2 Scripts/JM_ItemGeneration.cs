using UnityEngine;
using System.Collections;

public class JM_ItemGeneration : MonoBehaviour
{
    public GameObject mGO_Item;
    public GameObject mPF_Item;
    public GameObject[] Items;//array of items to be chosen

    //public int rarity;//variable to hold rarity of an item

	// Use this for initialization
	void Start ()
    {
        mPF_Item = Generation(Items);//passes the item list into the method, creating a prefab
        mGO_Item = (GameObject)Instantiate(mPF_Item, transform.position, transform.rotation);//gameobject then instantiates prefab clone at position.
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public static GameObject Generation(GameObject[] ItemArray)
    {
        return ItemArray[Random.Range(0, ItemArray.Length)];//selects a random item from the array
    }
}
