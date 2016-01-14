using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class JM_SpikeTrapTrigger : MonoBehaviour
{

    public string m_triggerTag;
    public GameObject m_animatingObject;
    public AnimationClip m_animationOnEnter;
    public AnimationClip m_animationOnExit;
    public AudioSource Audio;
    public AudioClip Clip;

    // Use this for initialization
    void Start()
    {
        Audio = transform.parent.GetComponent<AudioSource>();
    }

    // Trigger the animation on enter
    void OnTriggerEnter(Collider coll)
    {
        // If there's no animation set up, just bail
        if (m_animationOnEnter == null)
            return;

        // Check if we're colliding with the correct tag
        // If we are, trigger our animation
        if (coll.CompareTag(m_triggerTag) == true)
        {
            Animator anim = m_animatingObject.GetComponent<Animator>();
            anim.Play(m_animationOnEnter.name);
            Audio.PlayOneShot(Clip);
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
        if (coll.CompareTag(m_triggerTag) == true)
        {
            Animator anim = m_animatingObject.GetComponent<Animator>();
            anim.Play(m_animationOnExit.name);
        }
    }

}

