using UnityEngine;
using System.Collections;
using Character;//custom namespace to handle character related stuff.

public class JM_FireTrapDamageScript : MonoBehaviour
{
    private GameObject mGO_PC;//variable to hold the player character object

    private DigitalRuby.PyroParticles.FireBaseScript mMB_FlamethrowerScript;//used to access the FireBaseScript

    private JM_PCScript mMB_PCScript;//used to access rigidbodyFPS script.

    protected JM_LevelManager mLM_LevelManager;

	// Use this for initialization
	public void Start()
    {
        mLM_LevelManager = GameObject.Find("LevelManager").GetComponent<JM_LevelManager>();
        mMB_PCScript = mLM_LevelManager.mGO_PC.GetComponent<JM_PCScript>();//access the first person controller
        mMB_FlamethrowerScript = GameObject.FindGameObjectWithTag("Fire").GetComponent<DigitalRuby.PyroParticles.FireBaseScript>();//access the firebase script
	}

    void OnTriggerStay(Collider col)
    {
        if(mMB_FlamethrowerScript.Starting)
        {
            if (col.gameObject.tag == "Player")
            {
                mMB_PCScript.TakeDamage(10);//reduce health by 10
            }
            if(col.gameObject.tag == "Enemy")
            {
                //code to reduce enemy health
            }
        }
    }
}
