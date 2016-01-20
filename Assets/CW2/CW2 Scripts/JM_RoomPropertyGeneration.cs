using UnityEngine;
using System.Collections;

public class JM_RoomPropertyGeneration : MonoBehaviour
{
    public string[] properties = new string[] { "Healthy Enemies", "Strength", "Horde", "Gotta Go Fast", "None" };//array hold potential room properties.
    int i;//variable to access array variables
    public string RoomProperty;//variable to be assigned to room property.

	// Use this for initialization
	void Start ()
    {
        AssignProperty();//assign property to room
	}

    void AssignProperty()//method ot assign properties to rooms
    {
        i = Random.Range(0, 4);//select a number in a random range
        RoomProperty = properties[i];//property is a randomly selected one from an array.
    }
}
