using UnityEngine;


public class ModuleConnector : MonoBehaviour
{
	public string[] Tags;
    public string[] LeftSideTags;
    public string[] RightSideTags;
    public string[] AboveTags;
    public string[] BelowTags;
	public bool IsDefault;

    [SerializeField]
    States st;

    RaycastHit hit;

    public enum States
    {
        Blockedfront,
        Blockedleft,
        Blockedright,
        Blockedabove,
        Blockedbelow
    }

    void Awake()
    {
        transform.parent.gameObject.layer = 2;//set parent to ignore raycasts
        gameObject.layer = 2;//set gameobject to ignore raycasts.
    }
    void Start()
    {
        Debug.Log("The parents layer is currently " + transform.parent.gameObject.layer);
        Debug.Log("This objects layer is currently " + gameObject.layer);
        //CheckForObjectsInFront();//run method to check for blocking objects via raycast
        transform.parent.gameObject.layer = 0;//back to default layer
        gameObject.layer = 0;//back to default layer
        Debug.Log("The parents layer is now " + transform.parent.gameObject.layer + " and this objects layer is: " + gameObject.layer);
    }

    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward);
    }

    public void CheckForObjectsInFront()
    {

        if(!IsDefault)
        {
            Debug.Log("I am the default connecter: " + IsDefault + " if true, I am error");

            if (Physics.Raycast(transform.position, transform.forward, out hit, 15f))
            {
                Debug.Log("Hit a: " + hit.transform.parent);
                if (hit.transform.parent.tag == "Procedural")
                {
                    //if (hit.transform.gameObject != this.gameObject && !this.gameObject.transform.parent)
                    //
                        st = States.Blockedfront;
                        StateMachine(st);
                        Debug.Log("Current state is " + st, gameObject);
                    //}
                }
                else if (hit.transform.parent.parent.tag == "Procedural")
                {
                    //if (hit.transform.gameObject != this.gameObject && !this.gameObject.transform.parent)
                    //{
                        st = States.Blockedfront;
                        StateMachine(st);
                        Debug.Log("Current state is " + st, gameObject);
                    //}
                }
                else if (hit.transform.parent.parent.parent.tag == "Procedural")
                {
                    //if (hit.transform.gameObject != this.gameObject && !this.gameObject.transform.parent)
                    //{
                        st = States.Blockedfront;
                        StateMachine(st);
                        Debug.Log("Current state is " + st, gameObject);
                    //}
                }
            }

            else if (Physics.Raycast(transform.position, (transform.up + transform.forward/2), out hit, 15f))
            {
                Debug.Log("Hit a: " + hit.transform.parent);
                if (hit.transform.parent.tag == "Procedural")
                {
                    st = States.Blockedabove;
                    StateMachine(st);
                    Debug.Log("Current state is " + st, gameObject);
                }
                else if (hit.transform.parent.parent.tag == "Procedural")
                {
                    //if(hit.transform.gameObject != this.gameObject && !this.gameObject.transform.parent )
                    //{
                        st = States.Blockedabove;
                        StateMachine(st);
                        Debug.Log("Current state is " + st, gameObject);
                    //}
                }
                else if (hit.transform.parent.parent.parent.tag == "Procedural")
                {
                    //if (hit.transform.gameObject != this.gameObject && !this.gameObject.transform.parent)
                    //{
                        st = States.Blockedabove;
                        StateMachine(st);
                        Debug.Log("Current state is " + st, gameObject);
                    //}
                }
            }

            else if (Physics.Raycast(transform.position, (-transform.up + transform.forward/2), out hit, 15f))
            {
                Debug.Log("Hit a: " + hit.transform.parent);
                if (hit.transform.parent.tag == "Procedural")
                {
                    //if (hit.transform.gameObject != this.gameObject && !this.gameObject.transform.parent)
                    //{
                        st = States.Blockedbelow;
                        StateMachine(st);
                        Debug.Log("Current state is " + st, gameObject);
                    //}
                }
                else if (hit.transform.parent.parent.tag == "Procedural")
                {
                    //if (hit.transform.gameObject != this.gameObject && !this.gameObject.transform.parent)
                    //{
                        st = States.Blockedbelow;
                        StateMachine(st);
                        Debug.Log("Current state is " + st, gameObject);
                    //}
                }
                else if (hit.transform.parent.parent.parent.tag == "Procedural")
                {
                    //if (hit.transform.gameObject != this.gameObject && !this.gameObject.transform.parent)
                    //{
                        st = States.Blockedbelow;
                        StateMachine(st);
                        Debug.Log("Current state is " + st, gameObject);
                    //}
                }
            }

            else if (Physics.Raycast(transform.position, (-transform.right + transform.forward/2), out hit, 15f))
            {
                Debug.Log("Hit a: " + hit.transform.parent);
                if (hit.transform.parent.tag == "Procedural")
                {
                    //if (hit.transform.gameObject != this.gameObject && !this.gameObject.transform.parent)
                    //{
                        st = States.Blockedleft;
                        StateMachine(st);
                        Debug.Log("Current state is " + st, gameObject);
                    //}
                }
                else if (hit.transform.parent.parent.tag == "Procedural")
                {
                    //if (hit.transform.gameObject != this.gameObject && !this.gameObject.transform.parent)
                    //{
                        st = States.Blockedleft;
                        StateMachine(st);
                        Debug.Log("Current state is " + st, gameObject);
                    //}
                }
                else if (hit.transform.parent.parent.parent.tag == "Procedural")
                {
                    //if (hit.transform.gameObject != this.gameObject && !this.gameObject.transform.parent)
                    //{
                        st = States.Blockedleft;
                        StateMachine(st);
                        Debug.Log("Current state is " + st, gameObject);
                    //}
                }
            }

            else if (Physics.Raycast(transform.position, (transform.right + transform.forward/2), out hit, 15f))
            {
                Debug.Log("Hit a: " + hit.transform.parent);
                if (hit.transform.parent.tag == "Procedural")
                {
                    //if (hit.transform.gameObject != this.gameObject && !this.gameObject.transform.parent)
                    //{
                        st = States.Blockedright;
                        StateMachine(st);
                        Debug.Log("Current state is " + st, gameObject);
                    //}
                }
                else if (hit.transform.parent.parent.tag == "Procedural")
                {
                    //if (hit.transform.gameObject != this.gameObject && !this.gameObject.transform.parent)
                    //{
                        st = States.Blockedright;
                        StateMachine(st);
                        Debug.Log("Current state is " + st, gameObject);
                    //}
                }
                else if (hit.transform.parent.parent.parent.tag == "Procedural")
                {
                    //if (hit.transform.gameObject != this.gameObject && !this.gameObject.transform.parent)
                    //{
                        st = States.Blockedright;
                        StateMachine(st);
                        Debug.Log("Current state is " + st, gameObject);
                    //}
                }
            }
        }
    }
    void OnDrawGizmos()
	{
		var scale = 1.0f;

		Gizmos.color = Color.blue;
		Gizmos.DrawLine(transform.position, transform.position + transform.forward * scale);

		Gizmos.color = Color.red;
		Gizmos.DrawLine(transform.position, transform.position - transform.right * scale);
		Gizmos.DrawLine(transform.position, transform.position + transform.right * scale);

		Gizmos.color = Color.green;
		Gizmos.DrawLine(transform.position, transform.position + Vector3.up * scale);

		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere(transform.position, 0.125f);
	}

    public string StateMachine(States state)
    {
        if(state == States.Blockedfront)
        {
            Tags[0] = LeftSideTags[0];
        }
        else if (state == States.Blockedleft)
        {
            //Tags[0] = RightSideTags[0];
        }
        else if (state == States.Blockedright)
        {
            //Tags[0] = AboveTags[0];
        }
        else if (state == States.Blockedabove)
        {
            Tags[0] = BelowTags[0];
        }
        else if (state == States.Blockedbelow)
        {
            //nothing
        }

        return Tags[0];
    }
}
