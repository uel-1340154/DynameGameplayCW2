using UnityEngine;
using System.Collections;
using Character;

public class JM_LevelManager : MonoBehaviour
{
    public CursorLockMode CLM;

    public GameObject mGO_PC;
    public GameObject mPF_PC;
    public JM_PCScript mMB_PCScript;

    public JM_PerkGeneration mMB_PerkScript;
    public GameObject mGO_PerkGen;

    // Use this for initialization
    void Awake()
    {
        LoadLevel();
        mMB_PCScript = mGO_PC.GetComponent<JM_PCScript>();
        //mMB_PerkScript = mGO_PerkGen.GetComponent<JM_PerkGeneration>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CursorState();
    }

    void CursorState()
    {
         CLM = Cursor.lockState;
        //Hide cursor when locking
        Cursor.visible = (CursorLockMode.Confined != CLM);
    }

    void LoadLevel()
    {
        mGO_PC = (GameObject)Instantiate(mPF_PC, new Vector3(7,1,-8), transform.rotation);
    }

    void OnGUI()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CLM = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CLM = CursorLockMode.Confined;
        }

        GUI.Box(new Rect(50, 50, 150, 200), "Health: \n\n" + mMB_PCScript.CurrentHealth + "/" + mMB_PCScript.MaxHealth + "\n\n" + "Experience: \n\n" + mMB_PCScript.CurrentExperience + "/" + mMB_PCScript.ExperienceTotal + "\n\n Level: \n\n" + mMB_PCScript.Level);//simple interface elementfor player to track experience.
        //if(mMB_PCScript.LevelledUp)
        //{
            //string Perk;
            //Perk = mMB_PerkScript.PerkGeneration(mMB_PerkScript.perks);
            //if (GUI.Button((new Rect(200, 200, 100, 60)), Perk))
            //{
                //mMB_PCScript.LevelledUp = false;
                //mMB_PerkScript.picked = false;
            //}
        //}
    }
}
