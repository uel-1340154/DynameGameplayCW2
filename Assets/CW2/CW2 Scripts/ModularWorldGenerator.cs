﻿using System.Linq;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ModularWorldGenerator : MonoBehaviour
{
    public Module[] Modules;
    public Module StartModule;
    public Module EndModule;

    public List<Module> rooms;
    public List<Module> level;

    public int Iterations = 8;

    public List<ModuleConnector> pendingExits;

    IEnumerator RestartCoroutine()
    {
        Debug.Log("Got called to restart again!");
        Debug.Log("The level list should contain: " + level.Count + " Elements!");
        yield return new WaitForSeconds(2);
        Awake();
    }

    void Awake()
    {
        var startModule = (Module)Instantiate(StartModule, transform.position, transform.rotation);
        pendingExits = new List<ModuleConnector>(startModule.GetExits());

        level.Add(startModule);//adds first module to level list as it is instantiated before the loop

        for (int iteration = 0; iteration <= Iterations; iteration++)//while iteration is less than Iterations
        {
            var newExits = new List<ModuleConnector>();//create a new list of module connectors

            foreach (var pendingExit in pendingExits)//for each exit in the pendingexits list
            {
                pendingExit.GetComponent<ModuleConnector>().CheckForObjectsInFront();               
                var newTag = GetRandom(pendingExit.Tags);//select a random applicable tag to the exit
                Debug.Log("This exits tag is: " + newTag, pendingExit.gameObject);
                var newModulePrefab = GetRandomWithTag(Modules, newTag);//find a module with the appropriate tag
                var newModule = (Module)Instantiate(newModulePrefab);//instantiate said module
                if (newModule.Tags[0] == "Room")//if the first tag of the module is a room
                {
                    rooms.Add(newModule);//add it to the rooms list
                }
                level.Add(newModule);//add all modules (per iteration) to the level list
                var newModuleExits = newModule.GetExits();//access the exits of the new module
                var exitToMatch = newModuleExits.FirstOrDefault(x => x.IsDefault) ?? GetRandom(newModuleExits);//check if the exit is the first or default then get the module exits
                MatchExits(pendingExit, exitToMatch);//match the currently pending exit to the new module exit
                newExits.AddRange(newModuleExits.Where(e => e != exitToMatch));//add the new module exits to the next exits list
            }
            pendingExits = newExits;//assign the new exits to the pendingExits list.
        }

        if (rooms.Count < 7)//if there are less than 8 rooms
        {
            ClearLevel();//clear the level
        }

        Smoothing(pendingExits);//we can then smooth the level out, ready to make.
    }

    void ClearLevel()//pass a room list and level list
    {
        level = level.ToList();
        rooms = rooms.ToList();
        foreach (Module room in level)//for each of the modules in the level
        {
            Destroy(room.gameObject);//destroy them
            level.ToList().Remove(room);
        }
        level.Clear();//clear the level list
        rooms.Clear();//clear the room list
        StartCoroutine(RestartCoroutine());//start coroutine to restart this method as it hasn't generated enough rooms
    }
    //Original method written to circumvent the issue of doors not leading to rooms
    //written by 1340154 on 29/12/2015
    void Smoothing(List<ModuleConnector> RemainingExits)//method with a list parameter, for the intent of smoothing the level out.
    {
        Debug.Log("Smoothening the game!");
        var newExits = new List<ModuleConnector>();//creates a new lsit instance
        int ExtraIterations = 2;
        int extraiterationcount;
        bool Finalroomadded;

        Finalroomadded = false;

        for(extraiterationcount = 0; extraiterationcount < ExtraIterations; extraiterationcount++)
        {
            foreach (var remainingexit in RemainingExits.ToList())//ToList() function creates clone of current list that can be used in IEnumerable operations such as foreach loops.
            {
                //remainingexit.GetComponent<ModuleConnector>().CheckForObjectsInFront();
                if (remainingexit.GetComponentInParent<Module>().Tags[0] == "Corridor" || remainingexit.GetComponentInParent<Module>().Tags[0] == "DownStairs" || remainingexit.GetComponentInParent<Module>().Tags[0] == "LeftTurnCorridor" && !Finalroomadded)//check if the module is a corridor
                {
                    Debug.Log("Adding the final room!");
                    var newModulePrefab = EndModule;
                    var newModule = (Module)Instantiate(newModulePrefab);
                    var newModuleExits = newModule.GetExits();
                    var exitToMatch = newModuleExits.FirstOrDefault(x => x.IsDefault) ?? GetRandom(newModuleExits);
                    MatchExits(remainingexit, exitToMatch);
                    newExits.AddRange(newModuleExits.Where(e => e != exitToMatch));
                    Finalroomadded = true;
                }
                else if (remainingexit.GetComponentInParent<Module>().Tags[0] == "Corridor" || remainingexit.GetComponentInParent<Module>().Tags[0] == "DownStairs" || remainingexit.GetComponentInParent<Module>().Tags[0] == "LeftTurnCorridor" && Finalroomadded)//check if the module is a corridor
                {
                    var newTag = GetRandom(remainingexit.Tags); //try and truncate remaining corridors by forcing them to select specific rooms
                    var newModulePrefab = GetRandomWithTag(Modules, newTag);
                    var newModule = (Module)Instantiate(newModulePrefab);
                    var newModuleExits = newModule.GetExits();
                    var exitToMatch = newModuleExits.FirstOrDefault(x => x.IsDefault) ?? GetRandom(newModuleExits);
                    MatchExits(remainingexit, exitToMatch);
                    newExits.AddRange(newModuleExits.Where(e => e != exitToMatch));
                }
                else if (remainingexit.GetComponentInParent<Module>().Tags[0] == "Room")//check ifthe module is a room.
                {
                    var newTag = GetRandom(remainingexit.Tags);
                    var newModulePrefab = GetRandomWithTag(Modules, newTag);
                    var newModule = (Module)Instantiate(newModulePrefab);
                    var newModuleExits = newModule.GetExits();
                    var exitToMatch = newModuleExits.FirstOrDefault(x => x.IsDefault) ?? GetRandom(newModuleExits);
                    MatchExits(remainingexit, exitToMatch);
                    newExits.AddRange(newModuleExits.Where(e => e != exitToMatch));
                }
            }
            RemainingExits = newExits;//assigns the new exits found from the modules to the RemainingExits list.
        }
    }    

    private void MatchExits(ModuleConnector oldExit, ModuleConnector newExit)
	{
		var newModule = newExit.transform.parent;
		var forwardVectorToMatch = -oldExit.transform.forward;
		var correctiveRotation = Azimuth(forwardVectorToMatch) - Azimuth(newExit.transform.forward);
		newModule.RotateAround(newExit.transform.position, Vector3.up, correctiveRotation);
		var correctiveTranslation = oldExit.transform.position - newExit.transform.position;
		newModule.transform.position += correctiveTranslation;
	}


	public static TItem GetRandom<TItem>(TItem[] array)
	{
        return array[Random.Range(0, array.Length)];
	}


	private static Module GetRandomWithTag(IEnumerable<Module> modules, string tagToMatch)
	{
		var matchingModules = modules.Where(m => m.Tags.Contains(tagToMatch)).ToArray();
		return GetRandom(matchingModules);
	}


	private static float Azimuth(Vector3 vector)
	{
		return Vector3.Angle(Vector3.forward, vector) * Mathf.Sign(vector.x);
	}
}
