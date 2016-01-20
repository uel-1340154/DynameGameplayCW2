using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Character
{
    public class JM_EnemyAI : JM_Character
    {
        public Animator animator;

        public int ExperienceValue;
        public float Speed;

        public GameObject mGO_PC;
        public JM_PCScript mMB_PCScript;

        public JM_EnemySpawner mMB_SpawnScript;

        public AudioSource Audio;

        public float viewRadius;
        public float viewAngle;

        public LayerMask Player;
        public LayerMask Obstacle;
        public LayerMask Enemy;

        State States;

        public List<Transform> visibleTargets = new List<Transform>();

        // Use this for initialization
        void Awake()//used instead of a constructor as super class is derived from monobehaviour & loads quicker than start
        {
            MaxHealth = 50;
            CurrentHealth = MaxHealth;
            ExperienceValue = 10;
            Speed = 0.4f;
            viewRadius = 15;
            viewAngle = 60;
        }

        new void Start()
        {
            base.Start();//required to access levelmanager finding
            mMB_PCScript = mLM_LevelManager.mGO_PC.GetComponent<JM_PCScript>();
            mMB_SpawnScript = transform.parent.GetComponent<JM_EnemySpawner>();
            animator = GetComponent<Animator>();
            Audio = GetComponent<AudioSource>();
        }

        public enum State
        {
            Aggressive,
            Fearful,
            Idle
        }

        IEnumerator DestroyCoroutine()
        {
            yield return new WaitForSeconds(1);//wait 2 seconds for all other processes to end
            mMB_PCScript.LevelUp(ExperienceValue);//add this enemies experience point value to current experience.
            mMB_SpawnScript.EnemiesAlive.Remove(gameObject);//if killed, remove self from list
            Destroy(gameObject);//destroy self, helps with cleaning up the level of uneeded objects
        }

        // Update is called once per frame
        void Update()
        {
            Movement();
            ClumpAvoidance();
            HealthCheck();
            SimpleStateMachine();
        }

        void HealthCheck()
        {
            if(CurrentHealth <= 0)
            {
                StartCoroutine(DestroyCoroutine());//start coroutine to destroy self.
            }
        }

        public override void OnTriggerEnter(Collider col)//paramters for method to be used in superclass.
        {
            if (col.gameObject.tag == "PlayerBullet")
            {
                TakeDamage(5);
            }
        }

        public override void TakeDamage(int Dmg)
        {
            base.TakeDamage(Dmg);
        }

        void Movement()//handles the AI movement.
        {
            Collider[] TargetinViewRadius = Physics.OverlapSphere(transform.position, viewRadius, Player);
            States = SimpleStateMachine();
            for (int i = 0; i < TargetinViewRadius.Length; i++)
            {
                Transform target = TargetinViewRadius[i].transform;
                Vector3 dirToTarget = (target.position - transform.position).normalized;
                if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
                {
                    float dstToTarget = Vector3.Distance(transform.position, target.position);
                    if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, Obstacle))
                    {
                        visibleTargets.Add(target);
                        transform.LookAt(target.position);//rotate towards target position
                        if (States == State.Aggressive)
                        {
                            transform.Translate((target.position - transform.position) * Speed * Time.deltaTime);//chase them
                            if ((target.position.x - transform.position.x) <= 0.8f)
                            {
                                animator.Play("EnemyAttackAnim");
                                Audio.Play();
                            }
                        }
                        else if (States == State.Fearful)
                        {
                            transform.Translate(((target.position + transform.position)/3) * Speed * Time.deltaTime);//Run away
                        }
                        else
                        {
                            animator.Play("EnemyStaticAnim");
                        }
                    }
                    else
                    {
                        transform.Rotate(target.position);
                    }
                }
            }
        }

        public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
        {
            if(!angleIsGlobal)
            {
                angleInDegrees += transform.eulerAngles.y;
            }
            return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
        }

        void ClumpAvoidance()
        {
            Transform Target;
            Collider[] Enemies = Physics.OverlapSphere(transform.position, 2f, Enemy);
            for (int i = 0; i < Enemies.Length; i++)
            {
                Target = Enemies[i].transform;
            }
            foreach(var enemy in Enemies)
            {
                if((enemy.transform.position.x - transform.position.x) < 0.3f)
                {
                    transform.Translate(-(enemy.transform.position - transform.position) * Speed * Time.deltaTime);
                }
            }
        }

        State SimpleStateMachine()
        {
            State st;
            if(CurrentHealth > (Mathf.Round((MaxHealth/100) * 33)) && CurrentHealth <= MaxHealth)
            {
                st = State.Aggressive;
            }
            else if(CurrentHealth < (Mathf.Round((MaxHealth / 100) * 33)))
            {
                st = State.Fearful;
            }
            else
            {
                st = State.Idle;
            }
            return st;
        }
    }

}
