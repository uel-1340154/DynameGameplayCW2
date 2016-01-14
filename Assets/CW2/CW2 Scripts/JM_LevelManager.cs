using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Character;

public class JM_LevelManager : MonoBehaviour
{
    public CursorLockMode CLM;

    public GameObject mGO_PC;
    public GameObject mPF_PC;
    public JM_PCScript mMB_PCScript;

    public ModularWorldGenerator mMB_LevelScript;

    public Text PerkText;
    public Button PerkButton;

    public bool loaded;

    public Color FadeIn;
    public Color FadeOut;

    public JM_PerkGeneration mMB_PerkScript;
    public GameObject mGO_PerkGen;

    // Use this for initialization
    void Awake()
    {
        mGO_PC = (GameObject)Instantiate(mPF_PC, new Vector3(7, 1, -8), transform.rotation);
        mMB_LevelScript = GameObject.Find("DungeonGenerator").GetComponent<ModularWorldGenerator>();
        mMB_PCScript = mGO_PC.GetComponent<JM_PCScript>();
        mMB_PerkScript = mGO_PerkGen.GetComponent<JM_PerkGeneration>();
        PerkButton = GameObject.FindGameObjectWithTag("PerkText").GetComponent<Button>();
        PerkText = PerkButton.GetComponentInChildren<Text>();
        FadeOut = PerkButton.colors.disabledColor;
        FadeIn = new Color(200, 200, 200, 255);
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

    public void LoadLevel()
    {
        mGO_PC = (GameObject)Instantiate(mPF_PC, new Vector3(7, 1, -8), transform.rotation);
    }

    void OnGUI()
    {
        bool picked = false;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CLM = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CLM = CursorLockMode.Confined;
        }

        if (mMB_PCScript.LevelledUp && !picked)
        {
            string Perk;
            Perk = mMB_PerkScript.PerkGeneration(mMB_PerkScript.perks);
            PerkText.text = Perk;
            picked = true;
            ColorBlock vis = PerkButton.colors;
            vis.normalColor = Color.Lerp(FadeOut, FadeIn, 2);
            if (mMB_PCScript.LevelledUp && picked)
            {
                mMB_PCScript.LevelledUp = false;
                picked = false;
            }
        }
   }
}
