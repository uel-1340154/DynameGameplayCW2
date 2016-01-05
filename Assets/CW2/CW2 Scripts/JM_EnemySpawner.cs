using UnityEngine;
using System.Collections;

public class JM_EnemySpawner : MonoBehaviour
{
    public GameObject mPF_Enemy;
    public GameObject mGO_Enemy;

    public int mIN_Enemylimit;

    public bool Spawned;

    public GameObject mGO_RoomPropertyGenerator;
    public JM_RoomPropertyGeneration mMB_RoomPropertyScript;

    IEnumerator WaitCoRoutine()
    {
        yield return new WaitForSeconds(1);
    }

    void Awake()
    {
        mIN_Enemylimit = 8;
        mMB_RoomPropertyScript = mGO_RoomPropertyGenerator.GetComponent<JM_RoomPropertyGeneration>();
        Spawned = false;
    }

	// Use this for initialization
	void Start ()
    {
        CheckForHorde();
	}

    void CheckForHorde()
    {
        if(mMB_RoomPropertyScript.RoomProperty == "Horde")
        {
            mIN_Enemylimit = 16;
        }
        else
        {
            mIN_Enemylimit = 8;
        }
    }

    void OnTriggerEnter (Collider col)
    {
        if(col.gameObject.tag == "Player")//if player is in room
        {
            if(!Spawned)//if enemies for this lcoation have not yet been spawned
            {
                SpawnEnemies();//spawn enemies
            }
            else
            {
                //Do nothing
            }
        }
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < mIN_Enemylimit; i++)//whilst i is lower than the enemy limit
        {
            mGO_Enemy = (GameObject)Instantiate(mPF_Enemy, transform.position + new Vector3((Random.Range(-5, 5)), 0.5f, (Random.Range(-4, 5))), transform.rotation);//instantiate enemy prefabs in a random range x and zco-ordinate range.
            StartCoroutine(WaitCoRoutine());//delay between enemy spawns to prevent player being overwhelmed and manage loading in game.
        }
        Spawned = true;
    }
}
