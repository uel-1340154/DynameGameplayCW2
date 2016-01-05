using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Character
{
    public class JM_PCScript : JM_Character
    {

        //experience and level variables
        public int CurrentExperience;
        public int ExperienceTotal;
        public int Level;

        public Slider Healthslider;
        public Slider ExperienceSlider;
        public Text LevelUpText;
        public Color FadeIn;
        public Color FadeOut;


        public bool LevelledUp;

        //stats
        public int Strength;
        public int Intelligence;
        public int Dexterity;

        public AudioSource Audio;
        public AudioClip[] Clips;

        IEnumerator TextFadeCoroutine()
        {
            yield return new WaitForSeconds(3);
            LevelUpText.color = Color.Lerp(FadeIn, FadeOut,3);//fade text out over time.

        }

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
            Healthslider = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<Slider>();
            Healthslider.maxValue = MaxHealth;
            Healthslider.value = CurrentHealth;
            ExperienceSlider = GameObject.FindGameObjectWithTag("ExperienceBar").GetComponent<Slider>();
            ExperienceSlider.maxValue = ExperienceTotal;
            LevelUpText = GameObject.FindGameObjectWithTag("LevelUpText").GetComponent<Text>();
            FadeOut = LevelUpText.color;
            FadeIn = new Color(244, 255, 51, 255);
        }

        new void Start()
        {
            Audio = GetComponent<AudioSource>();
        }

        void FixedUpdate()
        {
            LevelUp(XpGained);//checks if the PC has levelled up yet
            if(LevelledUp)
            {
                LevelUpText.color = Color.Lerp(FadeOut, FadeIn, 3);//fade in the Level Up Text
                LevelledUp = false;
                StartCoroutine(TextFadeCoroutine());
            }
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
        }

        public int XpGained
        {
            get; set;
        }
    }
}
