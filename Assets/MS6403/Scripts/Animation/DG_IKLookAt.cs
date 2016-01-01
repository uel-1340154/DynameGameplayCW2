using UnityEngine;
using System.Collections;

public class DG_IKLookAt : MonoBehaviour {
	
		public Transform viewTarget;
		Animator anim;
		
		void Awake()
		{
			anim = GetComponent<Animator>();
		}
		
		void OnAnimatorIK(int layerIndex)
		{
			if (viewTarget)
			{
				anim.SetLookAtPosition(viewTarget.position);        
				
				anim.SetLookAtWeight(1.0f);
			}
		}
}
