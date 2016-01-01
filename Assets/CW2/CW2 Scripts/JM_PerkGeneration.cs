using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Character;

public class JM_PerkGeneration : MonoBehaviour
{
    public string[] perks;

    protected JM_LevelManager mLM_LevelManager;

    public JM_PCScript mMB_PCScript;
    public GameObject mGO_PC;
    public bool picked;
	// Use this for initialization
	public void Start ()
    {
        mLM_LevelManager = GameObject.Find("LevelManager").GetComponent<JM_LevelManager>();
        mMB_PCScript = mLM_LevelManager.mGO_PC.GetComponent<JM_PCScript>();
        perks = new string[] { "Tough Hide", "Fingers of Fury", "Chilling Touch", "Rage against the meme", "Sanic" };
    }

    public string PerkGeneration(string[] PerkArray)
    {
        string Choice = PerkArray[Random.Range(0, PerkArray.Length)];
        return Choice;
    }
}
