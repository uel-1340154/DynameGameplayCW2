using UnityEngine;

public class Module : MonoBehaviour
{
    public string[] Tags;

    bool overlap;

    public ModuleConnector[] GetExits()
    {
        return GetComponentsInChildren<ModuleConnector>();
    }
}
