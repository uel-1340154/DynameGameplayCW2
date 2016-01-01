using UnityEngine;
using System.Collections;

public class DG_SphereMaterialControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		mNoiseOffset = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		mNoiseOffset += Time.fixedDeltaTime;

		GetComponent<Renderer>().material.SetFloat ("fAnimationTime", mNoiseOffset);
		GetComponent<Renderer>().material.SetFloat ("fVertNoiseOffset", mVertexOffsetScalar);
		GetComponent<Renderer>().material.SetFloat ("fVertNoiseScalar", mVertexNoiseScalar);
		GetComponent<Renderer>().material.SetFloat ("fPixelNoiseOffset", mPixelOffsetScalar );
		GetComponent<Renderer>().material.SetFloat ("fPixelNoiseScalar", mPixelNoiseScalar);
	}

	public float mVertexOffsetScalar = 0.3f;
	public float mVertexNoiseScalar = 1.0f;
	public float mPixelOffsetScalar = 0.3f;
	public float mPixelNoiseScalar = 1.0f;

	private float mNoiseOffset;
}
