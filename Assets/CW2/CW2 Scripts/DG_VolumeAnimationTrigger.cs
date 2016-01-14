using UnityEngine;
using System.Collections;

[RequireComponent (typeof(BoxCollider))]
public class DG_VolumeAnimationTrigger : MonoBehaviour
{

	public string			m_triggerTag;
	public GameObject		m_animatingObject;
	public AnimationClip	m_animationOnEnter;
	public AnimationClip	m_animationOnExit;
    public AudioSource Audio;
    public AudioClip[] Clips;

    public Transform Parent;
    public JM_EnemySpawner mMB_SpawnScript;
    public Transform EnemySpawner;
    public Transform EnemySpawnerObject;

	// Use this for initialization
	void Start ()
    {
        Audio = GetComponent<AudioSource>();
        Parent = transform.parent;
        mMB_SpawnScript = Parent.gameObject.GetComponentInChildren<JM_EnemySpawner>();
	}

	// Trigger the animation on enter
	void OnTriggerEnter(Collider coll)
	{
		// If there's no animation set up, just bail
		if (m_animationOnEnter == null)
			return;

		// Check if we're colliding with the correct tag
		// If we are, trigger our animation
        if(mMB_SpawnScript == null)
        {
            if (coll.CompareTag(m_triggerTag) == true)
            {
                Animator anim = m_animatingObject.GetComponent<Animator>();
                anim.Play(m_animationOnEnter.name);
                Audio.PlayOneShot(Clips[0]);
            }
        }
        if(mMB_SpawnScript != null)
        {
            if (coll.CompareTag(m_triggerTag) == true && !mMB_SpawnScript.LockDoors)
            {
                Animator anim = m_animatingObject.GetComponent<Animator>();
                anim.Play(m_animationOnEnter.name);
                Audio.PlayOneShot(Clips[0]);
            }
            else if (coll.CompareTag(m_triggerTag) == true && mMB_SpawnScript.LockDoors == true)
            {
                //Do nothing
            }
        }
	}

	// Trigger the animation on exit
	void OnTriggerExit(Collider coll)
	{
		// If there's no animation set up, just bail
		if (m_animationOnExit == null)
			return;

		// Check if we're colliding with the correct tag
		// If we are, trigger our animation
        if(mMB_SpawnScript != null)
        {
            if (coll.CompareTag(m_triggerTag) == true && mMB_SpawnScript.LockDoors == false)
            {
                Animator anim = m_animatingObject.GetComponent<Animator>();
                anim.Play(m_animationOnExit.name);
                Audio.PlayOneShot(Clips[1]);
            }
            else if (coll.CompareTag(m_triggerTag) == true && mMB_SpawnScript.LockDoors == true)
            {
                Animator anim = m_animatingObject.GetComponent<Animator>();
                anim.Play(m_animationOnExit.name);
                Audio.PlayOneShot(Clips[1]);
            }
        }
        else
        {
            if (coll.CompareTag(m_triggerTag) == true)
            {
                Animator anim = m_animatingObject.GetComponent<Animator>();
                anim.Play(m_animationOnExit.name);
                Audio.PlayOneShot(Clips[1]);
            }
        }
	}

}
