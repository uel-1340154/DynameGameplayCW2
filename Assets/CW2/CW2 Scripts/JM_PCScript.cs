using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

namespace Character
{
    public class JM_PCScript : JM_Character
    {

        //experience and level variables
        public int CurrentExperience;
        public int ExperienceTotal;
        public int Level;

        public static GameObject MasterPC;

        public Rigidbody rb;

        public Slider Healthslider;
        public Slider ExperienceSlider;
        public Text LevelUpText;

        public bool LevelledUp;

        public bool Dead;

        //stats
        public int Strength;
        public int Intelligence;
        public int Dexterity;

        public AudioSource Audio;
        public AudioClip[] Clips;

        IEnumerator TextFadeCoroutine()
        {
            yield return new WaitForSeconds(3);
            LevelUpText.CrossFadeAlpha(1, 5, false);
        }

        // Use this for initialization
        void Awake()//used instead of constructors as superclass is derived from monobehaviour & loads quicker than start
        {
            MaxHealth = 100;
            CurrentHealth = MaxHealth;
            rb = GetComponent<Rigidbody>();
            rb.useGravity = false;
            Level = 1;
            ExperienceTotal = 100;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            Healthslider = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<Slider>();
            Healthslider.maxValue = MaxHealth;
            Healthslider.value = CurrentHealth;
            ExperienceSlider = GameObject.FindGameObjectWithTag("ExperienceBar").GetComponent<Slider>();
            ExperienceSlider.maxValue = ExperienceTotal;
            LevelUpText = GameObject.FindGameObjectWithTag("LevelUpText").GetComponent<Text>();
            if(MasterPC == null)
            {
                DontDestroyOnLoad(gameObject);
                MasterPC = this.gameObject;
            }
            else if(MasterPC != this)
            {
                Destroy(gameObject);
            }
        }

        void LevelCheck()
        {
            if(!Physics.Raycast(transform.position, Vector3.down, 5f))
            {
                rb.useGravity = false;
            }
            else if (Physics.Raycast(transform.position, Vector3.down, 5f))
            {
                rb.useGravity = true;
            }
        }

        new void Start()
        {
            Audio = GetComponent<AudioSource>();
        }

        void FixedUpdate()
        {
            LevelUp(XpGained);//checks if the PC has levelled up yet
            LevelCheck();
        }

        public void LevelUp(int XpGained)
        {
            CurrentExperience += XpGained;
            ExperienceSlider.value = CurrentExperience;
            if (CurrentExperience >= ExperienceTotal)//if current xp goes above needed total
            {
                Level += 1;//increase level by one
                CurrentExperience -= ExperienceTotal;//reduce experience by total, allowing player to retain a overflow towards the next level.
                LevelledUp = true;
                LevelUpText.CrossFadeAlpha(255, 2.5f, false);
                StartCoroutine(TextFadeCoroutine());
                MaxHealth += 10;
                CurrentHealth += 10;
                Healthslider.maxValue = MaxHealth;
                Healthslider.value = CurrentHealth;
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
            Healthslider.value = CurrentHealth;
            base.TakeDamage(Dmg);
            if (CurrentHealth <= 0)
            {
                Dead = true;
                gameObject.GetComponent<RigidbodyFirstPersonController>().enabled = false;
                gameObject.GetComponentInChildren<AudioListener>().enabled = false;
            }
        }

        public int XpGained
        {
            get; set;
        }
    }
}
