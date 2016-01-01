using UnityEngine;
using System.Collections;
using DG.Tweening;

[RequireComponent (typeof(BoxCollider))]
public class DG_TweeningToy_CubeAnimation : MonoBehaviour {

	[Header("Prefabs / Spawning")]
	public int 			p_nSpawnCount = 2;
	public GameObject	p_goSpawnPrefab;

	[Header("Tweening Parameters")]
	public float		p_fTweenTime = 3.0f;
	public Ease			p_eEaseFunction = Ease.Linear;

	private BoxCollider	m_boxCollider;

	// Use this for initialization
	void Start () {
		// Grab our collider
		m_boxCollider = GetComponent<BoxCollider> ();

		// Create some prefabs
		for (int c=0; c<p_nSpawnCount; ++c) {
			GameObject newObj = GameObject.Instantiate (p_goSpawnPrefab, Vector3.zero, Quaternion.identity) as GameObject;
			newObj.transform.SetParent (transform);
			newObj.transform.position = GetRandomPositionFromBox ();
		
			ResetTweenAnimations (newObj);
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	Vector3	GetRandomPositionFromBox()
	{
		Vector3 v3Min = m_boxCollider.bounds.min;
		Vector3 v3Max = m_boxCollider.bounds.max;

		return new Vector3 (Random.Range (v3Min.x, v3Max.x), Random.Range (v3Min.y, v3Max.y), Random.Range (v3Min.z, v3Max.z)); 
	}

	void ResetTweenAnimations(GameObject obj)
	{
		obj.transform.DOMove (GetRandomPositionFromBox (), p_fTweenTime).SetEase (p_eEaseFunction).OnComplete (()=>OnTweenComplete(obj));
	}

	void OnTweenComplete(GameObject obj)
	{
		ResetTweenAnimations (obj);
	}
}
