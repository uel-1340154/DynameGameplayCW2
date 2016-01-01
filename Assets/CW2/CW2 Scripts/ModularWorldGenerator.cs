using System.Linq;
using UnityEngine;
using System.Collections.Generic;

public class ModularWorldGenerator : MonoBehaviour
{
	public Module[] Modules;
	public Module StartModule;

	public int Iterations = 5;


	void Start()
	{
		var startModule = (Module) Instantiate(StartModule, transform.position, transform.rotation);
		var pendingExits = new List<ModuleConnector>(startModule.GetExits());

        int iteration;


        for (iteration = 0; iteration <= Iterations; iteration++)
		{
            var newExits = new List<ModuleConnector>();

            foreach (var pendingExit in pendingExits)
			{
				var newTag = GetRandom(pendingExit.Tags);
				var newModulePrefab = GetRandomWithTag(Modules, newTag);
				var newModule = (Module) Instantiate(newModulePrefab);
				var newModuleExits = newModule.GetExits();
				var exitToMatch = newModuleExits.FirstOrDefault(x => x.IsDefault) ?? GetRandom(newModuleExits);
				MatchExits(pendingExit, exitToMatch);
				newExits.AddRange(newModuleExits.Where(e => e != exitToMatch));
			}

            pendingExits = newExits;
        }

        Smoothing(pendingExits);
	}

    //Original method written to circumvent the issue of doors not leading to rooms
    //written by 1340154 on 29/12/2015
    void Smoothing(List<ModuleConnector> RemainingExits)
    {
        Debug.Log("smoothing the level out!");
        var newExits = new List<ModuleConnector>();
        int ExtraIterations = 5;
        int extraiterationcount;

        for(extraiterationcount = 0; extraiterationcount < ExtraIterations; extraiterationcount++)
        {
            foreach (var remainingexit in RemainingExits.ToList())//ToList() function creates clone of current list that can be used in IEnumerable operations such as foreach loops.
            {
                if (remainingexit.GetComponentInParent<Module>().Tags[0] == "Corridor")//check if the module is a corridor
                {
                    var newTag = "Room1Door";//try and truncate remaining corridors by forcing them to select specific rooms
                    var newModulePrefab = GetRandomWithTag(Modules, newTag);
                    var newModule = (Module)Instantiate(newModulePrefab);
                    var newModuleExits = newModule.GetExits();
                    var exitToMatch = newModuleExits.FirstOrDefault(x => x.IsDefault) ?? GetRandom(newModuleExits);
                    MatchExits(remainingexit, exitToMatch);
                    newExits.AddRange(newModuleExits.Where(e => e != exitToMatch));
                }
                else if (remainingexit.GetComponentInParent<Module>().Tags[0] == "Room")//check ifthe module is a room.
                {
                    Debug.Log("Giving a room a corridor");
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
