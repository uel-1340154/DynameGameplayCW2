using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class JM_ItemPickUp : JM_ItemPropertyGeneration
{
    public Transform PlayerChild;

    public GameObject mPF_ShootObject;
    public GameObject mGO_ShootObject;

    public Text PickUpText;

    public Vector3 Offset;//offset value for shootobject position depending on weapon tag.

    public JM_LevelManager mLM_LevelManager;

    public JM_WeaponManager mMB_WMScript;

    public ParticleSystem[] itemParticles;

    IEnumerator TextFadeCoroutine()
    {
        yield return new WaitForSeconds(3);
        PickUpText.CrossFadeAlpha(1, 5, false);
    }

    // Use this for initialization
    public void Start()
    {
        StatRolls = 0;          //Initialise variables to be used by child class.
        StatMinimum = 0;
        StatMaximum = 0;
        ChanceofTraits = 0;
        MinimumTraitRolls = 0;
        MaximumTraitRolls = 0;
        ChosenStat = new string[] { "Health", "Strength", "Dexterity", "Intelligence" };
        TraitSlot1 = " ";
        TraitSlot2 = " ";
        TraitSlot3 = " ";
        TraitSlot4 = " ";
        PickUpText = GameObject.Find("ItemPickUpText").GetComponent<Text>();
        mLM_LevelManager = GameObject.Find("LevelManager").GetComponent<JM_LevelManager>();
        mMB_WMScript = GameObject.Find("WeaponSlot").GetComponent<JM_WeaponManager>();
        itemParticles = new ParticleSystem[2];
        itemParticles = GetComponentsInChildren<ParticleSystem>();
        CheckWeaponType();
        mGO_ShootObject = (GameObject)Instantiate(mPF_ShootObject, transform.position + Offset, transform.rotation);//set gameobject to instantiated prefab
        mGO_ShootObject.transform.parent = this.transform;//child prefab to object this script is attatched to.
        ItemStatGeneration(RarityRoll());
    }

    public override void ItemStatGeneration(int Rarity)
    {
        base.ItemStatGeneration(Rarity);
    }

    void CheckWeaponType()//check the type of weapon to determine the appropraite offset
    {
        if (gameObject.tag == "Wand")//if the weapon is a wand
        {
            Offset = new Vector3(0.074f,0.33f,0.075f);//set shoot object  the offset to a certain co-ordinate
        }
        if (gameObject.tag == "Orb")//if it's an orb
        {
            Offset = new Vector3(0.5f,0,0);//set the offset to a certain varaible
        }
    }

    int RarityRoll()
    {
        int Rarity;

        Rarity = Random.Range(0, 950);
        if(Rarity >= 0 && Rarity <= 350)
        {
            itemParticles[0].startColor = new Color(192, 192, 192);//grey
            //code to change associated particle effect colours
        }
        else if(Rarity >= 351 && Rarity <= 600)
        {
            itemParticles[0].startColor = new Color(0, 204, 0);//green
            //code to change associated particle effect colours
        }
        else if(Rarity >= 601 && Rarity <= 750)
        {
            itemParticles[0].startColor = new Color(0, 0, 255);//blue
            //code to change associated particle effect colours
        }
        else if(Rarity >= 751 && Rarity <= 800)
        {
            itemParticles[0].startColor = new Color(102, 0, 204);//purple
            //code to change associated particle effect colours
        }
        else if(Rarity >= 801 && Rarity <= 850)
        {
            itemParticles[0].startColor = new Color(255, 255, 125);//light yellow
            //code to change aprticle effect
        }
        else if(Rarity >= 851 && Rarity <= 875)
        {
            itemParticles[0].startColor = new Color(255, 100, 100);//red
            //code to change particle effect
        }
        else if(Rarity >= 876 && Rarity <= 950)
        {
            itemParticles[0].startColor = new Color(32, 32, 32);//black
            //codeto change particle effect, mimic an existing one but slightly more devious
        }
        return Rarity;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            PlayerChild = col.gameObject.transform.GetChild(0);//get player child
            transform.parent = PlayerChild.transform.GetChild(0);//get player grandchildand make that the parent
            transform.position = transform.parent.position; //+ new Vector3(0.2f, 0, 0.1f);//position object at parents. seems vector mathematics and velocity don't mix at all.
            transform.rotation = transform.parent.rotation;
            PickUpText.text = "You have just acquired a " + gameObject.tag + " of " + TraitSlot1;//changes the text depending on the weapon picked up and if traited or not
            PickUpText.CrossFadeAlpha(255, 2.5f, false);//fades in the pick up text
            StartCoroutine(TextFadeCoroutine());//corroutine ot fade out text.
            mMB_WMScript.NewWeapon = this.gameObject;//tell the weapon script this is the new eapon
        }
    }   
}
