using UnityEngine;
using System.Collections;

namespace Character
{
    public class JM_PCScript : JM_Character
    {

        //experience and level variables
        public int CurrentExperience;
        public int ExperienceTotal;
        public int Level;

        public bool LevelledUp;

        //stats
        public int Strength;
        public int Intelligence;
        public int Dexterity;

        public AudioSource Audio;
        public AudioClip[] Clips;

        // Use this for initialization
        void Awake()//used instead of constructors as superclass is derived from monobehaviour & loads quicker than start
        {
            MaxHealth = 100;
            CurrentHealth = MaxHealth;
            Level = 1;
            ExperienceTotal = 100;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
        }

        new void Start()
        {
            Audio = GetComponent<AudioSource>();
        }

        void Update()
        {
            LevelUp(XpGained);//checks if the PC has levelled up yet
        }

        public void LevelUp(int XpGained)
        {
            CurrentExperience += XpGained;
            if (CurrentExperience >= ExperienceTotal)//if current xp goes above needed total
            {
                Level += 1;//increase level by one
                CurrentExperience -= ExperienceTotal;//reduce experience by total, allowing player to retain a overflow towards the next level.
                LevelledUp = true;
            }
        }

        public override void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.tag == "Sword")
            {
                TakeDamage(5);
                Audio.PlayOneShot(Clips[0]);
            }
        }

        public override void TakeDamage(int Dmg)
        {
            base.TakeDamage(Dmg);
        }

        public int XpGained
        {
            get; set;
        }
    }
}
