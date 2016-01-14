using UnityEngine;
using System.Collections;

public class JM_BulletCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Enemy" || col.gameObject.tag == "Untagged")
        {
            Destroy(gameObject);
        }
    }
}
