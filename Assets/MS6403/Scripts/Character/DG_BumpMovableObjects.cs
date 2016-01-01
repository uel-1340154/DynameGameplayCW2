using UnityEngine;
using System.Collections;

public class DG_BumpMovableObjects : MonoBehaviour
{

	public float pushPower = 2.0F;

	void OnControllerColliderHit(ControllerColliderHit CC_Hit)
    {

		// Has the PC bumped into an ojbect it can push 
		if (CC_Hit.gameObject.isStatic == true)
            return;

        // Check for a rigidbody & that it isn't kinematic
		Rigidbody body = CC_Hit.collider.attachedRigidbody;
		if (body == null || body.isKinematic)
			return;
		
        // Check that we're not falling
		if (CC_Hit.moveDirection.y < -0.3F)
			return;
		
		Vector3 pushDir = new Vector3(CC_Hit.moveDirection.x, 0, CC_Hit.moveDirection.z);
		body.velocity = pushDir * pushPower;
	}
}
