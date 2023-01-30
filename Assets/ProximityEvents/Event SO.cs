using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProximityEvent : ScriptableObject
{
    #region Activates
    public virtual void Activate(GameObject self, GameObject target) 
    {
        Debug.Log("No Event Found");
    }
    public virtual void Activate(GameObject self, GameObject target, List<GameObject> additionalTargets)
    {
        Debug.Log("No Event Found");
    }

    #endregion

    #region Deactivates
    public virtual void Deactivate(GameObject self, GameObject target)
    {
        Debug.Log("No Event Found");
    }
    public virtual void Deactivate(GameObject self, GameObject target, List<GameObject> additionalTargets)
    {
        Debug.Log("No Event Found");
    }

    #endregion
}
