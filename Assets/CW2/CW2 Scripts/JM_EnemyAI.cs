using UnityEngine;
using System.Collections;

namespace Character
{
    public class JM_EnemyAI : JM_Character
    {
        public Animator animator;

        public int ExperienceValue;
        public int Speed;

        public GameObject mGO_PC;
        public JM_PCScript mMB_PCScript;

        public AudioSource Audio;

        public RaycastHit Ray;

        // Use this for initialization
        void Awake()//used instead of a constructor as super class is derived from monobehaviour & loads quicker than start
        {
            MaxHealth = 50;
            CurrentHealth = MaxHealth;
            Debug.Log("My current health is: " + CurrentHealth + "HP!");
            ExperienceValue = 10;
            Speed = 1;
        }

        new void Start()
        {
            base.Start();//required to access levelmanager finding
            mMB_PCScript = mLM_LevelManager.mGO_PC.GetComponent<JM_PCScript>();
            animator = GetComponent<Animator>();
            Audio = GetComponent<AudioSource>();
        }

        public enum State
        {
            Aggressive = 1,
            Fearful = 2,
            Idle = 3,
        }

        IEnumerator DestroyCoroutine()
        {
            yield return new WaitForSeconds(1);//wait 2 seconds for all other processes to end
            mMB_PCScript.LevelUp(ExperienceValue);//add this enemies experience point value to current experience.
            Destroy(gameObject);//destroy self, helps with cleaning up the level of uneeded objects
        }

        // Update is called once per frame
        void Update()
        {
            Movement();
        }

        public override void OnTriggerEnter(Collider col)//paramters for method to be used in superclass.
        {
            if (col.gameObject.tag == "PlayerBullet")
            {
                TakeDamage(10);
            }
        }

        public override void TakeDamage(int Dmg)
        {
            base.TakeDamage(Dmg);
            StartCoroutine(DestroyCoroutine());//start coroutine to destroy self.
        }

        void Movement()//handles the AI movement.
        {
            if (Physics.Raycast(transform.position, transform.forward, out Ray, 10f))//has a raycast point forward
            {
                if (Ray.transform.tag == "Player")//if the player object is in the raycast
                {
                    transform.LookAt(Ray.transform.position);//rotate towards target position
                    transform.Translate((Ray.transform.position - transform.position) * Speed * Time.deltaTime);//chase them
                    if ((Ray.transform.position.x - transform.position.x) <= 0.5f)
                    {
                        animator.Play("EnemyAttackAnim");
                        Audio.Play();
                    }
                    else
                    {
                        animator.Play("EnemyStaticAnim");
                    }
                }
            }
        }
    }
}
