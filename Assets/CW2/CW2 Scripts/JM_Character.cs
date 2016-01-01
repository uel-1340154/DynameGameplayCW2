using UnityEngine;
using System.Collections;

namespace Character//namespace to better co-ordinate all classes relating to character actions & statistics
{
    public abstract class JM_Character : MonoBehaviour
    {
        //Superclass for all characters, both NPC and PC
        //This will not handle prefabs, only statistics and methods shared by the same class.

        protected JM_LevelManager mLM_LevelManager;

        public void Awake(int MH, int CH)//constructing in awake as it starts before any object and derives from monobehaviour, which makes constructors go do-lally
        {
            MaxHealth = MH;//assigns the Maximum health
            CurrentHealth = CH;//Current Health is assigned the same number.
        }

        public void Start()
        {
            mLM_LevelManager = GameObject.Find("LevelManager").GetComponent<JM_LevelManager>();
        }

        public virtual void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.tag == "")
            {
                TakeDamage(Dmg);
            }
        }

        public virtual void TakeDamage(int Dmg)//made public and virtual for child classes to access.
        {
            CurrentHealth -= Dmg;
            if (CurrentHealth <= 0)
            {
                Debug.Log("I am Dead");
            }
        }

        //GETTERS AND SETTERS
        //All for the sake of data encapsulation for proper OOP

        public int Dmg
        {
            get; set;
        }
        public int CurrentHealth
        {
            get; set;
        }
        public int MaxHealth
        {
            get; set;
        }

    }
}
