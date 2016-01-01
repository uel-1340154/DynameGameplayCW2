using UnityEngine;
using System.Collections;

public class DG_TrailToy_RotateObject : MonoBehaviour {

	public float fRotationSpeed = 30.0f;		// Degrees / Second
	public Vector3	v3RotationAngle = Vector3.up;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation *= Quaternion.AngleAxis (fRotationSpeed * Time.deltaTime, v3RotationAngle);
	}
}
