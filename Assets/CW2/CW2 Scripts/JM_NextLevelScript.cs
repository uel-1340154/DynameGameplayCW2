using UnityEngine;
using System.Collections;

namespace Character
{
    public class JM_NextLevelScript : MonoBehaviour
    {
        protected JM_LevelManager mLM_LevelManager;

        void Awake()
        {
            mLM_LevelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<JM_LevelManager>();

        }
        void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.tag == "Player")//if player enters trigger
            {
                PlayerPrefs.SetInt("Level", col.gameObject.GetComponent<JM_PCScript>().Level);//set the level to player pref
                PlayerPrefs.SetInt("CurrentHealth", col.gameObject.GetComponent<JM_PCScript>().CurrentHealth);//set current health to palyer pref
                PlayerPrefs.SetInt("MaxHealth", col.gameObject.GetComponent<JM_PCScript>().MaxHealth);//set max health to player pref
                col.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);//reduce previous velocity to zero
                col.gameObject.transform.position = new Vector3(8, 1, -8);//set position to initial spawn.
                Application.LoadLevel(1);//load current scene again, as procedurally generated, laods a new layout
                //mLM_LevelManager.level += 1;
            }
        }
    }
}
